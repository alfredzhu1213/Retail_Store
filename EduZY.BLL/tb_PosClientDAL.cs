using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace Maticsoft.DAL
{
	/// <summary>
	/// 数据访问类:tb_PosClient
	/// </summary>
	public partial class tb_PosClientDAL
	{
		 public string DBName = "";
         public tb_PosClientDAL(string db)
		{
            DBName = db;     
        
        }
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("id", "[" + DBName + @"].[dbo].tb_PosClient"); 
		}


		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from [" + DBName + @"].[dbo].tb_PosClient");
			strSql.Append(" where id="+id+" ");
			return DbHelperSQL.Exists(strSql.ToString());
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Maticsoft.Model.tb_PosClient model)
		{
			StringBuilder strSql=new StringBuilder();
			StringBuilder strSql1=new StringBuilder();
			StringBuilder strSql2=new StringBuilder();
            //if (model.id != null)
            //{
            //    strSql1.Append("id,");
            //    strSql2.Append(""+model.id+",");
            //}
            if (model.GuidID != null)
            {
                strSql1.Append("GuidID,");
                strSql2.Append("'" + model.GuidID + "',");
            }
			if (model.Code != null)
			{
				strSql1.Append("Code,");
				strSql2.Append("'"+model.Code+"',");
			}
			if (model.name != null)
			{
				strSql1.Append("name,");
				strSql2.Append("'"+model.name+"',");
			}
			if (model.Status != null)
			{
				strSql1.Append("Status,");
				strSql2.Append("'"+model.Status+"',");
			}
			if (model.Remark != null)
			{
				strSql1.Append("Remark,");
				strSql2.Append("'"+model.Remark+"',");
			}
            if (model.StoreId != null)
            {
                strSql1.Append("StoreId,");
                strSql2.Append("" + model.StoreId + ",");
            }
            if (model.AddUserId != null)
            {
                strSql1.Append("AddUserId,");
                strSql2.Append("" + model.AddUserId + ",");
            }
            if (model.AddTime != null)
            {
                strSql1.Append("AddTime,");
                strSql2.Append("'" + model.AddTime + "',");
            }
			
			strSql.Append("insert into [" + DBName + @"].[dbo].tb_PosClient(");
			strSql.Append(strSql1.ToString().Remove(strSql1.Length - 1));
			strSql.Append(")");
			strSql.Append(" values (");
			strSql.Append(strSql2.ToString().Remove(strSql2.Length - 1));
			strSql.Append(")");
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
		/// 更新一条数据
		/// </summary>
		public bool Update(Maticsoft.Model.tb_PosClient model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update [" + DBName + @"].[dbo].tb_PosClient set ");
			if (model.GuidID != null)
			{
				strSql.Append("GuidID='"+model.GuidID+"',");
			}
			else
			{
				strSql.Append("GuidID= null ,");
			}
			if (model.Code != null)
			{
				strSql.Append("Code='"+model.Code+"',");
			}
			else
			{
				strSql.Append("Code= null ,");
			}
			if (model.name != null)
			{
				strSql.Append("name='"+model.name+"',");
			}
			else
			{
				strSql.Append("name= null ,");
			}
			if (model.Status != null)
			{
				strSql.Append("Status='"+model.Status+"',");
			}
			else
			{
				strSql.Append("Status= null ,");
			}
			if (model.Remark != null)
			{
				strSql.Append("Remark='"+model.Remark+"',");
			}
			else
			{
				strSql.Append("Remark= null ,");
			}
			if (model.StoreId != null)
			{
				strSql.Append("StoreId="+model.StoreId+",");
			}
			else
			{
				strSql.Append("StoreId= null ,");
			}
            //if (model.AddUserId != null)
            //{
            //    strSql.Append("AddUserId="+model.AddUserId+",");
            //}
            //else
            //{
            //    strSql.Append("AddUserId= null ,");
            //}
            //if (model.AddTime != null)
            //{
            //    strSql.Append("AddTime='"+model.AddTime+"',");
            //}
            //else
            //{
            //    strSql.Append("AddTime= null ,");
            //}
			if (model.UpdateUserId != null)
			{
				strSql.Append("UpdateUserId="+model.UpdateUserId+",");
			}
			else
			{
				strSql.Append("UpdateUserId= null ,");
			}
			if (model.UpdateTime != null)
			{
				strSql.Append("UpdateTime='"+model.UpdateTime+"',");
			}
			else
			{
				strSql.Append("UpdateTime= null ,");
			}
			int n = strSql.ToString().LastIndexOf(",");
			strSql.Remove(n, 1);
			strSql.Append(" where id="+ model.id+" ");
			int rowsAffected=DbHelperSQL.ExecuteSql(strSql.ToString());
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
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from [" + DBName + @"].[dbo].tb_PosClient ");
			strSql.Append(" where id="+id+" " );
			int rowsAffected=DbHelperSQL.ExecuteSql(strSql.ToString());
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
		public bool DeleteList(string idlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from [" + DBName + @"].[dbo].tb_PosClient ");
			strSql.Append(" where id in ("+idlist + ")  ");
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
		public Maticsoft.Model.tb_PosClient GetModel(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  ");
			strSql.Append(" id,GuidID,Code,name,Status,Remark,StoreId,AddUserId,AddTime,UpdateUserId,UpdateTime ");
			strSql.Append(" from [" + DBName + @"].[dbo].tb_PosClient ");
			strSql.Append(" where id="+id+" " );
			Maticsoft.Model.tb_PosClient model=new Maticsoft.Model.tb_PosClient();
			DataSet ds=DbHelperSQL.Query(strSql.ToString());
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
		public Maticsoft.Model.tb_PosClient DataRowToModel(DataRow row)
		{
			Maticsoft.Model.tb_PosClient model=new Maticsoft.Model.tb_PosClient();
			if (row != null)
			{
				if(row["id"]!=null && row["id"].ToString()!="")
				{
					model.id=int.Parse(row["id"].ToString());
				}
				if(row["GuidID"]!=null && row["GuidID"].ToString()!="")
				{
					model.GuidID= row["GuidID"].ToString();
				}
				if(row["Code"]!=null)
				{
					model.Code=row["Code"].ToString();
				}
				if(row["name"]!=null)
				{
					model.name=row["name"].ToString();
				}
				if(row["Status"]!=null)
				{
					model.Status=row["Status"].ToString();
				}
				if(row["Remark"]!=null)
				{
					model.Remark=row["Remark"].ToString();
				}
				if(row["StoreId"]!=null && row["StoreId"].ToString()!="")
				{
					model.StoreId=int.Parse(row["StoreId"].ToString());
				}
				if(row["AddUserId"]!=null && row["AddUserId"].ToString()!="")
				{
					model.AddUserId=int.Parse(row["AddUserId"].ToString());
				}
				if(row["AddTime"]!=null && row["AddTime"].ToString()!="")
				{
					model.AddTime=DateTime.Parse(row["AddTime"].ToString());
				}
				if(row["UpdateUserId"]!=null && row["UpdateUserId"].ToString()!="")
				{
					model.UpdateUserId=int.Parse(row["UpdateUserId"].ToString());
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
			strSql.Append("select id,GuidID,Code,name,Status,Remark,StoreId,AddUserId,AddTime,UpdateUserId,UpdateTime ");
			strSql.Append(" FROM [" + DBName + @"].[dbo].tb_PosClient ");
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
			strSql.Append(" id,GuidID,Code,name,Status,Remark,StoreId,AddUserId,AddTime,UpdateUserId,UpdateTime ");
			strSql.Append(" FROM [" + DBName + @"].[dbo].tb_PosClient ");
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
			strSql.Append("select count(1) FROM [" + DBName + @"].[dbo].tb_PosClient ");
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
				strSql.Append("order by T.id desc");
			}
			strSql.Append(")AS Row, T.*  from [" + DBName + @"].[dbo].tb_PosClient T ");
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

