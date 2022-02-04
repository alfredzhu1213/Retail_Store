using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Common;
using EduZY.Web.Models;
using System.Data;
using EduZY.Model;
using System.Web.Script.Serialization;
using Entity;
using Maticsoft.DBUtility;

using System.IO;
using EduJXC.Model;
using Base;


namespace EduZY.Web.Controllers
{
    public class HomeController : BaseController
    {
        //
        // GET: /Index/

        public ActionResult Index()
        {
            ViewBag.nav_index = 0;
            ViewBag.StoreName = StoreName.Replace("/'","");
            return View();
        }
        public ActionResult DrawImage()
        {
            Common.CreateImage.DrawImage();
            return View();
        }
        public ActionResult ResList(int cid=0)
        {
            ViewBag.ClassName = "";
            if (cid != 0)
            {
                string obj = DbHelperSQL.GetSingle("select top 1 ClassID from dbo.fn_ResClass_pre("+cid+") order by Level desc")+"";
                ViewBag.nav_index = obj;

                ViewBag.ClassName = DbHelperSQL.GetSingle("select top 1 ClassName from tb_Res_Class where ClassID=" + cid + "") + "";
            }
            return View();
        }
   
        public ActionResult Login()
        {
            if (Session["OtherLogin"] != null && Convert.ToBoolean(Session["OtherLogin"]) == true)
            {

                HttpContext.Response.Write(" <script type='text/javascript'> window.top.location = '/Home/Login'; alert('您的账号已在其它地方登录，被迫退出。'); </script>");
                Session["OtherLogin"] = null;
            }
            else
            {
                ViewBag.Msg = "";
            }

            return View();
        }
        public ActionResult Logout()
        {
            AdminPage.Logout();
            //HttpContext.Response.Write(" <script type='text/javascript'> window.top.location='/'; </script>");

            return Redirect("/Home/Login");
        }
        public ActionResult LoginVail(string UserName, string Password)
        {
            JsonModel jm = new JsonModel();
            UserMaster user = new UserMaster();
            string msg = "";
            if (Session["CheckCode"] != null && Session["CheckCode"].ToString().ToLower() != DNTRequest.GetString("VailCode").Trim().ToLower())
            {
                jm.status = 0;
                jm.msg = "验证码错误";
            }
            else
            {
                if (AdminPage.UserLogin(UserName, Password, out msg, out user) == true)
                {
                    jm.status = 1;
                    AdminPage.WriteUserCookie(user);

                }
                else
                {
                    jm.status = 0;
                    jm.msg = msg;
                }
            }
           
            return Json(jm, JsonRequestBehavior.AllowGet);
        }

     
        int count = 0, pagesize = 0, pageindex = 1;
        string webUrl = "";
        public string Pager()
        {
            PagerNumber pager = new PagerNumber("","");
            return pager.FunPager_New(count, pagesize, pageindex, new PagerNumber.ProcessDelegate(this.PageA), null);
        }
        private string PageA(int iCurrentPage)
        {
            string sTemp = "";
            sTemp = "href='#a_listtop' onclick=\"javacript:ajaxGet('/home/GetResListJson?page=" + iCurrentPage + this.webUrl + "');\"";
            return sTemp;
        }

    }
}
