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
using System.Web;
using Common;

namespace EduZY.Web
{
    public class CommonHelper
    {
        /// <summary>
        /// 动态反射
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="model"></param>
        /// <param name="newmodel"></param>
        /// <returns></returns>
        public static T NewObject<T>(T model, T newmodel)
        {
            Type t2 = typeof(T);
            PropertyInfo[] propertys2 = t2.GetProperties();
            foreach (PropertyInfo pi in propertys2)
            {
                string name = pi.Name;
                object value = t2.GetProperty(name).GetValue(model, null);
                if (!pi.CanWrite) continue;//该属性不可写，直接跳出  

                if (value != null)
                {
                    if (pi.PropertyType.ToString() == "System.DateTime")
                    {
                        if (Convert.ToDateTime(value).Ticks == 0)
                            continue;
                    }
                    t2.GetProperty(name).SetValue(newmodel, value, null);
                }
            }
            return newmodel;
        }

        public static List<tb_MenuPage> UserMenuList(int UserID)
        {
            DataSet ds = DbHelperSQL.Query(@"select distinct m.MenuID
      ,m.MenuName
      ,m.MenuType
      ,m.MenuShort
      ,m.MenuUrl
      ,m.MenuICO
      ,m.UpdateDate
      ,m.ParentId
      ,m.RootID
      ,m.AddDate
      ,m.Status
      ,m.Sort from tb_UserMenu_Right um 
join tb_MenuPage m on um.MenuID=m.MenuID and um.ButtonID=0
where um.UserID=" + UserID + @" and m.Status=1
union 
select distinct m.MenuID
      ,m.MenuName
      ,m.MenuType
      ,m.MenuShort
      ,m.MenuUrl
      ,m.MenuICO
      ,m.UpdateDate
      ,m.ParentId
      ,m.RootID
      ,m.AddDate
      ,m.Status
      ,m.Sort from tb_UserRole ur
join  tb_RoleMenu_Right rm on ur.RoleID=rm.RoleID
join tb_MenuPage m on rm.MenuID=m.MenuID and rm.ButtonID=0
where ur.UserID=" + UserID + @"  and m.Status=1 ");
            List<tb_MenuPage> list = TBToList<tb_MenuPage>.ConvertToList(ds.Tables[0]).ToList();

            return list;
        }

        /// <summary>
        /// 计算文件大小函数(保留两位小数),Size为字节大小
        /// </summary>
        /// <param name="Size">初始文件大小</param>
        /// <returns></returns>
        public static string CountFileSize(long Size)
        {
            double KBCount = 1024;
            double MBCount = KBCount * 1024;
            double GBCount = MBCount * 1024;
            double TBCount = GBCount * 1024;
            string m_strSize = "";
            long FactSize = 0;
            FactSize = Size;
            if (FactSize < KBCount)
                m_strSize = FactSize.ToString("F2") + " Byte";
            else if (FactSize >= KBCount && FactSize < MBCount)
                m_strSize = (FactSize / KBCount).ToString("F2") + " KB";
            else if (FactSize >= MBCount && FactSize < GBCount)
                m_strSize = (FactSize / MBCount).ToString("F2") + " MB";
            else if (FactSize >= GBCount && FactSize < TBCount)
                m_strSize = (FactSize / GBCount).ToString("F2") + " GB";
            else if (FactSize >= TBCount)
                m_strSize = (FactSize / TBCount).ToString("F2") + " TB";
            return m_strSize;
        }
        public static string getFilesMD5Hash(string file)
        {
            //MD5 hash provider for computing the hash of the file
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            //open the file
            FileStream stream = new FileStream(file, FileMode.Open, FileAccess.Read, FileShare.Read, 8192);
            //calculate the files hash
            md5.ComputeHash(stream);
            //close our stream
            stream.Close();
            //byte array of files hash
            byte[] hash = md5.Hash;
            //string builder to hold the results
            StringBuilder sb = new StringBuilder();
            //loop through each byte in the byte array
            foreach (byte b in hash)
            {
                //format each byte into the proper value and append
                //current value to return value
                sb.Append(string.Format("{0:X2}", b));
            }
            //return the MD5 hash of the file
            return sb.ToString();
        }

        public static string GetCheckListItemsString<T>(string controlName,List<T> list, string itemValueName, string itemTextName, string defKey)
        {
            string str = "";
            foreach (T m in list)
            {
                Type t2 = typeof(T);
                str += "<input  type=\"checkbox\" value=\"" + t2.GetProperty(itemValueName).GetValue(m, null) + "\" " + (t2.GetProperty(itemValueName).GetValue(m, null) + "" == defKey ? " checked=\"checked\"" : "") + @" name='" + controlName + @"' />" + t2.GetProperty(itemTextName).GetValue(m, null) + "  ";
            }
            return str;
        }
        public static string GetDropItemsString<T>(List<T> list, string itemValueName, string itemTextName, string defKey)
        {
            string str = "";
            foreach (T m in list)
            {
                Type t2 = typeof(T);
                str += "<option value=\"" + t2.GetProperty(itemValueName).GetValue(m, null) + "\" " + (t2.GetProperty(itemValueName).GetValue(m, null) + "" == defKey ? " selected=\"selected\"" : "") + @">" + t2.GetProperty(itemTextName).GetValue(m, null) + "</option>";
            }
            return str;
        }

        public static string GetCurrentPagePath()
        {
            string str = "";
            string pagePath = System.Web.HttpContext.Current.Request.Url.AbsolutePath.ToLower();
            List<tb_MenuPage> list = CacheCommon.MenuPageList();
            tb_MenuPage model = list.FirstOrDefault(p => p.MenuUrl.ToLower().StartsWith(System.Web.HttpContext.Current.Request.Url.PathAndQuery.ToString().ToLower()) == true);
            if(model==null)
            model = list.FirstOrDefault(p => p.MenuUrl.ToLower().StartsWith(pagePath.ToLower()) == true);
            if (model != null)
            {
                if (model.ParentId != 0)
                {
                     tb_MenuPage model2 = list.FirstOrDefault(p =>p.MenuID==model.ParentId);
                    str += @"<li><span class=""divider""></span>
                </li><li class=""active"">" + model2.MenuName + @" </li>";
                }
                str += @"<li><span class=""divider""></span>
                </li><li class=""active"">" + model.MenuName + @" </li>";
            }
            return str;
        }


    

    
    }
}
