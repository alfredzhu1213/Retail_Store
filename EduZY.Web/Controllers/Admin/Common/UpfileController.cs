
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.Web;
using System.Drawing;
using System.IO;
using EduZY.Web.Controllers.Admin.Common;
using Entity;
using Common;

namespace XXJPT.Views.OnlineInquiry.Controllers
{
    public class UpfileController:Controller
    {
        #region 图片截取功能
        /// <summary>
        /// 图片传递参数
        /// </summary>
        public class PicParameters
        {
            /// <summary>
            /// 图片宽度
            /// </summary>
            public string width { get; set; }
            /// <summary>
            /// 图片高度
            /// </summary>
            public string height { get; set; }
            /// <summary>
            /// 图片宽高比例
            /// </summary>
            public string aspectRatio { get; set; }
            /// <summary>
            /// 图片截取后的地址放在这个ID下
            /// </summary>
            public string element { get; set; }
            /// <summary>
            /// 图片截取后的地址放在<img id=“imgelement”></img>下
            /// </summary>
            public string imgelement { get; set; }

            public int _iswatermark = 0;
            /// <summary>
            /// 是否加水印
            /// </summary>
            public int iswatermark { get { return _iswatermark; } set { _iswatermark = value; } }
        }
    


        [HttpPost]
        public ActionResult GetImgUrl(int startW, int startH, int startX, int startY, int width, int height, string imgUrl, float rate, bool hasWarter)
        {
           

            JsonModel result = new JsonModel();
            string finalSavedPath = imgUrl.Replace("UpTemp", "UpFileList");
            string finalPath = HttpContext.Server.MapPath(imgUrl);// 原路径
            string finalSaved = HttpContext.Server.MapPath(finalSavedPath); //保存路径
            string finalPathDir = finalSaved.Substring(0, finalSaved.LastIndexOf("\\"));
            string savedUrl = finalSavedPath.Substring(0, finalSavedPath.LastIndexOf("/") + 1);

            /*获取原图*/
            Image rootImage = System.Drawing.Image.FromFile(finalPath);

            /*生成缩放图*/
            Image copyImage = ImgHandler.MakeThumbnail(rootImage, (int)((float)rootImage.Width * rate), (int)((float)rootImage.Height * rate));

            System.Drawing.Image canvas = new System.Drawing.Bitmap(startW, startH);
            Graphics g = Graphics.FromImage(canvas);

            /*合并画面与绽放图*/
            g.DrawImage(copyImage, new Rectangle((canvas.Width - copyImage.Width) / 2, (canvas.Height - copyImage.Height) / 2, copyImage.Width, copyImage.Height), 0, 0, copyImage.Width, copyImage.Height, GraphicsUnit.Pixel);
            g.Dispose();

            /*将画面进行截取*/
            string path = ImgHandler.SaveCutPic(canvas, finalPathDir, 0, 0, width, height, startX, startY, startW, startH);

            if (!string.IsNullOrEmpty(path))
            {
                result.status = 1;
                result.msg = savedUrl + path;
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 其他图片获取
        /// </summary>
        /// <param name="fileData"></param>
        /// <param name="directory"></param>
        /// <param name="fixWidth"></param>
        /// <param name="fixHeight"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult GetPic(HttpPostedFileBase fileData, string directory, int fixHeight, int fixWidth)
        {
            if (!System.IO.Directory.Exists(Server.MapPath(directory)))
            {
                System.IO.Directory.CreateDirectory(Server.MapPath(directory));
            }

            //保存源图片
            var imgUrl = directory + fileData.FileName;
            fileData.SaveAs(Server.MapPath(imgUrl));

            //取出源图片的高宽
            System.Drawing.Image image = Image.FromStream(fileData.InputStream);
            var height = image.Height;
            var width = image.Width;
            float rate = 1;

            //与配置高宽对比
            if (height > fixHeight || width > fixWidth)//如果源图片的高或宽超出固定高或宽,或者都超出
            {
                //取出图片比例
                float base_rate = (float)height / (float)width;      //源图片高宽比例
                float fix_rate = (float)fixHeight / (float)fixWidth; //固定高宽比例

                if (base_rate > fix_rate)//原图片以高度的比例 作为缩小比例
                {
                    rate = (float)fixHeight / (float)image.Height;

                    height = fixHeight;
                    width = (int)(image.Width * rate);

                }
                else //原图片以宽度的比例 作为缩小比例
                {
                    rate = (float)fixWidth / (float)image.Width;

                    width = fixWidth;
                    height = (int)(image.Height * rate);
                }
            }

            return GetImgUrl(width, height, 0, 0, width, height, imgUrl, rate, false);
        }

    
        #endregion
    }
}
