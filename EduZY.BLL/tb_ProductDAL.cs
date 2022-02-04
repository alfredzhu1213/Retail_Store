using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace Maticsoft.DAL
{
	/// <summary>
	/// 数据访问类:tb_Product
	/// </summary>
    public partial class tb_ProductDAL
	{
		public string DBName = "";
        public tb_ProductDAL(string db)
		{
            DBName = db;     
        
        }
		#region  Method


        public string GetUintList(string selectValue)
        {
            StringBuilder html = new StringBuilder();
            DataSet ds = DbHelperSQL.Query("SELECT [id] ,[name] FROM [" + DBName + @"].[dbo].[tb_ProductUnit]  union select '1000','其他' as name   ");
            DataRow[] arr_row = ds.Tables[0].Select();
            for (int i = 0; i < arr_row.Length; i++)
            {

                if (selectValue == arr_row[i]["name"].ToString())
                {
                    html.Append("<option value=\"" + arr_row[i]["name"].ToString() + "\" selected >" + arr_row[i]["name"].ToString() + "</option>");
                }
                else {
                    html.Append("<option value=\"" + arr_row[i]["name"].ToString() + "\">" + arr_row[i]["name"].ToString() + "</option>");
                }
                
              
            }
           return html.ToString();
        }
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from [" + DBName + @"].[dbo].tb_Product");
			strSql.Append(" where id="+id+" ");
			return DbHelperSQL.Exists(strSql.ToString());
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Maticsoft.Model.tb_Product model)
		{
			StringBuilder strSql=new StringBuilder();
			StringBuilder strSql1=new StringBuilder();
			StringBuilder strSql2=new StringBuilder();
			if (model.ProductName != null)
			{
				strSql1.Append("ProductName,");
				strSql2.Append("'"+model.ProductName+"',");
			}
			if (model.ImgUrl != null)
			{
				strSql1.Append("ImgUrl,");
				strSql2.Append("'"+model.ImgUrl+"',");
			}
			if (model.HHNo != null)
			{
				strSql1.Append("HHNo,");
				strSql2.Append("'"+model.HHNo+"',");
			}
			if (model.GG != null)
			{
				strSql1.Append("GG,");
				strSql2.Append("'"+model.GG+"',");
			}
			if (model.other != null)
			{
				strSql1.Append("other,");
				strSql2.Append("'"+model.other+"',");
			}
			if (model.Unit != null)
			{
				strSql1.Append("Unit,");
				strSql2.Append("'"+model.Unit.Trim()+"',");
			}
			if (model.StockNum != null)
			{
				strSql1.Append("StockNum,");
                //strSql2.Append(""+model.StockNum+",");
                strSql2.Append("0,");
			}

			if (model.MemberPrice != null)
			{
				strSql1.Append("MemberPrice,");
				strSql2.Append(""+model.MemberPrice+",");
			}
			if (model.jinPrice != null)
			{
				strSql1.Append("jinPrice,");
				strSql2.Append(""+model.jinPrice+",");
			}
			if (model.SalesPrice != null)
			{
				strSql1.Append("SalesPrice,");
				strSql2.Append(""+model.SalesPrice+",");
			}
			if (model.MinPrice != null)
			{
				strSql1.Append("MinPrice,");
				strSql2.Append(""+model.MinPrice+",");
			}
			if (model.IsAllowChange != null)
			{
				strSql1.Append("IsAllowChange,");
				strSql2.Append(""+model.IsAllowChange+",");
			}
			if (model.ClassId != null)
			{
				strSql1.Append("ClassId,");
				strSql2.Append(""+model.ClassId+",");
			}
			if (model.ClassCode != null)
			{
				strSql1.Append("ClassCode,");
				strSql2.Append("'"+model.ClassCode+"',");
			}
			if (model.ProductSingeName != null)
			{
				strSql1.Append("ProductSingeName,");
				strSql2.Append("'"+model.ProductSingeName+"',");
			}
			if (model.ProductJJ != null)
			{
				strSql1.Append("ProductJJ,");
				strSql2.Append("'"+model.ProductJJ+"',");
			}
			if (model.BrandCode != null)
			{
				strSql1.Append("BrandCode,");
				strSql2.Append("'"+model.BrandCode+"',");
			}
			if (model.BrandId != null)
			{
				strSql1.Append("BrandId,");
				strSql2.Append(""+model.BrandId+",");
			}
			if (model.SupCode != null)
			{
				strSql1.Append("SupCode,");
				strSql2.Append("'"+model.SupCode+"',");
			}
			if (model.SupId != null)
			{
				strSql1.Append("SupId,");
				strSql2.Append(""+model.SupId+",");
			}
			if (model.JinGG != null)
			{
				strSql1.Append("JinGG,");
				strSql2.Append(""+model.JinGG+",");
			}
			if (model.ProductStatus != null)
			{
				strSql1.Append("ProductStatus,");
				strSql2.Append("'"+model.ProductStatus+"',");
			}
			if (model.ProductType != null)
			{
				strSql1.Append("ProductType,");
				strSql2.Append("'"+model.ProductType+"',");
			}
			if (model.JJWay != null)
			{
				strSql1.Append("JJWay,");
				strSql2.Append("'"+model.JJWay+"',");
			}
			if (model.TJWay != null)
			{
				strSql1.Append("TJWay,");
				strSql2.Append("'"+model.TJWay+"',");
			}
			if (model.TJPrice != null)
			{
				strSql1.Append("TJPrice,");
				strSql2.Append(""+model.TJPrice+",");
			}
			if (model.Remark != null)
			{
				strSql1.Append("Remark,");
				strSql2.Append("'"+model.Remark+"',");
			}
			strSql.Append("insert into [" + DBName + @"].[dbo].tb_Product(");
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
		public bool Update(Maticsoft.Model.tb_Product model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update [" + DBName + @"].[dbo].tb_Product set ");
			if (model.ProductName != null)
			{
				strSql.Append("ProductName='"+model.ProductName+"',");
			}
			if (model.ImgUrl != null)
			{
				strSql.Append("ImgUrl='"+model.ImgUrl+"',");
			}
			else
			{
				strSql.Append("ImgUrl= null ,");
			}
			if (model.HHNo != null)
			{
				strSql.Append("HHNo='"+model.HHNo+"',");
			}
			else
			{
				strSql.Append("HHNo= null ,");
			}
			if (model.GG != null)
			{
				strSql.Append("GG='"+model.GG+"',");
			}
			else
			{
				strSql.Append("GG= null ,");
			}
			if (model.other != null)
			{
				strSql.Append("other='"+model.other+"',");
			}
			else
			{
				strSql.Append("other= null ,");
			}
			if (model.Unit != null)
			{
                strSql.Append("Unit='" + model.Unit.Trim() + "',");
			}
			else
			{
				strSql.Append("Unit= null ,");
			}
            //if (model.StockNum != null)
            //{
            //    strSql.Append("StockNum="+model.StockNum+",");
            //}
            //else
            //{
            //    strSql.Append("StockNum= null ,");
            //}
			if (model.MemberPrice != null)
			{
				strSql.Append("MemberPrice="+model.MemberPrice+",");
			}
			else
			{
				strSql.Append("MemberPrice= null ,");
			}
			if (model.jinPrice != null)
			{
				strSql.Append("jinPrice="+model.jinPrice+",");
			}
			if (model.SalesPrice != null)
			{
				strSql.Append("SalesPrice="+model.SalesPrice+",");
			}
			if (model.MinPrice != null)
			{
				strSql.Append("MinPrice="+model.MinPrice+",");
			}
			if (model.IsAllowChange != null)
			{
				strSql.Append("IsAllowChange="+model.IsAllowChange+",");
			}
			else
			{
				strSql.Append("IsAllowChange= null ,");
			}
			if (model.ClassId != null)
			{
				strSql.Append("ClassId="+model.ClassId+",");
			}
			else
			{
				strSql.Append("ClassId= null ,");
			}
			if (model.ClassCode != null)
			{
				strSql.Append("ClassCode='"+model.ClassCode+"',");
			}
			else
			{
				strSql.Append("ClassCode= null ,");
			}
			if (model.ProductSingeName != null)
			{
				strSql.Append("ProductSingeName='"+model.ProductSingeName+"',");
			}
			else
			{
				strSql.Append("ProductSingeName= null ,");
			}
			if (model.ProductJJ != null)
			{
				strSql.Append("ProductJJ='"+model.ProductJJ+"',");
			}
			else
			{
				strSql.Append("ProductJJ= null ,");
			}
			if (model.BrandCode != null)
			{
				strSql.Append("BrandCode='"+model.BrandCode+"',");
			}
			else
			{
				strSql.Append("BrandCode= null ,");
			}
			if (model.BrandId != null)
			{
				strSql.Append("BrandId="+model.BrandId+",");
			}
			else
			{
				strSql.Append("BrandId= null ,");
			}
			if (model.SupCode != null)
			{
				strSql.Append("SupCode='"+model.SupCode+"',");
			}
			else
			{
				strSql.Append("SupCode= null ,");
			}
			if (model.SupId != null)
			{
				strSql.Append("SupId="+model.SupId+",");
			}
			else
			{
				strSql.Append("SupId= null ,");
			}
			if (model.JinGG != null)
			{
				strSql.Append("JinGG="+model.JinGG+",");
			}
			if (model.ProductStatus != null)
			{
				strSql.Append("ProductStatus='"+model.ProductStatus+"',");
			}
			else
			{
				strSql.Append("ProductStatus= null ,");
			}
			if (model.ProductType != null)
			{
				strSql.Append("ProductType='"+model.ProductType+"',");
			}
			else
			{
				strSql.Append("ProductType= null ,");
			}
			if (model.JJWay != null)
			{
				strSql.Append("JJWay='"+model.JJWay+"',");
			}
			else
			{
				strSql.Append("JJWay= null ,");
			}
			if (model.TJWay != null)
			{
				strSql.Append("TJWay='"+model.TJWay+"',");
			}
			else
			{
				strSql.Append("TJWay= null ,");
			}
			if (model.TJPrice != null)
			{
				strSql.Append("TJPrice="+model.TJPrice+",");
			}
			else
			{
				strSql.Append("TJPrice= null ,");
			}
			if (model.Remark != null)
			{
				strSql.Append("Remark='"+model.Remark+"',");
			}
			else
			{
				strSql.Append("Remark= null ,");
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
			strSql.Append("delete from [" + DBName + @"].[dbo].tb_Product ");
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
			strSql.Append("delete from [" + DBName + @"].[dbo].tb_Product ");
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
		public Maticsoft.Model.tb_Product GetModel(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  ");
			strSql.Append(" id,ProductName,ImgUrl,HHNo,GG,other,Unit,StockNum,MemberPrice,jinPrice,SalesPrice,MinPrice,IsAllowChange,ClassId,ClassCode,ProductSingeName,ProductJJ,BrandCode,BrandId,SupCode,SupId,JinGG,ProductStatus,ProductType,JJWay,TJWay,TJPrice,Remark ");
			strSql.Append(" from [" + DBName + @"].[dbo].tb_Product ");
			strSql.Append(" where id="+id+"" );
			Maticsoft.Model.tb_Product model=new Maticsoft.Model.tb_Product();
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
		public Maticsoft.Model.tb_Product DataRowToModel(DataRow row)
		{
			Maticsoft.Model.tb_Product model=new Maticsoft.Model.tb_Product();
			if (row != null)
			{
				if(row["id"]!=null && row["id"].ToString()!="")
				{
					model.id=int.Parse(row["id"].ToString());
				}
				if(row["ProductName"]!=null)
				{
					model.ProductName=row["ProductName"].ToString();
				}
				if(row["ImgUrl"]!=null)
				{
					model.ImgUrl=row["ImgUrl"].ToString();
				}
				if(row["HHNo"]!=null)
				{
					model.HHNo=row["HHNo"].ToString();
				}
				if(row["GG"]!=null)
				{
					model.GG=row["GG"].ToString();
				}
				if(row["other"]!=null)
				{
					model.other=row["other"].ToString();
				}
				if(row["Unit"]!=null)
				{
					model.Unit=row["Unit"].ToString();
				}
				if(row["StockNum"]!=null && row["StockNum"].ToString()!="")
				{
                    model.StockNum = decimal.Parse(row["StockNum"].ToString());
				}
				if(row["MemberPrice"]!=null && row["MemberPrice"].ToString()!="")
				{
					model.MemberPrice=decimal.Parse(row["MemberPrice"].ToString());
				}
				if(row["jinPrice"]!=null && row["jinPrice"].ToString()!="")
				{
					model.jinPrice=decimal.Parse(row["jinPrice"].ToString());
				}
				if(row["SalesPrice"]!=null && row["SalesPrice"].ToString()!="")
				{
					model.SalesPrice=decimal.Parse(row["SalesPrice"].ToString());
				}
				if(row["MinPrice"]!=null && row["MinPrice"].ToString()!="")
				{
					model.MinPrice=decimal.Parse(row["MinPrice"].ToString());
				}
				if(row["IsAllowChange"]!=null && row["IsAllowChange"].ToString()!="")
				{
					model.IsAllowChange=int.Parse(row["IsAllowChange"].ToString());
				}
				if(row["ClassId"]!=null && row["ClassId"].ToString()!="")
				{
					model.ClassId=int.Parse(row["ClassId"].ToString());
				}
				if(row["ClassCode"]!=null)
				{
					model.ClassCode=row["ClassCode"].ToString();
				}
				if(row["ProductSingeName"]!=null)
				{
					model.ProductSingeName=row["ProductSingeName"].ToString();
				}
				if(row["ProductJJ"]!=null)
				{
					model.ProductJJ=row["ProductJJ"].ToString();
				}
				if(row["BrandCode"]!=null)
				{
					model.BrandCode=row["BrandCode"].ToString();
				}
				if(row["BrandId"]!=null && row["BrandId"].ToString()!="")
				{
					model.BrandId=int.Parse(row["BrandId"].ToString());
				}
				if(row["SupCode"]!=null)
				{
					model.SupCode=row["SupCode"].ToString();
				}
				if(row["SupId"]!=null && row["SupId"].ToString()!="")
				{
					model.SupId=int.Parse(row["SupId"].ToString());
				}
				if(row["JinGG"]!=null && row["JinGG"].ToString()!="")
				{
					model.JinGG=decimal.Parse(row["JinGG"].ToString());
				}
				if(row["ProductStatus"]!=null)
				{
					model.ProductStatus=row["ProductStatus"].ToString();
				}
				if(row["ProductType"]!=null)
				{
					model.ProductType=row["ProductType"].ToString();
				}
				if(row["JJWay"]!=null)
				{
					model.JJWay=row["JJWay"].ToString();
				}
				if(row["TJWay"]!=null)
				{
					model.TJWay=row["TJWay"].ToString();
				}
				if(row["TJPrice"]!=null && row["TJPrice"].ToString()!="")
				{
					model.TJPrice=decimal.Parse(row["TJPrice"].ToString());
				}
				if(row["Remark"]!=null)
				{
					model.Remark=row["Remark"].ToString();
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
			strSql.Append("select id,ProductName,ImgUrl,HHNo,GG,other,Unit,StockNum,MemberPrice,jinPrice,SalesPrice,MinPrice,IsAllowChange,ClassId,ClassCode,ProductSingeName,ProductJJ,BrandCode,BrandId,SupCode,SupId,JinGG,ProductStatus,ProductType,JJWay,TJWay,TJPrice,Remark ");
			strSql.Append(" FROM [" + DBName + @"].[dbo].tb_Product ");
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
			strSql.Append(" id,ProductName,ImgUrl,HHNo,GG,other,Unit,StockNum,MemberPrice,jinPrice,SalesPrice,MinPrice,IsAllowChange,ClassId,ClassCode,ProductSingeName,ProductJJ,BrandCode,BrandId,SupCode,SupId,JinGG,ProductStatus,ProductType,JJWay,TJWay,TJPrice,Remark ");
			strSql.Append(" FROM [" + DBName + @"].[dbo].tb_Product ");
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
			strSql.Append("select count(1) FROM [" + DBName + @"].[dbo].tb_Product ");
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
			strSql.Append(")AS Row, T.*  from [" + DBName + @"].[dbo].tb_Product T ");
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

