using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BitirmeApp.Data;
using Microsoft.EntityFrameworkCore;


namespace BitirmeApp.Controllers
{

    public class KategoriController : Controller
    {
        private readonly DataContext _context;

        public KategoriController(DataContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(_context.Kategoriler.ToList());
          
        }

       public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Kategori model)
        {
            _context.Kategoriler.Add(model);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
            
        } 
 public IActionResult Edit(int id)
        {
            
            var kategori = _context.Kategoriler.SingleOrDefault(k=>k.KategoriId == id);
          
            return View(kategori);
        }

         [HttpPost]
        public IActionResult Edit(Kategori model)
        {
            
            var kategori = _context.Kategoriler.SingleOrDefault(i=>i.KategoriId == model.KategoriId);  
            kategori.KategoriAd = model.KategoriAd;
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
         public IActionResult Delete(int id)
        {
            var kategori = _context.Kategoriler.SingleOrDefault(i=>i.KategoriId == id);  
            _context.Kategoriler.Remove(kategori);          
            _context.SaveChanges();
            return RedirectToAction("Index");
            
        }

    }
}