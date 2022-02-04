using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;

namespace Common
{
    /// <summary>
    /// 字符串操作类
    /// </summary>
    public static class StrOperate
    {
        ///   <summary> 
        ///   按字节截断字符串。 
        ///   </summary> 
        public static string GetSubString(string mText, int byteCount)
        {
            if (byteCount < 1) return mText;

            if (System.Text.Encoding.Default.GetByteCount(mText) <= byteCount)
            {
                return mText;
            }
            else
            {
                byte[] txtBytes = System.Text.Encoding.Default.GetBytes(mText);
                byte[] newBytes = new byte[byteCount - 6];

                for (int i = 0; i < byteCount - 6; i++)
                    newBytes[i] = txtBytes[i];

                string str = System.Text.Encoding.Default.GetString(newBytes);
                if (str.Substring(str.Length - 1, 1) == "?")
                    str = str.Substring(0, str.Length - 1);
                return str + "..."; //Replace("?","")替换字节不对应产生的问号
            }
        }

        /// <summary>
        /// 删除html标签
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string DealHtml(string str)
        {
            str = Regex.Replace(str, @"\<(img)[^>]*>|<\/(img)>", "", RegexOptions.IgnoreCase);
            str = Regex.Replace(str, @"\<(table|tbody|tr|td|th|)[^>]*>|<\/(table|tbody|tr|td|th|)>", "", RegexOptions.IgnoreCase);
            str = Regex.Replace(str, @"\<(div|blockquote|fieldset|legend)[^>]*>|<\/(div|blockquote|fieldset|legend)>", "", RegexOptions.IgnoreCase);
            str = Regex.Replace(str, @"\<(font|i|u|h[1-9]|s)[^>]*>|<\/(font|i|u|h[1-9]|s)>", "", RegexOptions.IgnoreCase);
            str = Regex.Replace(str, @"\<(style|strong)[^>]*>|<\/(style|strong)>", "", RegexOptions.IgnoreCase);
            str = Regex.Replace(str, @"\<a[^>]*>|<\/a>", "", RegexOptions.IgnoreCase);
            str = Regex.Replace(str, @"\<(meta|iframe|frame|span|tbody|layer)[^>]*>|<\/(iframe|frame|meta|span|tbody|layer)>", "", RegexOptions.IgnoreCase);
            str = Regex.Replace(str, @"\<a[^>]*", "", RegexOptions.IgnoreCase);

            return str;
        }

        /// <summary>
        /// 截取字符串函数
        /// </summary>
        /// <param name="str">所要截取的字符串</param>
        /// <param name="num">截取字符串的长度</param>
        /// <returns></returns>
        public static string SubString(string str, int num)
        {
            #region
            return (str.Length > num) ? str.Substring(0, num) + "..." : str;
            #endregion
        }

        /// <summary>
        /// 对字符串进行HTML解码
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>

        public static string GetShortDate(object str)
        {
            string sResult = "";
            if (str != null)
            {
                sResult = Convert.ToDateTime(str).ToShortDateString();

            }

            return sResult;
        }


        /// <summary>
        /// 对字符串进行HTML解码
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>

        public static string GetStatus(object str)
        {
            string sResult = "否";
            if (str != null)
            {
                if (Convert.ToInt32(str) ==1)
                {
                    sResult = "是";
                }

            }

            return sResult;
        }

        ///   <summary>   
        ///   截取字符串(适用于中英文混合)   
        ///   </summary>   
        ///   <param   name="str">原字符串</param>   
        ///   <param   name="len">长度</param>   
        ///   <returns></returns>   
        public static string SubChinaString(string str, int len)
        {
            str = str.Trim();
            byte[] myByte = System.Text.Encoding.Default.GetBytes(str);
            if (myByte.Length > len)
            {
                string result = "";
                for (int i = 0; i < str.Length; i++)
                {
                    byte[] tempByte = System.Text.Encoding.Default.GetBytes(result);
                    if (tempByte.Length < len)
                    {
                        result += str.Substring(i, 1);
                    }
                    else
                    {
                        break;
                    }
                }
                return result + "...";
            }
            else
            {
                return str;
            }
        }

    }
}
