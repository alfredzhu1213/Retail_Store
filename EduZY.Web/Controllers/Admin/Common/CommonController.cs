using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Common;
using System.Data;
using Maticsoft.Model;
using Base;
using System.Data.SqlClient;
using Maticsoft.DBUtility;
using Entity;
using System.IO;
using EduZY.Model;
using System.Web.Script.Serialization;
using System.Text;
using EduJXC.Model;

namespace EduZY.Web.Controllers.Admin.Common
{
    public class CommonController : BaseController
    {
        public ActionResult SelectStoreMore()
        { 
            return View();
        }

        public ActionResult SelectProduct()
        {
            return View();
        }
        public ActionResult SelectStoreEasyui()
        {
            return View();
        }
        public ActionResult SelectStoreEasyuis()
        {
            return View();
        }
        
        public ActionResult SelectProductALL()
        {
            return View();
        }
        public ActionResult SelectProductThis(int? pageindex=1)
        {
            string KeyWord = DNTRequest.GetString("KeyWord");
            string ClassId = DNTRequest.GetString("ClassId");
            string ClassName = DNTRequest.GetString("ClassName");
            
            int rows = DNTRequest.GetInt("rows", 10);
            string strWhere = " 1=1 AND ProductStatus<>'淘汰'  ";
            if (KeyWord != "")
            {
                strWhere += " and (ProductName like '%" + KeyWord + "%'  or HHNo like '%" + KeyWord + "%' ) ";
            }

            if (ClassId != "")
            {
                strWhere += " and  ClassId in (SELECT id FROM [" + DBName + @"].[dbo].[f_ProductType_next] (" + Convert.ToInt32(ClassId) + ")) ";
            }
            int iRecordCount = 0;


            string sql = @"select  [id]
                      ,[ProductName]
                      ,[ImgUrl]
                      ,[HHNo]
                      ,[GG]
                      ,[other]
                      ,[Unit]
                      ,[StockNum]
                      ,[MemberPrice]
                      ,[jinPrice]
                      ,[SalesPrice]
                      ,[MinPrice]
                      ,IsAllowChange
                      , CASE IsAllowChange WHEN 1 THEN '是' WHEN 0 THEN '否' ELSE '' END as  IsAllowChangeName
                      ,(SELECT [name] FROM  [" + DBName + @"].[dbo].[tb_ProductType] where id=pro.ClassId) as ClassName
                      ,[ClassCode]
                      ,[ProductSingeName]
                      ,[ProductJJ]
                      ,[BrandCode]
                      ,(SELECT [name] FROM  [" + DBName + @"].[dbo].[tb_ProductBrand] where id=pro.BrandId) as BrandName
                      ,[SupCode]
                      ,(SELECT [name] FROM  [" + DBName + @"].[dbo].[tb_PurchaseSupplier] where id=pro.SupId) as SupName 
                      ,[JinGG]
                      ,[ProductStatus]
                      ,[ProductType]
                      ,[JJWay]
                      ,[TJWay]
                      ,[TJPrice]
                      ,[Remark]
                      ,[AddTime] from [" + DBName + @"].[dbo].[tb_Product] as pro where  " + strWhere;
            DataSet ds = DataPageHelper.GetDataPage(DataPageHelper.GetPageSql(sql, pageindex.Value, rows, "id desc"), out iRecordCount);
            IEnumerable<tb_Product> list = TBToList<tb_Product>.ConvertToList(ds.Tables[0]).ToList();

            string UrlParameter = "&KeyWord=" + KeyWord + "&ClassId=" + ClassId + "&ClassName=" + ClassName;
            var viewData = new ModelViewData();
            int currentPage = pageindex ?? 1;
            viewData.CurrentPage = currentPage;
            viewData.PageSize = 10;
            viewData.tb_Product = list;
            viewData.RowCount = iRecordCount;
            viewData.PageName = "SelectProductThis";
            viewData.UrlParameter = UrlParameter;
            return View(viewData);
        }



        public ActionResult SelectProductType()
        {
            return View();
        }

        public ActionResult GetListProduct(int? page)
        {
            string KeyWord = DNTRequest.GetString("KeyWord");
            string ProductType = DNTRequest.GetString("ProductType");

            int rows = DNTRequest.GetInt("rows", 10);
            string strWhere = " 1=1 AND ProductStatus<>'淘汰'  ";
            if (KeyWord != "")
            {
                strWhere += " and (ProductName like '%" + KeyWord + "%'  or HHNo like '%" + KeyWord + "%' ) ";
            }

            if (ProductType != "")
            {
                strWhere += " and  ClassId in (SELECT id FROM [" + DBName + @"].[dbo].[f_ProductType_next] (" + Convert.ToInt32(ProductType) + ")) ";
            }
            int count = 0;


            string sql = @"select  [id]
                      ,[ProductName]
                      ,[ImgUrl]
                      ,[HHNo]
                      ,[GG]
                      ,[other]
                      ,[Unit]
                      ,[StockNum]
                      ,[MemberPrice]
                      ,[jinPrice]
                      ,[SalesPrice]
                      ,[MinPrice]
                      ,IsAllowChange
                      , CASE IsAllowChange WHEN 1 THEN '是' WHEN 0 THEN '否' ELSE '' END as  IsAllowChangeName
                      ,(SELECT [name] FROM  [" + DBName + @"].[dbo].[tb_ProductType] where id=pro.ClassId) as ClassName
                      ,[ClassCode]
                      ,[ProductSingeName]
                      ,[ProductJJ]
                      ,[BrandCode]
                      ,(SELECT [name] FROM  [" + DBName + @"].[dbo].[tb_ProductBrand] where id=pro.BrandId) as BrandName
                      ,[SupCode]
                      ,(SELECT [name] FROM  [" + DBName + @"].[dbo].[tb_PurchaseSupplier] where id=pro.SupId) as SupName 
                      ,[JinGG]
                      ,[ProductStatus]
                      ,[ProductType]
                      ,[JJWay]
                      ,[TJWay]
                      ,[TJPrice]
                      ,[Remark]
                      ,[AddTime] from [" + DBName + @"].[dbo].[tb_Product] as pro where  " + strWhere;
            DataSet ds = DataPageHelper.GetDataPage(DataPageHelper.GetPageSql(sql, page.Value, rows, "id desc"), out count);
            List<tb_Product> list = TBToList<tb_Product>.ConvertToList(ds.Tables[0]).ToList();
            var grid = new EasyuiDataGrid<List<tb_Product>>();
            grid.total = count;
            grid.rows = list;
            return Json(grid, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetAutoProductList(string keywords)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("select * from [" + DBName + @"].[dbo].[tb_Product]  ");
            sql.Append(" where  ProductStatus<>'淘汰'  AND HHNo like '%" + keywords + "%'");

            DataSet ds = DbHelperSQL.Query(sql.ToString());
            List<tb_Product> list = TBToList<tb_Product>.ConvertToList(ds.Tables[0]).ToList();
            List<tb_Product> listJson = new List<tb_Product>();
            foreach (tb_Product model in list.OrderBy(p => p.id))
            {
                model.Count = list.Count();
              
            }
            return Json(listJson, JsonRequestBehavior.AllowGet);
        }

        //生鲜类code=22
        public ActionResult GetAutoProductListNew(string keywords, int StoreId = 0)
        {
            StringBuilder sql = new StringBuilder();
         

            if (StoreId > 0)
            {
                sql.Append(@"select [id] ,[ProductName],[ImgUrl] ,[HHNo]  ,[goodscode] ,[GG]
                                  ,[other]
                                  ,[Unit]
                                  ,[MemberPrice]
                                  ,[jinPrice]
                                  ,[SalesPrice]
                                  ,[MinPrice]
                                  ,[IsAllowChange]
                                  ,[ClassId]
                                  ,[ClassCode]
                                  ,[ProductSingeName]
                                  ,[ProductJJ]
                                  ,[BrandCode]
                                  ,[BrandId]
                                  ,[SupCode]
                                  ,[SupId]
                                  ,[JinGG]
                                  ,[ProductStatus]
                                  ,[ProductType]
                                  ,[JJWay]
                                  ,[TJWay]
                                  ,[TJPrice]
                                  ,[Remark]
                                  ,[AddTime],(select top 1 StockNum  from [" + DBName + @"].[dbo].[View_SelectStock_Store_StockNum_Get]  where [ProductId]=p.id and StoreId='" + StoreId + "') as StockNum from [" + DBName + @"].[dbo].[tb_Product] as p  ");
                sql.Append(" where  ProductStatus<>'淘汰' AND  (HHNo like '%" + keywords + "%' or  ProductName like '%" + keywords + "%'  or ProductJJ  like '%" + keywords + "%')");

            }
            else
            {
                sql.Append("select * from [" + DBName + @"].[dbo].[tb_Product]  ");
                sql.Append(" where  ProductStatus<>'淘汰' AND  (HHNo like '%" + keywords + "%' or  ProductName like '%" + keywords + "%'  or ProductJJ  like '%" + keywords + "%')");
            }


            DataSet ds = DbHelperSQL.Query(sql.ToString());
            List<tb_Product> list = TBToList<tb_Product>.ConvertToList(ds.Tables[0]).ToList();
            List<tb_Product> listJson = new List<tb_Product>();
            foreach (tb_Product model in list.OrderBy(p => p.id))
            {
                model.Count = list.Count();
                if (keywords.Length>=2)
	            {
                    if (model.Count > 1 && keywords.Substring(0, 2) == "22")
                    {
                        model.Count = 1;
                    }
                    else if (model.Count==1)
                    {
                        if (model.HHNo.Length==13)
                        {
                            model.SumPrice = GetSumPrice(model.HHNo);
                            if (model.jinPrice > 0)
                            {
                                model.Num = model.SumPrice / model.jinPrice;
                            }
                        }
                    
                        listJson.Add(model);
                    }
		 
	            }
              
            }

         
            return Json(listJson, JsonRequestBehavior.AllowGet);
        }

        private decimal GetSumPrice(string hhNo)
        {
            string SumPrice = hhNo.Substring(7, 5);
            SumPrice = SumPrice.Substring(0, 3) + "." + SumPrice.Substring(3, 2);

            return Convert.ToDecimal(SumPrice);
        }

        public ActionResult GetProductList(string idlist, int StoreId=0)
        {
            StringBuilder sql = new StringBuilder();

            if (StoreId > 0)
            {
                sql.Append(@"select [id] ,[ProductName],[ImgUrl] ,[HHNo]  ,[goodscode] ,[GG]
                                  ,[other]
                                  ,[Unit]
                                  ,[MemberPrice]
                                  ,[jinPrice]
                                  ,[SalesPrice]
                                  ,[MinPrice]
                                  ,[IsAllowChange]
                                  ,[ClassId]
                                  ,[ClassCode]
                                  ,[ProductSingeName]
                                  ,[ProductJJ]
                                  ,[BrandCode]
                                  ,[BrandId]
                                  ,[SupCode]
                                  ,[SupId]
                                  ,[JinGG]
                                  ,[ProductStatus]
                                  ,[ProductType]
                                  ,[JJWay]
                                  ,[TJWay]
                                  ,[TJPrice]
                                  ,[Remark]
                                  ,[AddTime],(select top 1 StockNum  from [" + DBName + @"].[dbo].[View_SelectStock_Store_StockNum_Get]  where [ProductId]=p.id and StoreId='" + StoreId + "') as StockNum from [" + DBName + @"].[dbo].[tb_Product] as p  ");
                sql.Append(" where  ProductStatus<>'淘汰' AND  id in(" + idlist + ")");

            }
            else
            {
                sql.Append("select * from [" + DBName + @"].[dbo].[tb_Product]  ");
                sql.Append(" where  ProductStatus<>'淘汰' AND  id in(" + idlist + ")");
            }


            DataSet ds = DbHelperSQL.Query(sql.ToString());
            List<tb_Product> list = TBToList<tb_Product>.ConvertToList(ds.Tables[0]).ToList();
            List<tb_Product> listJson = new List<tb_Product>();
            foreach (tb_Product model in list.OrderBy(p => p.id))
            {
                model.Count = list.Count();
                listJson.Add(model);
            }
            return Json(listJson, JsonRequestBehavior.AllowGet);
        }
        
        public ActionResult GetHzPy(string value)
        {
            JsonModel jm = new JsonModel();


            object obj = DbHelperSQL.GetSingle(@" DECLARE @RC int
                                                 DECLARE @strName nvarchar(500)
                                                 DECLARE @ReturnStr nvarchar(500)
                                                 EXECUTE @RC = [dbo].[pGet_ZJM]  '" + value + @"',@ReturnStr OUTPUT ; SELECT @ReturnStr");
            if (obj != null)
            {
                jm.html = obj + "";
            }
            return Json(jm, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetGuidID()
        {
            JsonModel jm = new JsonModel();
            jm.html=Guid.NewGuid().ToString().Replace("-","");
            return Json(jm, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetStore()
        {
            string sql = @"select [id],[name] as text   from [" + DBName + @"].[dbo].tb_Store where  id in("+StoreId+")";
            DataSet ds = DbHelperSQL.Query(sql);
            List<tb_Store> list = TBToList<tb_Store>.ConvertToList(ds.Tables[0]).ToList();
            List<tb_Store> listJson = new List<tb_Store>();
            foreach (tb_Store model in list.OrderBy(p => p.id))
            {
                listJson.Add(model);
            }
            return Json(listJson, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetMemberType()
        {
            string sql = @"select [id],[name] as text   from [" + DBName + @"].[dbo].tb_MemberClass  ";
            DataSet ds = DbHelperSQL.Query(sql);
            List<tb_MemberClass> list = TBToList<tb_MemberClass>.ConvertToList(ds.Tables[0]).ToList();
            List<tb_MemberClass> listJson = new List<tb_MemberClass>();
            foreach (tb_MemberClass model in list.OrderBy(p => p.id))
            {
                listJson.Add(model);
            }
            return Json(listJson, JsonRequestBehavior.AllowGet);
        }

        
        
        public ActionResult GetListProductType(int? page)
        {
            string KeyWord = DNTRequest.GetString("KeyWord");

            int rows = DNTRequest.GetInt("rows", 10);
            string strWhere = " 1=1 ";
            if (KeyWord != "")
            {
                strWhere += " and (Name like '%" + KeyWord + "%'  or code like '%" + KeyWord + "% ') ";
            }
            int count = 0;
            string sql = @"select * from [" + DBName + @"].[dbo].[tb_ProductType] where  " + strWhere;
            DataSet ds = DataPageHelper.GetDataPage(DataPageHelper.GetPageSql(sql, page.Value, rows, "code asc"), out count);
            List<tb_ProductType> list = TBToList<tb_ProductType>.ConvertToList(ds.Tables[0]).ToList();
            var grid = new EasyuiDataGrid<List<tb_ProductType>>();
            grid.total = count;
            grid.rows = list;
            return Json(grid, JsonRequestBehavior.AllowGet);
        }


        public ActionResult GetIsLastLeval(int? ClassId)
        {
            JsonModel jm = new JsonModel();
            string sql = @"select id  from [" + DBName + @"].[dbo].[tb_ProductType] where ParentId='" + ClassId + "'";
            object obj = DbHelperSQL.GetSingle(sql);
            if (obj != null)
            {
                jm.count = 1;
            }
            else
            {
                jm.count = 0;
            }
            return Json(jm, JsonRequestBehavior.AllowGet);
        }

        


        public ActionResult SelectUser()
        {
            return View();
        }

        public ActionResult GetListUserList(int? page)
        {
            string KeyWord = DNTRequest.GetString("KeyWord");

            int rows = DNTRequest.GetInt("rows", 10);
            string strWhere = " 1=1 AND dbo.UserMaster.UserID in( Select UserID from  tb_UserManageStore where StoreId in (" + StoreId + ")) ";
            if (KeyWord != "")
            {
                strWhere += " and (UserName like '%" + KeyWord + "%' OR TrueName like '%" + KeyWord + "%' ) ";
            }
            int count = 0;
            string sql = @"SELECT     dbo.UserMaster.UserID, dbo.UserMaster.UserName, dbo.UserMaster.usercode, dbo.UserDetail.TrueName, dbo.UserMaster.StoreName
                        FROM         dbo.UserMaster INNER JOIN
                      dbo.UserDetail ON dbo.UserMaster.UserID = dbo.UserDetail.UserID    where  " + strWhere;
            DataSet ds = DataPageHelper.GetDataPage(DataPageHelper.GetPageSql(sql, page.Value, rows, "UserId desc"), out count);
            List<UserMaster> list = TBToList<UserMaster>.ConvertToList(ds.Tables[0]).ToList();
            var grid = new EasyuiDataGrid<List<UserMaster>>();
            grid.total = count;
            grid.rows = list;
            return Json(grid, JsonRequestBehavior.AllowGet);
        }


        public ActionResult SelectStore(int? type=0)
        {
            ViewBag.type = type;
            return View();
        }
        public ActionResult GetListStoreList(int? page)
        {
            string KeyWord = DNTRequest.GetString("KeyWord");

            int rows = DNTRequest.GetInt("rows", 10);
            string strWhere = " 1=1  AND   id in(" + StoreId + ") ";

            if (KeyWord != "")
            {
                strWhere += " and (Name like '%" + KeyWord + "%'  or code like '%" + KeyWord + "% ') ";
            }
            int count = 0;
            string sql = @"select * from [" + DBName + @"].[dbo].[tb_Store] where  " + strWhere;
            DataSet ds = DataPageHelper.GetDataPage(DataPageHelper.GetPageSql(sql, page.Value, rows, "id desc"), out count);
            List<tb_Store> list = TBToList<tb_Store>.ConvertToList(ds.Tables[0]).ToList();
            var grid = new EasyuiDataGrid<List<tb_Store>>();
            grid.total = count;
            grid.rows = list;
            return Json(grid, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetListStoreListMore(int? page)
        {
            string KeyWord = DNTRequest.GetString("KeyWord");

            int rows = DNTRequest.GetInt("rows", 10);
            string strWhere = " 1=1  ";

            if (KeyWord != "")
            {
                strWhere += " and (Name like '%" + KeyWord + "%'  or code like '%" + KeyWord + "% ') ";
            }
            int count = 0;
            string sql = @"select * from [" + DBName + @"].[dbo].[tb_Store] where  " + strWhere;
            DataSet ds = DataPageHelper.GetDataPage(DataPageHelper.GetPageSql(sql, page.Value, rows, "id desc"), out count);
            List<tb_Store> list = TBToList<tb_Store>.ConvertToList(ds.Tables[0]).ToList();
            var grid = new EasyuiDataGrid<List<tb_Store>>();
            grid.total = count;
            grid.rows = list;
            return Json(grid, JsonRequestBehavior.AllowGet);
        }
        

        public ActionResult SelectProductBrand()
        {
            return View();
        }

        public ActionResult GetListProductBrand(int? page)
        {
            string KeyWord = DNTRequest.GetString("KeyWord");

            int rows = DNTRequest.GetInt("rows", 10);
            string strWhere = " 1=1 ";
            if (KeyWord != "")
            {
                strWhere += " and (Name like '%" + KeyWord + "%'  or code like '%" + KeyWord + "%') ";
            }
            int count = 0;
            string sql = @"select * from [" + DBName + @"].[dbo].[tb_ProductBrand] where  " + strWhere;
            DataSet ds = DataPageHelper.GetDataPage(DataPageHelper.GetPageSql(sql, page.Value, rows, "id desc"), out count);
            List<tb_ProductBrand> list = TBToList<tb_ProductBrand>.ConvertToList(ds.Tables[0]).ToList();
            var grid = new EasyuiDataGrid<List<tb_ProductBrand>>();
            grid.total = count;
            grid.rows = list;
            return Json(grid, JsonRequestBehavior.AllowGet);
        }


        public ActionResult SelectPurchaseSupplier()
        {
            return View();
        }

        public ActionResult GetListPurchaseSupplier(int? page)
        {
            string KeyWord = DNTRequest.GetString("KeyWord");

            int rows = DNTRequest.GetInt("rows", 10);
            string strWhere = " 1=1 ";
            if (KeyWord != "")
            {
                strWhere += " and (Name like '%" + KeyWord + "%'  or code like '%" + KeyWord + "% ') ";
            }
            int count = 0;
            string sql = @"select * from [" + DBName + @"].[dbo].[tb_PurchaseSupplier] where  " + strWhere;
            DataSet ds = DataPageHelper.GetDataPage(DataPageHelper.GetPageSql(sql, page.Value, rows, "id desc"), out count);
            List<tb_PurchaseSupplier> list = TBToList<tb_PurchaseSupplier>.ConvertToList(ds.Tables[0]).ToList();
            var grid = new EasyuiDataGrid<List<tb_PurchaseSupplier>>();
            grid.total = count;
            grid.rows = list;
            return Json(grid, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetCommonCodeMemberClass(int id)
        {
            string result = "";
            JsonModel jm = new JsonModel();
            object obj = DbHelperSQL.GetSingle("select count(code) from [" + DBName + @"].[dbo].[tb_MemberClass] ");
            if (obj != null)
            {
                if (Convert.ToInt32(obj) > 0)
                {
                    string next = (Convert.ToInt32(obj) + 1).ToString();
                    if (next.Length == 1)
                    {
                        result = "0" + next;
                    }
                }
                else
                {
                    result = "01";
                }
            }

            jm.html = result;
            return Json(jm, JsonRequestBehavior.AllowGet);
        }

    }
}
