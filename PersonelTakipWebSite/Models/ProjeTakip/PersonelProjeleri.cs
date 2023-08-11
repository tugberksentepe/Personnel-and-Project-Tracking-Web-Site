using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Web;
using PersonelTakipWebSite.Models.Personel;

namespace PersonelTakipWebSite.Models.ProjeTakip
{
    public class PersonelProjeleri
    {
        //Kurulan tablolaların ilişkileri sıkıntıya düşmemeleri için yeni bir HashSet oluşturduk
        //Yeni bir personel eklenmesi durumunda, bunu göremeyeceği durumlarda null döndürme durumunun önüne geçmek için.
        public PersonelProjeleri()
        {
            this.PersonelBilgileris = new HashSet<PersonelBilgileri>();
        }

        [Key]
        public int PersonelProjeID { get; set; }

        [DisplayName("PROJE BAŞLIĞI")]  //Ekranda gözükecek isimlendirmeler.
        [StringLength(150, ErrorMessage = "Başlık uzunluğu 150 karakterden fazla olamaz.")]    //Sınırlandırmalar. 
        public string ProjeBaslik { get; set; }


        public string ProjeAciklama { get; set; }


        public DateTime ProjeOlusturmaTarihi { get; set; }

        [DisplayName("ÖNCELİK DURUMU ")]
        [StringLength(25, ErrorMessage = "Öncelik durumu bilgisi 25 karakterden fazla olamaz.")]
        public string OncelikDurumu { get; set; }


        public int ProjeTamamlanmaOrani { get; set; }


        public DateTime? ProjeTamamlanmaTarihi { get; set; }


        public bool ProjeTamamlanmaDurumu { get; set; }

        //Bir personelin birden fazla projesi, bir projenin de birden fazla personeli olabilir.
        //Bu durum için ICollection kullanıyorum.
        public virtual ICollection<PersonelBilgileri> PersonelBilgileris { get; set; }
    }
}