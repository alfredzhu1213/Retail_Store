using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace Maticsoft.DAL
{
	/// <summary>
	/// 数据访问类:tb_MemberGift
	/// </summary>
	public partial class tb_MemberGiftDAL
	{
         public string DBName = "";
         public tb_MemberGiftDAL(string db)
         {
             DBName = db;
         }

		#region  Method

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from [" + DBName + @"].[dbo].tb_MemberGift");
			strSql.Append(" where id="+id+" ");
			return DbHelperSQL.Exists(strSql.ToString());
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Maticsoft.Model.tb_MemberGift model)
		{
			StringBuilder strSql=new StringBuilder();
			StringBuilder strSql1=new StringBuilder();
			StringBuilder strSql2=new StringBuilder();

            if (model.ProductId != null)
            {
                strSql1.Append("ProductId,");
                strSql2.Append("" + model.ProductId + ",");
            }
			if (model.Code != null)
			{
				strSql1.Append("Code,");
				strSql2.Append("'"+model.Code+"',");
			}
			if (model.Name != null)
			{
				strSql1.Append("Name,");
				strSql2.Append("'"+model.Name+"',");
			}
			if (model.Num != null)
			{
				strSql1.Append("Num,");
				strSql2.Append(""+model.Num+",");
			}
			if (model.IntegralNum != null)
			{
				strSql1.Append("IntegralNum,");
				strSql2.Append(""+model.IntegralNum+",");
			}
			if (model.StartDate != null)
			{
				strSql1.Append("StartDate,");
				strSql2.Append("'"+model.StartDate+"',");
			}
			if (model.EndDate != null)
			{
				strSql1.Append("EndDate,");
				strSql2.Append("'"+model.EndDate+"',");
			}
			if (model.CreateUserName != null)
			{
				strSql1.Append("CreateUserName,");
				strSql2.Append("'"+model.CreateUserName+"',");
			}
			if (model.CreateDate != null)
			{
				strSql1.Append("CreateDate,");
				strSql2.Append("'"+model.CreateDate+"',");
			}
			strSql.Append("insert into [" + DBName + @"].[dbo].tb_MemberGift(");
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
		public bool Update(Maticsoft.Model.tb_MemberGift model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update [" + DBName + @"].[dbo].tb_MemberGift set ");
            if (model.ProductId != null)
            {
                strSql.Append(" ProductId=" + model.ProductId + ",");
            }
			if (model.Code != null)
			{
				strSql.Append("Code='"+model.Code+"',");
			}
			if (model.Name != null)
			{
				strSql.Append("Name='"+model.Name+"',");
			}
			if (model.Num != null)
			{
				strSql.Append("Num="+model.Num+",");
			}
			if (model.IntegralNum != null)
			{
				strSql.Append("IntegralNum="+model.IntegralNum+",");
			}
			if (model.StartDate != null)
			{
				strSql.Append("StartDate='"+model.StartDate+"',");
			}
			if (model.EndDate != null)
			{
				strSql.Append("EndDate='"+model.EndDate+"',");
			}
            //if (model.CreateUserName != null)
            //{
            //    strSql.Append("CreateUserName='"+model.CreateUserName+"',");
            //}
            //else
            //{
            //    strSql.Append("CreateUserName= null ,");
            //}
            //if (model.CreateDate != null)
            //{
            //    strSql.Append("CreateDate='"+model.CreateDate+"',");
            //}
            //else
            //{
            //    strSql.Append("CreateDate= null ,");
            //}
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
			strSql.Append("delete from [" + DBName + @"].[dbo].tb_MemberGift ");
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
			strSql.Append("delete from [" + DBName + @"].[dbo].tb_MemberGift ");
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
		public Maticsoft.Model.tb_MemberGift GetModel(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  ");
			strSql.Append(" id,Code,Name,Num,IntegralNum,StartDate,EndDate,CreateUserName,CreateDate ");
			strSql.Append(" from [" + DBName + @"].[dbo].tb_MemberGift ");
			strSql.Append(" where id="+id+"" );
			Maticsoft.Model.tb_MemberGift model=new Maticsoft.Model.tb_MemberGift();
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
		public Maticsoft.Model.tb_MemberGift DataRowToModel(DataRow row)
		{
			Maticsoft.Model.tb_MemberGift model=new Maticsoft.Model.tb_MemberGift();
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
				if(row["Name"]!=null)
				{
					model.Name=row["Name"].ToString();
				}
				if(row["Num"]!=null && row["Num"].ToString()!="")
				{
					model.Num=decimal.Parse(row["Num"].ToString());
				}
				if(row["IntegralNum"]!=null && row["IntegralNum"].ToString()!="")
				{
					model.IntegralNum=int.Parse(row["IntegralNum"].ToString());
				}
				if(row["StartDate"]!=null)
				{
					model.StartDate=row["StartDate"].ToString();
				}
				if(row["EndDate"]!=null)
				{
					model.EndDate=row["EndDate"].ToString();
				}
				if(row["CreateUserName"]!=null)
				{
					model.CreateUserName=row["CreateUserName"].ToString();
				}
				if(row["CreateDate"]!=null && row["CreateDate"].ToString()!="")
				{
					model.CreateDate=DateTime.Parse(row["CreateDate"].ToString());
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
			strSql.Append("select id,Code,Name,Num,IntegralNum,StartDate,EndDate,CreateUserName,CreateDate ");
			strSql.Append(" FROM [" + DBName + @"].[dbo].tb_MemberGift ");
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
			strSql.Append(" id,Code,Name,Num,IntegralNum,StartDate,EndDate,CreateUserName,CreateDate ");
			strSql.Append(" FROM [" + DBName + @"].[dbo].tb_MemberGift ");
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
			strSql.Append("select count(1) FROM tb_MemberGift ");
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
			strSql.Append(")AS Row, T.*  from tb_MemberGift T ");
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

