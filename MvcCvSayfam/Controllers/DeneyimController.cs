using MvcCvSayfam.Models.Entity;
using MvcCvSayfam.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCvSayfam.Controllers
{
    public class DeneyimController : Controller
    {
        // GET: Deneyim
        DeneyimRepository repo = new DeneyimRepository();
        public ActionResult Index()
        {
            var degerler = repo.List();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult DeneyimEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DeneyimEkle(Deneyimlerim d)
        {
            repo.Tadd(d);
            return RedirectToAction("Index");
        }
        public ActionResult DeneyimSil(int id)
        {
            Deneyimlerim t = repo.Find(x => x.ID == id);
            repo.TDelete(t);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult DeneyimGetir(int id)
        {
            Deneyimlerim t = repo.Find(x => x.ID == id);
            return View(t);
        }
        [HttpPost]
        public ActionResult DeneyimGetir(Deneyimlerim p)
        {
            Deneyimlerim t = repo.Find(x => x.ID == p.ID);
            t.Başlık = p.Başlık;
            t.Altbaşlık = p.Altbaşlık;
            t.Tarih = p.Tarih;
            t.Aciklama = p.Aciklama;
            repo.TUpdate(t);
            return RedirectToAction("Index");
        }

    }
}