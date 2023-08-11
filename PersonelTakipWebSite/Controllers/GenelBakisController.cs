using PersonelTakipWebSite.Models.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PersonelTakipWebSite.Controllers
{
    public class GenelBakisController : Controller
    {

        private ProjeDBContext db = new ProjeDBContext();   //Veritabanı ile bağlantı kuruldu.
        // GET: GenelBakis
        public ActionResult Index()
        {
            int projeSayisi = db.PersonelProjeleris.Count();
            ViewBag.ProjeSayisi = projeSayisi; 


            int tamamlanmisProje = db.PersonelProjeleris.Where(p => p.ProjeTamamlanmaDurumu == true).Count();
            ViewBag.TamamlanmisProje = tamamlanmisProje;

            int tamamlanmamisProje = db.PersonelProjeleris.Where(p => p.ProjeTamamlanmaDurumu == false).Count();
            ViewBag.TamamlanmamisProje = tamamlanmamisProje;


            var yuksekOncelikliProjeler = db.PersonelProjeleris.Where(p => p.OncelikDurumu == "Yüksek Öncelikli").Count();
            ViewBag.YuksekOncelikliProjeler = yuksekOncelikliProjeler;

            var ortaOncelikliProjeler = db.PersonelProjeleris.Where(p => p.OncelikDurumu == "Orta Öncelikli").Count();
            ViewBag.OrtaOncelikliProjeler = ortaOncelikliProjeler;

            var dusukOncelikliProjeler = db.PersonelProjeleris.Where(p => p.OncelikDurumu == "Düşük Öncelikli").Count();
            ViewBag.DusukOncelikliProjeler = dusukOncelikliProjeler;

            var basariliVeYuksek = db.PersonelProjeleris.Where(p => p.ProjeTamamlanmaDurumu == true && p.OncelikDurumu == "Yüksek Öncelikli").Count();
            ViewBag.BasariliVeYuksek = basariliVeYuksek;

            var basariliVeOrta = db.PersonelProjeleris.Where(p => p.ProjeTamamlanmaDurumu == true && p.OncelikDurumu == "Orta Öncelikli").Count();
            ViewBag.BasariliVeOrta = basariliVeOrta;

            var basariliVeDusuk = db.PersonelProjeleris.Where(p => p.ProjeTamamlanmaDurumu == true && p.OncelikDurumu == "Düşük Öncelikli").Count();
            ViewBag.BasariliVeDusuk = basariliVeDusuk;

            var personelProjeListesi = db.PersonelProjeleris.ToList();
            var personelTamamlanmisProjeSayisi = new Dictionary<int, int>(); //personelID ve tamamlanmışProje Sayısı çiftlerini tutuyoruz
            foreach(var personel in db.PersonelBilgileris.ToList())
            {
                int tamamlanmisProjeSayisi = 0;
                foreach(var proje in personel.PersonelProjeleris )
                {
                    tamamlanmisProjeSayisi++;
                }
                personelTamamlanmisProjeSayisi[personel.PersonelBilgileriID] = tamamlanmisProjeSayisi;
            }
            var siraliPersonelListesi = personelTamamlanmisProjeSayisi.OrderByDescending(x => x.Value); //tamamlanmış proje sayısına göre personelleri sıralıyoruz
            var enCokTamamlananPersonelId = siraliPersonelListesi.First().Key; //en çok proje tamamlama sayısına sahip personeli alıyoruz
            var enCokTamamlananPersonel = db.PersonelBilgileris.FirstOrDefault(p => p.PersonelBilgileriID == enCokTamamlananPersonelId);
            ViewBag.EnCokTamamlayanPersonelBilgisi = enCokTamamlananPersonel.AdSoyad;

            var enCokProjeTamamlayanPersonelProjeSayisi = personelTamamlanmisProjeSayisi[enCokTamamlananPersonelId];
            ViewBag.EnCokProjeTamamlayanPersonelinProjeSayisi = enCokProjeTamamlayanPersonelProjeSayisi;
            return View("Index");
        }


        public ActionResult GenelIstatistik()
        {
            var personeller = db.PersonelBilgileris.ToList();
            var personelProjeleri = db.PersonelProjeleris.ToList();
            var tamamlananProjeSayisi = new Dictionary<int,int>();
            var tamamlanmayanProjeSayisi = new Dictionary <int,int>();
            var toplamProjeSayisi = new Dictionary <int,int>();
            foreach ( var personel in personeller)
            {
                int tamamlananProje = 0;
                int tamamlanmayanProje = 0;
                int toplamProje = 0;
                foreach(var proje in personelProjeleri)
                {
                    if (proje.PersonelBilgileris.Contains(personel))
                    {
                        toplamProje++;
                        if (proje.ProjeTamamlanmaDurumu)
                        {
                            tamamlananProje++;
                        }
                        else
                        {
                            tamamlanmayanProje++;
                        }
                    }
                }
                tamamlananProjeSayisi[personel.PersonelBilgileriID] = tamamlananProje;
                tamamlanmayanProjeSayisi[personel.PersonelBilgileriID] = tamamlanmayanProje;
                toplamProjeSayisi[personel.PersonelBilgileriID] = toplamProje;
            }
            ViewBag.TamamlananProjeSayisi = tamamlananProjeSayisi;
            ViewBag.TamamlanmayanProjeSayisi = tamamlanmayanProjeSayisi;
            ViewBag.ToplamProjeSayisi = toplamProjeSayisi;


            int projeSayisi = db.PersonelProjeleris.Count();
            ViewBag.ProjeSayisi = projeSayisi;
            int personelSayisi = db.PersonelBilgileris.Count();
            ViewBag.PersonelSayisi = personelSayisi;
            int tamamlanmisProje = db.PersonelProjeleris.Where(p => p.ProjeTamamlanmaDurumu == true).Count();
            ViewBag.TamamlanmisProje = tamamlanmisProje;
            int tamamlanmamisProje = db.PersonelProjeleris.Where(p => p.ProjeTamamlanmaDurumu == false).Count();
            ViewBag.TamamlanmamisProje = tamamlanmamisProje;
            var basarisizVeYuksek = db.PersonelProjeleris.Where(p => p.ProjeTamamlanmaDurumu == false && p.OncelikDurumu == "Yüksek Öncelikli").Count();
            ViewBag.BasarisizVeYuksek = basarisizVeYuksek;
            var basarisizVeOrta = db.PersonelProjeleris.Where(p => p.ProjeTamamlanmaDurumu == false && p.OncelikDurumu == "Orta Öncelikli").Count();
            ViewBag.BasarisizVeOrta = basarisizVeOrta;

            return View(personeller);
        }
    }
}