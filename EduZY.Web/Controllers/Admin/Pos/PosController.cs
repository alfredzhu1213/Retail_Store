using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Entity;
using System.Text;
using Maticsoft.DBUtility;
using Common;
using Maticsoft.Model;
using System.Data;
using Base;
using Maticsoft.DAL;

namespace EduZY.Web.Controllers.Admin.Pos
{
     [SupportFilter]
    public class PosController : BaseController
    {
        #region tb_PosSaleMan
        public ActionResult SaleMan()
        {
            return View();
        }
        [HttpPost]
        public JsonResult GetCommonCodeSaleMan(int id)
        {
            string result = "";
            JsonModel jm = new JsonModel();
            object obj = DbHelperSQL.GetSingle("select count(code) from [" + DBName + @"].[dbo].[tb_PosSaleMan] ");
            if (obj != null)
            {
                if (Convert.ToInt32(obj) > 0)
                {
                    string next = (Convert.ToInt32(obj) + 1).ToString();
                    if (next.Length == 1)
                    {
                        result = "000" + next;
                    }
                    if (next.Length == 2)
                    {
                        result = "00" + next;
                    }
                    if (next.Length == 3)
                    {
                        result = "0" + next;
                    }

                }
                else
                {
                    result = "0001";
                }
            }

            jm.html = result;
            return Json(jm, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetListtb_PosSaleMan(int? page)
        {
            string KeyWord = DNTRequest.GetString("KeyWord");
          

            int rows = DNTRequest.GetInt("rows", 10);
            string strWhere = " 1=1 AND (StoreId in ("+StoreId+")) ";
            if (KeyWord != "")
            {
                strWhere += " and (Name like '%" + KeyWord + "%'  or code like '%" + KeyWord + "%'  ) ";
            }
            string StoreIds = DNTRequest.GetString("StoreIds");
            if (StoreIds != "")
            {
                strWhere += " and (StoreId='" + StoreIds + "') ";
            }

            int count = 0;

            string sql = @"select  * from [" + DBName + @"].[dbo].[tb_PosSaleMan]  where  " + strWhere;
            DataSet ds = DataPageHelper.GetDataPage(DataPageHelper.GetPageSql(sql, page.Value, rows, "id desc"), out count);
            List<tb_PosSaleMan> list = TBToList<tb_PosSaleMan>.ConvertToList(ds.Tables[0]).ToList();
            var grid = new EasyuiDataGrid<List<tb_PosSaleMan>>();
            grid.total = count;
            grid.rows = list;
            return Json(grid, JsonRequestBehavior.AllowGet);
        }



        public ActionResult savetb_PosSaleMan(tb_PosSaleMan model)
        {

            JsonModel jm = new JsonModel();
            try
            {
                Maticsoft.DAL.tb_PosSaleManDAL bll = new Maticsoft.DAL.tb_PosSaleManDAL(DBName);
                jm.status = 1;
                int id = DNTRequest.GetInt("id", 0);
                model.AddUserId = CurrentUserID;
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
        public ActionResult Deltb_PosSaleMan(int id)
        {

            JsonModel jm = new JsonModel();
            try
            {
                jm.status = 1;
                StringBuilder strSql = new StringBuilder();
                strSql.Append("delete from [" + DBName + @"].[dbo].tb_PosSaleMan ");
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
        #region tb_PosSaleSetting
        public ActionResult SaleSetting()
        {
            Maticsoft.Model.tb_PosSaleSetting model = new tb_PosSaleSetting();
            tb_PosSaleSettingDAL bll = new tb_PosSaleSettingDAL(DBName);
            model = bll.GetModel(1);
            return View(model);
        }



        public ActionResult savetb_PosSaleSetting(tb_PosSaleSetting model)
        {

            JsonModel jm = new JsonModel();
            try
            {
                Maticsoft.DAL.tb_PosSaleSettingDAL bll = new Maticsoft.DAL.tb_PosSaleSettingDAL(DBName);
                jm.status = 1;
                if (!bll.Exists(0))
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
        #region tb_PosClient
        public ActionResult PosClient()
        {
            return View();
        }

        public ActionResult GetListtb_PosClient(int? page)
        {
            string KeyWord = DNTRequest.GetString("KeyWord");

            int rows = DNTRequest.GetInt("rows", 10);
            string strWhere = " 1=1 ";
            if (KeyWord != "")
            {
                strWhere += " and (Name like '%" + KeyWord + "%'  or code like '%" + KeyWord + "%' or  StoreId in (SELECT  top 1 [id] FROM [" + DBName + @"].[dbo].[tb_Store] where  name like '%" + KeyWord + "%') ) ";
            }

            int count = 0;

            string sql = @"select  *, 
                  (SELECT  top 1 [name] FROM [" + DBName + @"].[dbo].[tb_Store] where  id=ps.StoreId) as StoreName,
                  (SELECT  top 1 [UserName] FROM  [UserMaster] where  UserID=ps.AddUserId) as AddUserName,
                   (SELECT  top 1 [UserName] FROM  [UserMaster] where  UserID=ps.UpdateUserId) as UpdateUserName
                     from [" + DBName + @"].[dbo].[tb_PosClient] as ps  where  " + strWhere;
            DataSet ds = DataPageHelper.GetDataPage(DataPageHelper.GetPageSql(sql, page.Value, rows, "id desc"), out count);
            List<tb_PosClient> list = TBToList<tb_PosClient>.ConvertToList(ds.Tables[0]).ToList();
            var grid = new EasyuiDataGrid<List<tb_PosClient>>();
            grid.total = count;
            grid.rows = list;
            return Json(grid, JsonRequestBehavior.AllowGet);
        }



        public ActionResult savetb_PosClient(tb_PosClient model)
        {

            JsonModel jm = new JsonModel();
            try
            {
                Maticsoft.DAL.tb_PosClientDAL bll = new Maticsoft.DAL.tb_PosClientDAL(DBName);
                jm.status = 1;
                int id = DNTRequest.GetInt("id", 0);

                if (id == 0)
                {
                    model.AddTime = DateTime.Now;
                    model.AddUserId = CurrentUserID;
                    bll.Add(model);
                    jm.status = 1;
                }
                else
                {
                    model.UpdateTime = DateTime.Now;
                    model.UpdateUserId = CurrentUserID;
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
        public ActionResult Deltb_PosClient(int id)
        {

            JsonModel jm = new JsonModel();
            try
            {
                jm.status = 1;
                StringBuilder strSql = new StringBuilder();
                strSql.Append("delete from [" + DBName + @"].[dbo].tb_PosClient ");
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

        #region tb_PosSaleGoodsTypeSummary
        public ActionResult RptSaleCategoriesSummary()
        {
            return View();
        }

        public ActionResult GetListtb_PosSaleGoodsTypeSummary(int? page)
        {
            string KeyWord = DNTRequest.GetString("KeyWord");

            int rows = DNTRequest.GetInt("rows", 10);
            string strWhere = " 1=1 and  StoreName in(" + StoreName + ")";
            if (KeyWord != "")
            {
                strWhere += " and (GoodsTypeCode like '%" + KeyWord + "%'  or StoreCode  like '%" + KeyWord + "%') ";
            }
            string StoreIds = DNTRequest.GetString("StoreIds");
            if (StoreIds != "")
            {
                strWhere += " and (StoreId='" + StoreIds + "') ";
            }
            string ClassName = DNTRequest.GetString("ClassName");
            if (ClassName != "")
            {
                strWhere += " and (GoodsTypeName like '%" + ClassName + "%' ) ";
            }
            int count = 0;

            string sql = @"select ROW_NUMBER() OVER   (ORDER BY StoreCode)  as id, *,([SaleCount]+ReturnCount) as CountSubtotal   ,([SaleAccount]+[ReturnAccount]) as AccountSubtotal
                           from [" + DBName + @"].[dbo].[View_SelectPos_ProductClass1]  where  " + strWhere;
            DataSet ds = DataPageHelper.GetDataPage(DataPageHelper.GetPageSql(sql, page.Value, rows, "id desc"), out count);
            List<tb_PosSaleGoodsTypeSummary> list = TBToList<tb_PosSaleGoodsTypeSummary>.ConvertToList(ds.Tables[0]).ToList();
            var grid = new EasyuiDataGrid<List<tb_PosSaleGoodsTypeSummary>>();
            grid.total = count;
            grid.rows = list;
            return Json(grid, JsonRequestBehavior.AllowGet);
        }
        #endregion
        #region tb_PosSaleJournal
        public ActionResult RptSaleFlow()
        {
            return View();
        }

        public ActionResult GetListtb_PosSaleJournal(int? page)
        { 

            string YYName = DNTRequest.GetString("YYName");
            string SYName = DNTRequest.GetString("SYName");
            string ClassName = DNTRequest.GetString("ClassName");
            string KeyWord = DNTRequest.GetString("KeyWord");
            int rows = DNTRequest.GetInt("rows", 10);
            string strWhere = " 1=1 AND StoreID in(" + StoreId + ") ";
            if (KeyWord != "")
            {
                strWhere += " and (BillNo like '%" + KeyWord + "%'  or StoreCode like '%" + KeyWord + "%' or HHNo like '%" + KeyWord + "%' or GoodsName like '%" + KeyWord + "%' ) ";
            }
            if (YYName != "")
            {
                strWhere += " and (YYerName like '%" + YYName + "%' ) ";
            }
            if (SYName != "")
            {
                strWhere += " and (SYerName  like '%" + SYName + "%' ) ";
            }
            if (ClassName != "")
            {
                strWhere += " and (GoodsTypeName like '%" + ClassName + "%' ) ";
            }
            string StoreIds = DNTRequest.GetString("StoreIds");
            if (StoreIds != "")
            {
                strWhere += " and (StoreId='" + StoreIds + "') ";
            }

            string StartDate = DNTRequest.GetString("StartDate");
            string EndDate = DNTRequest.GetString("EndDate");

            if (StartDate != "")
            {

                if (EndDate != "")
                {

                    strWhere += " and SaleDateTime between '" + StartDate + " 00:00:00' and '" + EndDate + " 23:59:59'";
                }
                else
                {
                    strWhere += " and SaleDateTime between '" + StartDate + " 00:00:00' and '" + System.DateTime.Now.ToShortDateString() + " 23:59:59'";
                }
            }

            int count = 0;

            string sql = @"select  *  from [" + DBName + @"].[dbo].[tb_PosSaleJournal] AS PSJ where  " + strWhere;
            DataSet ds = DataPageHelper.GetDataPage(DataPageHelper.GetPageSql(sql, page.Value, rows, "id desc"), out count);
            List<tb_PosSaleJournal> list = TBToList<tb_PosSaleJournal>.ConvertToList(ds.Tables[0]).ToList();
            var grid = new EasyuiDataGrid<List<tb_PosSaleJournal>>();
            grid.total = count;
            grid.rows = list;
            return Json(grid, JsonRequestBehavior.AllowGet);
        }


        #endregion
        #region tb_PosCashJournal
        public ActionResult RptSaleDaily()
        {
            return View();
        }

        public ActionResult GetListtb_PosCashJournal(int? page)
        {
            string KeyWord = DNTRequest.GetString("KeyWord");

            int rows = DNTRequest.GetInt("rows", 10);
            string strWhere = " 1=1 and  StoreName in(" + StoreName + ")";
            if (KeyWord != "")
            {
                strWhere += " and (BillNo like '%" + KeyWord + "%'  or StoreName like '%" + KeyWord + "% ') ";
            }

            string SYName = DNTRequest.GetString("SYName");
            if (SYName != "")
            {
                strWhere += " and (SYerName  like '%" + SYName + "%' ) ";
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

                    strWhere += " and SYDateTime between '" + StartDate + " 00:00:00' and '" + EndDate + " 23:59:59'";
                }
                else
                {
                    strWhere += " and SYDateTime between '" + StartDate + " 00:00:00' and '" + System.DateTime.Now.ToShortDateString() + " 23:59:59'";
                }
            }

            int count = 0;

            string sql = @"select  ROW_NUMBER() OVER     (ORDER BY id)  as id,  StoreName, BillNo, SYDateTime, TradeType, BillAccount, PaymentMode, PaymentAccount, ReturnOriginalNo, SYerName


                                from [" + DBName + @"].[dbo].[tb_PosCashJournal]  where  " + strWhere;



            DataSet ds = DataPageHelper.GetDataPage(DataPageHelper.GetPageSql(sql, page.Value, rows, "id desc"), out count);
            List<tb_PosCashJournal> list = TBToList<tb_PosCashJournal>.ConvertToList(ds.Tables[0]).ToList();
            var grid = new EasyuiDataGrid<List<tb_PosCashJournal>>();
            grid.total = count;
            grid.rows = list;
            return Json(grid, JsonRequestBehavior.AllowGet);
        }

        #endregion
        #region tb_PosSaleDaySummary
        public ActionResult RptSalePayFlow()
        {
            return View();
        }

        public ActionResult GetListtb_PosSaleDaySummary(int? page)
        {
            string KeyWord = DNTRequest.GetString("KeyWord");

            int rows = DNTRequest.GetInt("rows", 10);
            string strWhere = " 1=1 AND  StoreID in(" + StoreId + ") ";
            if (KeyWord != "")
            {
                strWhere += " and (HHNo like '%" + KeyWord + "%'  or GoodsName like '%" + KeyWord + "%') ";
            }
     
         
            string StoreIds = DNTRequest.GetString("StoreIds");
            if (StoreIds != "")
            {
                strWhere += " and (StoreId='" + StoreIds + "') ";
            }

            string StartDate = DNTRequest.GetString("StartDate");
            string EndDate = DNTRequest.GetString("EndDate");

            if (StartDate != "")
            {

                if (EndDate != "")
                {

                    strWhere += " and S_DateTime between '" + StartDate + " 00:00:00' and '" + EndDate + " 23:59:59'";
                }
                else
                {
                    strWhere += " and S_DateTime between '" + StartDate + " 00:00:00' and '" + System.DateTime.Now.ToShortDateString() + " 23:59:59'";
                }
            }


            int count = 0;

            string sql = @"select  ROW_NUMBER() OVER   (ORDER BY StoreCode)  as id,[S_DateTime]
                                      ,[StoreCode]
                                      ,[StoreName]
                                      ,[SaleCount]
                                      ,[SaleAccount]
                                      ,[TradeType]
                                      ,[GoodsID]
                                      ,[GoodsName]
                                      ,[HHNo]
                                      ,[ReturnCount]
                                      ,[ReturnAccount]
                                      ,(Select GG from [" + DBName + @"].[dbo].tb_Product where id=tb.GoodsID) as GG
                                      ,(Select Unit from [" + DBName + @"].[dbo].tb_Product where id=tb.GoodsID) as Unit
                                      ,([SaleCount]+ReturnCount) as CountSubtotal   ,([SaleAccount]+[ReturnAccount]) as AccountSubtotal

                                from [" + DBName + @"].[dbo].[View_SelectPos_ProductDay1] as tb  where  " + strWhere;


            DataSet ds = DataPageHelper.GetDataPage(DataPageHelper.GetPageSql(sql, page.Value, rows, "id desc"), out count);
            List<tb_PosSaleDaySummary> list = TBToList<tb_PosSaleDaySummary>.ConvertToList(ds.Tables[0]).ToList();
            var grid = new EasyuiDataGrid<List<tb_PosSaleDaySummary>>();
            grid.total = count;
            grid.rows = list;
            return Json(grid, JsonRequestBehavior.AllowGet);
        }

       #endregion
        #region tb_PosSaleMonthSummary
        public ActionResult RptSaleMonthly()
        {
            return View();
        }

        public ActionResult GetListtb_PosSaleMonthSummary(int? page)
        {
            string KeyWord = DNTRequest.GetString("KeyWord");

               int rows = DNTRequest.GetInt("rows", 10);
               string strWhere = " 1=1  AND  tb.StoreID in(" + StoreId + ")";
            if (KeyWord != "")
            {
                strWhere += " and (HHNo like '%" + KeyWord + "%'  or GoodsName like '%" + KeyWord + "%') ";
            }
            string StoreIds = DNTRequest.GetString("StoreIds");
            if (StoreIds != "")
            {
                strWhere += " and (StoreId='" + StoreIds + "') ";
            }

            string StartDate = DNTRequest.GetString("StartDate");
            string EndDate = DNTRequest.GetString("EndDate");

            if (StartDate != "")
            {

                if (EndDate != "")
                {

                    strWhere += " and S_DateTime between '" + StartDate + " 00:00:00' and '" + EndDate + " 23:59:59'";
                }
                else
                {
                    strWhere += " and S_DateTime between '" + StartDate + " 00:00:00' and '" + System.DateTime.Now.ToShortDateString() + " 23:59:59'";
                }
            }

            int count = 0;

            string sql = @"select  ROW_NUMBER() OVER   (ORDER BY StoreCode)  as id,[S_DateTime]
                                      ,[StoreCode]
                                      ,[StoreName]
                                      ,[SaleCount]
                                      ,[SaleAccount]
                                      ,[TradeType]
                                      ,[GoodsID]
                                      ,[GoodsName]
                                      ,[HHNo]
                                      ,[ReturnCount]
                                      ,[ReturnAccount]
                                      ,(Select GG from [" + DBName + @"].[dbo].tb_Product where id=tb.GoodsID) as GG
                                      ,(Select Unit from [" + DBName + @"].[dbo].tb_Product where id=tb.GoodsID) as Unit
                                      ,([SaleCount]+ReturnCount) as CountSubtotal   ,([SaleAccount]+[ReturnAccount]) as AccountSubtotal

                                from [" + DBName + @"].[dbo].[View_SelectPos_ProductMonth1] as tb  where  " + strWhere;

            DataSet ds = DataPageHelper.GetDataPage(DataPageHelper.GetPageSql(sql, page.Value, rows, "id desc"), out count);
            List<tb_PosSaleMonthSummary> list = TBToList<tb_PosSaleMonthSummary>.ConvertToList(ds.Tables[0]).ToList();
            var grid = new EasyuiDataGrid<List<tb_PosSaleMonthSummary>>();
            grid.total = count;
            grid.rows = list;
            return Json(grid, JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region tb_PosSaleBrandSummary
        public ActionResult RptSaleBrandsSummary()
        {
            return View();
        }

        public ActionResult GetListtb_PosSaleBrandSummary(int? page)
        {
            string KeyWord = DNTRequest.GetString("KeyWord");

            int rows = DNTRequest.GetInt("rows", 10);
            string strWhere = " 1=1  AND  StoreID in(" + StoreId + ") ";
            if (KeyWord != "")
            {
                strWhere += " and (brandName like '%" + KeyWord + "%'  or brandCode like '%" + KeyWord + "%') ";
            }
            string StoreIds = DNTRequest.GetString("StoreIds");
            if (StoreIds != "")
            {
                strWhere += " and (StoreId='" + StoreIds + "') ";
            }
            int count = 0;

            string sql = @"SELECT ROW_NUMBER() OVER   (ORDER BY StoreCode)  as id,[StoreCode]
                              ,[StoreName]
                              ,[brandName]
                              ,[SaleCount]
                              ,[SaleAccount]
                              ,[ReturnCount]
                              ,[ReturnAccount]
                              ,[brandCode]
                              ,([SaleCount]+ReturnCount) as CountSubtotal  
                               ,([SaleAccount]+[ReturnAccount]) as AccountSubtotal  from [" + DBName + @"].[dbo].[View_SelectPos_ProductBrand1]  where  " + strWhere;
            DataSet ds = DataPageHelper.GetDataPage(DataPageHelper.GetPageSql(sql, page.Value, rows, "id desc"), out count);
            List<tb_PosSaleBrandSummary> list = TBToList<tb_PosSaleBrandSummary>.ConvertToList(ds.Tables[0]).ToList();
            var grid = new EasyuiDataGrid<List<tb_PosSaleBrandSummary>>();
            grid.total = count;
            grid.rows = list;
            return Json(grid, JsonRequestBehavior.AllowGet);
        }



       
        #endregion

        #region tb_PosSaleGrossProfitAnalyse
        public ActionResult RptSaleGrossAnalysis()
        {
            return View();
        }

        public ActionResult GetListtb_PosSaleGrossProfitAnalyse(int? page)
        {
            string KeyWord = DNTRequest.GetString("KeyWord");

            int rows = DNTRequest.GetInt("rows", 10);
            string strWhere = " 1=1  AND  StoreID in(" + StoreId + ") ";
            if (KeyWord != "")
            {
                strWhere += " and (GoodsName like '%" + KeyWord + "%'  or HHNo like '%" + KeyWord + "%') ";
            }
            string ClassName = DNTRequest.GetString("ClassName");

            if (ClassName != "")
            {
                strWhere += " and (GoodsTypeName like '%" + ClassName + "%' ) ";
            }
            string StoreIds = DNTRequest.GetString("StoreIds");
            if (StoreIds != "")
            {
                strWhere += " and (StoreId='" + StoreIds + "') ";
            }
         
            int count = 0;

            string sql = @"select  [GoodsID]
                                  ,[StoreCode]
                                  ,[StoreName]
                                  ,[GoodsName]
                                  ,[GG]
                                  ,[GrossProfitRate]
                                  ,[GrossProfit]
                                  ,[SalePrice]
                                  ,[CostPrice]
                                  ,[StockNum]
                                  ,[SaleAccount]
                                  ,[SaleCount]
                                  ,[Unit]
                                  ,[HHNo]
                                  ,[BrandName]
                                  ,[SupplierName]
                                  ,[GoodsTypeName],SaleCostPrice from [" + DBName + @"].[dbo].[View_SelectPosProductGrossProfitAnalyse2]  where  " + strWhere+"";
            DataSet ds = DataPageHelper.GetDataPage(DataPageHelper.GetPageSql(sql, page.Value, rows, "GoodsID desc"), out count);
            List<tb_PosSaleGrossProfitAnalyse> list = TBToList<tb_PosSaleGrossProfitAnalyse>.ConvertToList(ds.Tables[0]).ToList();
            var grid = new EasyuiDataGrid<List<tb_PosSaleGrossProfitAnalyse>>();
            grid.total = count;
            grid.rows = list;
            return Json(grid, JsonRequestBehavior.AllowGet);
        }



      
        #endregion

        #region tb_PosSaleSyerTC
        public ActionResult RptSaleManAmt()
        {
            return View();
        }

        public ActionResult GetListtb_PosSaleSyerTC(int? page)
        {
            string KeyWord = DNTRequest.GetString("KeyWord");

            int rows = DNTRequest.GetInt("rows", 10);
            string strWhere = " 1=1   AND  StoreID in(" + StoreId + ")  ";
            if (KeyWord != "")
            {
                strWhere += " and (YYerCode like '%" + KeyWord + "%'  or YYerName like '%" + KeyWord + "%') ";
            }

            string StoreIds = DNTRequest.GetString("StoreIds");
            if (StoreIds != "")
            {
                strWhere += " and (StoreId='" + StoreIds + "') ";
            }

            int count = 0;

            string sql = @"select ROW_NUMBER() OVER   (ORDER BY YYerCode)  as id,[YYerCode]
                                  ,[YYerName]
                                  ,[StoreName]
                                  ,SUM([SaleAccount]) SaleAccount
                                  ,SUM(TCAccount)  [TCAccount]
                            from [" + DBName + @"].[dbo].[View_SelectPos_ProductTCDetail1]  where  " + strWhere + "  and TCAccount>0  group by [YYerCode],[YYerName] ,[StoreName]";
            DataSet ds = DataPageHelper.GetDataPage(DataPageHelper.GetPageSql(sql, page.Value, rows, "id desc"), out count);
            List<tb_PosSaleSyerTC> list = TBToList<tb_PosSaleSyerTC>.ConvertToList(ds.Tables[0]).ToList();
            var grid = new EasyuiDataGrid<List<tb_PosSaleSyerTC>>();
            grid.total = count;
            grid.rows = list;
            return Json(grid, JsonRequestBehavior.AllowGet);
        }
       
        #endregion


        #region tb_PosSaleSyerTCDetail
        public ActionResult RptSalesmanCommission()
        {
            return View();
        }

        public ActionResult GetListtb_PosSaleSyerTCDetail(int? page)
        {
            string KeyWord = DNTRequest.GetString("KeyWord");

            int rows = DNTRequest.GetInt("rows", 10);
            string strWhere = " 1=1   AND  StoreID in(" + StoreId + ") ";
            if (KeyWord != "")
            {
                strWhere += " and (YYerCode like '%" + KeyWord + "%'  or YYerName like '%" + KeyWord + "%' or HHNo like '%" + KeyWord + "%') ";
            }

            string YYName = DNTRequest.GetString("YYName");
            string SYName = DNTRequest.GetString("SYName");

            if (YYName != "")
            {
                strWhere += " and (YYerName like '%" + YYName + "%' ) ";
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

                    strWhere += " and SaleDateTime between '" + StartDate + " 00:00:00' and '" + EndDate + " 23:59:59'";
                }
                else
                {
                    strWhere += " and SaleDateTime between '" + StartDate + " 00:00:00' and '" + System.DateTime.Now.ToShortDateString() + " 23:59:59'";
                }
            }
            int count = 0;
            string sql = @"select   ROW_NUMBER() OVER   (ORDER BY StoreCode)  as id,* from [" + DBName + @"].[dbo].[View_SelectPos_ProductTCDetail1]  where TCAccount>0 AND  " + strWhere;
            DataSet ds = DataPageHelper.GetDataPage(DataPageHelper.GetPageSql(sql, page.Value, rows, "id desc"), out count);
            List<tb_PosSaleSyerTCDetail> list = TBToList<tb_PosSaleSyerTCDetail>.ConvertToList(ds.Tables[0]).ToList();
            var grid = new EasyuiDataGrid<List<tb_PosSaleSyerTCDetail>>();
            grid.total = count;
            grid.rows = list;
            return Json(grid, JsonRequestBehavior.AllowGet);
        }
        #endregion
        
    }
}
