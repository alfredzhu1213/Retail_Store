using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI.WebControls;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;

namespace Common
{
    /// <summary>
    /// 图片文件上传类
    /// </summary>
    public static class ImgUpLoad
    {
        /// <summary>
        /// 保存图片（不生成小图片）
        /// </summary>
        /// <param name="FU">上传控件</param>
        /// <param name="LastImgFilePath">旧图片文件路径</param>
        /// <returns></returns>
        public static string SaveFile(FileUpload FU, string LastImgFilePath)
        {
            return SaveFile(FU, LastImgFilePath, false);
        }

        /// <summary>
        /// 保存图片(默认宽度：72 高度：95 不变形裁剪）
        /// </summary>
        /// <param name="FU">上传控件</param>
        /// <param name="LastImgFilePath">旧图片文件路径</param>
        /// <param name="IsMakeSmalllImg">是否生成小图片（默认宽度72，高度：95）</param>
        /// <returns></returns>
        public static string SaveFile(FileUpload FU, string LastImgFilePath, bool IsMakeSmalllImg)
        {
            int width = 72;//图片宽度
            int height = 95;//图片高度
            return SaveFile(FU, LastImgFilePath, IsMakeSmalllImg, width, height, "Cut");
        }

        /// <summary>
        /// 保存图片(默认宽度：72 高度：95 不变形裁剪）
        /// </summary>
        /// <param name="FU">上传控件</param>
        /// <param name="LastImgFilePath">旧图片文件路径</param>
        /// <param name="IsMakeSmalllImg">是否生成小图片（默认宽度72，高度：95）</param>
        /// <param name="mode">生成缩略图的方式(HW: 指定高宽缩放（可能变形）, W: 指定宽,高按比例, H: 指定高,宽按比例, Cut: 指定高宽裁减（不变形）)</param>
        /// <returns></returns>
        public static string SaveFile(FileUpload FU, string LastImgFilePath, bool IsMakeSmalllImg, string mode)
        {
            int width = 72;//图片宽度
            int height = 95;//图片高度
            return SaveFile(FU, LastImgFilePath, IsMakeSmalllImg, width, height, mode);
        }

        /// <summary>
        /// 保存图片（根据宽度和高度生成对应的小图片）
        /// </summary>
        /// <param name="FU">上传控件</param>
        /// <param name="LastImgFilePath">旧图片文件路径</param>
        /// <param name="IsMakeSmalllImg">是否生成小图片（默认宽度72，高度：95）</param>
        /// <param name="width">小图片宽度</param>
        /// <param name="height">小图片高度</param>
        /// <param name="mode">生成缩略图的方式(HW: 指定高宽缩放（可能变形）, W: 指定宽,高按比例, H: 指定高,宽按比例, Cut: 指定高宽裁减（不变形）)</param>
        /// <returns></returns>
        public static string SaveFile(FileUpload FU, string LastImgFilePath, bool IsMakeSmalllImg, int width, int height, string mode)
        {
            return SaveFile(FU, LastImgFilePath, IsMakeSmalllImg, width, height, mode, false);
        }

        /// <summary>
        /// 保存图片（根据宽度和高度生成对应的小图片）
        /// </summary>
        /// <param name="FU">上传控件</param>
        /// <param name="LastImgFilePath">旧图片文件路径</param>
        /// <param name="IsMakeSmalllImg">是否生成小图片（默认宽度72，高度：95）</param>
        /// <param name="width">小图片宽度</param>
        /// <param name="height">小图片高度</param>
        /// <param name="mode">生成缩略图的方式(HW: 指定高宽缩放（可能变形）, W: 指定宽,高按比例, H: 指定高,宽按比例, Cut: 指定高宽裁减（不变形）)</param>
        /// <param name="IsWaterMark">水印</param>
        /// <returns></returns>
        public static string SaveFile(FileUpload FU, string LastImgFilePath, bool IsMakeSmalllImg, int width, int height, string mode, bool IsWaterMark)
        {
            string lastfilename = FU.FileName;
            if (lastfilename == "")
                return "";
            //文件名与路径
            DateTime time = DateTime.Now;
            string newfilename = time.ToString("yyyyMMddHHmmssfff") + lastfilename.Substring(lastfilename.LastIndexOf('.'));
            string path = HttpContext.Current.Server.MapPath("~\\uploadfile\\" + time.Year.ToString() + "\\" + time.Month.ToString() + "\\" + time.Day.ToString() + "\\");
            string watherfilename = time.ToString("yyyyMMddHHmmssfff") + "_wather" + lastfilename.Substring(lastfilename.LastIndexOf('.'));
            //创建文件夹
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
            //删除文件
            if (LastImgFilePath != "")
            {
                string lastimagefilepath_wather = LastImgFilePath.Replace("_wather", "");
                if (File.Exists(HttpContext.Current.Server.MapPath("~" + LastImgFilePath)))
                    File.Delete(HttpContext.Current.Server.MapPath("~" + LastImgFilePath));
                if (File.Exists(HttpContext.Current.Server.MapPath("~" + lastimagefilepath_wather)))
                    File.Delete(HttpContext.Current.Server.MapPath("~" + lastimagefilepath_wather));
                if (File.Exists(HttpContext.Current.Server.MapPath("~\\defaultuploadfile" + LastImgFilePath)))
                    File.Delete(HttpContext.Current.Server.MapPath("~\\defaultuploadfile" + LastImgFilePath));
            }
            //上传文件
            string picpath = path + newfilename;
            FU.SaveAs(picpath);

            if (IsMakeSmalllImg)
            {
                //生成小图片用于首页显示
                string originalImagePath = HttpContext.Current.Server.MapPath("~\\uploadfile\\" + time.Year.ToString() + "\\" + time.Month.ToString() + "\\" + time.Day.ToString() + "\\" + newfilename); ;
                string thumbnailPath = "~\\defaultuploadfile\\uploadfile\\" + time.Year.ToString() + "\\" + time.Month.ToString() + "\\" + time.Day.ToString() + "\\";
                string filename = newfilename;
                MakeThumbnail(originalImagePath, thumbnailPath, filename, width, height, mode);
                //
            }

            //水印图片路径
            if (IsWaterMark)
            {
                string waterpicpath = path + watherfilename;
                System.Drawing.Image image = System.Drawing.Image.FromFile(picpath);
                WaterMark watermark = new WaterMark(PublicConst.WaterMarkTitle, "宋体", false,  Color.FromArgb(99,99,99), image.Width - PublicConst.WaterMarkWidth, image.Height - PublicConst.WaterMarkHeight);
                watermark.Mark(image).Save(waterpicpath);
            }

            return ("\\uploadfile\\" + time.Year.ToString() + "\\" + time.Month.ToString() + "\\" + time.Day.ToString() + "\\" + watherfilename).Replace("\\", "/");
        }

        /// <summary>
        /// 生成缩略图
        /// </summary>
        /// <param name="originalImagePath">源图路径（物理路径）</param>
        /// <param name="thumbnailPath">缩略图路径（物理路径）</param>
        /// <param name="filename">文件名</param>
        /// <param name="width">缩略图宽度</param>
        /// <param name="height">缩略图高度</param>
        /// <param name="mode">生成缩略图的方式</param>   
        public static void MakeThumbnail(string originalImagePath, string thumbnailPath, string filename, int width, int height, string mode)
        {
            System.Drawing.Image originalImage = System.Drawing.Image.FromFile(originalImagePath);

            int towidth = width;
            int toheight = height;
            int level = 75; //缩略图的质量 1-100的范围
            int x = 0;
            int y = 0;
            int ow = originalImage.Width;
            int oh = originalImage.Height;


            switch (mode)
            {
                case "HW"://指定高宽缩放（可能变形）               
                    break;
                case "W"://指定宽，高按比例                   
                    toheight = originalImage.Height * width / originalImage.Width;
                    break;
                case "H"://指定高，宽按比例
                    towidth = originalImage.Width * height / originalImage.Height;
                    break;
                case "Cut"://指定高宽裁减（不变形）   

                    //if ((double)originalImage.Width / (double)originalImage.Height > (double)towidth / (double)toheight)
                    //{
                    //    oh = originalImage.Height;
                    //    ow = originalImage.Height * towidth / toheight;
                    //    y = 0;
                    //    x = (originalImage.Width - ow) / 2;
                    //}
                    //else
                    //{
                    //    ow = originalImage.Width;
                    //    oh = originalImage.Width * height / towidth;
                    //    x = 0;
                    //    y = (originalImage.Height - oh) / 2;
                    //}

                    if (originalImage.Width >= originalImage.Height)
                    {
                        toheight = height * originalImage.Height / originalImage.Width;

                    }
                    else
                    {
                        towidth = width * originalImage.Width / originalImage.Height;
                    }
                    break;
                default:
                    break;
            }

            //新建一个bmp图片
            System.Drawing.Image bitmap = new System.Drawing.Bitmap(towidth, toheight);

            //新建一个画板
            Graphics g = System.Drawing.Graphics.FromImage(bitmap);

            //设置高质量插值法
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;

            //设置高质量,低速度呈现平滑程度
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

            //清空画布并以透明背景色填充
            g.Clear(Color.Transparent);

            //在指定位置并且按指定大小绘制原图片的指定部分
            g.DrawImage(originalImage, new Rectangle(0, 0, towidth, toheight),
                new Rectangle(x, y, ow, oh),
                GraphicsUnit.Pixel);

            try
            {
                //文件夹创建
                if (!Directory.Exists(HttpContext.Current.Server.MapPath(thumbnailPath)))
                    Directory.CreateDirectory(HttpContext.Current.Server.MapPath(thumbnailPath));

                string samllname = thumbnailPath + filename;
                samllname = HttpContext.Current.Server.MapPath(samllname);
                //处理JPG质量的函数
                ImageCodecInfo[] codecs = ImageCodecInfo.GetImageEncoders();
                ImageCodecInfo ici = null;
                foreach (ImageCodecInfo codec in codecs)
                {
                    if (codec.MimeType == "image/jpeg")
                    { ici = codec; }
                }
                EncoderParameters ep = new EncoderParameters();
                ep.Param[0] = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, (long)level);
                //以jpg格式保存缩略图
                bitmap.Save(samllname, ici, ep);
            }
            catch (System.Exception e)
            {
                throw e;
            }
            finally
            {

                originalImage.Dispose();
                bitmap.Dispose();
                g.Dispose();


            }

        }
    }
}
