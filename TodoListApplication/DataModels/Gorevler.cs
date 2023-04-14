//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TodoListApplication.DataModels
{
    using System;
    using System.Collections.Generic;
    
    public partial class Gorevler
    {
        public int id { get; set; }
        public string adi { get; set; }
        public string aciklama { get; set; }
        public Nullable<bool> aktif { get; set; }
        public Nullable<bool> silindi { get; set; }
        public Nullable<System.DateTime> olusturulma_zamani { get; set; }
        public string olusturan_kullanici { get; set; }
        public Nullable<System.DateTime> guncelleme_zamani { get; set; }
        public string guncelleyen_kullanici { get; set; }
        public Nullable<int> kullanici_id { get; set; }
        public Nullable<int> departman_id { get; set; }
        public Nullable<int> etiket_id { get; set; }
        public Nullable<int> durum_id { get; set; }
        public Nullable<System.DateTime> baslama_tarihi { get; set; }
        public Nullable<System.DateTime> bitis_tarihi { get; set; }
        public Nullable<System.DateTime> bitirilmesi_gereken_zaman { get; set; }
        public Nullable<int> proje_id { get; set; }
    
        public virtual Departmanlar Departmanlar { get; set; }
        public virtual Etiketler Etiketler { get; set; }
        public virtual Kullanicilar Kullanicilar { get; set; }
        public virtual Durumlar Durumlar { get; set; }
        public virtual Projeler Projeler { get; set; }
    }
}
