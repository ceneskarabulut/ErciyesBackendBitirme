using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using BitirmeApp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace BitirmeApp.Controllers
{
 
    public class KullaniciController : Controller
    {
        private readonly DataContext _context;
        private string code = null;

        public KullaniciController(DataContext context)
        {
            _context = context;
        }
       
        public IActionResult Index()
        {
            if(HttpContext.Session.GetInt32("KullaniciId").HasValue){
                return Redirect("/Home/Index");
            }
            return View();
            
        }
        public IActionResult Profile(int id)
        {
            var user = _context.Kullanicilar
               .Include(u => u.Yorum)
               .ThenInclude(u => u.Makale)
               .Include(u => u.Makale)
                .ThenInclude(b => b.Yorums)
                .FirstOrDefault(u => u.KullaniciId == id);

            return View(user);
        }

        public IActionResult Login(string email,string pass){
           var user = _context.Kullanicilar.FirstOrDefault(w => w.Email.Equals(email) && w.Sifre.Equals(pass));
            if(user != null){
                HttpContext.Session.SetInt32("KullaniciId",user.KullaniciId);   
                return Redirect("/Home/Index");
            }
            return Redirect("Index");
        }

        public IActionResult SignUp(){
            if(HttpContext.Session.GetInt32("KullaniciId").HasValue){
                return Redirect("/Home/Index");
            }
            return View();
        }
        public IActionResult Logout(){
            HttpContext.Session.Clear();
            return Redirect("Index");
        }
        public async Task<IActionResult> Register(Kullanici model){
            await _context.AddAsync(model);
            await _context.SaveChangesAsync();

            return Redirect("Index");
        }
          public IActionResult ForgotPassword()
        {
            if (HttpContext.Session.GetInt32("id").HasValue)
            {
                return Redirect("/Home/Index");
            }
            return View();
        }

        public IActionResult ResetPassword()
        {
            if (HttpContext.Session.GetInt32("id").HasValue)
            {
                return Redirect("/Home/Index");
            }
            return View();
        }

        public IActionResult SendCode(string email)
        {
            var user = _context.Kullanicilar.FirstOrDefault(w => w.Email.Equals(email));
            if(user != null)
            {
                _context.Add(new PasswordCode { KullaniciId=user.KullaniciId,Code=getCode()});
                _context.SaveChanges();
                string text = "<h1>Sıfırlama için kodunuz:</h1>"+ getCode()+" ";
                string subject = "Parola sıfırlama";
                MailMessage msg = new MailMessage("deneme@gmail.com",email,subject,text);
                msg.IsBodyHtml = true;
                SmtpClient sc = new SmtpClient("smtp.gmail.com", 587);
                sc.UseDefaultCredentials = false;
                NetworkCredential cre = new NetworkCredential("deneme@gmail.com","123456");
                sc.Credentials = cre;
                sc.EnableSsl = true;
                sc.Send(msg);
                return Redirect("ResetPassword");

            }
            return Redirect("Index");
        }

        public IActionResult ResetPasswordCode(string code,string newPassword)
        {
            var passwordcode = _context.PasswordCodes.FirstOrDefault(w => w.Code.Equals(code));
            if (passwordcode != null)
            {
                var user = _context.Kullanicilar.Find(passwordcode.KullaniciId);
                user.Sifre = newPassword;
                _context.Update(user);
                _context.Remove(passwordcode);
                _context.SaveChanges();
                return Redirect("Index");
            }
            return Redirect("Index");

        }
        public string getCode()
        {
            if(code == null)
            {
                Random rand = new Random();
                code = "";
                for(int i = 0; i < 6; i++)
                {
                    char tmp = Convert.ToChar(rand.Next(48, 58));
                    code += tmp;
                }

            }
            return code;
        }
       
    }
}