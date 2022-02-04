using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Common;
using EduZY.Web.Models;
using System.Data;

using System.Web.Script.Serialization;
using Entity;
using Maticsoft.DBUtility;
using System.IO;


using EduJXC.BLL.Admin;
using System.Web.Security;
using System.Text;
using EduZY.Model;
using EduJXC.Model;


namespace EduZY.Web.Controllers.Admin
{
    [SupportFilter]
    public class BasicController : Base.BaseController
    {
        //
        // GET: /Basic/
        [SupportFilter]
        public ActionResult Index()
        {
            return View();
        }



        public ActionResult UpdatePwd()
        {
            UserMaster model = new UserMaster();
            model.UserName = CurrentUserName;
            return View(model);
        }
        public ActionResult pwdSave(UserMaster models)
        {
            UserMasterBLL bll = new UserMasterBLL();
            UserMaster model = new UserMaster();
            JsonModel json = new JsonModel();
            string OldPassword = models.OldPassword;
            string Password1 = models.Password1;
            string Password2 = models.Password2;
            try
            {

                Convert.ToInt32(Password1);
                if (Password1.Length != 6)
                {
                    json.status = -11;
                    return Json(json);
                }
            }
            catch
            {
                json.status = -10;
                return Json(json);

            }
            OldPassword = FormsAuthentication.HashPasswordForStoringInConfigFile(OldPassword, "MD5");
            Password1 = FormsAuthentication.HashPasswordForStoringInConfigFile(Password1, "MD5");
            Password2 = FormsAuthentication.HashPasswordForStoringInConfigFile(Password2, "MD5");

            if (!bll.ExistsUser(CurrentUserID, OldPassword))
            {
                json.status = 2;
            }
            else if (Password1.Trim() != Password2.Trim())
            {
                json.status = 3;
            }
            else
            {
                model.Password = Password1;
                model.UserID = CurrentUserID;
                json.status = bll.UpdatePWD(model);
            }

            System.Web.Script.Serialization.JavaScriptSerializer js = new System.Web.Script.Serialization.JavaScriptSerializer();
            Response.Write(js.Serialize(json));
            Response.End();
            return View();
        }
        /// <summary>
        /// 用户添加
        /// </summary>
        /// <returns></returns>
        [SupportFilter]
        public ActionResult UserlistAdd()
        {
            List<SelectListItem> items = new List<SelectListItem>();
            List<SelectListItem> items1 = new List<SelectListItem>();

            DataSet ds = GetList();
            DataRow[] arr_row = ds.Tables[0].Select();
            for (int i = 0; i < arr_row.Length; i++)
            {
                SelectListItem item = new SelectListItem();
                item.Value = arr_row[i]["RoleID"].ToString();
                item.Text = arr_row[i]["RoleName"].ToString();
                items.Add(item);
            }
            ViewData["itemsrole"] = items;

            DataSet ds1 = GetList1();
            DataRow[] arr_row1 = ds1.Tables[0].Select();
            for (int i = 0; i < arr_row1.Length; i++)
            {
                SelectListItem item1 = new SelectListItem();
                item1.Value = arr_row1[i]["id"].ToString();
                item1.Text = arr_row1[i]["name"].ToString();
                items1.Add(item1);
            }
            ViewData["StoreList"] = items1;


            return View();
        }
        public DataSet GetList1()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,Name ");
            strSql.Append(" FROM [" + DBName + @"].[dbo].tb_Store ");
            return DbHelperSQL.Query(strSql.ToString());
        }
        public DataSet GetList()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select RoleID,RoleName ");
            strSql.Append(" FROM tb_Role ");
            return DbHelperSQL.Query(strSql.ToString());
        }


        /// <summary>
        /// 用户编辑
        /// </summary>
        /// <returns></returns>
        [SupportFilter]
        public ActionResult UserlistEdit()
        {
            string id = DNTRequest.GetString("id");
            List<SelectListItem> items1 = new List<SelectListItem>();
            List<SelectListItem> items = new List<SelectListItem>();
            UserMaster model = new UserMaster();
            UserMasterBLL bll = new UserMasterBLL();
            model = bll.GetModel(Convert.ToInt32(id));
            DataSet ds = GetList();
            DataRow[] arr_row = ds.Tables[0].Select();
            for (int i = 0; i < arr_row.Length; i++)
            {
                SelectListItem item = new SelectListItem();
                item.Value = arr_row[i]["RoleID"].ToString();
                item.Text = arr_row[i]["RoleName"].ToString();
                items.Add(item);
            }
            ViewData["itemsrole"] = items;

            DataSet ds1 = GetList1();
            DataRow[] arr_row1 = ds1.Tables[0].Select();
            for (int i = 0; i < arr_row1.Length; i++)
            {
                SelectListItem item1 = new SelectListItem();
                item1.Value = arr_row1[i]["id"].ToString();
                item1.Text = arr_row1[i]["name"].ToString();
                items1.Add(item1);
            }
            ViewData["StoreList"] = items1;

           DataSet dss=DbHelperSQL.Query("select * FROM tb_UserManageStore where userid='"+model.UserID+"'");
           if (dss!=null)
           {
               string ids = "";
               string names = "";
               foreach (DataRow dr in dss.Tables[0].Rows)
               {
                   ids += dr["StoreId"]+",";
                   names += dr["StoreName"] + ",";
                  
               }
               model.StoreIdList = ids.TrimEnd(',');
               model.StoreNameList = names.TrimEnd(',');
           }
            return View(model);
        }

        /// <summary>
        /// 用户添加
        /// </summary>
        /// <returns></returns>
        public ActionResult UserlistSave()
        {
            JsonModel json = new JsonModel();
             EduJXC.Model.UserMaster model = new EduJXC.Model.UserMaster();
             string UserName = DNTRequest.GetString("UserName");
             string Password = DNTRequest.GetString("Password");
             string Password1 = DNTRequest.GetString("Password1");

             string TrueName = DNTRequest.GetString("TrueName");
             string Mobile = DNTRequest.GetString("Mobile");
             string Phone = DNTRequest.GetString("Phone");
             string QQ = DNTRequest.GetString("QQ");
             string EMail = DNTRequest.GetString("EMail");
             string RoleID = DNTRequest.GetString("RoleID");
             string Status = DNTRequest.GetString("Status");
             int BuMenID = -1;
             try
             {
                 BuMenID = DNTRequest.GetIntString("BuMenId");
             }
             catch
             {

             }
            string StoreIdList = DNTRequest.GetString("StoreIdList");
            string StoreNameList = DNTRequest.GetString("StoreNameList");

           
             //string StoreId = DNTRequest.GetString("StoreId");
             //string StoreName = DbHelperSQL.GetSingle("select Name  FROM [" + DBName + @"].[dbo].tb_Store where Id='" + StoreId + "'") + "";

             string ZhiCheng = DNTRequest.GetString("ZhiCheng");
             model.UserName = UserName.Trim();
             model.RoleID = RoleID.Trim();
             model.TrueName = TrueName.Trim();
             model.Mobile = Mobile.Trim();
             model.Phone = Phone.Trim();
             model.QQ = QQ.Trim();
             model.EMail = EMail.Trim();
             model.Status = Status;
             model.BuMenId = BuMenID;
             model.ZhiCheng = ZhiCheng;
             try
             {
                 model.StoreId = Convert.ToInt32(0);
                 model.StoreName = StoreNameList;

             }
             catch
             {
                 model.StoreId = 0;
                 model.StoreName = "";

             }
             if (DNTRequest.GetString("Sex").ToLower() == "false")
             {
                 model.Sex = false;
             }
             else
             {
                 model.Sex = true;
             }
         
             UserMasterBLL bll = new UserMasterBLL();
             string id = DNTRequest.GetString("id");

             if (!string.IsNullOrWhiteSpace(id))
             {
                 model.UserID = Convert.ToInt32(id);
                 if (string.IsNullOrWhiteSpace(Password.Trim()))
                 {
                     model.Password = bll.GetModel(model.UserID).Password;
                     bll.Update(model);
                     DbHelperSQL.GetSingle("delete tb_UserManageStore where Userid='" + model.UserID + "'");
                     StringBuilder sql = new StringBuilder();
                     if (StoreIdList != "")
                     {
                         int i = 0;
                         foreach (string storeId in StoreIdList.Split(','))
                         {
                             sql.Append(" INSERT INTO [dbo].[tb_UserManageStore] ([Userid],[StoreId],[StoreName]) VALUES('" + model.UserID + "','" + storeId + "','" + StoreNameList.Split(',')[i] + "');");
                             i++;
                         }
                         DbHelperSQL.GetSingle(sql.ToString());
                     }
                     json.status = 1;
                 }
                 else
                 {
                     Password = FormsAuthentication.HashPasswordForStoringInConfigFile(Password, "MD5");
                     Password1 = FormsAuthentication.HashPasswordForStoringInConfigFile(Password1, "MD5");

                     if (Password.Trim() != Password1.Trim())
                     {
                         json.status = 3;
                     }
                     else
                     {
                         model.Password = Password;
                         bll.Update(model);
                         DbHelperSQL.GetSingle("delete tb_UserManageStore where Userid='" + model.UserID + "'");
                         StringBuilder sql = new StringBuilder();
                         if (StoreIdList != "")
                         {
                             int i = 0;
                             foreach (string storeId in StoreIdList.Split(','))
                             {
                                 sql.Append(" INSERT INTO [dbo].[tb_UserManageStore] ([Userid],[StoreId],[StoreName]) VALUES('" + model.UserID + "','" + storeId + "','" + StoreNameList.Split(',')[i] + "');");
                                 i++;
                             }
                             DbHelperSQL.GetSingle(sql.ToString());
                         }

                         json.status = 1;
                     }
                 }
             }
             else
             {
                 try
                 {
                     Convert.ToInt32(Password);
                     if (Password1.Length != 6)
                     {
                         json.status = -11;
                         return Json(json);
                     }
                 }
                 catch
                 {
                     json.status = -10;
                     return Json(json);

                 }

                 try
                 {
                     Convert.ToInt32(UserName);
                 }
                 catch
                 {
                     json.status = -12;
                     return Json(json);

                 }

                 Password = FormsAuthentication.HashPasswordForStoringInConfigFile(Password, "MD5");
                 Password1 = FormsAuthentication.HashPasswordForStoringInConfigFile(Password1, "MD5");
                 if (Password.Trim() != Password1.Trim())
                 {
                     json.status = 3;
                 }
                 else
                 {
                     model.Password = Password;
                     int userid = bll.Add(model);
                     StringBuilder sql = new StringBuilder();
                     if (StoreIdList != "")
                     {
                         int i = 0;
                         foreach (string storeId in StoreIdList.Split(','))
                         {
                             sql.Append(" INSERT INTO [dbo].[tb_UserManageStore] ([Userid],[StoreId],[StoreName]) VALUES('" + userid + "','" + storeId + "','" + StoreNameList.Split(',')[i] + "');");
                             i++;
                         }
                         DbHelperSQL.GetSingle(sql.ToString());
                     }
                     json.status =1;
                 }
             }
             System.Web.Script.Serialization.JavaScriptSerializer js = new System.Web.Script.Serialization.JavaScriptSerializer();
             Response.Write(js.Serialize(json));
             Response.End();

             return View();
         }

        /// <summary>
        /// 资源配置    
        /// </summary>
        /// <param name="pageindex"></param>
        /// <returns></returns>
        [SupportFilter]
        public ActionResult ConfigSet(int? page)
        {
            ViewBag.StatusItem = CommonHelper.GetDropItemsString(CacheCommon.DicOtion(2), "ItemValue", "ItemText", "");

            return View();
        }

        [SupportFilter]
        public ActionResult OptionList()
        {
            return View();
        }
        [SupportFilter]
        public ActionResult Center()
        {
            return View();
        }


        /// <summary>
        /// 用户管理    
        /// </summary>
        /// <param name="pageindex"></param>
        /// <returns></returns>
        [SupportFilter]
        public ActionResult UserList(int? page)
        {

            ViewBag.RoleItem = CommonHelper.GetCheckListItemsString("RoleID", CacheCommon.RoleList(), "RoleID", "RoleName", "");
            return View();
        }
        [SupportFilter]
        public ActionResult GetUserList(int? page)
        {
            UserMasterBLL bll = new UserMasterBLL();
            string strWhere = " 1=1 ";

            string KeyWord = DNTRequest.GetString("KeyWord");
            string RoleID = DNTRequest.GetString("RoleID");
            int rows = DNTRequest.GetInt("rows", 10);

            if (KeyWord != "")
            {
                strWhere += " and (UserName like '%" + KeyWord + "%') or ( UserID in (select UserID from .[dbo].UserDetail where trueName  like '%" + KeyWord + "%')) ";
            }
            if (RoleID != "")
            {
                strWhere += " and UserID in (select UserID from .[dbo].UserRole where RoleID=" + RoleID.ToString() + ")";
            }
            int count = 0;
            string sql = @"select * ,(select top 1 TrueName from [dbo].UserDetail where UserID=m.UserID) as TrueName, 
             (select RoleName from tb_Role where RoleID in(select top 1  RoleID from tb_UserRole where UserID=m.UserID)) as RoleName  
             
             from .[dbo].UserMaster m  where  " + strWhere;
            DataSet ds = DataPageHelper.GetDataPage(DataPageHelper.GetPageSql(sql, page.Value, rows, "UserID desc"), out count);
            List<UserMaster> list = TBToList<UserMaster>.ConvertToList(ds.Tables[0]).ToList();
            var grid = new EasyuiDataGrid<List<UserMaster>>();
            grid.total = count;
            grid.rows = list;
            return Json(grid, JsonRequestBehavior.AllowGet);
        }
        [SupportFilter]
        public ActionResult GetUserRoleList(int? UserID)
        {
            zhxy_resEntities ef = new zhxy_resEntities();
            List<tb_UserRole> list = ef.tb_UserRole.Where(p => p.UserID == UserID).ToList();
            return Json(list, JsonRequestBehavior.AllowGet);
        }
        [SupportFilter]
        public ActionResult SaveUserRole()
        {
            zhxy_resEntities ef = new zhxy_resEntities();
            string sids = Request["RoleID"] + "";
            JsonModel jm = new JsonModel(); jm.status = 1;
            int UserID = DNTRequest.GetInt("UserID", 0);
            List<tb_UserRole> list = ef.tb_UserRole.Where(p => p.UserID == UserID).ToList();
            foreach (tb_UserRole item in list)
                ef.tb_UserRole.DeleteObject(item);
            if (sids != "")
            {

                foreach (string s in sids.Split(','))
                {
                    tb_UserRole model = new tb_UserRole();
                    model.UserID = DNTRequest.GetInt("UserID", 0);
                    model.RoleID = Convert.ToInt32(s);
                    ef.tb_UserRole.AddObject(model);
                }
                ef.SaveChanges();
            }
            return Json(jm, JsonRequestBehavior.AllowGet);

        }
        #region 日志管理
        [SupportFilter]
        public ActionResult LogList()
        {
            return View();
        }
        [SupportFilter]
        public ActionResult GetOptLog(int? page)
        {
            zhxy_resEntities ef = new zhxy_resEntities();

            page = page == null ? 1 : page;
            string sql = @" select l.*,m.UserName from tb_Log l
left join dbo.UserMaster m on m.UserID=l.UserID where 1=1 ";

            string KeyWord = DNTRequest.GetString("KeyWord");
            string RoleID = DNTRequest.GetString("RoleID");
            int rows = DNTRequest.GetInt("rows", 10);
            if (KeyWord != "")
            {
                sql += " and ( l.RequestUrl like '%" + KeyWord + "%' or l.SourceUrl like '%" + KeyWord + "%' or m.UserName like '%" + KeyWord + "%') ";
            }
            int count = 0;

            DataSet ds = DataPageHelper.GetDataPage(DataPageHelper.GetPageSql(sql, page.Value, rows, "LogID desc"), out count);
            List<tb_Log> list = TBToList<tb_Log>.ConvertToList(ds.Tables[0]).ToList();
            var grid = new EasyuiDataGrid<List<tb_Log>>();
            grid.total = count;
            grid.rows = list;

            JavaScriptSerializer js = new JavaScriptSerializer();
            return Json(grid, JsonRequestBehavior.AllowGet);
        }
        [SupportFilter]
        public ActionResult LogDel(int LogID)
        {
            JsonModel jm = new JsonModel();
            jm.status = 1;
            try
            {
                zhxy_resEntities ef = new zhxy_resEntities();
                tb_Log model = ef.tb_Log.FirstOrDefault(p => p.LogID == LogID);
                ef.tb_Log.DeleteObject(model);
                ef.SaveChanges();
            }
            catch (Exception ex)
            {
                jm.status = 0;
                jm.msg = ex.Message;
            }
            return Json(jm);
        }
        #endregion
    }
}
