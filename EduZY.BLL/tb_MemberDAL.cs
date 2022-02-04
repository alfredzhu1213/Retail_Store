using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace Maticsoft.DAL
{
	/// <summary>
	/// 数据访问类:tb_Member
	/// </summary>
	public partial class tb_MemberDAL
	{
	
        public string DBName = "";
         public tb_MemberDAL(string db)
		{
            DBName = db;     
        
        }
		#region  Method

		/// <summary>
		/// 是否存在该记录
		/// </summary>
         public bool Exists(string Code )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from [" + DBName + @"].[dbo].tb_Member");
            strSql.Append(" where Code=" + Code + " ");
			return DbHelperSQL.Exists(strSql.ToString());
		}



        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Maticsoft.Model.tb_Member model)
        {
            StringBuilder strSql = new StringBuilder();
            StringBuilder strSql1 = new StringBuilder();
            StringBuilder strSql2 = new StringBuilder();
            if (model.Code != null)
            {
                strSql1.Append("Code,");
                strSql2.Append("'" + model.Code + "',");
            }
            if (model.CardCode != null)
            {
                strSql1.Append("CardCode,");
                strSql2.Append("'" + model.CardCode + "',");
            }
            if (model.Pwd != null)
            {
                strSql1.Append("Pwd,");
                strSql2.Append("'" + model.Pwd + "',");
            }
            if (model.Amount != null)
            {
                strSql1.Append("Amount,");
                strSql2.Append("" + model.Amount + ",");
            }
            if (model.XfAmount != null)
            {
                strSql1.Append("XfAmount,");
                strSql2.Append("" + model.XfAmount + ",");
            }
            if (model.XfSum != null)
            {
                strSql1.Append("XfSum,");
                strSql2.Append("" + model.XfSum + ",");
            }
            if (model.SumIntegral != null)
            {
                strSql1.Append("SumIntegral,");
                strSql2.Append("" + model.SumIntegral + ",");
            }
            if (model.keYongIntegral != null)
            {
                strSql1.Append("keYongIntegral,");
                strSql2.Append("" + model.keYongIntegral + ",");
            }
            if (model.UsedIntegral != null)
            {
                strSql1.Append("UsedIntegral,");
                strSql2.Append("" + model.UsedIntegral + ",");
            }
            if (model.TrueName != null)
            {
                strSql1.Append("TrueName,");
                strSql2.Append("'" + model.TrueName + "',");
            }
            if (model.MemberTypeId != null)
            {
                strSql1.Append("MemberTypeId,");
                strSql2.Append("" + model.MemberTypeId + ",");
            }
            if (model.MemberTypeName != null)
            {
                strSql1.Append("MemberTypeName,");
                strSql2.Append("'" + model.MemberTypeName + "',");
            }
            if (model.Sex != null)
            {
                strSql1.Append("Sex,");
                strSql2.Append("'" + model.Sex + "',");
            }
            if (model.Mobile != null)
            {
                strSql1.Append("Mobile,");
                strSql2.Append("'" + model.Mobile + "',");
            }
            if (model.BirthDate != null)
            {
                strSql1.Append("BirthDate,");
                strSql2.Append("'" + model.BirthDate + "',");
            }
            if (model.Email != null)
            {
                strSql1.Append("Email,");
                strSql2.Append("'" + model.Email + "',");
            }
            if (model.Status != null)
            {
                strSql1.Append("Status,");
                strSql2.Append("'" + model.Status + "',");
            }
            strSql.Append("insert into [" + DBName + @"].[dbo].tb_Member(");
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
		public bool Update(Maticsoft.Model.tb_Member model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update [" + DBName + @"].[dbo].tb_Member set ");
			if (model.Code != null)
			{
				strSql.Append("Code='"+model.Code+"',");
			}
			else
			{
				strSql.Append("Code= null ,");
			}
			if (model.CardCode != null)
			{
				strSql.Append("CardCode='"+model.CardCode+"',");
			}
			else
			{
				strSql.Append("CardCode= null ,");
			}
			if (model.Pwd != null)
			{
				strSql.Append("Pwd='"+model.Pwd+"',");
			}
			else
			{
				strSql.Append("Pwd= null ,");
			}
			if (model.TrueName != null)
			{
				strSql.Append("TrueName='"+model.TrueName+"',");
			}
			else
			{
				strSql.Append("TrueName= null ,");
			}
			if (model.MemberTypeId != null)
			{
				strSql.Append("MemberTypeId="+model.MemberTypeId+",");
			}
			else
			{
				strSql.Append("MemberTypeId= null ,");
			}
			if (model.MemberTypeName != null)
			{
				strSql.Append("MemberTypeName='"+model.MemberTypeName+"',");
			}
			else
			{
				strSql.Append("MemberTypeName= null ,");
			}
			if (model.Sex != null)
			{
				strSql.Append("Sex='"+model.Sex+"',");
			}
			else
			{
				strSql.Append("Sex= null ,");
			}
			if (model.Mobile != null)
			{
				strSql.Append("Mobile='"+model.Mobile+"',");
			}
			else
			{
				strSql.Append("Mobile= null ,");
			}
			if (model.BirthDate != null)
			{
				strSql.Append("BirthDate='"+model.BirthDate+"',");
			}
			else
			{
				strSql.Append("BirthDate= null ,");
			}
			if (model.Email != null)
			{
				strSql.Append("Email='"+model.Email+"',");
			}
			else
			{
				strSql.Append("Email= null ,");
			}
			if (model.Status != null)
			{
				strSql.Append("Status='"+model.Status+"',");
			}
			else
			{
				strSql.Append("Status= null ,");
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
			strSql.Append("delete from [" + DBName + @"].[dbo].tb_Member ");
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
			strSql.Append("delete from [" + DBName + @"].[dbo].tb_Member ");
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
		public Maticsoft.Model.tb_Member GetModel(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  ");
            strSql.Append(" id,Code,CardCode,Pwd,Amount,XfAmount,XfSum,SumIntegral,keYongIntegral,UsedIntegral,TrueName,MemberTypeId,MemberTypeName,Sex,Mobile,BirthDate,Email,Status ");
            strSql.Append(" from [" + DBName + @"].[dbo].tb_Member ");
			strSql.Append(" where id="+id+"" );
			Maticsoft.Model.tb_Member model=new Maticsoft.Model.tb_Member();
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
        public Maticsoft.Model.tb_Member GetModeltb_Member(string Code)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1  ");
            strSql.Append(" id,Code,CardCode,Pwd,Amount,XfAmount,XfSum,SumIntegral,keYongIntegral,UsedIntegral,TrueName,MemberTypeId,MemberTypeName,Sex,Mobile,BirthDate,Email,Status ");
            strSql.Append(" from [" + DBName + @"].[dbo].tb_Member ");

            strSql.Append(" where Code=" + Code + "");
            Maticsoft.Model.tb_Member model = new Maticsoft.Model.tb_Member();
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            if (ds.Tables[0].Rows.Count > 0)
            {
                return DataRowToModel(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }

        public Maticsoft.Model.tb_Member DataRowToModel(DataRow row)
        {
            Maticsoft.Model.tb_Member model = new Maticsoft.Model.tb_Member();
            if (row != null)
            {
                if (row["id"] != null && row["id"].ToString() != "")
                {
                    model.id = int.Parse(row["id"].ToString());
                }
                if (row["Code"] != null)
                {
                    model.Code = row["Code"].ToString();
                }
                if (row["CardCode"] != null)
                {
                    model.CardCode = row["CardCode"].ToString();
                }
                if (row["Pwd"] != null)
                {
                    model.Pwd = row["Pwd"].ToString();
                }
                if (row["Amount"] != null && row["Amount"].ToString() != "")
                {
                    model.Amount = decimal.Parse(row["Amount"].ToString());
                }
                if (row["XfAmount"] != null && row["XfAmount"].ToString() != "")
                {
                    model.XfAmount = decimal.Parse(row["XfAmount"].ToString());
                }
                if (row["XfSum"] != null && row["XfSum"].ToString() != "")
                {
                    model.XfSum = int.Parse(row["XfSum"].ToString());
                }
                if (row["SumIntegral"] != null && row["SumIntegral"].ToString() != "")
                {
                    model.SumIntegral = int.Parse(row["SumIntegral"].ToString());
                }
                if (row["keYongIntegral"] != null && row["keYongIntegral"].ToString() != "")
                {
                    model.keYongIntegral = int.Parse(row["keYongIntegral"].ToString());
                }
                if (row["UsedIntegral"] != null && row["UsedIntegral"].ToString() != "")
                {
                    model.UsedIntegral = int.Parse(row["UsedIntegral"].ToString());
                }
                if (row["TrueName"] != null)
                {
                    model.TrueName = row["TrueName"].ToString();
                }
                if (row["MemberTypeId"] != null && row["MemberTypeId"].ToString() != "")
                {
                    model.MemberTypeId = int.Parse(row["MemberTypeId"].ToString());
                }
                if (row["MemberTypeName"] != null)
                {
                    model.MemberTypeName = row["MemberTypeName"].ToString();
                }
                if (row["Sex"] != null)
                {
                    model.Sex = row["Sex"].ToString();
                }
                if (row["Mobile"] != null)
                {
                    model.Mobile = row["Mobile"].ToString();
                }
                if (row["BirthDate"] != null)
                {
                    model.BirthDate = row["BirthDate"].ToString();
                }
                if (row["Email"] != null)
                {
                    model.Email = row["Email"].ToString();
                }
                if (row["Status"] != null)
                {
                    model.Status = row["Status"].ToString();
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
			strSql.Append("select id,Code,CardCode,Pwd,TrueName,MemberTypeId,MemberTypeName,Sex,Mobile,BirthDate,Email,Status ");
			strSql.Append(" FROM [" + DBName + @"].[dbo].tb_Member ");
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
			strSql.Append(" id,Code,CardCode,Pwd,TrueName,MemberTypeId,MemberTypeName,Sex,Mobile,BirthDate,Email,Status ");
			strSql.Append(" FROM [" + DBName + @"].[dbo].tb_Member ");
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
			strSql.Append("select count(1) FROM [" + DBName + @"].[dbo].tb_Member ");
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
			strSql.Append(")AS Row, T.*  from [" + DBName + @"].[dbo].tb_Member T ");
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

