using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace EduZY.DAL.Common
{
	/// <summary>
	/// 数据访问类:BasicUnit
	/// </summary>
	public partial class BasicUnitDAL
	{
		public BasicUnitDAL()
		{}
		#region  BasicMethod

        public DataSet GetPageList(int pageSize, int pageIndex, string strWhere, out int iRecordCount)
        {
            return DbHelperSQL.QueryPageList("BasicUnit", "UnitID", "*", pageSize, pageIndex, " UnitID ", strWhere, out iRecordCount);
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public EduZY.Model.Common.BasicUnit GetModel上级单位(int UnitID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 UnitID,UnitCode,UnitName,UnitClassID,PCAID,Remark,ParentUnitID,UnitManageUserID,OperationUserID,AddTime,UpdateTime from BasicUnit ");
            strSql.Append(" where UnitID in(select ParentUnitID from  BasicUnit where  UnitID=@UnitID) ");
            SqlParameter[] parameters = {
					new SqlParameter("@UnitID", SqlDbType.Int,4)
			};
            parameters[0].Value = UnitID;

            EduZY.Model.Common.BasicUnit model = new EduZY.Model.Common.BasicUnit();
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

        public EduZY.Model.Common.BasicUnit GetModel下级单位(int UnitID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 UnitID,UnitCode,UnitName,UnitClassID,PCAID,Remark,ParentUnitID,UnitManageUserID,OperationUserID,AddTime,UpdateTime from BasicUnit ");
            strSql.Append(" where ParentUnitID=@UnitID ");
            SqlParameter[] parameters = {
					new SqlParameter("@UnitID", SqlDbType.Int,4)
			};
            parameters[0].Value = UnitID;

            EduZY.Model.Common.BasicUnit model = new EduZY.Model.Common.BasicUnit();
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

        public string GetReceiveDepList(string InfoID)
        {
            string ReceiveDepList = "";
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select UnitID,UnitName FROM BasicUnit ");
            strSql.Append(" where  UnitID in ( SELECT UnitID FROM InfoUnitUser where InfoID='"+InfoID+"') ");
            DataSet ds= DbHelperSQL.Query(strSql.ToString());
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                ReceiveDepList += dr["UnitName"].ToString() + ",";
            }
            if (ReceiveDepList.Trim() != "")
            {
                ReceiveDepList = ReceiveDepList.TrimEnd(',');
            }
            return ReceiveDepList;

            
        }

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int UnitID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from BasicUnit");
			strSql.Append(" where UnitID=@UnitID");
			SqlParameter[] parameters = {
					new SqlParameter("@UnitID", SqlDbType.Int,4)
			};
			parameters[0].Value = UnitID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(EduZY.Model.Common.BasicUnit model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into BasicUnit(");
			strSql.Append("UnitCode,UnitName,UnitClassID,PCAID,Remark,ParentUnitID,UnitManageUserID,OperationUserID,AddTime,UpdateTime)");
			strSql.Append(" values (");
			strSql.Append("@UnitCode,@UnitName,@UnitClassID,@PCAID,@Remark,@ParentUnitID,@UnitManageUserID,@OperationUserID,@AddTime,@UpdateTime)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@UnitCode", SqlDbType.NVarChar,50),
					new SqlParameter("@UnitName", SqlDbType.NVarChar,50),
					new SqlParameter("@UnitClassID", SqlDbType.Int,4),
					new SqlParameter("@PCAID", SqlDbType.Int,4),
					new SqlParameter("@Remark", SqlDbType.NVarChar,500),
					new SqlParameter("@ParentUnitID", SqlDbType.Int,4),
					new SqlParameter("@UnitManageUserID", SqlDbType.Int,4),
					new SqlParameter("@OperationUserID", SqlDbType.Int,4),
					new SqlParameter("@AddTime", SqlDbType.DateTime),
					new SqlParameter("@UpdateTime", SqlDbType.DateTime)};
			parameters[0].Value = model.UnitCode;
			parameters[1].Value = model.UnitName;
			parameters[2].Value = model.UnitClassID;
			parameters[3].Value = model.PCAID;
			parameters[4].Value = model.Remark;
			parameters[5].Value = model.ParentUnitID;
			parameters[6].Value = model.UnitManageUserID;
			parameters[7].Value = model.OperationUserID;
			parameters[8].Value = model.AddTime;
			parameters[9].Value = model.UpdateTime;

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
		public bool Update(EduZY.Model.Common.BasicUnit model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update BasicUnit set ");
			strSql.Append("UnitCode=@UnitCode,");
			strSql.Append("UnitName=@UnitName,");
			strSql.Append("UnitClassID=@UnitClassID,");
			strSql.Append("PCAID=@PCAID,");
			strSql.Append("Remark=@Remark,");
			strSql.Append("ParentUnitID=@ParentUnitID,");
			strSql.Append("UnitManageUserID=@UnitManageUserID,");
			strSql.Append("OperationUserID=@OperationUserID,");
			strSql.Append("AddTime=@AddTime,");
			strSql.Append("UpdateTime=@UpdateTime");
			strSql.Append(" where UnitID=@UnitID");
			SqlParameter[] parameters = {
					new SqlParameter("@UnitCode", SqlDbType.NVarChar,50),
					new SqlParameter("@UnitName", SqlDbType.NVarChar,50),
					new SqlParameter("@UnitClassID", SqlDbType.Int,4),
					new SqlParameter("@PCAID", SqlDbType.Int,4),
					new SqlParameter("@Remark", SqlDbType.NVarChar,500),
					new SqlParameter("@ParentUnitID", SqlDbType.Int,4),
					new SqlParameter("@UnitManageUserID", SqlDbType.Int,4),
					new SqlParameter("@OperationUserID", SqlDbType.Int,4),
					new SqlParameter("@AddTime", SqlDbType.DateTime),
					new SqlParameter("@UpdateTime", SqlDbType.DateTime),
					new SqlParameter("@UnitID", SqlDbType.Int,4)};
			parameters[0].Value = model.UnitCode;
			parameters[1].Value = model.UnitName;
			parameters[2].Value = model.UnitClassID;
			parameters[3].Value = model.PCAID;
			parameters[4].Value = model.Remark;
			parameters[5].Value = model.ParentUnitID;
			parameters[6].Value = model.UnitManageUserID;
			parameters[7].Value = model.OperationUserID;
			parameters[8].Value = model.AddTime;
			parameters[9].Value = model.UpdateTime;
			parameters[10].Value = model.UnitID;

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
		public bool Delete(int UnitID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from BasicUnit ");
			strSql.Append(" where UnitID=@UnitID");
			SqlParameter[] parameters = {
					new SqlParameter("@UnitID", SqlDbType.Int,4)
			};
			parameters[0].Value = UnitID;

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
		public bool DeleteList(string UnitIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from BasicUnit ");
			strSql.Append(" where UnitID in ("+UnitIDlist + ")  ");
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
		public EduZY.Model.Common.BasicUnit GetModel(int UnitID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 UnitID,UnitCode,UnitName,UnitClassID,PCAID,Remark,ParentUnitID,UnitManageUserID,OperationUserID,AddTime,UpdateTime from BasicUnit ");
			strSql.Append(" where UnitID=@UnitID");
			SqlParameter[] parameters = {
					new SqlParameter("@UnitID", SqlDbType.Int,4)
			};
			parameters[0].Value = UnitID;

			EduZY.Model.Common.BasicUnit model=new EduZY.Model.Common.BasicUnit();
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
		public EduZY.Model.Common.BasicUnit DataRowToModel(DataRow row)
		{
			EduZY.Model.Common.BasicUnit model=new EduZY.Model.Common.BasicUnit();
			if (row != null)
			{
				if(row["UnitID"]!=null && row["UnitID"].ToString()!="")
				{
					model.UnitID=int.Parse(row["UnitID"].ToString());
				}
				if(row["UnitCode"]!=null)
				{
					model.UnitCode=row["UnitCode"].ToString();
				}
				if(row["UnitName"]!=null)
				{
					model.UnitName=row["UnitName"].ToString();
				}
				if(row["UnitClassID"]!=null && row["UnitClassID"].ToString()!="")
				{
					model.UnitClassID=int.Parse(row["UnitClassID"].ToString());
				}
				if(row["PCAID"]!=null && row["PCAID"].ToString()!="")
				{
					model.PCAID=int.Parse(row["PCAID"].ToString());
				}
				if(row["Remark"]!=null)
				{
					model.Remark=row["Remark"].ToString();
				}
				if(row["ParentUnitID"]!=null && row["ParentUnitID"].ToString()!="")
				{
					model.ParentUnitID=int.Parse(row["ParentUnitID"].ToString());
				}
				if(row["UnitManageUserID"]!=null && row["UnitManageUserID"].ToString()!="")
				{
					model.UnitManageUserID=int.Parse(row["UnitManageUserID"].ToString());
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
			strSql.Append("select UnitID,UnitCode,UnitName,UnitClassID,PCAID,Remark,ParentUnitID,UnitManageUserID,OperationUserID,AddTime,UpdateTime ");
			strSql.Append(" FROM BasicUnit ");
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
			strSql.Append(" UnitID,UnitCode,UnitName,UnitClassID,PCAID,Remark,ParentUnitID,UnitManageUserID,OperationUserID,AddTime,UpdateTime ");
			strSql.Append(" FROM BasicUnit ");
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
			strSql.Append("select count(1) FROM BasicUnit ");
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
				strSql.Append("order by T.UnitID desc");
			}
			strSql.Append(")AS Row, T.*  from BasicUnit T ");
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
			parameters[0].Value = "BasicUnit";
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

