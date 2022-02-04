using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EduZY.Model;
using System.Data;

using Maticsoft.Model;
using Maticsoft.DBUtility;
using Entity;
using Common;
using System.Text;
using Base;

namespace EduZY.Web.Controllers.Admin.Product
{
    [SupportFilter]
    public class ProductController : BaseController
    {

        #region 产品分类
        public ActionResult ProductTypeList()
        {
            return View();
        }
        public ActionResult GetProductTypeList(int id = 0, string KeyWord = "")
        {
            int count = 0;
            string sql = "SELECT [id] ,[code] ,[name],[ParentId],[AddTime] FROM [" + DBName + "].[dbo].[tb_ProductType] ";
            string strWhere = " Where 1=1";
            if (KeyWord != "")
            {
                strWhere += " and ( id in ( select id from  [" + DBName + "].[dbo].[tb_ProductType] where code like '%" + KeyWord + "%' or name like '%" + KeyWord + "%' ) ";
                strWhere += "  or id in ( select ParentId from  [" + DBName + "].[dbo].[tb_ProductType] where code like '%" + KeyWord + "%' or name like '%" + KeyWord + "%' ) ) ";
            }
            sql = sql + strWhere;
            DataSet ds = DataPageHelper.GetDataPage(DataPageHelper.GetPageSql(sql, 1, 10000, "id desc"), out count);
            List<tb_ProductType> list = TBToList<tb_ProductType>.ConvertToList(ds.Tables[0]).ToList();
            //List<tb_ProductType> list = ef.tb_ProductType.Where(p => p.MenuID > 0).ToList();
            List<tb_ProductType> listJson = new List<tb_ProductType>();
            foreach (tb_ProductType model in list.Where(p => p.ParentId == 0).OrderBy(p => p.id))
            {
                MakeMenuJson(list, model, id);
                listJson.Add(model);
            }


            return Json(listJson, JsonRequestBehavior.AllowGet);
        }

        public void MakeMenuJson(List<tb_ProductType> list, tb_ProductType model, int id)
        {
            List<tb_ProductType> listJson = new List<tb_ProductType>();
            List<tb_ProductType> Temp = list.Where(p => p.ParentId == model.id).OrderBy(p => p.id).ToList();
            foreach (tb_ProductType model2 in Temp)
            {
                if (model2.id != id)
                    listJson.Add(model2);
            }
            model.children = listJson;
            foreach (tb_ProductType model2 in Temp)
            {
                if (model2.id != id)
                    MakeMenuJson(list, model2, id);
            }
        }
        public ActionResult GetProductComboTreeJson(int id = 0)
        {
            string sql = @"select [id],[code] ,[name] as text ,[ParentId]  from [" + DBName + @"].[dbo].tb_ProductType 
                        union all
                        select 0 [id], '根目录' code,'根目录' as text,-1 ParentId ";
            DataSet ds = DbHelperSQL.Query(sql);
            List<tb_ProductType> list = TBToList<tb_ProductType>.ConvertToList(ds.Tables[0]).ToList();
            List<tb_ProductType> listJson = new List<tb_ProductType>();
            foreach (tb_ProductType model in list.Where(p => p.id == 0).OrderBy(p => p.id))
            {
                MakeMenuJson(list, model, id);
                listJson.Add(model);

            }
            return Json(listJson, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult GetCommonCode(int id)
        {
            string result = "";
            JsonModel jm = new JsonModel();
            object obj1 = DbHelperSQL.GetSingle("select code from [" + DBName + @"].[dbo].[tb_ProductType] where id='" + id + "'");//第一次传入0 看看是否有编码
            if (obj1 != null)
            {
                object obj2 = DbHelperSQL.GetSingle("select count(code) from [" + DBName + @"].[dbo].[tb_ProductType] where ParentId='" + id + "'");
                if (obj2 != null)
                {
                    if (Convert.ToInt32(obj2) > 0)
                    {

                        string next = (Convert.ToInt32(obj2) + 1).ToString();
                        if (next.Length == 1)
                        {
                            result = "0" + next;
                        }
                      

                        result = obj1.ToString() + result;

                    }
                    else
                    {
                        result = obj1.ToString() + "01";
                    }
                }
            }
            else//传入0未找到就说是根目录
            {
                object obj = DbHelperSQL.GetSingle("select count(code) from [" + DBName + @"].[dbo].[tb_ProductType] where ParentId='0'");
                if (obj != null)
                {
                    if (Convert.ToInt32(obj) > 0)
                    {
                        string next = (Convert.ToInt32(obj) + 1).ToString();
                        if (next.Length == 1)
                        {
                            result = "0" + next ;
                        }
                       
                        else
                        {
                            result = next;
                        }
                    }
                    else
                    {
                        result = "01";
                    }
                }
            }
            jm.html = result;
            return Json(jm, JsonRequestBehavior.AllowGet);
        }
        public ActionResult saveInfo(tb_ProductType model)
        {
            zhxy_resEntities ef = new zhxy_resEntities();
            JsonModel jm = new JsonModel();
            try
            {
                jm.status = 1;
                int id = DNTRequest.GetInt("id", 0);
                int ParentId = DNTRequest.GetInt("ParentId", 0);
                model.AddTime = System.DateTime.Now;
                model.ParentId = ParentId;
                if (id == 0)
                {
                    StringBuilder strSql = new StringBuilder();
                    StringBuilder strSql1 = new StringBuilder();
                    StringBuilder strSql2 = new StringBuilder();
                    if (model.code != null)
                    {
                        strSql1.Append("code,");
                        strSql2.Append("'" + model.code + "',");
                    }
                    if (model.name != null)
                    {
                        strSql1.Append("name,");
                        strSql2.Append("'" + model.name + "',");
                    }
                    if (model.ParentId != null)
                    {
                        strSql1.Append("ParentId,");
                        strSql2.Append("" + model.ParentId + ",");
                    }
                    if (model.AddTime != null)
                    {
                        strSql1.Append("AddTime,");
                        strSql2.Append("'" + model.AddTime + "',");
                    }
                    strSql.Append("insert into [" + DBName + @"].[dbo].tb_ProductType(");
                    strSql.Append(strSql1.ToString().Remove(strSql1.Length - 1));
                    strSql.Append(")");
                    strSql.Append(" values (");
                    strSql.Append(strSql2.ToString().Remove(strSql2.Length - 1));
                    strSql.Append(")");
                    strSql.Append(";select @@IDENTITY");
                    object obj = DbHelperSQL.GetSingle(strSql.ToString());
                    jm.status = 1;
                }
                else
                {
                    StringBuilder strSql = new StringBuilder();
                    strSql.Append("update [" + DBName + @"].[dbo].tb_ProductType set ");
                    //if (model.code != null)
                    //{
                    //    strSql.Append("code='" + model.code + "',");
                    //}
                    //else
                    //{
                    //    strSql.Append("code= null ,");
                    //}
                    if (model.name != null)
                    {
                        strSql.Append("name='" + model.name + "',");
                    }
                    else
                    {
                        strSql.Append("name= null ,");
                    }
                    if (model.ParentId != null)
                    {
                        strSql.Append("ParentId=" + model.ParentId + ",");
                    }
                    else
                    {
                        strSql.Append("ParentId= null ,");
                    }
                    if (model.AddTime != null)
                    {
                        strSql.Append("AddTime='" + model.AddTime + "',");
                    }
                    else
                    {
                        strSql.Append("AddTime= null ,");
                    }
                    int n = strSql.ToString().LastIndexOf(",");
                    strSql.Remove(n, 1);
                    strSql.Append(" where id=" + model.id + "");
                    DbHelperSQL.ExecuteSql(strSql.ToString());
                    jm.status = 1;
                }


            }
            catch (Exception ex)
            {
                jm.status = 0; jm.msg = ex.Message;
            }
            return Json(jm, JsonRequestBehavior.AllowGet);
        }
        public ActionResult DelInfo(int id)
        {

            JsonModel jm = new JsonModel();
            try
            {

                if (DbHelperSQL.GetSingle("select id from [" + DBName + @"].[dbo].tb_ProductType where ParentId='" + id + "'") != null)
                {
                    jm.status = -1;
                    jm.msg = "存在子级，不能删除！";
                }
                else
                {
                    if (DbHelperSQL.GetSingle("select id from [" + DBName + @"].[dbo].tb_Product where ClassId='" + id + "'") != null)
                    {
                        jm.status = -1;
                        jm.msg = "数据已经商品档案被使用，不能删除！";
                    }
                    else
                    {

                        StringBuilder strSql = new StringBuilder();
                        strSql.Append("delete from [" + DBName + @"].[dbo].tb_ProductType ");
                        strSql.Append(" where id=" + id + "");
                        DbHelperSQL.ExecuteSql(strSql.ToString());
                        jm.status = 1;
                    }
                }
            }
            catch (Exception ex)
            {
                jm.status = 0; jm.msg = "数据已经被使用，不能删除！";
            }
            return Json(jm, JsonRequestBehavior.AllowGet);
        }
        #endregion
        #region 品牌管理

        public ActionResult ProductBrandList()
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
                strWhere += " and (code like '%" + KeyWord + "%'  or name like '%" + KeyWord + "%' ) ";
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

        [HttpPost]
        public JsonResult GetCommonCodeProductBrand(int id)
        {
            string result = "";
            JsonModel jm = new JsonModel();
            object obj = DbHelperSQL.GetSingle("select count(code) from [" + DBName + @"].[dbo].[tb_ProductBrand] ");
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
        public ActionResult saveInfoProductBrand(tb_ProductType model)
        {

            JsonModel jm = new JsonModel();
            try
            {
                jm.status = 1;
                int id = DNTRequest.GetInt("id", 0);
                model.AddTime = System.DateTime.Now;
                if (id == 0)
                {
                    StringBuilder strSql = new StringBuilder();
                    StringBuilder strSql1 = new StringBuilder();
                    StringBuilder strSql2 = new StringBuilder();
                    if (model.code != null)
                    {
                        strSql1.Append("code,");
                        strSql2.Append("'" + model.code + "',");
                    }
                    if (model.name != null)
                    {
                        strSql1.Append("name,");
                        strSql2.Append("'" + model.name + "',");
                    }
                    if (model.ParentId != null)
                    {
                        strSql1.Append("ParentId,");
                        strSql2.Append("" + model.ParentId + ",");
                    }
                    if (model.AddTime != null)
                    {
                        strSql1.Append("AddTime,");
                        strSql2.Append("'" + model.AddTime + "',");
                    }
                    strSql.Append("insert into [" + DBName + @"].[dbo].tb_ProductBrand(");
                    strSql.Append(strSql1.ToString().Remove(strSql1.Length - 1));
                    strSql.Append(")");
                    strSql.Append(" values (");
                    strSql.Append(strSql2.ToString().Remove(strSql2.Length - 1));
                    strSql.Append(")");
                    strSql.Append(";select @@IDENTITY");
                    object obj = DbHelperSQL.GetSingle(strSql.ToString());
                    jm.status = 1;
                }
                else
                {
                    StringBuilder strSql = new StringBuilder();
                    strSql.Append("update [" + DBName + @"].[dbo].tb_ProductBrand set ");
                    //if (model.code != null)
                    //{
                    //    strSql.Append("code='" + model.code + "',");
                    //}
                    //else
                    //{
                    //    strSql.Append("code= null ,");
                    //}
                    if (model.name != null)
                    {
                        strSql.Append("name='" + model.name + "',");
                    }
                    else
                    {
                        strSql.Append("name= null ,");
                    }

                    if (model.AddTime != null)
                    {
                        strSql.Append("AddTime='" + model.AddTime + "',");
                    }
                    else
                    {
                        strSql.Append("AddTime= null ,");
                    }
                    int n = strSql.ToString().LastIndexOf(",");
                    strSql.Remove(n, 1);
                    strSql.Append(" where id=" + model.id + "");
                    DbHelperSQL.ExecuteSql(strSql.ToString());
                    jm.status = 1;
                }


            }
            catch (Exception ex)
            {
                jm.status = 0; jm.msg = ex.Message;
            }
            return Json(jm, JsonRequestBehavior.AllowGet);
        }
        public ActionResult DelInfoProductBrand(int id)
        {

            JsonModel jm = new JsonModel();
            try
            {
                jm.status = 1;
                StringBuilder strSql = new StringBuilder();
                strSql.Append("delete from [" + DBName + @"].[dbo].tb_ProductBrand");
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
        #region 单位管理

        public ActionResult ProductUnitList()
        {
            return View();
        }

        public ActionResult GetListProductUnit(int? page)
        {
            string KeyWord = DNTRequest.GetString("KeyWord");

            int rows = DNTRequest.GetInt("rows", 10);
            string strWhere = " 1=1 ";
            if (KeyWord != "")
            {
                strWhere += " and (code like '%" + KeyWord + "%'  or name like '%" + KeyWord + "% ) ";
            }
            int count = 0;
            string sql = @"select * from [" + DBName + @"].[dbo].[tb_ProductUnit] where  " + strWhere;
            DataSet ds = DataPageHelper.GetDataPage(DataPageHelper.GetPageSql(sql, page.Value, rows, "code desc"), out count);
            List<tb_ProductUnit> list = TBToList<tb_ProductUnit>.ConvertToList(ds.Tables[0]).ToList();
            var grid = new EasyuiDataGrid<List<tb_ProductUnit>>();
            grid.total = count;
            grid.rows = list;
            return Json(grid, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult GetCommonCodeProductUnit(int id)
        {
            string result = "";
            JsonModel jm = new JsonModel();
            object obj = DbHelperSQL.GetSingle("select count(code) from [" + DBName + @"].[dbo].[tb_ProductUnit] ");
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
        public ActionResult saveInfoProductUnit(tb_ProductType model)
        {

            JsonModel jm = new JsonModel();
            try
            {
                jm.status = 1;
                int id = DNTRequest.GetInt("id", 0);
                model.AddTime = System.DateTime.Now;
                if (id == 0)
                {
                    StringBuilder strSql = new StringBuilder();
                    StringBuilder strSql1 = new StringBuilder();
                    StringBuilder strSql2 = new StringBuilder();
                    if (model.code != null)
                    {
                        strSql1.Append("code,");
                        strSql2.Append("'" + model.code + "',");
                    }
                    if (model.name != null)
                    {
                        strSql1.Append("name,");
                        strSql2.Append("'" + model.name + "',");
                    }
                    if (model.ParentId != null)
                    {
                        strSql1.Append("ParentId,");
                        strSql2.Append("" + model.ParentId + ",");
                    }
                    if (model.AddTime != null)
                    {
                        strSql1.Append("AddTime,");
                        strSql2.Append("'" + model.AddTime + "',");
                    }
                    strSql.Append("insert into [" + DBName + @"].[dbo].tb_ProductUnit(");
                    strSql.Append(strSql1.ToString().Remove(strSql1.Length - 1));
                    strSql.Append(")");
                    strSql.Append(" values (");
                    strSql.Append(strSql2.ToString().Remove(strSql2.Length - 1));
                    strSql.Append(")");
                    strSql.Append(";select @@IDENTITY");
                    object obj = DbHelperSQL.GetSingle(strSql.ToString());
                    jm.status = 1;
                }
                else
                {
                    StringBuilder strSql = new StringBuilder();
                    strSql.Append("update [" + DBName + @"].[dbo].tb_ProductUnit set ");
                    //if (model.code != null)
                    //{
                    //    strSql.Append("code='" + model.code + "',");
                    //}
                    //else
                    //{
                    //    strSql.Append("code= null ,");
                    //}
                    if (model.name != null)
                    {
                        strSql.Append("name='" + model.name + "',");
                    }
                    else
                    {
                        strSql.Append("name= null ,");
                    }

                    if (model.AddTime != null)
                    {
                        strSql.Append("AddTime='" + model.AddTime + "',");
                    }
                    else
                    {
                        strSql.Append("AddTime= null ,");
                    }
                    int n = strSql.ToString().LastIndexOf(",");
                    strSql.Remove(n, 1);
                    strSql.Append(" where id=" + model.id + "");
                    DbHelperSQL.ExecuteSql(strSql.ToString());
                    jm.status = 1;
                }


            }
            catch (Exception ex)
            {
                jm.status = 0; jm.msg = ex.Message;
            }
            return Json(jm, JsonRequestBehavior.AllowGet);
        }
        public ActionResult DelInfoProductUnit(int id)
        {

            JsonModel jm = new JsonModel();
            try
            {
                jm.status = 1;
                StringBuilder strSql = new StringBuilder();
                strSql.Append("delete from [" + DBName + @"].[dbo].tb_ProductUnit");
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
        #region 商品档案管理


        public ActionResult ProductBarCode()
        {
        
            return View();
        }

        public ActionResult ProductList()
        {
            return View();
        }
        public ActionResult GetListProduct(int? page)
        {
            string KeyWord = DNTRequest.GetString("KeyWord");

            int rows = DNTRequest.GetInt("rows", 10);
            string strWhere = " 1=1 ";

            string ProductType = DNTRequest.GetString("ProductType");
            string ClassId = DNTRequest.GetString("ClassId");
            string BrandId = DNTRequest.GetString("BrandId");
            string SupId = DNTRequest.GetString("SupId");
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
       

        public ActionResult ProductAddEdit(int id=0)
        {
            Maticsoft.DAL.tb_ProductDAL bll = new Maticsoft.DAL.tb_ProductDAL(DBName);
            Maticsoft.Model.tb_Product model = new tb_Product();
            if (id>0)
            {
               
		        model=bll.GetModel(id);

                string barcodelist = "";
                DataSet ds = DbHelperSQL.Query("SELECT [barcode] FROM [" + DBName + @"].[dbo].[tb_ProductBarCode] where ProductId='" + model.id + "' ");
                foreach(DataRow dr in  ds.Tables[0].Rows)
                {
                    barcodelist += dr["barcode"] + ",";
                }
                model.barcodelist = barcodelist.TrimEnd(',');
                model.BrandName = DbHelperSQL.GetSingle("SELECT [name] FROM [" + DBName + @"].[dbo].[tb_ProductBrand] where id='"+model.BrandId+"' ") + "";
                model.SupName = DbHelperSQL.GetSingle("SELECT [name] FROM [" + DBName + @"].[dbo].[tb_PurchaseSupplier] where id='" + model.SupId + "' ") + "";
                model.ClassName = DbHelperSQL.GetSingle("SELECT [name] FROM [" + DBName + @"].[dbo].[tb_ProductType] where id='" + model.ClassId + "' ") + "";
            }
            model.unitlist = bll.GetUintList(model.Unit);

            return View(model);
        }
        
        [HttpPost]
        public ActionResult saveInfoProduct(tb_Product model)
        {

            JsonModel jm = new JsonModel();
            try
            {
                Maticsoft.DAL.tb_ProductDAL bll = new Maticsoft.DAL.tb_ProductDAL(DBName);

                jm.status = 1;
                int id = DNTRequest.GetInt("id", 0);
                string IsAllowChange = Request["IsAllowChange"];
                if (IsAllowChange == "on")
                {
                    model.IsAllowChange = 1;
                }
                else 
                {
                    model.IsAllowChange = 0;
                }
                string StatusGroup = Request["StatusGroup"];


                if (id == 0)
                {
                    int ReturnValue=bll.Add(model);

                    Maticsoft.DAL.tb_ProductBarCodeDAL bll1 = new Maticsoft.DAL.tb_ProductBarCodeDAL(DBName);
                    if (!string.IsNullOrEmpty(model.barcodelist))
                    {
                        foreach (string t in model.barcodelist.Split(','))
                        {
                            Maticsoft.Model.tb_ProductBarCode mode1 = new Maticsoft.Model.tb_ProductBarCode();
                            mode1.ProductId = ReturnValue;
                            mode1.barcode = t;
                            bll1.Add(mode1);
                        }
                    }
                    jm.status = 1;
                }
                else
                {
                    bll.Update(model);


                    DbHelperSQL.GetSingle("delete [" + DBName + @"].[dbo].tb_ProductBarCode where ProductId='" + model.id + "' ");
                    Maticsoft.DAL.tb_ProductBarCodeDAL bll1 = new Maticsoft.DAL.tb_ProductBarCodeDAL(DBName);
                    if (!string.IsNullOrEmpty(model.barcodelist))
                    {
                        foreach (string t in model.barcodelist.Split(','))
                        {
                            Maticsoft.Model.tb_ProductBarCode mode1 = new Maticsoft.Model.tb_ProductBarCode();
                            mode1.ProductId = model.id;
                            mode1.barcode = t;
                            bll1.Add(mode1);
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
        public ActionResult DelInfoProduct(int id)
        {

            JsonModel jm = new JsonModel();
            try
            {
                jm.status = 1;
                StringBuilder strSql = new StringBuilder();
                strSql.Append("delete from [" + DBName + @"].[dbo].tb_Product");
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
        #region tb_Store
        public ActionResult StoreList()
        {
            return View();
        }

        public ActionResult GetListtb_Store(int? page)
        {
            string KeyWord = DNTRequest.GetString("KeyWord");

            int rows = DNTRequest.GetInt("rows", 10);
            string strWhere = " 1=1 ";
            if (KeyWord != "")
            {
                strWhere += " and (Name like '%" + KeyWord + "%'  or code like '%" + KeyWord + "%') ";
            }
            int count = 0;

            string sql = @"select   *  from [" + DBName + @"].[dbo].[tb_Store]  where  " + strWhere;
            DataSet ds = DataPageHelper.GetDataPage(DataPageHelper.GetPageSql(sql, page.Value, rows, "id desc"), out count);
            List<tb_Store> list = TBToList<tb_Store>.ConvertToList(ds.Tables[0]).ToList();
            var grid = new EasyuiDataGrid<List<tb_Store>>();
            grid.total = count;
            grid.rows = list;
            return Json(grid, JsonRequestBehavior.AllowGet);
        }



        public ActionResult savetb_Store(tb_Store model)
        {
            JsonModel jm = new JsonModel();
            try
            {
                Maticsoft.DAL.tb_StoreDAL bll = new Maticsoft.DAL.tb_StoreDAL(DBName);
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
        public ActionResult Deltb_Store(int id)
        {

            JsonModel jm = new JsonModel();
            try
            {
                jm.status = 1;
                StringBuilder strSql = new StringBuilder();
                strSql.Append("delete from [" + DBName + @"].[dbo].tb_Store ");
                strSql.Append(" where id=" + id + "");
                DbHelperSQL.ExecuteSql(strSql.ToString());

            }
            catch (Exception ex)
            {
                jm.status = 0; jm.msg = ex.Message;
            }
            return Json(jm, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GetCommonCodeStore(int id)
        {
            string result = "";
            JsonModel jm = new JsonModel();
            object obj = DbHelperSQL.GetSingle("select count(code) from [" + DBName + @"].[dbo].[tb_Store] ");
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
        #endregion

    }
}
