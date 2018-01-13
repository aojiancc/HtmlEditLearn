using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace HtmlEditLearn.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {

            //string str = "jhxmjggyoi689987563xxssfg";
            //string str22 = "jhxmjggyoi689989879xxssfg";

            ////字符串转化成字符串数组
            //char[] chars = str.ToCharArray();
            //char[] chars2 = str22.ToCharArray();
            //int count = 0;
            //for (int i = 0; i < chars.Count(); i++)
            //{
            //    if (count == 6) //超过五位匹配不成功
            //    {
            //        break;
            //    }

            //    if (chars[i] != chars2[i]) 
            //    {
            //        count++;
            //    }
            //}
            //Response.Write(count);




            return View();
        }


        public ActionResult UploadImage()
        {
            var action = Request["action"];
            var json = "";
            if (action == "config")
            {
                json = @"{""imageActionName"":""UploadImage"",""imageFieldName"": ""upfile"",""imageCompressEnable"":""true"",""imageCompressBorder"": 1600,""imageInsertAlign"": ""none"",""imageUrlPrefix"": """",""imageAllowFiles"": ["".png"", "".jpg"", "".jpeg"", "".gif"", "".bmp""]}";
            }
            else
            {
                var file = Request.Files["upfile"];
                //var relativePath = AppConfig.GetAppSettingsValue("CustomizeProductMaskImageRelativePath");

                //var newFileName = string.Concat(DateTime.Now.ToString("yy-MM-dd"), Path.GetExtension(file.FileName));
                //var savePath = Server.MapPath(relativePath);

                //if (!Directory.Exists(savePath))
                //{
                //    Directory.CreateDirectory(savePath);
                //}

                //relativePath = Path.Combine(relativePath, newFileName);

                //// 合成目标文件路径
                //var srcFileName = FilePath.CombinePath(savePath, newFileName);

                string srcFileName = Server.MapPath("~/arcimg/" + file.FileName);

                // 保存图片
                file.SaveAs(srcFileName);

                var tvcMallImageUrl = "/arcimg/" + file.FileName;

                // 上传图片到外网服务器
                //tvcMallImageUrl = "";

                json = json + "{\"url\":\"" + tvcMallImageUrl + "\",";
                json = json + "\"state\":\"SUCCESS\"}";
            }

            return new ContentResult { ContentEncoding = Encoding.UTF8, ContentType = "application/json", Content = json };
        }
        


        [ValidateInput(false)]
        public ActionResult Show(string content)
        {
            ViewBag.content = content;
            return View();
        }



    }
}
