using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using BitirmeApp.Data;
using BitirmeApp.Filter;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Logging;

namespace BitirmeApp.Controllers
{

    public class MakaleController : Controller
    {
        private readonly DataContext _context;

        public MakaleController(DataContext context)
        {
            _context = context;
      
        }


        public IActionResult AddComment(int MakaleId, string YorumAciklama)
        {
            var makale = _context.Makaleler.Find(MakaleId);

            if (makale != null)
            {
                var newComment = new Yorum
                {
                    YorumAciklama = YorumAciklama,
                    OlusturmaTarihi=DateTime.Now,
                    MakaleId = makale.MakaleId,
                    KullaniciId=makale.KullaniciId
                };

                makale.Yorums.Add(newComment);
                _context.SaveChanges();
            }

            return RedirectToAction("Details", new { id = MakaleId });
         

        }


            public IActionResult Index(int? id)  
        {
            var mak= _context.Makaleler?.ToList();
            if(id != null){
                mak=mak.Where(m => m.KategoriId==id).ToList();
            }
            return View(mak);
            
        }
        [HttpGet]
        public IActionResult Create()
        {
             ViewBag.Kullanicilar = new SelectList(_context.Kullanicilar.ToList(), "KullaniciId", "KullaniciAd");
            ViewBag.Kategoriler = new SelectList(_context.Kategoriler.ToList(), "KategoriId", "KategoriAd");
            return View();
        }

        [HttpPost]
        public IActionResult Create(Makale yeniMakale)
        {
           
            if (yeniMakale.Dosya != null)
            {
                string kokDizin = Directory.GetCurrentDirectory(); 
                string kayitDizini = Path.Combine(kokDizin, "wwwroot", "resimler", "makaleler"); 
                string dosyaAdi = Guid.NewGuid() + Path.GetExtension(yeniMakale.Dosya.FileName); 
                string tamYol = Path.Combine(kayitDizini, dosyaAdi); 

                using (var dosyaAkisi = new FileStream(tamYol, FileMode.Create))
                {
                    yeniMakale.Dosya.CopyTo(dosyaAkisi);
                }

                yeniMakale.Resim = dosyaAdi;
            }

           

            _context.Makaleler.Add(yeniMakale);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
         public IActionResult Details(int id)
        {
         
            var makale = _context.Makaleler.Include(m=>m.Yorums).Include(m=>m.Kullanici).FirstOrDefault(m=>m.MakaleId == id);
            return View(makale);
        }

        public IActionResult Edit(int id)
        {
            
            var makale = _context.Makaleler.SingleOrDefault(i=>i.MakaleId == id);          
            ViewBag.Kategoriler = new SelectList(_context.Kategoriler.ToList(), "KategoriId", "KategoriAd");
            return View(makale);
        }

         [HttpPost]
        public IActionResult Edit(Makale model)
        {
            
            var makale = _context.Makaleler.Include(m => m.Kategori).SingleOrDefault(i=>i.MakaleId == model.MakaleId);
           if (model.Dosya != null)
            {
           
                string kokDizin = Directory.GetCurrentDirectory();
                string kayitDizini = Path.Combine(kokDizin, "wwwroot", "resimler", "makaleler");
                string ?dosyaAdi = makale.Resim;
                string silinecekResminTamYolu = Path.Combine(kayitDizini, dosyaAdi);
                System.IO.File.Delete(silinecekResminTamYolu);

                dosyaAdi = Guid.NewGuid() + Path.GetExtension(model.Dosya.FileName);
                string tamYol = Path.Combine(kayitDizini, dosyaAdi);

                using (var dosyaAkisi = new FileStream(tamYol, FileMode.Create))
                {
                    model.Dosya.CopyTo(dosyaAkisi);
                }

                makale.Resim = dosyaAdi;
            }
            
            makale.KategoriId=model.KategoriId;
            makale.Baslik = model.Baslik;
            makale.İcerik = model.İcerik;
         

            _context.SaveChanges();

            return RedirectToAction("Index");
        }
         public IActionResult Delete(int id)
        {
          if(ModelState.IsValid){
            var makale = _context.Makaleler.SingleOrDefault(m=>m.MakaleId == id);
            string kokDizin = Directory.GetCurrentDirectory();
            string kayitDizini = Path.Combine(kokDizin, "wwwroot", "resimler", "makaleler");
            
            string dosyaAdi = makale.Resim;
            string tamYol = Path.Combine(kayitDizini, dosyaAdi);
            System.IO.File.Delete(tamYol);

            _context.Makaleler.Remove(makale);
            }else{
                return NotFound();
            }
            _context.SaveChanges();
            return RedirectToAction("Index");
            
        }

      

    }
}