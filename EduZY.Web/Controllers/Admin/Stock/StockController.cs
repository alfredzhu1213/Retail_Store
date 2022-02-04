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

namespace EduZY.Web.Controllers.Admin.Stock
{
    [SupportFilter]
    public class StockController : Base.BaseController
    {

        public ActionResult savetb_StockChainSet(tb_StockChainSet model)
        {

            JsonModel jm = new JsonModel();
            try
            {
                Maticsoft.DAL.tb_StockChainSetDAL bll = new Maticsoft.DAL.tb_StockChainSetDAL(DBName);
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

        public ActionResult ChainBranchSetting()
        {
            Maticsoft.Model.tb_StockChainSet model = new tb_StockChainSet();
            tb_StockChainSetDAL bll = new tb_StockChainSetDAL(DBName);
            model = bll.GetModel(1);
            return View(model);
        }
        public ActionResult StockIn()
        {
            return View();
        }
        public ActionResult StockOut()
        {
            return View();
        }
        public ActionResult StockDB()
        {
            return View();
        }
        public ActionResult StockPanDian()
        {
            return View();
        }
      
        #region tb_StockIn
      
        public ActionResult GetListtb_StockIn(int? page)
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

            string sql = @"select  * from [" + DBName + @"].[dbo].[View_SelectStockIn] as tb where  " + strWhere;
            DataSet ds = DataPageHelper.GetDataPage(DataPageHelper.GetPageSql(sql, page.Value, rows, "id desc"), out count);
            List<View_SelectPurchaseOrder> list = TBToList<View_SelectPurchaseOrder>.ConvertToList(ds.Tables[0]).ToList();
            var grid = new EasyuiDataGrid<List<View_SelectPurchaseOrder>>();
            grid.total = count;
            grid.rows = list;
            return Json(grid, JsonRequestBehavior.AllowGet);
        }
        public ActionResult savetb_StockInStatus(int id, string status)
        {
            JsonModel jm = new JsonModel();
            jm.status = 1;

            //StringBuilder strSql = new StringBuilder();
            //strSql.Append(" update  [" + DBName + @"].[dbo].tb_StockIn set Status='" + status + "',ApprUserName='" + CurrentUserName + "',ApprDate=Getdate() ");
            //strSql.Append(" where id='" + id + "'");
            //DbHelperSQL.ExecuteSql(strSql.ToString());

            DbHelperSQL.GetSingle(@"DECLARE @RC int;EXECUTE @RC = [" + DBName + @"].[dbo].[UP_tb_StockIn] 
                          " + id + @"
                          ,'" + status + @"'
                          ,'" + CurrentUserName + @"'; Select @RC"); 


            return Json(jm, JsonRequestBehavior.AllowGet);
        }
        public ActionResult savetb_StockIn(tb_StockIn model)
        {

            JsonModel jm = new JsonModel();
            try
            {
                Maticsoft.DAL.tb_StockInDAL bll = new Maticsoft.DAL.tb_StockInDAL(DBName);
                jm.status = 1;
                model.Status = "未审核";
                if (model.id == 0)
                {
                    int pid = bll.Add(model);
                    JavaScriptSerializer _JavaScriptSerializer = new JavaScriptSerializer();
                    var lists = _JavaScriptSerializer.Deserialize<List<tb_StockInDetail>>(model.JsonString);
                    foreach (var item in lists)
                    {
                        if (item.DeleteFlag == false && item.HHNo != "" && item.HHNo != "0")    
                        {
                            Maticsoft.DAL.tb_StockInDetailDAL bll1 = new Maticsoft.DAL.tb_StockInDetailDAL(DBName);
                            item.StockInId = pid;
                            bll1.Add(item);
                        }
                    }
                    jm.status = pid;
                }
                else
                {
                    bll.Update(model);

                    StringBuilder strSql = new StringBuilder();
                    strSql.Append("delete from [" + DBName + @"].[dbo].tb_StockInDetail ");
                    strSql.Append(" where StockInId=" + model.id + "");
                    DbHelperSQL.ExecuteSql(strSql.ToString());

                    JavaScriptSerializer _JavaScriptSerializer = new JavaScriptSerializer();
                    var lists = _JavaScriptSerializer.Deserialize<List<tb_StockInDetail>>(model.JsonString);
                    foreach (var item in lists)
                    {
                        if (item.DeleteFlag == false && item.HHNo != "" && item.HHNo != "0")
                        {
                            Maticsoft.DAL.tb_StockInDetailDAL bll1 = new Maticsoft.DAL.tb_StockInDetailDAL(DBName);
                            item.StockInId = model.id;
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
        public ActionResult Deltb_StockIn(int id)
        {

            JsonModel jm = new JsonModel();
            try
            {
                jm.status = 1;
                StringBuilder strSql = new StringBuilder();
                strSql.Append("delete from [" + DBName + @"].[dbo].tb_StockInDetail ");
                strSql.Append(" where StockInId=" + id + " ;");

                strSql.Append("delete from [" + DBName + @"].[dbo].tb_StockIn ");
                strSql.Append(" where id=" + id + "");
                DbHelperSQL.ExecuteSql(strSql.ToString());

            }
            catch (Exception ex)
            {
                jm.status = 0; jm.msg = ex.Message;
            }
            return Json(jm, JsonRequestBehavior.AllowGet);
        }
        public ActionResult StockInAddOrEdit(int? id)
        {

            Maticsoft.Model.tb_StockIn model = new tb_StockIn();
            tb_StockInDAL bll = new tb_StockInDAL(DBName);
            if (id > 0)
            {
                model = bll.GetModel(Convert.ToInt32(id));
              
                model.StoreName = DbHelperSQL.GetSingle("select name from  [" + DBName + @"].[dbo].tb_Store where id='" + model.StoreId + "'") + "";

            }
            else
            {
                model.SerialNum = "RK" + DateTime.Now.ToString("yyyyMMddHHmmss") + ServerInfo.GetBack_Str("SerialNum", "  [" + DBName + @"].dbo.tb_StockIn ", " CONVERT(varchar(10), CreateDate, 120 )=CONVERT(varchar(10),getdate(),120) order by CreateDate DESC");
                model.CreateDate = DateTime.Now;
                model.CreateUserName = CurrentUserName;
            }

            string sql = @"select * from [" + DBName + @"].[dbo].[tb_StockInDetail]  where StockInId='" + id + "' ";
            DataSet ds = DbHelperSQL.Query(sql); ;
            List<tb_StockInDetail> list = TBToList<tb_StockInDetail>.ConvertToList(ds.Tables[0]).ToList();
            ViewBag.list = list;
            return View(model);
        }

        #endregion
        #region tb_StockOut

        public ActionResult GetListtb_StockOut(int? page)
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

            string sql = @"select  * from [" + DBName + @"].[dbo].[View_SelectStockOut] as tb where  " + strWhere;
            DataSet ds = DataPageHelper.GetDataPage(DataPageHelper.GetPageSql(sql, page.Value, rows, "id desc"), out count);
            List<View_SelectPurchaseOrder> list = TBToList<View_SelectPurchaseOrder>.ConvertToList(ds.Tables[0]).ToList();
            var grid = new EasyuiDataGrid<List<View_SelectPurchaseOrder>>();
            grid.total = count;
            grid.rows = list;
            return Json(grid, JsonRequestBehavior.AllowGet);
        }


        public ActionResult savetb_StockOutStatus(int id, string status)
        {
            JsonModel jm = new JsonModel();
            jm.status = 1;

            //StringBuilder strSql = new StringBuilder();
            //strSql.Append(" update  [" + DBName + @"].[dbo].tb_StockOut set Status='" + status + "',ApprUserName='" + CurrentUserName + "',ApprDate=Getdate() ");
            //strSql.Append(" where id='" + id + "'");
            //DbHelperSQL.ExecuteSql(strSql.ToString());


            DbHelperSQL.GetSingle(@"DECLARE @RC int;EXECUTE @RC = [" + DBName + @"].[dbo].[UP_tb_StockOut] 
                          " + id + @"
                          ,'" + status + @"'
                          ,'" + CurrentUserName + @"'; Select @RC"); 

            return Json(jm, JsonRequestBehavior.AllowGet);
        }
        public ActionResult savetb_StockOut(tb_StockOut model)
        {

            JsonModel jm = new JsonModel();
            try
            {
                Maticsoft.DAL.tb_StockOutDAL bll = new Maticsoft.DAL.tb_StockOutDAL(DBName);
                jm.status = 1;
                model.Status = "未审核";
                if (model.id == 0)
                {
                    int pid = bll.Add(model);
                    JavaScriptSerializer _JavaScriptSerializer = new JavaScriptSerializer();
                    var lists = _JavaScriptSerializer.Deserialize<List<tb_StockOutDetail>>(model.JsonString);
                    foreach (var item in lists)
                    {
                        if (item.DeleteFlag == false && item.HHNo != "" && item.HHNo != "0")
                        {
                            Maticsoft.DAL.tb_StockOutDetailDAL bll1 = new Maticsoft.DAL.tb_StockOutDetailDAL(DBName);
                            item.StocOutId = pid;
                            bll1.Add(item);
                        }
                    }
                    jm.status = pid;
                }
                else
                {
                    bll.Update(model);

                    StringBuilder strSql = new StringBuilder();
                    strSql.Append("delete from [" + DBName + @"].[dbo].tb_StockOutDetail ");
                    strSql.Append(" where StocOutId=" + model.id + "");
                    DbHelperSQL.ExecuteSql(strSql.ToString());

                    JavaScriptSerializer _JavaScriptSerializer = new JavaScriptSerializer();
                    var lists = _JavaScriptSerializer.Deserialize<List<tb_StockOutDetail>>(model.JsonString);
                    foreach (var item in lists)
                    {
                        if (item.DeleteFlag == false && item.HHNo != "" && item.HHNo != "0")
                        {
                            Maticsoft.DAL.tb_StockOutDetailDAL bll1 = new Maticsoft.DAL.tb_StockOutDetailDAL(DBName);
                            item.StocOutId = model.id;
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
        public ActionResult Deltb_StockOut(int id)
        {

            JsonModel jm = new JsonModel();
            try
            {
                jm.status = 1;
                StringBuilder strSql = new StringBuilder();
                strSql.Append("delete from [" + DBName + @"].[dbo].tb_StockOutDetail ");
                strSql.Append(" where StocOutId=" + id + " ;");

                strSql.Append("delete from [" + DBName + @"].[dbo].tb_StockOut ");
                strSql.Append(" where id=" + id + "");
                DbHelperSQL.ExecuteSql(strSql.ToString());

            }
            catch (Exception ex)
            {
                jm.status = 0; jm.msg = ex.Message;
            }
            return Json(jm, JsonRequestBehavior.AllowGet);
        }


        public ActionResult StockOutAddOrEdit(int? id)
        {

            Maticsoft.Model.tb_StockOut model = new tb_StockOut();
            tb_StockOutDAL bll = new tb_StockOutDAL(DBName);
            if (id > 0)
            {
                model = bll.GetModel(Convert.ToInt32(id));

                model.StoreName = DbHelperSQL.GetSingle("select name from  [" + DBName + @"].[dbo].tb_Store where id='" + model.StoreId + "'") + "";

            }
            else
            {
                model.SerialNum = "CK" + DateTime.Now.ToString("yyyyMMddHHmmss") + ServerInfo.GetBack_Str("SerialNum", "  [" + DBName + @"].dbo.tb_StockOut ", " CONVERT(varchar(10), CreateDate, 120 )=CONVERT(varchar(10),getdate(),120) order by CreateDate DESC");
                model.CreateDate = DateTime.Now;
                model.CreateUserName = CurrentUserName;
            }

            string sql = @"select * from [" + DBName + @"].[dbo].[tb_StockOutDetail]  where StocOutId ='" + id + "' ";
            DataSet ds = DbHelperSQL.Query(sql); ;
            List<tb_StockOutDetail> list = TBToList<tb_StockOutDetail>.ConvertToList(ds.Tables[0]).ToList();
            ViewBag.list = list;
            return View(model);
        }

        #endregion
        #region tb_Stocktransfer

        public ActionResult GetListtb_Stocktransfer(int? page)
        {
            string KeyWord = DNTRequest.GetString("KeyWord");

            int rows = DNTRequest.GetInt("rows", 10);
            string strWhere = " 1=1 and (INStoreID in(" + StoreId + ") or  outStoreID in(" + StoreId + "))";
            string SupId = DNTRequest.GetString("SupId");
            string status = DNTRequest.GetString("status");

            if (KeyWord != "")
            {
                strWhere += " and (SerialNum like '%" + KeyWord + "%'  or HandledUserName like '%" + KeyWord + "%' or ApprUserName like '%" + KeyWord + "%' or CreateUserName like '%" + KeyWord + "%' ) ";
            }

            if (status != "")
            {
                strWhere += " and (status = '" + status.Trim() + "' ) ";
            }

          
            string StoreNames = DNTRequest.GetString("StoreNames");
            if (StoreNames != "")
            {
                strWhere += " and (OutStoreName='" + StoreNames + "') ";
            }

            string StoreNames1 = DNTRequest.GetString("StoreNames1");
            if (StoreNames1 != "")
            {
                strWhere += " and (InStoreName='" + StoreNames1 + "') ";
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

            string sql = @"select  * from [" + DBName + @"].[dbo].[View_SelectStocktransfer] as tb where  " + strWhere;
            DataSet ds = DataPageHelper.GetDataPage(DataPageHelper.GetPageSql(sql, page.Value, rows, "id desc"), out count);
            List<View_SelectPurchaseOrder> list = TBToList<View_SelectPurchaseOrder>.ConvertToList(ds.Tables[0]).ToList();
            var grid = new EasyuiDataGrid<List<View_SelectPurchaseOrder>>();
            grid.total = count;
            grid.rows = list;
            return Json(grid, JsonRequestBehavior.AllowGet);
        }


        public ActionResult savetb_StocktransferStatus(int id, string status)
        {
            JsonModel jm = new JsonModel();
            jm.status = 1;

            StringBuilder strSql = new StringBuilder();
            if (status == "审核通过")
            {
                strSql.Append(" update  [" + DBName + @"].[dbo].tb_Stocktransfer set Status='" + status + "',ApprUserName='" + CurrentUserName + "',ApprDate=Getdate() ");
                strSql.Append(" where id='" + id + "'");
            }
            else if (status == "已调出")
            {
                strSql.Append(" update  [" + DBName + @"].[dbo].tb_Stocktransfer set Status='" + status + "',ApprUserNameIn='" + CurrentUserName + "',ApprDateIn=Getdate() ");
                strSql.Append(" where id='" + id + "'");
            }


      


            DbHelperSQL.ExecuteSql(strSql.ToString());


            return Json(jm, JsonRequestBehavior.AllowGet);
        }
        public ActionResult savetb_Stocktransfer(tb_Stocktransfer model)
        {

            JsonModel jm = new JsonModel();
            try
            {
                Maticsoft.DAL.tb_StocktransferDAL bll = new Maticsoft.DAL.tb_StocktransferDAL(DBName);
                jm.status = 1;
                model.Status = "未审核";
                if (model.id == 0)
                {
                    int pid = bll.Add(model);
                    JavaScriptSerializer _JavaScriptSerializer = new JavaScriptSerializer();
                    var lists = _JavaScriptSerializer.Deserialize<List<tb_StocktransferDetail>>(model.JsonString);
                    foreach (var item in lists)
                    {
                        if (item.DeleteFlag == false && item.HHNo != "" && item.HHNo != "0")
                        {
                            Maticsoft.DAL.tb_StocktransferDetailDAL bll1 = new Maticsoft.DAL.tb_StocktransferDetailDAL(DBName);
                            item.StocktransferId = pid;
                            bll1.Add(item);
                        }
                    }
                    jm.status = pid;
                }
                else
                {
                    bll.Update(model);

                    StringBuilder strSql = new StringBuilder();
                    strSql.Append("delete from [" + DBName + @"].[dbo].tb_StocktransferDetail ");
                    strSql.Append(" where StocktransferId=" + model.id + "");
                    DbHelperSQL.ExecuteSql(strSql.ToString());

                    JavaScriptSerializer _JavaScriptSerializer = new JavaScriptSerializer();
                    var lists = _JavaScriptSerializer.Deserialize<List<tb_StocktransferDetail>>(model.JsonString);
                    foreach (var item in lists)
                    {
                        if (item.DeleteFlag == false && item.HHNo != "" && item.HHNo != "0")
                        {
                            Maticsoft.DAL.tb_StocktransferDetailDAL bll1 = new Maticsoft.DAL.tb_StocktransferDetailDAL(DBName);
                            item.StocktransferId = model.id;
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
        public ActionResult Deltb_Stocktransfer(int id)
        {

            JsonModel jm = new JsonModel();
            try
            {
                jm.status = 1;
                StringBuilder strSql = new StringBuilder();
                strSql.Append("delete from [" + DBName + @"].[dbo].tb_StocktransferDetail ");
                strSql.Append(" where StocktransferId=" + id + " ;");

                strSql.Append("delete from [" + DBName + @"].[dbo].tb_Stocktransfer ");
                strSql.Append(" where id=" + id + "");
                DbHelperSQL.ExecuteSql(strSql.ToString());

            }
            catch (Exception ex)
            {
                jm.status = 0; jm.msg = ex.Message;
            }
            return Json(jm, JsonRequestBehavior.AllowGet);
        }


        public ActionResult StockDBAddOrEdit(int? id)
        {

            Maticsoft.Model.tb_Stocktransfer model = new tb_Stocktransfer();
            tb_StocktransferDAL bll = new tb_StocktransferDAL(DBName);
            if (id > 0)
            {
                model = bll.GetModel(Convert.ToInt32(id));

                model.OutStoreName = DbHelperSQL.GetSingle("select name from  [" + DBName + @"].[dbo].tb_Store where id='" + model.OutStoreId + "'") + "";
                model.InStoreName = DbHelperSQL.GetSingle("select name from  [" + DBName + @"].[dbo].tb_Store where id='" + model.InStoreId + "'") + "";

            }
            else
            {
                model.SerialNum = "DB" + DateTime.Now.ToString("yyyyMMddHHmmss") + ServerInfo.GetBack_Str("SerialNum", "  [" + DBName + @"].dbo.tb_Stocktransfer ", " CONVERT(varchar(10), CreateDate, 120 )=CONVERT(varchar(10),getdate(),120) order by CreateDate DESC");
                model.CreateDate = DateTime.Now;
                model.CreateUserName = CurrentUserName;
            }

            string sql = @"select * from [" + DBName + @"].[dbo].[tb_StocktransferDetail]  where StocktransferId ='" + id + "' ";
            DataSet ds = DbHelperSQL.Query(sql); ;
            List<tb_StocktransferDetail> list = TBToList<tb_StocktransferDetail>.ConvertToList(ds.Tables[0]).ToList();
            ViewBag.list = list;
            return View(model);
        }

        #endregion
        #region tb_StockCheck

        public ActionResult GetListtb_StockCheck(int? page)
        {
            string KeyWord = DNTRequest.GetString("KeyWord");

            int rows = DNTRequest.GetInt("rows", 10);
            string strWhere = " 1=1 and tb.StoreID in(" + StoreId + ")  ";
            if (KeyWord != "")
            {
                strWhere += " and (SerialNum like '%" + KeyWord + "%'  or CreateUserName like '%" + KeyWord + "% ') ";
            }
            int count = 0;

            string sql = @"select  * from [" + DBName + @"].[dbo].[View_SelectStockCheck] as tb where  " + strWhere;
            DataSet ds = DataPageHelper.GetDataPage(DataPageHelper.GetPageSql(sql, page.Value, rows, "id desc"), out count);
            List<View_SelectPurchaseOrder> list = TBToList<View_SelectPurchaseOrder>.ConvertToList(ds.Tables[0]).ToList();
            var grid = new EasyuiDataGrid<List<View_SelectPurchaseOrder>>();
            grid.total = count;
            grid.rows = list;
            return Json(grid, JsonRequestBehavior.AllowGet);
        }
        public ActionResult savetb_StockCheckStatus(int id, string status)
        {
            JsonModel jm = new JsonModel();
            jm.status = 1;

            StringBuilder strSql = new StringBuilder();
            strSql.Append(" update  [" + DBName + @"].[dbo].tb_StockCheck set Status='" + status + "',ApprUserName='" + CurrentUserName + "',ApprDate=Getdate() ");
            strSql.Append(" where id='" + id + "'");
            DbHelperSQL.ExecuteSql(strSql.ToString());


            return Json(jm, JsonRequestBehavior.AllowGet);
        }
        public ActionResult savetb_StockCheck(tb_StockCheck model)
        {

            JsonModel jm = new JsonModel();
            try
            {
                Maticsoft.DAL.tb_StockCheckDAL bll = new Maticsoft.DAL.tb_StockCheckDAL(DBName);
                jm.status = 1;
                model.Status = "未审核";
                if (model.id == 0)
                {
                    int pid = bll.Add(model);
                    JavaScriptSerializer _JavaScriptSerializer = new JavaScriptSerializer();
                    var lists = _JavaScriptSerializer.Deserialize<List<tb_StockCheckDetail>>(model.JsonString);
                    foreach (var item in lists)
                    {
                        if (item.DeleteFlag == false && item.HHNo != "" && item.HHNo != "0")
                        {
                            Maticsoft.DAL.tb_StockCheckDetailDAL bll1 = new Maticsoft.DAL.tb_StockCheckDetailDAL(DBName);
                            item.StocOutId = pid;
                            bll1.Add(item);
                        }
                    }
                    jm.status = 1;
                }
                else
                {
                    bll.Update(model);

                    StringBuilder strSql = new StringBuilder();
                    strSql.Append("delete from [" + DBName + @"].[dbo].tb_StockCheckDetail ");
                    strSql.Append(" where StocOutId=" + model.id + "");
                    DbHelperSQL.ExecuteSql(strSql.ToString());

                    JavaScriptSerializer _JavaScriptSerializer = new JavaScriptSerializer();
                    var lists = _JavaScriptSerializer.Deserialize<List<tb_StockCheckDetail>>(model.JsonString);
                    foreach (var item in lists)
                    {
                        if (item.DeleteFlag == false && item.HHNo != "" && item.HHNo != "0")
                        {
                            Maticsoft.DAL.tb_StockCheckDetailDAL bll1 = new Maticsoft.DAL.tb_StockCheckDetailDAL(DBName);
                            item.StocOutId = model.id;
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
        public ActionResult Deltb_StockCheck(int id)
        {

            JsonModel jm = new JsonModel();
            try
            {
                jm.status = 1;
                StringBuilder strSql = new StringBuilder();
                strSql.Append("delete from [" + DBName + @"].[dbo].tb_StockCheckDetail ");
                strSql.Append(" where StocOutId=" + id + " ;");

                strSql.Append("delete from [" + DBName + @"].[dbo].tb_StockCheck ");
                strSql.Append(" where id=" + id + "");
                DbHelperSQL.ExecuteSql(strSql.ToString());

            }
            catch (Exception ex)
            {
                jm.status = 0; jm.msg = ex.Message;
            }
            return Json(jm, JsonRequestBehavior.AllowGet);
        }
        public ActionResult StockPanDianAddOrEdit(int? id)
        {

            Maticsoft.Model.tb_StockCheck model = new tb_StockCheck();
            tb_StockCheckDAL bll = new tb_StockCheckDAL(DBName);
            if (id > 0)
            {
                model = bll.GetModel(Convert.ToInt32(id));

                model.StoreName = DbHelperSQL.GetSingle("select name from  [" + DBName + @"].[dbo].tb_Store where id='" + model.StoreId + "'") + "";

            }
            else
            {
                model.SerialNum = "PD" + DateTime.Now.ToString("yyyyMMddHHmmss") + ServerInfo.GetBack_Str("SerialNum", "  [" + DBName + @"].dbo.tb_StockCheck ", " CONVERT(varchar(10), CreateDate, 120 )=CONVERT(varchar(10),getdate(),120) order by CreateDate DESC");
                model.CreateDate = DateTime.Now;
                model.CreateUserName = CurrentUserName;
            }

            string sql = @"select * from [" + DBName + @"].[dbo].[tb_StockCheckDetail]  where StocOutId='" + id + "' ";
            DataSet ds = DbHelperSQL.Query(sql); ;
            List<tb_StockCheckDetail> list = TBToList<tb_StockCheckDetail>.ConvertToList(ds.Tables[0]).ToList();
            ViewBag.list = list;
            return View(model);
        }
        #endregion

         // View_SelectStockReport_StockDetail_RptStmIODetail 出入库明细

    //View_SelectStockReport_StockRptStmCost_GroupBy  库存成本查询

    //View_SelectStockReport_StockDetail_RptStmDaily   出入库日汇总


    //View_SelectStockReport_StockDetail_RptStmMonthly   出入库月汇总

    //View_SelectStockReport_StocktransferDetail_RptStmDBItems 商品调拨明细

       
        #region View_SelectStockReport_StockRptStmCost
        public ActionResult RptStmCost()
        {
            return View();
        }

        public ActionResult GetListView_SelectStockReport_StockRptStmCost_GroupBy(int? page)
        {
            string KeyWord = DNTRequest.GetString("KeyWord");
            string ProductType = DNTRequest.GetString("ProductType");
            string ProductClassName = DNTRequest.GetString("ClassName");
            string BrandName = DNTRequest.GetString("BrandName");
            string SupplierName = DNTRequest.GetString("SupName");

            int rows = DNTRequest.GetInt("rows", 10);
            string strWhere = " 1=1  AND StoreID in(" + StoreId + ")  ";
            if (KeyWord != "")
            {
                strWhere += " and (ProductName like '%" + KeyWord + "%'  or HHNo like '%" + KeyWord + "%' ) ";
            }

            if (ProductClassName != "")
            {
                strWhere += " and  ProductClassName in ('" + ProductClassName + "') ";
            }

            if (BrandName != "")
            {
                strWhere += " and  BrandName in ('" + BrandName + "') ";
            }
            if (SupplierName != "")
            {
                strWhere += " and  SupplierName in ('" + SupplierName + "') ";
            }
            string StoreNames = DNTRequest.GetString("StoreNames");
            if (StoreNames != "")
            {
                strWhere += " and (StoreName='" + StoreNames + "') ";
            }


            int count = 0;
            string sql = @"select ROW_NUMBER() OVER  (ORDER BY HHNo)  as KeyID ,  * from [" + DBName + @"].[dbo].[View_SelectStockReport_StockRptStmCost_GroupBy]  where  " + strWhere;
            DataSet ds = DataPageHelper.GetDataPage(DataPageHelper.GetPageSql(sql, page.Value, rows, "HHNo desc"), out count);
            List<View_SelectStockReport_StockRptStmCost_GroupBy> list = TBToList<View_SelectStockReport_StockRptStmCost_GroupBy>.ConvertToList(ds.Tables[0]).ToList();
            var grid = new EasyuiDataGrid<List<View_SelectStockReport_StockRptStmCost_GroupBy>>();
            grid.total = count;
            grid.rows = list;
            return Json(grid, JsonRequestBehavior.AllowGet);
        }


        #endregion

        #region View_SelectStockReport_StockRptStmCost
        public ActionResult RptStmIODetail()
        {
            return View();
        }
        public ActionResult GetListView_SelectStockReport_StockDetail_RptStmIODetail(int? page)
        {
            string KeyWord = DNTRequest.GetString("KeyWord");
            string ProductClassName = DNTRequest.GetString("ClassName");
            string BrandName = DNTRequest.GetString("BrandName");
            string SupplierName = DNTRequest.GetString("SupName");


            int rows = DNTRequest.GetInt("rows", 10);
            string strWhere = " 1=1 and StoreID in(" + StoreId + ")";
            string StartDate = DNTRequest.GetString("StartDate");
            string EndDate = DNTRequest.GetString("EndDate");
            if (StartDate != "")
            {

                if (EndDate != "")
                {

                    strWhere += " and CreateDate between '" + StartDate + " 00:00:00' and '" + EndDate + " 23:59:59'";
                }
                else
                {
                    strWhere += " and CreateDate between '" + StartDate + " 00:00:00' and '" + System.DateTime.Now.ToShortDateString() + " 23:59:59'";
                }
            }

            if (KeyWord != "")
            {
                strWhere += " and (ProductName like '%" + KeyWord + "%'  or HHNo like '%" + KeyWord + "%' ) ";
            }

            if (ProductClassName != "")
            {
                strWhere += " and  ProductClassName in ('" + ProductClassName + "') ";
            }

            if (BrandName != "")
            {
                strWhere += " and  BrandName in ('" + BrandName + "') ";
            }
            if (SupplierName != "")
            {
                strWhere += " and  SupplierName in ('" + SupplierName + "') ";
            }
            string StoreNames = DNTRequest.GetString("StoreNames");
            if (StoreNames != "")
            {
                strWhere += " and (StoreName='" + StoreNames + "') ";
            }

            int count = 0;

            string sql = @"select ROW_NUMBER() OVER  (ORDER BY HHNo)  as KeyID , * from [" + DBName + @"].[dbo].[View_SelectStockReport_StockDetail_RptStmIODetail]  where  " + strWhere;
            DataSet ds = DataPageHelper.GetDataPage(DataPageHelper.GetPageSql(sql, page.Value, rows, "createDate desc"), out count);
            List<View_SelectStockReport_StockDetail_RptStmIODetail> list = TBToList<View_SelectStockReport_StockDetail_RptStmIODetail>.ConvertToList(ds.Tables[0]).ToList();
            var grid = new EasyuiDataGrid<List<View_SelectStockReport_StockDetail_RptStmIODetail>>();
            grid.total = count;
            grid.rows = list;
            return Json(grid, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region View_SelectStockReport_StockDetail_RptStmDaily
        public ActionResult RptStmDaily()
        {
            return View();
        }

        public ActionResult GetListView_SelectStockReport_StockDetail_RptStmDaily(int? page)
        {

            string KeyWord = DNTRequest.GetString("KeyWord");
            string ProductClassName = DNTRequest.GetString("ClassName");
            string BrandName = DNTRequest.GetString("BrandName");
            string SupplierName = DNTRequest.GetString("SupName");

            int rows = DNTRequest.GetInt("rows", 10);
            string strWhere = " 1=1 and StoreID in(" + StoreId + ") ";
            if (KeyWord != "")
            {
                strWhere += " and (ProductName like '%" + KeyWord + "%'  or HHNo like '%" + KeyWord + "%' ) ";
            }
            if (ProductClassName != "")
            {
                strWhere += " and  ProductClassName in ('" + ProductClassName + "') ";
            }

            if (BrandName != "")
            {
                strWhere += " and  BrandName in ('" + BrandName + "') ";
            }
            if (SupplierName != "")
            {
                strWhere += " and  SupplierName in ('" + SupplierName + "') ";
            }
            string StoreNames = DNTRequest.GetString("StoreNames");
            if (StoreNames != "")
            {
                strWhere += " and (StoreName='" + StoreNames + "') ";
            }
            int count = 0;

            string sql = @"select ROW_NUMBER() OVER  (ORDER BY HHNo)  as KeyID , * from [" + DBName + @"].[dbo].[View_SelectStockReport_StockDetail_RptStm_SUM]  where  " + strWhere;
            DataSet ds = DataPageHelper.GetDataPage(DataPageHelper.GetPageSql(sql, page.Value, rows, "HHNo desc"), out count);
            List<View_SelectStockReport_StockDetail_RptStmDaily> list = TBToList<View_SelectStockReport_StockDetail_RptStmDaily>.ConvertToList(ds.Tables[0]).ToList();
            var grid = new EasyuiDataGrid<List<View_SelectStockReport_StockDetail_RptStmDaily>>();
            grid.total = count;
            grid.rows = list;
            return Json(grid, JsonRequestBehavior.AllowGet);
        }


        //public ActionResult GetListView_SelectStockReport_StockDetail_RptStmDaily(int? page)
        //{
        //    string KeyWord = DNTRequest.GetString("KeyWord");

        //    int rows = DNTRequest.GetInt("rows", 10);
        //    string strWhere = " 1=1 ";
        //    if (KeyWord != "")
        //    {
        //        strWhere += " and (ProductName like '%" + KeyWord + "%'  or StoreName like '%" + KeyWord + "% ') ";
        //    }
        //    int count = 0;

        //    string sql = @"select ROW_NUMBER() OVER  (ORDER BY createdate)  as KeyID , * from [" + DBName + @"].[dbo].[View_SelectStockReport_StockDetail_RptStmDaily]  where  " + strWhere;
        //    DataSet ds = DataPageHelper.GetDataPage(DataPageHelper.GetPageSql(sql, page.Value, rows, "createdate desc"), out count);
        //    List<View_SelectStockReport_StockDetail_RptStmDaily> list = TBToList<View_SelectStockReport_StockDetail_RptStmDaily>.ConvertToList(ds.Tables[0]).ToList();
        //    var grid = new EasyuiDataGrid<List<View_SelectStockReport_StockDetail_RptStmDaily>>();
        //    grid.total = count;
        //    grid.rows = list;
        //    return Json(grid, JsonRequestBehavior.AllowGet);
        //}

        #endregion

     
        #region View_SelectStockReport_StockDetail_RptStmDaily
        public ActionResult RptStmMonthly()
        {
            return View();
        }
        public ActionResult GetListView_SelectStockReport_StockDetail_RptStmMonthly(int? page)
        {
            string KeyWord = DNTRequest.GetString("KeyWord");

            int rows = DNTRequest.GetInt("rows", 10);
            string strWhere = " 1=1 and StoreID in(" + StoreId + ") ";
            if (KeyWord != "")
            {
                strWhere += " and (ProductName like '%" + KeyWord + "%'  or StoreName like '%" + KeyWord + "% ') ";
            }
            int count = 0;

            string sql = @"select ROW_NUMBER() OVER  (ORDER BY HHNo)  as KeyID , * from [" + DBName + @"].[dbo].[View_SelectStockReport_StockDetail_RptStmMonthly]  where  " + strWhere;
            DataSet ds = DataPageHelper.GetDataPage(DataPageHelper.GetPageSql(sql, page.Value, rows, "createdate desc"), out count);
            List<View_SelectStockReport_StockDetail_RptStmDaily> list = TBToList<View_SelectStockReport_StockDetail_RptStmDaily>.ConvertToList(ds.Tables[0]).ToList();
            var grid = new EasyuiDataGrid<List<View_SelectStockReport_StockDetail_RptStmDaily>>();
            grid.total = count;
            grid.rows = list;
            return Json(grid, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region View_SelectStockReport_StocktransferDetail_RptStmDBItems
        public ActionResult RptStmDBItems()
        {
            return View();
        }

        public ActionResult GetListView_SelectStockReport_StocktransferDetail_RptStmDBItems(int? page)
        {
            string KeyWord = DNTRequest.GetString("KeyWord");

            int rows = DNTRequest.GetInt("rows", 10);
            string strWhere = " 1=1 and (INStoreID in(" + StoreId + ") or  outStoreID in(" + StoreId + "))";
            if (KeyWord != "")
            {
                strWhere += " and (ProductName like '%" + KeyWord + "%'  or StoreName like '%" + KeyWord + "% ') ";
            }
            int count = 0;

            string sql = @"select ROW_NUMBER() OVER  (ORDER BY HHNo)  as KeyID ,(OutNum*Price) AS SumPrice,(AcceptNum*AcceptPrice) AS AcceptSumPrice, * from [" + DBName + @"].[dbo].[View_SelectStockReport_StocktransferDetail_RptStmDBItems]  where  " + strWhere;
            DataSet ds = DataPageHelper.GetDataPage(DataPageHelper.GetPageSql(sql, page.Value, rows, "HHNo desc"), out count);
            List<View_SelectStockReport_StocktransferDetail_RptStmDBItems> list = TBToList<View_SelectStockReport_StocktransferDetail_RptStmDBItems>.ConvertToList(ds.Tables[0]).ToList();
            var grid = new EasyuiDataGrid<List<View_SelectStockReport_StocktransferDetail_RptStmDBItems>>();
            grid.total = count;
            grid.rows = list;
            return Json(grid, JsonRequestBehavior.AllowGet);
        }
        #endregion
    }
}
