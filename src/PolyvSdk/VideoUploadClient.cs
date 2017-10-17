using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PolyvSdk
{
    public class VideoUploadClient : IDisposable
    {
        private HttpClient _httpClient = new HttpClient();
        public VideoUploadClient(PolyvOptions options)
        {
            Options = options;
        }
        public VideoUploadClient(PolyvOptions options,HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public PolyvOptions Options { get; }

        public HttpClient HttpClient
        {
            get => _httpClient;
            set => _httpClient = value;
        }

        public async Task<Video> UploadAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<Video> ResumableUploadAsync()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Do not dispose this Object, if your <see cref="HttpClient"/> still need to use.
        /// </summary>
        public void Dispose()
        {
            HttpClient?.Dispose();
        }
    }
}
