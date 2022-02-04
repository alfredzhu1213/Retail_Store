using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Text.RegularExpressions;
using System.Data.SqlClient;



    /// <summary>
    /// WEB信息
    /// </summary>
    public class ServerInfo
    {
        /// <summary>
        /// 取得网站的根目录的URL
        /// </summary>
        /// <returns></returns>
        public static string GetRootURI()
        {
            string AppPath = "";
            HttpContext HttpCurrent = HttpContext.Current;
            HttpRequest Req;
            if (HttpCurrent != null)
            {
                Req = HttpCurrent.Request;

                string UrlAuthority = Req.Url.GetLeftPart(UriPartial.Authority);
                if (Req.ApplicationPath == null || Req.ApplicationPath == "/")
                    //直接安装在   Web   站点   
                    AppPath = UrlAuthority;
                else
                    //安装在虚拟子目录下   
                    AppPath = UrlAuthority + Req.ApplicationPath;
            }
            return AppPath;
        }
        /// <summary>
        /// 取得网站的根目录的URL
        /// </summary>
        /// <param name="Req"></param>
        /// <returns></returns>
        public static string GetRootURI(HttpRequest Req)
        {
            string AppPath = "";
            if (Req != null)
            {
                string UrlAuthority = Req.Url.GetLeftPart(UriPartial.Authority);
                if (Req.ApplicationPath == null || Req.ApplicationPath == "/")
                    //直接安装在   Web   站点   
                    AppPath = UrlAuthority;
                else
                    //安装在虚拟子目录下   
                    AppPath = UrlAuthority + Req.ApplicationPath;
            }
            return AppPath;
        }
        /// <summary>
        /// 取得网站根目录的物理路径
        /// </summary>
        /// <returns></returns>
        public static string GetRootPath()
        {
            string AppPath = "";
            HttpContext HttpCurrent = HttpContext.Current;
            if (HttpCurrent != null)
            {
                AppPath = HttpCurrent.Server.MapPath("~");
            }
            else
            {
                AppPath = AppDomain.CurrentDomain.BaseDirectory;
                if (Regex.Match(AppPath, @"\\$", RegexOptions.Compiled).Success)
                    AppPath = AppPath.Substring(0, AppPath.Length - 1);
            }
            return AppPath;
        }

        public static Object GetObjectByCondition(String columnName, String tblName, String conditions)
        {

            Object str = null;
            try
            {
                Object obj = GetObjectByC(columnName, tblName, conditions);
                if (obj != null)
                {
                    str = obj;
                }
                return str;
            }
            catch
            {
                return str;
            }
        }
        private static Object GetObjectByC(String columnName, String tblName, String conditions)
        {
            Object obj = null;
            SqlDataReader reader = null;
            try
            {
                String sql = "SELECT TOP 1 " + columnName + " as tempstr FROM " + tblName + " WHERE " + conditions;
                reader = Maticsoft.DBUtility.DbHelperSQL.ExecuteReader(sql);
                if (reader.Read())
                {
                    obj = reader["tempstr"] is DBNull ? null : reader["tempstr"];
                }
                reader.Close();
                return obj;
            }
            catch (Exception ea)
            {
                throw ea;
            }
            finally
            {
                reader.Close();
            }

        }
        public static String GetBack_Str(String columnName, String tblName, String conditions)
        {
            object obj = null;
            String b_Str = "";
            String[] temp = { "000", "00", "0", "" };
            try
            {
                obj = GetObjectByCondition(columnName, tblName, conditions);
                if (obj == null)
                {
                    b_Str = "0001";
                }
                else
                {
                    String temStr = Convert.ToString(obj);
                    temStr = temStr.Substring(temStr.Length - 4);
                    b_Str = Convert.ToString(Convert.ToInt32(temStr) + 1);
                }
            }
            catch
            {

            }
            b_Str = temp[b_Str.Length - 1] + b_Str;
            return b_Str;
        }
    }


