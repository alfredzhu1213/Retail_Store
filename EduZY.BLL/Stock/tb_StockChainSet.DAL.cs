using System; 
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic; 
using System.Data;
using Maticsoft.DBUtility;
namespace Maticsoft.DAL{

    
        


	 	//tb_StockChainSet
		public partial class tb_StockChainSetDAL
	{
	     public string DBName = "";
         public tb_StockChainSetDAL(string db)
		{
            DBName = db;     
        
        } 
   		     
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from [" + DBName + @"].[dbo].tb_StockChainSet");
			strSql.Append(" where ");
			                                       strSql.Append(" id = @id  ");
                            			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)			};
			parameters[0].Value = id;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}
		
				
		
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(Maticsoft.Model.tb_StockChainSet model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into [" + DBName + @"].[dbo].tb_StockChainSet(");			
            strSql.Append("IsEnable");
			strSql.Append(") values (");
            strSql.Append("@IsEnable");            
            strSql.Append(") ");            
            		
			SqlParameter[] parameters = {
			            new SqlParameter("@id", SqlDbType.Int,4) ,            
                        new SqlParameter("@IsEnable", SqlDbType.TinyInt,1)             
              
            };
			            
            parameters[0].Value = model.id;                        
            parameters[1].Value = model.IsEnable;                        
			            DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
            			
		}
		
		
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public int  Update(Maticsoft.Model.tb_StockChainSet model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update [" + DBName + @"].[dbo].tb_StockChainSet set ");
			                                                          
            strSql.Append(" IsEnable = @IsEnable  ");            			
			strSql.Append(" where id=@id  ");
						
SqlParameter[] parameters = {
			            new SqlParameter("@id", SqlDbType.Int,4) ,            
                        new SqlParameter("@IsEnable", SqlDbType.TinyInt,1)             
              
            };
						            
            parameters[0].Value = model.id;                        
            parameters[1].Value = model.IsEnable;                        
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
			strSql.Append("delete from [" + DBName + @"].[dbo].tb_StockChainSet ");
			strSql.Append(" where id=@id ");
						SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)			};
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
		/// 得到一个对象实体
		/// </summary>
		public Maticsoft.Model.tb_StockChainSet GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select top 1 id, IsEnable  ");			
			strSql.Append("  from [" + DBName + @"].[dbo].tb_StockChainSet ");
	
						SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)			};
			parameters[0].Value = id;

			
			Maticsoft.Model.tb_StockChainSet model=new Maticsoft.Model.tb_StockChainSet();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			
			if(ds.Tables[0].Rows.Count>0)
			{
												if(ds.Tables[0].Rows[0]["id"].ToString()!="")
				{
					model.id=int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["IsEnable"].ToString()!="")
				{
					model.IsEnable=int.Parse(ds.Tables[0].Rows[0]["IsEnable"].ToString());
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
			strSql.Append(" FROM [" + DBName + @"].[dbo].tb_StockChainSet ");
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
			strSql.Append(" FROM tb_StockChainSet ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQL.Query(strSql.ToString());
		}
		
	    public DataSet GetPageList(int pageSize, int pageIndex, string strWhere, out int iRecordCount)
        {

            return DbHelperSQL.QueryPageList("[" + DBName + @"].[dbo].tb_StockChainSet", "id ","*", pageSize, pageIndex, "id desc ", strWhere, out iRecordCount);
        }
		

   
	}
}

