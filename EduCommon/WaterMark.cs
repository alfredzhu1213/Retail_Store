using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.IO;
using System.Web;

namespace Common
{
    /// <summary>
    /// 图片水印
    /// </summary>
    public class WaterMark
    {
        private bool _textMark = false;
        private bool _imgMark = false;
        private string _text = "";
        private string _imgPath = "";
        private int _markX = 0;
        private int _markY = 0;
        private float _transparency = 1;
        private string _fontFamily = "宋体";
        private Color _textColor = Color.Black;
        private bool _textbold = false;
        int[] sizes = new int[] { 48, 32, 16, 8, 6, 4 };

        /// <summary>
        ///　初始化一个只添加文字水印得实例
        /// </summary>
        /// <param name="text">水印文字</param>
        /// <param name="fontFamily">文字字体</param>
        /// <param name="bold">是否粗体</param>
        /// <param name="color">字体颜色</param>
        /// <param name="markX">标记位置横坐标</param>
        /// <param name="markY">标记位置纵坐标</param>
        public WaterMark(string text, string fontFamily, bool bold, Color color, int markX, int markY)
        {
            this._imgMark = false;
            this._textMark = true;
            this._text = text;
            this._fontFamily = fontFamily;
            this._textbold = bold;
            this._textColor = color;
            this._markX = markX;
            this._markY = markY;
        }

        /// <summary>
        /// 实例化一个只添加图片水印得实例
        /// </summary>
        /// <param name="imagePath">水印图片路径</param>
        /// <param name="tranparence">透明度</param>
        /// <param name="markX">标记位置横坐标</param>
        /// <param name="markY">标记位置纵坐标</param>
        public WaterMark(string imagePath, float tranparence, int markX, int markY)
        {
            this._textMark = false;
            this._imgMark = true;
            this._imgPath = imagePath;
            this._markX = markX;
            this._markY = MarkY;
            this._transparency = tranparence;
        }

        /// <summary>
        /// 是否添加文字水印
        /// </summary>
        public bool TextMark
        {
            get { return _textMark; }
            set { _textMark = value; }
        }

        /// <summary>
        /// 是否添加图片水印
        /// </summary>
        public bool ImageMark
        {
            get { return _imgMark; }
            set { _imgMark = value; }
        }

        /// <summary>
        /// 文字水印得内容
        /// </summary>
        public string Text
        {
            get { return _text; }
            set { _text = value; }
        }

        /// <summary>
        /// 图片水印得图片地址
        /// </summary>
        public string ImagePath
        {
            get { return _imgPath; }
            set { _imgPath = value; }
        }

        /// <summary>
        /// 添加水印位置得横坐标
        /// </summary>
        public int MarkX
        {
            get { return _markX; }
            set { _markX = value; }
        }

        /// <summary>
        /// 添加水印位置得纵坐标
        /// </summary>
        public int MarkY
        {
            get { return _markY; }
            set { _markY = value; }
        }

        /// <summary>
        /// 水印得透明度
        /// </summary>
        public float Transparency
        {
            get
            {
                if (_transparency > 1.0f)
                {
                    _transparency = 1.0f;
                }
                return _transparency;
            }
            set { _transparency = value; }
        }

        /// <summary>
        /// 水印文字得颜色
        /// </summary>
        public Color TextColor
        {
            get { return _textColor; }
            set { _textColor = value; }
        }

        /// <summary>
        /// 水印文字得字体
        /// </summary>
        public string TextFontFamily
        {
            get { return _fontFamily; }
            set { _fontFamily = value; }
        }

        /// <summary>
        /// 水印文字是否加粗
        /// </summary>
        public bool Bold
        {
            get { return _textbold; }
            set { _textbold = value; }
        }

        /// <summary>
        /// 添加水印，此方法适用于gif格式得图片
        /// </summary>
        /// <param name="image">需要添加水印得图片</param>
        /// <returns>添加水印之后得图片</returns>
        public Image Mark(Image img)
        {
            try
            {
                //添加文字水印
                if (this.TextMark)
                {
                    //根据源图片生成新的Bitmap对象作为作图区，为了给gif图片添加水印，才有此周折
                    Bitmap newBitmap = new Bitmap(img.Width, img.Height, PixelFormat.Format24bppRgb);
                    //设置新建位图得分辨率
                    newBitmap.SetResolution(img.HorizontalResolution, img.VerticalResolution);
                    //创建Graphics对象，以对该位图进行操作
                    Graphics g = Graphics.FromImage(newBitmap);
                    //消除锯齿
                    g.SmoothingMode = SmoothingMode.AntiAlias;
                    //将原图拷贝到作图区
                    g.DrawImage(img, new Rectangle(0, 0, img.Width, img.Height), 0, 0, img.Width, img.Height, GraphicsUnit.Pixel);
                    //声明字体对象
                    Font cFont = null;
                    ////用来测试水印文本长度得尺子
                    //SizeF size = new SizeF();
                    ////探测出一个适合图片大小得字体大小，以适应水印文字大小得自适应
                    //for (int i = 0; i < 6; i++)
                    //{
                    //    //创建一个字体对象
                    //    cFont = new Font(this.TextFontFamily, sizes[i]);
                    //    //是否加粗
                    //    if (!this.Bold)
                    //    {
                    //        cFont = new Font(this.TextFontFamily, sizes[i], FontStyle.Regular);
                    //    }
                    //    else
                    //    {
                    //        cFont = new Font(this.TextFontFamily, sizes[i], FontStyle.Bold);
                    //    }
                    //    //测量文本大小
                    //    size = g.MeasureString(this.Text, cFont);
                    //    //匹配第一个符合要求得字体大小
                    //    if ((ushort)size.Width < (ushort)img.Width)
                    //    {
                    //        break;
                    //    }
                    //}
                    cFont = new Font(this.TextFontFamily, 12, FontStyle.Bold);
                    //创建刷子对象，准备给图片写上文字
                    Brush brush = new SolidBrush(this.TextColor);
                    //在指定得位置写上文字
                    g.DrawString(this.Text, cFont, brush, this.MarkX, this.MarkY);
                    //释放Graphics对象
                    g.Dispose();
                    //将生成得图片读入MemoryStream
                    System.IO.MemoryStream ms = new System.IO.MemoryStream();
                    newBitmap.Save(ms, ImageFormat.Jpeg);
                    //重新生成Image对象
                    img = System.Drawing.Image.FromStream(ms);
                    //返回新的Image对象
                    return img;

                }
                //添加图像水印
                if (this.ImageMark)
                {
                    //获得水印图像
                    Image markImg = Image.FromFile(this.ImagePath);
                    //创建颜色矩阵
                    float[][] ptsArray ={ 
         new float[] {1, 0, 0, 0, 0},
         new float[] {0, 1, 0, 0, 0},
          new float[] {0, 0, 1, 0, 0},
         new float[] {0, 0, 0, this.Transparency, 0}, //注意：此处为0.0f为完全透明，1.0f为完全不透明
         new float[] {0, 0, 0, 0, 1}};
                    ColorMatrix colorMatrix = new ColorMatrix(ptsArray);
                    //新建一个Image属性
                    ImageAttributes imageAttributes = new ImageAttributes();
                    //将颜色矩阵添加到属性
                    imageAttributes.SetColorMatrix(colorMatrix, ColorMatrixFlag.Default,
                     ColorAdjustType.Default);
                    //生成位图作图区
                    Bitmap newBitmap = new Bitmap(img.Width, img.Height, PixelFormat.Format24bppRgb);
                    //设置分辨率
                    newBitmap.SetResolution(img.HorizontalResolution, img.VerticalResolution);
                    //创建Graphics
                    Graphics g = Graphics.FromImage(newBitmap);
                    //消除锯齿
                    g.SmoothingMode = SmoothingMode.AntiAlias;
                    //拷贝原图到作图区
                    g.DrawImage(img, new Rectangle(0, 0, img.Width, img.Height), 0, 0, img.Width, img.Height, GraphicsUnit.Pixel);
                    //如果原图过小
                    if (markImg.Width > img.Width || markImg.Height > img.Height)
                    {
                        System.Drawing.Image.GetThumbnailImageAbort callb = null;
                        //对水印图片生成缩略图,缩小到原图得1/4
                        System.Drawing.Image new_img = markImg.GetThumbnailImage(img.Width / 4, markImg.Height * img.Width / markImg.Width, callb, new System.IntPtr());
                        //添加水印
                        g.DrawImage(new_img, new Rectangle(this.MarkX, this.MarkY, new_img.Width, new_img.Height), 0, 0, new_img.Width, new_img.Height, GraphicsUnit.Pixel, imageAttributes);
                        //释放缩略图
                        new_img.Dispose();
                        //释放Graphics
                        g.Dispose();
                        //将生成得图片读入MemoryStream
                        System.IO.MemoryStream ms = new System.IO.MemoryStream();
                        newBitmap.Save(ms, ImageFormat.Jpeg);
                        //返回新的Image对象
                        img = Image.FromStream(ms);
                        return img;
                    }
                    //原图足够大
                    else
                    {
                        //添加水印
                        g.DrawImage(markImg, new Rectangle(this.MarkX, this.MarkY, markImg.Width, markImg.Height), 0, 0, markImg.Width, markImg.Height, GraphicsUnit.Pixel, imageAttributes);
                        //释放Graphics
                        g.Dispose();
                        //将生成得图片读入MemoryStream
                        System.IO.MemoryStream ms = new System.IO.MemoryStream();
                        newBitmap.Save(ms, ImageFormat.Jpeg);
                        //返回新的Image对象
                        img = Image.FromStream(ms);
                        return img;
                    }
                }
                return img;
            }
            catch
            {
                return img;
            }
        }
    }
    public class ImgHandler
    {
        /// <summary>
        /// 剪裁头像图片
        /// </summary>
        /// <param name="pointX">X坐标</param>
        /// <param name="pointY">Y坐标</param>
        /// <param name="imgUrl">被截图图片地址</param>
        /// <param name="rlSize">截图矩形的大小</param>
        public static string CutAvatar(string imgUrl, int pointX = 0, int pointY = 0, int width = 0, int height = 0)
        {
            System.Drawing.Bitmap bitmap = null;   //按截图区域生成Bitmap
            System.Drawing.Image thumbImg = null;  //被截图 
            System.Drawing.Graphics gps = null;    //存绘图对象   
            System.Drawing.Image finalImg = null;  //最终图片
            try
            {
                int finalWidth = 180;
                int finalHeight = 180;
                if (!string.IsNullOrEmpty(imgUrl))
                {
                    bitmap = new System.Drawing.Bitmap(width, height);
                    thumbImg = System.Drawing.Image.FromFile(HttpContext.Current.Server.MapPath(imgUrl));
                    gps = System.Drawing.Graphics.FromImage(bitmap);      //读到绘图对象
                    gps.DrawImage(thumbImg, new Rectangle(0, 0, width, height), new Rectangle(pointX, pointY, width, height), GraphicsUnit.Pixel);

                    finalImg = GetThumbNailImage(bitmap, finalWidth, finalHeight);

                    //以下代码为保存图片时，设置压缩质量  
                    EncoderParameters ep = new EncoderParameters();
                    long[] qy = new long[1];
                    qy[0] = 80;//设置压缩的比例1-100  
                    EncoderParameter eParam = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, qy);
                    ep.Param[0] = eParam;

                    ImageCodecInfo[] arrayICI = ImageCodecInfo.GetImageEncoders();
                    ImageCodecInfo jpegICIinfo = null;
                    for (int x = 0; x < arrayICI.Length; x++)
                    {
                        if (arrayICI[x].FormatDescription.Equals("JPEG"))
                        {
                            jpegICIinfo = arrayICI[x];
                            break;
                        }
                    }

                    string finalUrl = imgUrl.Replace("Tmp", "MemberImg");
                    string finalPath = HttpContext.Current.Server.MapPath(finalUrl);
                    string finalPathDir = finalPath.Substring(0, finalPath.LastIndexOf("\\"));

                    if (!Directory.Exists(finalPathDir))
                    {
                        Directory.CreateDirectory(finalPathDir);
                    }

                    if (jpegICIinfo != null)
                    {
                        finalImg.Save(finalPath, jpegICIinfo, ep);
                    }
                    else
                    {
                        finalImg.Save(finalPath);
                    }

                    return finalUrl;

                }
                return "";
            }
            catch (Exception)
            {
                return "";
            }
            finally
            {
                bitmap.Dispose();
                thumbImg.Dispose();
                gps.Dispose();
                finalImg.Dispose();
                GC.Collect();
            }
        }

        ///<summary>
        /// 对给定的一个图片（Image对象）生成一个指定大小的缩略图。
        ///</summary>
        ///<param name="originalImage">原始图片</param>
        ///<param name="thumMaxWidth">缩略图的宽度</param>
        ///<param name="thumMaxHeight">缩略图的高度</param>
        ///<returns>返回缩略图的Image对象</returns>
        public static Image GetThumbNailImage(Image originalImage, int thumMaxWidth, int thumMaxHeight)
        {
            Size thumRealSize = System.Drawing.Size.Empty;
            Image newImage = originalImage;
            Graphics graphics = null;
            try
            {
                thumRealSize = GetNewSize(thumMaxWidth, thumMaxHeight, originalImage.Width, originalImage.Height);
                newImage = new System.Drawing.Bitmap(thumRealSize.Width, thumRealSize.Height);
                graphics = Graphics.FromImage(newImage);
                graphics.DrawImage(originalImage, new System.Drawing.Rectangle(0, 0, thumRealSize.Width, thumRealSize.Height), new Rectangle(0, 0, originalImage.Width, originalImage.Height), GraphicsUnit.Pixel);
            }
            catch { }
            finally
            {
                if (graphics != null)
                {
                    graphics.Dispose();
                    graphics = null;
                }
            }
            return newImage;
        }

        ///<summary>
        /// 获取一个图片按等比例缩小后的大小。
        ///</summary>
        ///<param name="maxWidth">需要缩小到的宽度</param>
        ///<param name="maxHeight">需要缩小到的高度</param>
        ///<param name="imageOriginalWidth">图片的原始宽度</param>
        ///<param name="imageOriginalHeight">图片的原始高度</param>
        ///<returns>返回图片按等比例缩小后的实际大小</returns>
        public static System.Drawing.Size GetNewSize(int maxWidth, int maxHeight, int imageOriginalWidth, int imageOriginalHeight)
        {
            double w = 0.0;
            double h = 0.0;
            double sw = Convert.ToDouble(imageOriginalWidth);
            double sh = Convert.ToDouble(imageOriginalHeight);
            double mw = Convert.ToDouble(maxWidth);
            double mh = Convert.ToDouble(maxHeight);
            if (sw < mw && sh < mh)
            {
                w = sw;
                h = sh;
            }
            else if ((sw / sh) > (mw / mh))
            {
                w = maxWidth;
                h = (w * sh) / sw;
            }
            else
            {
                h = maxHeight;
                w = (h * sw) / sh;
            }
            return new System.Drawing.Size(Convert.ToInt32(w), Convert.ToInt32(h));
        }

        /// <summary>
        /// 保存剪切后图片
        /// </summary>
        /// <param name="pPath">原图片路径</param>
        /// <param name="pSavedPath">保存剪切图片路径</param>
        /// <param name="pPartStartPointX">原图X</param>
        /// <param name="pPartStartPointY">原图Y</param>
        /// <param name="pPartWidth">剪切图宽</param>
        /// <param name="pPartHeight">剪切图高</param>
        /// <param name="pOrigStartPointX">剪切图片X</param>
        /// <param name="pOrigStartPointY">剪切图片Y</param>
        /// <param name="imageWidth">原图片宽</param>
        /// <param name="imageHeight">原图片高</param>
        /// <returns></returns>
        public static string SaveCutPic(string pPath, string pSavedPath, int pPartStartPointX, int pPartStartPointY, int pPartWidth, int pPartHeight, int pOrigStartPointX, int pOrigStartPointY, int imageWidth, int imageHeight)
        {

            if (!Directory.Exists(pSavedPath))
            {
                Directory.CreateDirectory(pSavedPath);
            }

            using (Image originalImg = Image.FromFile(pPath))
            {
                if (originalImg.Width == imageWidth && originalImg.Height == imageHeight)
                {
                    return SaveCutPic(pPath, pSavedPath, pPartStartPointX, pPartStartPointY, pPartWidth, pPartHeight,
                            pOrigStartPointX, pOrigStartPointY);

                }
                string filename = Guid.NewGuid().ToString() + ".jpg";
                string filePath = pSavedPath + "\\" + filename;

                Bitmap thumimg = MakeThumbnail(originalImg, imageWidth, imageHeight);

                Bitmap partImg = new Bitmap(pPartWidth, pPartHeight);

                Graphics graphics = Graphics.FromImage(partImg);
                Rectangle destRect = new Rectangle(new Point(pPartStartPointX, pPartStartPointY), new Size(pPartWidth, pPartHeight));//目标位置
                Rectangle origRect = new Rectangle(new Point(pOrigStartPointX, pOrigStartPointY), new Size(pPartWidth, pPartHeight));//原图位置（默认从原图中截取的图片大小等于目标图片的大小）

                ///文字水印  
                Graphics G = Graphics.FromImage(partImg);
                //Font f = new Font("Lucida Grande", 6);
                //Brush b = new SolidBrush(Color.Gray);
                G.Clear(Color.White);
                // 指定高质量的双三次插值法。执行预筛选以确保高质量的收缩。此模式可产生质量最高的转换图像。 
                G.InterpolationMode = InterpolationMode.HighQualityBicubic;
                // 指定高质量、低速度呈现。 
                G.SmoothingMode = SmoothingMode.HighQuality;

                graphics.DrawImage(thumimg, destRect, origRect, GraphicsUnit.Pixel);
                //G.DrawString("Xuanye", f, b, 0, 0);
                G.Dispose();

                originalImg.Dispose();
                if (File.Exists(filePath))
                {
                    File.SetAttributes(filePath, FileAttributes.Normal);
                    File.Delete(filePath);
                }
                partImg.Save(filePath, ImageFormat.Jpeg);

                partImg.Dispose();
                thumimg.Dispose();
                return filename;
            }
        }
        /// <summary>
        /// 生成一个画板图片
        /// </summary>
        /// <param name="fromImg">图片</param>
        /// <param name="width">宽</param>
        /// <param name="height">高</param>
        /// <returns></returns>
        public static Bitmap MakeThumbnail(Image fromImg, int width, int height)
        {
            Bitmap bmp = new Bitmap(width, height);
            int ow = fromImg.Width;
            int oh = fromImg.Height;

            //新建一个画板
            Graphics g = Graphics.FromImage(bmp);

            //设置高质量插值法
            g.InterpolationMode = InterpolationMode.High;
            //设置高质量,低速度呈现平滑程度
            g.SmoothingMode = SmoothingMode.HighQuality;
            //清空画布并以透明背景色填充
            g.Clear(Color.Transparent);

            g.DrawImage(fromImg, new Rectangle(0, 0, width, height),
                new Rectangle(0, 0, ow, oh),
                GraphicsUnit.Pixel);

            return bmp;

        }

        /// <summary>
        /// 保存剪切后图片
        /// </summary>
        /// <param name="pPath">原图片路径</param>
        /// <param name="pSavedPath">保存剪切图片路径</param>
        /// <param name="pPartStartPointX">原图X</param>
        /// <param name="pPartStartPointY">原图Y</param>
        /// <param name="pPartWidth">原图宽</param>
        /// <param name="pPartHeight">原图高</param>
        /// <returns></returns>
        public static string SaveCutPic(string pPath, string pSavedPath, int pPartStartPointX, int pPartStartPointY, int pPartWidth, int pPartHeight, int pOrigStartPointX, int pOrigStartPointY)
        {
            string filename = Guid.NewGuid().ToString() + ".jpg";
            string filePath = pSavedPath + "\\" + filename;

            using (Image originalImg = Image.FromFile(pPath))
            {
                Bitmap partImg = new Bitmap(pPartWidth, pPartHeight);
                Graphics graphics = Graphics.FromImage(partImg);
                Rectangle destRect = new Rectangle(new Point(pPartStartPointX, pPartStartPointY), new Size(pPartWidth, pPartHeight));//目标位置
                Rectangle origRect = new Rectangle(new Point(pOrigStartPointX, pOrigStartPointY), new Size(pPartWidth, pPartHeight));//原图位置（默认从原图中截取的图片大小等于目标图片的大小）

                ///注释 文字水印  
                Graphics G = Graphics.FromImage(partImg);
                //Font f = new Font("Lucida Grande", 6);
                //Brush b = new SolidBrush(Color.Gray);
                G.Clear(Color.White);
                // 指定高质量的双三次插值法。执行预筛选以确保高质量的收缩。此模式可产生质量最高的转换图像。 
                G.InterpolationMode = InterpolationMode.HighQualityBicubic;
                // 指定高质量、低速度呈现。 
                G.SmoothingMode = SmoothingMode.HighQuality;

                graphics.DrawImage(originalImg, destRect, origRect, GraphicsUnit.Pixel);
                //G.DrawString("Xuanye", f, b, 0, 0);
                G.Dispose();

                originalImg.Dispose();
                if (File.Exists(filePath))
                {
                    File.SetAttributes(filePath, FileAttributes.Normal);
                    File.Delete(filePath);
                }
                partImg.Save(filePath, ImageFormat.Jpeg);
                partImg.Dispose();
            }
            return filename;
        }

        /// <summary>
        /// 保存剪切后图片
        /// </summary>
        /// <param name="pPath">原图片路径</param>
        /// <param name="pSavedPath">保存剪切图片路径</param>
        /// <param name="pPartStartPointX">原图X</param>
        /// <param name="pPartStartPointY">原图Y</param>
        /// <param name="pPartWidth">剪切图宽</param>
        /// <param name="pPartHeight">剪切图高</param>
        /// <param name="pOrigStartPointX">剪切图片X</param>
        /// <param name="pOrigStartPointY">剪切图片Y</param>
        /// <param name="imageWidth">原图片宽</param>
        /// <param name="imageHeight">原图片高</param>
        /// <returns></returns>
        public static string SaveCutPic(Image originalImg, string pSavedPath, int pPartStartPointX, int pPartStartPointY, int pPartWidth, int pPartHeight, int pOrigStartPointX, int pOrigStartPointY, int imageWidth, int imageHeight)
        {
            if (!Directory.Exists(pSavedPath))
            {
                Directory.CreateDirectory(pSavedPath);
            }
            string filename = Guid.NewGuid().ToString() + ".jpg";
            string filePath = pSavedPath + "\\" + filename;

            Bitmap thumimg = MakeThumbnail(originalImg, imageWidth, imageHeight);

            Bitmap partImg = new Bitmap(pPartWidth, pPartHeight);

            Graphics graphics = Graphics.FromImage(partImg);
            Rectangle destRect = new Rectangle(new Point(pPartStartPointX, pPartStartPointY), new Size(pPartWidth, pPartHeight));//目标位置
            Rectangle origRect = new Rectangle(new Point(pOrigStartPointX, pOrigStartPointY), new Size(pPartWidth, pPartHeight));//原图位置（默认从原图中截取的图片大小等于目标图片的大小）

            ///文字水印  
            Graphics G = Graphics.FromImage(partImg);
            //Font f = new Font("Lucida Grande", 6);
            //Brush b = new SolidBrush(Color.Gray);
            G.Clear(Color.White);
            // 指定高质量的双三次插值法。执行预筛选以确保高质量的收缩。此模式可产生质量最高的转换图像。 
            G.InterpolationMode = InterpolationMode.HighQualityBicubic;
            // 指定高质量、低速度呈现。 
            G.SmoothingMode = SmoothingMode.HighQuality;

            graphics.DrawImage(thumimg, destRect, origRect, GraphicsUnit.Pixel);
            //G.DrawString("Xuanye", f, b, 0, 0);
            G.Dispose();

            originalImg.Dispose();
            if (File.Exists(filePath))
            {
                File.SetAttributes(filePath, FileAttributes.Normal);
                File.Delete(filePath);
            }
            partImg.Save(filePath, ImageFormat.Jpeg);

            partImg.Dispose();
            thumimg.Dispose();
            return filename;
        }



    }


}
