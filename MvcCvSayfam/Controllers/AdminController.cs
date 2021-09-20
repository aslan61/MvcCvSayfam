using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCvSayfam.Models.Entity;
using MvcCvSayfam.Repositories;

namespace MvcCvSayfam.Controllers
{
    [AllowAnonymous]
    public class AdminController : Controller
    {
        // GET: Admin
        GenericRepository<Admin> repo = new GenericRepository<Admin>();
        public ActionResult Index()
        {
            var liste = repo.List();
            return View(liste);
        }
        [HttpGet]
        public ActionResult AdminEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AdminEkle(Admin d)
        {
            repo.Tadd(d);
            return RedirectToAction("Index");
        }
        public ActionResult AdminSil(int id)
        {
            Admin t = repo.Find(x => x.ID == id);
            repo.TDelete(t);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult AdminDuzenle(int id)
        {
            Admin t = repo.Find(x => x.ID == id);
            return View(t);
        }
        [HttpPost]
        public ActionResult AdminDuzenle(Admin p)
        {
            Admin t = repo.Find(x => x.ID == p.ID);
            t.KullaniciAdi = p.KullaniciAdi;
            t.Sifre = p.Sifre;
            repo.TUpdate(t);
            return RedirectToAction("Index");
        }
    }
}