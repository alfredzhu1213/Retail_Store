using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace Maticsoft.DAL
{
	/// <summary>
	/// 数据访问类:tb_PurchaseBasicSet
	/// </summary>
	public partial class tb_PurchaseBasicSetDAL
	{
         public string DBName = "";
         public tb_PurchaseBasicSetDAL(string db)
		{
            DBName = db;     
        
        }
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("id", "[" + DBName + @"].[dbo].[tb_PurchaseBasicSet]"); 
		}


		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from [" + DBName + @"].[dbo].[tb_PurchaseBasicSet]");
			strSql.Append(" where id="+id+" ");
			return DbHelperSQL.Exists(strSql.ToString());
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Maticsoft.Model.tb_PurchaseBasicSet model)
		{
			StringBuilder strSql=new StringBuilder();
			StringBuilder strSql1=new StringBuilder();
			StringBuilder strSql2=new StringBuilder();
			if (model.SetStatus1 != null)
			{
				strSql1.Append("SetStatus1,");
				strSql2.Append(""+model.SetStatus1+",");
			}
			if (model.SetStatus2 != null)
			{
				strSql1.Append("SetStatus2,");
				strSql2.Append(""+model.SetStatus2+",");
			}
			if (model.SetStatus3 != null)
			{
				strSql1.Append("SetStatus3,");
				strSql2.Append(""+model.SetStatus3+",");
			}
			if (model.SetStatus4 != null)
			{
				strSql1.Append("SetStatus4,");
				strSql2.Append(""+model.SetStatus4+",");
			}
			strSql.Append("insert into [" + DBName + @"].[dbo].[tb_PurchaseBasicSet](");
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
		public bool Update(Maticsoft.Model.tb_PurchaseBasicSet model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update [" + DBName + @"].[dbo].[tb_PurchaseBasicSet] set ");
			if (model.SetStatus1 != null)
			{
				strSql.Append("SetStatus1="+model.SetStatus1+",");
			}
			else
			{
				strSql.Append("SetStatus1= null ,");
			}
			if (model.SetStatus2 != null)
			{
				strSql.Append("SetStatus2="+model.SetStatus2+",");
			}
			else
			{
				strSql.Append("SetStatus2= null ,");
			}
			if (model.SetStatus3 != null)
			{
				strSql.Append("SetStatus3="+model.SetStatus3+",");
			}
			else
			{
				strSql.Append("SetStatus3= null ,");
			}
			if (model.SetStatus4 != null)
			{
				strSql.Append("SetStatus4="+model.SetStatus4+",");
			}
			else
			{
				strSql.Append("SetStatus4= null ,");
			}
			int n = strSql.ToString().LastIndexOf(",");
			strSql.Remove(n, 1);
			strSql.Append(" where id="+ model.id+"");
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
			strSql.Append("delete from [" + DBName + @"].[dbo].[tb_PurchaseBasicSet] ");
			strSql.Append(" where id="+id+"" );
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
			strSql.Append("delete from [" + DBName + @"].[dbo].[tb_PurchaseBasicSet] ");
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
		public Maticsoft.Model.tb_PurchaseBasicSet GetModel(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  ");
			strSql.Append(" id,SetStatus1,SetStatus2,SetStatus3,SetStatus4 ");
			strSql.Append(" from [" + DBName + @"].[dbo].[tb_PurchaseBasicSet] ");
			Maticsoft.Model.tb_PurchaseBasicSet model=new Maticsoft.Model.tb_PurchaseBasicSet();
			DataSet ds=DbHelperSQL.Query(strSql.ToString());
			if(ds.Tables[0].Rows.Count>0)
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
		public Maticsoft.Model.tb_PurchaseBasicSet DataRowToModel(DataRow row)
		{
			Maticsoft.Model.tb_PurchaseBasicSet model=new Maticsoft.Model.tb_PurchaseBasicSet();
			if (row != null)
			{
				if(row["id"]!=null && row["id"].ToString()!="")
				{
					model.id=int.Parse(row["id"].ToString());
				}
				if(row["SetStatus1"]!=null && row["SetStatus1"].ToString()!="")
				{
					model.SetStatus1=int.Parse(row["SetStatus1"].ToString());
				}
				if(row["SetStatus2"]!=null && row["SetStatus2"].ToString()!="")
				{
					model.SetStatus2=int.Parse(row["SetStatus2"].ToString());
				}
				if(row["SetStatus3"]!=null && row["SetStatus3"].ToString()!="")
				{
					model.SetStatus3=int.Parse(row["SetStatus3"].ToString());
				}
				if(row["SetStatus4"]!=null && row["SetStatus4"].ToString()!="")
				{
					model.SetStatus4=int.Parse(row["SetStatus4"].ToString());
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
			strSql.Append("select id,SetStatus1,SetStatus2,SetStatus3,SetStatus4 ");
			strSql.Append(" FROM [" + DBName + @"].[dbo].[tb_PurchaseBasicSet] ");
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
			strSql.Append(" id,SetStatus1,SetStatus2,SetStatus3,SetStatus4 ");
			strSql.Append(" FROM [" + DBName + @"].[dbo].[tb_PurchaseBasicSet] ");
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
			strSql.Append("select count(1) FROM [" + DBName + @"].[dbo].[tb_PurchaseBasicSet] ");
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
			strSql.Append(")AS Row, T.*  from [" + DBName + @"].[dbo].[tb_PurchaseBasicSet] T ");
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

