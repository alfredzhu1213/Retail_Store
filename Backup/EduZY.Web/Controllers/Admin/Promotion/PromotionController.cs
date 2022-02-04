using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Base;
using Common;
using System.Data;
using Maticsoft.Model;
using Entity;
using System.Text;
using Maticsoft.DBUtility;
using Maticsoft.DAL;
using System.Web.Script.Serialization;

namespace EduZY.Web.Controllers.Admin.Promotion
{
    [SupportFilter]
    public class PromotionController : BaseController
    {

        #region tb_PromotionPlanSheet
        public ActionResult PromotionPlanSheetList()
        {
            return View();
        }
       

        public ActionResult GetListtb_PromotionPlanSheet(int? page)
        {
            string KeyWord = DNTRequest.GetString("KeyWord");

            int rows = DNTRequest.GetInt("rows", 10);
            string strWhere = " 1=1 ";
            if (KeyWord != "")
            {
                strWhere += " and (Title like '%" + KeyWord + "%') ";
            }
            int count = 0;

            string sql = @"select (select name from  [" + DBName + @"].[dbo].tb_Store where id=pps.StoreId) as StoreName,* from [" + DBName + @"].[dbo].[tb_PromotionPlanSheet] as pps  where  " + strWhere;
            DataSet ds = DataPageHelper.GetDataPage(DataPageHelper.GetPageSql(sql, page.Value, rows, "id desc"), out count);
            List<tb_PromotionPlanSheet> list = TBToList<tb_PromotionPlanSheet>.ConvertToList(ds.Tables[0]).ToList();
            var grid = new EasyuiDataGrid<List<tb_PromotionPlanSheet>>();
            grid.total = count;
            grid.rows = list;
            return Json(grid, JsonRequestBehavior.AllowGet);
        }



        public ActionResult savetb_PromotionPlanSheet(tb_PromotionPlanSheet model)
        {
            JsonModel jm = new JsonModel();
            try
            {
                Maticsoft.DAL.tb_PromotionPlanSheetDAL bll = new Maticsoft.DAL.tb_PromotionPlanSheetDAL(DBName);
                jm.status = 1;

                model.Status ="未审核";
                if (model.id == 0)
                {
                    int pid = bll.Add(model);
                    JavaScriptSerializer _JavaScriptSerializer = new JavaScriptSerializer();
                    var lists = _JavaScriptSerializer.Deserialize<List<tb_PromotionPlanSheetDetail>>(model.JsonString);
                    foreach (var item in lists)
                    {
                        if (item.DeleteFlag == false)
                        {
                            Maticsoft.DAL.tb_PromotionPlanSheetDetailDAL bll1 = new Maticsoft.DAL.tb_PromotionPlanSheetDetailDAL(DBName);
                            item.ppsdId = pid;
                            bll1.Add(item);
                        }
                    }

                    jm.status = pid;
                }
                else
                {
                    bll.Update(model);
                    StringBuilder strSql = new StringBuilder();
                    strSql.Append("delete from [" + DBName + @"].[dbo].tb_PromotionPlanSheetDetail ");
                    strSql.Append(" where ppsdId=" + model.id + "");
                    DbHelperSQL.ExecuteSql(strSql.ToString());

                    JavaScriptSerializer _JavaScriptSerializer = new JavaScriptSerializer();
                    var lists = _JavaScriptSerializer.Deserialize<List<tb_PromotionPlanSheetDetail>>(model.JsonString);
                    foreach (var item in lists)
                    {
                        if (item.DeleteFlag == false)
                        {
                            Maticsoft.DAL.tb_PromotionPlanSheetDetailDAL bll1 = new Maticsoft.DAL.tb_PromotionPlanSheetDetailDAL(DBName);
                            item.ppsdId = model.id;
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
        public ActionResult savetb_PromotionOrderStatus(int id, string status)
        {
            JsonModel jm = new JsonModel();
            jm.status = 1;

            StringBuilder strSql = new StringBuilder();
            strSql.Append(" update  [" + DBName + @"].[dbo].tb_PromotionPlanSheet set Status='" + status + "',ApprUserName='" + CurrentUserName + "',AppDate=Getdate() ");
            strSql.Append(" where id='" + id + "'");
            DbHelperSQL.ExecuteSql(strSql.ToString());
            return Json(jm, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Deltb_PromotionPlanSheet(int id)
        {

            JsonModel jm = new JsonModel();
            try
            {
                jm.status = 1;
                StringBuilder strSql = new StringBuilder();

                strSql.Append("delete from [" + DBName + @"].[dbo].tb_PromotionPlanSheetDetail ");
                strSql.Append(" where ppsdId=" + id + " ;");

                strSql.Append("delete from [" + DBName + @"].[dbo].tb_PromotionPlanSheet ");
                strSql.Append(" where id=" + id + "");
                DbHelperSQL.ExecuteSql(strSql.ToString());

            }
            catch (Exception ex)
            {
                jm.status = 0; jm.msg = ex.Message;
            }
            return Json(jm, JsonRequestBehavior.AllowGet);
        }

  
        public ActionResult PromotionPlanSheetAddOrEdit(int? id)
        {
            Maticsoft.Model.tb_PromotionPlanSheet model = new tb_PromotionPlanSheet();
            tb_PromotionPlanSheetDAL bll = new tb_PromotionPlanSheetDAL(DBName);
            if (id > 0)
            {
                model = bll.GetModel(Convert.ToInt32(id));
                model.StoreName = DbHelperSQL.GetSingle("select name from  [" + DBName + @"].[dbo].tb_Store where id='" + model.StoreId + "'") + "";

            }
            else
            {
                model.SerialNum = "CG" + DateTime.Now.ToString("yyyyMMddHHmmss") + ServerInfo.GetBack_Str("SerialNum", "  [" + DBName + @"].dbo.tb_PromotionPlanSheet ", " CONVERT(varchar(10), CreateDate, 120 )=CONVERT(varchar(10),getdate(),120) order by CreateDate DESC");
      
                model.CreateDate = DateTime.Now;
                model.CreateUserName = CurrentUserName;
            }
            string sql = @"select * from [" + DBName + @"].[dbo].[tb_PromotionPlanSheetDetail]  where ppsdId='" + id + "' ";
            DataSet ds = DbHelperSQL.Query(sql); ;
            List<tb_PromotionPlanSheetDetail> list = TBToList<tb_PromotionPlanSheetDetail>.ConvertToList(ds.Tables[0]).ToList();
            ViewBag.list = list;
            return View(model);
        }
        #endregion


        #region View_SelectChuxiaoList
        public ActionResult PromotionQuery()
        {
            return View();
        }

        public ActionResult GetListView_SelectChuxiaoList(int? page)
        {
            string KeyWord = DNTRequest.GetString("KeyWord");

            int rows = DNTRequest.GetInt("rows", 10);
            string strWhere = " 1=1 ";
            if (KeyWord != "")
            {
                strWhere += " and (Name like '%" + KeyWord + "%'  or code like '%" + KeyWord + "% ') ";
            }
            int count = 0;

            string sql = @"select  * from [" + DBName + @"].[dbo].[View_SelectChuxiaoList]  where  " + strWhere;
            DataSet ds = DataPageHelper.GetDataPage(DataPageHelper.GetPageSql(sql, page.Value, rows, "id desc"), out count);
            List<View_SelectChuxiaoList> list = TBToList<View_SelectChuxiaoList>.ConvertToList(ds.Tables[0]).ToList();
            var grid = new EasyuiDataGrid<List<View_SelectChuxiaoList>>();
            grid.total = count;
            grid.rows = list;
            return Json(grid, JsonRequestBehavior.AllowGet);
        }



        
        #endregion

        public ActionResult RptPromotionSaleDetail()
        {
            return View();
        }
        public ActionResult RptPromotionSale()
        {
            return View();
        }

        #region tb_PromotionSaleSummary

        public ActionResult GetListtb_PromotionSaleSummary(int? page)
        {
            string KeyWord = DNTRequest.GetString("KeyWord");

            int rows = DNTRequest.GetInt("rows", 10);
            string strWhere = " 1=1 ";
            if (KeyWord != "")
            {
                strWhere += " and (Name like '%" + KeyWord + "%'  or code like '%" + KeyWord + "% ') ";
            }
            int count = 0;

            string sql = @"select  * from [" + DBName + @"].[dbo].[tb_PromotionSaleSummary]  where  " + strWhere;
            DataSet ds = DataPageHelper.GetDataPage(DataPageHelper.GetPageSql(sql, page.Value, rows, "id desc"), out count);
            List<tb_PromotionSaleSummary> list = TBToList<tb_PromotionSaleSummary>.ConvertToList(ds.Tables[0]).ToList();
            var grid = new EasyuiDataGrid<List<tb_PromotionSaleSummary>>();
            grid.total = count;
            grid.rows = list;
            return Json(grid, JsonRequestBehavior.AllowGet);
        }


        #endregion


        #region tb_PromotionSaleDetail
        public ActionResult tb_PromotionSaleDetailList()
        {
            return View();
        }

        public ActionResult GetListtb_PromotionSaleDetail(int? page)
        {
            string KeyWord = DNTRequest.GetString("KeyWord");

            int rows = DNTRequest.GetInt("rows", 10);
            string strWhere = " 1=1 ";
            if (KeyWord != "")
            {
                strWhere += " and (Name like '%" + KeyWord + "%'  or code like '%" + KeyWord + "% ') ";
            }
            int count = 0;

            string sql = @"select  * from [" + DBName + @"].[dbo].[tb_PromotionSaleDetail]  where  " + strWhere;
            DataSet ds = DataPageHelper.GetDataPage(DataPageHelper.GetPageSql(sql, page.Value, rows, "id desc"), out count);
            List<tb_PromotionSaleDetail> list = TBToList<tb_PromotionSaleDetail>.ConvertToList(ds.Tables[0]).ToList();
            var grid = new EasyuiDataGrid<List<tb_PromotionSaleDetail>>();
            grid.total = count;
            grid.rows = list;
            return Json(grid, JsonRequestBehavior.AllowGet);
        }

        #endregion
    }
}
