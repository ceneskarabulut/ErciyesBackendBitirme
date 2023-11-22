using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BitirmeApp.Data
{
	 public class PasswordCode
    {
        public int Id { get; set; }

        public Kullanici Kullanici { get; set; }
        public int KullaniciId { get; set; }

        [StringLength(6)]

        public string Code { get; set; }
    }
}