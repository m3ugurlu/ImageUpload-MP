using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Threading.Tasks;

namespace ImageUploadDemo.Controllers
{
    public class ImageUploadController : Controller
    {
        private readonly string _uploadPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads");

        // 📌 [GET] Upload Sayfası
        public IActionResult Index()
        {
            return View();
        }

        // 📌 [POST] Dosya Yükleme İşlemi
        [HttpPost]
        public async Task<IActionResult> Upload(IFormFile file)
        {
            // **1. Dosya Kontrolü**
            if (file == null || file.Length == 0)
            {
                ViewBag.Message = "⚠️ Lütfen bir dosya seçin!";
                return View("Index");
            }

            try
            {
                // **2. Klasör Yoksa Oluştur**
                if (!Directory.Exists(_uploadPath))
                {
                    Directory.CreateDirectory(_uploadPath);
                }

                // **3. Dosyanın Kaydedileceği Yolu Belirle**
                string filePath = Path.Combine(_uploadPath, file.FileName);

                // **4. Dosyayı Kaydet**
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

                // **5. Başarılı Mesajını Dön & Yüklenen Dosyanın Yolu**
                ViewBag.Message = "✅ Dosya başarıyla yüklendi: " + file.FileName;
                ViewBag.ImagePath = "/uploads/" + file.FileName; // Tarayıcıda gösterme için

                return View("Index");
            }
            catch (Exception ex)
            {
                // **6. Hata Durumunda Kullanıcıya Bilgi Ver**
                ViewBag.Message = "❌ Hata oluştu: " + ex.Message;
                return View("Index");
            }
        }
    }
}
