using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace EduZY.DAL.departGroup
{
    /// <summary>
    /// 数据访问类:UserGroupMaster
    /// </summary>
    public partial class UserGroupMasterDAL
    {
        public UserGroupMasterDAL()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int UserGroupID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from UserGroupMaster");
            strSql.Append(" where UserGroupID=@UserGroupID");
            SqlParameter[] parameters = {
					new SqlParameter("@UserGroupID", SqlDbType.Int,4)
			};
            parameters[0].Value = UserGroupID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(EduZY.Model.departGroup.UserGroupMaster model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into UserGroupMaster(");
            strSql.Append("UserID,GroupName,Remark,AddTime,UpdateTime)");
            strSql.Append(" values (");
            strSql.Append("@UserID,@GroupName,@Remark,@AddTime,@UpdateTime)");
            strSql.Append(";select @@IDENTITY");

            SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.Int,4),
					new SqlParameter("@GroupName", SqlDbType.NVarChar,50),
					new SqlParameter("@Remark", SqlDbType.NVarChar,500),
					new SqlParameter("@AddTime", SqlDbType.DateTime),
					new SqlParameter("@UpdateTime", SqlDbType.DateTime)};
            parameters[0].Value = model.UserID;
            parameters[1].Value = model.GroupName;
            parameters[2].Value = model.Remark;
            parameters[3].Value = model.AddTime;
            parameters[4].Value = model.UpdateTime;
            object UserGroupID = DbHelperSQL.GetSingle(strSql.ToString(), parameters);

            UserGroupDetailDAL dal = new UserGroupDetailDAL();
            EduZY.Model.departGroup.UserGroupDetail dmodel = new Model.departGroup.UserGroupDetail();
            if (model.groupDepartlist.Trim() != "")
            {
                foreach (string UnitID in model.groupDepartlist.Split(','))
                {
                    if (!dal.Exists(Convert.ToInt32(UserGroupID), Convert.ToInt32(UnitID)))
                    {
                        dmodel.AddTime = DateTime.Now;
                        dmodel.UnitID = Convert.ToInt32(UnitID);
                        dmodel.OrderNo = 1;
                        dmodel.UserGroupID = Convert.ToInt32(UserGroupID);
                        dal.Add(dmodel);
                    }

                }
            }

            if (UserGroupID == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(UserGroupID);
            }
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(EduZY.Model.departGroup.UserGroupMaster model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update UserGroupMaster set ");
            //strSql.Append("UserID=@UserID,");
            strSql.Append("GroupName=@GroupName,");
            strSql.Append("Remark=@Remark,");
            //strSql.Append("AddTime=@AddTime,");
            strSql.Append("UpdateTime=@UpdateTime");
            strSql.Append(" where UserGroupID=@UserGroupID");
            SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.Int,4),
					new SqlParameter("@GroupName", SqlDbType.NVarChar,50),
					new SqlParameter("@Remark", SqlDbType.NVarChar,500),
					new SqlParameter("@AddTime", SqlDbType.DateTime),
					new SqlParameter("@UpdateTime", SqlDbType.DateTime),
					new SqlParameter("@UserGroupID", SqlDbType.Int,4)};
            parameters[0].Value = model.UserID;
            parameters[1].Value = model.GroupName;
            parameters[2].Value = model.Remark;
            parameters[3].Value = model.AddTime;
            parameters[4].Value = model.UpdateTime;
            parameters[5].Value = model.UserGroupID;


            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);

            UserGroupDetailDAL dal = new UserGroupDetailDAL();
            EduZY.Model.departGroup.UserGroupDetail dmodel = new Model.departGroup.UserGroupDetail();
            if (model.groupDepartlist.Trim() != "")
            {
                dal.DeleteList(model.UserGroupID.ToString());
                foreach (string UnitID in model.groupDepartlist.Split(','))
                {
                    if (!dal.Exists(Convert.ToInt32(model.UserGroupID.ToString()), Convert.ToInt32(UnitID)))
                    {
                        dmodel.AddTime = DateTime.Now;
                        dmodel.UnitID = Convert.ToInt32(UnitID);
                        dmodel.OrderNo = 1;
                        dmodel.UserGroupID = Convert.ToInt32(model.UserGroupID);
                        dal.Add(dmodel);
                    }

                }
            }

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
        public bool Delete(int UserGroupID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from UserGroupMaster ");
            strSql.Append(" where UserGroupID=@UserGroupID");
            SqlParameter[] parameters = {
					new SqlParameter("@UserGroupID", SqlDbType.Int,4)
			};
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
        /// <summary>
        /// 批量删除数据
        /// </summary>
        public bool DeleteList(string UserGroupIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from UserGroupMaster ");
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
        /// 得到一个对象实体
        /// </summary>
        public EduZY.Model.departGroup.UserGroupMaster GetModel(int UserGroupID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 UserGroupID,UserID,GroupName,Remark,AddTime,UpdateTime from UserGroupMaster ");
            strSql.Append(" where UserGroupID=@UserGroupID");
            SqlParameter[] parameters = {
					new SqlParameter("@UserGroupID", SqlDbType.Int,4)
			};
            parameters[0].Value = UserGroupID;

            EduZY.Model.departGroup.UserGroupMaster model = new EduZY.Model.departGroup.UserGroupMaster();
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
        public EduZY.Model.departGroup.UserGroupMaster DataRowToModel(DataRow row)
        {
            EduZY.Model.departGroup.UserGroupMaster model = new EduZY.Model.departGroup.UserGroupMaster();
            if (row != null)
            {


                if (row["UserGroupID"] != null && row["UserGroupID"].ToString() != "")
                {
                    model.UserGroupID = int.Parse(row["UserGroupID"].ToString());

                    string groupDepartIDlist = "";
                    string groupDepartNamelist = "";
                    StringBuilder strSql = new StringBuilder();
                    strSql.Append("select UnitID,UnitName FROM BasicUnit ");
                    strSql.Append(" where  UnitID in ( SELECT UnitID FROM UserGroupDetail where UserGroupID='" + model.UserGroupID + "') ");
                    DataSet ds = DbHelperSQL.Query(strSql.ToString());
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        groupDepartIDlist += dr["UnitID"].ToString() + ",";
                        groupDepartNamelist += dr["UnitName"].ToString() + ",";
                    }

                    model.groupDepartIDlist = groupDepartIDlist.TrimEnd(',');
                    model.groupDepartNamelist = groupDepartNamelist.TrimEnd(','); 
                }
             
                if (row["UserID"] != null && row["UserID"].ToString() != "")
                {
                    model.UserID = int.Parse(row["UserID"].ToString());
                }
                if (row["GroupName"] != null)
                {
                    model.GroupName = row["GroupName"].ToString();
                }
                if (row["Remark"] != null)
                {
                    model.Remark = row["Remark"].ToString();
                }
                if (row["AddTime"] != null && row["AddTime"].ToString() != "")
                {
                    model.AddTime = DateTime.Parse(row["AddTime"].ToString());
                }
                if (row["UpdateTime"] != null && row["UpdateTime"].ToString() != "")
                {
                    model.UpdateTime = DateTime.Parse(row["UpdateTime"].ToString());
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
            strSql.Append("select UserGroupID,UserID,GroupName,Remark,AddTime,UpdateTime ");
            strSql.Append(" FROM UserGroupMaster ");
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
            strSql.Append(" UserGroupID,UserID,GroupName,Remark,AddTime,UpdateTime ");
            strSql.Append(" FROM UserGroupMaster ");
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
            strSql.Append("select count(1) FROM UserGroupMaster ");
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
                strSql.Append("order by T.UserGroupID desc");
            }
            strSql.Append(")AS Row, T.*  from UserGroupMaster T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelperSQL.Query(strSql.ToString());
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
            parameters[0].Value = "UserGroupMaster";
            parameters[1].Value = "UserGroupID";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/


        public DataSet GetPageList(int pageSize, int pageIndex, string strWhere, out int iRecordCount)
        {
            return DbHelperSQL.QueryPageList("UserGroupMaster", "UserGroupID    ", "*", pageSize, pageIndex, " AddTime DESC ", strWhere, out iRecordCount);
        }
        #endregion  BasicMethod
    }

     
}

