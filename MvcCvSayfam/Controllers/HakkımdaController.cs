using MvcCvSayfam.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCvSayfam.Models.Entity;

namespace MvcCvSayfam.Controllers
{
    public class HakkımdaController : Controller
    {
        // GET: Hakkımda
        GenericRepository<Hakkımda> repo = new GenericRepository<Hakkımda>();
        [HttpGet]
        public ActionResult Index()
        {
            var hakkımda = repo.List();
            return View(hakkımda);
        }
        [HttpPost]
        public ActionResult Index(Hakkımda h)
        {
            var b = repo.Find(x => x.ID == 1);
            b.Ad = h.Ad;
            b.Soyad = h.Soyad;
            b.Adres = h.Adres;
            b.Telefon = h.Telefon;
            b.Mail = h.Mail;
            b.Aciklama = h.Aciklama;
            b.Resim = h.Resim;
            repo.TUpdate(b);
            return RedirectToAction("Index");
        }
    }
}