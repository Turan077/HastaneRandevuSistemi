using HastaneRandevu.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace HastaneRandevu.Controllers
{
    public class RandevuController : Controller
    {
        private readonly HastaneContext _context;

        // Tüm tıbbi bölümler listesi
        private List<string> Bolumler = new List<string>
        {
            "Dahiliye", "Kardiyoloji", "Nöroloji", "Ortopedi", "Göz Hastalıkları", "Kulak Burun Boğaz", "Cildiye", "Üroloji", "Psikiyatri", "Genel Cerrahi", "Çocuk Sağlığı", "Kadın Doğum", "Enfeksiyon", "Göğüs Hastalıkları", "Fizik Tedavi", "Acil", "Radyoloji", "Anestezi", "Ağız ve Diş Sağlığı", "Onkoloji", "Endokrinoloji"
        };

        public RandevuController(HastaneContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            ViewBag.Bolumler = Bolumler;
            return View();
        }

        [HttpPost]
        public IActionResult Index(Randevu model)
        {
            ViewBag.Bolumler = Bolumler;
            if (ModelState.IsValid)
            {
                _context.Randevular.Add(model);
                _context.SaveChanges();
                ViewBag.Mesaj = "Randevunuz başarıyla alındı!";
                return View("Onay", model);
            }
            return View(model);
        }

        public IActionResult Liste()
        {
            var randevular = _context.Randevular.ToList();
            return View(randevular);
        }

        [HttpPost]
        public IActionResult Sil(int id)
        {
            var randevu = _context.Randevular.Find(id);
            if (randevu != null)
            {
                _context.Randevular.Remove(randevu);
                _context.SaveChanges();
            }
            return RedirectToAction("Liste");
        }

        public IActionResult Guncelle(int id)
        {
            var randevu = _context.Randevular.Find(id);
            if (randevu == null)
                return NotFound();
            ViewBag.Bolumler = Bolumler;
            return View(randevu);
        }

        [HttpPost]
        public IActionResult Guncelle(Randevu model)
        {
            ViewBag.Bolumler = Bolumler;
            if (ModelState.IsValid)
            {
                _context.Randevular.Update(model);
                _context.SaveChanges();
                return RedirectToAction("Liste");
            }
            return View(model);
        }
    }
}