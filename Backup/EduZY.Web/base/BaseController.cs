using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.Web;
using System.IO;
namespace Base
{
    public class BaseController : Controller
    {
       

        /// <summary>
        /// 默认PageSize，从配置文件中读取
        /// </summary>
       
        /// <summary>
        /// 当前的用户id
        /// </summary>
        protected int CurrentUserID
        {
            get
            {
                if (Request != null && Request.Cookies["AdminCookie"] != null)
                {
                    HttpCookie cookie = Request.Cookies["AdminCookie"];
                    return Convert.ToInt32(cookie.Values["UserID"]);
                }
                else
                {
                    return 0;
                }
            }
        }

     
        /// <summary>
        /// 当前的用户名
        /// </summary>
        protected string CurrentUserName
        {
            get
            {
                HttpCookie cookie = Request.Cookies["AdminCookie"];
                if (cookie == null)
                {
                    return "";
                }
                return HttpUtility.UrlDecode(cookie.Values["UserName"].ToString());
            }
        }

        protected string DBName
        {
            get
            {
                HttpCookie cookie = Request.Cookies["AdminCookie"];
                if (cookie == null)
                {
                    return "";
                }
                return HttpUtility.UrlDecode(cookie.Values["DBName"].ToString());
            }
        }

        protected string StoreName
        {
            get
            {
                HttpCookie cookie = Request.Cookies["AdminCookie"];
                if (cookie == null)
                {
                    return "";
                }
                return HttpUtility.UrlDecode(cookie.Values["StoreName"].ToString());
            }
        }
        protected string StoreNames
        {
            get
            {
                HttpCookie cookie = Request.Cookies["AdminCookie"];
                if (cookie == null)
                {
                    return "";
                }
                return HttpUtility.UrlDecode(cookie.Values["StoreNames"].ToString());
            }
        }
        protected string StoreId
        {
            get
            {
                HttpCookie cookie = Request.Cookies["AdminCookie"];
                if (cookie == null)
                {
                    return "'0'";
                }
                return HttpUtility.UrlDecode(cookie.Values["StoreId"].ToString().TrimEnd(','));
            }
        }     
    }


}
