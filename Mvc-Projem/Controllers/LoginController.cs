using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Mvc_Projem.Models;
using System.Security.Claims;

namespace Mvc_Projem.Controllers
{
    public class LoginController : Controller
    {
        private readonly Context _context;

        public LoginController(Context context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GirisYap()
        {
            return View();
        }

        public async Task<IActionResult> GirisYap(Admin admin)
        {
            var bilgiler = _context.Admins.FirstOrDefault(x => x.Kullanici == admin.Kullanici && x.Sifre == admin.Sifre);

            if (bilgiler != null) // bilgiler bos degilse icerdeki islemleri gerceklestirir.
            {
                // talepler
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, admin.Kullanici) // turu,value degeri
                };

                var userIdentity = new ClaimsIdentity(claims, "Login"); //talebin kimligi / claimsten gelen deger,Authentication'dan gelen deger.

                ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity); // birden çok talebi karsılamak icin kullanılır.

                await HttpContext.SignInAsync(principal); // tanımlanan talebin nesnesini gondeririz!

                return RedirectToAction("Index", "Personel");
            }
            return View();
        }
    }
}
