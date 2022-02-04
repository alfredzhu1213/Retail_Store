using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Common;

using Entity;
using EduZY.Model;
using System.Web.Script.Serialization;

using System.Reflection;
using EduJXC.Model.Common;
using EduJXC.Model;
using Base;

namespace EduZY.Web.Controllers
{
    public class AdminController : BaseController
    {
        //
        // GET: /Admin/
         [SupportFilter]
        public ActionResult Index()
        {
            ViewBag.StoreName = StoreNames;
            string strHtml = @"";
            List<tb_MenuPage> list = CommonHelper.UserMenuList(AdminPage.UserID());
            foreach (tb_MenuPage model in list.Where(p => p.ParentId == 0).OrderBy(p => p.Sort))
            {
                strHtml += @"<div title='<span>"+model.MenuName+"</span>'><ul>";
                foreach (tb_MenuPage model2 in list.Where(p => p.ParentId == model.MenuID).OrderBy(p => p.Sort))
                {
                    strHtml +=string.Format(@"<li><a href='#' url='{0}' title='{1}'  pkid='21'  tabid='{2}'>
                            <img alt='{1}' src='/Content/images/oa/module/smallicon/icon/menu_xtgl.png' t_src='/Content/images/oa/module/smallicon/white/menu_xtgl.png'
                                width='16' height='16' />
                            {1} <span class='caret'></span></a></li>", model2.MenuUrl, model2.MenuName, model2.MenuID);

                }
                strHtml += @"</ul>
                </div>";
            }
            ViewBag.strHtml = strHtml;
            return View();
        }

         public ActionResult DelUser(int id)
         {
             zhxy_resEntities ef = new zhxy_resEntities();
             JsonModel jm = new JsonModel();
             try
             {
                 string sql = "delete  tb_UserRole  where [UserID]='" + id + "';";
                 sql += "delete  [dbo].tb_UserData_Right  where [UserID]='" + id + "';";
                 sql += "delete  [dbo].tb_UserMenu_Right  where [UserID]='" + id + "';";
                 sql += "delete  .[dbo].UserMaster  where [UserID]='" + id + "' ;";
                 Maticsoft.DBUtility.DbHelperSQL.ExecuteSql(sql);

                 jm.status = 1; jm.msg = "删除成功！";
             }
             catch (Exception ex)
             {
                 jm.status = 0; jm.msg = ex.Message;
             }
             return Json(jm, JsonRequestBehavior.AllowGet);
         }

    }
    public class EasyuiDataGrid<t>
    {
        public int total { get; set; }
        public t rows { get; set; }
    }
    public class ViewDataBase
    {

        /// <summary>
        /// 传值参数
        /// </summary>
        public string UrlParameter
        {
            get;
            set;
        }


        /// <summary>
        /// 传值参数
        /// </summary>
        public string PageName
        {
            get;
            set;
        }
        /// <summary>
        /// 当前页
        /// </summary>
        public int CurrentPage
        {
            get;
            set;
        }
        /// <summary>
        /// 页大小
        /// </summary>
        public int PageSize
        {
            get;
            set;
        }
        /// <summary>
        /// 记录总数大小
        /// </summary>
        public int RowCount
        {
            get;
            set;
        }

        /// <summary>
        /// 是否有上一页
        /// </summary>
        public bool HasPreviousPage
        {
            get
            {
                return (CurrentPage - 1) > 0;
            }
        }
        /// <summary>
        /// 是否有下一页
        /// </summary>
        public bool HasNextPage
        {
            get
            {
                return (TotalPages - CurrentPage) > 0;
            }
        }
        /// <summary>
        /// 上一页
        /// </summary>
        public int PreviousPage
        {
            get
            {
                return (CurrentPage <= 1) ? 1 : CurrentPage - 1;
            }
        }
        /// <summary>
        /// 下一页
        /// </summary>
        public int NextPage
        {
            get
            {
                return CurrentPage + 1;
            }
        }
        /// <summary>
        /// 总页数
        /// </summary>
        public int TotalPages
        {
            get
            {
                if (PageSize == 0)
                    throw new ArgumentOutOfRangeException("page");
                int remainder = RowCount % PageSize;
                if (remainder == 0)
                    return RowCount / PageSize;
                else
                    return (RowCount / PageSize) + 1;
            }

        }
    }
    public class ModelViewData : ViewDataBase
    {


        public IEnumerable<EduJXC.Model.UserMaster> UserMaster
        {
            get;
            set;
        }
        public IEnumerable<Maticsoft.Model.tb_Product> tb_Product
        {
            get;
            set;
        }
        public IEnumerable<BasicClass> BasicClass
        {
            get;
            set;
        }





    }
}
