using System.Web.Mvc;
using Common;
using System.Web;
using EduZY.Model;
using System;

namespace EduZY.Web
{

    public class SupportFilterAttribute : ActionFilterAttribute
    {

        /// <summary>
        /// 当Action中标注了[SupportFilter]的时候会执行
        /// </summary>
        /// <param name="filterContext">请求上下文</param>
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            HttpCookie cookie = System.Web.HttpContext.Current.Request.Cookies.Get("AdminCookie");
            if (cookie == null)
            {
                filterContext.HttpContext.Response.Write(" <script type='text/javascript'> window.top.location='/Home/Login';</script>");

                return;
            }
            else
            {



                int? CurrentUserID = Convert.ToInt32(cookie.Values["UserID"]);
                string currentURL = filterContext.HttpContext.Request.Url.LocalPath;
                int MenuId = BaseQX.GetMenuID(currentURL);
                filterContext.HttpContext.Session["MenuId"] = MenuId;
                {
                    string res = (filterContext.HttpContext.Session["ReturnUrl"] as string) ?? "";
                    if (!string.IsNullOrEmpty(filterContext.HttpContext.Request["ReturnUrl"]))
                        res = filterContext.HttpContext.Request["ReturnUrl"];
                    else if (filterContext.HttpContext.Request.UrlReferrer != null && filterContext.HttpContext.Request.UrlReferrer != filterContext.HttpContext.Request.Url)
                    {
                        res = filterContext.HttpContext.Request.UrlReferrer.ToString();
                    }
                    filterContext.HttpContext.Session["ReturnUrl"] = res;
                    filterContext.Controller.ViewBag.ReturnUrl = res;
                }



                filterContext.Controller.ViewBag.SysMenuPPid = new BaseQX().GetSysMenuPPid(MenuId);  //导航菜单

                filterContext.Controller.ViewBag.UserPrivilege = new BaseQX().GetUserPrivilege(CurrentUserID.ToString(), MenuId.ToString());

                //增加单用户登录验证  
                string guid = cookie.Values["Guid"].ToString();
                System.Web.Caching.Cache objCache = HttpRuntime.Cache;
                if (objCache[CurrentUserID.ToString()] != null)
                {
                    string catchguid = objCache[CurrentUserID.ToString()].ToString();
                    if (guid != catchguid)
                    {
                        filterContext.HttpContext.Session["OtherLogin"] = true;
                        //filterContext.HttpContext.Response.Redirect("/Home/LogOn", true);
                        filterContext.HttpContext.Response.Write(" <script type='text/javascript'> window.top.location='/Home/Login';</script>");
                        return;
                    }
                    else
                    {
                        objCache.Insert(CurrentUserID.ToString(), guid, null, System.DateTime.Now.AddMinutes(10), TimeSpan.Zero);//修改缓存
                    }
                }
                else
                {
                    objCache.Insert(CurrentUserID.ToString(), guid, null, System.DateTime.Now.AddMinutes(10), TimeSpan.Zero);//修改缓存
                }


            }

        }

    }

}




