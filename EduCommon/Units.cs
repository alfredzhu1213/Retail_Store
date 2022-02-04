using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Security.Cryptography;

namespace Common
{
    /// <summary>
    /// 数据类型转换与获取地址参数类
    /// </summary>
    public static class Units
    {

        /// <summary>
        /// MD5函数
        /// </summary>
        /// <param name="str">原始字符串</param>
        /// <returns>MD5结果</returns>
        public static string MD5(string str)
        {
            byte[] b = Encoding.UTF8.GetBytes(str);
            b = new MD5CryptoServiceProvider().ComputeHash(b);
            string ret = "";
            for (int i = 0; i < b.Length; i++)
                ret += b[i].ToString("x").PadLeft(2, '0');

            return ret;
        }



        /// <summary>
        /// 获取querystring
        /// </summary>
        /// <returns></returns>
        public static string GetQueryValue(string query)
        {
            try
            {
                if (HttpContext.Current.Request[query] == null)
                {
                    return "";
                }
                else
                {
                    return HttpContext.Current.Request[query].ToString();
                }
            }
            catch
            {
                return "";
            }
        }

        /// <summary>
        /// 获取整型querystring
        /// </summary>
        /// <param name="qs">参数名</param>
        /// <returns></returns>
        public static int GetIntQS(string qs)
        {
            return ToInt(GetQueryValue(qs));
        }

        /// <summary>
        /// 获取字符型querystring
        /// </summary>
        /// <param name="qs">参数名</param>
        /// <returns></returns>
        public static string GetStringQS(string qs)
        {
            if (GetQueryValue(qs) == null)
            {
                return "";
            }
            return GetQueryValue(qs);
        }

        public static bool CheckNullQS(string qs)
        {
            return HttpContext.Current.Request.QueryString[qs] != null;
        }

        /// <summary>
        /// 转为整型
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static int ToInt(object obj)
        {
            try
            {
                if ((obj != DBNull.Value) && (obj != null))
                    return Convert.ToInt32(obj);
                else
                    return 0;
            }
            catch
            {
                return 0;
            }
        }

        /// <summary>
        /// 转为时间类型
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static DateTime ToDateTime(object obj)
        {
            try
            {
                if ((obj != DBNull.Value) && (obj != null))
                    return Convert.ToDateTime(obj);
                else
                    return DateTime.Now;
            }
            catch
            {
                return DateTime.Now;
            }
        }

        /// <summary>
        /// 转为整型
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static decimal ToDecimal(object obj)
        {
            try
            {
                if ((obj != DBNull.Value) && (obj != null))
                    return Convert.ToDecimal(obj);
                else
                    return 0;
            }
            catch
            {
                return 0;
            }
        }
    }
}
