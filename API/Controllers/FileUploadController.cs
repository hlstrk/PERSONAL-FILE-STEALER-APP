using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using System.Net.Http.Headers;
using System.Text;

namespace thief_api.Controllers
{

    [ApiController]


    public class FileUploadController : ControllerBase
    {
        

       [HttpPost("uploadimage")] //Gönderilecek api yolunu belirle
       public async Task<IActionResult> UploadImage(IFormFile file)  //API Fonkisyonu  IFormFile==Gönderilecek şeyin türünü belirle(Dosya)
    {
           
            //Hata kontrolü try catch
                try
                {
                var sunucu_ana_dizini = Directory.GetCurrentDirectory(); //API'nin çalıştığı sunucunun ana dizinini al ve değişkene aktar.
                var icerik_dizini = "wwwroot";                 //ASP.NET CORE'da sunucuya dosya kaydederken,dosya her zaman wwwroot dizinine kaydedilir.
                var dosya_adi = file.FileName;                           //Gönderilen dosyanın adını değişkene aktar. 
                var dosyanin_olusturalacagi_yer = Path.Combine(sunucu_ana_dizini, icerik_dizini, dosya_adi); 
                //Sunucunun ana dizinini, wwwroot klasörünü, ve dosya adının yolunbu birleştir.

                var bos_dosya = new FileStream(dosyanin_olusturalacagi_yer, FileMode.Create); //Belirtilen dizinde dosya oluştur.
                await file.CopyToAsync(bos_dosya); //Oluşturulan dosyanın içine gönderilen dosyayı yaz.
                
                }
            //hatayı yakala
                catch (Exception e)
                {
                    return BadRequest(e.Message); //Hata var ise hatayı 400 hata kodu ile  dönder. 
                }
                return Ok();//İşlem başarılı ise 200 durum kodunu dönder.


    }





       



    }
}


