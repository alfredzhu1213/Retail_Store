using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace Maticsoft.DAL
{
	/// <summary>
	/// 数据访问类:tb_PurchaseOrderReturn
	/// </summary>
	public partial class tb_PurchaseOrderReturnDAL
	{
	    public string DBName = "";
        public tb_PurchaseOrderReturnDAL(string db)
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
			strSql.Append("select count(1) from [" + DBName + @"].[dbo].tb_PurchaseOrderReturn");
			strSql.Append(" where id="+id+" ");
			return DbHelperSQL.Exists(strSql.ToString());
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Maticsoft.Model.tb_PurchaseOrderReturn model)
		{
			StringBuilder strSql=new StringBuilder();
			StringBuilder strSql1=new StringBuilder();
			StringBuilder strSql2=new StringBuilder();
			if (model.SerialNum != null)
			{
				strSql1.Append("SerialNum,");
				strSql2.Append("'"+model.SerialNum+"',");
			}
			if (model.AcceptSerialNum != null)
			{
				strSql1.Append("AcceptSerialNum,");
				strSql2.Append("'"+model.AcceptSerialNum+"',");
			}
			if (model.SupId != null)
			{
				strSql1.Append("SupId,");
				strSql2.Append(""+model.SupId+",");
			}
			if (model.SupCode != null)
			{
				strSql1.Append("SupCode,");
				strSql2.Append("'"+model.SupCode+"',");
			}
			if (model.StoreId != null)
			{
				strSql1.Append("StoreId,");
				strSql2.Append(""+model.StoreId+",");
			}
			if (model.StoreCode != null)
			{
				strSql1.Append("StoreCode,");
				strSql2.Append("'"+model.StoreCode+"',");
			}
			if (model.Remark != null)
			{
				strSql1.Append("Remark,");
				strSql2.Append("'"+model.Remark+"',");
			}
			if (model.Status != null)
			{
				strSql1.Append("Status,");
				strSql2.Append("'"+model.Status+"',");
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
			if (model.ApprUserName != null)
			{
				strSql1.Append("ApprUserName,");
				strSql2.Append("'"+model.ApprUserName+"',");
			}
			if (model.ApprDate != null)
			{
				strSql1.Append("ApprDate,");
				strSql2.Append("'"+model.ApprDate+"',");
			}
			if (model.HandledUserName != null)
			{
				strSql1.Append("HandledUserName,");
				strSql2.Append("'"+model.HandledUserName+"',");
			}
			strSql.Append("insert into [" + DBName + @"].[dbo].tb_PurchaseOrderReturn(");
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
		public bool Update(Maticsoft.Model.tb_PurchaseOrderReturn model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update [" + DBName + @"].[dbo].tb_PurchaseOrderReturn set ");
			if (model.SerialNum != null)
			{
				strSql.Append("SerialNum='"+model.SerialNum+"',");
			}
			else
			{
				strSql.Append("SerialNum= null ,");
			}
			if (model.AcceptSerialNum != null)
			{
				strSql.Append("AcceptSerialNum='"+model.AcceptSerialNum+"',");
			}
			else
			{
				strSql.Append("AcceptSerialNum= null ,");
			}
			if (model.SupId != null)
			{
				strSql.Append("SupId="+model.SupId+",");
			}
			else
			{
				strSql.Append("SupId= null ,");
			}
			if (model.SupCode != null)
			{
				strSql.Append("SupCode='"+model.SupCode+"',");
			}
			else
			{
				strSql.Append("SupCode= null ,");
			}
			if (model.StoreId != null)
			{
				strSql.Append("StoreId="+model.StoreId+",");
			}
			else
			{
				strSql.Append("StoreId= null ,");
			}
			if (model.StoreCode != null)
			{
				strSql.Append("StoreCode='"+model.StoreCode+"',");
			}
			else
			{
				strSql.Append("StoreCode= null ,");
			}
			if (model.Remark != null)
			{
				strSql.Append("Remark='"+model.Remark+"',");
			}
			else
			{
				strSql.Append("Remark= null ,");
			}
			if (model.Status != null)
			{
				strSql.Append("Status='"+model.Status+"',");
			}
			else
			{
				strSql.Append("Status= null ,");
			}
			if (model.CreateUserName != null)
			{
				strSql.Append("CreateUserName='"+model.CreateUserName+"',");
			}
			else
			{
				strSql.Append("CreateUserName= null ,");
			}
			if (model.CreateDate != null)
			{
				strSql.Append("CreateDate='"+model.CreateDate+"',");
			}
			else
			{
				strSql.Append("CreateDate= null ,");
			}
			if (model.ApprUserName != null)
			{
				strSql.Append("ApprUserName='"+model.ApprUserName+"',");
			}
			else
			{
				strSql.Append("ApprUserName= null ,");
			}
			if (model.ApprDate != null)
			{
				strSql.Append("ApprDate='"+model.ApprDate+"',");
			}
			else
			{
				strSql.Append("ApprDate= null ,");
			}
			if (model.HandledUserName != null)
			{
				strSql.Append("HandledUserName='"+model.HandledUserName+"',");
			}
			else
			{
				strSql.Append("HandledUserName= null ,");
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
			strSql.Append("delete from [" + DBName + @"].[dbo].tb_PurchaseOrderReturn ");
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
			strSql.Append("delete from [" + DBName + @"].[dbo].tb_PurchaseOrderReturn ");
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
		public Maticsoft.Model.tb_PurchaseOrderReturn GetModel(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  ");
			strSql.Append(" id,SerialNum,AcceptSerialNum,SupId,SupCode,StoreId,StoreCode,Remark,Status,CreateUserName,CreateDate,ApprUserName,ApprDate,HandledUserName ");
			strSql.Append(" from [" + DBName + @"].[dbo].tb_PurchaseOrderReturn ");
			strSql.Append(" where id="+id+"" );
			Maticsoft.Model.tb_PurchaseOrderReturn model=new Maticsoft.Model.tb_PurchaseOrderReturn();
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
		public Maticsoft.Model.tb_PurchaseOrderReturn DataRowToModel(DataRow row)
		{
			Maticsoft.Model.tb_PurchaseOrderReturn model=new Maticsoft.Model.tb_PurchaseOrderReturn();
			if (row != null)
			{
				if(row["id"]!=null && row["id"].ToString()!="")
				{
					model.id=int.Parse(row["id"].ToString());
				}
				if(row["SerialNum"]!=null)
				{
					model.SerialNum=row["SerialNum"].ToString();
				}
				if(row["AcceptSerialNum"]!=null)
				{
					model.AcceptSerialNum=row["AcceptSerialNum"].ToString();
				}
				if(row["SupId"]!=null && row["SupId"].ToString()!="")
				{
					model.SupId=int.Parse(row["SupId"].ToString());
				}
				if(row["SupCode"]!=null)
				{
					model.SupCode=row["SupCode"].ToString();
				}
				if(row["StoreId"]!=null && row["StoreId"].ToString()!="")
				{
					model.StoreId=int.Parse(row["StoreId"].ToString());
				}
				if(row["StoreCode"]!=null)
				{
					model.StoreCode=row["StoreCode"].ToString();
				}
				if(row["Remark"]!=null)
				{
					model.Remark=row["Remark"].ToString();
				}
				if(row["Status"]!=null)
				{
					model.Status=row["Status"].ToString();
				}
				if(row["CreateUserName"]!=null)
				{
					model.CreateUserName=row["CreateUserName"].ToString();
				}
				if(row["CreateDate"]!=null && row["CreateDate"].ToString()!="")
				{
					model.CreateDate=DateTime.Parse(row["CreateDate"].ToString());
				}
				if(row["ApprUserName"]!=null)
				{
					model.ApprUserName=row["ApprUserName"].ToString();
				}
				if(row["ApprDate"]!=null && row["ApprDate"].ToString()!="")
				{
					model.ApprDate=DateTime.Parse(row["ApprDate"].ToString());
				}
				if(row["HandledUserName"]!=null)
				{
					model.HandledUserName=row["HandledUserName"].ToString();
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
			strSql.Append("select id,SerialNum,AcceptSerialNum,SupId,SupCode,StoreId,StoreCode,Remark,Status,CreateUserName,CreateDate,ApprUserName,ApprDate,HandledUserName ");
			strSql.Append(" FROM [" + DBName + @"].[dbo].tb_PurchaseOrderReturn ");
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
			strSql.Append(" id,SerialNum,AcceptSerialNum,SupId,SupCode,StoreId,StoreCode,Remark,Status,CreateUserName,CreateDate,ApprUserName,ApprDate,HandledUserName ");
			strSql.Append(" FROM [" + DBName + @"].[dbo].tb_PurchaseOrderReturn ");
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
			strSql.Append("select count(1) FROM [" + DBName + @"].[dbo].tb_PurchaseOrderReturn ");
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
			strSql.Append(")AS Row, T.*  from [" + DBName + @"].[dbo].tb_PurchaseOrderReturn T ");
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

