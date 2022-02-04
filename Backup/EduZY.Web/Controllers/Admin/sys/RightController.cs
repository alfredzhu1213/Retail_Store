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

namespace EduZY.Web.Controllers.Admin
{
    public class RightController : Controller
    {
        [SupportFilter]
        //
        // GET: /Right/ UserDataRight
        public ActionResult UserDataRight()
        {
            return View();
        }
        [SupportFilter]
        public ActionResult RoleDataRight()
        {
            return View();
        }
        [SupportFilter]
        public ActionResult Index()
        {
            return View();
        }
        #region 角色
        [SupportFilter]
        public ActionResult RoleList()
        {
            return View();
        }
        [SupportFilter]
        public ActionResult GetRoleList(int? page)
        {


            page = page == null ? 1 : page;
            string sql = "select m.*,d.ItemText StatusName from tb_Role m  left join tb_Doption d on d.MoptionID=2 and d.ItemValue=m.Status where 1=1 ";

            string KeyWord = DNTRequest.GetString("KeyWord");
            string Status = DNTRequest.GetString("Status");
            int rows = DNTRequest.GetInt("rows", 10);
            if (KeyWord != "")
            {
                sql += " and (m.RoleName like '%" + KeyWord + "%') ";
            }
            if (Status != "")
            {
                sql += " and (m.Status =" + Status + ")";
            }
            int count = 0;

            DataSet ds = DataPageHelper.GetDataPage(DataPageHelper.GetPageSql(sql, page.Value, rows, "RoleID desc"), out count);
            List<tb_Role> list = TBToList<tb_Role>.ConvertToList(ds.Tables[0]).ToList();
            var grid = new EasyuiDataGrid<List<tb_Role>>();
            grid.total = count;
            grid.rows = list;

            //JavaScriptSerializer js = new JavaScriptSerializer();
            return Json(grid, JsonRequestBehavior.AllowGet);
        }
        [SupportFilter]
        public ActionResult SaveRole(tb_Role model)
        {
            zhxy_resEntities ef = new zhxy_resEntities();
            JsonModel jm = new JsonModel();
            try
            {
                jm.status = 1;
                int RoleID = DNTRequest.GetInt("RoleID", 0);
                model.Status = DNTRequest.GetInt("Status", 1);
                model.UpdateDate = System.DateTime.Now;
                model.IsSys = 1;
                if (RoleID == 0)
                {
                    model.AddDate = System.DateTime.Now;
                    ef.tb_Role.AddObject(model);
                }
                else
                {
                    tb_Role item = ef.tb_Role.FirstOrDefault(p => p.RoleID == model.RoleID);
                    CommonHelper.NewObject<tb_Role>(model, item);
                }
                ef.SaveChanges();
            }
            catch (Exception ex)
            {
                jm.status = 0; jm.msg = ex.Message;
            }
            return Json(jm, JsonRequestBehavior.AllowGet);
        }
        [SupportFilter]
        public ActionResult DelRole(int id)
        {
            zhxy_resEntities ef = new zhxy_resEntities();
            JsonModel jm = new JsonModel();
            try
            {
                tb_Role item = ef.tb_Role.FirstOrDefault(p => p.RoleID == id);
                ef.tb_Role.DeleteObject(item);
                ef.SaveChanges();
                jm.status =1; jm.msg ="删除成功！";
            }
            catch (Exception ex)
            {
                jm.status = 0; jm.msg = ex.Message;
            }
            return Json(jm, JsonRequestBehavior.AllowGet);
        }
        #endregion
        [SupportFilter]
        public ActionResult MenuList()
        {
            return View();
        }
        [SupportFilter]
        public ActionResult GetMenuList(int MenuID = 0)
        {
            zhxy_resEntities ef = new zhxy_resEntities();
            int count = 0;
            string sql = "select m.*,m.MenuName nodeName,d.ItemText StatusName,dType.ItemText MenuTypeName from tb_MenuPage m  left join tb_Doption d on d.MoptionID=2 and d.ItemValue=m.Status  left join tb_Doption dType on dType.MoptionID=3 and dType.ItemValue=m.MenuType where 1=1 ";
            DataSet ds = DataPageHelper.GetDataPage(DataPageHelper.GetPageSql(sql, 1, 10000, "MenuID desc"), out count);
            List<tb_MenuPage> list = TBToList<tb_MenuPage>.ConvertToList(ds.Tables[0]).ToList();
            //List<tb_MenuPage> list = ef.tb_MenuPage.Where(p => p.MenuID > 0).ToList();
            List<tb_MenuPage> listJson = new List<tb_MenuPage>();
            foreach (tb_MenuPage model in list.Where(p => p.ParentId == 0).OrderBy(p => p.Sort))
            {
                MakeMenuJson(list, model, MenuID);
                listJson.Add(model);
            }


            return Json(listJson, JsonRequestBehavior.AllowGet);
        }
        [SupportFilter]
        public void MakeMenuJson(List<tb_MenuPage> list, tb_MenuPage model, int MenuID)
        {
            List<tb_MenuPage> listJson = new List<tb_MenuPage>();
            List<tb_MenuPage> Temp = list.Where(p => p.ParentId == model.MenuID).OrderBy(p => p.Sort).ToList();
            foreach (tb_MenuPage model2 in Temp)
            {
                if (model2.MenuID != MenuID)
                    listJson.Add(model2);
            }
            model.children = listJson;
            foreach (tb_MenuPage model2 in Temp)
            {
                if (model2.MenuID != MenuID)
                    MakeMenuJson(list, model2, MenuID);
            }


        }
        [SupportFilter]
        public ActionResult GetMenuComboTreeJson(int MenuID = 0)
        {
            string sql = "select MenuID,MenuName,MenuID id,MenuName text,Sort,ParentID  from tb_MenuPage union all select 0 MenuID,'根目录',0 id,'根目录' text,-100000 Sort,-1 ParentID  ";
            DataSet ds = DbHelperSQL.Query(sql);
            List<tb_MenuPage> list = TBToList<tb_MenuPage>.ConvertToList(ds.Tables[0]).ToList();

            List<tb_MenuPage> listJson = new List<tb_MenuPage>();
            foreach (tb_MenuPage model in list.Where(p => p.id == 0).OrderBy(p => p.Sort))
            {
                //if (model.MenuID != MenuID)
                //{
                MakeMenuJson(list, model, MenuID); listJson.Add(model);
                //}

            }
            return Json(listJson, JsonRequestBehavior.AllowGet);
        }



        [SupportFilter]

        public ActionResult GetMenuButtonJson(int MenuID)
        {
            JsonModel jm = new JsonModel();
            jm.status = 1;
            zhxy_resEntities ef = new zhxy_resEntities();
            DataSet ds = DbHelperSQL.Query(@"
select * from tb_Button
select m.*,b.ButtonName,b.ButtonIco,b.ButtonClass,b.ButtonFun from tb_MenuPage_Fun m join tb_Button b on m.ButtonID=b.ButtonID where m.MenuID=" + MenuID);
            List<tb_Button> list = TBToList<tb_Button>.ConvertToList(ds.Tables[0]).ToList();
            List<tb_MenuPage_Fun> listMenu = TBToList<tb_MenuPage_Fun>.ConvertToList(ds.Tables[1]).ToList();
            string strHtml = "";
            foreach (tb_Button model in list)
            {
                int num = listMenu.Count(p => p.ButtonID == model.ButtonID);
                strHtml += string.Format(@"<div class=""{4} panelcheck"">
                    <div id=""div_btn_{0}""
                        class=""checktext"">
                        <img src=""{1}"">{2}</div>
                    <div class=""{3}"" ButtonID=""{0}"">
                    </div>
                </div>", model.ButtonID, model.ButtonIco, model.ButtonName, num > 0 ? "triangleOk" : "triangleNo", num > 0 ? "checkbuttonOk" : "checkbuttonNo");

            }
            jm.html = strHtml;
            return Json(jm, JsonRequestBehavior.AllowGet);
        }

        [SupportFilter]
        public ActionResult SaveMenuButton(string buttonids, int MenuID)
        {
            zhxy_resEntities ef = new zhxy_resEntities();
            JsonModel jm = new JsonModel();
            jm.status = 1;
            buttonids = buttonids.Trim(',');
            var list = ef.tb_MenuPage_Fun.Where(p => p.MenuID == MenuID);
            foreach (tb_MenuPage_Fun model in list)
                ef.tb_MenuPage_Fun.DeleteObject(model);
            if (buttonids.Trim() != "")
            {

                foreach (string s in buttonids.Split(','))
                {
                    tb_MenuPage_Fun model = new tb_MenuPage_Fun();
                    model.MenuID = MenuID;
                    model.ButtonID = Convert.ToInt32(s);
                    ef.tb_MenuPage_Fun.AddObject(model);
                }

            }
            ef.SaveChanges();
            jm.msg = "授权成功";
            return Json(jm, JsonRequestBehavior.AllowGet);
        }


        [SupportFilter]
        public ActionResult SaveMenuPage(tb_MenuPage model)
        {
            zhxy_resEntities ef = new zhxy_resEntities();
            JsonModel jm = new JsonModel();
            try
            {
                jm.status = 1;
                int MenuID = DNTRequest.GetInt("MenuID", 0);
                model.Status = DNTRequest.GetInt("Status", 1);
                model.UpdateDate = System.DateTime.Now;
                model.RootID = 0;
                if (MenuID == 0)
                {
                    model.AddDate = System.DateTime.Now;
                    ef.tb_MenuPage.AddObject(model);
                }
                else
                {
                    tb_MenuPage item = ef.tb_MenuPage.FirstOrDefault(p => p.MenuID == model.MenuID);
                    CommonHelper.NewObject<tb_MenuPage>(model, item);
                }
                ef.SaveChanges();
            }
            catch (Exception ex)
            {
                jm.status = 0; jm.msg = ex.Message;
            }
            return Json(jm, JsonRequestBehavior.AllowGet);
        }
        [SupportFilter]
        public ActionResult DelMenuPage(int MenuID)
        {
            zhxy_resEntities ef = new zhxy_resEntities();
            JsonModel jm = new JsonModel();
            try
            {
                jm.status = 1;
                tb_MenuPage item = ef.tb_MenuPage.FirstOrDefault(p => p.MenuID == MenuID);
                ef.tb_MenuPage.DeleteObject(item);
                ef.SaveChanges();
            }
            catch (Exception ex)
            {
                jm.status = 0; jm.msg = ex.Message;
            }
            return Json(jm, JsonRequestBehavior.AllowGet);
        }
        [SupportFilter]
        public ActionResult UserMenuRight(tb_MenuPage model)
        {


            return View();
        }
        [SupportFilter]
        public ActionResult RoleMenuRight(tb_MenuPage model)
        {

            //model.c
            return View();
        }
        #region 用户菜单权限
        [SupportFilter]
        public ActionResult GetUserMenuList(int UserID = 0)
        {
            zhxy_resEntities ef = new zhxy_resEntities();
            int count = 0;
            string sql = @"select m.*,m.MenuName nodeName,d.ItemText StatusName,dType.ItemText MenuTypeName 
            ,isnull(um.UserMenuID,0) Checked
            from tb_MenuPage m  
            left join tb_Doption d on d.MoptionID=2 and d.ItemValue=m.Status 
            left join tb_Doption dType on dType.MoptionID=3 and dType.ItemValue=m.MenuType
            left join tb_UserMenu_Right um on um.UserID=" + UserID + @" and um.ButtonID=0 and um.MenuID=m.MenuID
            where 1=1 ";
            DataSet ds = DataPageHelper.GetDataPage(DataPageHelper.GetPageSql(sql, 1, 10000, "MenuID desc"), out count);
            List<tb_MenuPage> list = TBToList<tb_MenuPage>.ConvertToList(ds.Tables[0]).ToList();
            //List<tb_MenuPage> list = ef.tb_MenuPage.Where(p => p.MenuID > 0).ToList();
            List<tb_MenuPage> listJson = new List<tb_MenuPage>();
            foreach (tb_MenuPage model in list.Where(p => p.ParentId == 0).OrderBy(p => p.Sort))
            {
                MakeMenuJson(list, model, 0);
                listJson.Add(model);
            }


            return Json(listJson, JsonRequestBehavior.AllowGet);
        }
        [SupportFilter]
        public ActionResult GetUserMenuButtonJson(int MenuID, int UserID)
        {
            JsonModel jm = new JsonModel();
            jm.status = 1;
            zhxy_resEntities ef = new zhxy_resEntities();
            DataSet ds = DbHelperSQL.Query(@"
select * from  tb_MenuPage_Fun m 
        join tb_Button b on m.ButtonID=b.ButtonID 
        where m.MenuID=" + MenuID + @"
select m.*,b.ButtonName,b.ButtonIco,b.ButtonClass,b.ButtonFun from 
        tb_MenuPage_Fun m 
        join tb_Button b on m.ButtonID=b.ButtonID 
        join tb_UserMenu_Right um on um.UserID=" + UserID + @" and m.MenuID=um.MenuID and b.ButtonID=um.ButtonID
        where m.MenuID=" + MenuID);
            List<tb_Button> list = TBToList<tb_Button>.ConvertToList(ds.Tables[0]).ToList();
            List<tb_MenuPage_Fun> listMenu = TBToList<tb_MenuPage_Fun>.ConvertToList(ds.Tables[1]).ToList();
            string strHtml = "";
            foreach (tb_Button model in list)
            {
                int num = listMenu.Count(p => p.ButtonID == model.ButtonID);
                strHtml += string.Format(@"<div class=""{4} panelcheck"">
                    <div id=""div_btn_{0}""
                        class=""checktext"">
                        <img src=""{1}"">{2}</div>
                    <div class=""{3}"" ButtonID=""{0}"">
                    </div>
                </div>", model.ButtonID, model.ButtonIco, model.ButtonName, num > 0 ? "triangleOk" : "triangleNo", num > 0 ? "checkbuttonOk" : "checkbuttonNo");

            }
            jm.html = strHtml;
            return Json(jm, JsonRequestBehavior.AllowGet);
        }
        [SupportFilter]
        public ActionResult GetUserListTreeJson(int UserID = 0)
        {
            zhxy_resEntities ef = new zhxy_resEntities();
            int count = 0;
            string sql = "select UserID id,UserID,UserName text,'icon-user' iconCls,cast(1 as bit) Checkedes,UserID target from .[dbo].UserMaster m  where 1=1 ";
            DataSet ds = DataPageHelper.GetDataPage(DataPageHelper.GetPageSql(sql, 1, 10000, "UserID desc"), out count);
            List<tbUser> list = TBToList<tbUser>.ConvertToList(ds.Tables[0]).ToList();
            List<tbUser> listJson = new List<tbUser>();
            tbUser item = new tbUser(); item.id = 0; item.text = "所有用户"; item.iconCls = "icon-organ";
            item.children = list;
            listJson.Add(item);
            if (UserID == 0)
                item.children[0].Checkedes = true;
            else
                item.children.FirstOrDefault(p => p.id == UserID).Checkedes = true;

            JavaScriptSerializer js = new JavaScriptSerializer();
            string str = js.Serialize(listJson).Replace("Checkedes", "checked");
            return Content(str);// Json(listJson, JsonRequestBehavior.AllowGet);
        }
        [SupportFilter]
        public ActionResult SaveUserMenu(string menuids, int UserID)
        {
            zhxy_resEntities ef = new zhxy_resEntities();
            JsonModel jm = new JsonModel();
            jm.status = 1;
            menuids = menuids.Trim(',');
            var list = ef.tb_UserMenu_Right.Where(p => p.UserID == UserID && p.ButtonID == 0);
            foreach (tb_UserMenu_Right model in list)
                ef.tb_UserMenu_Right.DeleteObject(model);
            if (menuids.Trim() != "")
            {

                foreach (string s in menuids.Split(','))
                {
                    tb_UserMenu_Right model = new tb_UserMenu_Right();
                    model.UserID = UserID;
                    model.MenuID = Convert.ToInt32(s);
                    model.ButtonID = 0;
                    ef.tb_UserMenu_Right.AddObject(model);
                }
            }
            jm.msg = "授权成功";
            ef.SaveChanges();
            return Json(jm, JsonRequestBehavior.AllowGet);
        }
        [SupportFilter]
        public ActionResult SaveUserMenuButton(string buttonids, int MenuID, int UserID)
        {
            zhxy_resEntities ef = new zhxy_resEntities();
            JsonModel jm = new JsonModel();
            jm.status = 1;
            buttonids = buttonids.Trim(',');
            var list = ef.tb_UserMenu_Right.Where(p => p.MenuID == MenuID && p.UserID == UserID);
            foreach (tb_UserMenu_Right model in list)
                ef.tb_UserMenu_Right.DeleteObject(model);
            if (buttonids.Trim() != "")
            {
                foreach (string s in buttonids.Split(','))
                {
                    tb_UserMenu_Right model = new tb_UserMenu_Right();
                    model.MenuID = MenuID;
                    model.ButtonID = Convert.ToInt32(s);
                    model.UserID = UserID;
                    ef.tb_UserMenu_Right.AddObject(model);
                }
            }
            ef.SaveChanges();
            jm.msg = "授权成功";
            return Json(jm, JsonRequestBehavior.AllowGet);
        }
        #endregion
        #region 用户数据权限
        [SupportFilter]
        public ActionResult GetUserDataButtonJson(int ClassID, int UserID)
        {
            JsonModel jm = new JsonModel();
            jm.status = 1;
            zhxy_resEntities ef = new zhxy_resEntities();
            DataSet ds = DbHelperSQL.Query(@"
select * from  
         tb_Button b 
        where b.ButtonID in(1,3,4)
select b.* from 
         tb_Button b 
        join tb_UserData_Right um on um.UserID=" + UserID + @" and um.TypeID=1 and b.ButtonID=um.ButtonID
        where um.object_id=" + ClassID);
            List<tb_Button> list = TBToList<tb_Button>.ConvertToList(ds.Tables[0]).ToList();
            List<tb_Button> listMenu = TBToList<tb_Button>.ConvertToList(ds.Tables[1]).ToList();
            string strHtml = "";
            foreach (tb_Button model in list)
            {
                int num = listMenu.Count(p => p.ButtonID == model.ButtonID);
                strHtml += string.Format(@"<div class=""{4} panelcheck"">
                    <div id=""div_btn_{0}""
                        class=""checktext"">
                        <img src=""{1}"">{2}</div>
                    <div class=""{3}"" ButtonID=""{0}"">
                    </div>
                </div>", model.ButtonID, model.ButtonIco, model.ButtonName, num > 0 ? "triangleOk" : "triangleNo", num > 0 ? "checkbuttonOk" : "checkbuttonNo");

            }
            jm.html = strHtml;
            return Json(jm, JsonRequestBehavior.AllowGet);
        }
        [SupportFilter]
        public ActionResult SaveUserDataButton(string buttonids, int ClassID, int UserID)
        {
            zhxy_resEntities ef = new zhxy_resEntities();
            JsonModel jm = new JsonModel();
            jm.status = 1;
            buttonids = buttonids.Trim(',');
            var list = ef.tb_UserData_Right.Where(p => p.object_id == ClassID && p.TypeID == 1 && p.UserID == UserID);
            foreach (tb_UserData_Right model in list)
                ef.tb_UserData_Right.DeleteObject(model);

            ef.ExecuteStoreCommand("delete  from tb_UserData_Right where TypeID=1 and UserID=" + UserID + " and object_id in( select ClassID from dbo.fn_ResClass_next(" + ClassID + ") )");
            ef = new zhxy_resEntities();
        
            ef.SaveChanges();
            jm.msg = "授权成功";
            return Json(jm, JsonRequestBehavior.AllowGet);
        }
        #endregion
        #region 角色数据权限
        [SupportFilter]
        public ActionResult GetRoleDataButtonJson(int ClassID, int RoleID)
        {
            JsonModel jm = new JsonModel();
            jm.status = 1;
            zhxy_resEntities ef = new zhxy_resEntities();
            DataSet ds = DbHelperSQL.Query(@"
select * from  
         tb_Button b 
        where b.ButtonID in(1,3,4)
select b.* from 
         tb_Button b 
        join tb_RoleData_Right um on um.RoleID=" + RoleID + @" and um.TypeID=1 and b.ButtonID=um.ButtonID
        where um.object_id=" + ClassID);
            List<tb_Button> list = TBToList<tb_Button>.ConvertToList(ds.Tables[0]).ToList();
            List<tb_Button> listMenu = TBToList<tb_Button>.ConvertToList(ds.Tables[1]).ToList();
            string strHtml = "";
            foreach (tb_Button model in list)
            {
                int num = listMenu.Count(p => p.ButtonID == model.ButtonID);
                strHtml += string.Format(@"<div class=""{4} panelcheck"">
                    <div id=""div_btn_{0}""
                        class=""checktext"">
                        <img src=""{1}"">{2}</div>
                    <div class=""{3}"" ButtonID=""{0}"">
                    </div>
                </div>", model.ButtonID, model.ButtonIco, model.ButtonName, num > 0 ? "triangleOk" : "triangleNo", num > 0 ? "checkbuttonOk" : "checkbuttonNo");

            }
            jm.html = strHtml;
            return Json(jm, JsonRequestBehavior.AllowGet);
        }
        [SupportFilter]
        public ActionResult SaveRoleDataButton(string buttonids, int ClassID, int RoleID)
        {
            zhxy_resEntities ef = new zhxy_resEntities();
            JsonModel jm = new JsonModel();
            jm.status = 1;
            buttonids = buttonids.Trim(',');
            var list = ef.tb_RoleData_Right.Where(p => p.object_id == ClassID && p.TypeID == 1 && p.RoleID == RoleID);
            foreach (tb_RoleData_Right model in list)
                ef.tb_RoleData_Right.DeleteObject(model);

            ef.ExecuteStoreCommand("delete  from tb_RoleData_Right where TypeID=1 and RoleID=" + RoleID + " and object_id in( select ClassID from dbo.fn_ResClass_next(" + ClassID + ") )");
          
       
            ef.SaveChanges();
            jm.msg = "授权成功";
            return Json(jm, JsonRequestBehavior.AllowGet);
        }
        #endregion
        #region 角色菜单权限
        [SupportFilter]
        public ActionResult GetRoleListTreeJson(int RoleID = 0)
        {
            zhxy_resEntities ef = new zhxy_resEntities();
            int count = 0;
            string sql = "select RoleID id,RoleID,RoleName text,'icon-user' iconCls,cast(1 as bit) Checkedes,RoleID target from tb_Role m  where 1=1 ";
            DataSet ds = DataPageHelper.GetDataPage(DataPageHelper.GetPageSql(sql, 1, 10000, "RoleID desc"), out count);
            List<tbRole> list = TBToList<tbRole>.ConvertToList(ds.Tables[0]).ToList();
            List<tbRole> listJson = new List<tbRole>();
            tbRole item = new tbRole(); item.id = 0; item.text = "所有角色"; item.iconCls = "icon-organ";
            item.children = list;
            listJson.Add(item);
            if (RoleID == 0)
                item.children[0].Checkedes = true;
            else
                item.children.FirstOrDefault(p => p.id == RoleID).Checkedes = true;

            JavaScriptSerializer js = new JavaScriptSerializer();
            string str = js.Serialize(listJson).Replace("Checkedes", "checked");
            return Content(str);// Json(listJson, JsonRequestBehavior.AllowGet);
        }
        [SupportFilter]
        public ActionResult GetRoleMenuList(int RoleID = 0)
        {
            zhxy_resEntities ef = new zhxy_resEntities();
            int count = 0;
            string sql = @"select m.*,m.MenuName nodeName,d.ItemText StatusName,dType.ItemText MenuTypeName 
            ,isnull(um.RoleMenuID,0) Checked
            from tb_MenuPage m  
            left join tb_Doption d on d.MoptionID=2 and d.ItemValue=m.Status 
            left join tb_Doption dType on dType.MoptionID=3 and dType.ItemValue=m.MenuType
            left join tb_RoleMenu_Right um on um.RoleID=" + RoleID + @" and um.ButtonID=0 and um.MenuID=m.MenuID
            where m.Status=1 ";
            DataSet ds = DataPageHelper.GetDataPage(DataPageHelper.GetPageSql(sql, 1, 10000, "MenuID desc"), out count);
            List<tb_MenuPage> list = TBToList<tb_MenuPage>.ConvertToList(ds.Tables[0]).ToList();
            //List<tb_MenuPage> list = ef.tb_MenuPage.Where(p => p.MenuID > 0).ToList();
            List<tb_MenuPage> listJson = new List<tb_MenuPage>();
            foreach (tb_MenuPage model in list.Where(p => p.ParentId == 0).OrderBy(p => p.Sort))
            {
                MakeMenuJson(list, model, 0);
                listJson.Add(model);
            }


            return Json(listJson, JsonRequestBehavior.AllowGet);
        }
        [SupportFilter]
        public ActionResult GetRoleMenuButtonJson(int MenuID, int RoleID)
        {
            JsonModel jm = new JsonModel();
            jm.status = 1;
            zhxy_resEntities ef = new zhxy_resEntities();
            DataSet ds = DbHelperSQL.Query(@"
select * from  tb_MenuPage_Fun m 
        join tb_Button b on m.ButtonID=b.ButtonID 
        where m.MenuID=" + MenuID + @"
select m.*,b.ButtonName,b.ButtonIco,b.ButtonClass,b.ButtonFun from 
        tb_MenuPage_Fun m 
        join tb_Button b on m.ButtonID=b.ButtonID 
        join tb_RoleMenu_Right um on um.RoleID=" + RoleID + @" and m.MenuID=um.MenuID and b.ButtonID=um.ButtonID
        where m.MenuID=" + MenuID);
            List<tb_Button> list = TBToList<tb_Button>.ConvertToList(ds.Tables[0]).ToList();
            List<tb_MenuPage_Fun> listMenu = TBToList<tb_MenuPage_Fun>.ConvertToList(ds.Tables[1]).ToList();
            string strHtml = "";
            foreach (tb_Button model in list)
            {
                int num = listMenu.Count(p => p.ButtonID == model.ButtonID);
                strHtml += string.Format(@"<div class=""{4} panelcheck"">
                    <div id=""div_btn_{0}""
                        class=""checktext"">
                        <img src=""{1}"">{2}</div>
                    <div class=""{3}"" ButtonID=""{0}"">
                    </div>
                </div>", model.ButtonID, model.ButtonIco, model.ButtonName, num > 0 ? "triangleOk" : "triangleNo", num > 0 ? "checkbuttonOk" : "checkbuttonNo");

            }
            jm.html = strHtml;
            return Json(jm, JsonRequestBehavior.AllowGet);
        }
        [SupportFilter]
        public ActionResult SaveRoleMenu(string menuids, int RoleID)
        {
            zhxy_resEntities ef = new zhxy_resEntities();
            JsonModel jm = new JsonModel();
            jm.status = 1;
            menuids = menuids.Trim(',');
            var list = ef.tb_RoleMenu_Right.Where(p => p.RoleID == RoleID && p.ButtonID == 0);
            foreach (tb_RoleMenu_Right model in list)
                ef.tb_RoleMenu_Right.DeleteObject(model);
            if (menuids.Trim() != "")
            {

                foreach (string s in menuids.Split(','))
                {
                    tb_RoleMenu_Right model = new tb_RoleMenu_Right();
                    model.RoleID = RoleID;
                    model.MenuID = Convert.ToInt32(s);
                    model.ButtonID = 0;
                    ef.tb_RoleMenu_Right.AddObject(model);
                }
            }
            jm.msg = "授权成功";
            ef.SaveChanges();
            return Json(jm, JsonRequestBehavior.AllowGet);
        }
        [SupportFilter]
        public ActionResult SaveRoleMenuButton(string buttonids, int MenuID, int RoleID)
        {
            zhxy_resEntities ef = new zhxy_resEntities();
            JsonModel jm = new JsonModel();
            jm.status = 1;
            buttonids = buttonids.Trim(',');
            var list = ef.tb_RoleMenu_Right.Where(p => p.MenuID == MenuID && p.RoleID == RoleID);
            foreach (tb_RoleMenu_Right model in list)
                ef.tb_RoleMenu_Right.DeleteObject(model);
            if (buttonids.Trim() != "")
            {
                foreach (string s in buttonids.Split(','))
                {
                    tb_RoleMenu_Right model = new tb_RoleMenu_Right();
                    model.MenuID = MenuID;
                    model.ButtonID = Convert.ToInt32(s);
                    model.RoleID = RoleID;
                    ef.tb_RoleMenu_Right.AddObject(model);
                }
            }
            ef.SaveChanges();
            jm.msg = "授权成功";
            return Json(jm, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetRoleBasicRightJson(int RoleID)
        {
            zhxy_resEntities ef = new zhxy_resEntities();
            int count = 0;
            string sql = @"select *,(select Objectids from tb_RoleBasicRight rr where rr.RoleID=1 and rr.BasicRightID=m.BasicRightID) Objectids
,(select ObjectStr from tb_RoleBasicRight rr where rr.RoleID="+RoleID+@" and rr.BasicRightID=m.BasicRightID) ObjectStr
  from tb_BasicRight m";
            DataSet ds = DataPageHelper.GetDataPage(DataPageHelper.GetPageSql(sql, 1, 10000, "BasicRightID desc"), out count);
            List<tb_BasicRight> list = TBToList<tb_BasicRight>.ConvertToList(ds.Tables[0]).ToList();



            return Json(list, JsonRequestBehavior.AllowGet);
        }
          [SupportFilter]
        public ActionResult RoleBasicRightSet()
        {
            return View();
        }
          [SupportFilter]
          public ActionResult SaveRoleBasicRight(int RoleID, int BasicRightID,string ids)
          {
              JsonModel jm = new JsonModel();
              try
              {
                  ids = ids.Trim(',');
                  if (("," + ids + ",").Contains(",0,") == true)
                  {
                      string sql = @"delete from tb_RoleBasicRight where RoleID=" + RoleID + @" and BasicRightID=" + BasicRightID + @"
              insert into tb_RoleBasicRight(RoleID,BasicRightID,Objectids,ObjectStr,AddDate)
                select " + RoleID + @"," + BasicRightID + @",'0','所有分类',getdate() ";
                      DbHelperSQL.ExecuteSql(sql);
                  }
                  else
                  {
                      string sql = @"delete from tb_RoleBasicRight where RoleID=" + RoleID + @" and BasicRightID=" + BasicRightID + @"
              insert into tb_RoleBasicRight(RoleID,BasicRightID,Objectids,ObjectStr,AddDate)
                select " + RoleID + @"," + BasicRightID + @",'" + ids + @"',(  select stuff((select ','+cast(ClassName as varchar(50)) from tb_Res_Class b where b.ClassID in(select f1 from dbo.Split('" + ids + @"',',')) for xml path('')),1,1,'') ),getdate() ";
                      DbHelperSQL.ExecuteSql(sql);
                  }
                  jm.status = 1;
              }
              catch (Exception ex)
              {
                  jm.status = 0; jm.msg = ex.Message;
              }
              
              return Json(jm, JsonRequestBehavior.AllowGet);
          }
    

        #endregion

        #region 基本权限
        [SupportFilter]
        public ActionResult BasicRightList()
        {
            return View();
        }
        [SupportFilter]
        public ActionResult GetBasicRightList(int? page)
        {


            page = page == null ? 1 : page;
            string sql = "select m.*,d.ItemText StatusName from tb_BasicRight m  left join tb_Doption d on d.MoptionID=2 and d.ItemValue=m.Status where 1=1 ";

            string KeyWord = DNTRequest.GetString("KeyWord");
            string Status = DNTRequest.GetString("Status");
            int rows = DNTRequest.GetInt("rows", 10);
            if (KeyWord != "")
            {
                sql += " and (m.BasicRightName like '%" + KeyWord + "%') ";
            }
            if (Status != "")
            {
                sql += " and (m.Status =" + Status + ")";
            }
            int count = 0;

            DataSet ds = DataPageHelper.GetDataPage(DataPageHelper.GetPageSql(sql, page.Value, rows, "BasicRightID desc"), out count);
            List<tb_BasicRight> list = TBToList<tb_BasicRight>.ConvertToList(ds.Tables[0]).ToList();
            var grid = new EasyuiDataGrid<List<tb_BasicRight>>();
            grid.total = count;
            grid.rows = list;

            //JavaScriptSerializer js = new JavaScriptSerializer();
            return Json(grid, JsonRequestBehavior.AllowGet);
        }
        [SupportFilter]
        public ActionResult SaveBasicRight(tb_BasicRight model)
        {
            zhxy_resEntities ef = new zhxy_resEntities();
            JsonModel jm = new JsonModel();
            try
            {
                tb_BasicRight item = new tb_BasicRight();
                jm.status = 1;
                int BasicRightID = DNTRequest.GetInt("BasicRightID", 0);
                if (BasicRightID > 0)
                    item = ef.tb_BasicRight.FirstOrDefault(p => p.BasicRightID == model.BasicRightID);

                CommonHelper.NewObject<tb_BasicRight>(model, item);
                item.Status = DNTRequest.GetInt("Status", 1);
                item.UpdateDate = System.DateTime.Now;
                if (BasicRightID == 0)
                {
                    item.AddDate = System.DateTime.Now;
                    ef.tb_BasicRight.AddObject(item);
                }
               
                ef.SaveChanges();
            }
            catch (Exception ex)
            {
                jm.status = 0; jm.msg = ex.Message;
            }
            return Json(jm, JsonRequestBehavior.AllowGet);
        }
        [SupportFilter]
        public ActionResult DelBasicRight(int BasicRightID)
        {
            zhxy_resEntities ef = new zhxy_resEntities();
            JsonModel jm = new JsonModel();
            try
            {
                tb_BasicRight item = ef.tb_BasicRight.FirstOrDefault(p => p.BasicRightID == BasicRightID);
                ef.tb_BasicRight.DeleteObject(item);
                ef.SaveChanges();
            }
            catch (Exception ex)
            {
                jm.status = 0; jm.msg = ex.Message;
            }
            return Json(jm, JsonRequestBehavior.AllowGet);
        }
        #endregion
    }
}
