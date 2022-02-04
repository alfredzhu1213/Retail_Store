using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;
using Maticsoft.DBUtility;//Please add references
namespace EduZY.DAL.Index
{
	/// <summary>
	/// 数据访问类:QFWUserMaster
	/// </summary>
	public class UserMasterDAL
	{
		public UserMasterDAL()
		{}
		#region  Method

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(EduZY.Model.UserMaster model)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.Int,4),
					new SqlParameter("@UserName", SqlDbType.VarChar,50),
					new SqlParameter("@Password", SqlDbType.VarChar,32),
					new SqlParameter("@Status", SqlDbType.VarChar,1),
					new SqlParameter("@RoleID", SqlDbType.Char,1),
					new SqlParameter("@TrueName", SqlDbType.NVarChar,20),
					new SqlParameter("@WorkUnit", SqlDbType.NVarChar,200),
					new SqlParameter("@BirthDay", SqlDbType.SmallDateTime),
					new SqlParameter("@Mobile", SqlDbType.VarChar,12),
					new SqlParameter("@Phone", SqlDbType.VarChar,20),
					new SqlParameter("@EMail", SqlDbType.VarChar,100),
					new SqlParameter("@QQ", SqlDbType.VarChar,15),
					new SqlParameter("@Address", SqlDbType.NVarChar,200),
					new SqlParameter("@PicAddresss", SqlDbType.NVarChar,200)};
            parameters[0].Direction = ParameterDirection.Output;
            parameters[1].Value = model.UserName;
            parameters[2].Value = model.Password;
            parameters[3].Value = model.Status;
            parameters[4].Value = model.RoleID;
            parameters[5].Value = model.TrueName;
            parameters[6].Value = model.WorkUnit;
            parameters[7].Value = model.BirthDay;
            parameters[8].Value = model.Mobile;
            parameters[9].Value = model.Phone;
            parameters[10].Value = model.EMail;
            parameters[11].Value = model.QQ;
            parameters[12].Value = model.Address;
            parameters[13].Value = model.PicAddresss;

            DbHelperSQL.RunProcedure("UP_UserMaster_ADD", parameters, out rowsAffected);
            return (int)parameters[0].Value;
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(EduZY.Model.UserMaster model)
        {
            int rowsAffected = 0;
            SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.Int,4),
					new SqlParameter("@UserName", SqlDbType.VarChar,50),
					new SqlParameter("@Password", SqlDbType.VarChar,32),
					new SqlParameter("@Status", SqlDbType.VarChar,1),
					new SqlParameter("@RoleID", SqlDbType.Char,1),
					new SqlParameter("@TrueName", SqlDbType.NVarChar,20),
					new SqlParameter("@WorkUnit", SqlDbType.NVarChar,200),
					new SqlParameter("@BirthDay", SqlDbType.SmallDateTime),
					new SqlParameter("@Mobile", SqlDbType.VarChar,12),
					new SqlParameter("@Phone", SqlDbType.VarChar,20),
					new SqlParameter("@EMail", SqlDbType.VarChar,100),
					new SqlParameter("@QQ", SqlDbType.VarChar,15),
					new SqlParameter("@Address", SqlDbType.NVarChar,200),
					new SqlParameter("@PicAddresss", SqlDbType.NVarChar,200)};
            parameters[0].Value = model.UserID;
            parameters[1].Value = model.UserName;
            parameters[2].Value = model.Password;
            parameters[3].Value = model.Status;
            parameters[4].Value = model.RoleID;
            parameters[5].Value = model.TrueName;
            parameters[6].Value = model.WorkUnit;
            parameters[7].Value = model.BirthDay;
            parameters[8].Value = model.Mobile;
            parameters[9].Value = model.Phone;
            parameters[10].Value = model.EMail;
            parameters[11].Value = model.QQ;
            parameters[12].Value = model.Address;
            parameters[13].Value = model.PicAddresss;

            DbHelperSQL.RunProcedure("UP_UserMaster_Update", parameters, out rowsAffected);
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
        /// 禁用用户
        /// </summary>
        /// <param name="UserIDList"></param>
        /// <returns></returns>
        public bool Disable(string UserIDList)
        {
            string strSql = "update UserMaster set Status='2' where UserID in (" + UserIDList + ")";
            int rows = DbHelperSQL.ExecuteSql(strSql);
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
		public EduZY.Model.UserMaster GetModel(int UserID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 UserID,UserName,Password,Status,RoleID,RegStateDate,Sign,LastDate,DateUpdated,GenearchUserID,Uid,UserSource from UserMaster ");
			strSql.Append(" where UserID=@UserID");
			SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.Int,4)
};
            parameters[0].Value = UserID;

            return GetModel(strSql.ToString(), parameters);
		}

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public EduZY.Model.UserMaster GetModel(string UserName)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 UserID,UserName,Password,Status,RoleID,RegStateDate,Sign,LastDate,DateUpdated,GenearchUserID,Uid,UserSource from UserMaster ");
            strSql.Append(" where UserName=@UserName");
            SqlParameter[] parameters = {
					new SqlParameter("@UserName", SqlDbType.VarChar,50)
};
            parameters[0].Value = UserName;

            return GetModel(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        private EduZY.Model.UserMaster GetModel(string strSql, SqlParameter[] parameters)
        {
            EduZY.Model.UserMaster model = new EduZY.Model.UserMaster();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["UserID"].ToString() != "")
                {
                    model.UserID = int.Parse(ds.Tables[0].Rows[0]["UserID"].ToString());
                }
                model.UserName = ds.Tables[0].Rows[0]["UserName"].ToString();
                model.Password = ds.Tables[0].Rows[0]["Password"].ToString();
                model.Status = ds.Tables[0].Rows[0]["Status"].ToString();
                model.RoleID = ds.Tables[0].Rows[0]["RoleID"].ToString();
                if (ds.Tables[0].Rows[0]["RegStateDate"].ToString() != "")
                {
                    model.RegStateDate = DateTime.Parse(ds.Tables[0].Rows[0]["RegStateDate"].ToString());
                }
                model.Sign = ds.Tables[0].Rows[0]["Sign"].ToString();
                if (ds.Tables[0].Rows[0]["LastDate"].ToString() != "")
                {
                    model.LastDate = DateTime.Parse(ds.Tables[0].Rows[0]["LastDate"].ToString());
                }
                if (ds.Tables[0].Rows[0]["DateUpdated"].ToString() != "")
                {
                    model.DateUpdated = DateTime.Parse(ds.Tables[0].Rows[0]["DateUpdated"].ToString());
                }
                if (ds.Tables[0].Rows[0]["GenearchUserID"].ToString() != "")
                {
                    model.GenearchUserID = int.Parse(ds.Tables[0].Rows[0]["GenearchUserID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Uid"].ToString() != "")
                {
                    model.Uid = int.Parse(ds.Tables[0].Rows[0]["Uid"].ToString());
                }
                model.UserSource = ds.Tables[0].Rows[0]["UserSource"].ToString();
                return model;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 获取用户信息实体(包括用户详细信息)
        /// </summary>
        /// <param name="UserID"></param>
        /// <returns></returns>
        public EduZY.Model.UserMaster GetMDModel(int UserID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 UserMaster.UserID,UserName,Password,Status,RoleID,RegStateDate,Sign,LastDate,DateUpdated,GenearchUserID,Uid,UserSource,");
            strSql.Append("TrueName,WorkUnit,BirthDay,Mobile,Phone,EMail,QQ,Address,PicAddresss,PicType ");
            strSql.Append(" from UserMaster,UserDetail ");
            strSql.Append(" where UserMaster.UserID=UserDetail.UserID and UserMaster.UserID=@UserID");
            SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.Int,4)
};
            parameters[0].Value = UserID;
            EduZY.Model.UserMaster model = new EduZY.Model.UserMaster();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["UserID"].ToString() != "")
                {
                    model.UserID = int.Parse(ds.Tables[0].Rows[0]["UserID"].ToString());
                }
                model.UserName = ds.Tables[0].Rows[0]["UserName"].ToString();
                model.Password = ds.Tables[0].Rows[0]["Password"].ToString();
                model.Status = ds.Tables[0].Rows[0]["Status"].ToString();
                model.RoleID = ds.Tables[0].Rows[0]["RoleID"].ToString();
                if (ds.Tables[0].Rows[0]["RegStateDate"].ToString() != "")
                {
                    model.RegStateDate = DateTime.Parse(ds.Tables[0].Rows[0]["RegStateDate"].ToString());
                }
                model.Sign = ds.Tables[0].Rows[0]["Sign"].ToString();
                if (ds.Tables[0].Rows[0]["LastDate"].ToString() != "")
                {
                    model.LastDate = DateTime.Parse(ds.Tables[0].Rows[0]["LastDate"].ToString());
                }
                if (ds.Tables[0].Rows[0]["DateUpdated"].ToString() != "")
                {
                    model.DateUpdated = DateTime.Parse(ds.Tables[0].Rows[0]["DateUpdated"].ToString());
                }
                if (ds.Tables[0].Rows[0]["GenearchUserID"].ToString() != "")
                {
                    model.GenearchUserID = int.Parse(ds.Tables[0].Rows[0]["GenearchUserID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Uid"].ToString() != "")
                {
                    model.Uid = int.Parse(ds.Tables[0].Rows[0]["Uid"].ToString());
                }
                model.UserSource = ds.Tables[0].Rows[0]["UserSource"].ToString();
                //用户详细信息
                model.TrueName = ds.Tables[0].Rows[0]["TrueName"].ToString();
                model.WorkUnit = ds.Tables[0].Rows[0]["WorkUnit"].ToString();
                if (ds.Tables[0].Rows[0]["BirthDay"].ToString() != "")
                {
                    model.BirthDay = DateTime.Parse(ds.Tables[0].Rows[0]["BirthDay"].ToString());
                }
                model.Mobile = ds.Tables[0].Rows[0]["Mobile"].ToString();
                model.Phone = ds.Tables[0].Rows[0]["Phone"].ToString();
                model.EMail = ds.Tables[0].Rows[0]["EMail"].ToString();
                model.QQ = ds.Tables[0].Rows[0]["QQ"].ToString();
                model.Address = ds.Tables[0].Rows[0]["Address"].ToString();
                model.PicAddresss = ds.Tables[0].Rows[0]["PicAddresss"].ToString();
                model.PicType = ds.Tables[0].Rows[0]["PicType"].ToString();
                return model;
            }
            else
            {
                return null;
            }
        }

		/// <summary>
		/// 获取当前页数据及总记录数
		/// </summary>
		/// <<param name="pageSize"></param>
		/// <param name="pageIndex"></param>
		/// <param name="iRecordCount"></param>
		/// <returns></returns>
		public DataSet GetPageList(int pageSize, int pageIndex, string UserName, out int iRecordCount)
        {
            string strWhere = " 1=1 ";
            if (UserName != "")
            {
                strWhere += " and UserMaster.UserName like '%" + UserName + "%'";
            }
            return DbHelperSQL.QueryPageList("UserMaster", "UserID", "UserID,UserName,(select TrueName from UserDetail where UserDetail.UserID=UserMaster.UserID) as TrueName,case Status when '0' then '未激活' when '1' then '已激活' else '禁用' end as StatusName ,(select RoleName from BasicRole where RoleID=UserMaster.RoleID) as RoleName,RegStateDate", pageSize, pageIndex, " RegStateDate desc ", strWhere, out iRecordCount);
        }

        /// <summary>
        /// 获取角色列表 
        /// </summary>
        /// <returns></returns>
        public DataSet GetRoleList()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select RoleID,RoleName,ParentRoleID from BasicRole");
            return DbHelperSQL.Query(strSql.ToString());
        }
        
        /// <summary>
        /// 验证用户名是否已被注册
        /// </summary>
        /// <param name="UserName"></param>
        /// <returns></returns>
        public bool VerifyUserName(string UserName)
        {
            string strSql = "select UserID from UserMaster where UserName='" + UserName + "'";
            DataSet ds = DbHelperSQL.Query(strSql);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return true;
            }

            return false;
        }

		#endregion  Method
	}
}

