using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace Maticsoft.DAL
{
    /// <summary>
    /// 数据访问类:tb_PurchaseOrderDetail
    /// </summary>
    public partial class tb_PurchaseOrderDetailDAL
    {
        public string DBName = "";
        public tb_PurchaseOrderDetailDAL(string db)
        {
            DBName = db;

        }
        #region  Method

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("id", "[" + DBName + @"].[dbo].tb_PurchaseOrderDetail");
        }


        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from [" + DBName + @"].[dbo].tb_PurchaseOrderDetail");
            strSql.Append(" where id=" + id + " ");
            return DbHelperSQL.Exists(strSql.ToString());
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(Maticsoft.Model.tb_PurchaseOrderDetail model)
        {
            StringBuilder strSql = new StringBuilder();
            StringBuilder strSql1 = new StringBuilder();
            StringBuilder strSql2 = new StringBuilder();
        
            if (model.POId != null)
            {
                strSql1.Append("POId,");
                strSql2.Append("" + model.POId + ",");
            }
            if (model.ProductName != null)
            {
                strSql1.Append("ProductName,");
                strSql2.Append("'" + model.ProductName + "',");
            }
            if (model.HHNo != null)
            {
                strSql1.Append("HHNo,");
                strSql2.Append("'" + model.HHNo + "',");
            }
            if (model.GG != null)
            {
                strSql1.Append("GG,");
                strSql2.Append("'" + model.GG + "',");
            }
            if (model.Unit != null)
            {
                strSql1.Append("Unit,");
                strSql2.Append("'" + model.Unit + "',");
            }
            if (model.BoxNum != null)
            {
                decimal? BoxNum = 0;
                try
                {
                    BoxNum = model.BoxNum;
                }
                catch
                {
                }

                strSql1.Append("BoxNum,");
                strSql2.Append("" + BoxNum + ",");
            }
            if (model.Num != null)
            {
                decimal? Num = 0;
                try
                {
                    Num = model.Num;
                }
                catch
                {
                }

                strSql1.Append("Num,");
                strSql2.Append("" + Num + ",");
            }
            if (model.SendNum != null)
            {

                decimal? SendNum = 0;
                try
                {
                    SendNum = model.SendNum;
                }
                catch
                {
                }
                strSql1.Append("SendNum,");
                strSql2.Append("" + SendNum + ",");
            }
            if (model.Price != null)
            {
                decimal? Price = 0;
                try
                {
                    Price = model.Price;
                }
                catch
                {
                }

                strSql1.Append("Price,");
                strSql2.Append("" + Price + ",");
            }

            
           strSql1.Append("SumPrice,");
           try
           {
               strSql2.Append("" + model.Price * model.Num + ",");
           }
           catch
           {
               strSql2.Append("0,");
           }

         
    
            if (model.Remark != null)
            {
                strSql1.Append("Remark,");
                strSql2.Append("'" + model.Remark + "',");
            }
            if (model.AddTime != null)
            {
                strSql1.Append("AddTime,");
                strSql2.Append("'" + model.AddTime + "',");
            }
            if (model.ProductId != null)
            {
                strSql1.Append("ProductId,");
                strSql2.Append("" + model.ProductId + ",");
            }
            strSql.Append("insert into [" + DBName + @"].[dbo].tb_PurchaseOrderDetail(");
            strSql.Append(strSql1.ToString().Remove(strSql1.Length - 1));
            strSql.Append(")");
            strSql.Append(" values (");
            strSql.Append(strSql2.ToString().Remove(strSql2.Length - 1));
            strSql.Append(")");
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
        /// 更新一条数据
        /// </summary>
        public bool Update(Maticsoft.Model.tb_PurchaseOrderDetail model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update [" + DBName + @"].[dbo].tb_PurchaseOrderDetail set ");
            if (model.POId != null)
            {
                strSql.Append("POId=" + model.POId + ",");
            }
            else
            {
                strSql.Append("POId= null ,");
            }
            if (model.ProductName != null)
            {
                strSql.Append("ProductName='" + model.ProductName + "',");
            }
            if (model.HHNo != null)
            {
                strSql.Append("HHNo='" + model.HHNo + "',");
            }
            else
            {
                strSql.Append("HHNo= null ,");
            }
            if (model.GG != null)
            {
                strSql.Append("GG='" + model.GG + "',");
            }
            else
            {
                strSql.Append("GG= null ,");
            }
            if (model.Unit != null)
            {
                strSql.Append("Unit='" + model.Unit + "',");
            }
            else
            {
                strSql.Append("Unit= null ,");
            }
            if (model.BoxNum != null)
            {
                strSql.Append("BoxNum=" + model.BoxNum + ",");
            }
            if (model.Num != null)
            {
                strSql.Append("Num=" + model.Num + ",");
            }
            if (model.SendNum != null)
            {
                strSql.Append("SendNum=" + model.SendNum + ",");
            }
            else
            {
                strSql.Append("SendNum= null ,");
            }
            if (model.Price != null)
            {
                strSql.Append("Price=" + model.Price + ",");
            }
            else
            {
                strSql.Append("Price= null ,");
            }
            if (model.Remark != null)
            {
                strSql.Append("Remark='" + model.Remark + "',");
            }
            else
            {
                strSql.Append("Remark= null ,");
            }
            if (model.AddTime != null)
            {
                strSql.Append("AddTime='" + model.AddTime + "',");
            }
            else
            {
                strSql.Append("AddTime= null ,");
            }
            if (model.ProductId != null)
            {
                strSql.Append("ProductId=" + model.ProductId + ",");
            }
            else
            {
                strSql.Append("ProductId= null ,");
            }
            int n = strSql.ToString().LastIndexOf(",");
            strSql.Remove(n, 1);
            strSql.Append(" where id=" + model.id + " ");
            int rowsAffected = DbHelperSQL.ExecuteSql(strSql.ToString());
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
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from [" + DBName + @"].[dbo].tb_PurchaseOrderDetail ");
            strSql.Append(" where id=" + id + " ");
            int rowsAffected = DbHelperSQL.ExecuteSql(strSql.ToString());
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
        public bool DeleteList(string idlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from [" + DBName + @"].[dbo].tb_PurchaseOrderDetail ");
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
        public Maticsoft.Model.tb_PurchaseOrderDetail GetModel(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1  ");
            strSql.Append(" id,POId,ProductName,HHNo,GG,Unit,BoxNum,Num,SendNum,Price,Remark,AddTime,ProductId,SumPrice ");
            strSql.Append(" from [" + DBName + @"].[dbo].tb_PurchaseOrderDetail ");
            strSql.Append(" where id=" + id + " ");
            Maticsoft.Model.tb_PurchaseOrderDetail model = new Maticsoft.Model.tb_PurchaseOrderDetail();
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

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Maticsoft.Model.tb_PurchaseOrderDetail DataRowToModel(DataRow row)
        {
            Maticsoft.Model.tb_PurchaseOrderDetail model = new Maticsoft.Model.tb_PurchaseOrderDetail();
            if (row != null)
            {
                if (row["id"] != null && row["id"].ToString() != "")
                {
                    model.id = int.Parse(row["id"].ToString());
                }
                if (row["POId"] != null && row["POId"].ToString() != "")
                {
                    model.POId = int.Parse(row["POId"].ToString());
                }
                if (row["ProductName"] != null)
                {
                    model.ProductName = row["ProductName"].ToString();
                }
                if (row["HHNo"] != null)
                {
                    model.HHNo = row["HHNo"].ToString();
                }
                if (row["GG"] != null)
                {
                    model.GG = row["GG"].ToString();
                }
                if (row["Unit"] != null)
                {
                    model.Unit = row["Unit"].ToString();
                }
                if (row["BoxNum"] != null && row["BoxNum"].ToString() != "")
                {
                    model.BoxNum = decimal.Parse(row["BoxNum"].ToString());
                }
                if (row["Num"] != null && row["Num"].ToString() != "")
                {
                    model.Num = decimal.Parse(row["Num"].ToString());
                }
                if (row["SendNum"] != null && row["SendNum"].ToString() != "")
                {
                    model.SendNum = decimal.Parse(row["SendNum"].ToString());
                }
                if (row["Price"] != null && row["Price"].ToString() != "")
                {
                    model.Price = decimal.Parse(row["Price"].ToString());
                }
                if (row["SumPrice"] != null && row["SumPrice"].ToString() != "")
                {
                    model.SumPrice = decimal.Parse(row["SumPrice"].ToString());
                }
                
                if (row["Remark"] != null)
                {
                    model.Remark = row["Remark"].ToString();
                }
                if (row["AddTime"] != null && row["AddTime"].ToString() != "")
                {
                    model.AddTime = DateTime.Parse(row["AddTime"].ToString());
                }
                if (row["ProductId"] != null && row["ProductId"].ToString() != "")
                {
                    model.ProductId = int.Parse(row["ProductId"].ToString());
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,POId,ProductName,HHNo,GG,Unit,BoxNum,Num,SendNum,Price,Remark,AddTime,ProductId ");
            strSql.Append(" FROM [" + DBName + @"].[dbo].tb_PurchaseOrderDetail ");
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
            strSql.Append(" id,POId,ProductName,HHNo,GG,Unit,BoxNum,Num,SendNum,Price,Remark,AddTime,ProductId ");
            strSql.Append(" FROM [" + DBName + @"].[dbo].tb_PurchaseOrderDetail ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM [" + DBName + @"].[dbo].tb_PurchaseOrderDetail ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
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
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby);
            }
            else
            {
                strSql.Append("order by T.id desc");
            }
            strSql.Append(")AS Row, T.*  from [" + DBName + @"].[dbo].tb_PurchaseOrderDetail T ");
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

