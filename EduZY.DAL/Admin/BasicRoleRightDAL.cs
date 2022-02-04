using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;
using EduZY.Model.Admin;//Please add references
namespace EduZY.DAL.Admin
{
	/// <summary>
	/// 数据访问类:BasicRoleRight
	/// </summary>
	public partial class BasicRoleRightDAL
	{
        public BasicRoleRightDAL()
		{}
		#region  Method

 

        public DataSet GetListRoleRight_Resource(int RoleID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select BasicResourceInfo.ResourceID,ResourceLevel,ResourceName,EResourceName,URL,Description,ParentID,ResourceOrder,Visible,BasicRoleRight.ResourceID as RoleRightResourceID");
            strSql.Append(" from BasicResourceInfo");
            strSql.Append(" left join BasicRoleRight on BasicResourceInfo.ResourceID=BasicRoleRight.ResourceID and BasicRoleRight.RoleID=@RoleID");
            strSql.Append(" where BasicResourceInfo.Visible=1");
            SqlParameter[] parameters = {
					new SqlParameter("@RoleID", SqlDbType.Int,4)
            };
            parameters[0].Value = RoleID;
            return DbHelperSQL.Query(strSql.ToString(), parameters);
        }


        public DataSet GetListIDlist(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT  id FROM [dbo].[f_BasicResource_ppid] (@ID)");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
            };
            parameters[0].Value = ID;
            return DbHelperSQL.Query(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 保存角色信息
        /// </summary>
        /// <param name="model"></param>
        /// <param name="ResourceIDList">权限编码</param>
        /// <returns></returns>
        public int AddOrUpdateRoleRight(BasicRole model, string ResourceIDList)
        {
            int rowsAffected;
            SqlParameter[] parameters = {					
					new SqlParameter("@RoleID", SqlDbType.Int,4),
					new SqlParameter("@RoleName", SqlDbType.NVarChar,50),
					new SqlParameter("@ResourceIDList", SqlDbType.NVarChar,2000),
                                        };
            parameters[0].Value = model.RoleID;
            parameters[1].Value = model.RoleName;
            parameters[2].Value = ResourceIDList;
            DbHelperSQL.RunProcedure("UP_Save_RoleRight", parameters, out rowsAffected);
            return rowsAffected;
        }
		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("RoleID", "BasicRoleRight"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int RoleID,int ResourceID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from BasicRoleRight");
			strSql.Append(" where RoleID=@RoleID and ResourceID=@ResourceID ");
			SqlParameter[] parameters = {
					new SqlParameter("@RoleID", SqlDbType.Int,4),
					new SqlParameter("@ResourceID", SqlDbType.Int,4)			};
			parameters[0].Value = RoleID;
			parameters[1].Value = ResourceID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(EduZY.Model.Admin.BasicRoleRight model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into BasicRoleRight(");
			strSql.Append("RoleID,ResourceID,OperationUserID,AddTime,UpdateTime)");
			strSql.Append(" values (");
			strSql.Append("@RoleID,@ResourceID,@OperationUserID,@AddTime,@UpdateTime)");
			SqlParameter[] parameters = {
					new SqlParameter("@RoleID", SqlDbType.Int,4),
					new SqlParameter("@ResourceID", SqlDbType.Int,4),
					new SqlParameter("@OperationUserID", SqlDbType.Int,4),
					new SqlParameter("@AddTime", SqlDbType.DateTime),
					new SqlParameter("@UpdateTime", SqlDbType.DateTime)};
			parameters[0].Value = model.RoleID;
			parameters[1].Value = model.ResourceID;
			parameters[2].Value = model.OperationUserID;
			parameters[3].Value = model.AddTime;
			parameters[4].Value = model.UpdateTime;

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
		/// 更新一条数据
		/// </summary>
		public bool Update(EduZY.Model.Admin.BasicRoleRight model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update BasicRoleRight set ");
			strSql.Append("OperationUserID=@OperationUserID,");
			strSql.Append("AddTime=@AddTime,");
			strSql.Append("UpdateTime=@UpdateTime");
			strSql.Append(" where RoleID=@RoleID and ResourceID=@ResourceID ");
			SqlParameter[] parameters = {
					new SqlParameter("@OperationUserID", SqlDbType.Int,4),
					new SqlParameter("@AddTime", SqlDbType.DateTime),
					new SqlParameter("@UpdateTime", SqlDbType.DateTime),
					new SqlParameter("@RoleID", SqlDbType.Int,4),
					new SqlParameter("@ResourceID", SqlDbType.Int,4)};
			parameters[0].Value = model.OperationUserID;
			parameters[1].Value = model.AddTime;
			parameters[2].Value = model.UpdateTime;
			parameters[3].Value = model.RoleID;
			parameters[4].Value = model.ResourceID;

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
		public bool Delete(int RoleID,int ResourceID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from BasicRoleRight ");
			strSql.Append(" where RoleID=@RoleID and ResourceID=@ResourceID ");
			SqlParameter[] parameters = {
					new SqlParameter("@RoleID", SqlDbType.Int,4),
					new SqlParameter("@ResourceID", SqlDbType.Int,4)			};
			parameters[0].Value = RoleID;
			parameters[1].Value = ResourceID;

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
		/// 得到一个对象实体
		/// </summary>
		public EduZY.Model.Admin.BasicRoleRight GetModel(int RoleID,int ResourceID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 RoleID,ResourceID,OperationUserID,AddTime,UpdateTime from BasicRoleRight ");
			strSql.Append(" where RoleID=@RoleID and ResourceID=@ResourceID ");
			SqlParameter[] parameters = {
					new SqlParameter("@RoleID", SqlDbType.Int,4),
					new SqlParameter("@ResourceID", SqlDbType.Int,4)			};
			parameters[0].Value = RoleID;
			parameters[1].Value = ResourceID;

			EduZY.Model.Admin.BasicRoleRight model=new EduZY.Model.Admin.BasicRoleRight();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["RoleID"]!=null && ds.Tables[0].Rows[0]["RoleID"].ToString()!="")
				{
					model.RoleID=int.Parse(ds.Tables[0].Rows[0]["RoleID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["ResourceID"]!=null && ds.Tables[0].Rows[0]["ResourceID"].ToString()!="")
				{
					model.ResourceID=int.Parse(ds.Tables[0].Rows[0]["ResourceID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["OperationUserID"]!=null && ds.Tables[0].Rows[0]["OperationUserID"].ToString()!="")
				{
					model.OperationUserID=int.Parse(ds.Tables[0].Rows[0]["OperationUserID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["AddTime"]!=null && ds.Tables[0].Rows[0]["AddTime"].ToString()!="")
				{
					model.AddTime=DateTime.Parse(ds.Tables[0].Rows[0]["AddTime"].ToString());
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
			strSql.Append("select RoleID,ResourceID,OperationUserID,AddTime,UpdateTime ");
			strSql.Append(" FROM BasicRoleRight ");
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
			strSql.Append(" RoleID,ResourceID,OperationUserID,AddTime,UpdateTime ");
			strSql.Append(" FROM BasicRoleRight ");
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
			strSql.Append("select count(1) FROM BasicRoleRight ");
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
				strSql.Append("order by T.ResourceID desc");
			}
			strSql.Append(")AS Row, T.*  from BasicRoleRight T ");
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
			parameters[0].Value = "BasicRoleRight";
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

