using PersonelTakipWebSite.Models.DataContext;
using PersonelTakipWebSite.Models.ProjeTakip;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PersonelTakipWebSite.Controllers
{
    public class PersonelProjeController : Controller
    {
        private ProjeDBContext db = new ProjeDBContext();   //Veritabanı ile bağlantı kuruldu.

        // GET: PersonelProje
        public ActionResult Index()
        {
            var projeListele = db.PersonelProjeleris.ToList();
            return View(projeListele);
        }

        public ActionResult Create()
        {
            ViewBag.PersonelBilgileriID = new SelectList(db.PersonelBilgileris, "PersonelBilgileriID", "AdSoyad");
            return View();
        }
        [HttpPost]
        public ActionResult Create(PersonelProjeleri projeObj, int[] PersonelBilgileriID)
        {
            foreach (var x in PersonelBilgileriID) 
            {
                projeObj.PersonelBilgileris.Add(db.PersonelBilgileris.Find(x));
            }
            projeObj.ProjeOlusturmaTarihi = DateTime.Now;
            db.PersonelProjeleris.Add(projeObj);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var projeObj = db.PersonelProjeleris.Find(id);
            return View(projeObj);
        }
        [HttpPost]

        public ActionResult Edit(PersonelProjeleri projeObj)
        {
            var projeDbObj = db.PersonelProjeleris.Find(projeObj.PersonelProjeID);
            projeDbObj.ProjeAciklama = projeObj.ProjeAciklama;
            projeDbObj.ProjeBaslik = projeObj.ProjeBaslik;
            projeDbObj.ProjeTamamlanmaOrani = projeObj.ProjeTamamlanmaOrani;
            projeDbObj.OncelikDurumu = projeObj.OncelikDurumu;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Tamamla(int id)
        {
            var projeObj = db.PersonelProjeleris.Find(id);
            projeObj.ProjeTamamlanmaDurumu = true;
            projeObj.ProjeTamamlanmaOrani = 100;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}