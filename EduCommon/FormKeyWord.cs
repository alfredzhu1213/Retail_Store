using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common
{
    public class FormKeyWord
    {
        #region Session中的key值
        /// <summary>
        /// 已登录管理员的key值
        /// </summary>
        public const string SESSION_LOGINMANAGER_KEY = "MANAGER";
        /// <summary>
        /// 登录页面验证码的key值
        /// </summary>
        public const string SESSION_LOGINCODE_KEY = "LOGINCODE";

        #endregion

        #region 用户登录的提示信息

        /// <summary>
        /// 抱歉，该用户已被管理员禁用无法登录！
        /// </summary>
        public const string LOGIN_MANAGER_ENABLE = "抱歉，该用户已被管理员禁用无法登录！";
        /// <summary>
        /// 密码或用户名出错！
        /// </summary>
        public const string LOGIN_LOGINIDANDLOGINOWD_ERROR = "密码或用户名出错！";
        /// <summary>
        /// 验证码错误！
        /// </summary>
        public const string LOGIN_LOGINCODE_ERROR = "验证码错误！";
        /// <summary>
        /// 您尚未登录，或登录已超时！请重新登录
        /// </summary>
        public const string DEFAULT_NOLOGIN_MSG = "您尚未登录，或登录已超时！请重新登录";
        /// <summary>
        /// 抱歉，您没有访问该页面的权限！
        /// </summary>
        public const string HEAD_NOROLE_LOOK = "抱歉，您没有访问该页面的权限！";
        #endregion

        #region 用户操作提示信息
        /// <summary>
        /// 删除成功
        /// </summary>
        public const string FORM_DELETE_OK = "删除成功！";
        /// <summary>
        /// 删除失败
        /// </summary>
        public const string FORM_DELETE_NO="删除失败！";
        /// <summary>
        /// 修改成功
        /// </summary>
        public const string FORM_UPDATE_OK="修改成功！";
        /// <summary>
        /// 修改失败
        /// </summary>
        public const string FORM_UPDATE_NO="修改失败！";
        /// <summary>
        /// 添加成功
        /// </summary>
        public const string FORM_ADD_OK="添加成功！";
        /// <summary>
        /// 添加失败
        /// </summary>
        public const string FORM_ADD_NO="添加失败！";
        /// <summary>
        /// 操作成功！
        /// </summary>
        public const string FORM_OK = "操作成功！";
        /// <summary>
        /// 操作失败！
        /// </summary>
        public const string FORM_NO = "操作失败！";
        /// <summary>
        /// 操作失败，系统超时！
        /// </summary>
        public const string FORM_ERROR = "操作失败，系统超时！";
         
        #endregion

        #region 权限管理系统信息
        /// <summary>
        /// 请为角色配置权限！
        /// </summary>
        public const string ROLEPOWER_NULLROLE = "请为角色配置权限！";
        /// <summary>
        /// 修改角色信息
        /// </summary>
        public const string ROLEPOWER_UPDATE_ROLE = "修改角色信息";
        /// <summary>
        /// 新增角色
        /// </summary>
        public const string ROLEPOWER_ADD_ROLE = "新增角色";
        /// <summary>
        /// 修改管理员信息
        /// </summary>
        public const string MANAGEEDIT_UPDATE_MANAGER = "修改管理员信息";
        /// <summary>
        /// 新增管理员
        /// </summary>
        public const string MANAGEEDIT_ADD_MANAGER = "新增管理员";
        /// <summary>
        /// 该登录名已存在!
        /// </summary>
        public const string MANAGEEDIT_ISINLOGINID = "该登录名已存在!";
        /// <summary>
        /// 新增权限
        /// </summary>
        public const string HANDLEADD_ADD_HANDLE = "新增权限";


       

        /// <summary>
        /// 修改权限信息
        /// </summary>
        public const string HANDLEADD_UPDATE_HANDLE = "修改权限信息";
       

        /// <summary>
        /// 权限信息添加成功！
        /// </summary>
        public const string HANDLEADD_ADDOK = "权限信息添加成功！";
        /// <summary>
        /// 权限信息修改成功！
        /// </summary>
        public const string HANDLEADD_UPDATEOK = "权限信息修改成功！";
        #endregion

        #region 无权限提示信息
        public const string HANDLEADD_SELECT_HANDLE_NO = "对不起，您没查看权限！";
        public const string HANDLEADD_ADD_HANDLE_NO = "对不起，您没新增权限！";
        public const string HANDLEADD_UPDATE_HANDLE_NO = "对不起，您没修改权限！";
        public const string HANDLEADD_DELETE_HANDLE_NO = "对不起，您没删除权限！"; 
        #endregion
    }
}
