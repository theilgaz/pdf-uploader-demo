using PdfUploader.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PdfUploader.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        public ActionResult Index()
        {
            return View("Index",new MessageModel());
        }

        public ActionResult Upload()
        {
            return View();
        }

        public ActionResult UploadFile(FileModel model)
        {
            // Model durumunda bir problem yoksa (dosya seçilmişse)
            if (ModelState.IsValid)
            {
                // zaman damgası oluşturarak dosyanın yüklenme zamanını işaretliyoruz.
                string timestamp = DateTime.Now.ToString("yyyyMMddHHmmss");
                // yüklenecek dosya adını maskeliyoruz. (örn: 20191108001011_DosyaAdi.pdf)
                string fileName = timestamp + "_" + model.PdfFile.FileName;
                // dosyanın kaydedileceği dizini belirtiyoruz.
                string targetDirectory = "~/Content/pdf"; 
                 
                // eğer dizin yoksa oluşturur. dizin varsa bir şey yapmaz.
                Directory.CreateDirectory(Server.MapPath(targetDirectory)); // bu satır silinirse ve dizin yoksa exception'a düşer.
                
                // dizin + dosya adı kombinasyonu ile kayıt yapılacak noktayı işaretliyoruz.
                string path = Path.Combine(Server.MapPath(targetDirectory), fileName);

                // dosyayı sunucudaki dizine belirlenen isim ile kaydediyoruz.
                model.PdfFile.SaveAs(path);

                return View("Index", new MessageModel() { Message = "Dosya "+ path + " dizininde kaydedildi." });
            }
            return View("Index", new MessageModel() { Message = "Dosya istenilen biçimde değil. Lütfen doğru biçimde yükleyin!" });
            
        }

    }
}