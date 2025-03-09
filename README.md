# Image Upload & Preview (ASP.NET Core MVC)

Bu proje, **ASP.NET Core MVC** kullanarak **görsel yükleme ve önizleme** işlemini gerçekleştiren basit bir uygulamadır.
Kullanıcı, bir resim seçip yüklediğinde, resim **wwwroot/uploads** klasörüne kaydedilir ve yüklenen resim ekranda önizlenir.

## 📌 Özellikler
- Kullanıcı **görsel seçebilir** ve yükleyebilir.
- Yüklenen görsel **wwwroot/uploads** klasörüne kaydedilir.
- Yüklenen resim **anlık olarak önizlenir**.
- **Model-View-Controller (MVC) yapısına** uygun geliştirilmiştir.

## 📂 Proje Yapısı
📦 ImageUploadApp
┣ 📂 wwwroot/uploads 
# Yüklenen görsellerin saklandığı klasör 
┣ 📂 Controllers ┃ 
┗ 📜 HomeController.cs 
# Resim yükleme işlemini gerçekleştiren controller 
┣ 📂 Views 
┃ 
┗ 📂 Home ┃
┃ 
┣ 📜 Index.cshtml
# Ana sayfa (resim yükleme formu) 
┣ 📜 Program.cs # ASP.NET Core uygulama yapılandırması
┣ 📜 appsettings.json 
# Uygulama ayarları 
┗ 📜 README.md 

# Proje hakkında bilgi
## 🚀 Kurulum ve Çalıştırma
1. **Projeyi klonlayın:**
   ```sh
   git clone https://github.com/kullanici-adi/image-upload-mvc.git
   cd image-upload-mvc
2.Gerekli bağımlılıkları yükleyin ve çalıştırın:
dotnet restore
dotnet run

Uygulamayı açın:
Tarayıcınızda https://localhost:XXXX/ adresine gidin.

🖼 Kullanım
"Görsel Seç" butonuna tıklayın.
Bir resim seçin ve yüklemek için "Yükle" butonuna basın.
Resim başarıyla yüklendiğinde, ekranda önizlemesi görünecektir.

📜 Lisans
MIT Lisansı altında sunulmuştur. Dilediğiniz gibi kullanabilirsiniz! 😊
