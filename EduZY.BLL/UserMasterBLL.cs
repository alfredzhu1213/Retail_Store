using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using EduJXC.Model;
namespace EduJXC.BLL.Admin
{
	/// <summary>
	/// UserMaster
	/// </summary>
	public class UserMasterBLL
	{
        private readonly EduJXC.DAL.Index.UserMasterDAL dal = new EduJXC.DAL.Index.UserMasterDAL();
		public UserMasterBLL()
		{}
		#region  Method

        public bool ExistsUser(int UserID, string OldPWD)
        {
            return dal.ExistsUser(UserID, OldPWD);
        }

        public int UpdatePWD(UserMaster model)
        {
            return dal.UpdatePWD(model);
        }

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(EduJXC.Model.UserMaster model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public int  Update(EduJXC.Model.UserMaster model)
		{
			return dal.Update(model);
		}
        
        /// <summary>
        /// 禁用用户
        /// </summary>
        /// <param name="UserIDList"></param>
        /// <returns></returns>
        public bool Disable(string UserIDList)
        {
            return dal.Disable(UserIDList);
        }


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public EduJXC.Model.UserMaster GetModel(int UserID)
		{
			
			return dal.GetModel(UserID);
		}

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public DataSet GetUserNameList(string UserName)
        {

            return dal.GetUserNameList(UserName);
        }

        /// <summary>
        /// 获取用户信息实体(包括用户详细信息)
        /// </summary>
        /// <param name="UserID"></param>
        /// <returns></returns>
        public EduJXC.Model.UserMaster GetMDModel(int UserID)
        {
            return dal.GetMDModel(UserID);
        }


        public IEnumerable<EduJXC.Model.UserMaster> GetPageList(int pageSize, int pageIndex, string strWhere, out int iRecordCount)
        {
            DataSet ds = dal.GetPageList(pageSize, pageIndex, strWhere, out iRecordCount);
            List<EduJXC.Model.UserMaster> modellist = DataTableToList(ds.Tables[0]);
            return modellist;
        }

        public List<EduJXC.Model.UserMaster> DataTableToList(DataTable dt)
        {
            List<EduJXC.Model.UserMaster> modelList = new List<EduJXC.Model.UserMaster>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                EduJXC.Model.UserMaster model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = dal.DataRowToModel(dt.Rows[n]);
                    if (model != null)
                    {
                        modelList.Add(model);
                    }
                }
            }
            return modelList;
        }


        /// <summary>
        /// 获取角色列表 
        /// </summary>
        /// <returns></returns>
        public DataSet GetRoleList()
        {
            return dal.GetRoleList();
        }

        /// <summary>
        /// 验证用户名是否已被注册
        /// </summary>
        /// <param name="UserName"></param>
        /// <returns></returns>
        public bool VerifyUserName(string UserName)
        {
            return dal.VerifyUserName(UserName);
        }

		#endregion  Method

        
        /// <summary>
        /// 获取用户列表
        /// </summary>
        /// <param name="StrWhere"></param>
        /// <returns></returns>
        public DataSet GetList(string StrWhere)
        {
            return dal.GetList(StrWhere);
        }

        public int GetUserID(string UserName)
        {
            return dal.GetUserID(UserName);
        }

        public void AddDetail(int UserID, string TrueName)
        {
            dal.AddDetail(UserID, TrueName);
        }
	}
}

