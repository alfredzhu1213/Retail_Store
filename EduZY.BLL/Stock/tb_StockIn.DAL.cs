using System;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Data;
using Maticsoft.DBUtility;
namespace Maticsoft.DAL
{





    //tb_StockIn
    public partial class tb_StockInDAL
    {
        public string DBName = "";
        public tb_StockInDAL(string db)
        {
            DBName = db;

        }

        public bool Exists(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from [" + DBName + @"].[dbo].tb_StockIn");
            strSql.Append(" where ");
            strSql.Append(" id = @id  ");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
            parameters[0].Value = id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }



        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Maticsoft.Model.tb_StockIn model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into [" + DBName + @"].[dbo].tb_StockIn(");
            strSql.Append("SerialNum,StoreId,StoreCode,Remark,Status,CreateUserName,CreateDate,ApprUserName,ApprDate,HandledUserName");
            strSql.Append(") values (");
            strSql.Append("@SerialNum,@StoreId,@StoreCode,@Remark,@Status,@CreateUserName,@CreateDate,@ApprUserName,@ApprDate,@HandledUserName");
            strSql.Append(") ");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
			            new SqlParameter("@SerialNum", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@StoreId", SqlDbType.Int,4) ,            
                        new SqlParameter("@StoreCode", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@Remark", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@Status", SqlDbType.NVarChar,6) ,            
                        new SqlParameter("@CreateUserName", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@CreateDate", SqlDbType.DateTime) ,            
                        new SqlParameter("@ApprUserName", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@ApprDate", SqlDbType.DateTime) ,            
                        new SqlParameter("@HandledUserName", SqlDbType.VarChar,50)             
              
            };

            parameters[0].Value = model.SerialNum;
            parameters[1].Value = model.StoreId;
            parameters[2].Value = model.StoreCode;
            parameters[3].Value = model.Remark;
            parameters[4].Value = model.Status;
            parameters[5].Value = model.CreateUserName;
            parameters[6].Value = model.CreateDate;
            parameters[7].Value = model.ApprUserName;
            parameters[8].Value = model.ApprDate;
            parameters[9].Value = model.HandledUserName;

            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
            if (obj != null)
            {
                return Convert.ToInt32(obj);
            }
            else
            {

                return 0;

            }

        }


        /// <summary>
        /// 更新一条数据
        /// </summary>
        public int Update(Maticsoft.Model.tb_StockIn model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update [" + DBName + @"].[dbo].tb_StockIn set ");

            strSql.Append(" SerialNum = @SerialNum , ");
            strSql.Append(" StoreId = @StoreId , ");
            strSql.Append(" StoreCode = @StoreCode , ");
            strSql.Append(" Remark = @Remark , ");
            strSql.Append(" Status = @Status , ");
            strSql.Append(" CreateUserName = @CreateUserName , ");
            strSql.Append(" CreateDate = @CreateDate , ");
            strSql.Append(" ApprUserName = @ApprUserName , ");
            strSql.Append(" ApprDate = @ApprDate , ");
            strSql.Append(" HandledUserName = @HandledUserName  ");
            strSql.Append(" where id=@id ");

            SqlParameter[] parameters = {
			            new SqlParameter("@id", SqlDbType.Int,4) ,            
                        new SqlParameter("@SerialNum", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@StoreId", SqlDbType.Int,4) ,            
                        new SqlParameter("@StoreCode", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@Remark", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@Status", SqlDbType.NVarChar,6) ,            
                        new SqlParameter("@CreateUserName", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@CreateDate", SqlDbType.DateTime) ,            
                        new SqlParameter("@ApprUserName", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@ApprDate", SqlDbType.DateTime) ,            
                        new SqlParameter("@HandledUserName", SqlDbType.VarChar,50)             
              
            };

            parameters[0].Value = model.id;
            parameters[1].Value = model.SerialNum;
            parameters[2].Value = model.StoreId;
            parameters[3].Value = model.StoreCode;
            parameters[4].Value = model.Remark;
            parameters[5].Value = model.Status;
            parameters[6].Value = model.CreateUserName;
            parameters[7].Value = model.CreateDate;
            parameters[8].Value = model.ApprUserName;
            parameters[9].Value = model.ApprDate;
            parameters[10].Value = model.HandledUserName;
            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
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

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from [" + DBName + @"].[dbo].tb_StockIn ");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
            parameters[0].Value = id;


            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
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
        public bool DeleteList(string idlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from [" + DBName + @"].[dbo].tb_StockIn ");
            strSql.Append(" where id in (" + idlist + ")  ");
            int rows = DbHelperSQL.ExecuteSql(strSql.ToString());
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
        public Maticsoft.Model.tb_StockIn GetModel(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id, SerialNum, StoreId, StoreCode, Remark, Status, CreateUserName, CreateDate, ApprUserName, ApprDate, HandledUserName  ");
            strSql.Append("  from [" + DBName + @"].[dbo].tb_StockIn ");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
            parameters[0].Value = id;


            Maticsoft.Model.tb_StockIn model = new Maticsoft.Model.tb_StockIn();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);

            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["id"].ToString() != "")
                {
                    model.id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                }
                model.SerialNum = ds.Tables[0].Rows[0]["SerialNum"].ToString();
                if (ds.Tables[0].Rows[0]["StoreId"].ToString() != "")
                {
                    model.StoreId = int.Parse(ds.Tables[0].Rows[0]["StoreId"].ToString());
                }
                model.StoreCode = ds.Tables[0].Rows[0]["StoreCode"].ToString();
                model.Remark = ds.Tables[0].Rows[0]["Remark"].ToString();
                model.Status = ds.Tables[0].Rows[0]["Status"].ToString();
                model.CreateUserName = ds.Tables[0].Rows[0]["CreateUserName"].ToString();
                if (ds.Tables[0].Rows[0]["CreateDate"].ToString() != "")
                {
                    model.CreateDate = DateTime.Parse(ds.Tables[0].Rows[0]["CreateDate"].ToString());
                }
                model.ApprUserName = ds.Tables[0].Rows[0]["ApprUserName"].ToString();
                if (ds.Tables[0].Rows[0]["ApprDate"].ToString() != "")
                {
                    model.ApprDate = DateTime.Parse(ds.Tables[0].Rows[0]["ApprDate"].ToString());
                }
                model.HandledUserName = ds.Tables[0].Rows[0]["HandledUserName"].ToString();

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
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM [" + DBName + @"].[dbo].tb_StockIn ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" * ");
            strSql.Append(" FROM tb_StockIn ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }

        public DataSet GetPageList(int pageSize, int pageIndex, string strWhere, out int iRecordCount)
        {

            return DbHelperSQL.QueryPageList("[" + DBName + @"].[dbo].tb_StockIn", "id ", "*", pageSize, pageIndex, "id desc ", strWhere, out iRecordCount);
        }



    }
}

