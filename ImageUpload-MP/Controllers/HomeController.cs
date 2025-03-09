using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace ImageUpload_MP.Controllers
{
    public class HomeController : Controller
    {
        private readonly string _uploadPath = "wwwroot/uploads"; // Klasör yolu

        public IActionResult Index()
        {
            return View();
        }

        // 📌 Görsel Yükleme Metodu
        [HttpPost]
        public async Task<IActionResult> Upload(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return Json(new { success = false, message = "Lütfen bir dosya seçin!" });
            }

            try
            {
                // 📌 Dosya adı benzersiz olsun diye GUID ekliyoruz
                var fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                var filePath = Path.Combine(_uploadPath, fileName);

                // 📌 Klasör yoksa oluştur
                if (!Directory.Exists(_uploadPath))
                {
                    Directory.CreateDirectory(_uploadPath);
                }

                // 📌 Dosyayı sunucuya kaydet
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

                // 📌 Yüklenen dosyanın URL'sini geri döndür
                var fileUrl = $"/uploads/{fileName}";
                return Json(new { success = true, url = fileUrl });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "Dosya yüklenirken hata oluştu: " + ex.Message });
            }
        }
    }
}
