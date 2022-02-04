using System;
using System.IO;
using System.Text;

namespace EduZY.Web
{
    /// <summary>
    /// FileAccessHelper 文件访问辅助类
    /// </summary>
    public class FileAccessHelper
    {
        //public static bool ExportExcelWithAspose(System.Data.DataTable dt, string path)
        //{
        //    bool succeed = false;
        //    if (dt != null)
        //    {
        //        try
        //        {
        //            Aspose.Cells.License li = new Aspose.Cells.License();
            
        //            Stream s = new MemoryStream(Resources.License);
        //            li.SetLicense(s);

        //            Aspose.Cells.Workbook workbook = new Aspose.Cells.Workbook();
        //            Aspose.Cells.Worksheet cellSheet = workbook.Worksheets[0];

        //            cellSheet.Name = dt.TableName;

        //            int rowIndex = 0;
        //            int colIndex = 0;
        //            int colCount = dt.Columns.Count;
        //            int rowCount = dt.Rows.Count;

        //            //列名的处理
        //            for (int i = 0; i < colCount; i++)
        //            {
        //                cellSheet.Cells[rowIndex, colIndex].PutValue(dt.Columns[i].ColumnName);
        //                cellSheet.Cells[rowIndex, colIndex].Style.Font.IsBold = true;
        //                cellSheet.Cells[rowIndex, colIndex].Style.Font.Name = "宋体";
        //                colIndex++;
        //            }

        //            Aspose.Cells.Style style = workbook.Styles[workbook.Styles.Add()];
        //            style.Font.Name = "Arial";
        //            style.Font.Size = 10;
        //            Aspose.Cells.StyleFlag styleFlag = new Aspose.Cells.StyleFlag();
        //            cellSheet.Cells.ApplyStyle(style, styleFlag);

        //            rowIndex++;

        //            for (int i = 0; i < rowCount; i++)
        //            {
        //                colIndex = 0;
        //                for (int j = 0; j < colCount; j++)
        //                {
        //                    cellSheet.Cells[rowIndex, colIndex].PutValue(dt.Rows[i][j].ToString());
        //                    colIndex++;
        //                }
        //                rowIndex++;
        //            }
        //            cellSheet.AutoFitColumns();

        //            path = Path.GetFullPath(path);
        //            if (Directory.Exists(Path.GetDirectoryName(path)) == false)
        //                Directory.CreateDirectory(Path.GetDirectoryName(path));
        //            workbook.Save(path);
        //            succeed = true;
        //        }
        //        catch (Exception ex)
        //        {
        //            succeed = false;
        //        }
        //    }

        //    return succeed;
        //}
        /// <summary>
        /// 创建目录
        /// </summary>
        /// <param name="dir">此地路径相对站点而言</param>
        public static void CreateDir(string dir)
        {
            if (dir.Length == 0) return;
            if (!System.IO.Directory.Exists(System.Web.HttpContext.Current.Server.MapPath(dir)))
                System.IO.Directory.CreateDirectory(System.Web.HttpContext.Current.Server.MapPath(dir));
        }
        /// <summary>
        /// 创建目录路径
        /// </summary>
        /// <param name="folderPath">物理路径</param>
        public static void CreateFolder(string folderPath)
        {
            if (!System.IO.Directory.Exists(folderPath))
                System.IO.Directory.CreateDirectory(folderPath);
        }
        /// <summary>
        /// 删除目录
        /// </summary>
        /// <param name="dir">此地路径相对站点而言</param>
        public static void DeleteDir(string dir)
        {
            if (dir.Length == 0) return;
            if (System.IO.Directory.Exists(System.Web.HttpContext.Current.Server.MapPath(dir)))
                System.IO.Directory.Delete(System.Web.HttpContext.Current.Server.MapPath(dir), true);
        }
        private static Encoding defaultEncoding = Encoding.UTF8;

        #region ReadTextFile
        /// <summary>
        /// ReadTextFile
        /// </summary>
        /// <param name="fileName">文件路径</param>
        /// <returns>文本内容</returns>
        public static string ReadTextFile(string fileName)
        { //StreamReader sr = new StreamReader("D:/wwwroot/ip.txt", System.Text.Encoding.Default);
            //while (sr.Peek() > -1)
            //{
            //        string sIpLine = sr.ReadLine();
            //}
            //sr.Close();
            return ReadTextFile(fileName, defaultEncoding);
        }

        /// <summary>
        /// ReadTextFile
        /// </summary>
        /// <param name="fileName">文件路径</param>
        /// <param name="encoding">编码</param>
        /// <returns>文本内容</returns>
        public static string ReadTextFile(string fileName, Encoding encoding)
        {
            string text;

            using (StreamReader sr = new StreamReader(fileName, encoding))
            {
                text = sr.ReadToEnd();
            }

            return text;
        }
        #endregion

        #region WriteTextFile
        /// <summary>
        /// WriteTextFile
        /// </summary>
        /// <param name="fileName">文件路径</param>
        /// <param name="text">文本内容</param>
        public static void WriteTextFile(string fileName, string text)
        {
            WriteTextFile(fileName, text, false, true, defaultEncoding);
        }

        /// <summary>
        /// WriteTextFile
        /// </summary>
        /// <param name="fileName">文件路径</param>
        /// <param name="text">文本内容</param>
        /// <param name="encoding">编码</param>	
        public static void WriteTextFile(string fileName, string text, Encoding encoding)
        {
            WriteTextFile(fileName, text, false, true, encoding);
        }

        /// <summary>
        /// WriteTextFile
        /// </summary>
        /// <param name="fileName">文件路径</param>
        /// <param name="text">文本内容</param>
        /// <param name="createDir">是否创建目录</param>		
        public static void WriteTextFile(string fileName, string text, bool createDir)
        {
            WriteTextFile(fileName, text, false, createDir, defaultEncoding);
        }

        /// <summary>
        /// WriteTextFile
        /// </summary>
        /// <param name="fileName">文件路径</param>
        /// <param name="text">文本内容</param>
        /// <param name="createDir">是否创建目录</param>
        /// <param name="encoding">编码</param>	
        public static void WriteTextFile(string fileName, string text, bool createDir, Encoding encoding)
        {
            WriteTextFile(fileName, text, false, createDir, encoding);
        }

        /// <summary>
        /// WriteTextFile
        /// </summary>
        /// <param name="fileName">文件路径</param>
        /// <param name="text">文本内容</param>
        /// <param name="append">是否添加到文本后面</param>
        /// <param name="createDir">是否创建目录</param>
        /// <param name="encoding">编码</param>
        public static void WriteTextFile(string fileName, string text, bool append, bool createDir, Encoding encoding)
        {
            if (createDir)
            {
                string dirName = Path.GetDirectoryName(fileName);

                if (!Directory.Exists(dirName))
                {
                    Directory.CreateDirectory(dirName);
                }
            }

            using (StreamWriter sw = new StreamWriter(fileName, append, encoding))
            {
                sw.Write(text);
            }
        }
        #endregion

        #region 文件删除
        public static bool FileDelete(string filePath)
        {
            try
            {
                FileInfo fi = new FileInfo(filePath);
                fi.Delete();
                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion
    }

    public enum FileType
    {
        Txt = 1,
        Rar = 2,
        Zip = 4,
        Bmp = 8,
        Jpg = 16,
        Gif = 32,
        Png = 64,
        Doc = 128,
        Xls = 256,
        Pdf = 512
    }
}

