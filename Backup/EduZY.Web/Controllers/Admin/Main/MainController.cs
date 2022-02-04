using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;

namespace EduZY.Web.Controllers.Admin.Main
{
    public class MainController : Base.BaseController
    {
        //
        // GET: /Main/

        public ActionResult Index()
        {

            ViewBag.DBName = DBName;
            System.Text.StringBuilder sbSales = new System.Text.StringBuilder();
            sbSales.Append(@"
                             SELECT  ISNULL(SUM(SumPrice),0) SumPrice FROM  [" + DBName + @"].[dbo].[View_SelectStockReport_StockDetail_RptStmIODetail]
                            where [StockType]='POS销售' and  datediff(day,CreateDate,getdate())=0  AND StoreID in(" + StoreId + @"); --今天


                            SELECT  ISNULL(SUM(SumPrice),0) SumPrice FROM  [" + DBName + @"].[dbo].[View_SelectStockReport_StockDetail_RptStmIODetail]
                            where [StockType]='POS销售' and  datediff(day,CreateDate,getdate())=1  AND StoreID in(" + StoreId + @");--昨天


                            SELECT   ISNULL(SUM(SumPrice),0) SumPrice  FROM  [" + DBName + @"].[dbo].[View_SelectStockReport_StockDetail_RptStmIODetail]
                            where [StockType]='POS销售' and  datediff(week,CreateDate,getdate())=0  AND StoreID in(" + StoreId + @");--本周

                            SELECT   ISNULL(SUM(SumPrice),0)  SumPrice FROM  [" + DBName + @"].[dbo].[View_SelectStockReport_StockDetail_RptStmIODetail]
                            where [StockType]='POS销售' and  datediff(month,CreateDate,getdate())=0  AND StoreID in(" + StoreId + @");--本月

                               
                            ");

            DataSet ds = Maticsoft.DBUtility.DbHelperSQL.Query(sbSales.ToString());
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                ViewBag.销售今天 = Convert.ToDecimal(dr["SumPrice"].ToString()).ToString("f2");
            }
            foreach (DataRow dr in ds.Tables[1].Rows)
            {
                ViewBag.销售昨天 = Convert.ToDecimal(dr["SumPrice"].ToString()).ToString("f2");
            }
            foreach (DataRow dr in ds.Tables[2].Rows)
            {
                ViewBag.销售本周 = Convert.ToDecimal(dr["SumPrice"].ToString()).ToString("f2");
            }
            foreach (DataRow dr in ds.Tables[3].Rows)
            {
                ViewBag.销售本月 = Convert.ToDecimal(dr["SumPrice"].ToString()).ToString("f2");
            }

            System.Text.StringBuilder sbML = new System.Text.StringBuilder();
            sbML.Append(@"
                             SELECT  ISNULL(SUM(GrossProfit),0) SumPrice FROM  [" + DBName + @"].[dbo].[View_SelectPosProductGrossProfitAnalyse2_tj]
                            where  datediff(day,SaleDateTime,getdate())=0  AND StoreID in(" + StoreId + @"); --今天


                            SELECT  ISNULL(SUM(GrossProfit),0) SumPrice FROM  [" + DBName + @"].[dbo].[View_SelectPosProductGrossProfitAnalyse2_tj]
                            where  datediff(day,SaleDateTime,getdate())=1  AND StoreID in(" + StoreId + @");--昨天


                            SELECT   ISNULL(SUM(GrossProfit),0) SumPrice  FROM  [" + DBName + @"].[dbo].[View_SelectPosProductGrossProfitAnalyse2_tj]
                            where  datediff(week,SaleDateTime,getdate())=0  AND StoreID in(" + StoreId + @");--本周

                            SELECT   ISNULL(SUM(GrossProfit),0)  SumPrice FROM  [" + DBName + @"].[dbo].[View_SelectPosProductGrossProfitAnalyse2_tj]
                            where  datediff(month,SaleDateTime,getdate())=0  AND StoreID in(" + StoreId + @");--本月

                               
                            ");

            DataSet ds1 = Maticsoft.DBUtility.DbHelperSQL.Query(sbML.ToString());
            foreach (DataRow dr in ds1.Tables[0].Rows)
            {
                ViewBag.毛利今天 = Convert.ToDecimal(dr["SumPrice"].ToString()).ToString("f2");
            }
            foreach (DataRow dr in ds1.Tables[1].Rows)
            {
                ViewBag.毛利昨天 = Convert.ToDecimal(dr["SumPrice"].ToString()).ToString("f2");
            }
            foreach (DataRow dr in ds1.Tables[2].Rows)
            {
                ViewBag.毛利本周 = Convert.ToDecimal(dr["SumPrice"].ToString()).ToString("f2");
            }
            foreach (DataRow dr in ds1.Tables[3].Rows)
            {
                ViewBag.毛利本月 = Convert.ToDecimal(dr["SumPrice"].ToString()).ToString("f2");
            }




            System.Text.StringBuilder sbstock = new System.Text.StringBuilder();
            sbstock.Append(@"
                            SELECT   ISNULL(SUM(SumPrice),0) SumPrice  FROM  [" + DBName + @"].[dbo].[View_SelectStockReport_StockRptStmCost_GroupBy]
                            where   StoreID in(" + StoreId + @");
                            ");

            DataSet ds3 = Maticsoft.DBUtility.DbHelperSQL.Query(sbstock.ToString());
            foreach (DataRow dr in ds3.Tables[0].Rows)
            {
                ViewBag.库存金额 = Convert.ToDecimal(dr["SumPrice"].ToString()).ToString("f2");
            }


            System.Text.StringBuilder sbCG = new System.Text.StringBuilder();
            sbCG.Append(@"
                       

                            SELECT   ISNULL(SUM(SumPrice),0) SumPrice  FROM  [" + DBName + @"].[dbo].[View_SelectPurchaseOrder_Sum]
                            where  Status='审核通过' AND  datediff(week,CreateDate,getdate())=0  AND StoreID in(" + StoreId + @");--本周

                            SELECT   ISNULL(SUM(SumPrice),0)  SumPrice FROM  [" + DBName + @"].[dbo].[View_SelectPurchaseOrder_Sum]
                            where  Status='审核通过' AND  datediff(month,CreateDate,getdate())=0  AND StoreID in(" + StoreId + @");--本月

                            SELECT   ISNULL(SUM(SumPrice),0)  SumPrice FROM  [" + DBName + @"].[dbo].[View_SelectPurchaseOrder_Sum]
                            where  Status='审核通过' AND  DateAdd(month,-3,getdate())<=CreateDate  AND StoreID in(" + StoreId + @");--本月
                            ");

            DataSet ds4 = Maticsoft.DBUtility.DbHelperSQL.Query(sbCG.ToString());
            foreach (DataRow dr in ds4.Tables[0].Rows)
            {
                ViewBag.采购本周 = Convert.ToDecimal(dr["SumPrice"].ToString()).ToString("f2");
            }

            foreach (DataRow dr in ds4.Tables[1].Rows)
            {
                ViewBag.采购本月 = Convert.ToDecimal(dr["SumPrice"].ToString()).ToString("f2");
            }
            foreach (DataRow dr in ds4.Tables[2].Rows)
            {
                ViewBag.最近三个月 = Convert.ToDecimal(dr["SumPrice"].ToString()).ToString("f2");
            }




            return View();
        }

    }
}
