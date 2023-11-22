using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using BitirmeApp.Models;
using BitirmeApp.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using BitirmeApp.Filter;
using Microsoft.EntityFrameworkCore;
namespace BitirmeApp.Controllers;


public class HomeController : Controller
{   
    
     private readonly DataContext _context;

        public HomeController(DataContext context)
        {
            _context = context;
        }

    public IActionResult Index()
    {
        ViewBag.Kategoriler = new SelectList(_context.Kategoriler.ToList(), "KategoriId", "KategoriAd");
       return View(_context.Makaleler.ToList());
    }
public async Task<IActionResult> Filter(int? kategoriId)
    {
        if (kategoriId == null)
        {
            return RedirectToAction("Index");
        }

        var makaleler = await _context.Makaleler
            .Where(m => m.KategoriId == kategoriId)
            .ToListAsync();

        if (makaleler == null)
        {
            return NotFound();
        }
    ViewBag.Kategoriler = new SelectList(_context.Kategoriler.ToList(), "KategoriId", "KategoriAd");
        return View("Index", makaleler);
    }

  

  
}
