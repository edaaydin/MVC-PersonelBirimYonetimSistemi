using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Mvc_Projem.Models;

namespace Mvc_Projem.Controllers
{
    public class BirimController : Controller
    {
        Context context = new Context();

        [Authorize] // yetkisi olanlar giris yapıcak!
        public IActionResult Index()
        {
            var degerler = context.Birims.ToList();

            return View(degerler);
        }

        [HttpGet] // sayfa yuklendiğinde çalışıcak.
        public IActionResult YeniBirim()
        {
            return View();
        }

        [HttpPost] // sayfada post işlemi oldugunda çalışıcak
        public IActionResult YeniBirim(Birim birim)
        {
            context.Birims.Add(birim);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult BirimSil(int id) // silme işlemini görmüyor.
        {
            var sil = context.Birims.Find(id);
            context.Birims.Remove(sil);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult BirimGetir(int id)
        {
            var birim = context.Birims.Find(id);
            return View("BirimGetir", birim);
        }

        public IActionResult BirimGuncelle(Birim birim)
        {
            var dep = context.Birims.Find(birim.Id);

            dep.BirimAd = birim.BirimAd;
            context.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult BirimDetay(int id) // Birime ait personeller (a kişisi b biriminde gibi)
        {
            var degerler = context.Personels.Where(x => x.BirimId == id).ToList(); // amac Detaya tıklandıgında o birime ait personelleri listelesin.

            var birimAd = context.Birims.Where(x => x.Id == id).Select(y => y.BirimAd).FirstOrDefault(); // ilgili birimin adını getirme.
            ViewBag.brm = birimAd;
            return View(degerler);
        }

    }
}
