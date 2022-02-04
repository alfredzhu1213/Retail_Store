using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using EduZY.Model;
using Maticsoft.DBUtility;
using System.Security.Cryptography;
using System.IO;

namespace EduZY.Web
{

    public class CacheCommon
    {
      
        public static List<tb_MenuPage> MenuPageList()
        {
            List<tb_MenuPage> list = new List<tb_MenuPage>();
            object objDs = CacheHelper.Get("MenuPageList");
            if (objDs == null)
            {
                zhxy_resEntities ef = new zhxy_resEntities();
                list = ef.tb_MenuPage.Where(p => 1 == 1).ToList();
                CacheHelper.Insert("MenuPageList", list, 200);
            }
            else
            {
                list = (List<tb_MenuPage>)objDs;
            }
            return list;

        }
        public static List<tb_Doption> DicOtion(int MoptionID)
        {
            List<tb_Doption> list = new List<tb_Doption>();
            object objDs = CacheHelper.Get("DicOtion" + MoptionID);
            if (objDs == null)
            {
                zhxy_resEntities ef = new zhxy_resEntities();
                list = ef.tb_Doption.Where(p => p.Status == 1 && p.MoptionID == MoptionID).OrderBy(p=>p.Sort).ToList();
                CacheHelper.Insert("DicOtion" + MoptionID, list, 200);
            }
            else
            {
                list = (List<tb_Doption>)objDs;
            }
            return list;

        }

        public static List<tb_Role> RoleList()
        {
            List<tb_Role> list = new List<tb_Role>();
            object objDs = CacheHelper.Get("tb_Role");
            if (objDs == null)
            {
                zhxy_resEntities ef = new zhxy_resEntities();
                list = ef.tb_Role.Where(p => 1 == 1).ToList();
                CacheHelper.Insert("tb_Role", list, 200);
            }
            else
            {
                list = (List<tb_Role>)objDs;
            }
            return list;

        }

    }
}
