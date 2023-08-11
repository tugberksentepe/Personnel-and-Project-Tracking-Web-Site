using PersonelTakipWebSite.Models.Personel;
using PersonelTakipWebSite.Models.ProjeTakip;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PersonelTakipWebSite.Models.DataContext
{
    public class ProjeDBContext: DbContext
    {
        public ProjeDBContext() : base("ProjeDB") 
        {

        }

        public DbSet<PersonelBilgileri> PersonelBilgileris { get; set; }

        public DbSet<PersonelProjeleri> PersonelProjeleris { get; set; }
    }
}