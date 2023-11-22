using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace BitirmeApp.Data
{
    public class Yorum
    {
        [Key]
        public int YorumId { get; set; }    
        public string? YorumAciklama { get; set; }
        public DateTime OlusturmaTarihi { get; set; }
        public int? MakaleId { get; set; }
        public Makale Makale { get; set; }=null!;
        public int? KullaniciId  { get; set; }
        public Kullanici Kullanici{get;set;} =null!;
    }
}