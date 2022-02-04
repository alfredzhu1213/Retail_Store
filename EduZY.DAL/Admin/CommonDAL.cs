using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;
using System.Data;

namespace EduZY.DAL.index
{
    public class CommonDAL
    {
        #region  Method



        /// <summary>
        /// 头部分类
        /// </summary>
        public DataSet GetList_BasicInfoClass(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" InfoClassID,InfoClassName");
            strSql.Append(" FROM  EduZY.dbo.BasicInfoClass ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        ///友情链接
        /// </summary>
        public DataSet GetListIndexLink(int top, string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top " + top + " LinkName,LinkUrl");
            strSql.Append(" FROM EduZY.dbo.BasicFriendLink ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere + " Order by OrderBy DESC,UpdateTime DESC");
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        //获取中间首页图片
        public DataSet GetListIndextemPic(int top, int type)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"SELECT top  " + top + @"  [STPID] ,(select Height  from dbo.BasicSysTemPicClass
                            where STPCID=[QFW].[dbo].[BasicSysTemPic].[STPCID]) Height,
                            (select Width  from dbo.BasicSysTemPicClass
                            where STPCID=[QFW].[dbo].[BasicSysTemPic].[STPCID]) Width,[PicName] ,
                            [PicUrl] ,[picLinkUrl]  FROM [QFW].[dbo].[BasicSysTemPic] ");

            strSql.Append(@" WHERE IsShow=1  AND [STPCID]='" + type + "' Order by OrderNo  ,UpdateTime DESC");

            return DbHelperSQL.Query(strSql.ToString());

        }
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList_PictureBooksMaster(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" PBMID,PictureBooksName,PictureBooksUrl");
            strSql.Append(" FROM EduZY.dbo.PictureBooksMaster ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }



        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList_PictureBooksMasterHotReadNum(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" PBMID,PictureBooksName, PictureBooksUrl,isnull((SELECT  [ReadNum] FROM [QFW].[dbo].[PictureBooksAttribute] where [PBMID]=EduZY.dbo.PictureBooksMaster.PBMID),0 ) as ReadNum");
            strSql.Append(" FROM EduZY.dbo.PictureBooksMaster ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public EduZY.Model.BasicInfoClass GetModel_InfoClassName(int InfoClassID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 InfoClassID,InfoClassName from BasicInfoClass");
            strSql.Append(" where InfoClassID=@InfoClassID");
            SqlParameter[] parameters = {
					new SqlParameter("@InfoClassID", SqlDbType.Int,4)
};
            parameters[0].Value = InfoClassID;

            EduZY.Model.BasicInfoClass model = new EduZY.Model.BasicInfoClass();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["InfoClassID"].ToString() != "")
                {
                    model.InfoClassID = int.Parse(ds.Tables[0].Rows[0]["InfoClassID"].ToString());
                }
                model.InfoClassName = ds.Tables[0].Rows[0]["InfoClassName"].ToString();
              
  
                return model;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList_BasicInfoClass(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select InfoClassID,InfoClassName");
            strSql.Append(" FROM [QFW].[dbo].[BasicInfoClass] ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }


        /// <summary>
        /// 获取当前页数据及总记录数
        /// </summary>
        /// <<param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <param name="iRecordCount"></param>
        /// <returns></returns>
        public DataSet GetPageList(int pageSize, int pageIndex, out int iRecordCount)
        {
            return DbHelperSQL.QueryPageList("BasicInfoClass", "InfoClassID", " InfoClassID,InfoClassName,ParentInfoClassID,KeyWord,Label,Describe,StaticAddress,IsHead,IsShow,UserID,AddTime,UpdateTime,NO,CssColor ", pageSize, pageIndex, "", "", out iRecordCount);
        }

        /// <summary>
        /// 获取当前页数据及总记录数
        /// </summary>
        /// <<param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <param name="iRecordCount"></param>
        /// <returns></returns>
        public DataSet GetPageList_PictureBooksMaster(int pageSize, int pageIndex,string strWhere, out int iRecordCount)
        {
            return DbHelperSQL.QueryPageList("PictureBooksMaster", "PBMID", " PBMID,PictureBooksName,PictureBooksUrl ", pageSize, pageIndex, " UpdateTime desc ", strWhere, out iRecordCount);
        }
        #endregion  Method
    }
}
