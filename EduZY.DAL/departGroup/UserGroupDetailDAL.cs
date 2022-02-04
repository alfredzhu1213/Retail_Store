using System;
using System.Collections.Generic;
using System.Text;
using Maticsoft.DBUtility;
using System.Data.SqlClient;
using System.Data;

namespace EduZY.DAL.departGroup
{
    /// <summary>
    /// 数据访问类:UserGroupDetail
    /// </summary>
    public partial class UserGroupDetailDAL
    {
        public UserGroupDetailDAL()
        { }
        #region  BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("UserGroupID", "UserGroupDetail");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int UserGroupID, int UnitID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from UserGroupDetail");
            strSql.Append(" where UserGroupID=@UserGroupID and UnitID=@UnitID ");
            SqlParameter[] parameters = {
					new SqlParameter("@UserGroupID", SqlDbType.Int,4),
					new SqlParameter("@UnitID", SqlDbType.Int,4)			};
            parameters[0].Value = UserGroupID;
            parameters[1].Value = UnitID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(EduZY.Model.departGroup.UserGroupDetail model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into UserGroupDetail(");
            strSql.Append("UserGroupID,UnitID,OrderNo,AddTime)");
            strSql.Append(" values (");
            strSql.Append("@UserGroupID,@UnitID,@OrderNo,@AddTime)");
            SqlParameter[] parameters = {
					new SqlParameter("@UserGroupID", SqlDbType.Int,4),
					new SqlParameter("@UnitID", SqlDbType.Int,4),
					new SqlParameter("@OrderNo", SqlDbType.Int,4),
					new SqlParameter("@AddTime", SqlDbType.DateTime)};
            parameters[0].Value = model.UserGroupID;
            parameters[1].Value = model.UnitID;
            parameters[2].Value = model.OrderNo;
            parameters[3].Value = model.AddTime;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
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
        /// 增加一条数据
        /// </summary>
        public bool AddList(EduZY.Model.departGroup.UserGroupDetail model)
        {

            if (model.groupDepartlist.Trim() != "")
            {
                foreach (string UnitID in model.groupDepartlist.Split(','))
                {
                    EduZY.Model.departGroup.UserGroupDetail dmodel = new Model.departGroup.UserGroupDetail();
                    if (!Exists(Convert.ToInt32(model.UserGroupID), Convert.ToInt32(UnitID)))
                    {
                        dmodel.AddTime = DateTime.Now;
                        dmodel.UnitID = Convert.ToInt32(UnitID);
                        dmodel.OrderNo = 1;
                        dmodel.UserGroupID = Convert.ToInt32(model.UserGroupID);
                        Add(dmodel);
                    }

                }
            }
            return true;
          
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(EduZY.Model.departGroup.UserGroupDetail model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update UserGroupDetail set ");
            strSql.Append("OrderNo=@OrderNo,");
            strSql.Append("AddTime=@AddTime");
            strSql.Append(" where UserGroupID=@UserGroupID and UnitID=@UnitID ");
            SqlParameter[] parameters = {
					new SqlParameter("@OrderNo", SqlDbType.Int,4),
					new SqlParameter("@AddTime", SqlDbType.DateTime),
					new SqlParameter("@UserGroupID", SqlDbType.Int,4),
					new SqlParameter("@UnitID", SqlDbType.Int,4)};
            parameters[0].Value = model.OrderNo;
            parameters[1].Value = model.AddTime;
            parameters[2].Value = model.UserGroupID;
            parameters[3].Value = model.UnitID;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool DeleteList(string UserGroupIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from UserGroupDetail ");
            strSql.Append(" where UserGroupID in (" + UserGroupIDlist + ")  ");
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
        /// 删除一条数据
        /// </summary>
        public bool Delete(int UserGroupID, string UnitID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from UserGroupDetail ");
            strSql.Append(" where UserGroupID=@UserGroupID and UnitID in(" + UnitID + ")");
            SqlParameter[] parameters = {
					new SqlParameter("@UserGroupID", SqlDbType.Int,4)};
            parameters[0].Value = UserGroupID;


            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void UpdateSortNumEdit(int UserGroupID, string UnitID, string sortNum)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update UserGroupDetail set  OrderNo=@sortNum");
            strSql.Append(" where UserGroupID=@UserGroupID and UnitID in(" + UnitID + ")");
            SqlParameter[] parameters = {
					new SqlParameter("@UserGroupID", SqlDbType.Int,4),
                    new SqlParameter("@sortNum", SqlDbType.Int,4)
                                        };
            parameters[0].Value = UserGroupID;
            parameters[1].Value = sortNum;

             DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
         
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public EduZY.Model.departGroup.UserGroupDetail GetModel(int UserGroupID, int UnitID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 UserGroupID,UnitID,OrderNo,AddTime from UserGroupDetail ");
            strSql.Append(" where UserGroupID=@UserGroupID and UnitID=@UnitID ");
            SqlParameter[] parameters = {
					new SqlParameter("@UserGroupID", SqlDbType.Int,4),
					new SqlParameter("@UnitID", SqlDbType.Int,4)			};
            parameters[0].Value = UserGroupID;
            parameters[1].Value = UnitID;

            EduZY.Model.departGroup.UserGroupDetail model = new EduZY.Model.departGroup.UserGroupDetail();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return DataRowToModel(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public EduZY.Model.departGroup.UserGroupDetail DataRowToModel(DataRow row)
        {
            EduZY.Model.departGroup.UserGroupDetail model = new EduZY.Model.departGroup.UserGroupDetail();
            if (row != null)
            {
                if (row["UserGroupID"] != null && row["UserGroupID"].ToString() != "")
                {
                    model.UserGroupID = int.Parse(row["UserGroupID"].ToString());
                }
                if (row["UnitID"] != null && row["UnitID"].ToString() != "")
                {
                    model.UnitID = int.Parse(row["UnitID"].ToString());
                }
                if (row["OrderNo"] != null && row["OrderNo"].ToString() != "")
                {
                    model.OrderNo = int.Parse(row["OrderNo"].ToString());
                }
                if (row["AddTime"] != null && row["AddTime"].ToString() != "")
                {
                    model.AddTime = DateTime.Parse(row["AddTime"].ToString());
                }
                if (row["UnitName"] != null && row["UnitName"].ToString() != "")
                {
                    model.UnitName = row["UnitName"].ToString();
                }
                if (row["Remark"] != null && row["Remark"].ToString() != "")
                {
                    model.Remark = row["Remark"].ToString();
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
            strSql.Append("select UserGroupID,UnitID,OrderNo,AddTime ");
            strSql.Append(" FROM UserGroupDetail ");
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
            strSql.Append(" UserGroupID,UnitID,OrderNo,AddTime ");
            strSql.Append(" FROM UserGroupDetail ");
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
            strSql.Append("select count(1) FROM UserGroupDetail ");
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
                strSql.Append("order by T.UnitID desc");
            }
            strSql.Append(")AS Row, T.*  from UserGroupDetail T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelperSQL.Query(strSql.ToString());
        }
 

        public DataSet GetPageList(int pageSize, int pageIndex, string strWhere, out int iRecordCount)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" [UserGroupID],[UnitID],[OrderNo] ,[AddTime],(SELECT [UnitName] FROM [dbo].[BasicUnit] where UnitID=UserGroupDetail.UnitID) AS UnitName ,(SELECT [Remark] FROM [dbo].[BasicUnit] where UnitID=UserGroupDetail.UnitID) AS Remark");

            return DbHelperSQL.QueryPageList("UserGroupDetail", "UnitID", strSql.ToString(), pageSize, pageIndex, " OrderNo", strWhere, out iRecordCount);
        }
        /*
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        {
            SqlParameter[] parameters = {
                    new SqlParameter("@tblName", SqlDbType.VarChar, 255),
                    new SqlParameter("@fldName", SqlDbType.VarChar, 255),
                    new SqlParameter("@PageSize", SqlDbType.Int),
                    new SqlParameter("@PageIndex", SqlDbType.Int),
                    new SqlParameter("@IsReCount", SqlDbType.Bit),
                    new SqlParameter("@OrderType", SqlDbType.Bit),
                    new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
                    };
            parameters[0].Value = "UserGroupDetail";
            parameters[1].Value = "UnitID";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion  BasicMethod
        #region  ExtensionMethod

        #endregion  ExtensionMethod



      
    }
}
