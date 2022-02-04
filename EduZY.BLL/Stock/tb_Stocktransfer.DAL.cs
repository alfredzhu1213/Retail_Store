using System; 
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic; 
using System.Data;
using Maticsoft.DBUtility;
namespace Maticsoft.DAL{

    
        


	 	//tb_Stocktransfer
		public partial class tb_StocktransferDAL
	{
	     public string DBName = "";
         public tb_StocktransferDAL(string db)
		{
            DBName = db;     
        
        } 
   		     
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from [" + DBName + @"].[dbo].tb_Stocktransfer");
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
		public int Add(Maticsoft.Model.tb_Stocktransfer model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into [" + DBName + @"].[dbo].tb_Stocktransfer(");			
            strSql.Append("Status,CreateUserName,CreateDate,ApprUserName,ApprDate,ApprUserNameIn,ApprDateIn,HandledUserName,SerialNum,SupId,SupCode,InStoreId,InStoreCode,OutStoreId,OutStoreCode,Remark");
			strSql.Append(") values (");
            strSql.Append("@Status,@CreateUserName,@CreateDate,@ApprUserName,@ApprDate,@ApprUserNameIn,@ApprDateIn,@HandledUserName,@SerialNum,@SupId,@SupCode,@InStoreId,@InStoreCode,@OutStoreId,@OutStoreCode,@Remark");            
            strSql.Append(") ");            
            strSql.Append(";select @@IDENTITY");		
			SqlParameter[] parameters = {
			            new SqlParameter("@Status", SqlDbType.NVarChar,6) ,            
                        new SqlParameter("@CreateUserName", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@CreateDate", SqlDbType.DateTime) ,            
                        new SqlParameter("@ApprUserName", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@ApprDate", SqlDbType.DateTime) ,            
                        new SqlParameter("@ApprUserNameIn", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@ApprDateIn", SqlDbType.DateTime) ,            
                        new SqlParameter("@HandledUserName", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@SerialNum", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@SupId", SqlDbType.Int,4) ,            
                        new SqlParameter("@SupCode", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@InStoreId", SqlDbType.Int,4) ,            
                        new SqlParameter("@InStoreCode", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@OutStoreId", SqlDbType.Int,4) ,            
                        new SqlParameter("@OutStoreCode", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@Remark", SqlDbType.NVarChar,50)             
              
            };
			            
            parameters[0].Value = model.Status;                        
            parameters[1].Value = model.CreateUserName;                        
            parameters[2].Value = model.CreateDate;                        
            parameters[3].Value = model.ApprUserName;                        
            parameters[4].Value = model.ApprDate;                        
            parameters[5].Value = model.ApprUserNameIn;                        
            parameters[6].Value = model.ApprDateIn;                        
            parameters[7].Value = model.HandledUserName;                        
            parameters[8].Value = model.SerialNum;                        
            parameters[9].Value = model.SupId;                        
            parameters[10].Value = model.SupCode;                        
            parameters[11].Value = model.InStoreId;                        
            parameters[12].Value = model.InStoreCode;                        
            parameters[13].Value = model.OutStoreId;                        
            parameters[14].Value = model.OutStoreCode;                        
            parameters[15].Value = model.Remark;                        
			   
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
		public int  Update(Maticsoft.Model.tb_Stocktransfer model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update [" + DBName + @"].[dbo].tb_Stocktransfer set ");
			                                                
            strSql.Append(" Status = @Status , ");                                    
            strSql.Append(" CreateUserName = @CreateUserName , ");                                    
            strSql.Append(" CreateDate = @CreateDate , ");                                    
            strSql.Append(" ApprUserName = @ApprUserName , ");                                    
            strSql.Append(" ApprDate = @ApprDate , ");                                    
            strSql.Append(" ApprUserNameIn = @ApprUserNameIn , ");                                    
            strSql.Append(" ApprDateIn = @ApprDateIn , ");                                    
            strSql.Append(" HandledUserName = @HandledUserName , ");                                    
            strSql.Append(" SerialNum = @SerialNum , ");                                    
            strSql.Append(" SupId = @SupId , ");                                    
            strSql.Append(" SupCode = @SupCode , ");                                    
            strSql.Append(" InStoreId = @InStoreId , ");                                    
            strSql.Append(" InStoreCode = @InStoreCode , ");                                    
            strSql.Append(" OutStoreId = @OutStoreId , ");                                    
            strSql.Append(" OutStoreCode = @OutStoreCode , ");                                    
            strSql.Append(" Remark = @Remark  ");            			
			strSql.Append(" where id=@id ");
						
SqlParameter[] parameters = {
			            new SqlParameter("@id", SqlDbType.Int,4) ,            
                        new SqlParameter("@Status", SqlDbType.NVarChar,6) ,            
                        new SqlParameter("@CreateUserName", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@CreateDate", SqlDbType.DateTime) ,            
                        new SqlParameter("@ApprUserName", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@ApprDate", SqlDbType.DateTime) ,            
                        new SqlParameter("@ApprUserNameIn", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@ApprDateIn", SqlDbType.DateTime) ,            
                        new SqlParameter("@HandledUserName", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@SerialNum", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@SupId", SqlDbType.Int,4) ,            
                        new SqlParameter("@SupCode", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@InStoreId", SqlDbType.Int,4) ,            
                        new SqlParameter("@InStoreCode", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@OutStoreId", SqlDbType.Int,4) ,            
                        new SqlParameter("@OutStoreCode", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@Remark", SqlDbType.NVarChar,50)             
              
            };
						            
            parameters[0].Value = model.id;                        
            parameters[1].Value = model.Status;                        
            parameters[2].Value = model.CreateUserName;                        
            parameters[3].Value = model.CreateDate;                        
            parameters[4].Value = model.ApprUserName;                        
            parameters[5].Value = model.ApprDate;                        
            parameters[6].Value = model.ApprUserNameIn;                        
            parameters[7].Value = model.ApprDateIn;                        
            parameters[8].Value = model.HandledUserName;                        
            parameters[9].Value = model.SerialNum;                        
            parameters[10].Value = model.SupId;                        
            parameters[11].Value = model.SupCode;                        
            parameters[12].Value = model.InStoreId;                        
            parameters[13].Value = model.InStoreCode;                        
            parameters[14].Value = model.OutStoreId;                        
            parameters[15].Value = model.OutStoreCode;                        
            parameters[16].Value = model.Remark;                        
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
			strSql.Append("delete from [" + DBName + @"].[dbo].tb_Stocktransfer ");
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
			strSql.Append("delete from [" + DBName + @"].[dbo].tb_Stocktransfer ");
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
		public Maticsoft.Model.tb_Stocktransfer GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select id, Status, CreateUserName, CreateDate, ApprUserName, ApprDate, ApprUserNameIn, ApprDateIn, HandledUserName, SerialNum, SupId, SupCode, InStoreId, InStoreCode, OutStoreId, OutStoreCode, Remark  ");			
			strSql.Append("  from [" + DBName + @"].[dbo].tb_Stocktransfer ");
			strSql.Append(" where id=@id");
						SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			
			Maticsoft.Model.tb_Stocktransfer model=new Maticsoft.Model.tb_Stocktransfer();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			
			if(ds.Tables[0].Rows.Count>0)
			{
												if(ds.Tables[0].Rows[0]["id"].ToString()!="")
				{
					model.id=int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
				}
																																				model.Status= ds.Tables[0].Rows[0]["Status"].ToString();
																																model.CreateUserName= ds.Tables[0].Rows[0]["CreateUserName"].ToString();
																												if(ds.Tables[0].Rows[0]["CreateDate"].ToString()!="")
				{
					model.CreateDate=DateTime.Parse(ds.Tables[0].Rows[0]["CreateDate"].ToString());
				}
																																				model.ApprUserName= ds.Tables[0].Rows[0]["ApprUserName"].ToString();
																												if(ds.Tables[0].Rows[0]["ApprDate"].ToString()!="")
				{
					model.ApprDate=DateTime.Parse(ds.Tables[0].Rows[0]["ApprDate"].ToString());
				}
																																				model.ApprUserNameIn= ds.Tables[0].Rows[0]["ApprUserNameIn"].ToString();
																												if(ds.Tables[0].Rows[0]["ApprDateIn"].ToString()!="")
				{
					model.ApprDateIn=DateTime.Parse(ds.Tables[0].Rows[0]["ApprDateIn"].ToString());
				}
																																				model.HandledUserName= ds.Tables[0].Rows[0]["HandledUserName"].ToString();
																																model.SerialNum= ds.Tables[0].Rows[0]["SerialNum"].ToString();
																												if(ds.Tables[0].Rows[0]["SupId"].ToString()!="")
				{
					model.SupId=int.Parse(ds.Tables[0].Rows[0]["SupId"].ToString());
				}
																																				model.SupCode= ds.Tables[0].Rows[0]["SupCode"].ToString();
																												if(ds.Tables[0].Rows[0]["InStoreId"].ToString()!="")
				{
					model.InStoreId=int.Parse(ds.Tables[0].Rows[0]["InStoreId"].ToString());
				}
																																				model.InStoreCode= ds.Tables[0].Rows[0]["InStoreCode"].ToString();
																												if(ds.Tables[0].Rows[0]["OutStoreId"].ToString()!="")
				{
					model.OutStoreId=int.Parse(ds.Tables[0].Rows[0]["OutStoreId"].ToString());
				}
																																				model.OutStoreCode= ds.Tables[0].Rows[0]["OutStoreCode"].ToString();
																																model.Remark= ds.Tables[0].Rows[0]["Remark"].ToString();
																										
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
			strSql.Append(" FROM [" + DBName + @"].[dbo].tb_Stocktransfer ");
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
			strSql.Append(" FROM tb_Stocktransfer ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQL.Query(strSql.ToString());
		}
		
	    public DataSet GetPageList(int pageSize, int pageIndex, string strWhere, out int iRecordCount)
        {

            return DbHelperSQL.QueryPageList("[" + DBName + @"].[dbo].tb_Stocktransfer", "id ","*", pageSize, pageIndex, "id desc ", strWhere, out iRecordCount);
        }
		

   
	}
}

