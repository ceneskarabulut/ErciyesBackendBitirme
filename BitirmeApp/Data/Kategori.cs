using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BitirmeApp.Data
{
    public class Kategori
    {
        [Key]
        public int KategoriId { get; set; } 
        public string? KategoriAd { get; set; }
        public string? KategoriAciklama { get; set; }
       public List<Makale> Makale{get;set;}=new List<Makale>();
       public List<Yorum> Yorum{get;set;}=new List<Yorum>();
    }
}