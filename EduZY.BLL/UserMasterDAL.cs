using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;
using Maticsoft.DBUtility;

namespace EduJXC.DAL.Index
{
	/// <summary>
	/// 数据访问类:QFWUserMaster
	/// </summary>
	public class UserMasterDAL
	{
		public UserMasterDAL()
		{}
		#region  Method
        public bool ExistsUser(int UserID, string OldPWD)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from UserMaster");
            strSql.Append(" where UserID = @UserID  and  Password=@OldPWD ");

            SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.Int,4),
					new SqlParameter("@OldPWD", SqlDbType.VarChar,50)			};
            parameters[0].Value = UserID;
            parameters[1].Value = OldPWD;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public int UpdatePWD(EduJXC.Model.UserMaster model)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("update UserMaster set ");
            strSql.Append(" Password = @Password  ");
            strSql.Append(" where UserID=@UserID ");

            SqlParameter[] parameters = {
			            new SqlParameter("@UserID", SqlDbType.Int,4) ,            
                        new SqlParameter("@Password", SqlDbType.VarChar,32) 
                                       };

            parameters[0].Value = model.UserID;
            parameters[1].Value = model.Password;

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
		/// 增加一条数据
		/// </summary>
		public int Add(EduJXC.Model.UserMaster model)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.Int,4),
					new SqlParameter("@UserName", SqlDbType.VarChar,50),
					new SqlParameter("@Password", SqlDbType.VarChar,32),
					new SqlParameter("@Status", SqlDbType.VarChar,1),
					new SqlParameter("@RoleID", SqlDbType.Char,1),
					new SqlParameter("@TrueName", SqlDbType.NVarChar,20),
					new SqlParameter("@Mobile", SqlDbType.VarChar,12),
					new SqlParameter("@Phone", SqlDbType.VarChar,20),
					new SqlParameter("@EMail", SqlDbType.VarChar,100),
					new SqlParameter("@QQ", SqlDbType.VarChar,15),
					new SqlParameter("@Sex", SqlDbType.Bit),
					new SqlParameter("@BuMenId", SqlDbType.Int,4),
					new SqlParameter("@ZhiCheng", SqlDbType.NVarChar, 50),
                    new SqlParameter("@StoreId", SqlDbType.Int,4),
					new SqlParameter("@StoreName", SqlDbType.NVarChar, 50)                  
                                        
                                        };
            parameters[0].Direction = ParameterDirection.Output;
            parameters[1].Value = model.UserName;
            parameters[2].Value = model.Password;
            parameters[3].Value = model.Status;
            parameters[4].Value = model.RoleID;
            parameters[5].Value = model.TrueName;
            parameters[6].Value = model.Mobile;
            parameters[7].Value = model.Phone;
            parameters[8].Value = model.EMail;
            parameters[9].Value = model.QQ;
            parameters[10].Value = model.Sex;
            parameters[11].Value = model.BuMenId;
            parameters[12].Value = model.ZhiCheng;
            parameters[13].Value = model.StoreId;
            parameters[14].Value = model.StoreName;
            return DbHelperSQL.RunProcedure("UP_Add_User", parameters, out rowsAffected);
		}

        ///// <summary>
        ///// 更新一条数据
        ///// </summary>
        //public int  UpdateLast(EduJXC.Model.UserMaster model)
        //{
        //    int rowsAffected;
        //    SqlParameter[] parameters = {
        //            new SqlParameter("@UserID", SqlDbType.Int,4),
        //            new SqlParameter("@UserName", SqlDbType.VarChar,50),
        //            new SqlParameter("@Password", SqlDbType.VarChar,32),
        //            new SqlParameter("@Status", SqlDbType.VarChar,1),
        //            new SqlParameter("@RoleID", SqlDbType.Char,1),
        //            new SqlParameter("@TrueName", SqlDbType.NVarChar,20),
        //            new SqlParameter("@Mobile", SqlDbType.VarChar,12),
        //            new SqlParameter("@Phone", SqlDbType.VarChar,20),
        //            new SqlParameter("@EMail", SqlDbType.VarChar,100),
        //            new SqlParameter("@QQ", SqlDbType.VarChar,15),
        //            new SqlParameter("@Sex", SqlDbType.Bit)  };
        //    parameters[0].Value = model.UserID;
        //    parameters[1].Value = model.UserName;
        //    parameters[2].Value = model.Password;
        //    parameters[3].Value = model.Status;
        //    parameters[4].Value = model.RoleID;
        //    parameters[5].Value = model.TrueName;
        //    parameters[6].Value = model.Mobile;
        //    parameters[7].Value = model.Phone;
        //    parameters[8].Value = model.EMail;
        //    parameters[9].Value = model.QQ;
        //    parameters[10].Value = model.Sex;

        //    return DbHelperSQL.RunProcedure("UP_Edit_User", parameters, out rowsAffected);
        //}
        
        /// <summary>
        /// 真删除用户
        /// </summary>
        /// <param name="UserIDList"></param>
        /// <returns></returns>
        public bool Disable(string UserIDList)
        {
            string strSql = "update UserMaster set IsDelete=1  where UserID in (" + UserIDList + ")";
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
		public EduJXC.Model.UserMaster GetModel(int UserID)
		{
			
			StringBuilder strSql=new StringBuilder();
            strSql.Append("SELECT *  FROM .[dbo].[View_SelectUserList]");
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
        public DataSet GetUserNameList(string UserName)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 * from UserMaster ");
            strSql.Append(" where UserName=@UserName");
            SqlParameter[] parameters = {
					new SqlParameter("@UserName", SqlDbType.VarChar,50)
};
            parameters[0].Value = UserName;

            return DbHelperSQL.Query(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        private EduJXC.Model.UserMaster GetModel(string strSql, SqlParameter[] parameters)
        {
            EduJXC.Model.UserMaster model = new EduJXC.Model.UserMaster();
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
                model.TrueName = ds.Tables[0].Rows[0]["TrueName"].ToString();
                model.Mobile = ds.Tables[0].Rows[0]["Mobile"].ToString();
                model.Phone = ds.Tables[0].Rows[0]["Phone"].ToString();
                model.QQ = ds.Tables[0].Rows[0]["QQ"].ToString();
                model.EMail = ds.Tables[0].Rows[0]["EMail"].ToString();
                if (ds.Tables[0].Rows[0]["BuMenId"].ToString() != "")
                {
                    model.BuMenId = int.Parse(ds.Tables[0].Rows[0]["BuMenId"].ToString());
                }

                //if (ds.Tables[0].Rows[0]["StoreId"].ToString() != "")
                //{
                //    model.StoreId = int.Parse(ds.Tables[0].Rows[0]["StoreId"].ToString());
                //}

                if (ds.Tables[0].Rows[0]["sex"] != null && ds.Tables[0].Rows[0]["sex"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["sex"].ToString() == "1") || (ds.Tables[0].Rows[0]["sex"].ToString().ToLower() == "true"))
                    {
                        model.Sex = true;
                    }
                    else
                    {
                        model.Sex = false;
                    }
                }
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
        public EduJXC.Model.UserMaster GetMDModel(int UserID)
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
            EduJXC.Model.UserMaster model = new EduJXC.Model.UserMaster();
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
        public DataSet GetPageList(int pageSize, int pageIndex, string strWhere, out int iRecordCount)
        {

            StringBuilder strSql = new StringBuilder();

            strSql.Append("UserID,UserName,(select top  1 TrueName from UserDetail where UserDetail.UserID=UserMaster.UserID) as TrueName,");
            strSql.Append("case Status when '0' then '未激活' when '1' then '已激活' else '禁用' end as StatusName ,RegStateDate,");
            strSql.Append("(select RoleName from BasicRole where RoleID in (select RoleID from dbo.UserRole where UserID=UserMaster.UserID )) as RoleName");

            return DbHelperSQL.QueryPageList("UserMaster", "UserID", strSql.ToString(), pageSize, pageIndex, " RegStateDate desc ", strWhere, out iRecordCount);
        }

        public EduJXC.Model.UserMaster DataRowToModel(DataRow row)
        {
            EduJXC.Model.UserMaster model = new EduJXC.Model.UserMaster();
            if (row != null)
            {
                if (row["UserID"] != null && row["UserID"].ToString() != "")
                {
                    model.UserID = int.Parse(row["UserID"].ToString());
                }
                if (row["UserName"] != null)
                {
                    model.UserName = row["UserName"].ToString();
                }
                if (row["RoleName"] != null)
                {
                    model.RoleName = row["RoleName"].ToString();
                }
                if (row["StatusName"] != null)
                {
                    model.Status = row["StatusName"].ToString();
                }
                if (row["TrueName"] != null)
                {
                    model.TrueName = row["TrueName"].ToString();
                }
                if (row["RegStateDate"] != null && row["RegStateDate"].ToString() != "")
                {
                    model.RegStateDate = DateTime.Parse(row["RegStateDate"].ToString());
                }
                
            }
            return model;
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

        #region 扩展方法

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public int Update(EduJXC.Model.UserMaster model)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.Int,4),
					new SqlParameter("@UserName", SqlDbType.VarChar,50),
					new SqlParameter("@Status", SqlDbType.VarChar,1),
					new SqlParameter("@RoleID", SqlDbType.Char,1),
					new SqlParameter("@TrueName", SqlDbType.NVarChar,20),
					new SqlParameter("@Mobile", SqlDbType.VarChar,12),
					new SqlParameter("@Phone", SqlDbType.VarChar,20),
					new SqlParameter("@EMail", SqlDbType.VarChar,100),
					new SqlParameter("@QQ", SqlDbType.VarChar,15),
					new SqlParameter("@Sex", SqlDbType.Bit),
					new SqlParameter("@BuMenId", SqlDbType.Int,4),
					new SqlParameter("@ZhiCheng", SqlDbType.NVarChar, 50),
                    new SqlParameter("@StoreId", SqlDbType.Int,4),
					new SqlParameter("@StoreName", SqlDbType.NVarChar, 50)                            
                                        };
            parameters[0].Value = model.UserID;
            parameters[1].Value = model.UserName;
            parameters[2].Value = model.Status;
            parameters[3].Value = model.RoleID;
            parameters[4].Value = model.TrueName;
            parameters[5].Value = model.Mobile;
            parameters[6].Value = model.Phone;
            parameters[7].Value = model.EMail;
            parameters[8].Value = model.QQ;
            parameters[9].Value = model.Sex;
            parameters[10].Value = model.BuMenId;
            parameters[11].Value = model.ZhiCheng;
            parameters[12].Value = model.StoreId;
            parameters[13].Value = model.StoreName;
            return DbHelperSQL.RunProcedure("UP_Edit_User", parameters, out rowsAffected);
        }

        /// <summary>
        /// 获取用户ID和名字列表
        /// </summary>
        /// <param name="StrWhere"></param>
        /// <returns></returns>
        public DataSet GetList(string StrWhere)
        {
            string strsql = @"select m.UserID, case d.TrueName when Null then m.UserName else d.TrueName end as TrueName from usermaster m 
                            left join UserDetail d on m.UserID=d.UserID where 1=1 ";
            strsql = strsql + StrWhere;
            return DbHelperSQL.Query(strsql);
        }

        public int GetUserID(string UserName)
        {
            string strsql = "select UserID from UserMaster where UserName='" + UserName + "'";
            DataSet ds = DbHelperSQL.Query(strsql);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return Convert.ToInt32(ds.Tables[0].Rows[0]["UserID"].ToString());
            }
            else
            {
                return 0;
            }
        }

        public void AddDetail(int UserID, string TrueName)
        {
            string strsql = "insert into UserDetail (UserId,TrueName) values ({0},'{1}')";
            strsql = string.Format(strsql);
            DbHelperSQL.ExecuteSql(strsql);
        }
        #endregion
    }
}


