using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.IO;

namespace NCCQ.BLL
{
    public  class UpLoad
    {
        public  string UpLoadFile(string url)
        {
            string strFileName = DateTime.Now.ToString("yyyyMMddhhmmss");
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
                       string fileType= Path.GetExtension(hf.FileName);
                        if (!Directory.Exists(HttpContext.Current.Server.MapPath(url)))
                        {
                            Directory.CreateDirectory(HttpContext.Current.Server.MapPath(url));
                        }
                        string path = HttpContext.Current.Server.MapPath(url + strFileName + fileType);
                        hf.SaveAs(path);
                        return strFileName + fileType;
                    }
                    return string.Empty;
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
    }
}
