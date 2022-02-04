using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace Maticsoft.DAL
{
	/// <summary>
	/// 数据访问类:tb_PromotionPlanSheetDetail
	/// </summary>
	public partial class tb_PromotionPlanSheetDetailDAL
	{

        public string DBName = "";
        public tb_PromotionPlanSheetDetailDAL(string db)
        {
            DBName = db;

        }

		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("id", "[" + DBName + @"].[dbo].tb_PromotionPlanSheetDetail"); 
		}


		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from [" + DBName + @"].[dbo].tb_PromotionPlanSheetDetail");
			strSql.Append(" where id="+id+" ");
			return DbHelperSQL.Exists(strSql.ToString());
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Maticsoft.Model.tb_PromotionPlanSheetDetail model)
		{
			StringBuilder strSql=new StringBuilder();
			StringBuilder strSql1=new StringBuilder();
			StringBuilder strSql2=new StringBuilder();
			
			if (model.ppsdId != null)
			{
				strSql1.Append("ppsdId,");
				strSql2.Append(""+model.ppsdId+",");
			}
			if (model.HHNo != null)
			{
				strSql1.Append("HHNo,");
				strSql2.Append("'"+model.HHNo+"',");
			}
			if (model.ProductName != null)
			{
				strSql1.Append("ProductName,");
				strSql2.Append("'"+model.ProductName+"',");
			}
			if (model.OldPrice != null)
			{
				strSql1.Append("OldPrice,");
				strSql2.Append(""+model.OldPrice+",");
			}
			if (model.MemberPrice != null)
			{
				strSql1.Append("MemberPrice,");
				strSql2.Append(""+model.MemberPrice+",");
			}
			if (model.JinGG != null)
			{
				strSql1.Append("JinGG,");
				strSql2.Append(""+model.JinGG+",");
			}
			if (model.tjPrice != null)
			{
				strSql1.Append("tjPrice,");
				strSql2.Append(""+model.tjPrice+",");
			}
			if (model.ZK != null)
			{
				strSql1.Append("ZK,");
				strSql2.Append(""+model.ZK+",");
			}
            if (model.ProductId != null)
            {
                strSql1.Append("ProductId,");
                strSql2.Append("" + model.ProductId + ",");
            }
			if (model.Addtime != null)
			{
				strSql1.Append("Addtime,");
				strSql2.Append("'"+model.Addtime+"',");
			}
			strSql.Append("insert into [" + DBName + @"].[dbo].tb_PromotionPlanSheetDetail(");
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
		public bool Update(Maticsoft.Model.tb_PromotionPlanSheetDetail model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update [" + DBName + @"].[dbo].tb_PromotionPlanSheetDetail set ");
			if (model.ppsdId != null)
			{
				strSql.Append("ppsdId="+model.ppsdId+",");
			}
			if (model.HHNo != null)
			{
				strSql.Append("HHNo='"+model.HHNo+"',");
			}
			else
			{
				strSql.Append("HHNo= null ,");
			}
			if (model.ProductName != null)
			{
				strSql.Append("ProductName='"+model.ProductName+"',");
			}
			if (model.OldPrice != null)
			{
				strSql.Append("OldPrice="+model.OldPrice+",");
			}
			if (model.MemberPrice != null)
			{
				strSql.Append("MemberPrice="+model.MemberPrice+",");
			}
			if (model.JinGG != null)
			{
				strSql.Append("JinGG="+model.JinGG+",");
			}
			if (model.tjPrice != null)
			{
				strSql.Append("tjPrice="+model.tjPrice+",");
			}
			else
			{
				strSql.Append("tjPrice= null ,");
			}
			if (model.ZK != null)
			{
				strSql.Append("ZK="+model.ZK+",");
			}
			else
			{
				strSql.Append("ZK= null ,");
			}
          
            if (model.ProductId != null)
            {
                strSql.Append("ProductId=" + model.ProductId + ",");
            }
            else
            {
                strSql.Append("ProductId= null ,");
            }
			if (model.Addtime != null)
			{
				strSql.Append("Addtime='"+model.Addtime+"',");
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
			strSql.Append("delete from [" + DBName + @"].[dbo].tb_PromotionPlanSheetDetail ");
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
			strSql.Append("delete from [" + DBName + @"].[dbo].tb_PromotionPlanSheetDetail ");
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
		public Maticsoft.Model.tb_PromotionPlanSheetDetail GetModel(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  ");
			strSql.Append(" id,ppsdId,HHNo,ProductName,OldPrice,MemberPrice,JinGG,tjPrice,ZK,Addtime ");
			strSql.Append(" from [" + DBName + @"].[dbo].tb_PromotionPlanSheetDetail ");
			strSql.Append(" where id="+id+" " );
			Maticsoft.Model.tb_PromotionPlanSheetDetail model=new Maticsoft.Model.tb_PromotionPlanSheetDetail();
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
		public Maticsoft.Model.tb_PromotionPlanSheetDetail DataRowToModel(DataRow row)
		{
			Maticsoft.Model.tb_PromotionPlanSheetDetail model=new Maticsoft.Model.tb_PromotionPlanSheetDetail();
			if (row != null)
			{
				if(row["id"]!=null && row["id"].ToString()!="")
				{
					model.id=int.Parse(row["id"].ToString());
				}
				if(row["ppsdId"]!=null && row["ppsdId"].ToString()!="")
				{
					model.ppsdId=int.Parse(row["ppsdId"].ToString());
				}
				if(row["HHNo"]!=null)
				{
					model.HHNo=row["HHNo"].ToString();
				}
				if(row["ProductName"]!=null)
				{
					model.ProductName=row["ProductName"].ToString();
				}
				if(row["OldPrice"]!=null && row["OldPrice"].ToString()!="")
				{
					model.OldPrice=decimal.Parse(row["OldPrice"].ToString());
				}
				if(row["MemberPrice"]!=null && row["MemberPrice"].ToString()!="")
				{
					model.MemberPrice=decimal.Parse(row["MemberPrice"].ToString());
				}
				if(row["JinGG"]!=null && row["JinGG"].ToString()!="")
				{
					model.JinGG=decimal.Parse(row["JinGG"].ToString());
				}
				if(row["tjPrice"]!=null && row["tjPrice"].ToString()!="")
				{
					model.tjPrice=decimal.Parse(row["tjPrice"].ToString());
				}
				if(row["ZK"]!=null && row["ZK"].ToString()!="")
				{
					model.ZK=decimal.Parse(row["ZK"].ToString());
				}
				if(row["Addtime"]!=null && row["Addtime"].ToString()!="")
				{
					model.Addtime=DateTime.Parse(row["Addtime"].ToString());
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
			strSql.Append("select id,ppsdId,HHNo,ProductName,OldPrice,MemberPrice,JinGG,tjPrice,ZK,Addtime ");
			strSql.Append(" FROM [" + DBName + @"].[dbo].tb_PromotionPlanSheetDetail ");
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
			strSql.Append(" id,ppsdId,HHNo,ProductName,OldPrice,MemberPrice,JinGG,tjPrice,ZK,Addtime ");
			strSql.Append(" FROM [" + DBName + @"].[dbo].tb_PromotionPlanSheetDetail ");
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
			strSql.Append("select count(1) FROM [" + DBName + @"].[dbo].tb_PromotionPlanSheetDetail ");
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
			strSql.Append(")AS Row, T.*  from [" + DBName + @"].[dbo].tb_PromotionPlanSheetDetail T ");
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

