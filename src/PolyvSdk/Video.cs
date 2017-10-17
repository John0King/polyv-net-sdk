using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace PolyvSdk
{

    [JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    public class Video
    {

        public string SwfLink { get; set; }

        public int SourceFileSize { get; set; }

        public int Status { get; set; }
        public string Tag { get; set; }
        public int Seed { get; set; }
        public int PlayerWidth { get; set; }
        public List<long> FileSize { get; set; }
        public string Duration { get; set; }
        public string Title { get; set; }
        public int Df { get; set; }
        public string FirstImage { get; set; }
        public int Times { get; set; }
        public string Context { get; set; }
        public string OriginalDefinition { get; set; }
        public int PlayerHeight { get; set; }
        public string Vid { get; set; }
        public string Ptime { get; set; }
        public long Cataid { get; set; }
        
    }
}
