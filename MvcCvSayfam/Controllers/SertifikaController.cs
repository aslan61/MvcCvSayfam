using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCvSayfam.Models.Entity;
using MvcCvSayfam.Repositories;
namespace MvcCvSayfam.Controllers
{
    public class SertifikaController : Controller
    {
        // GET: Sertifika
        GenericRepository<Sertifikalarım> repo = new GenericRepository<Sertifikalarım>();
        public ActionResult Index()
        {
            var sertifika = repo.List();
            return View(sertifika);
        }
        [HttpGet]
        public ActionResult SertifikaGetir(int id)
        {
            var sertifika = repo.Find(x => x.ID == id);
            ViewBag.d = id;
            return View(sertifika);
        }
        [HttpPost]
        public ActionResult SertifikaGetir(Sertifikalarım s)
        {
            var sertifika = repo.Find(x => x.ID == s.ID);
            sertifika.Aciklama = s.Aciklama;
            sertifika.Tarih = s.Tarih;
            repo.TUpdate(sertifika);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult YeniSertifika()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniSertifika(Sertifikalarım p)
        {
            repo.Tadd(p);
            return RedirectToAction("Index");
        }
        public ActionResult SertifikaSil(int p)
        {
            var sertifika = repo.Find(x => x.ID == p);
            repo.TDelete(sertifika);
            return RedirectToAction("Index");
        }
    }
}