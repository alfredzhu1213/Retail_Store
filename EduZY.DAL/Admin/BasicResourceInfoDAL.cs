using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references

namespace EduZY.DAL.Admin
{
    /// <summary>
    /// 数据访问类:BasicResourceInfo
    /// </summary>
    public partial class BasicResourceInfoDAL
    {
        public BasicResourceInfoDAL()
        { }
        #region  Method

        public DataSet GetPageList(int pageSize, int pageIndex, string strWhere, out int iRecordCount)
        {
            return DbHelperSQL.QueryPageList("BasicResourceInfo", "ResourceID", "*", pageSize, pageIndex, " ParentID ASC ", strWhere, out iRecordCount);
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ResourceID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from BasicResourceInfo");
            strSql.Append(" where ResourceID=@ResourceID");
            SqlParameter[] parameters = {
					new SqlParameter("@ResourceID", SqlDbType.Int,4)
			};
            parameters[0].Value = ResourceID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(EduZY.Model.BasicResourceInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into BasicResourceInfo(");
            strSql.Append("ResourceLevel,ResourceName,EResourceName,URL,Description,ParentID,ResourceOrder,Visible,Remark,CreatTime)");
            strSql.Append(" values (");
            strSql.Append("@ResourceLevel,@ResourceName,@EResourceName,@URL,@Description,@ParentID,@ResourceOrder,@Visible,@Remark,@CreatTime)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@ResourceLevel", SqlDbType.Int,4),
					new SqlParameter("@ResourceName", SqlDbType.VarChar,255),
					new SqlParameter("@EResourceName", SqlDbType.VarChar,255),
					new SqlParameter("@URL", SqlDbType.VarChar,255),
					new SqlParameter("@Description", SqlDbType.NVarChar,2000),
					new SqlParameter("@ParentID", SqlDbType.Int,4),
					new SqlParameter("@ResourceOrder", SqlDbType.Int,4),
					new SqlParameter("@Visible", SqlDbType.Bit,1),
					new SqlParameter("@Remark", SqlDbType.NVarChar,2000),
					new SqlParameter("@CreatTime", SqlDbType.DateTime)};
            parameters[0].Value = model.ResourceLevel;
            parameters[1].Value = model.ResourceName;
            parameters[2].Value = model.EResourceName;
            parameters[3].Value = model.sURL;
            parameters[4].Value = model.Description;
            parameters[5].Value = model.ParentID;
            parameters[6].Value = model.ResourceOrder;
            parameters[7].Value = model.Visible;
            parameters[8].Value = model.Remark;
            parameters[9].Value = model.CreatTime;

            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
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
        public bool Update(EduZY.Model.BasicResourceInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update BasicResourceInfo set ");
            strSql.Append("ResourceLevel=@ResourceLevel,");
            strSql.Append("ResourceName=@ResourceName,");
            strSql.Append("EResourceName=@EResourceName,");
            strSql.Append("URL=@URL,");
            strSql.Append("Description=@Description,");
            strSql.Append("ParentID=@ParentID,");
            strSql.Append("ResourceOrder=@ResourceOrder,");
            strSql.Append("Visible=@Visible,");
            strSql.Append("Remark=@Remark,");
            strSql.Append("CreatTime=@CreatTime");
            strSql.Append(" where ResourceID=@ResourceID");
            SqlParameter[] parameters = {
					new SqlParameter("@ResourceLevel", SqlDbType.Int,4),
					new SqlParameter("@ResourceName", SqlDbType.VarChar,255),
					new SqlParameter("@EResourceName", SqlDbType.VarChar,255),
					new SqlParameter("@URL", SqlDbType.VarChar,255),
					new SqlParameter("@Description", SqlDbType.NVarChar,2000),
					new SqlParameter("@ParentID", SqlDbType.Int,4),
					new SqlParameter("@ResourceOrder", SqlDbType.Int,4),
					new SqlParameter("@Visible", SqlDbType.Bit,1),
					new SqlParameter("@Remark", SqlDbType.NVarChar,2000),
					new SqlParameter("@CreatTime", SqlDbType.DateTime),
					new SqlParameter("@ResourceID", SqlDbType.Int,4)};
            parameters[0].Value = model.ResourceLevel;
            parameters[1].Value = model.ResourceName;
            parameters[2].Value = model.EResourceName;
            parameters[3].Value = model.sURL;
            parameters[4].Value = model.Description;
            parameters[5].Value = model.ParentID;
            parameters[6].Value = model.ResourceOrder;
            parameters[7].Value = model.Visible;
            parameters[8].Value = model.Remark;
            parameters[9].Value = model.CreatTime;
            parameters[10].Value = model.ResourceID;

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
        /// 删除一条数据
        /// </summary>
        public bool Delete(int ResourceID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from BasicResourceInfo ");
            strSql.Append(" where ResourceID=@ResourceID");
            SqlParameter[] parameters = {
					new SqlParameter("@ResourceID", SqlDbType.Int,4)
			};
            parameters[0].Value = ResourceID;

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
        public bool DeleteList(string ResourceIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from BasicResourceInfo ");
            strSql.Append(" where ResourceID in (" + ResourceIDlist + ")  ");
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
        public EduZY.Model.BasicResourceInfo GetModel(int ResourceID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ResourceID,ResourceLevel,ResourceName,EResourceName,URL,Description,ParentID,ResourceOrder,Visible,Remark,CreatTime from BasicResourceInfo ");
            strSql.Append(" where ResourceID=@ResourceID");
            SqlParameter[] parameters = {
					new SqlParameter("@ResourceID", SqlDbType.Int,4)
			};
            parameters[0].Value = ResourceID;

            EduZY.Model.BasicResourceInfo model = new EduZY.Model.BasicResourceInfo();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ResourceID"] != null && ds.Tables[0].Rows[0]["ResourceID"].ToString() != "")
                {
                    model.ResourceID = int.Parse(ds.Tables[0].Rows[0]["ResourceID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ResourceLevel"] != null && ds.Tables[0].Rows[0]["ResourceLevel"].ToString() != "")
                {
                    model.ResourceLevel = int.Parse(ds.Tables[0].Rows[0]["ResourceLevel"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ResourceName"] != null && ds.Tables[0].Rows[0]["ResourceName"].ToString() != "")
                {
                    model.ResourceName = ds.Tables[0].Rows[0]["ResourceName"].ToString();
                }
                if (ds.Tables[0].Rows[0]["EResourceName"] != null && ds.Tables[0].Rows[0]["EResourceName"].ToString() != "")
                {
                    model.EResourceName = ds.Tables[0].Rows[0]["EResourceName"].ToString();
                }
                if (ds.Tables[0].Rows[0]["URL"] != null && ds.Tables[0].Rows[0]["URL"].ToString() != "")
                {
                    model.sURL = ds.Tables[0].Rows[0]["URL"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Description"] != null && ds.Tables[0].Rows[0]["Description"].ToString() != "")
                {
                    model.Description = ds.Tables[0].Rows[0]["Description"].ToString();
                }
                if (ds.Tables[0].Rows[0]["ParentID"] != null && ds.Tables[0].Rows[0]["ParentID"].ToString() != "")
                {
                    model.ParentID = int.Parse(ds.Tables[0].Rows[0]["ParentID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ResourceOrder"] != null && ds.Tables[0].Rows[0]["ResourceOrder"].ToString() != "")
                {
                    model.ResourceOrder = int.Parse(ds.Tables[0].Rows[0]["ResourceOrder"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Visible"] != null && ds.Tables[0].Rows[0]["Visible"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["Visible"].ToString() == "1") || (ds.Tables[0].Rows[0]["Visible"].ToString().ToLower() == "true"))
                    {
                        model.Visible = true;
                    }
                    else
                    {
                        model.Visible = false;
                    }
                }
                if (ds.Tables[0].Rows[0]["Remark"] != null && ds.Tables[0].Rows[0]["Remark"].ToString() != "")
                {
                    model.Remark = ds.Tables[0].Rows[0]["Remark"].ToString();
                }
                if (ds.Tables[0].Rows[0]["CreatTime"] != null && ds.Tables[0].Rows[0]["CreatTime"].ToString() != "")
                {
                    model.CreatTime = DateTime.Parse(ds.Tables[0].Rows[0]["CreatTime"].ToString());
                }
                return model;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ResourceID,ResourceLevel,ResourceName,EResourceName,URL,ImagesURL,Description,ParentID,ResourceOrder,Visible,Remark,CreatTime ");
            strSql.Append(" FROM BasicResourceInfo ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }
        public DataSet GetList(int RoleID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select BasicResourceInfo.ResourceID,ImagesURL,ResourceLevel,ResourceName,EResourceName,URL,Description,ParentID,ResourceOrder,Visible ");
            strSql.Append(" FROM BasicResourceInfo,BasicRoleRight ");
            strSql.Append(" where BasicResourceInfo.ResourceID=BasicRoleRight.ResourceID and BasicResourceInfo.Visible=1 and ResourceLevel=0 and BasicRoleRight.RoleID=@RoleID");
            SqlParameter[] parameters = {
					new SqlParameter("@RoleID", SqlDbType.Int,4)
            };
            parameters[0].Value = RoleID;
            return DbHelperSQL.Query(strSql.ToString(), parameters);
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
            strSql.Append(" ResourceID,ResourceLevel,ResourceName,EResourceName,URL,Description,ParentID,ResourceOrder,Visible,Remark,CreatTime ");
            strSql.Append(" FROM BasicResourceInfo ");
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
            strSql.Append("select count(1) FROM BasicResourceInfo ");
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
                strSql.Append("order by T.ResourceID desc");
            }
            strSql.Append(")AS Row, T.*  from BasicResourceInfo T ");
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
            parameters[0].Value = "BasicResourceInfo";
            parameters[1].Value = "ResourceID";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion  Method

     
    }
}
