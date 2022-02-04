using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Base;
using Entity;
using System.Text;
using Maticsoft.DBUtility;
using Maticsoft.Model;
using Common;
using System.Data;
using Maticsoft.DAL;
using System.Data.SqlClient;

namespace EduZY.Web.Controllers.Admin.Member
{
    [SupportFilter]
    public class MemberController : BaseController
    {
        public ActionResult ScoreExchange()
        {
            return View();
        }
        

        #region tb_MemberClass
        public ActionResult MemberCategory()
        {
            return View();
        }

        public ActionResult GetListtb_MemberClass(int? page)
        {
            string KeyWord = DNTRequest.GetString("KeyWord");

            int rows = DNTRequest.GetInt("rows", 10);
            string strWhere = " 1=1 ";
            if (KeyWord != "")
            {
                strWhere += " and (Name like '%" + KeyWord + "%'  or code like '%" + KeyWord + "% ') ";
            }
            int count = 0;

            string sql = @"select  * from [" + DBName + @"].[dbo].[tb_MemberClass]  where  " + strWhere;
            DataSet ds = DataPageHelper.GetDataPage(DataPageHelper.GetPageSql(sql, page.Value, rows, "id desc"), out count);
            List<tb_MemberClass> list = TBToList<tb_MemberClass>.ConvertToList(ds.Tables[0]).ToList();
            var grid = new EasyuiDataGrid<List<tb_MemberClass>>();
            grid.total = count;
            grid.rows = list;
            return Json(grid, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetScoreExchange(int? page)
        {
            string KeyWord = DNTRequest.GetString("KeyWord");

            int rows = DNTRequest.GetInt("rows", 10);
            string strWhere = " 1=1 ";
            if (KeyWord != "")
            {
                strWhere += " and ( code = '" + KeyWord.Trim()+ "') ";
            }
            int count = 0;

            string sql = @"select  * from [" + DBName + @"].[dbo].[tb_MemberClass]  where  " + strWhere;
            DataSet ds = DataPageHelper.GetDataPage(DataPageHelper.GetPageSql(sql, page.Value, rows, "id desc"), out count);
            List<tb_MemberClass> list = TBToList<tb_MemberClass>.ConvertToList(ds.Tables[0]).ToList();
            var grid = new EasyuiDataGrid<List<tb_MemberClass>>();
            grid.total = count;
            grid.rows = list;
       
            return Json(grid, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public ActionResult GetMemberModel(string KeyWord="")
        {

           Maticsoft.DAL.tb_MemberDAL dal = new Maticsoft.DAL.tb_MemberDAL(DBName);
           tb_Member model = new tb_Member();
           model = dal.GetModeltb_Member(KeyWord);
           if (string.IsNullOrEmpty(model.CardCode))
           {
               model.Result = 0;
           }
           else
           {
               model.Result = 1;
           }
           
            return Json(model, JsonRequestBehavior.AllowGet);

        }

        [HttpPost]
        public ActionResult GetMemberDuiHuan(int? id = 0, int IntegralNum = 0, int userId = 0)
        {
            JsonModel jm = new JsonModel();


            object str = DbHelperSQL.GetSingle(@"DECLARE @RC int;EXECUTE @RC = [" + DBName + @"].[dbo].[T_UserJfRecord_ADD] 
                          " +userId+@"
                          ,1
                          ," + id.Value + @"
                          ," + IntegralNum + @"
                          ,N'礼品兑换' ; Select @RC"); 
            switch (str.ToString())
            { 
                case "1":
                    jm.msg ="兑换成功";
                    break;
                case "-1":
                    jm.msg = "积分不足";
                    break;
                default:
                    jm.msg = "积分失败";
                    break;
            }

            return Json(jm, JsonRequestBehavior.AllowGet);
        }

        //public string T_UserJfRecord_ADD(int UserId, string type, int OrderId, int Score, string Remark)
        //{
        //    int rowsAffected;
        //    SqlParameter[] parameters = {			 
        //                 new SqlParameter("@UserId", SqlDbType.VarChar,50), 
        //                 new SqlParameter("@type", SqlDbType.VarChar,50), 
        //                 new SqlParameter("@OrderId", SqlDbType.VarChar,50), 
        //                 new SqlParameter("@Score", SqlDbType.Int,4), 
        //                 new SqlParameter("@Remark", SqlDbType.VarChar,5000) 
        //                 };
        //    parameters[0].Value = UserId;
        //    parameters[1].Value = type;
        //    parameters[2].Value = OrderId;
        //    parameters[3].Value = Score;
        //    parameters[4].Value = Remark;
        //    return DbHelperSQL.RunProcedure("[" + DBName + @"].[dbo].[T_UserJfRecord_ADD] ", parameters, out rowsAffected).ToString();

        //}
        public ActionResult savetb_MemberClass(tb_MemberClass model)
        {

            JsonModel jm = new JsonModel();
            try
            {
                Maticsoft.DAL.tb_MemberClassDAL bll = new Maticsoft.DAL.tb_MemberClassDAL(DBName);
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
        public ActionResult Deltb_MemberClass(int id)
        {

            JsonModel jm = new JsonModel();
            try
            {
                jm.status = 1;
                StringBuilder strSql = new StringBuilder();
                strSql.Append("delete from [" + DBName + @"].[dbo].tb_MemberClass ");
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

        #region tb_Member
        public ActionResult MemberInfo()
        {
            return View();
        }

        public ActionResult GetListtb_Member(int? page)
        {
            string KeyWord = DNTRequest.GetString("KeyWord");

            int rows = DNTRequest.GetInt("rows", 10);
            string strWhere = " 1=1 ";
            if (KeyWord != "")
            {
                strWhere += " and (CardCode like '%" + KeyWord + "%'  or code like '%" + KeyWord + "% ') ";
            }
            int count = 0;

            string sql = @"select  * from [" + DBName + @"].[dbo].[tb_Member]  where  " + strWhere;
            DataSet ds = DataPageHelper.GetDataPage(DataPageHelper.GetPageSql(sql, page.Value, rows, "id desc"), out count);
            List<tb_Member> list = TBToList<tb_Member>.ConvertToList(ds.Tables[0]).ToList();
            var grid = new EasyuiDataGrid<List<tb_Member>>();
            grid.total = count;
            grid.rows = list;
            return Json(grid, JsonRequestBehavior.AllowGet);
        }



        public ActionResult savetb_Member(tb_Member model)
        {

            JsonModel jm = new JsonModel();
            try
            {
                Maticsoft.DAL.tb_MemberDAL bll = new Maticsoft.DAL.tb_MemberDAL(DBName);
                jm.status = 1;
                int id = DNTRequest.GetInt("id", 0);

                model.MemberTypeName = DbHelperSQL.GetSingle("SELECT [name] FROM [" + DBName + @"].[dbo].[tb_MemberClass] where [id]='" + model.MemberTypeId + "'")+"";
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
        public ActionResult Deltb_Member(int id)
        {

            JsonModel jm = new JsonModel();
            try
            {
                jm.status = 1;
                StringBuilder strSql = new StringBuilder();
                strSql.Append("delete from [" + DBName + @"].[dbo].tb_Member ");
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
        #region tb_MemberIntegralSet
        public ActionResult ScoreSetting()
        {
            Maticsoft.Model.tb_MemberIntegralSet model = new tb_MemberIntegralSet();
            tb_MemberIntegralSetDAL bll = new tb_MemberIntegralSetDAL(DBName);
            model = bll.GetModel(1);
            return View(model);
      
        }

        public ActionResult GetListtb_MemberIntegralSet(int? page)
        {
            string KeyWord = DNTRequest.GetString("KeyWord");

            int rows = DNTRequest.GetInt("rows", 10);
            string strWhere = " 1=1 ";
            if (KeyWord != "")
            {
                strWhere += " and (Name like '%" + KeyWord + "%'  or code like '%" + KeyWord + "% ') ";
            }
            int count = 0;

            string sql = @"select  * from [" + DBName + @"].[dbo].[tb_MemberIntegralSet]  where  " + strWhere;
            DataSet ds = DataPageHelper.GetDataPage(DataPageHelper.GetPageSql(sql, page.Value, rows, "id desc"), out count);
            List<tb_MemberIntegralSet> list = TBToList<tb_MemberIntegralSet>.ConvertToList(ds.Tables[0]).ToList();
            var grid = new EasyuiDataGrid<List<tb_MemberIntegralSet>>();
            grid.total = count;
            grid.rows = list;
            return Json(grid, JsonRequestBehavior.AllowGet);
        }



        public ActionResult savetb_MemberIntegralSet(tb_MemberIntegralSet model)
        {

            JsonModel jm = new JsonModel();
            try
            {
                Maticsoft.DAL.tb_MemberIntegralSetDAL bll = new Maticsoft.DAL.tb_MemberIntegralSetDAL(DBName);
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
        public ActionResult Deltb_MemberIntegralSet(int id)
        {

            JsonModel jm = new JsonModel();
            try
            {
                jm.status = 1;
                StringBuilder strSql = new StringBuilder();
                strSql.Append("delete from [" + DBName + @"].[dbo].tb_MemberIntegralSet ");
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

        #region tb_MemberGift
        public ActionResult Gift()
        {
            return View();
        }

        public ActionResult GetListtb_MemberGift(int? page)
        {
            string KeyWord = DNTRequest.GetString("KeyWord");

            int rows = DNTRequest.GetInt("rows", 10);
            string strWhere = " 1=1 ";
            if (KeyWord != "")
            {
                strWhere += " and (Name like '%" + KeyWord + "%'  or code like '%" + KeyWord + "% ') ";
            }
            int count = 0;

            string sql = @"select  * from [" + DBName + @"].[dbo].[tb_MemberGift]  where  " + strWhere;
            DataSet ds = DataPageHelper.GetDataPage(DataPageHelper.GetPageSql(sql, page.Value, rows, "id desc"), out count);
            List<tb_MemberGift> list = TBToList<tb_MemberGift>.ConvertToList(ds.Tables[0]).ToList();
            var grid = new EasyuiDataGrid<List<tb_MemberGift>>();
            grid.total = count;
            grid.rows = list;
            return Json(grid, JsonRequestBehavior.AllowGet);
        }



        public ActionResult savetb_MemberGift(tb_MemberGift model)
        {

            JsonModel jm = new JsonModel();
            try
            {
                Maticsoft.DAL.tb_MemberGiftDAL bll = new Maticsoft.DAL.tb_MemberGiftDAL(DBName);
                jm.status = 1;
                int id = DNTRequest.GetInt("id", 0);
              
                if (id == 0)
                {
                    model.CreateDate = DateTime.Now;
                    model.CreateUserName = CurrentUserName;
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
        public ActionResult Deltb_MemberGift(int id)
        {

            JsonModel jm = new JsonModel();
            try
            {
                jm.status = 1;
                StringBuilder strSql = new StringBuilder();
                strSql.Append("delete from [" + DBName + @"].[dbo].tb_MemberGift ");
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

        public ActionResult RptMemberConsumptionDetail()
        {
            return View();
        }


        #region tb_MembersSpendingDetail
        public ActionResult tb_MembersSpendingDetailList()
        {
            return View();
        }

        public ActionResult GetListtb_MembersSpendingDetail(int? page)
        {
            string KeyWord = DNTRequest.GetString("KeyWord");

            int rows = DNTRequest.GetInt("rows", 10);
            string strWhere = " 1=1 ";
            if (KeyWord != "")
            {
                strWhere += " and (Name like '%" + KeyWord + "%'  or code like '%" + KeyWord + "% ') ";
            }
            int count = 0;

            string sql = @"select  * from [" + DBName + @"].[dbo].[tb_MembersSpendingDetail]  where  " + strWhere;
            DataSet ds = DataPageHelper.GetDataPage(DataPageHelper.GetPageSql(sql, page.Value, rows, "id desc"), out count);
            List<tb_MembersSpendingDetail> list = TBToList<tb_MembersSpendingDetail>.ConvertToList(ds.Tables[0]).ToList();
            var grid = new EasyuiDataGrid<List<tb_MembersSpendingDetail>>();
            grid.total = count;
            grid.rows = list;
            return Json(grid, JsonRequestBehavior.AllowGet);
        }



  
        #endregion

        #region View_SelectJfList
        public ActionResult RptMemberScoreDetail()
        {
            return View();
        }

        public ActionResult GetListView_SelectJfList(int? page)
        {
            string KeyWord = DNTRequest.GetString("KeyWord");

            int rows = DNTRequest.GetInt("rows", 10);
            string strWhere = " 1=1 ";
            if (KeyWord != "")
            {
                strWhere += " and (Name like '%" + KeyWord + "%'  or code like '%" + KeyWord + "% ') ";
            }
            int count = 0;

            string sql = @"select  * from [" + DBName + @"].[dbo].[View_SelectJfList]  where  " + strWhere;
            DataSet ds = DataPageHelper.GetDataPage(DataPageHelper.GetPageSql(sql, page.Value, rows, "GoldId "), out count);
            List<View_SelectJfList> list = TBToList<View_SelectJfList>.ConvertToList(ds.Tables[0]).ToList();
            var grid = new EasyuiDataGrid<List<View_SelectJfList>>();
            grid.total = count;
            grid.rows = list;
            return Json(grid, JsonRequestBehavior.AllowGet);
        }


        #endregion

  

    }
}
