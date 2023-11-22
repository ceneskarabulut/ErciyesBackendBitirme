using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BitirmeApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BitirmeApp.Controllers
{

    public class YorumController : Controller
    {
        private readonly DataContext _context;
    
      public YorumController(DataContext context)
        {
            _context = context;
        }

      [HttpGet]
        public IActionResult YorumYap(){
         //   ViewBag.Kullanicilar = new SelectList(_context.Kullanicilar.ToList(), "KullaniciId", "KullaniciAd");
            return View();
        }

        [HttpPost]
        public IActionResult YorumYap(Yorum model){
           // _context.Yorumlar.Add(model);
            //_context.SaveChanges();
            return View();
        }
    }
    }
    