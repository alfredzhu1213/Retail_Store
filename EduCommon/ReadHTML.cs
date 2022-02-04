using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.IO;

namespace Common
{
    public static class ReadHTML
    {
        public static string ToStr(string url)
        {
            string str = string.Empty;//ConfigurationManager.AppSettings["DoMain"] + "login.aspx";
            try
            {
                WebRequest request = WebRequest.Create(url);
                //定义对上面WEB请求的反应 
                WebResponse response = request.GetResponse();
                //取得WEB响应的数据流 
                Stream resStream = response.GetResponseStream();
                //根据上面定义的数据流，以默认编码的方式定义一个读数据流 
                StreamReader sr = new StreamReader(resStream, System.Text.Encoding.Default);
                // 读取数据流中的内容 
                str = sr.ReadToEnd();
                //关闭数据流 
                resStream.Close();
                //关闭读数据流并释放资源 
                sr.Close();
            }
            catch
            {
            }
            return str;
        }
    }
}
