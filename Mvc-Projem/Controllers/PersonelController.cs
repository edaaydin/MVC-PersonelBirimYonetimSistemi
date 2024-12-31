using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Mvc_Projem.Models;

namespace Mvc_Projem.Controllers
{
    public class PersonelController : Controller
    {
        Context context = new Context();

        [Authorize] // yetkisi olanlar giris yapıcak!
        public IActionResult Index() // personelleri listeler.
        {
            var degerler = context.Personels.Include(x => x.Birim).ToList(); // birim sınıfını da dahil et !

            return View(degerler);
        }

        [HttpGet]
        public IActionResult YeniPersonel() // olmadı
        {
            List<SelectListItem> degerler = (from x in context.Birims.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = x.BirimAd, // kullanıcının gordugu
                                                 Value = x.Id.ToString() // yazılımcının gordugu
                                             }).ToList();
            ViewBag.deger = degerler;
            return View();
        }

        [HttpPost]
        public IActionResult YeniPersonel(Personel personel)
        {
            var prs = context.Birims.FirstOrDefault(x => x.Id == personel.BirimId);
            personel.Birim = prs;
            context.Personels.Add(personel);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult PersonelSil(int id) // silme işlemini görmüyor.
        {
            var sil = context.Personels.Find(id);
            context.Personels.Remove(sil);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult PersonelGetir(int id)
        {
            var personel = context.Personels.Find(id);
            return View("PersonelGetir", personel);
        }

        public IActionResult PersonelGuncelle(Personel personel)
        {
            var dep = context.Personels.Find(personel.PersonelId);

            dep.Ad = personel.Ad;
            context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
