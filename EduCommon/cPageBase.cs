using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Maticsoft.DBUtility;

namespace Common
{
    public class cPageBase
    {
        /// <summary>
        /// 非环境下读取数据通用分页存储过程
        /// </summary>
        /// <param name="TableName">表名</param>
        /// <param name="FieldKey">关键字</param>
        /// <param name="FieldShow">显示字段</param>
        /// <param name="iPageSize">分页记录数</param>
        /// <param name="iCurrentPage">当前页</param>
        /// <param name="sColumnOrder">排序字段</param>
        /// <param name="sWhere">查询条件</param>
        /// <param name="iRecordCount">总记录数</param>
        /// <returns></returns>
        public static DataSet PageList(string TableName, string FieldKey, string FieldShow, int iPageSize, int iCurrentPage, string sColumnOrder, string sWhere, out int iRecordCount)
        {
            DataSet objDs;

            SqlParameter[] parameters ={ 
				 new SqlParameter("@tbname",SqlDbType.NVarChar,1000),
				 new SqlParameter("@FieldKey",SqlDbType.NVarChar,200),
				 new SqlParameter("@PageCurrent",SqlDbType.Int),
				 new SqlParameter("@PageSize",SqlDbType.Int),
				 new SqlParameter("@FieldShow",SqlDbType.NVarChar,1000),
				 new SqlParameter("@FieldOrder",SqlDbType.NVarChar,1000),
				 new SqlParameter("@Where",SqlDbType.NVarChar,1000),
				 new SqlParameter("@RecordCount",SqlDbType.Int)};
            parameters[0].Value = TableName;
            parameters[1].Value = FieldKey;
            parameters[2].Value = iCurrentPage;
            parameters[3].Value = iPageSize;
            parameters[4].Value = FieldShow;
            parameters[5].Value = sColumnOrder;
            parameters[6].Value = sWhere;
            parameters[7].Direction = ParameterDirection.Output;

            objDs = DbHelperSQL.RunProcedure("UP_GetRecordByPage", parameters, TableName);
            if (objDs.Tables[0].Rows.Count < 1)
            {
                objDs = null;
                iRecordCount = 0;
                return objDs;
            }

            if (parameters[7].Value != DBNull.Value)
            {
                iRecordCount = Convert.ToInt32(parameters[7].Value);
            }
            else
            {
                iRecordCount = 0;
            }
            return objDs;
        }
    }
}
