using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace Maticsoft.DAL
{
	/// <summary>
	/// 数据访问类:tb_PosSaleSetting
	/// </summary>
	public partial class tb_PosSaleSettingDAL
	{
	    public string DBName = "";
        public tb_PosSaleSettingDAL(string db)
		{
            DBName = db;     
        
        }

		#region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from [" + DBName + @"].[dbo].tb_PosSaleSetting");

			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Maticsoft.Model.tb_PosSaleSetting model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into [" + DBName + @"].[dbo].tb_PosSaleSetting(");
			strSql.Append("IsAutoFreshNoGroup,IsAutoBarcode,IsDefineItemNo,IsAutoPriceCreate,SmallChangeRound,IsPrintItemShortName,IsPrintSumDiscount,BillPrintTitle,BillPrintBranch,BillPrintFooter1,BillPrintFooter2,BillPrintFooter3,BillPrintFooter4,BillPrintFooter5,BillPrintFooter6,BillPrintFooter7,BillPrintFooter8)");
			strSql.Append(" values (");
			strSql.Append("@IsAutoFreshNoGroup,@IsAutoBarcode,@IsDefineItemNo,@IsAutoPriceCreate,@SmallChangeRound,@IsPrintItemShortName,@IsPrintSumDiscount,@BillPrintTitle,@BillPrintBranch,@BillPrintFooter1,@BillPrintFooter2,@BillPrintFooter3,@BillPrintFooter4,@BillPrintFooter5,@BillPrintFooter6,@BillPrintFooter7,@BillPrintFooter8)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@IsAutoFreshNoGroup", SqlDbType.Int,4),
					new SqlParameter("@IsAutoBarcode", SqlDbType.Int,4),
					new SqlParameter("@IsDefineItemNo", SqlDbType.Int,4),
					new SqlParameter("@IsAutoPriceCreate", SqlDbType.Int,4),
					new SqlParameter("@SmallChangeRound", SqlDbType.Int,4),
					new SqlParameter("@IsPrintItemShortName", SqlDbType.Int,4),
					new SqlParameter("@IsPrintSumDiscount", SqlDbType.Int,4),
					new SqlParameter("@BillPrintTitle", SqlDbType.NVarChar,50),
					new SqlParameter("@BillPrintBranch", SqlDbType.NVarChar,50),
					new SqlParameter("@BillPrintFooter1", SqlDbType.NVarChar,50),
					new SqlParameter("@BillPrintFooter2", SqlDbType.NVarChar,50),
					new SqlParameter("@BillPrintFooter3", SqlDbType.NVarChar,50),
					new SqlParameter("@BillPrintFooter4", SqlDbType.NVarChar,50),
					new SqlParameter("@BillPrintFooter5", SqlDbType.NVarChar,50),
					new SqlParameter("@BillPrintFooter6", SqlDbType.NVarChar,50),
					new SqlParameter("@BillPrintFooter7", SqlDbType.NVarChar,50),
					new SqlParameter("@BillPrintFooter8", SqlDbType.NVarChar,50)};
			parameters[0].Value = model.IsAutoFreshNoGroup;
			parameters[1].Value = model.IsAutoBarcode;
			parameters[2].Value = model.IsDefineItemNo;
			parameters[3].Value = model.IsAutoPriceCreate;
			parameters[4].Value = model.SmallChangeRound;
			parameters[5].Value = model.IsPrintItemShortName;
			parameters[6].Value = model.IsPrintSumDiscount;
			parameters[7].Value = model.BillPrintTitle;
			parameters[8].Value = model.BillPrintBranch;
			parameters[9].Value = model.BillPrintFooter1;
			parameters[10].Value = model.BillPrintFooter2;
			parameters[11].Value = model.BillPrintFooter3;
			parameters[12].Value = model.BillPrintFooter4;
			parameters[13].Value = model.BillPrintFooter5;
			parameters[14].Value = model.BillPrintFooter6;
			parameters[15].Value = model.BillPrintFooter7;
			parameters[16].Value = model.BillPrintFooter8;

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
		public bool Update(Maticsoft.Model.tb_PosSaleSetting model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update [" + DBName + @"].[dbo].tb_PosSaleSetting set ");
			strSql.Append("IsAutoFreshNoGroup=@IsAutoFreshNoGroup,");
			strSql.Append("IsAutoBarcode=@IsAutoBarcode,");
			strSql.Append("IsDefineItemNo=@IsDefineItemNo,");
			strSql.Append("IsAutoPriceCreate=@IsAutoPriceCreate,");
			strSql.Append("SmallChangeRound=@SmallChangeRound,");
			strSql.Append("IsPrintItemShortName=@IsPrintItemShortName,");
			strSql.Append("IsPrintSumDiscount=@IsPrintSumDiscount,");
			strSql.Append("BillPrintTitle=@BillPrintTitle,");
			strSql.Append("BillPrintBranch=@BillPrintBranch,");
			strSql.Append("BillPrintFooter1=@BillPrintFooter1,");
			strSql.Append("BillPrintFooter2=@BillPrintFooter2,");
			strSql.Append("BillPrintFooter3=@BillPrintFooter3,");
			strSql.Append("BillPrintFooter4=@BillPrintFooter4,");
			strSql.Append("BillPrintFooter5=@BillPrintFooter5,");
			strSql.Append("BillPrintFooter6=@BillPrintFooter6,");
			strSql.Append("BillPrintFooter7=@BillPrintFooter7,");
			strSql.Append("BillPrintFooter8=@BillPrintFooter8");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@IsAutoFreshNoGroup", SqlDbType.Int,4),
					new SqlParameter("@IsAutoBarcode", SqlDbType.Int,4),
					new SqlParameter("@IsDefineItemNo", SqlDbType.Int,4),
					new SqlParameter("@IsAutoPriceCreate", SqlDbType.Int,4),
					new SqlParameter("@SmallChangeRound", SqlDbType.Int,4),
					new SqlParameter("@IsPrintItemShortName", SqlDbType.Int,4),
					new SqlParameter("@IsPrintSumDiscount", SqlDbType.Int,4),
					new SqlParameter("@BillPrintTitle", SqlDbType.NVarChar,50),
					new SqlParameter("@BillPrintBranch", SqlDbType.NVarChar,50),
					new SqlParameter("@BillPrintFooter1", SqlDbType.NVarChar,50),
					new SqlParameter("@BillPrintFooter2", SqlDbType.NVarChar,50),
					new SqlParameter("@BillPrintFooter3", SqlDbType.NVarChar,50),
					new SqlParameter("@BillPrintFooter4", SqlDbType.NVarChar,50),
					new SqlParameter("@BillPrintFooter5", SqlDbType.NVarChar,50),
					new SqlParameter("@BillPrintFooter6", SqlDbType.NVarChar,50),
					new SqlParameter("@BillPrintFooter7", SqlDbType.NVarChar,50),
					new SqlParameter("@BillPrintFooter8", SqlDbType.NVarChar,50),
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = model.IsAutoFreshNoGroup;
			parameters[1].Value = model.IsAutoBarcode;
			parameters[2].Value = model.IsDefineItemNo;
			parameters[3].Value = model.IsAutoPriceCreate;
			parameters[4].Value = model.SmallChangeRound;
			parameters[5].Value = model.IsPrintItemShortName;
			parameters[6].Value = model.IsPrintSumDiscount;
			parameters[7].Value = model.BillPrintTitle;
			parameters[8].Value = model.BillPrintBranch;
			parameters[9].Value = model.BillPrintFooter1;
			parameters[10].Value = model.BillPrintFooter2;
			parameters[11].Value = model.BillPrintFooter3;
			parameters[12].Value = model.BillPrintFooter4;
			parameters[13].Value = model.BillPrintFooter5;
			parameters[14].Value = model.BillPrintFooter6;
			parameters[15].Value = model.BillPrintFooter7;
			parameters[16].Value = model.BillPrintFooter8;
			parameters[17].Value = model.id;

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
		public bool Delete(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from [" + DBName + @"].[dbo].tb_PosSaleSetting ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

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
		public bool DeleteList(string idlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from [" + DBName + @"].[dbo].tb_PosSaleSetting ");
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
		public Maticsoft.Model.tb_PosSaleSetting GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,IsAutoFreshNoGroup,IsAutoBarcode,IsDefineItemNo,IsAutoPriceCreate,SmallChangeRound,IsPrintItemShortName,IsPrintSumDiscount,BillPrintTitle,BillPrintBranch,BillPrintFooter1,BillPrintFooter2,BillPrintFooter3,BillPrintFooter4,BillPrintFooter5,BillPrintFooter6,BillPrintFooter7,BillPrintFooter8 from [" + DBName + @"].[dbo].tb_PosSaleSetting ");
            //strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			Maticsoft.Model.tb_PosSaleSetting model=new Maticsoft.Model.tb_PosSaleSetting();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
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
		public Maticsoft.Model.tb_PosSaleSetting DataRowToModel(DataRow row)
		{
			Maticsoft.Model.tb_PosSaleSetting model=new Maticsoft.Model.tb_PosSaleSetting();
			if (row != null)
			{
				if(row["id"]!=null && row["id"].ToString()!="")
				{
					model.id=int.Parse(row["id"].ToString());
				}
				if(row["IsAutoFreshNoGroup"]!=null && row["IsAutoFreshNoGroup"].ToString()!="")
				{
					model.IsAutoFreshNoGroup=int.Parse(row["IsAutoFreshNoGroup"].ToString());
				}
				if(row["IsAutoBarcode"]!=null && row["IsAutoBarcode"].ToString()!="")
				{
					model.IsAutoBarcode=int.Parse(row["IsAutoBarcode"].ToString());
				}
				if(row["IsDefineItemNo"]!=null && row["IsDefineItemNo"].ToString()!="")
				{
					model.IsDefineItemNo=int.Parse(row["IsDefineItemNo"].ToString());
				}
				if(row["IsAutoPriceCreate"]!=null && row["IsAutoPriceCreate"].ToString()!="")
				{
					model.IsAutoPriceCreate=int.Parse(row["IsAutoPriceCreate"].ToString());
				}
				if(row["SmallChangeRound"]!=null && row["SmallChangeRound"].ToString()!="")
				{
					model.SmallChangeRound=int.Parse(row["SmallChangeRound"].ToString());
				}
				if(row["IsPrintItemShortName"]!=null && row["IsPrintItemShortName"].ToString()!="")
				{
					model.IsPrintItemShortName=int.Parse(row["IsPrintItemShortName"].ToString());
				}
				if(row["IsPrintSumDiscount"]!=null && row["IsPrintSumDiscount"].ToString()!="")
				{
					model.IsPrintSumDiscount=int.Parse(row["IsPrintSumDiscount"].ToString());
				}
				if(row["BillPrintTitle"]!=null)
				{
					model.BillPrintTitle=row["BillPrintTitle"].ToString();
				}
				if(row["BillPrintBranch"]!=null)
				{
					model.BillPrintBranch=row["BillPrintBranch"].ToString();
				}
				if(row["BillPrintFooter1"]!=null)
				{
					model.BillPrintFooter1=row["BillPrintFooter1"].ToString();
				}
				if(row["BillPrintFooter2"]!=null)
				{
					model.BillPrintFooter2=row["BillPrintFooter2"].ToString();
				}
				if(row["BillPrintFooter3"]!=null)
				{
					model.BillPrintFooter3=row["BillPrintFooter3"].ToString();
				}
				if(row["BillPrintFooter4"]!=null)
				{
					model.BillPrintFooter4=row["BillPrintFooter4"].ToString();
				}
				if(row["BillPrintFooter5"]!=null)
				{
					model.BillPrintFooter5=row["BillPrintFooter5"].ToString();
				}
				if(row["BillPrintFooter6"]!=null)
				{
					model.BillPrintFooter6=row["BillPrintFooter6"].ToString();
				}
				if(row["BillPrintFooter7"]!=null)
				{
					model.BillPrintFooter7=row["BillPrintFooter7"].ToString();
				}
				if(row["BillPrintFooter8"]!=null)
				{
					model.BillPrintFooter8=row["BillPrintFooter8"].ToString();
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
			strSql.Append("select id,IsAutoFreshNoGroup,IsAutoBarcode,IsDefineItemNo,IsAutoPriceCreate,SmallChangeRound,IsPrintItemShortName,IsPrintSumDiscount,BillPrintTitle,BillPrintBranch,BillPrintFooter1,BillPrintFooter2,BillPrintFooter3,BillPrintFooter4,BillPrintFooter5,BillPrintFooter6,BillPrintFooter7,BillPrintFooter8 ");
			strSql.Append(" FROM [" + DBName + @"].[dbo].tb_PosSaleSetting ");
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
			strSql.Append(" id,IsAutoFreshNoGroup,IsAutoBarcode,IsDefineItemNo,IsAutoPriceCreate,SmallChangeRound,IsPrintItemShortName,IsPrintSumDiscount,BillPrintTitle,BillPrintBranch,BillPrintFooter1,BillPrintFooter2,BillPrintFooter3,BillPrintFooter4,BillPrintFooter5,BillPrintFooter6,BillPrintFooter7,BillPrintFooter8 ");
			strSql.Append(" FROM [" + DBName + @"].[dbo].tb_PosSaleSetting ");
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
			strSql.Append("select count(1) FROM [" + DBName + @"].[dbo].tb_PosSaleSetting ");
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
			strSql.Append(")AS Row, T.*  from [" + DBName + @"].[dbo].tb_PosSaleSetting T ");
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
			parameters[0].Value = "[" + DBName + @"].[dbo].tb_PosSaleSetting";
			parameters[1].Value = "id";
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

