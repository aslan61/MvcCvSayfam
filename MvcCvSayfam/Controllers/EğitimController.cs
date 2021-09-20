using MvcCvSayfam.Models.Entity;
using MvcCvSayfam.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCvSayfam.Controllers
{
    public class EğitimController : Controller
    {
        // GET: Eğitim
        GenericRepository<Eğitimlerim> repo = new GenericRepository<Eğitimlerim>();
        public ActionResult Index()
        {
            var eğitim = repo.List();
            return View(eğitim);
        }
        [HttpGet]
        public ActionResult EğitimEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult EğitimEkle(Eğitimlerim p)
        {
            if (!ModelState.IsValid)
            {
                return View("EgitimEkle");
            }
            repo.Tadd(p);
            return RedirectToAction("Index");
        }
        public ActionResult EğitimSil(int id)
        {
            var egitim = repo.Find(x => x.ID == id);
            repo.TDelete(egitim);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult EğitimDuzenle(int id)
        {
            var egitim = repo.Find(x => x.ID == id);
            return View(egitim);
        }
        [HttpPost]
        public ActionResult EğitimDuzenle(Eğitimlerim e)
        {
            var egitim = repo.Find(x => x.ID == e.ID);
            egitim.Baslik = e.Baslik;
            egitim.Altbaslık1 = e.Altbaslık1;
            egitim.Altbaslık2 = e.Altbaslık2;
            egitim.Tarih = e.Tarih;
            egitim.GNO = e.GNO;
            return RedirectToAction("Index");
        }
    }
}