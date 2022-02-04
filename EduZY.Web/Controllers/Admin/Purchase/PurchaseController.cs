using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Common;
using Maticsoft.Model;
using Entity;
using Maticsoft.DAL;
using System.Text;
using Maticsoft.DBUtility;
using System.Data;
using System.Web.Script.Serialization;

namespace EduZY.Web.Controllers.Admin.Purchase
{
    [SupportFilter]
    public class PurchaseController : Base.BaseController
    {

        #region tb_PurchaseBasicSet
        public ActionResult PurSetting()
        {
            Maticsoft.Model.tb_PurchaseBasicSet model = new tb_PurchaseBasicSet();
            tb_PurchaseBasicSetDAL bll = new tb_PurchaseBasicSetDAL(DBName);
            model = bll.GetModel(1);
            return View(model);
        }

        public ActionResult savetb_PurchaseBasicSet(tb_PurchaseBasicSet model)
        {

            JsonModel jm = new JsonModel();
            try
            {
                Maticsoft.DAL.tb_PurchaseBasicSetDAL bll = new Maticsoft.DAL.tb_PurchaseBasicSetDAL(DBName);
                jm.status = 1;
                int id = DNTRequest.GetInt("id", 0);

                if (id == 0)
                {

                    bll.Add(model);
                    jm.status = 1;
                }
                else
                {
                    bll.Update(model);
                    jm.status = 1;
                }


            }
            catch (Exception ex)
            {
                jm.status = 0; jm.msg = ex.Message;
            }
            return Json(jm, JsonRequestBehavior.AllowGet);

        }

        #endregion

        #region tb_PurchaseSupplier
        public ActionResult Vendor()
        {
            return View();
        }
        [HttpPost]
        public JsonResult GetCommonCode(int id)
        {
            string result = "";
            JsonModel jm = new JsonModel();
            object obj = DbHelperSQL.GetSingle("select count(code) from [" + DBName + @"].[dbo].[tb_PurchaseSupplier] ");
            if (obj != null)
            {
                if (Convert.ToInt32(obj) > 0)
                {
                    string next = (Convert.ToInt32(obj) + 1).ToString();
                    if (next.Length == 1)
                    {
                        result = "00" + next;
                    }
                    if (next.Length == 2)
                    {
                        result = "0" + next;
                    }
                }
                else
                {
                    result = "001";
                }
            }

            jm.html = result;
            return Json(jm, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetListtb_PurchaseSupplier(int? page)
        {
            string KeyWord = DNTRequest.GetString("KeyWord");

            int rows = DNTRequest.GetInt("rows", 10);
            string strWhere = " 1=1 ";
            if (KeyWord != "")
            {
                strWhere += " and (Name like '%" + KeyWord + "%'  or code like '%" + KeyWord + "% ') ";
            }
            int count = 0;

            string sql = @"select  * from [" + DBName + @"].[dbo].[tb_PurchaseSupplier]  where  " + strWhere;
            DataSet ds = DataPageHelper.GetDataPage(DataPageHelper.GetPageSql(sql, page.Value, rows, "id desc"), out count);
            List<tb_PurchaseSupplier> list = TBToList<tb_PurchaseSupplier>.ConvertToList(ds.Tables[0]).ToList();
            var grid = new EasyuiDataGrid<List<tb_PurchaseSupplier>>();
            grid.total = count;
            grid.rows = list;
            return Json(grid, JsonRequestBehavior.AllowGet);
        }



        public ActionResult savetb_PurchaseSupplier(tb_PurchaseSupplier model)
        {

            JsonModel jm = new JsonModel();
            try
            {
                Maticsoft.DAL.tb_PurchaseSupplierDAL bll = new Maticsoft.DAL.tb_PurchaseSupplierDAL(DBName);
                jm.status = 1;
                int id = DNTRequest.GetInt("id", 0);

                if (id == 0)
                {

                    bll.Add(model);
                    jm.status = 1;
                }
                else
                {
                    bll.Update(model);
                    jm.status = 1;
                }


            }
            catch (Exception ex)
            {
                jm.status = 0; jm.msg = ex.Message;
            }
            return Json(jm, JsonRequestBehavior.AllowGet);

        }
        public ActionResult Deltb_PurchaseSupplier(int id)
        {

            JsonModel jm = new JsonModel();
            try
            {
                jm.status = 1;
                StringBuilder strSql = new StringBuilder();
                strSql.Append("delete from [" + DBName + @"].[dbo].tb_PurchaseSupplier ");
                strSql.Append(" where id=" + id + "");
                DbHelperSQL.ExecuteSql(strSql.ToString());

            }
            catch (Exception ex)
            {
                jm.status = 0; jm.msg = ex.Message;
            }
            return Json(jm, JsonRequestBehavior.AllowGet);
        }
        #endregion


        #region tb_PurchaseOrder
        public ActionResult POSheet()
        {
            return View();
        }

        public ActionResult GetListtb_PurchaseOrder(int? page)
        {
            string KeyWord = DNTRequest.GetString("KeyWord");

            int rows = DNTRequest.GetInt("rows", 10);
            string strWhere = " 1=1  AND StoreID in(" + StoreId + ")  ";
            string SupId = DNTRequest.GetString("SupId");
            string status = DNTRequest.GetString("status");

            if (KeyWord != "")
            {
                strWhere += " and (SerialNum like '%" + KeyWord + "%'  or HandledUserName like '%" + KeyWord + "%' or ApprUserName like '%" + KeyWord + "%' or CreateUserName like '%" + KeyWord + "%' ) ";
            }
            if (SupId != "")
            {
                strWhere += " and (SupId = '" + SupId + "' ) ";
            }
            if (status != "")
            {
                strWhere += " and (status = '" + status.Trim() + "' ) ";
            }

            string StoreIds = DNTRequest.GetString("StoreIds");
            if (StoreIds != "")
            {
                strWhere += " and (StoreId='" + StoreIds + "') ";
            }
            string StoreNames = DNTRequest.GetString("StoreNames");
            if (StoreNames != "")
            {
                strWhere += " and (StoreName='" + StoreNames + "') ";
            }

            string StartDate = DNTRequest.GetString("StartDate");
            string EndDate = DNTRequest.GetString("EndDate");

            if (StartDate != "")
            {
                if (EndDate != "")
                {

                    strWhere += " and createDate between '" + StartDate + " 00:00:00' and '" + EndDate + " 23:59:59'";
                }
                else
                {
                    strWhere += " and createDate between '" + StartDate + " 00:00:00' and '" + System.DateTime.Now.ToShortDateString() + " 23:59:59'";
                }
            }

            int count = 0;
            string sql = @"select  * from [" + DBName + @"].[dbo].[View_SelectPurchaseOrder] as tb where   tb.StoreID in(" + StoreId + ") AND " + strWhere;
            DataSet ds = DataPageHelper.GetDataPage(DataPageHelper.GetPageSql(sql, page.Value, rows, "id desc"), out count);
            List<View_SelectPurchaseOrder> list = TBToList<View_SelectPurchaseOrder>.ConvertToList(ds.Tables[0]).ToList();
            var grid = new EasyuiDataGrid<List<View_SelectPurchaseOrder>>();
            grid.total = count;
            grid.rows = list;
            return Json(grid, JsonRequestBehavior.AllowGet);
        }


        public ActionResult savetb_PurchaseOrderStatus(int id, string status)
        {
            JsonModel jm = new JsonModel();
            jm.status = 1;

            StringBuilder strSql = new StringBuilder();
            strSql.Append(" update  [" + DBName + @"].[dbo].tb_PurchaseOrder set Status='" + status + "',ApprUserName='" + CurrentUserName + "',ApprDate=Getdate() ");
            strSql.Append(" where id='" + id + "'");
            DbHelperSQL.ExecuteSql(strSql.ToString());


            return Json(jm, JsonRequestBehavior.AllowGet);
        }
        public ActionResult savetb_PurchaseOrder(tb_PurchaseOrder model)
        {

            JsonModel jm = new JsonModel();
            try
            {
                Maticsoft.DAL.tb_PurchaseOrderDAL bll = new Maticsoft.DAL.tb_PurchaseOrderDAL(DBName);
                jm.status = 1;
                model.Status = "未审核";
                if (model.id == 0)
                {
                    int pid = bll.Add(model);
                    JavaScriptSerializer _JavaScriptSerializer = new JavaScriptSerializer();
                    var lists = _JavaScriptSerializer.Deserialize<List<tb_PurchaseOrderDetail>>(model.JsonString);
                    foreach (var item in lists)
                    {
                        if (item.DeleteFlag == false && item.HHNo != "" && item.HHNo != "0")    
                        {
                            Maticsoft.DAL.tb_PurchaseOrderDetailDAL bll1 = new Maticsoft.DAL.tb_PurchaseOrderDetailDAL(DBName);
                            item.POId = pid;
                            bll1.Add(item);
                        }
                    }
                    jm.status = 1;
                }
                else
                {
                    bll.Update(model);

                    StringBuilder strSql = new StringBuilder();
                    strSql.Append("delete from [" + DBName + @"].[dbo].tb_PurchaseOrderDetail ");
                    strSql.Append(" where POId=" + model.id + "");
                    DbHelperSQL.ExecuteSql(strSql.ToString());

                    JavaScriptSerializer _JavaScriptSerializer = new JavaScriptSerializer();
                    var lists = _JavaScriptSerializer.Deserialize<List<tb_PurchaseOrderDetail>>(model.JsonString);
                    foreach (var item in lists)
                    {
                        if (item.DeleteFlag == false && item.HHNo != "" && item.HHNo != "0")    
                        {
                            Maticsoft.DAL.tb_PurchaseOrderDetailDAL bll1 = new Maticsoft.DAL.tb_PurchaseOrderDetailDAL(DBName);
                            item.POId = model.id;
                            bll1.Add(item);
                        }

                    }
                    jm.status = 1;
                }


            }
            catch (Exception ex)
            {
                jm.status = 0; jm.msg = ex.Message;
            }
            return Json(jm, JsonRequestBehavior.AllowGet);

        }
        public ActionResult Deltb_PurchaseOrder(int id)
        {

            JsonModel jm = new JsonModel();
            try
            {
                jm.status = 1;
                StringBuilder strSql = new StringBuilder();
                strSql.Append("delete from [" + DBName + @"].[dbo].tb_PurchaseOrderDetail ");
                strSql.Append(" where POId=" + id + " ;");

                strSql.Append("delete from [" + DBName + @"].[dbo].tb_PurchaseOrder ");
                strSql.Append(" where id=" + id + "");
                DbHelperSQL.ExecuteSql(strSql.ToString());

            }
            catch (Exception ex)
            {
                jm.status = 0; jm.msg = ex.Message;
            }
            return Json(jm, JsonRequestBehavior.AllowGet);
        }


        public ActionResult POSheetAddOrEdit(int? id)
        {

            Maticsoft.Model.tb_PurchaseOrder model = new tb_PurchaseOrder();
            tb_PurchaseOrderDAL bll = new tb_PurchaseOrderDAL(DBName);
            if (id > 0)
            {
                model = bll.GetModel(Convert.ToInt32(id));
                model.SupName = DbHelperSQL.GetSingle("select name from  [" + DBName + @"].[dbo].tb_PurchaseSupplier where id='" + model.SupId + "'") + "";
                model.StoreName = DbHelperSQL.GetSingle("select name from  [" + DBName + @"].[dbo].tb_Store where id='" + model.StoreId + "'") + "";

            }
            else
            {
                model.SerialNum = "CG" + DateTime.Now.ToString("yyyyMMddHHmmss") + ServerInfo.GetBack_Str("SerialNum", "  [" + DBName + @"].dbo.tb_PurchaseOrder ", " CONVERT(varchar(10), CreateDate, 120 )=CONVERT(varchar(10),getdate(),120) order by CreateDate DESC");
                model.CreateDate = DateTime.Now;
                model.CreateUserName = CurrentUserName;
            }

            string sql = @"select * from [" + DBName + @"].[dbo].[tb_PurchaseOrderDetail]  where poid='" + id + "' ";
            DataSet ds = DbHelperSQL.Query(sql); ;
            List<tb_PurchaseOrderDetail> list = TBToList<tb_PurchaseOrderDetail>.ConvertToList(ds.Tables[0]).ToList();
            ViewBag.list = list;
            return View(model);
        }

        #endregion

        #region tb_PurchaseOrderAccept
        public ActionResult PISheet()
        {
            return View();
        }

        public ActionResult GetListtb_PurchaseOrderAccept(int? page)
        {
            string KeyWord = DNTRequest.GetString("KeyWord");

            int rows = DNTRequest.GetInt("rows", 10);
            string strWhere = " 1=1  AND StoreID in(" + StoreId + ")  ";
            string SupId = DNTRequest.GetString("SupId");
            string status = DNTRequest.GetString("status");
 
            if (KeyWord != "")
            {
                strWhere += " and (SerialNum like '%" + KeyWord + "%'  or HandledUserName like '%" + KeyWord + "%' or ApprUserName like '%" + KeyWord + "%' or CreateUserName like '%" + KeyWord + "%' ) ";
            }
            if (SupId != "")
            {
                strWhere += " and (SupId = '" + SupId + "' ) ";
            }
            if (status != "")
            {
                strWhere += " and (status = '" + status.Trim() + "' ) ";
            }

            string StoreIds = DNTRequest.GetString("StoreIds");
            if (StoreIds != "")
            {
                strWhere += " and (StoreId='" + StoreIds + "') ";
            }
            string StoreNames = DNTRequest.GetString("StoreNames");
            if (StoreNames != "")
            {
                strWhere += " and (StoreName='" + StoreNames + "') ";
            }

            string StartDate = DNTRequest.GetString("StartDate");
            string EndDate = DNTRequest.GetString("EndDate");

            if (StartDate != "")
            {
                if (EndDate != "")
                {

                    strWhere += " and createDate between '" + StartDate + " 00:00:00' and '" + EndDate + " 23:59:59'";
                }
                else
                {
                    strWhere += " and createDate between '" + StartDate + " 00:00:00' and '" + System.DateTime.Now.ToShortDateString() + " 23:59:59'";
                }
            }

            int count = 0;

            string sql = @"select  * from [" + DBName + @"].[dbo].[View_SelectPurchaseOrderAccept] as tb where  " + strWhere;
            DataSet ds = DataPageHelper.GetDataPage(DataPageHelper.GetPageSql(sql, page.Value, rows, "id desc"), out count);
            List<View_SelectPurchaseOrder> list = TBToList<View_SelectPurchaseOrder>.ConvertToList(ds.Tables[0]).ToList();
            var grid = new EasyuiDataGrid<List<View_SelectPurchaseOrder>>();
            grid.total = count;
            grid.rows = list;
            return Json(grid, JsonRequestBehavior.AllowGet);
        }


        public ActionResult savetb_PurchaseOrderAcceptStatus(int id, string status)
        {
            JsonModel jm = new JsonModel();
            jm.status = 1;

            //StringBuilder strSql = new StringBuilder();
            //strSql.Append(" update  [" + DBName + @"].[dbo].tb_PurchaseOrderAccept set Status='" + status + "',ApprUserName='" + CurrentUserName + "',ApprDate=Getdate() ");
            //strSql.Append(" where id='" + id + "'");
            //DbHelperSQL.ExecuteSql(strSql.ToString());

            DbHelperSQL.GetSingle(@"DECLARE @RC int;EXECUTE @RC = [" + DBName + @"].[dbo].[UP_tb_PurchaseOrderAccept] 
                          " + id + @"
                          ,'" + status + @"'
                          ,'" + CurrentUserName + @"'; Select @RC"); 


            return Json(jm, JsonRequestBehavior.AllowGet);
        }
        public ActionResult savetb_PurchaseOrderAccept(tb_PurchaseOrderAccept model)
        {

            JsonModel jm = new JsonModel();
            try
            {
                Maticsoft.DAL.tb_PurchaseOrderAcceptDAL bll = new Maticsoft.DAL.tb_PurchaseOrderAcceptDAL(DBName);
                jm.status = 1;
                model.Status = "未审核";
                if (model.id == 0)
                {
                    int pid = bll.Add(model);
                    JavaScriptSerializer _JavaScriptSerializer = new JavaScriptSerializer();
                    var lists = _JavaScriptSerializer.Deserialize<List<tb_PurchaseOrderAcceptDetail>>(model.JsonString);
                    foreach (var item in lists)
                    {
                        if (item.DeleteFlag == false && item.HHNo != "" && item.HHNo != "0")    
                        {
                            Maticsoft.DAL.tb_PurchaseOrderAcceptDetailDAL bll1 = new Maticsoft.DAL.tb_PurchaseOrderAcceptDetailDAL(DBName);
                            item.POId = pid;

                        

                            bll1.Add(item);
                        }
                    }
                    jm.status = pid;


                }
                else
                {
                    bll.Update(model);

                    StringBuilder strSql = new StringBuilder();
                    strSql.Append("delete from [" + DBName + @"].[dbo].tb_PurchaseOrderAcceptDetail ");
                    strSql.Append(" where POId=" + model.id + "");
                    DbHelperSQL.ExecuteSql(strSql.ToString());

                    JavaScriptSerializer _JavaScriptSerializer = new JavaScriptSerializer();
                    var lists = _JavaScriptSerializer.Deserialize<List<tb_PurchaseOrderAcceptDetail>>(model.JsonString);
                    foreach (var item in lists)
                    {
                        if (item.DeleteFlag == false && item.HHNo != "" && item.HHNo != "0")    
                        {
                            Maticsoft.DAL.tb_PurchaseOrderAcceptDetailDAL bll1 = new Maticsoft.DAL.tb_PurchaseOrderAcceptDetailDAL(DBName);
                            item.POId = model.id;
                            bll1.Add(item);
                        }

                    }
                    jm.status = model.id;
                }


            }
            catch (Exception ex)
            {
                jm.status = 0; jm.msg = ex.Message;
            }
            return Json(jm, JsonRequestBehavior.AllowGet);

        }
        public ActionResult Deltb_PurchaseOrderAccept(int id)
        {

            JsonModel jm = new JsonModel();
            try
            {
                jm.status = 1;
                StringBuilder strSql = new StringBuilder();
                strSql.Append("delete from [" + DBName + @"].[dbo].tb_PurchaseOrderAcceptDetail ");
                strSql.Append(" where POId=" + id + " ;");

                strSql.Append("delete from [" + DBName + @"].[dbo].tb_PurchaseOrderAccept ");
                strSql.Append(" where id=" + id + "");
                DbHelperSQL.ExecuteSql(strSql.ToString());

            }
            catch (Exception ex)
            {
                jm.status = 0; jm.msg = ex.Message;
            }
            return Json(jm, JsonRequestBehavior.AllowGet);
        }


        public ActionResult PISheetAddOrEdit(int? id)
        {

            Maticsoft.Model.tb_PurchaseOrderAccept model = new tb_PurchaseOrderAccept();
            tb_PurchaseOrderAcceptDAL bll = new tb_PurchaseOrderAcceptDAL(DBName);
            if (id > 0)
            {
                model = bll.GetModel(Convert.ToInt32(id));
                model.SupName = DbHelperSQL.GetSingle("select name from  [" + DBName + @"].[dbo].tb_PurchaseSupplier where id='" + model.SupId + "'") + "";
                model.StoreName = DbHelperSQL.GetSingle("select name from  [" + DBName + @"].[dbo].tb_Store where id='" + model.StoreId + "'") + "";

            }
            else
            {
                model.SerialNum = "SH" + DateTime.Now.ToString("yyyyMMddHHmmss") + ServerInfo.GetBack_Str("SerialNum", "  [" + DBName + @"].dbo.tb_PurchaseOrderAccept ", " CONVERT(varchar(10), CreateDate, 120 )=CONVERT(varchar(10),getdate(),120) order by CreateDate DESC");
                model.CreateDate = DateTime.Now;
                model.CreateUserName = CurrentUserName;
            }

            string sql = @"select * from [" + DBName + @"].[dbo].[tb_PurchaseOrderAcceptDetail]  where poid='" + id + "' ";
            DataSet ds = DbHelperSQL.Query(sql); ;
            List<tb_PurchaseOrderAcceptDetail> list = TBToList<tb_PurchaseOrderAcceptDetail>.ConvertToList(ds.Tables[0]).ToList();
            ViewBag.list = list;
            return View(model);
        }

        #endregion

        #region tb_PurchaseOrderReturn
        public ActionResult ROSheet()
        {
            return View();
        }

        public ActionResult GetListtb_PurchaseOrderReturn(int? page)
        {
            string KeyWord = DNTRequest.GetString("KeyWord");

            int rows = DNTRequest.GetInt("rows", 10);
            string strWhere = " 1=1  AND StoreID in(" + StoreId + ")  ";
            string SupId = DNTRequest.GetString("SupId");
            string status = DNTRequest.GetString("status");

            if (KeyWord != "")
            {
                strWhere += " and (SerialNum like '%" + KeyWord + "%'  or HandledUserName like '%" + KeyWord + "%' or ApprUserName like '%" + KeyWord + "%' or CreateUserName like '%" + KeyWord + "%' ) ";
            }
            if (SupId != "")
            {
                strWhere += " and (SupId = '" + SupId + "' ) ";
            }
            if (status != "")
            {
                strWhere += " and (status = '" + status.Trim() + "' ) ";
            }

            string StoreIds = DNTRequest.GetString("StoreIds");
            if (StoreIds != "")
            {
                strWhere += " and (StoreId='" + StoreIds + "') ";
            }
            string StoreNames = DNTRequest.GetString("StoreNames");
            if (StoreNames != "")
            {
                strWhere += " and (StoreName='" + StoreNames + "') ";
            }

            string StartDate = DNTRequest.GetString("StartDate");
            string EndDate = DNTRequest.GetString("EndDate");

            if (StartDate != "")
            {
                if (EndDate != "")
                {

                    strWhere += " and createDate between '" + StartDate + " 00:00:00' and '" + EndDate + " 23:59:59'";
                }
                else
                {
                    strWhere += " and createDate between '" + StartDate + " 00:00:00' and '" + System.DateTime.Now.ToShortDateString() + " 23:59:59'";
                }
            }

            int count = 0;

            string sql = @"select  * from [" + DBName + @"].[dbo].[View_SelectPurchaseOrderReturn] as tb where  " + strWhere;
            DataSet ds = DataPageHelper.GetDataPage(DataPageHelper.GetPageSql(sql, page.Value, rows, "id desc"), out count);
            List<View_SelectPurchaseOrder> list = TBToList<View_SelectPurchaseOrder>.ConvertToList(ds.Tables[0]).ToList();
            var grid = new EasyuiDataGrid<List<View_SelectPurchaseOrder>>();
            grid.total = count;
            grid.rows = list;
            return Json(grid, JsonRequestBehavior.AllowGet);
        }


        public ActionResult savetb_PurchaseOrderReturnStatus(int id, string status)
        {
            JsonModel jm = new JsonModel();
            jm.status = 1;

            //StringBuilder strSql = new StringBuilder();
            //strSql.Append(" update  [" + DBName + @"].[dbo].tb_PurchaseOrderReturn set Status='" + status + "',ApprUserName='" + CurrentUserName + "',ApprDate=Getdate() ");
            //strSql.Append(" where id='" + id + "'");
            //DbHelperSQL.ExecuteSql(strSql.ToString());


            DbHelperSQL.GetSingle(@"DECLARE @RC int;EXECUTE @RC = [" + DBName + @"].[dbo].[UP_tb_PurchaseOrderReturn] 
                          " + id + @"
                          ,'" + status + @"'
                          ,'" + CurrentUserName + @"'; Select @RC"); 

            return Json(jm, JsonRequestBehavior.AllowGet);
        }
        public ActionResult savetb_PurchaseOrderReturn(tb_PurchaseOrderReturn model)
        {

            JsonModel jm = new JsonModel();
            try
            {
                Maticsoft.DAL.tb_PurchaseOrderReturnDAL bll = new Maticsoft.DAL.tb_PurchaseOrderReturnDAL(DBName);
                jm.status = 1;
                model.Status = "未审核";
                if (model.id == 0)
                {
                    int pid = bll.Add(model);
                    JavaScriptSerializer _JavaScriptSerializer = new JavaScriptSerializer();
                    var lists = _JavaScriptSerializer.Deserialize<List<tb_PurchaseOrderReturnDetail>>(model.JsonString);
                    foreach (var item in lists)
                    {
                        if (item.DeleteFlag == false && item.HHNo != "" && item.HHNo != "0")    
                        {
                            Maticsoft.DAL.tb_PurchaseOrderReturnDetailDAL bll1 = new Maticsoft.DAL.tb_PurchaseOrderReturnDetailDAL(DBName);
                            item.POId = pid;
                            bll1.Add(item);
                        }
                    }
                    jm.status = pid;
                }
                else
                {
                    bll.Update(model);

                    StringBuilder strSql = new StringBuilder();
                    strSql.Append("delete from [" + DBName + @"].[dbo].tb_PurchaseOrderReturnDetail ");
                    strSql.Append(" where POId=" + model.id + "");
                    DbHelperSQL.ExecuteSql(strSql.ToString());

                    JavaScriptSerializer _JavaScriptSerializer = new JavaScriptSerializer();
                    var lists = _JavaScriptSerializer.Deserialize<List<tb_PurchaseOrderReturnDetail>>(model.JsonString);
                    foreach (var item in lists)
                    {
                        if (item.DeleteFlag == false && item.HHNo != "" && item.HHNo != "0")    
                        {
                            Maticsoft.DAL.tb_PurchaseOrderReturnDetailDAL bll1 = new Maticsoft.DAL.tb_PurchaseOrderReturnDetailDAL(DBName);
                            item.POId = model.id;
                            bll1.Add(item);
                        }

                    }
                    jm.status = model.id;
                }


            }
            catch (Exception ex)
            {
                jm.status = 0; jm.msg = ex.Message;
            }
            return Json(jm, JsonRequestBehavior.AllowGet);

        }
        public ActionResult Deltb_PurchaseOrderReturn(int id)
        {

            JsonModel jm = new JsonModel();
            try
            {
                jm.status = 1;
                StringBuilder strSql = new StringBuilder();
                strSql.Append("delete from [" + DBName + @"].[dbo].tb_PurchaseOrderReturnDetail ");
                strSql.Append(" where POId=" + id + " ;");

                strSql.Append("delete from [" + DBName + @"].[dbo].tb_PurchaseOrderReturn ");
                strSql.Append(" where id=" + id + "");
                DbHelperSQL.ExecuteSql(strSql.ToString());

            }
            catch (Exception ex)
            {
                jm.status = 0; jm.msg = ex.Message;
            }
            return Json(jm, JsonRequestBehavior.AllowGet);
        }


        public ActionResult ROSheetAddOrEdit(int? id)
        {

            Maticsoft.Model.tb_PurchaseOrderReturn model = new tb_PurchaseOrderReturn();
            tb_PurchaseOrderReturnDAL bll = new tb_PurchaseOrderReturnDAL(DBName);
            if (id > 0)
            {
                model = bll.GetModel(Convert.ToInt32(id));
                model.SupName = DbHelperSQL.GetSingle("select name from  [" + DBName + @"].[dbo].tb_PurchaseSupplier where id='" + model.SupId + "'") + "";
                model.StoreName = DbHelperSQL.GetSingle("select name from  [" + DBName + @"].[dbo].tb_Store where id='" + model.StoreId + "'") + "";

            }
            else
            {
                model.SerialNum = "TH" + DateTime.Now.ToString("yyyyMMddHHmmss") + ServerInfo.GetBack_Str("SerialNum", "  [" + DBName + @"].dbo.tb_PurchaseOrderReturn ", " CONVERT(varchar(10), CreateDate, 120 )=CONVERT(varchar(10),getdate(),120) order by CreateDate DESC");
                model.CreateDate = DateTime.Now;
                model.CreateUserName = CurrentUserName;
            }

            string sql = @"select * from [" + DBName + @"].[dbo].[tb_PurchaseOrderReturnDetail]  where poid='" + id + "' ";
            DataSet ds = DbHelperSQL.Query(sql); ;
            List<tb_PurchaseOrderReturnDetail> list = TBToList<tb_PurchaseOrderReturnDetail>.ConvertToList(ds.Tables[0]).ToList();
            ViewBag.list = list;
            return View(model);
        }

        #endregion

      
        #region 按日
        public ActionResult RptPurDaily()
        {
            return View();
        }
        public ActionResult GetListView_SelectPurchaseOrder_Sum(int? page)
        {
            string KeyWord = DNTRequest.GetString("KeyWord");

            int rows = DNTRequest.GetInt("rows", 10);
            string strWhere = " 1=1 AND  StoreID in(" + StoreId + ") ";
            if (KeyWord != "")
            {
                strWhere += " and (ProductName like '%" + KeyWord + "%'  or HHNo like '%" + KeyWord + "%') ";
            }
        
      
            string StoreNames = DNTRequest.GetString("StoreNames");
            if (StoreNames != "")
            {
                strWhere += " and (StoreName='" + StoreNames + "') ";
            }

            string StartDate = DNTRequest.GetString("StartDate");
            string EndDate = DNTRequest.GetString("EndDate");

            if (StartDate != "")
            {
                if (EndDate != "")
                {

                    strWhere += " and createDate between '" + StartDate + " 00:00:00' and '" + EndDate + " 23:59:59'";
                }
                else
                {
                    strWhere += " and createDate between '" + StartDate + " 00:00:00' and '" + System.DateTime.Now.ToShortDateString() + " 23:59:59'";
                }
            }

            int count = 0;

            StringBuilder sql = new StringBuilder();
            sql.Append(@" SELECT ROW_NUMBER() OVER  (ORDER BY CreateDate)  as KeyID , *  FROM [" + DBName + @"].dbo.[View_SelectPurchaseReport_Day]  ");

            //sql.Append(@" SELECT ROW_NUMBER() OVER  (ORDER BY HHNo)  as KeyID , *  FROM [" + DBName + @"].dbo.[View_SelectPurchaseReport_OK]  ");
            sql.Append(" where " + strWhere+"");


            DataSet ds = DataPageHelper.GetDataPage(DataPageHelper.GetPageSql(sql.ToString(), page.Value, rows, "HHNo desc"), out count);
            List<View_SelectPurchaseOrder_Sum> list = TBToList<View_SelectPurchaseOrder_Sum>.ConvertToList(ds.Tables[0]).ToList();
            var grid = new EasyuiDataGrid<List<View_SelectPurchaseOrder_Sum>>();
            try
            {
                grid.total = count;
            }
            catch 
            {
                grid.total = 0;
            }
            grid.rows = list;
            return Json(grid, JsonRequestBehavior.AllowGet);
        }


        #endregion

        #region 按月
        public ActionResult RptPurMonthly()
        {
            return View();
        }

        public ActionResult GetListView_RptPurMonthly(int? page)
        {
            string KeyWord = DNTRequest.GetString("KeyWord");

            int rows = DNTRequest.GetInt("rows", 10);
            string strWhere = " 1=1 AND  StoreID in(" + StoreId + ") ";
            if (KeyWord != "")
            {
                strWhere += " and (ProductName like '%" + KeyWord + "%'  or HHNo like '%" + KeyWord + "%') ";
            }

            string StoreNames = DNTRequest.GetString("StoreNames");
            if (StoreNames != "")
            {
                strWhere += " and (StoreName='" + StoreNames + "') ";
            }

            string StartDate = DNTRequest.GetString("StartDate");
            string EndDate = DNTRequest.GetString("EndDate");

            if (StartDate != "")
            {
                if (EndDate != "")
                {

                    strWhere += " and createDate between '" + StartDate + " 00:00:00' and '" + EndDate + " 23:59:59'";
                }
                else
                {
                    strWhere += " and createDate between '" + StartDate + " 00:00:00' and '" + System.DateTime.Now.ToShortDateString() + " 23:59:59'";
                }
            }

            int count = 0;

            StringBuilder sql = new StringBuilder();
            sql.Append(@" SELECT ROW_NUMBER() OVER  (ORDER BY CreateDate)  as KeyID , *  FROM [" + DBName + @"].dbo.[View_SelectPurchaseReport_Month]  ");

            sql.Append(" where " + strWhere + "");


            DataSet ds = DataPageHelper.GetDataPage(DataPageHelper.GetPageSql(sql.ToString(), page.Value, rows, "CreateDate desc"), out count);
            List<View_SelectPurchaseOrder_Sum> list = TBToList<View_SelectPurchaseOrder_Sum>.ConvertToList(ds.Tables[0]).ToList();
            var grid = new EasyuiDataGrid<List<View_SelectPurchaseOrder_Sum>>();
            try
            {
                grid.total = count;
            }
            catch
            {
                grid.total = 0;
            }
            grid.rows = list;
            return Json(grid, JsonRequestBehavior.AllowGet);
        }


        #endregion

        #region 类别
        public ActionResult RptPurCategories()
        {
            return View();
        }

        public ActionResult GetListView_RptPurCategoriesSummary(int? page)
        {
            string KeyWord = DNTRequest.GetString("KeyWord");

            int rows = DNTRequest.GetInt("rows", 10);
            string strWhere = " 1=1 AND  StoreID in(" + StoreId + ")  ";
            if (KeyWord != "")
            {
                strWhere += " and (ProductClassCode like '%" + KeyWord + "%'  or ProductClassName like '%" + KeyWord + "%') ";
            }
            string StoreNames = DNTRequest.GetString("StoreNames");
            if (StoreNames != "")
            {
                strWhere += " and (StoreName='" + StoreNames + "') ";
            }

            string ClassName = DNTRequest.GetString("ClassName");
            if (ClassName != "")
            {
                strWhere += " and (ProductClassName='" + ClassName + "') ";
            }


            int count = 0;
            StringBuilder sql = new StringBuilder();
            sql.Append(@" SELECT ROW_NUMBER() OVER  (ORDER BY ProductClassCode)  as KeyID , *  FROM [" + DBName + @"].dbo.[View_SelectPurchaseReport_RptPurCategoriesSummary]  ");

            sql.Append(" where " + strWhere + "");


            DataSet ds = DataPageHelper.GetDataPage(DataPageHelper.GetPageSql(sql.ToString(), page.Value, rows, "ProductClassCode desc"), out count);
            List<View_SelectPurchaseOrder_Sum> list = TBToList<View_SelectPurchaseOrder_Sum>.ConvertToList(ds.Tables[0]).ToList();
            var grid = new EasyuiDataGrid<List<View_SelectPurchaseOrder_Sum>>();
            try
            {
                grid.total = count;
            }
            catch
            {
                grid.total = 0;
            }
            grid.rows = list;
            return Json(grid, JsonRequestBehavior.AllowGet);
        }


        #endregion

        #region 品牌
        public ActionResult RptPurBrandsSummary()
        {
            return View();
        }

        public ActionResult GetListView_RptPurBrandsSummary(int? page)
        {
            string KeyWord = DNTRequest.GetString("KeyWord");

            int rows = DNTRequest.GetInt("rows", 10);
            string strWhere = " 1=1 AND  StoreID in(" + StoreId + ")  ";
            if (KeyWord != "")
            {
                strWhere += " and (BrandCode like '%" + KeyWord + "%'  or ProductBrandName like '%" + KeyWord + "%') ";
            }
            string StoreNames = DNTRequest.GetString("StoreNames");
            if (StoreNames != "")
            {
                strWhere += " and (StoreName='" + StoreNames + "') ";
            }

            string BrandName = DNTRequest.GetString("BrandName");
            if (BrandName != "")
            {
                strWhere += " and (ProductBrandName='" + BrandName + "') ";
            }


            int count = 0;

            StringBuilder sql = new StringBuilder();
            sql.Append(@" SELECT ROW_NUMBER() OVER  (ORDER BY BrandCode)  as KeyID , *  FROM [" + DBName + @"].dbo.[View_SelectPurchaseReport_RptPurBrandsSummary]  ");

            sql.Append(" where " + strWhere + "");


            DataSet ds = DataPageHelper.GetDataPage(DataPageHelper.GetPageSql(sql.ToString(), page.Value, rows, "BrandCode desc"), out count);
            List<View_SelectPurchaseOrder_Sum> list = TBToList<View_SelectPurchaseOrder_Sum>.ConvertToList(ds.Tables[0]).ToList();
            var grid = new EasyuiDataGrid<List<View_SelectPurchaseOrder_Sum>>();
            try
            {
                grid.total = count;
            }
            catch
            {
                grid.total = 0;
            }
            grid.rows = list;
            return Json(grid, JsonRequestBehavior.AllowGet);
        }


        #endregion
       
        #region 供应商
        public ActionResult RptPurVendorsSummary()
        {
            return View();
        }

        public ActionResult GetListView_RptPurVendorsSummary(int? page)
        {
            string KeyWord = DNTRequest.GetString("KeyWord");

            int rows = DNTRequest.GetInt("rows", 10);
            string strWhere = " 1=1 AND  StoreID in(" + StoreId + ") ";
            if (KeyWord != "")
            {
                strWhere += " and (SupplierCode like '%" + KeyWord + "%'  or SupplierName like '%" + KeyWord + "%') ";
            }
            string StoreNames = DNTRequest.GetString("StoreNames");
            if (StoreNames != "")
            {
                strWhere += " and (StoreName='" + StoreNames + "') ";
            }

            string SupName = DNTRequest.GetString("SupName");
            if (SupName != "")
            {
                strWhere += " and (SupplierName='" + SupName + "') ";
            }
            int count = 0;

            StringBuilder sql = new StringBuilder();
            sql.Append(@" SELECT ROW_NUMBER() OVER  (ORDER BY SupplierCode)  as KeyID , *  FROM [" + DBName + @"].dbo.[View_SelectPurchaseReport_RptPurVendorsSummary]  ");

            sql.Append(" where " + strWhere + "");


            DataSet ds = DataPageHelper.GetDataPage(DataPageHelper.GetPageSql(sql.ToString(), page.Value, rows, "SupplierCode desc"), out count);
            List<View_SelectPurchaseOrder_Sum> list = TBToList<View_SelectPurchaseOrder_Sum>.ConvertToList(ds.Tables[0]).ToList();
            var grid = new EasyuiDataGrid<List<View_SelectPurchaseOrder_Sum>>();
            try
            {
                grid.total = count;
            }
            catch
            {
                grid.total = 0;
            }
            grid.rows = list;
            return Json(grid, JsonRequestBehavior.AllowGet);
        }


        #endregion

        #region 采购明细汇总
        public ActionResult RptPurDetail()
        {
            return View();
        }

        public ActionResult GetListView_RptPurDetail(int? page)
        {
            string KeyWord = DNTRequest.GetString("KeyWord");
            string ProductType = DNTRequest.GetString("ProductType");
            string ClassId = DNTRequest.GetString("ClassId");
            string BrandId = DNTRequest.GetString("BrandId");
            string SupId = DNTRequest.GetString("SupId");

            int rows = DNTRequest.GetInt("rows", 10);
            string strWhere = " 1=1 ";
            if (KeyWord != "")
            {
                strWhere += " and (ProductName like '%" + KeyWord + "%'  or HHNo like '%" + KeyWord + "%' ) ";
            }

            if (ProductType != "")
            {
                strWhere += " and  ClassId in (SELECT id FROM [" + DBName + @"].[dbo].[f_ProductType_next] (" + Convert.ToInt32(ProductType) + ")) ";
            }

            if (BrandId != "")
            {
                strWhere += " and  BrandId in ('" + Convert.ToInt32(BrandId) + "') ";
            }

            if (ClassId != "")
            {
                strWhere += " and  ClassId in ('" + Convert.ToInt32(ClassId) + "') ";
            }
            if (SupId != "")
            {
                strWhere += " and  SupId in ('" + Convert.ToInt32(SupId) + "') ";
            }
            string StoreNames = DNTRequest.GetString("StoreNames");
            if (StoreNames != "")
            {
                strWhere += " and (StoreName='" + StoreNames + "') ";
            }
            int count = 0;

            StringBuilder sql = new StringBuilder();
            sql.Append(@" SELECT ROW_NUMBER() OVER  (ORDER BY id)  as KeyID , * ,'采购收货' CGType,(num*price) as SumPrice FROM [" + DBName + @"].dbo.[View_SelectPurchaseOrderAcceptDetailReport]  ");

            sql.Append(" where " + strWhere + "");


            DataSet ds = DataPageHelper.GetDataPage(DataPageHelper.GetPageSql(sql.ToString(), page.Value, rows, "id desc"), out count);
            List<View_SelectPurchaseOrder_SumMX> list = TBToList<View_SelectPurchaseOrder_SumMX>.ConvertToList(ds.Tables[0]).ToList();
            var grid = new EasyuiDataGrid<List<View_SelectPurchaseOrder_SumMX>>();
            try
            {
                grid.total = count;
            }
            catch
            {
                grid.total = 0;
            }
            grid.rows = list;
            return Json(grid, JsonRequestBehavior.AllowGet);
        }


        #endregion
    }
}
