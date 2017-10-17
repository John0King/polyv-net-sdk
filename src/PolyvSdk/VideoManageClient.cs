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
    /// 用于管理视频的 客户端，用户获取，删除，添加视频
    /// </summary>
    public class VideoManageClient : IDisposable
    {
        private HttpClient _httpClient = new HttpClient();

        /// <summary>
        /// 实例化一个视频管理客户端
        /// </summary>
        /// <param name="options"></param>
        public VideoManageClient(PolyvOptions options)
        {
            Options = options;
        }
        public PolyvOptions Options { get; }

        public HttpClient HttpClient
        {
            get => _httpClient;
            set => _httpClient = value;
        }

        public void Dispose()
        {
            _httpClient?.Dispose();
        }

        public async Task<IList<Video>> GetVideoListAsync(int page, int pageSize)
        {
            var json = await HttpClient.GetStringAsync($"http://v.polyv.net/uc/services/rest?method=getNewList&readtoken={ Options.ReadToken }&pageNum={ page }&numPerPage={pageSize}");
            return JsonConvert.DeserializeObject<List<Video>>(json);
        }

        public async Task<bool> DeleteVideoAsync(string videoId)
        {
            var json = await HttpClient.GetStringAsync($"http://v.polyv.net/uc/services/rest?method=delVideoById&writetoken={ Options.WriteToken }&vid={ videoId }");
            var error = JObject.Parse(json).Value<int>("error");
            if (error == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<Video> GetVideoAsync(string videoId)
        {
            var json = await HttpClient.GetStringAsync($"http://v.polyv.net/uc/services/rest?method=getById&readtoken={ Options.ReadToken }&vid={ videoId }");
            return JsonConvert.DeserializeObject<Video>(json);
        }


        /// <summary>
        /// 上传视频
        /// </summary>
        /// <returns></returns>
        public Task<Video> UploadVideoAsync()
        {
            var uploader = new VideoUploadClient(Options, HttpClient);
            return uploader.UploadAsync();
        }

        /// <summary>
        /// 断点续传
        /// </summary>
        /// <returns></returns>
        public Task<Video> ResumableUploadAsync()
        {
            var uploader = new VideoUploadClient(Options, HttpClient);
            return uploader.ResumableUploadAsync();
        }
    }
}
