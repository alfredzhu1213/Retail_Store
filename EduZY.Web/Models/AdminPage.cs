using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.CodeDom.Compiler;
using System.Reflection;
using Common;
using System.Text.RegularExpressions;
using System.Net;
using System.IO;
using System.Configuration;
using System.Web.Security;
using System.Data.SqlClient;
using System.Web.UI;

using System.Text;
using System.Security.Cryptography;
using Maticsoft.DBUtility;
using EduJXC.Model;
namespace Common
{


     public class AdminPage
     {
         
         public static bool UserLogin(string UserName, string Pwd, out string msg, out UserMaster user)
         {
             bool bflag = false; msg = ""; user = new UserMaster();
             SqlParameter[] parameters = {
                new SqlParameter("@UserName",SqlDbType.VarChar,80),
                new SqlParameter("@UserPWd",SqlDbType.VarChar,80)};
             parameters[0].Value = UserName;
             parameters[1].Value = Units.MD5(Pwd);
             try
             {
                 DataSet ds = new DataSet();
                 DbHelperSQL.RunProcedure("Up_Login", parameters, out ds);
                 if (ds.Tables[0].Rows.Count > 0)
                 {
                     DataRow dr = ds.Tables[0].Rows[0];
                     msg = dr["msg"] + "";
                     if (msg == "1")
                     {
                         user.RoleID =dr["RoleID"].ToString();
                         user.UserID = Convert.ToInt32(dr["UserID"]);
                         user.UserName = dr["UserName"] + "";
                         user.DBName = dr["DBName"] + "";
                         user.TrueName = dr["TrueName"] + "";
                         user.StoreName = dr["StoreName"] + "";
                         
                         
                         bflag = true;
                     }

                 }
                 else
                     msg = "用户或密码错误";
             }
             catch
             {
                 msg = "登录失败";
             }
             return bflag;
         }

         public static void Logout()
         {

             HttpCookie cookie = new HttpCookie("AdminCookie");
             if (cookie != null)
             {
                 cookie.Expires = DateTime.Now.AddDays(-1);
                 HttpContext.Current.Response.AppendCookie(cookie);
                 FormsAuthentication.SignOut();
             }
         }
         /// <summary>
         /// 写登录用户的cookie
         /// </summary>
         /// <param name="userinfo">用户信息</param>
         /// <param name="expires">cookie有效期 分钟</param>
         /// <param name="passwordkey">用户密码Key</param>
         public static void WriteUserCookie(UserMaster userinfo)
         {
       

             if (userinfo == null)
                 return;
             string guid = Guid.NewGuid().ToString();
             HttpCookie cookie = new HttpCookie("AdminCookie");

             cookie.Values["UserName"] = HttpUtility.UrlEncode(userinfo.UserName);
             cookie.Values["UserID"] = HttpUtility.UrlEncode(userinfo.UserID.ToString());
             cookie.Values["RoleID"] = HttpUtility.UrlEncode(userinfo.RoleID.ToString());
             cookie.Values["DBName"] = HttpUtility.UrlEncode(userinfo.DBName.ToString());
             cookie.Values["TrueName"] = HttpUtility.UrlEncode(userinfo.TrueName.ToString());
            
             
             cookie.Values["Guid"] = guid;

             DataSet dss = DbHelperSQL.Query("select * FROM tb_UserManageStore where userid='" + userinfo.UserID + "'");
             if (dss != null)
             {
                 string ids = "";
                 string names = "";
                 string namess = "";
                 foreach (DataRow dr in dss.Tables[0].Rows)
                 {
                     ids += dr["StoreId"] + ",";
                     names += "'" + dr["StoreName"] + "',";
                     namess += "" + dr["StoreName"] + ",";
                 }
                 cookie.Values["StoreId"] = HttpUtility.UrlEncode(ids.TrimEnd(','));
                 cookie.Values["StoreName"] = HttpUtility.UrlEncode(names.TrimEnd(','));
                 cookie.Values["StoreNames"] = HttpUtility.UrlEncode(namess.TrimEnd(','));
             }
             else
             {
                 cookie.Values["StoreId"] = HttpUtility.UrlEncode("0");
                 cookie.Values["StoreName"] = HttpUtility.UrlEncode("未设置门店");
             }

             cookie.Expires = DateTime.Now.AddMinutes(200);
             HttpContext.Current.Response.AppendCookie(cookie);

             System.Web.Caching.Cache cache = HttpRuntime.Cache;
             cache.Insert(userinfo.UserID.ToString(), guid, null, System.DateTime.Now.AddMinutes(10), TimeSpan.Zero);

         }


         /// <summary>
         /// 网站登录用户ID
         /// </summary>
         /// <returns></returns>
         public static int UserID()
         {
             int userid = -1;
             try
             {

                 HttpCookie cookie = HttpContext.Current.Request.Cookies["AdminCookie"];
                 userid = Convert.ToInt32(cookie.Values["UserID"]);
             }
             catch
             {
                 userid = -1;
             }
             return userid;
         }

         public static string LoginName()
         {
             string str = "";
             try
             {
                 HttpCookie cookie = HttpContext.Current.Request.Cookies["AdminCookie"];
                 str = Convert.ToString(cookie.Values["UserName"]);
             }
             catch
             {
                 str = "";
             }
             return str;
         }


         /// <summary>
         /// 用户角色
         /// </summary>
         /// <returns></returns>
         public static int RoleID()
         {
             int str = 0;
             try
             {
       
                 HttpCookie cookie = HttpContext.Current.Request.Cookies["AdminCookie"];
                 str = Convert.ToInt32(cookie.Values["RoleID"]);

             }
             catch
             {
                 str = 0;
             }
             return str;
         }
      
     }
}
