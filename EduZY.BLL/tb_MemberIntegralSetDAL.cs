using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace Maticsoft.DAL
{
	/// <summary>
	/// 数据访问类:tb_MemberIntegralSet
	/// </summary>
    public partial class tb_MemberIntegralSetDAL
	{


         public string DBName = "";
         public tb_MemberIntegralSetDAL(string db)
		{
            DBName = db;     
        
        }
		#region  Method

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int Id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from [" + DBName + @"].[dbo].tb_MemberIntegralSet");
			strSql.Append(" where Id="+Id+" ");
			return DbHelperSQL.Exists(strSql.ToString());
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Maticsoft.Model.tb_MemberIntegralSet model)
		{
			StringBuilder strSql=new StringBuilder();
			StringBuilder strSql1=new StringBuilder();
			StringBuilder strSql2=new StringBuilder();
			if (model.xfPrice != null)
			{
				strSql1.Append("xfPrice,");
				strSql2.Append(""+model.xfPrice+",");
			}
			if (model.IsPayIntegralEnable != null)
			{
				strSql1.Append("IsPayIntegralEnable,");
				strSql2.Append(""+model.IsPayIntegralEnable+",");
			}
			if (model.Integral != null)
			{
				strSql1.Append("Integral,");
				strSql2.Append(""+model.Integral+",");
			}
			if (model.diPrice != null)
			{
				strSql1.Append("diPrice,");
				strSql2.Append(""+model.diPrice+",");
			}
			if (model.IsScorePayingNoScoring != null)
			{
				strSql1.Append("IsScorePayingNoScoring,");
				strSql2.Append(""+model.IsScorePayingNoScoring+",");
			}
			strSql.Append("insert into [" + DBName + @"].[dbo].tb_MemberIntegralSet(");
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
		public bool Update(Maticsoft.Model.tb_MemberIntegralSet model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update [" + DBName + @"].[dbo].tb_MemberIntegralSet set ");
			if (model.xfPrice != null)
			{
				strSql.Append("xfPrice="+model.xfPrice+",");
			}
			else
			{
				strSql.Append("xfPrice= null ,");
			}
			if (model.IsPayIntegralEnable != null)
			{
				strSql.Append("IsPayIntegralEnable="+model.IsPayIntegralEnable+",");
			}
			else
			{
				strSql.Append("IsPayIntegralEnable= null ,");
			}
			if (model.Integral != null)
			{
				strSql.Append("Integral="+model.Integral+",");
			}
			else
			{
				strSql.Append("Integral= null ,");
			}
			if (model.diPrice != null)
			{
				strSql.Append("diPrice="+model.diPrice+",");
			}
			else
			{
				strSql.Append("diPrice= null ,");
			}
			if (model.IsScorePayingNoScoring != null)
			{
				strSql.Append("IsScorePayingNoScoring="+model.IsScorePayingNoScoring+",");
			}
			else
			{
				strSql.Append("IsScorePayingNoScoring= null ,");
			}
			int n = strSql.ToString().LastIndexOf(",");
			strSql.Remove(n, 1);
			strSql.Append(" where Id="+ model.Id+"");
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
		public bool Delete(int Id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from [" + DBName + @"].[dbo].tb_MemberIntegralSet ");
			strSql.Append(" where Id="+Id+"" );
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
		public bool DeleteList(string Idlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from [" + DBName + @"].[dbo].tb_MemberIntegralSet ");
			strSql.Append(" where Id in ("+Idlist + ")  ");
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
		public Maticsoft.Model.tb_MemberIntegralSet GetModel(int Id)
		{

			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  ");
			strSql.Append(" Id,xfPrice,IsPayIntegralEnable,Integral,diPrice,IsScorePayingNoScoring ");
			strSql.Append(" from [" + DBName + @"].[dbo].tb_MemberIntegralSet ");
			Maticsoft.Model.tb_MemberIntegralSet model=new Maticsoft.Model.tb_MemberIntegralSet();
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
		public Maticsoft.Model.tb_MemberIntegralSet DataRowToModel(DataRow row)
		{
			Maticsoft.Model.tb_MemberIntegralSet model=new Maticsoft.Model.tb_MemberIntegralSet();
			if (row != null)
			{
				if(row["Id"]!=null && row["Id"].ToString()!="")
				{
					model.Id=int.Parse(row["Id"].ToString());
				}
				if(row["xfPrice"]!=null && row["xfPrice"].ToString()!="")
				{
					model.xfPrice=decimal.Parse(row["xfPrice"].ToString());
				}
				if(row["IsPayIntegralEnable"]!=null && row["IsPayIntegralEnable"].ToString()!="")
				{
					model.IsPayIntegralEnable=int.Parse(row["IsPayIntegralEnable"].ToString());
				}
				if(row["Integral"]!=null && row["Integral"].ToString()!="")
				{
					model.Integral=decimal.Parse(row["Integral"].ToString());
				}
				if(row["diPrice"]!=null && row["diPrice"].ToString()!="")
				{
					model.diPrice=decimal.Parse(row["diPrice"].ToString());
				}
				if(row["IsScorePayingNoScoring"]!=null && row["IsScorePayingNoScoring"].ToString()!="")
				{
					model.IsScorePayingNoScoring=int.Parse(row["IsScorePayingNoScoring"].ToString());
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
			strSql.Append("select Id,xfPrice,IsPayIntegralEnable,Integral,diPrice,IsScorePayingNoScoring ");
			strSql.Append(" FROM [" + DBName + @"].[dbo].tb_MemberIntegralSet ");
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
			strSql.Append(" Id,xfPrice,IsPayIntegralEnable,Integral,diPrice,IsScorePayingNoScoring ");
			strSql.Append(" FROM [" + DBName + @"].[dbo].tb_MemberIntegralSet ");
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
			strSql.Append("select count(1) FROM [" + DBName + @"].[dbo].tb_MemberIntegralSet ");
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
				strSql.Append("order by T.Id desc");
			}
			strSql.Append(")AS Row, T.*  from [" + DBName + @"].[dbo].tb_MemberIntegralSet T ");
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

