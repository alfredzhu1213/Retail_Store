
using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace EduZY.DAL.Common
{
	/// <summary>
	/// 数据访问类:BasicClass
	/// </summary>
	public partial class BasicClassDAL
	{
        public BasicClassDAL()
		{}
		#region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ClassID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from BasicClass");
			strSql.Append(" where ClassID=@ClassID");
			SqlParameter[] parameters = {
					new SqlParameter("@ClassID", SqlDbType.Int,4)
			};
			parameters[0].Value = ClassID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(EduZY.Model.Common.BasicClass model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into BasicClass(");
			strSql.Append("ClassName,ParentClassID,OperationUserID,AddTime,UpdateTime)");
			strSql.Append(" values (");
			strSql.Append("@ClassName,@ParentClassID,@OperationUserID,@AddTime,@UpdateTime)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@ClassName", SqlDbType.NVarChar,50),
					new SqlParameter("@ParentClassID", SqlDbType.Int,4),
					new SqlParameter("@OperationUserID", SqlDbType.Int,4),
					new SqlParameter("@AddTime", SqlDbType.DateTime),
					new SqlParameter("@UpdateTime", SqlDbType.DateTime)};
			parameters[0].Value = model.ClassName;
			parameters[1].Value = model.ParentClassID;
			parameters[2].Value = model.OperationUserID;
			parameters[3].Value = model.AddTime;
			parameters[4].Value = model.UpdateTime;

			object obj = DbHelperSQL.GetSingle(strSql.ToString(),parameters);
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
		public bool Update(EduZY.Model.Common.BasicClass model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update BasicClass set ");
			strSql.Append("ClassName=@ClassName,");
			strSql.Append("ParentClassID=@ParentClassID,");
			strSql.Append("OperationUserID=@OperationUserID,");
			strSql.Append("AddTime=@AddTime,");
			strSql.Append("UpdateTime=@UpdateTime");
			strSql.Append(" where ClassID=@ClassID");
			SqlParameter[] parameters = {
					new SqlParameter("@ClassName", SqlDbType.NVarChar,50),
					new SqlParameter("@ParentClassID", SqlDbType.Int,4),
					new SqlParameter("@OperationUserID", SqlDbType.Int,4),
					new SqlParameter("@AddTime", SqlDbType.DateTime),
					new SqlParameter("@UpdateTime", SqlDbType.DateTime),
					new SqlParameter("@ClassID", SqlDbType.Int,4)};
			parameters[0].Value = model.ClassName;
			parameters[1].Value = model.ParentClassID;
			parameters[2].Value = model.OperationUserID;
			parameters[3].Value = model.AddTime;
			parameters[4].Value = model.UpdateTime;
			parameters[5].Value = model.ClassID;

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
		public bool Delete(int ClassID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from BasicClass ");
			strSql.Append(" where ClassID=@ClassID");
			SqlParameter[] parameters = {
					new SqlParameter("@ClassID", SqlDbType.Int,4)
			};
			parameters[0].Value = ClassID;

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
		public bool DeleteList(string ClassIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from BasicClass ");
			strSql.Append(" where ClassID in ("+ClassIDlist + ")  ");
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
		public EduZY.Model.Common.BasicClass GetModel(int ClassID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ClassID,ClassName,ParentClassID,OperationUserID,AddTime,UpdateTime from BasicClass ");
			strSql.Append(" where ClassID=@ClassID");
			SqlParameter[] parameters = {
					new SqlParameter("@ClassID", SqlDbType.Int,4)
			};
			parameters[0].Value = ClassID;

			EduZY.Model.Common.BasicClass model=new EduZY.Model.Common.BasicClass();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
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
		public EduZY.Model.Common.BasicClass DataRowToModel(DataRow row)
		{
			EduZY.Model.Common.BasicClass model=new EduZY.Model.Common.BasicClass();
			if (row != null)
			{
				if(row["ClassID"]!=null && row["ClassID"].ToString()!="")
				{
					model.ClassID=int.Parse(row["ClassID"].ToString());
				}
				if(row["ClassName"]!=null)
				{
					model.ClassName=row["ClassName"].ToString();
				}
				if(row["ParentClassID"]!=null && row["ParentClassID"].ToString()!="")
				{
					model.ParentClassID=int.Parse(row["ParentClassID"].ToString());
				}
				if(row["OperationUserID"]!=null && row["OperationUserID"].ToString()!="")
				{
					model.OperationUserID=int.Parse(row["OperationUserID"].ToString());
				}
				if(row["AddTime"]!=null && row["AddTime"].ToString()!="")
				{
					model.AddTime=DateTime.Parse(row["AddTime"].ToString());
				}
				if(row["UpdateTime"]!=null && row["UpdateTime"].ToString()!="")
				{
					model.UpdateTime=DateTime.Parse(row["UpdateTime"].ToString());
				}
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ClassID,ClassName,ParentClassID,OperationUserID,AddTime,UpdateTime ");
			strSql.Append(" FROM BasicClass ");
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
			strSql.Append(" ClassID,ClassName,ParentClassID,OperationUserID,AddTime,UpdateTime ");
			strSql.Append(" FROM BasicClass ");
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
			strSql.Append("select count(1) FROM BasicClass ");
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
				strSql.Append("order by T.ClassID desc");
			}
			strSql.Append(")AS Row, T.*  from BasicClass T ");
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
			parameters[0].Value = "BasicClass";
			parameters[1].Value = "ClassID";
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

