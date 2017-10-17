using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace PolyvSdk
{
    /// <summary>
    /// 用于管理视频的 客户端
    /// </summary>
    public class VideoManageClient:IDisposable
    {
        private HttpClient _httpClient = new HttpClient();
        public HttpClient HttpClient
        {
            get => _httpClient ;
            set => _httpClient = value;
        }

        public string ReadToken { get; set; }
        public string WriteToken { get; set; }
        public void Dispose()
        {
            _httpClient?.Dispose();
        }

        public async Task<IList<Video>> GetVideoListAsync(int page,int pageSize)
        {
            var json = await HttpClient.GetStringAsync($"http://v.polyv.net/uc/services/rest?method=getNewList&readtoken={ ReadToken }&pageNum={ page }&numPerPage={pageSize}");
            return JsonConvert.DeserializeObject<List<Video>>(json);
        }

        public async Task<bool> DeleteVideo(string videoId)
        {
            var json = await HttpClient.GetStringAsync($"http://v.polyv.net/uc/services/rest?method=delVideoById&writetoken={ WriteToken }&vid={ videoId }");
            var error = JObject.Parse(json).Value<int>("error");
            if(error == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<Video> GetVideo(string videoId)
        {
            var json = await HttpClient.GetStringAsync($"http://v.polyv.net/uc/services/rest?method=getById&readtoken={ ReadToken }&vid={ videoId }");
            return JsonConvert.DeserializeObject<Video>(json);
        }

    }
}
