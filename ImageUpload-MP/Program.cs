var builder = WebApplication.CreateBuilder(args);

// 📌 **Statik Dosya Kullanımını Aç**
builder.Services.AddControllersWithViews();

var app = builder.Build();

// 📌 **Hata Yönetimi (Geliştirme ve Prod Ortamları İçin)**
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();

// 📌 **Görsellerin ve Statik Dosyaların Kullanılmasını Sağla**
app.UseStaticFiles();

app.UseRouting();

// 📌 **Kimlik Doğrulama & Yetkilendirme (Gereksinime Göre Kullan)**
app.UseAuthentication(); // Eğer login sistemi kullanıyorsan bunu aç
app.UseAuthorization();

// 📌 **Varsayılan Rota Tanımlaması**
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// 📌 **Uygulamayı Çalıştır**
app.Run();
