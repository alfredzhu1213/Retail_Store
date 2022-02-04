using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace Maticsoft.DAL
{
	/// <summary>
	/// 数据访问类:tb_Store
	/// </summary>
	public partial class tb_StoreDAL
	{
      	public string DBName = "";
        public tb_StoreDAL(string db)
		{
            DBName = db;     
        
        }
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("id", "[" + DBName + @"].[dbo].[tb_Store]"); 
		}


		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from [" + DBName + @"].[dbo].[tb_Store]");
			strSql.Append(" where id="+id+" ");
			return DbHelperSQL.Exists(strSql.ToString());
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Maticsoft.Model.tb_Store model)
		{
			StringBuilder strSql=new StringBuilder();
			StringBuilder strSql1=new StringBuilder();
			StringBuilder strSql2=new StringBuilder();
		
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
			if (model.lxr != null)
			{
				strSql1.Append("lxr,");
				strSql2.Append("'"+model.lxr+"',");
			}
			if (model.Tel != null)
			{
				strSql1.Append("Tel,");
				strSql2.Append("'"+model.Tel+"',");
			}
			if (model.Address != null)
			{
				strSql1.Append("Address,");
				strSql2.Append("'"+model.Address+"',");
			}
			if (model.AddTime != null)
			{
				strSql1.Append("AddTime,");
				strSql2.Append("'"+model.AddTime+"',");
			}
			strSql.Append("insert into [" + DBName + @"].[dbo].[tb_Store](");
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
		public bool Update(Maticsoft.Model.tb_Store model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update [" + DBName + @"].[dbo].[tb_Store] set ");
			if (model.Code != null)
			{
				strSql.Append("Code='"+model.Code+"',");
			}
			if (model.name != null)
			{
				strSql.Append("name='"+model.name+"',");
			}
			if (model.lxr != null)
			{
				strSql.Append("lxr='"+model.lxr+"',");
			}
			else
			{
				strSql.Append("lxr= null ,");
			}
			if (model.Tel != null)
			{
				strSql.Append("Tel='"+model.Tel+"',");
			}
			else
			{
				strSql.Append("Tel= null ,");
			}
			if (model.Address != null)
			{
				strSql.Append("Address='"+model.Address+"',");
			}
			else
			{
				strSql.Append("Address= null ,");
			}
			if (model.AddTime != null)
			{
				strSql.Append("AddTime='"+model.AddTime+"',");
			}
			else
			{
				strSql.Append("AddTime= null ,");
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
			strSql.Append("delete from [" + DBName + @"].[dbo].[tb_Store] ");
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
			strSql.Append("delete from [" + DBName + @"].[dbo].[tb_Store] ");
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
		public Maticsoft.Model.tb_Store GetModel(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  ");
			strSql.Append(" id,Code,name,lxr,Tel,Address,AddTime ");
			strSql.Append(" from [" + DBName + @"].[dbo].[tb_Store] ");
			strSql.Append(" where id="+id+" " );
			Maticsoft.Model.tb_Store model=new Maticsoft.Model.tb_Store();
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
		public Maticsoft.Model.tb_Store DataRowToModel(DataRow row)
		{
			Maticsoft.Model.tb_Store model=new Maticsoft.Model.tb_Store();
			if (row != null)
			{
				if(row["id"]!=null && row["id"].ToString()!="")
				{
					model.id=int.Parse(row["id"].ToString());
				}
				if(row["Code"]!=null)
				{
					model.Code=row["Code"].ToString();
				}
				if(row["name"]!=null)
				{
					model.name=row["name"].ToString();
				}
				if(row["lxr"]!=null)
				{
					model.lxr=row["lxr"].ToString();
				}
				if(row["Tel"]!=null)
				{
					model.Tel=row["Tel"].ToString();
				}
				if(row["Address"]!=null)
				{
					model.Address=row["Address"].ToString();
				}
				if(row["AddTime"]!=null && row["AddTime"].ToString()!="")
				{
					model.AddTime=DateTime.Parse(row["AddTime"].ToString());
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
			strSql.Append("select id,Code,name,lxr,Tel,Address,AddTime ");
			strSql.Append(" FROM [" + DBName + @"].[dbo].[tb_Store] ");
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
			strSql.Append(" id,Code,name,lxr,Tel,Address,AddTime ");
			strSql.Append(" FROM [" + DBName + @"].[dbo].[tb_Store] ");
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
			strSql.Append("select count(1) FROM [" + DBName + @"].[dbo].[tb_Store] ");
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
			strSql.Append(")AS Row, T.*  from [" + DBName + @"].[dbo].[tb_Store] T ");
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

