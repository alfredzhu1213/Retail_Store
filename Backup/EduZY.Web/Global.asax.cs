using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using EduZY.Web.Models;
using Common;

using System.Text;
using EduZY.Web;
using EduZY.Model;

namespace NewEduZY.Web
{
    // 注意: 有关启用 IIS6 或 IIS7 经典模式的说明，
    // 请访问 http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        { 
            //路由规则匹配是从上到下的，优先匹配的路由一定要写在最上面。因为路由匹配成功以后，他不会继续匹配下去。

            routes.MapRoute(
                "Admin", // 路由名称，这个只要保证在路由集合中唯一即可
                "Admin/{controller}/{action}/{id}", //路由规则,匹配以Admin开头的url
                new { controller = "Admin", action = "Index", id = UrlParameter.Optional } // 
            );
            routes.MapRoute(
                "Default", // 路由名称
                "{controller}/{action}/{id}", // 带有参数的 URL
                new { controller = "Home", action = "Login", id = UrlParameter.Optional } // 参数默认值
            );
           
        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RegisterView();//注册视图访问规则
            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);

          
        }
        protected void RegisterView()
        {
            //ViewEngines.Engines.Clear();
            ViewEngines.Engines.Add(new MyViewEngine());
        }
        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            string Extension = Context.Request.CurrentExecutionFilePathExtension.ToLower();
            if (Extension == ".css" || Extension == ".js" || Extension == ".png" || Extension == ".jpg" || Extension == ".ico" || Extension == ".gif" || Extension == ".swf" || Extension == ".jpeg")
                return;
            try
            {
                zhxy_resEntities ef = new zhxy_resEntities();
                tb_Log model = new tb_Log();
                model.Browser = Context.Request.Browser.Type;
                model.CreateDate = System.DateTime.Now;
                model.IP = DNTRequest.GetIP();
                model.UserID = AdminPage.UserID();
                model.LogTypeID = 1;
                model.LogTypeName = "浏览";
                string PostData = "";
                foreach (string i in this.Request.Form)
                {
                    PostData += "" + i + "=" + HttpUtility.UrlDecode(this.Request.Form[i]) + "&";
                }
                model.PostData = PostData.Trim('&');
                model.RequestUrl = Context.Request.RawUrl;
                model.SourceUrl = DNTRequest.GetUrlReferrer();
                ef.tb_Log.AddObject(model);
                ef.SaveChanges();
            }
            catch
            {
                Server.ClearError();
            }
        }

        void Application_Error(object sender, EventArgs e)
        {
            // 在出现未处理的错误时运行的代码
            //在出现未处理的错误时运行的代码
            Exception LastError = Server.GetLastError();
            String ErrMessage = LastError.ToString();
            string Message = "\r\n\tUrl " + Request.Url.ToString() + "\r\n\t Error: " + ErrMessage + "\r\n\t" + " Time:" + System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "\r\n\tUserLogin:" + AdminPage.LoginName() + "\r\n\t";
            try
            {
                string photoDestination = System.Web.HttpContext.Current.Request.PhysicalApplicationPath;
                FileAccessHelper.WriteTextFile(photoDestination + "Upfile\\Log\\Application_Error.txt", Message, true, true, Encoding.UTF8);
            }
            catch
            {
            }
        }
    }
}