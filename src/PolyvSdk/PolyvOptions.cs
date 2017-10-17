using System;
using System.Collections.Generic;
using System.Text;

namespace PolyvSdk
{
    public class PolyvOptions
    {
        /// <summary>
        /// 用于保利威视服务器与您的服务器进行通讯的时候的身份验证
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// 读密钥，用来从保利威视服务器上读取数据
        /// </summary>
        public string ReadToken { get; set; }

        /// <summary>
        /// 写密钥，用来向保利威视服务器上写入数据
        /// </summary>
        public string WriteToken { get; set; }

        /// <summary>
        /// 调用保利威视的API接口做签名访问时要用到
        /// </summary>
        public string SecretKey { get; set; }

    }
}
