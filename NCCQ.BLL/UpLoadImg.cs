using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.IO;

namespace NCCQ.BLL
{
    public class UpLoadImg
    {
        private string longFileName, fileType, fileName, fileExtension;//缩略属性

        public string uploadpeopleimg(string tW, string tH)
        {
            try
            {
                string strFileName = DateTime.Now.ToString("yyyyMMddhhmmss");
                string imgMaxPath = string.Empty;
                string imgMinPath = string.Empty;
                int pcount = HttpContext.Current.Request.Files.Count;
                if (pcount > 0)
                {
                    HttpPostedFile hf = HttpContext.Current.Request.Files[0];//获取上传图片对象
                    if (hf.ContentLength > 0)
                    {
                        int fileSize = 0;
                        fileSize = hf.ContentLength;
                        if (fileSize < 2097152)
                        {
                            longFileName = hf.FileName;
                            fileName = Path.GetFileName(longFileName);
                            fileExtension = Path.GetExtension(longFileName);
                            strFileName = strFileName + fileExtension;
                            fileType = hf.ContentType;
                            if (!Directory.Exists(HttpContext.Current.Server.MapPath("~/newsImg/max/")))
                            {
                                Directory.CreateDirectory(HttpContext.Current.Server.MapPath("~/newsImg/max/"));
                            }
                            if (!Directory.Exists(HttpContext.Current.Server.MapPath("~/newsImg/min/")))
                            {
                                Directory.CreateDirectory(HttpContext.Current.Server.MapPath("~/newsImg/min/"));
                            }
                            imgMaxPath = "~/newsImg/max/" + strFileName;
                            imgMinPath = "~/newsImg/min/" + strFileName;
                            byte[] byts = getByte(hf);
                            string flag = SavePicOfSuoLue(byts, imgMinPath, imgMaxPath, Int32.Parse(tH), Int32.Parse(tW));
                        }
                        return strFileName;
                    }
                    else
                    {
                        return string.Empty;
                    }
                }
                else
                {
                    return string.Empty;
                }
            }
            catch 
            {
                return string.Empty;
            }
        }

        public static byte[] getByte(HttpPostedFile FileUpload1)
        {
            //获得转化后的字节数组
            //得到用户要上传的文件名
            string strFilePathName = FileUpload1.FileName;
            string strFileName = Path.GetFileName(strFilePathName);
            int FileLength = FileUpload1.ContentLength;
            //上传文件
            Byte[] FileByteArray = new Byte[FileLength]; //图象文件临时储存Byte数组
            Stream StreamObject = FileUpload1.InputStream; //建立数据流对像
            //读取图象文件数据，FileByteArray为数据储存体，0为数据指针位置、FileLnegth为数据长度
            StreamObject.Read(FileByteArray, 0, FileLength);
            return FileByteArray;
        }
        public string SavePicOfSuoLue(byte[] fs, string savethumbnailpath, string saveoriginalpath, int th, int tw)
        {
            try
            {
                string info = SavePic(fs, saveoriginalpath);
                if ("true".Equals(info))
                {

                    if (!"".Equals(savethumbnailpath) && !"".Equals(saveoriginalpath))
                    {
                        MakePic(HttpContext.Current.Server.MapPath(saveoriginalpath), HttpContext.Current.Server.MapPath(savethumbnailpath), tw, th);
                    }
                    return "true";//成功
                }
                else
                {
                    return "false";//失败
                }
            }
            catch
            {
                throw;
            }
        }
        public string SavePic(byte[] fs, string filepath)
        {
            try
            {
                ///定义并实例化一个内存流，以存放提交上来的字节数组。
                MemoryStream m = new MemoryStream(fs);
                ///定义实际文件对象，保存上载的文件。
                FileStream f = new FileStream(HttpContext.Current.Server.MapPath(filepath), FileMode.Create);
                ///把内内存里的数据写入物理文件
                m.WriteTo(f);
                m.Close();
                f.Close();
                f = null;
                m = null;
                return "true";
            }
            catch
            {
                throw;
            }
        }
        public static int MakePic(string sourceImg, string toPath, int pW, int pH)
        {
            System.Drawing.Image originalImage = null;
            System.Drawing.Image bitmap = null;
            System.Drawing.Graphics g = null;
            try
            {
                originalImage = System.Drawing.Image.FromFile(sourceImg);
                int oW = originalImage.Width;//原始图片宽
                int oH = originalImage.Height;//原始图片高
                int tW = oW;//最终显示到页面宽
                int tH = oH;//最终显示到页面高
                if (oW > pW)//如果原始宽度大于固定宽度
                {
                    tW = pW;//最终的宽度等于固定的宽度
                    tH = pW * oH / oW;//最终的高度等于固定宽度乘以原始高度除以原始宽度
                    if (tH > pH)
                    {
                        tH = pH;
                        tW = pH * oW / oH;//最终的宽度等于固定高度乘以原始宽度除以原始高度
                    }
                }
                else if (oW < pW)//如果原始宽度小于固定宽度
                {
                    tW = oW;
                    if (oH > pH)
                    {
                        tH = pH;
                        tW = pH * oW / oH;//最终的宽度等于固定高度乘以原始宽度除以原始高度                
                    }
                }
                else//如果原始宽度等于固定宽度
                {
                    if (oH > pH)
                    {
                        tH = pH;
                        tW = pH * oW / oH;//最终的宽度等于固定高度乘以原始宽度除以原始高度                
                    }
                    if (oH < pH)
                    {
                        tH = oH;
                        tW = pH * oW / oH;//最终的宽度等于固定高度乘以原始宽度除以原始高度                
                    }
                    if (oH == pH)
                    {
                        tH = oH;
                        tW = oW;
                    }
                }
                //新建一个bmp图片 
                bitmap = new System.Drawing.Bitmap(tW, tH);
                //新建一个画板 
                g = System.Drawing.Graphics.FromImage(bitmap);
                //设置高质量插值法
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;
                //设置高质量,低速度呈现平滑程度  
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;               
                g.DrawImage(originalImage, new System.Drawing.Rectangle(0, 0, tW, tH),
                new System.Drawing.Rectangle(0, 0, oW, oH),
                System.Drawing.GraphicsUnit.Pixel);
                //以jpg格式保存缩略图 
                bitmap.Save(toPath, System.Drawing.Imaging.ImageFormat.Jpeg);
                return 1;
            }
            catch
            {
                throw;
            }
            finally
            {
                if (originalImage != null)
                {
                    originalImage.Dispose();
                }
                if (bitmap != null)
                {
                    bitmap.Dispose();
                }
                if (g != null)
                {
                    g.Dispose();
                }
            }
        }
    }
}
