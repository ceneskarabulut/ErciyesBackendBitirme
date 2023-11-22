using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BitirmeApp.Data
{
    public class Kullanici
    {
         [Key]
        public int KullaniciId { get; set; }    
        public string KullaniciAd{get; set; }
        public string Sifre { get; set; }
        public string Email { get; set; }
        public List<Makale> Makale {get;set;}=new List<Makale>();
        public List<Yorum> Yorum {get;set;}=new List<Yorum>();
            }
}