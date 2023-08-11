using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Web;
using PersonelTakipWebSite.Models.ProjeTakip;

namespace PersonelTakipWebSite.Models.Personel
{
    public class PersonelBilgileri
    {
        public PersonelBilgileri()
        {
            this.PersonelProjeleris = new HashSet<PersonelProjeleri>();
        }

        [Key]
        public int PersonelBilgileriID { get; set; }

        [DisplayName("E-POSTA")]
        public string Eposta { get; set; }


        [DisplayName("ŞİFRE")]  //Ekranda gözükecek isimlendirmeler.
        [StringLength(25, ErrorMessage = "Şifre uzunluğu 25 karakterden fazla olamaz.")]    //Sınırlandırmalar. 
        public string Sifre { get; set; }



        [DisplayName("AD SOYAD")]
        [StringLength(50, ErrorMessage = "Ad Soyad bilgisi 50 karakterden fazla olamaz.")]
        public string AdSoyad { get; set; }


        [DisplayName("Personel Görseli")]
        public string PersonelGörseli { get; set; }



        [DisplayName("TC KİMLİK NO")]
        [StringLength(11, ErrorMessage = "TC kimlik numarası 11 karakter uzunluğunda olmalıdır.")]
        public string TCNO { get; set; }



        [DisplayName("DOĞUM TARİHİ")]
        public DateTime DogumTarihi { get; set; }



        [DisplayName("İŞE GİRİŞ TARİHİ")]
        public DateTime? IseGirisTarihi { get; set; }



        [DisplayName("TELEFON NUMARASI")]
        [StringLength(15, ErrorMessage = "Telefon Numarası uzunluğu 15 karakterden fazla olamaz.")]
        public string TelNo { get; set; }



        [DisplayName("ADRES BİLGİLERİ")]
        public string Adres { get; set; }



        [DisplayName("MEDENİ HAL")]
        [StringLength(25, ErrorMessage = "Medeni hali bilgisi 25 karakterden fazla olamaz.")]
        public string MedeniHal { get; set; }



        [DisplayName("YAKINLIK BİLGİSİ")]
        [StringLength(25, ErrorMessage = "Yakınlık bilgisi 25 karakterden fazla olamaz.")]
        public string YakinBilgisi { get; set; }



        [DisplayName("YAKIN TC NO")]
        [StringLength(11, ErrorMessage = "TC kimlik numarası 11 karakter uzunluğunda olmalıdır.")]
        public string YakinTC { get; set; }



        [DisplayName("YAKIN AD SOYAD")]
        [StringLength(50, ErrorMessage = "Ad Soyad bilgisi 50 karakterden fazla olamaz.")]
        public string YakinAdSoyad { get; set; }



        [DisplayName("YAKIN TELEFON NUMARASI")]
        [StringLength(15, ErrorMessage = "Telefon Numarası uzunluğu 15 karakterden fazla olamaz.")]
        public string YakinTelNo { get; set; }



        [DisplayName("DEPARTMANI")]
        [StringLength(25, ErrorMessage = "Departman bilgisi 25 karakterden fazla olamaz.")]
        public string Departman { get; set; }



        [DisplayName("YETKİ")]
        [StringLength(25, ErrorMessage = "Yetki bilgisi 25 karakterden fazla olamaz.")]
        public string Yetki { get; set; }



        [DisplayName("GÖREVİ")]
        public string Gorev { get; set; }



        [DisplayName("AÇIKLAMA")]
        public string PozisyonAciklama { get; set; }
        public virtual ICollection<PersonelProjeleri> PersonelProjeleris { get; set; }
    }
}