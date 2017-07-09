using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll
{
    public class WaysOfString
    {
        /// <summary>
        /// 返回当前时间的字符串形式
        /// </summary>
        /// <returns></returns>
        public static string ReturnNowTimeString() {
            string nowTime = DateTime.Now.ToString();
            nowTime = nowTime.Replace(" ", "");
            nowTime = nowTime.Replace(":", "");
            nowTime = nowTime.Replace("/", "");
            return nowTime;
        }
    }
}
