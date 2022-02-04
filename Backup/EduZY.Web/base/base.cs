using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EduZY.Model;

namespace EduZY.Web
{


    public class BaseQX
    {
        public static int GetMenuID(string currentURL)
        {
            zhxy_resEntities ef = new zhxy_resEntities();
            tb_MenuPage m = ef.tb_MenuPage.FirstOrDefault(u => u.MenuUrl == currentURL);
            int MenuId = 0;
            if (m != null)
            {
                if (m.MenuType == 1)
                {
                    MenuId = m.MenuID;
                }
                else
                {
                    MenuId = Convert.ToInt32(m.ParentId);
                }
            }
            return MenuId;
        }

        public IEnumerable<tb_MenuPage> GetSysMenuPPid(int menuId)
        {
            zhxy_resEntities ef = new zhxy_resEntities();
            var dt = new List<tb_MenuPage>();
            var m = ef.CreateObjectSet<tb_MenuPage>().SingleOrDefault(u => u.MenuID == menuId);
            if (m != null && m.ParentId > 0)
            {
                var t = this.GetSysMenuPPid(m.ParentId);
                dt.AddRange(t);
            }
            if (m != null)
            {
                dt.Add(m);
            }

            return dt;
        }

        public string GetUserPrivilege(string userId, string menuId)
        {
            zhxy_resEntities Db = new zhxy_resEntities();

            var txt = string.Empty;
            if (userId == "" || menuId == "0") //参数判断
                return txt;

            var _userid = int.Parse(userId);
            var _menuid = int.Parse(menuId);

            var roleIds = Db.CreateObjectSet<tb_UserRole>().Where(role => role.UserID == _userid).Select(role => role.RoleID);
            var menuIds = Db.CreateObjectSet<tb_RoleMenu_Right>().Where(rm => roleIds.Contains(rm.RoleID)).Select(rm => rm.MenuID);
            var temp = Db.CreateObjectSet<tb_MenuPage>().Where(menu => menu.ParentId == _menuid && menu.MenuType == 2 && menuIds.Contains(menu.MenuID));

            txt = string.Join(",", temp.Select(u => u.MenuName));
            return txt;
        }



    }

    public struct  BaseRightInfo
    {
        public const string 新增 = "新增";
        public const string 修改 = "修改";
        public const string 删除 = "删除";
        public const string 查询 = "查询";
        public const string 导入 = "导入";
        public const string 导出 = "导出";
      
    }
}