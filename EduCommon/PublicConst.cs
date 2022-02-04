using System;
using System.Collections.Generic;
using System.Text;

namespace Common
{
    public static class PublicConst
    {
        //登录后台cookie名称
        public static string ManageCookieName = "ManageUserInfo";

        //前台cookie名称
        public static string CookieName = "UserInfo";

        //论坛路径
        public static string bbspath = System.Configuration.ConfigurationManager.AppSettings["bbspath"];

        //博客路径
        public static string blogpath = System.Configuration.ConfigurationManager.AppSettings["blogpath"];

        //站点域名
        public static string Domain = System.Configuration.ConfigurationManager.AppSettings["Domain"];

        /// <summary>
        /// 后台管理标题
        /// </summary>
        public static string WebManageTitle = System.Configuration.ConfigurationManager.AppSettings["WebManageTitle"];



        public static string TempCss = "default";

  
        /// <summary>
        /// 后台分页记录数
        /// </summary>
        public static int pageSize = 15;


        /// <summary>
        /// 水印文字
        /// </summary>
        public static string WaterMarkTitle = System.Configuration.ConfigurationManager.AppSettings["WaterMarkTitle"];

        /// <summary>
        /// 水印文字(横向起始位置)
        /// </summary>
        public static int WaterMarkWidth = Units.ToInt(System.Configuration.ConfigurationManager.AppSettings["WaterMarkWidth"]);

        /// <summary>
        /// 水印文字(纵向距底位置)
        /// </summary>
        public static int WaterMarkHeight = Units.ToInt(System.Configuration.ConfigurationManager.AppSettings["WaterMarkHeight"]);
    }
}
