using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using Entity;
using Common;
using System.Data;
using System.Text;
using Base;
using Maticsoft.DBUtility;

namespace EduZY.Web.Controllers.Admin
{
    [SupportFilter]
    public class ExportController : BaseController
    {
        #region 产品导入导出
        public ActionResult ProductExport()
        {
            return View();
        }
        /// <summary>
        /// 产品导入
        /// </summary>
        /// <param name="fileData"></param>
        /// <param name="directory"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult ExcelImportProduct(HttpPostedFileBase fileData, string directory)
        {
            JsonModel result = new JsonModel();
            DataTable dt = GetExportDatable(fileData, directory);
            if (dt.Rows.Count > 0)
            {
                Maticsoft.DAL.tb_ProductDAL bll = new Maticsoft.DAL.tb_ProductDAL(DBName);
                int i = 0;
                foreach (DataRow dr in dt.Rows)
                {
                    Maticsoft.Model.tb_Product model = new Maticsoft.Model.tb_Product();
                    try
                    {
                        string HHNo = dr["货号"].ToString();
                        string ProductName = dr["品名"].ToString();
                        string GG = dr["规格"].ToString();
                        string Unit = dr["单位"].ToString();
                        string 类别 = dr["类别"].ToString();
                        string 品牌 = dr["品牌"].ToString();
                        string jinPrice = dr["进货价"].ToString();
                        string SalesPrice = dr["零售价"].ToString();
                        string MemberPrice = dr["会员价"].ToString();
                        string MinPrice = dr["最低售价"].ToString();
                        string 品牌编码 = dr["品牌编码"].ToString();
                        string 类别编码 = dr["类别编码"].ToString();

                        int StockNum = 0;
                        string goodscode = HHNo;
                        int ClassId = 0;
                        int BrandId = 0;
                        try
                        {
                            StockNum = Convert.ToInt32(dr["初始库存"].ToString());
                  
                        }
                        catch { }
                        try
                        {
                          
                            ClassId = int.Parse(DbHelperSQL.GetSingle("SELECT [id] FROM [" + DBName + @"].[dbo].[tb_ProductType] where Code='" + 类别编码 + "'").ToString());
                        }
                        catch { }
                        try
                        {
                            BrandId = int.Parse(DbHelperSQL.GetSingle("SELECT [id] FROM [" + DBName + @"].[dbo].[tb_ProductBrand] where Code='" + 品牌编码 + "' ").ToString());
                        }
                        catch { }

                        DateTime AddTime = DateTime.Now;
                        model.ProductName = ProductName;
                        model.goodscode = goodscode;
                        model.HHNo = HHNo;
                        model.GG = GG;
                        model.Unit = Unit;
                        model.StockNum = StockNum;
                        model.MemberPrice = Convert.ToDecimal(MemberPrice);
                        model.jinPrice = Convert.ToDecimal(MemberPrice); ;
                        model.SalesPrice = Convert.ToDecimal(SalesPrice); ;
                        model.MinPrice = Convert.ToDecimal(MinPrice); ;
                        model.ClassId = ClassId;
                        model.BrandId = BrandId;
                        model.ProductStatus = "正常";
                        model.TJWay = "不提成";
                        model.JJWay = "普通";
                        if (BrandId > 0)
                        {
                            model.BrandCode = 品牌编码;
                        }
                        if (ClassId > 0)
                        {
                            model.ClassCode = 类别编码;
                        }

                        object obj = DbHelperSQL.GetSingle(@" DECLARE @RC int
                                                 DECLARE @strName nvarchar(500)
                                                 DECLARE @ReturnStr nvarchar(500)
                                                 EXECUTE @RC = [dbo].[pGet_ZJM]  '" + model.ProductName + @"',@ReturnStr OUTPUT ; SELECT @ReturnStr");
                        if (obj != null)
                        {
                            model.ProductJJ = obj.ToString();
                        }

                    
                      
                        try
                        {
                            int ReturnValue = bll.Add(model);
                            if (ReturnValue > 0)
                            {
                                i++;
                            }

                        }
                        catch { }

                    }
                    catch
                    {
                        result.status = 0;
                        result.count = 0;
                        return Json(result, JsonRequestBehavior.AllowGet);
                    }
                }

                result.status = 1;
                result.count = i;
            }
            else
            {
                result.status = 0;
                result.count = 0;
            }
            return Json(result, JsonRequestBehavior.AllowGet);

        }

        //导出
        public FileResult ExcelImportProductOut()
        {
            JsonModel result = new JsonModel();
            string sql = @"select * from [" + DBName + @"].[dbo].[View_SelectProduct_ExcelExportOut]   ";
            DataSet ds = DbHelperSQL.Query(sql); ;
            //导出数据
            string temppath = Server.MapPath("\\UpFile");
            string filepath = temppath + "\\ExportExcel\\商品导出模板.xls";//临时文件,也作为模板文件
            string downUrl = "\\ExcelOut\\" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xls";//导出文件路径
            string outfilepath = temppath + downUrl;//导出文件路径
            AsposeExcel asposeexcel = new AsposeExcel(outfilepath, filepath);
            asposeexcel.DatatableToExcel(ds.Tables[0]);
            return DownFile("\\UpFile" + downUrl, DateTime.Now.ToString("yyyyMMdd") + "商品导出列表.xls");

        }

        #endregion

        #region 会员导入导出

        public ActionResult MemberExport()
        {
            return View();
        }

        [HttpPost]
        public ActionResult MemberExcelExport(HttpPostedFileBase fileData, string directory)
        {
            JsonModel result = new JsonModel();
            DataTable dt = GetExportDatable(fileData, directory);
            if (dt.Rows.Count > 0)
            {
                Maticsoft.DAL.tb_MemberDAL bll = new Maticsoft.DAL.tb_MemberDAL(DBName);

                int i = 0;
                foreach (DataRow dr in dt.Rows)
                {
                    Maticsoft.Model.tb_Member model = new Maticsoft.Model.tb_Member();
                    try
                    {
                        string Code = dr["会员卡号"].ToString();
                        string CardCode = dr["会员卡号"].ToString();
                        string TrueName = dr["姓名"].ToString();
                        string Mobile = dr["手机号码"].ToString();
                        string Sex = dr["性别"].ToString();
                        string BirthDate = dr["生日"].ToString();
                        string Email = dr["邮箱"].ToString();
                        string XfSum = dr["消费次数"].ToString();
                        string XfAmount = dr["消费金额"].ToString();
                        string SumIntegral = dr["累计积分"].ToString();
                        string keYongIntegral = dr["剩余积分"].ToString();
                        string Amount = dr["储值余额"].ToString();
                        string Pwd = "123456";
                        string 会员类别编码 = dr["会员类别编码"].ToString();
                        int MemberTypeId = 0;
                        string MemberTypeName = "";
                        try
                        {
                            MemberTypeId = int.Parse(DbHelperSQL.GetSingle("SELECT [id] FROM [" + DBName + @"].[dbo].[tb_MemberClass] where code='" + 会员类别编码 + "'").ToString());
                            MemberTypeName = DbHelperSQL.GetSingle("SELECT [name] FROM [" + DBName + @"].[dbo].[tb_MemberClass] where code='" + 会员类别编码 + "'").ToString();
                        }
                        catch { }
                        try
                        {
                            model.XfSum = Convert.ToInt32(XfSum);
                        }
                        catch { }

                        try
                        {
                            model.SumIntegral = Convert.ToInt32(Amount);
                        }
                        catch { }
                        try
                        {
                            model.keYongIntegral = Convert.ToInt32(keYongIntegral);
                        }
                        catch { }
                        string Status = "正常";
                        model.Code = Code;
                        model.CardCode = CardCode;
                        model.Pwd = Pwd;
                        model.Amount = Convert.ToDecimal(Amount);
                        model.XfAmount = Convert.ToDecimal(XfAmount);

                        model.UsedIntegral = 0;
                        model.TrueName = TrueName;
                        model.MemberTypeId = MemberTypeId;
                        model.MemberTypeName = MemberTypeName;
                        model.Sex = Sex;
                        model.Mobile = Mobile;
                        model.BirthDate = BirthDate;
                        model.Email = Email;
                        model.Status = Status;
                        try
                        {
                            if (!bll.Exists(model.Code))
                            {
                                int ReturnValue = bll.Add(model);
                                if (ReturnValue > 0)
                                {
                                    i++;
                                }
                            }
                        }
                        catch
                        {
                            result.count = i;
                        }
                    }
                    catch
                    {
                        result.status = 0;
                        result.count = i;
                        return Json(result, JsonRequestBehavior.AllowGet);
                    }
                }

                result.status = 1;
                result.count = i;
            }
            else
            {
                result.status = 0;
                result.count = 0;
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ExcelImportMemberOut()
        {
            JsonModel result = new JsonModel();
            string sql = @"select * from [" + DBName + @"].[dbo].[View_SelectProduct_ExcelExportOut]   ";
            DataSet ds = DbHelperSQL.Query(sql); ;
            //导出数据
            string temppath = Server.MapPath("\\UpFile");
            string filepath = temppath + "\\ExportExcel\\商品导出模板.xls";//临时文件,也作为模板文件
            string downUrl = "\\ExcelOut\\" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xls";//导出文件路径
            string outfilepath = temppath + downUrl;//导出文件路径
            AsposeExcel asposeexcel = new AsposeExcel(outfilepath, filepath);
            asposeexcel.DatatableToExcel(ds.Tables[0]);
            return DownFile("\\UpFile" + downUrl, DateTime.Now.ToString("yyyyMMdd") + "商品导出列表导出.xls");

        }
        #endregion

        #region 零售商品流水
        public ActionResult tb_PosSaleJournalExport()
        {
            JsonModel result = new JsonModel();
            string sql = @"select   ROW_NUMBER() OVER     (ORDER BY id)  as id,StoreName, BillNo, SaleDateTime, HHNo, GoodsName, TradeType, Count, Price, Subtotal, YYerName from [" + DBName + @"].[dbo].[tb_PosSaleJournal]  where StoreID in(" + StoreId + ") ";
            DataSet ds = DbHelperSQL.Query(sql); ;
            //导出数据
            string temppath = Server.MapPath("\\UpFile");
            string filepath = temppath + "\\ExportExcel\\零售商品流水导出.xls";//临时文件,也作为模板文件
            string downUrl = "\\ExcelOut\\" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xls";//导出文件路径
            string outfilepath = temppath + downUrl;//导出文件路径
            AsposeExcel asposeexcel = new AsposeExcel(outfilepath, filepath);
            asposeexcel.DatatableToExcel(ds.Tables[0]);
            return DownFile("\\UpFile" + downUrl, DateTime.Now.ToString("yyyyMMdd") + "零售商品流水导出.xls");
        }
        #endregion

        #region 零售收银流水
        public ActionResult tb_PosCashJournalExport()
        {
            JsonModel result = new JsonModel();
            string sql = @"select   ROW_NUMBER() OVER     (ORDER BY id)  as id,  StoreName, BillNo, SYDateTime, TradeType, BillAccount, PaymentMode, PaymentAccount, ReturnOriginalNo, SYerName from [" + DBName + @"].[dbo].[tb_PosCashJournal]  where StoreName in(" + StoreName + ") ";
            DataSet ds = DbHelperSQL.Query(sql);
            //导出数据
            string temppath = Server.MapPath("\\UpFile");
            string filepath = temppath + "\\ExportExcel\\零售收银流水导出.xls";//临时文件,也作为模板文件
            string downUrl = "\\ExcelOut\\" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xls";//导出文件路径
            string outfilepath = temppath + downUrl;//导出文件路径
            AsposeExcel asposeexcel = new AsposeExcel(outfilepath, filepath);
            asposeexcel.DatatableToExcel(ds.Tables[0]);
            return DownFile("\\UpFile" + downUrl, DateTime.Now.ToString("yyyyMMdd") + "零售收银流水导出.xls");
        }
        #endregion

        #region 零售类别汇总导出
        public ActionResult tb_PosSaleGoodsTypeSummaryExport()
        {
            JsonModel result = new JsonModel();
            //string sql = @"select   ROW_NUMBER() OVER   (ORDER BY id)  as id, GoodsTypeCode, GoodsTypeName,  StoreName, SaleCount, SaleAccount, ReturnCount, ReturnAccount, CountSubtotal, AccountSubtotal from [" + DBName + @"].[dbo].[tb_PosSaleGoodsTypeSummary]   ";

            string sql = @"select ROW_NUMBER() OVER   (ORDER BY StoreCode)  as id, GoodsTypeCode, GoodsTypeName,  StoreName, SaleCount, SaleAccount, ReturnCount,ReturnAccount,
([SaleCount]+ReturnCount) as CountSubtotal   ,([SaleAccount]+[ReturnAccount]) as AccountSubtotal
                           from [" + DBName + @"].[dbo].[View_SelectPos_ProductClass1]   where StoreID in(" + StoreId + ") ";

            DataSet ds = DbHelperSQL.Query(sql);
            //导出数据
            string temppath = Server.MapPath("\\UpFile");
            string filepath = temppath + "\\ExportExcel\\零售类别汇总导出.xls";//临时文件,也作为模板文件
            string downUrl = "\\ExcelOut\\" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xls";//导出文件路径
            string outfilepath = temppath + downUrl;//导出文件路径
            AsposeExcel asposeexcel = new AsposeExcel(outfilepath, filepath);
            asposeexcel.DatatableToExcel(ds.Tables[0]);
            return DownFile("\\UpFile" + downUrl, DateTime.Now.ToString("yyyyMMdd") + "零售类别汇总导出.xls");
        }
        #endregion

        #region 零售日汇总导出
        public ActionResult tb_PosSaleDaySummarySummaryExport()
        {
            JsonModel result = new JsonModel();
            //            string sql = @"select   ROW_NUMBER() OVER   (ORDER BY id)  as id, S_DateTime, HHNo, GoodsName, StoreName, SaleCount, SaleAccount,
            //                           ReturnCount, ReturnAccount, CountSubtotal, AccountSubtotal   from [" + DBName + @"].[dbo].[tb_PosSaleDaySummary]   ";

            string sql = @"select ROW_NUMBER() OVER   (ORDER BY HHNo)  as id, S_DateTime, HHNo, GoodsName, StoreName, SaleCount, SaleAccount,
                           ReturnCount, ReturnAccount,([SaleCount]+ReturnCount) as CountSubtotal   ,([SaleAccount]+[ReturnAccount]) as AccountSubtotal

                                from [" + DBName + @"].[dbo].[View_SelectPos_ProductDay1] as tb  where tb.StoreID in(" + StoreId + ")";


            DataSet ds = DbHelperSQL.Query(sql);
            //导出数据
            string temppath = Server.MapPath("\\UpFile");
            string filepath = temppath + "\\ExportExcel\\零售日汇总导出.xls";//临时文件,也作为模板文件
            string downUrl = "\\ExcelOut\\" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xls";//导出文件路径
            string outfilepath = temppath + downUrl;//导出文件路径
            AsposeExcel asposeexcel = new AsposeExcel(outfilepath, filepath);
            asposeexcel.DatatableToExcel(ds.Tables[0]);
            return DownFile("\\UpFile" + downUrl, DateTime.Now.ToString("yyyyMMdd") + "零售日汇总导出.xls");
        }
        #endregion

        #region 零售月汇总导出
        public ActionResult tb_PosSaleMonthSummaryExport()
        {
            JsonModel result = new JsonModel();
            //            string sql = @"select ROW_NUMBER() OVER   (ORDER BY id)  as id, StoreDateTime, HHNo, GoodsName, StoreName, SaleCount, SaleAccount,
            //                           ReturnCount, ReturnAccount, CountSubtotal, AccountSubtotal    from [" + DBName + @"].[dbo].[tb_PosSaleMonthSummary]   ";


            string sql = @"select ROW_NUMBER() OVER   (ORDER BY HHNo)  as id, S_DateTime, HHNo, GoodsName, StoreName, SaleCount, SaleAccount,
                           ReturnCount, ReturnAccount,([SaleCount]+ReturnCount) as CountSubtotal   ,([SaleAccount]+[ReturnAccount]) as AccountSubtotal

                                from [" + DBName + @"].[dbo].[View_SelectPos_ProductMonth1] as tb where tb.StoreID in(" + StoreId + ") ";

            DataSet ds = DbHelperSQL.Query(sql);
            //导出数据
            string temppath = Server.MapPath("\\UpFile");
            string filepath = temppath + "\\ExportExcel\\零售月汇总导出.xls";//临时文件,也作为模板文件
            string downUrl = "\\ExcelOut\\" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xls";//导出文件路径
            string outfilepath = temppath + downUrl;//导出文件路径
            AsposeExcel asposeexcel = new AsposeExcel(outfilepath, filepath);
            asposeexcel.DatatableToExcel(ds.Tables[0]);
            return DownFile("\\UpFile" + downUrl, DateTime.Now.ToString("yyyyMMdd") + "零售月汇总导出.xls");
        }
        #endregion

        #region 零售品牌汇总导出
        public ActionResult tb_PosSaleBrandSummaryExport()
        {
            JsonModel result = new JsonModel();
            //string sql = @"select ROW_NUMBER() OVER  (ORDER BY id)  as id,  BrandCode, BrandName, StoreName, SaleCount, SaleAccount, ReturnCount, ReturnAccount, CountSubtotal, AccountSubtotal  from [" + DBName + @"].[dbo].[tb_PosSaleBrandSummary]   ";


            string sql = @"SELECT ROW_NUMBER() OVER   (ORDER BY StoreCode)  as id,[BrandCode]
                              ,[BrandName]
                              ,[StoreName]
                              ,[SaleCount]
                              ,[SaleAccount]
                              ,[ReturnCount]
                              ,[ReturnAccount]
                              ,[brandCode]
                              ,([SaleCount]+ReturnCount) as CountSubtotal  
                               ,([SaleAccount]+[ReturnAccount]) as AccountSubtotal  from [" + DBName + @"].[dbo].[View_SelectPos_ProductBrand1]   where StoreID in(" + StoreId + ") ";
            
            DataSet ds = DbHelperSQL.Query(sql);
            //导出数据
            string temppath = Server.MapPath("\\UpFile");
            string filepath = temppath + "\\ExportExcel\\零售品牌汇总导出.xls";//临时文件,也作为模板文件
            string downUrl = "\\ExcelOut\\" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xls";//导出文件路径
            string outfilepath = temppath + downUrl;//导出文件路径
            AsposeExcel asposeexcel = new AsposeExcel(outfilepath, filepath);
            asposeexcel.DatatableToExcel(ds.Tables[0]);
            return DownFile("\\UpFile" + downUrl, DateTime.Now.ToString("yyyyMMdd") + "零售品牌汇总导出.xls");
        }
        #endregion

        #region 零售毛利分析导出
        public ActionResult tb_PosSaleGrossProfitAnalyseExport()
        {
            JsonModel result = new JsonModel();
//            string sql1 = @"select ROW_NUMBER() OVER  (ORDER BY id)  as id,  HHNo, GoodsName, SaleCount, SaleAccount, SaleCostPrice, GrossProfit, GrossProfitRate, SalePrice, CostPrice  
//
//from [" + DBName + @"].[dbo].[tb_PosSaleGrossProfitAnalyse]   ";


            string sql = @"select  ROW_NUMBER() OVER  (ORDER BY HHNo)  as id,
                                   HHNo, GoodsName, SaleCount, SaleAccount, SaleCostPrice, GrossProfit, GrossProfitRate, SalePrice, CostPrice  from [" + DBName + @"].[dbo].[View_SelectPosProductGrossProfitAnalyse2]  where StoreID in(" + StoreId + ")  ";


            DataSet ds = DbHelperSQL.Query(sql);
            //导出数据
            string temppath = Server.MapPath("\\UpFile");
            string filepath = temppath + "\\ExportExcel\\零售毛利分析导出.xls";//临时文件,也作为模板文件
            string downUrl = "\\ExcelOut\\" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xls";//导出文件路径
            string outfilepath = temppath + downUrl;//导出文件路径
            AsposeExcel asposeexcel = new AsposeExcel(outfilepath, filepath);
            asposeexcel.DatatableToExcel(ds.Tables[0]);
            return DownFile("\\UpFile" + downUrl, DateTime.Now.ToString("yyyyMMdd") + "零售毛利分析导出.xls");
        }
        #endregion

        #region 零售营业员提成导出
        public ActionResult tb_PosSaleSyerTCExport()
        {
            JsonModel result = new JsonModel();
            string sql = @"select ROW_NUMBER() OVER  (ORDER BY YYerCode)  as id,  StoreName, YYerCode, YYerName, SUM([SaleAccount]) SaleAccount, SUM(TCAccount)  [TCAccount]  from [" + DBName + @"].[dbo].[View_SelectPos_ProductTCDetail1]  where TCAccount>0  AND  StoreID in(" + StoreId + ") group by [YYerCode],[YYerName] ,[StoreName] ";
            DataSet ds = DbHelperSQL.Query(sql);
            //导出数据
            string temppath = Server.MapPath("\\UpFile");
            string filepath = temppath + "\\ExportExcel\\零售营业员提成导出.xls";//临时文件,也作为模板文件
            string downUrl = "\\ExcelOut\\" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xls";//导出文件路径
            string outfilepath = temppath + downUrl;//导出文件路径
            AsposeExcel asposeexcel = new AsposeExcel(outfilepath, filepath);
            asposeexcel.DatatableToExcel(ds.Tables[0]);
            return DownFile("\\UpFile" + downUrl, DateTime.Now.ToString("yyyyMMdd") + "零售营业员提成导出.xls");
        }
        #endregion

        #region 零售营业员提成明细导出
        public ActionResult tb_PosSaleSyerTCDetailExport()
        {
            JsonModel result = new JsonModel();
            string sql = @"select ROW_NUMBER() OVER  (ORDER BY YYerCode)  as id,   StoreName, YYerCode, YYerName, BillNo, SaleDateTime, HHNo, GoodsName, TradeType, SaleAccount, TCAccount  from [" + DBName + @"].[dbo].[View_SelectPos_ProductTCDetail1]  where StoreID in(" + StoreId + ")  ";
            DataSet ds = DbHelperSQL.Query(sql);
            //导出数据
            string temppath = Server.MapPath("\\UpFile");
            string filepath = temppath + "\\ExportExcel\\零售营业员提成明细导出.xls";//临时文件,也作为模板文件
            string downUrl = "\\ExcelOut\\" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xls";//导出文件路径
            string outfilepath = temppath + downUrl;//导出文件路径
            AsposeExcel asposeexcel = new AsposeExcel(outfilepath, filepath);
            asposeexcel.DatatableToExcel(ds.Tables[0]);
            return DownFile("\\UpFile" + downUrl, DateTime.Now.ToString("yyyyMMdd") + "零售营业员提成明细导出.xls");
        }
        #endregion

        #region 促销销售汇总导出
        public ActionResult tb_PromotionSaleSummaryExport()
        {
            JsonModel result = new JsonModel();
            string sql = @"select ROW_NUMBER() OVER  (ORDER BY id)  as id, HHNo, GoodsName, Count, PrimePrice, Price, SaleAccount, RLAccount from [" + DBName + @"].[dbo].[tb_PromotionSaleSummary]   ";
            DataSet ds = DbHelperSQL.Query(sql);
            //导出数据
            string temppath = Server.MapPath("\\UpFile");
            string filepath = temppath + "\\ExportExcel\\促销销售汇总导出.xls";//临时文件,也作为模板文件
            string downUrl = "\\ExcelOut\\" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xls";//导出文件路径
            string outfilepath = temppath + downUrl;//导出文件路径
            AsposeExcel asposeexcel = new AsposeExcel(outfilepath, filepath);
            asposeexcel.DatatableToExcel(ds.Tables[0]);
            return DownFile("\\UpFile" + downUrl, DateTime.Now.ToString("yyyyMMdd") + "促销销售汇总导出.xls");
        }
        #endregion

        #region 促销销售明细导出
        public ActionResult tb_PromotionSaleDetailExport()
        {
            JsonModel result = new JsonModel();
            string sql = @"select ROW_NUMBER() OVER  (ORDER BY id)  as id, StoreName, PromotionMode, BillNo, HHNo, GoodsName, Count, PrimePrice, Price, SaleAccount, RLAccount from [" + DBName + @"].[dbo].[tb_PromotionSaleDetail]   ";
            DataSet ds = DbHelperSQL.Query(sql);
            //导出数据
            string temppath = Server.MapPath("\\UpFile");
            string filepath = temppath + "\\ExportExcel\\促销销售明细导出.xls";//临时文件,也作为模板文件
            string downUrl = "\\ExcelOut\\" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xls";//导出文件路径
            string outfilepath = temppath + downUrl;//导出文件路径
            AsposeExcel asposeexcel = new AsposeExcel(outfilepath, filepath);
            asposeexcel.DatatableToExcel(ds.Tables[0]);
            return DownFile("\\UpFile" + downUrl, DateTime.Now.ToString("yyyyMMdd") + "促销销售明细导出.xls");
        }
        #endregion

        #region 会员消费明细导出
        public ActionResult tb_MembersSpendingDetailExport()
        {
            JsonModel result = new JsonModel();
            string sql = @"select ROW_NUMBER() OVER  (ORDER BY id)  as id, MemberCode, MemberName, StoreName, BillNo, HHNo, GoodsName, PrimePrice, Count, Price, SaleAccount, TradeDateTime  from [" + DBName + @"].[dbo].[tb_MembersSpendingDetail]   ";
            DataSet ds = DbHelperSQL.Query(sql);
            //导出数据
            string temppath = Server.MapPath("\\UpFile");
            string filepath = temppath + "\\ExportExcel\\会员消费明细导出.xls";//临时文件,也作为模板文件
            string downUrl = "\\ExcelOut\\" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xls";//导出文件路径
            string outfilepath = temppath + downUrl;//导出文件路径
            AsposeExcel asposeexcel = new AsposeExcel(outfilepath, filepath);
            asposeexcel.DatatableToExcel(ds.Tables[0]);
            return DownFile("\\UpFile" + downUrl, DateTime.Now.ToString("yyyyMMdd") + "会员消费明细导出.xls");
        }
        #endregion

        #region 采购日汇总导出
        public ActionResult tbView_SelectPurchaseReport_DayExport()
        {
            JsonModel result = new JsonModel();
            string sql = @"select ROW_NUMBER() OVER  (ORDER BY CreateDate)  as id,
                               [CreateDate],
                               [HHNo]
                              ,[ProductName]
                              ,[StoreName]
                               ,[Num]
                              ,[Price]
                              ,[SendNum]
                              ,[SumPrice]
                              ,[THNum]
                              ,[THSendNum]
                              ,[Num] as SumNum
                              ,[THSumPrice]

                        from [" + DBName + @"].[dbo].[View_SelectPurchaseReport_Day]   where StoreID in(" + StoreId + ")  ";
            DataSet ds = DbHelperSQL.Query(sql);
            //导出数据
            string temppath = Server.MapPath("\\UpFile");
            string filepath = temppath + "\\ExportExcel\\采购日汇总导出.xls";//临时文件,也作为模板文件
            string downUrl = "\\ExcelOut\\" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xls";//导出文件路径
            string outfilepath = temppath + downUrl;//导出文件路径
            AsposeExcel asposeexcel = new AsposeExcel(outfilepath, filepath);
            asposeexcel.DatatableToExcel(ds.Tables[0]);
            return DownFile("\\UpFile" + downUrl, DateTime.Now.ToString("yyyyMMdd") + "采购日汇总导出.xls");
        }
        #endregion

        #region 采购月汇总导出
        public ActionResult tbView_SelectPurchaseReport_MonthExport()
        {
            JsonModel result = new JsonModel();
            string sql = @"select ROW_NUMBER() OVER  (ORDER BY CreateDate)  as id,
                               [CreateDate],
                               [HHNo]
                              ,[ProductName]
                              ,[StoreName]
                               ,[Num]
                              ,[Price]
                              ,[SendNum]
                              ,[SumPrice]
                              ,[THNum]
                              ,[THSendNum]
                              ,[Num] as SumNum
                              ,[THSumPrice]

                        from [" + DBName + @"].[dbo].[View_SelectPurchaseReport_Month]    where StoreID in(" + StoreId + ") ";
            DataSet ds = DbHelperSQL.Query(sql);
            //导出数据
            string temppath = Server.MapPath("\\UpFile");
            string filepath = temppath + "\\ExportExcel\\采购月汇总导出.xls";//临时文件,也作为模板文件
            string downUrl = "\\ExcelOut\\" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xls";//导出文件路径
            string outfilepath = temppath + downUrl;//导出文件路径
            AsposeExcel asposeexcel = new AsposeExcel(outfilepath, filepath);
            asposeexcel.DatatableToExcel(ds.Tables[0]);
            return DownFile("\\UpFile" + downUrl, DateTime.Now.ToString("yyyyMMdd") + "采购月汇总导出.xls");
        }
        #endregion

        #region 采购类别汇总导出
        public ActionResult tbView_SelectPurchaseReport_RptPurCategoriesSummaryMonthExport()
        {
            JsonModel result = new JsonModel();
            string sql = @"select ROW_NUMBER() OVER  (ORDER BY ProductClassCode)  as id,
                               [ProductClassCode]
                              ,[ProductClassName]
                              ,[StoreName]
                              ,[Num]
                              ,[Price]
                              ,[SendNum]
                              ,[SumPrice]
                              ,[THNum]
                              ,[THSendNum]
                              ,[Num] as xjNum
                              ,[THSumPrice]

                        from [" + DBName + @"].[dbo].[View_SelectPurchaseReport_RptPurCategoriesSummary]   where StoreID in(" + StoreId + ")";
            DataSet ds = DbHelperSQL.Query(sql);
            //导出数据
            string temppath = Server.MapPath("\\UpFile");
            string filepath = temppath + "\\ExportExcel\\采购类别汇总导出.xls";//临时文件,也作为模板文件
            string downUrl = "\\ExcelOut\\" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xls";//导出文件路径
            string outfilepath = temppath + downUrl;//导出文件路径
            AsposeExcel asposeexcel = new AsposeExcel(outfilepath, filepath);
            asposeexcel.DatatableToExcel(ds.Tables[0]);
            return DownFile("\\UpFile" + downUrl, DateTime.Now.ToString("yyyyMMdd") + "采购类别汇总导出.xls");
        }
        #endregion

        #region 采购品牌汇总导出
        public ActionResult tbView_SelectPurchaseReport_RptPurBrandsSummaryExport()
        {
            JsonModel result = new JsonModel();
            string sql = @"select ROW_NUMBER() OVER  (ORDER BY BrandCode)  as id,
                           [BrandCode]
                          ,[ProductBrandName]
                          ,[StoreName]
                          ,[Num]
                          ,[Price]
                          ,[SendNum]
                          ,[SumPrice]
                          ,[THNum]
                          ,[THSendNum]
                          ,Num as  xjnum
                          ,[THSumPrice]
                        from [" + DBName + @"].[dbo].[View_SelectPurchaseReport_RptPurBrandsSummary]  where StoreID in(" + StoreId + ") ";
            DataSet ds = DbHelperSQL.Query(sql);
            //导出数据
            string temppath = Server.MapPath("\\UpFile");
            string filepath = temppath + "\\ExportExcel\\采购品牌汇总导出.xls";//临时文件,也作为模板文件
            string downUrl = "\\ExcelOut\\" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xls";//导出文件路径
            string outfilepath = temppath + downUrl;//导出文件路径
            AsposeExcel asposeexcel = new AsposeExcel(outfilepath, filepath);
            asposeexcel.DatatableToExcel(ds.Tables[0]);
            return DownFile("\\UpFile" + downUrl, DateTime.Now.ToString("yyyyMMdd") + "采购品牌汇总导出.xls");
        }
        #endregion

        #region 采购供应商汇总导出
        public ActionResult tb_View_SelectPurchaseReport_RptPurVendorsSummaryExport()
        {
            JsonModel result = new JsonModel();
            string sql = @"select ROW_NUMBER() OVER  (ORDER BY SupplierCode)  as id,
                           [SupplierCode]
                          ,[SupplierName]
                          ,[StoreName]
                          ,[Num]
                          ,[Price]
                          ,[SendNum]
                          ,[SumPrice]
                          ,[THNum]
                          ,[THSendNum]
                          ,Num AS XJNUM
                          ,[THSumPrice]
                        from [" + DBName + @"].[dbo].[View_SelectPurchaseReport_RptPurVendorsSummary]   where StoreID in(" + StoreId + ")  ";
            DataSet ds = DbHelperSQL.Query(sql);
            //导出数据
            string temppath = Server.MapPath("\\UpFile");
            string filepath = temppath + "\\ExportExcel\\采购供应商汇总导出.xls";//临时文件,也作为模板文件
            string downUrl = "\\ExcelOut\\" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xls";//导出文件路径
            string outfilepath = temppath + downUrl;//导出文件路径
            AsposeExcel asposeexcel = new AsposeExcel(outfilepath, filepath);
            asposeexcel.DatatableToExcel(ds.Tables[0]);
            return DownFile("\\UpFile" + downUrl, DateTime.Now.ToString("yyyyMMdd") + "采购供应商汇总导出.xls");
        }
        #endregion

        #region 采购明细汇总导出
        public ActionResult tb_View_SelectPurchaseOrderAcceptDetailReportExport()
        {
            JsonModel result = new JsonModel();
            string sql = @"select ROW_NUMBER() OVER  (ORDER BY SerialNum)  as id,
                           [SerialNum]
                          ,[StoreName]
                          ,[SupplierName]
                          ,[HHNo]
                          ,[ProductName]
                          ,[Num]
                          ,[SendNum]
                          ,[Price]
                          ,(num*price) as SumPrice
                          ,[CreateDate]
                        from [" + DBName + @"].[dbo].[View_SelectPurchaseOrderAcceptDetailReport]   where StoreID in(" + StoreId + ") ";
            DataSet ds = DbHelperSQL.Query(sql);
            //导出数据
            string temppath = Server.MapPath("\\UpFile");
            string filepath = temppath + "\\ExportExcel\\采购明细汇总导出.xls";//临时文件,也作为模板文件
            string downUrl = "\\ExcelOut\\" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xls";//导出文件路径
            string outfilepath = temppath + downUrl;//导出文件路径
            AsposeExcel asposeexcel = new AsposeExcel(outfilepath, filepath);
            asposeexcel.DatatableToExcel(ds.Tables[0]);
            return DownFile("\\UpFile" + downUrl, DateTime.Now.ToString("yyyyMMdd") + "采购明细汇总导出.xls");
        }
        #endregion

        #region 库存成本查询导出
        public ActionResult tb_View_SelectStockReport_StockRptStmCost_GroupByReportExport()
        {
            JsonModel result = new JsonModel();
            string sql = @"select ROW_NUMBER() OVER  (ORDER BY HHNo)  as id,
                           [StoreName]
                          ,[HHNo]
                          ,[ProductName]
                          ,[SupplierName]
                          ,[ProductClassName]
                          ,[BrandName]
                          ,[Num]
                          ,[jinPrice]
                          ,(Num*jinPrice) as SumPrice
                        from [" + DBName + @"].[dbo].[View_SelectStockReport_StockRptStmCost_GroupBy]   where StoreID in(" + StoreId + ")  ";
            DataSet ds = DbHelperSQL.Query(sql);
            //导出数据
            string temppath = Server.MapPath("\\UpFile");
            string filepath = temppath + "\\ExportExcel\\库存成本查询导出.xls";//临时文件,也作为模板文件
            string downUrl = "\\ExcelOut\\" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xls";//导出文件路径
            string outfilepath = temppath + downUrl;//导出文件路径
            AsposeExcel asposeexcel = new AsposeExcel(outfilepath, filepath);
            asposeexcel.DatatableToExcel(ds.Tables[0]);
            return DownFile("\\UpFile" + downUrl, DateTime.Now.ToString("yyyyMMdd") + "库存成本查询导出.xls");
        }
        #endregion

        #region 库存出入库明细导出
        public ActionResult tb_View_SelectStockReport_StockDetail_RptStmIODetailExport()
        {
            JsonModel result = new JsonModel();
            string sql = @"select ROW_NUMBER() OVER  (ORDER BY HHNo)  as id

                          ,[HHNo]
                          ,[ProductName] 
                          ,[StoreName]
                          ,[SerialNum]  
                          ,[Num]
                          ,[OutNum]   
                           ,[Price]
                          ,[SumPrice]
                           ,StockType
                        from [" + DBName + @"].[dbo].[View_SelectStockReport_StockDetail_RptStmIODetail]  where StoreID in(" + StoreId + ")   ";
            DataSet ds = DbHelperSQL.Query(sql);
            //导出数据
            string temppath = Server.MapPath("\\UpFile");
            string filepath = temppath + "\\ExportExcel\\库存出入库明细导出.xls";//临时文件,也作为模板文件
            string downUrl = "\\ExcelOut\\" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xls";//导出文件路径
            string outfilepath = temppath + downUrl;//导出文件路径
            AsposeExcel asposeexcel = new AsposeExcel(outfilepath, filepath);
            asposeexcel.DatatableToExcel(ds.Tables[0]);
            return DownFile("\\UpFile" + downUrl, DateTime.Now.ToString("yyyyMMdd") + "库存出入库明细导出.xls");
        }
        #endregion

        #region 库存出入库汇总导出
        public ActionResult tb_View_SelectStockReport_StockDetail_RptStm_SUMExport()
        {
            JsonModel result = new JsonModel();
            string sql = @"select ROW_NUMBER() OVER  (ORDER BY HHNo)  as id,
                               [StoreName] 
                              ,[HHNo]
                              ,[ProductName]
                              ,[Num]
                              ,[OutNum]
                              ,[ProductClassName]     
                              ,[BrandName]  
                        from [" + DBName + @"].[dbo].[View_SelectStockReport_StockDetail_RptStm_SUM]    where StoreID in(" + StoreId + ") ";
            DataSet ds = DbHelperSQL.Query(sql);
            //导出数据
            string temppath = Server.MapPath("\\UpFile");
            string filepath = temppath + "\\ExportExcel\\库存出入库汇总导出.xls";//临时文件,也作为模板文件
            string downUrl = "\\ExcelOut\\" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xls";//导出文件路径
            string outfilepath = temppath + downUrl;//导出文件路径
            AsposeExcel asposeexcel = new AsposeExcel(outfilepath, filepath);
            asposeexcel.DatatableToExcel(ds.Tables[0]);
            return DownFile("\\UpFile" + downUrl, DateTime.Now.ToString("yyyyMMdd") + "库存出入库汇总导出.xls");
        }
        #endregion

        #region 库存商品调拨明细导出
        public ActionResult tb_View_SelectStockReport_StocktransferDetail_RptStmDBItemsExport()
        {
            JsonModel result = new JsonModel();
            string sql = @"select ROW_NUMBER() OVER  (ORDER BY HHNo)  as id,
                               [SerialNum]    
                               ,[OutStoreName]
                              ,[InStoreName]      
                              ,[HHNo]
                              ,[ProductName]
                              ,[OutNum]
                              ,(OutNum*Price) AS SumPrice
                              ,AcceptNum
                              ,(AcceptNum*AcceptPrice) AS AcceptSumPrice,[Status] , ApprUserName ,ApprDate
                        from [" + DBName + @"].[dbo].[View_SelectStockReport_StocktransferDetail_RptStmDBItems] where inStoreID in(" + StoreId + ") OR  OutStoreID in(" + StoreId + ")    ";
            DataSet ds = DbHelperSQL.Query(sql);
            //导出数据
            string temppath = Server.MapPath("\\UpFile");
            string filepath = temppath + "\\ExportExcel\\库存商品调拨明细导出.xls";//临时文件,也作为模板文件
            string downUrl = "\\ExcelOut\\" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xls";//导出文件路径
            string outfilepath = temppath + downUrl;//导出文件路径
            AsposeExcel asposeexcel = new AsposeExcel(outfilepath, filepath);
            asposeexcel.DatatableToExcel(ds.Tables[0]);
            return DownFile("\\UpFile" + downUrl, DateTime.Now.ToString("yyyyMMdd") + "库存商品调拨明细导出.xls");
        }
        #endregion

        #region 公用类库
        private DataTable GetExportDatable(HttpPostedFileBase fileData, string directory)
        {

            string SaveName = fileData.FileName;
            var guidFile = DateTime.Now.ToString("yyyyMMddHHmmss");

            var directoryAbsolutePath = Server.MapPath(directory) + "/" + guidFile;
            if (!Directory.Exists(directoryAbsolutePath))
            {
                var directoryInfo = Directory.CreateDirectory(directoryAbsolutePath);
            }
            string fileName = fileData.FileName;/// 原始文件名称
            string fileExtension = Path.GetExtension(fileName); // 文件扩展名
            string fullName = directoryAbsolutePath + "\\" + SaveName;
            fileData.SaveAs(fullName);

            string ExportExcelPath = fullName;
            string ExcelOutpath = Server.MapPath("\\UpFile\\ExcelOut");
            if (!Directory.Exists(ExcelOutpath))
                Directory.CreateDirectory(ExcelOutpath);
            string outfilepath = ExcelOutpath + "\\" + DateTime.Now.ToString("yyyyMMddHHmmss") + fileExtension;//导出文件路径
            AsposeExcel asposeexcel = new AsposeExcel(outfilepath, ExportExcelPath, "");

            StringBuilder sb = new StringBuilder();

            DataTable Olddt = asposeexcel.ExcelToDatatalbe();
            DataTable dtNew = new DataTable();
            for (int i = 0; i < Olddt.Columns.Count; i++)//获取列表
            {
                dtNew.Columns.Add(Olddt.Rows[0][i].ToString(), typeof(System.String));
            }
            for (int j = 1; j < Olddt.Rows.Count; j++)
            {
                DataRow row = dtNew.NewRow();
                int c = 0;
                foreach (DataColumn dc in dtNew.Columns)
                {
                    sb.Append("string " + dc.ColumnName + " =dr[\"" + dc.ColumnName + "\"].ToString();");

                    row[dc.ColumnName] = Olddt.Rows[j][c].ToString();
                    c++;
                }
                dtNew.Rows.Add(row);
            }
            string temp = sb.ToString();

            return dtNew;
        }

        public FileResult DownFile(string FilePath, string FileName)
        {
            if (!Request.Browser.IsBrowser("Firefox"))
            {
                FileName = System.Web.HttpUtility.UrlEncode(FileName);
            }
            FilePath = Server.MapPath(FilePath);
            return File(FilePath, "application/octet-stream", FileName);
        }
        #endregion
    }
}
