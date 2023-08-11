using PersonelTakipWebSite.Models.DataContext;
using PersonelTakipWebSite.Models.Personel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PersonelTakipWebSite.Controllers
{
    public class GirisEkraniController : Controller
    {
        private ProjeDBContext db = new ProjeDBContext();   //Veritabanı ile bağlantı kuruldu.
        // GET: GirisEkrani
        public ActionResult Login()
        {
            
            return View();
        }
        [HttpPost]
        public ActionResult Dogrulama(PersonelBilgileri acc)
        {
            if (ModelState.IsValid)
            {
                // Kullanıcı adı ve şifre doğrulama işlemleri

                bool isValidUser = ValidateUser(acc.Eposta, acc.Sifre);

                if (isValidUser)
                {
                    // Doğrulama başarılı ise, kullanıcıyı ana sayfaya yönlendirir.
                    return RedirectToAction("Index", "GenelBakis");
                }

                // Doğrulama başarısız ise, hata mesajını göster.
                ModelState.AddModelError("", "Kullanıcı adı veya şifre hatalı!");
            }

            return View("Login"); 
        }

        private bool ValidateUser(string eposta, string sifre)
        {
            // Kullanıcı adı ve şifre doğrulama işlemleri

            // Örnek olarak, veritabanında kullanıcı bilgilerini kontrol edelim.
            // Bu örnekte, Users tablosundan kullanıcıyı sorgulayarak doğrulama yapılabilir.
            
                var kullanici = db.PersonelBilgileris.Where(u => u.Eposta == eposta && u.Sifre == sifre);

                if (kullanici != null)
                {
                    // Kullanıcı doğrulandı
                    return true;
                }
            
            return false;
        }
    }
}