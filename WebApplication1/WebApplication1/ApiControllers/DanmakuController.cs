using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.ApiControllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DanmakuController : ControllerBase
    {

        /// <summary>
        ///参数1（157.47900）：弹幕出现的时间，以秒数为单位
        ///参数2（1）：弹幕的模式，1-3 滚动弹幕，4 底端弹幕，5顶端弹幕，6 逆向弹幕，7 精准定位，8 高级弹幕
        ///参数3（25）：字号 （12非常小，16特小，18小，25中，36大，45很大，64特别大）
        ///参数4（16777215）：字体的颜色；这串数字是十进制表示；通常软件中使用的是十六进制颜色码；
        ///e.g:
        ///白色
        /// RGB值：(255,255,255)
        ///十进制值：16777215
        ///十六进制值：#FFFFFF
        ///参数5（1548340494）：unix时间戳，从1970年1月1日（UTC/GMT的午夜）开始所经过的秒数
        ///参数6（0）：弹幕池，0普通池，1字幕池，2特殊池 【目前特殊池为高级弹幕专用】
        ///参数7（389b20da）：发送者的ID，用于“屏蔽此弹幕的发送者”功能
        ///参数8（11114024647262210）：弹幕在弹幕数据库中rowID 用于“历史弹幕”功能。
        /// </summary>
        /// <param name="id"></param>
        /// <param name="v"></param>
        /// <returns></returns>
        [Route("{v}")]
        [HttpGet]
        public DankamuModel GetListByVideoId([FromQuery] int id, [FromRoute] string v)
        {
            DankamuModel result = new DankamuModel();
            if (id == 1)
            {
                object[] tmp = new object[5];
                object[] item = new object[] { "0.1", 5, 16777215, "I", " hello " };
                tmp[0] = item;
                item = new object[] { "1", 1, 16777215, "You", " Hi " };
                tmp[1] = item;
                item = new object[] { "2", 2, 16777215, "You", " Hi11 " };
                tmp[2] = item;
                item = new object[] { "3", 3, 16777215, "You", " Hi22 " };
                tmp[3] = item;
                item = new object[] { "4", 4, 16777215, "You", " Hi33 " };
                tmp[4] = item;

                result.data = tmp;
            }


            return result;
        }
    }
}
