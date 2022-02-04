using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;
using System.IO;
using System.Web;

namespace Common
{
    public static class UpLoadFile
    {
        /// <summary>
        /// 上传文件
        /// </summary>
        /// <param name="fileupload">上传文件控件</param>
        /// <returns>未上传返回为空,否则返回路径</returns>
        public static string SaveFile(FileUpload fileupload)
        {
            string filename = fileupload.FileName;
            if (filename == "")
                return "";
            //文件名与路径
            DateTime time = DateTime.Now;
            string newfilename = time.ToString("yyyyMMddHHmmssfff") + filename.Substring(filename.LastIndexOf('.'));
            string path = HttpContext.Current.Server.MapPath("~\\uploadfile\\" + time.Year.ToString() + "\\" + time.Month.ToString() + "\\" + time.Day.ToString() + "\\");
            //创建文件夹
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
            //上传文件
            string picpath = path + newfilename;
            fileupload.SaveAs(picpath);

            return ("\\uploadfile\\" + time.Year.ToString() + "\\" + time.Month.ToString() + "\\" + time.Day.ToString() + "\\" + newfilename).Replace("\\", "/");
        }

        /// <summary>
        /// 上传文件（含有旧文件，需要删除）
        /// </summary>
        /// <param name="fileupload">上传文件控件</param>
        /// <param name="lastfilename">旧文件名</param>
        /// <returns>未上传返回为空,否则返回路径</returns>
        public static string SaveFile(FileUpload fileupload, string lastfilename)
        {
            string filename = fileupload.FileName;
            if (filename == "")
                return "";
            //文件名与路径
            DateTime time = DateTime.Now;
            string newfilename = time.ToString("yyyyMMddHHmmssfff") + filename.Substring(filename.LastIndexOf('.'));
            string path = HttpContext.Current.Server.MapPath("~\\uploadfile\\" + time.Year.ToString() + "\\" + time.Month.ToString() + "\\" + time.Day.ToString() + "\\");
            //创建文件夹
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
            //删除文件
            if (lastfilename != "" && File.Exists(HttpContext.Current.Server.MapPath("~" + lastfilename)))
                File.Delete(HttpContext.Current.Server.MapPath("~" + lastfilename));
            //上传文件
            string picpath = path + newfilename;
            fileupload.SaveAs(picpath);

            return ("\\uploadfile\\" + time.Year.ToString() + "\\" + time.Month.ToString() + "\\" + time.Day.ToString() + "\\" + newfilename).Replace("\\", "/");
        }
    }
}
