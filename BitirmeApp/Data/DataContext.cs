using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BitirmeApp.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options){}
       public DbSet<Makale> Makaleler => Set<Makale>();
       public DbSet<Yorum> Yorumlar => Set<Yorum>();
       public DbSet<Kullanici> Kullanicilar => Set<Kullanici>();
       public DbSet<Kategori> Kategoriler => Set<Kategori>();
       public DbSet<PasswordCode> PasswordCodes =>Set<PasswordCode>();
    }
}