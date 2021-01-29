using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.ApiControllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class WebSocketTController : ControllerBase
    {
        private readonly IWebHostEnvironment _hostingEnvironment;

        public WebSocketTController(IWebHostEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        /// <summary>
        /// 直播链接  逻辑上应该是，只要摄像头那边不断读取摄像头的流生成mu38文件和ts文件然后保存到服务器上，这个接口就可以不断读取mu38文件
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public FileResult mu38()
        {
            string path = AppContext.BaseDirectory;
            path = Path.Combine(path, "Files");
            path = Path.Combine(path, "cctv1hd.m3u8");
            string filepath = path;
            //string filepath = @"D:\myprojects\github.com\DPlayerDemo\WebApplication1\WebApplication1\bin\Debug\netcoreapp3.1\Files\cctv1hd.m3u8";
            HttpContext.Response.ContentType = "application/vnd.apple.mpegurl";
            FileContentResult result = new FileContentResult
            (System.IO.File.ReadAllBytes(filepath), "application/vnd.apple.mpegurl")
            {
                FileDownloadName = "cctv1hd.m3u8"
            };
            return result;
        }
    }
}
