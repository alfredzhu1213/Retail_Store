using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace EduZY.DAL.Admin
{
	/// <summary>
	/// 数据访问类:BasicRole
	/// </summary>
	public partial class BasicRoleDAL
	{
        public BasicRoleDAL()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("RoleID", "BasicRole"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int RoleID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from BasicRole");
			strSql.Append(" where RoleID=@RoleID");
			SqlParameter[] parameters = {
					new SqlParameter("@RoleID", SqlDbType.Int,4)
			};
			parameters[0].Value = RoleID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(EduZY.Model.Admin.BasicRole model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into BasicRole(");
            strSql.Append("RoleName,RoleRemark,ParentRoleID,OperationUserID,Addtime,UpdateTime)");
            strSql.Append(" values (");
            strSql.Append("@RoleName,@RoleRemark,@ParentRoleID,@OperationUserID,getdate(),getdate())");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@RoleName", SqlDbType.NVarChar,50),
					new SqlParameter("@RoleRemark", SqlDbType.NVarChar,255),
					new SqlParameter("@ParentRoleID", SqlDbType.Int,4),
					new SqlParameter("@OperationUserID", SqlDbType.Int,4),
					new SqlParameter("@Addtime", SqlDbType.DateTime),
					new SqlParameter("@UpdateTime", SqlDbType.DateTime)};
            parameters[0].Value = model.RoleName;
            parameters[1].Value = model.RoleRemark;
            parameters[2].Value = model.ParentRoleID;
            parameters[3].Value = model.OperationUserID;
            parameters[4].Value = model.Addtime;
            parameters[5].Value = model.UpdateTime;

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
		public bool Update(EduZY.Model.Admin.BasicRole model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update BasicRole set ");
			strSql.Append("RoleName=@RoleName,");
            strSql.Append("RoleRemark=@RoleRemark,");
            
			strSql.Append("ParentRoleID=@ParentRoleID,");
			strSql.Append("OperationUserID=@OperationUserID,");
			
			strSql.Append("UpdateTime=getdate() ");
			strSql.Append(" where RoleID=@RoleID");
			SqlParameter[] parameters = {
					new SqlParameter("@RoleName", SqlDbType.NVarChar,50),
					new SqlParameter("@ParentRoleID", SqlDbType.Int,4),
					new SqlParameter("@OperationUserID", SqlDbType.Int,4),
					new SqlParameter("@Addtime", SqlDbType.DateTime),
					new SqlParameter("@UpdateTime", SqlDbType.DateTime),
					new SqlParameter("@RoleID", SqlDbType.Int,4),
                    new SqlParameter("@RoleRemark", SqlDbType.NVarChar,255),               
                                        
                                        };
			parameters[0].Value = model.RoleName;
			parameters[1].Value = model.ParentRoleID;
			parameters[2].Value = model.OperationUserID;
			parameters[3].Value = model.Addtime;
			parameters[4].Value = model.UpdateTime;
			parameters[5].Value = model.RoleID;
            parameters[6].Value = model.RoleRemark;
			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
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
		public bool Delete(int RoleID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from BasicRole ");
			strSql.Append(" where RoleID=@RoleID");
			SqlParameter[] parameters = {
					new SqlParameter("@RoleID", SqlDbType.Int,4)
			};
			parameters[0].Value = RoleID;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
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
		public bool DeleteList(string RoleIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from BasicRole ");
			strSql.Append(" where RoleID in ("+RoleIDlist + ")  ");
			int rows=DbHelperSQL.ExecuteSql(strSql.ToString());
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
		public EduZY.Model.Admin.BasicRole GetModel(int RoleID)
		{
			
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select  top 1 RoleID,RoleName,RoleRemark,ParentRoleID,OperationUserID,Addtime,UpdateTime from BasicRole ");
			strSql.Append(" where RoleID=@RoleID");
			SqlParameter[] parameters = {
					new SqlParameter("@RoleID", SqlDbType.Int,4)
			};
			parameters[0].Value = RoleID;

			EduZY.Model.Admin.BasicRole model=new EduZY.Model.Admin.BasicRole();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["RoleID"]!=null && ds.Tables[0].Rows[0]["RoleID"].ToString()!="")
				{
					model.RoleID=int.Parse(ds.Tables[0].Rows[0]["RoleID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["RoleName"]!=null && ds.Tables[0].Rows[0]["RoleName"].ToString()!="")
				{
					model.RoleName=ds.Tables[0].Rows[0]["RoleName"].ToString();
				}

                if (ds.Tables[0].Rows[0]["RoleRemark"] != null && ds.Tables[0].Rows[0]["RoleRemark"].ToString() != "")
				{
                    model.RoleRemark = ds.Tables[0].Rows[0]["RoleRemark"].ToString();
				}
                
				if(ds.Tables[0].Rows[0]["ParentRoleID"]!=null && ds.Tables[0].Rows[0]["ParentRoleID"].ToString()!="")
				{
					model.ParentRoleID=int.Parse(ds.Tables[0].Rows[0]["ParentRoleID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["OperationUserID"]!=null && ds.Tables[0].Rows[0]["OperationUserID"].ToString()!="")
				{
					model.OperationUserID=int.Parse(ds.Tables[0].Rows[0]["OperationUserID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Addtime"]!=null && ds.Tables[0].Rows[0]["Addtime"].ToString()!="")
				{
					model.Addtime=DateTime.Parse(ds.Tables[0].Rows[0]["Addtime"].ToString());
				}
				if(ds.Tables[0].Rows[0]["UpdateTime"]!=null && ds.Tables[0].Rows[0]["UpdateTime"].ToString()!="")
				{
					model.UpdateTime=DateTime.Parse(ds.Tables[0].Rows[0]["UpdateTime"].ToString());
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
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select RoleID,RoleName,ParentRoleID,OperationUserID,Addtime,UpdateTime ");
			strSql.Append(" FROM BasicRole ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(" RoleID,RoleName,ParentRoleID,OperationUserID,Addtime,UpdateTime ");
			strSql.Append(" FROM BasicRole ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM BasicRole ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
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
			StringBuilder strSql=new StringBuilder();
			strSql.Append("SELECT * FROM ( ");
			strSql.Append(" SELECT ROW_NUMBER() OVER (");
			if (!string.IsNullOrEmpty(orderby.Trim()))
			{
				strSql.Append("order by T." + orderby );
			}
			else
			{
				strSql.Append("order by T.RoleID desc");
			}
			strSql.Append(")AS Row, T.*  from BasicRole T ");
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
			parameters[0].Value = "BasicRole";
			parameters[1].Value = "RoleID";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  Method

        public DataSet GetPageList(int pageSize, int pageIndex, string strWhere, out int iRecordCount)
        {
            return DbHelperSQL.QueryPageList("BasicRole", "RoleName    ", "*", pageSize, pageIndex, " AddTime DESC ", strWhere, out iRecordCount);
        }
    }
}

