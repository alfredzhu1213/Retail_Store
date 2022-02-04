using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace Maticsoft.DAL
{
    /// <summary>
    /// 数据访问类:tb_PromotionPlanSheet
    /// </summary>
    public partial class tb_PromotionPlanSheetDAL
    {


        public string DBName = "";
        public tb_PromotionPlanSheetDAL(string db)
        {
            DBName = db;

        }
        #region  Method

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from [" + DBName + @"].[dbo].tb_PromotionPlanSheet");
            strSql.Append(" where id=" + id + " ");
            return DbHelperSQL.Exists(strSql.ToString());
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Maticsoft.Model.tb_PromotionPlanSheet model)
        {
            StringBuilder strSql = new StringBuilder();
            StringBuilder strSql1 = new StringBuilder();
            StringBuilder strSql2 = new StringBuilder();
            if (model.SerialNum != null)
            {
                strSql1.Append("SerialNum,");
                strSql2.Append("'" + model.SerialNum + "',");
            }
            if (model.Title != null)
            {
                strSql1.Append("Title,");
                strSql2.Append("'" + model.Title + "',");
            }
            if (model.StoreId != null)
            {
                strSql1.Append("StoreId,");
                strSql2.Append("" + model.StoreId + ",");
            }
            if (model.StoreCode != null)
            {
                strSql1.Append("StoreCode,");
                strSql2.Append("'" + model.StoreCode + "',");
            }
            if (model.PromotionStyles != null)
            {
                strSql1.Append("PromotionStyles,");
                strSql2.Append("'" + model.PromotionStyles + "',");
            }
            if (model.StartDate != null)
            {
                strSql1.Append("StartDate,");
                strSql2.Append("'" + model.StartDate + "',");
            }
            if (model.EndDate != null)
            {
                strSql1.Append("EndDate,");
                strSql2.Append("'" + model.EndDate + "',");
            }
            if (model.MemTypeCode != null)
            {
                strSql1.Append("MemTypeCode,");
                strSql2.Append("'" + model.MemTypeCode + "',");
            }
            if (model.MemTypeName != null)
            {
                strSql1.Append("MemTypeName,");
                strSql2.Append("'" + model.MemTypeName + "',");
            }
            if (model.EffectWeekList != null)
            {
                strSql1.Append("EffectWeekList,");
                strSql2.Append("'" + model.EffectWeekList + "',");
            }
            if (model.Remark != null)
            {
                strSql1.Append("Remark,");
                strSql2.Append("'" + model.Remark + "',");
            }
            if (model.CreateUserName != null)
            {
                strSql1.Append("CreateUserName,");
                strSql2.Append("'" + model.CreateUserName + "',");
            }
            if (model.CreateDate != null)
            {
                strSql1.Append("CreateDate,");
                strSql2.Append("'" + model.CreateDate + "',");
            }
            if (model.ApprUserName != null)
            {
                strSql1.Append("ApprUserName,");
                strSql2.Append("'" + model.ApprUserName + "',");
            }
            if (model.AppDate != null)
            {
                strSql1.Append("AppDate,");
                strSql2.Append("'" + model.AppDate + "',");
            }
            if (model.Status != null)
            {
                strSql1.Append("Status,");
                strSql2.Append("'" + model.Status + "',");
            }
            strSql.Append("insert into [" + DBName + @"].[dbo].tb_PromotionPlanSheet(");
            strSql.Append(strSql1.ToString().Remove(strSql1.Length - 1));
            strSql.Append(")");
            strSql.Append(" values (");
            strSql.Append(strSql2.ToString().Remove(strSql2.Length - 1));
            strSql.Append(")");
            strSql.Append(";select @@IDENTITY");
            object obj = DbHelperSQL.GetSingle(strSql.ToString());
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Maticsoft.Model.tb_PromotionPlanSheet model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update [" + DBName + @"].[dbo].tb_PromotionPlanSheet set ");
            if (model.SerialNum != null)
            {
                strSql.Append("SerialNum='" + model.SerialNum + "',");
            }
            else
            {
                strSql.Append("SerialNum= null ,");
            }
            if (model.Title != null)
            {
                strSql.Append("Title='" + model.Title + "',");
            }
            else
            {
                strSql.Append("Title= null ,");
            }
            if (model.StoreId != null)
            {
                strSql.Append("StoreId=" + model.StoreId + ",");
            }
            else
            {
                strSql.Append("StoreId= null ,");
            }
            if (model.StoreCode != null)
            {
                strSql.Append("StoreCode='" + model.StoreCode + "',");
            }
            else
            {
                strSql.Append("StoreCode= null ,");
            }
            if (model.PromotionStyles != null)
            {
                strSql.Append("PromotionStyles='" + model.PromotionStyles + "',");
            }
            else
            {
                strSql.Append("PromotionStyles= null ,");
            }
            if (model.StartDate != null)
            {
                strSql.Append("StartDate='" + model.StartDate + "',");
            }
            else
            {
                strSql.Append("StartDate= null ,");
            }
            if (model.EndDate != null)
            {
                strSql.Append("EndDate='" + model.EndDate + "',");
            }
            else
            {
                strSql.Append("EndDate= null ,");
            }
            if (model.MemTypeCode != null)
            {
                strSql.Append("MemTypeCode='" + model.MemTypeCode + "',");
            }
            else
            {
                strSql.Append("MemTypeCode= null ,");
            }
            if (model.MemTypeName != null)
            {
                strSql.Append("MemTypeName='" + model.MemTypeName + "',");
            }
            else
            {
                strSql.Append("MemTypeName= null ,");
            }
            if (model.EffectWeekList != null)
            {
                strSql.Append("EffectWeekList='" + model.EffectWeekList + "',");
            }
            else
            {
                strSql.Append("EffectWeekList= null ,");
            }
            if (model.Remark != null)
            {
                strSql.Append("Remark='" + model.Remark + "',");
            }
            else
            {
                strSql.Append("Remark= null ,");
            }
            if (model.CreateUserName != null)
            {
                strSql.Append("CreateUserName='" + model.CreateUserName + "',");
            }
            else
            {
                strSql.Append("CreateUserName= null ,");
            }
            if (model.CreateDate != null)
            {
                strSql.Append("CreateDate='" + model.CreateDate + "',");
            }
            else
            {
                strSql.Append("CreateDate= null ,");
            }
            if (model.ApprUserName != null)
            {
                strSql.Append("ApprUserName='" + model.ApprUserName + "',");
            }
            else
            {
                strSql.Append("ApprUserName= null ,");
            }
            if (model.AppDate != null)
            {
                strSql.Append("AppDate='" + model.AppDate + "',");
            }
            else
            {
                strSql.Append("AppDate= null ,");
            }
            if (model.Status != null)
            {
                strSql.Append("Status='" + model.Status + "',");
            }
            else
            {
                strSql.Append("Status= null ,");
            }
            int n = strSql.ToString().LastIndexOf(",");
            strSql.Remove(n, 1);
            strSql.Append(" where id=" + model.id + "");
            int rowsAffected = DbHelperSQL.ExecuteSql(strSql.ToString());
            if (rowsAffected > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from [" + DBName + @"].[dbo].tb_PromotionPlanSheet ");
            strSql.Append(" where id=" + id + "");
            int rowsAffected = DbHelperSQL.ExecuteSql(strSql.ToString());
            if (rowsAffected > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }		/// <summary>
        /// 批量删除数据
        /// </summary>
        public bool DeleteList(string idlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from [" + DBName + @"].[dbo].tb_PromotionPlanSheet ");
            strSql.Append(" where id in (" + idlist + ")  ");
            int rows = DbHelperSQL.ExecuteSql(strSql.ToString());
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Maticsoft.Model.tb_PromotionPlanSheet GetModel(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1  ");
            strSql.Append(" id,SerialNum,Title,StoreId,StoreCode,PromotionStyles,StartDate,EndDate,MemTypeCode,MemTypeName,EffectWeekList,Remark,CreateUserName,CreateDate,ApprUserName,AppDate,Status ");
            strSql.Append(" from [" + DBName + @"].[dbo].tb_PromotionPlanSheet ");
            strSql.Append(" where id=" + id + "");
            Maticsoft.Model.tb_PromotionPlanSheet model = new Maticsoft.Model.tb_PromotionPlanSheet();
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            if (ds.Tables[0].Rows.Count > 0)
            {
                return DataRowToModel(ds.Tables[0].Rows[0]);
            }
            else
            {
                return model;
            }
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Maticsoft.Model.tb_PromotionPlanSheet DataRowToModel(DataRow row)
        {
            Maticsoft.Model.tb_PromotionPlanSheet model = new Maticsoft.Model.tb_PromotionPlanSheet();
            if (row != null)
            {
                if (row["id"] != null && row["id"].ToString() != "")
                {
                    model.id = int.Parse(row["id"].ToString());
                }
                if (row["SerialNum"] != null)
                {
                    model.SerialNum = row["SerialNum"].ToString();
                }
                if (row["Title"] != null)
                {
                    model.Title = row["Title"].ToString();
                }
                if (row["StoreId"] != null && row["StoreId"].ToString() != "")
                {
                    model.StoreId = int.Parse(row["StoreId"].ToString());
                }
                if (row["StoreCode"] != null)
                {
                    model.StoreCode = row["StoreCode"].ToString();
                }
                if (row["PromotionStyles"] != null)
                {
                    model.PromotionStyles = row["PromotionStyles"].ToString();
                }
                if (row["StartDate"] != null && row["StartDate"].ToString() != "")
                {
                    model.StartDate = DateTime.Parse(row["StartDate"].ToString());
                }
                if (row["EndDate"] != null && row["EndDate"].ToString() != "")
                {
                    model.EndDate = DateTime.Parse(row["EndDate"].ToString());
                }
                if (row["MemTypeCode"] != null)
                {
                    model.MemTypeCode = row["MemTypeCode"].ToString();
                }
                if (row["MemTypeName"] != null)
                {
                    model.MemTypeName = row["MemTypeName"].ToString();
                }
                if (row["EffectWeekList"] != null)
                {
                    model.EffectWeekList = row["EffectWeekList"].ToString();
                }
                if (row["Remark"] != null)
                {
                    model.Remark = row["Remark"].ToString();
                }
                if (row["CreateUserName"] != null)
                {
                    model.CreateUserName = row["CreateUserName"].ToString();
                }
                if (row["CreateDate"] != null && row["CreateDate"].ToString() != "")
                {
                    model.CreateDate = DateTime.Parse(row["CreateDate"].ToString());
                }
                if (row["ApprUserName"] != null)
                {
                    model.ApprUserName = row["ApprUserName"].ToString();
                }
                if (row["AppDate"] != null && row["AppDate"].ToString() != "")
                {
                    model.AppDate = DateTime.Parse(row["AppDate"].ToString());
                }
                if (row["Status"] != null)
                {
                    model.Status = row["Status"].ToString();
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,SerialNum,Title,StoreId,StoreCode,PromotionStyles,StartDate,EndDate,MemTypeCode,MemTypeName,EffectWeekList,Remark,CreateUserName,CreateDate,ApprUserName,AppDate,Status ");
            strSql.Append(" FROM tb_PromotionPlanSheet ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" id,SerialNum,Title,StoreId,StoreCode,PromotionStyles,StartDate,EndDate,MemTypeCode,MemTypeName,EffectWeekList,Remark,CreateUserName,CreateDate,ApprUserName,AppDate,Status ");
            strSql.Append(" FROM [" + DBName + @"].[dbo].tb_PromotionPlanSheet ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM [" + DBName + @"].[dbo].tb_PromotionPlanSheet ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            object obj = DbHelperSQL.GetSingle(strSql.ToString());
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby);
            }
            else
            {
                strSql.Append("order by T.id desc");
            }
            strSql.Append(")AS Row, T.*  from [" + DBName + @"].[dbo].tb_PromotionPlanSheet T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /*
        */

        #endregion  Method
        #region  MethodEx

        #endregion  MethodEx
    }
}

