using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PersonelTakipWebSite.Models.DataContext;
using PersonelTakipWebSite.Models.Personel;

namespace PersonelTakipWebSite.Controllers
{
    public class PersonelBilgilerisController : Controller
    {
        private ProjeDBContext db = new ProjeDBContext();   //Veritabanı ile bağlantı kuruldu.

        
        public ActionResult Index()     //Verileri listelemeyi burada yapıyoruz.
        {
            return View(db.PersonelBilgileris.ToList());
        }

        public ActionResult PersonelKart()
        {
            return View(db.PersonelBilgileris.ToList());
        }
        public ActionResult Create()        //Ekleme oluşturma işlemlerini yapıyor.
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PersonelBilgileriID,Eposta,Sifre,AdSoyad,TCNO,DogumTarihi,IseGirisTarihi,TelNo,Adres,MedeniHal,YakinBilgisi,YakinTC,YakinAdSoyad,YakinTelNo,Departman,Yetki,Gorev,PozisyonAciklama")] PersonelBilgileri personelBilgileri)
        {
            if (ModelState.IsValid)
            {
                db.PersonelBilgileris.Add(personelBilgileri);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(personelBilgileri);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PersonelBilgileri personelBilgileri = db.PersonelBilgileris.Find(id);
            if (personelBilgileri == null)
            {
                return HttpNotFound();
            }
            return View(personelBilgileri);
        }       
          
        // GET: PersonelBilgileris/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PersonelBilgileri personelBilgileri = db.PersonelBilgileris.Find(id);
            if (personelBilgileri == null)
            {
                return HttpNotFound();
            }
            return View(personelBilgileri);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PersonelBilgileriID,Eposta,Sifre,AdSoyad,TCNO,DogumTarihi,IseGirisTarihi,TelNo,Adres,MedeniHal,YakinBilgisi,YakinTC,YakinAdSoyad,YakinTelNo,Departman,Yetki,Gorev,PozisyonAciklama")] PersonelBilgileri personelBilgileri)
        {
            if (ModelState.IsValid)
            {
                db.Entry(personelBilgileri).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(personelBilgileri);
        }

        // GET: PersonelBilgileris/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PersonelBilgileri personelBilgileri = db.PersonelBilgileris.Find(id);
            if (personelBilgileri == null)
            {
                return HttpNotFound();
            }
            return View(personelBilgileri);
        }

        // POST: PersonelBilgileris/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PersonelBilgileri personelBilgileri = db.PersonelBilgileris.Find(id);
            db.PersonelBilgileris.Remove(personelBilgileri);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
