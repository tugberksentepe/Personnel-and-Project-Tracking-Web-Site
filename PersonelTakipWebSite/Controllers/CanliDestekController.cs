using PersonelTakipWebSite.Models.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PersonelTakipWebSite.Controllers
{
    public class CanliDestekController : Controller
    {
        private ProjeDBContext db = new ProjeDBContext();   //Veritabanı ile bağlantı kuruldu.
        // GET: CanliDestek
        public ActionResult CanliDestek()
        {
            var destek = db.PersonelBilgileris.Where(x => x.Departman == "Yönetim");
            return View(destek.ToList());
        }
    }
}