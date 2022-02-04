using System; 
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic; 
using System.Data;
using Maticsoft.DBUtility;
namespace Maticsoft.DAL{

    
        


	 	//tb_StockInDetail
		public partial class tb_StockInDetailDAL
	{
	     public string DBName = "";
         public tb_StockInDetailDAL(string db)
		{
            DBName = db;     
        
        } 
   		     
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from [" + DBName + @"].[dbo].tb_StockInDetail");
			strSql.Append(" where ");
			                                       strSql.Append(" id = @id  ");
                            			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}
		
				
		
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Maticsoft.Model.tb_StockInDetail model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into [" + DBName + @"].[dbo].tb_StockInDetail(");			
            strSql.Append("Remark,AddTime,ProductId,StockInId,ProductName,HHNo,GG,Unit,BoxNum,Num,Price");
			strSql.Append(") values (");
            strSql.Append("@Remark,@AddTime,@ProductId,@StockInId,@ProductName,@HHNo,@GG,@Unit,@BoxNum,@Num,@Price");            
            strSql.Append(") ");            
            strSql.Append(";select @@IDENTITY");		
			SqlParameter[] parameters = {
			            new SqlParameter("@Remark", SqlDbType.NVarChar,4000) ,            
                        new SqlParameter("@AddTime", SqlDbType.DateTime) ,            
                        new SqlParameter("@ProductId", SqlDbType.Int,4) ,            
                        new SqlParameter("@StockInId", SqlDbType.Int,4) ,            
                        new SqlParameter("@ProductName", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@HHNo", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@GG", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@Unit", SqlDbType.Char,10) ,            
                        new SqlParameter("@BoxNum", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@Num", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@Price", SqlDbType.Decimal,9)             
              
            };
			            
            parameters[0].Value = model.Remark;                        
            parameters[1].Value = model.AddTime;                        
            parameters[2].Value = model.ProductId;                        
            parameters[3].Value = model.StockInId;                        
            parameters[4].Value = model.ProductName;                        
            parameters[5].Value = model.HHNo;                        
            parameters[6].Value = model.GG;                        
            parameters[7].Value = model.Unit;                        
            parameters[8].Value = model.BoxNum;                        
            parameters[9].Value = model.Num;                        
            parameters[10].Value = model.Price;                        
			   
			object obj = DbHelperSQL.GetSingle(strSql.ToString(),parameters);			
			if (obj == null)
			{
				return 0;
			}
			else
			{
				                    
            	return 1;
                                                                  
			}			   
            			
		}
		
		
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public int  Update(Maticsoft.Model.tb_StockInDetail model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update [" + DBName + @"].[dbo].tb_StockInDetail set ");
			                                                
            strSql.Append(" Remark = @Remark , ");                                    
            strSql.Append(" AddTime = @AddTime , ");                                    
            strSql.Append(" ProductId = @ProductId , ");                                    
            strSql.Append(" StockInId = @StockInId , ");                                    
            strSql.Append(" ProductName = @ProductName , ");                                    
            strSql.Append(" HHNo = @HHNo , ");                                    
            strSql.Append(" GG = @GG , ");                                    
            strSql.Append(" Unit = @Unit , ");                                    
            strSql.Append(" BoxNum = @BoxNum , ");                                    
            strSql.Append(" Num = @Num , ");                                    
            strSql.Append(" Price = @Price  ");            			
			strSql.Append(" where id=@id ");
						
SqlParameter[] parameters = {
			            new SqlParameter("@id", SqlDbType.Int,4) ,            
                        new SqlParameter("@Remark", SqlDbType.NVarChar,4000) ,            
                        new SqlParameter("@AddTime", SqlDbType.DateTime) ,            
                        new SqlParameter("@ProductId", SqlDbType.Int,4) ,            
                        new SqlParameter("@StockInId", SqlDbType.Int,4) ,            
                        new SqlParameter("@ProductName", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@HHNo", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@GG", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@Unit", SqlDbType.Char,10) ,            
                        new SqlParameter("@BoxNum", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@Num", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@Price", SqlDbType.Decimal,9)             
              
            };
						            
            parameters[0].Value = model.id;                        
            parameters[1].Value = model.Remark;                        
            parameters[2].Value = model.AddTime;                        
            parameters[3].Value = model.ProductId;                        
            parameters[4].Value = model.StockInId;                        
            parameters[5].Value = model.ProductName;                        
            parameters[6].Value = model.HHNo;                        
            parameters[7].Value = model.GG;                        
            parameters[8].Value = model.Unit;                        
            parameters[9].Value = model.BoxNum;                        
            parameters[10].Value = model.Num;                        
            parameters[11].Value = model.Price;                        
            int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return 1;
			}
			else
			{
				return 0;
			}
		}
		
		
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from [" + DBName + @"].[dbo].tb_StockInDetail ");
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
		/// 批量删除一批数据
		/// </summary>
		public bool DeleteList(string idlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from [" + DBName + @"].[dbo].tb_StockInDetail ");
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
		public Maticsoft.Model.tb_StockInDetail GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select id, Remark, AddTime, ProductId, StockInId, ProductName, HHNo, GG, Unit, BoxNum, Num, Price  ");			
			strSql.Append("  from [" + DBName + @"].[dbo].tb_StockInDetail ");
			strSql.Append(" where id=@id");
						SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			
			Maticsoft.Model.tb_StockInDetail model=new Maticsoft.Model.tb_StockInDetail();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			
			if(ds.Tables[0].Rows.Count>0)
			{
												if(ds.Tables[0].Rows[0]["id"].ToString()!="")
				{
					model.id=int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
				}
																																				model.Remark= ds.Tables[0].Rows[0]["Remark"].ToString();
																												if(ds.Tables[0].Rows[0]["AddTime"].ToString()!="")
				{
					model.AddTime=DateTime.Parse(ds.Tables[0].Rows[0]["AddTime"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["ProductId"].ToString()!="")
				{
					model.ProductId=int.Parse(ds.Tables[0].Rows[0]["ProductId"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["StockInId"].ToString()!="")
				{
					model.StockInId=int.Parse(ds.Tables[0].Rows[0]["StockInId"].ToString());
				}
																																				model.ProductName= ds.Tables[0].Rows[0]["ProductName"].ToString();
																																model.HHNo= ds.Tables[0].Rows[0]["HHNo"].ToString();
																																model.GG= ds.Tables[0].Rows[0]["GG"].ToString();
																																model.Unit= ds.Tables[0].Rows[0]["Unit"].ToString();
																												if(ds.Tables[0].Rows[0]["BoxNum"].ToString()!="")
				{
					model.BoxNum=decimal.Parse(ds.Tables[0].Rows[0]["BoxNum"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["Num"].ToString()!="")
				{
					model.Num=decimal.Parse(ds.Tables[0].Rows[0]["Num"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["Price"].ToString()!="")
				{
					model.Price=decimal.Parse(ds.Tables[0].Rows[0]["Price"].ToString());
				}
																														
				return model;
			}
			else
			{
				return model;
			}
		}
		
		
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select * ");
			strSql.Append(" FROM [" + DBName + @"].[dbo].tb_StockInDetail ");
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
			strSql.Append(" * ");
			strSql.Append(" FROM tb_StockInDetail ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQL.Query(strSql.ToString());
		}
		
	    public DataSet GetPageList(int pageSize, int pageIndex, string strWhere, out int iRecordCount)
        {

            return DbHelperSQL.QueryPageList("[" + DBName + @"].[dbo].tb_StockInDetail", "id ","*", pageSize, pageIndex, "id desc ", strWhere, out iRecordCount);
        }
		

   
	}
}

