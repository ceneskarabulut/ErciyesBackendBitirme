using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BitirmeApp.Data
{
	public class Makale
	{
		[Key]
		public int MakaleId { get; set; }
		public string? Baslik { get; set; }
		public string? İcerik { get; set; }
		public string? Resim { get; set; }
		public int KullaniciId { get; set; }
		public Kullanici Kullanici{get; set;} =null!;
		public int KategoriId { get; set; }
		public Kategori Kategori{get;set;} =null!;
        public List<Yorum> Yorums { get; set; } = new List<Yorum>();


        [NotMapped]
        public IFormFile? Dosya { get; set; }


    }
}

