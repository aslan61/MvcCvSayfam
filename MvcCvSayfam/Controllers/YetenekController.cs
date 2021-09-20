using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCvSayfam.Models.Entity;
using MvcCvSayfam.Repositories;
namespace MvcCvSayfam.Controllers
{
    public class YetenekController : Controller
    {
        // GET: Yetenek
        GenericRepository<Yeteneklerim> repo = new GenericRepository<Yeteneklerim>();
        public ActionResult Index()
        {
            var yetenekler = repo.List();
            return View(yetenekler);
        }
        [HttpGet]
        public ActionResult YeniYetenek()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniYetenek(Yeteneklerim p)
        {
            repo.Tadd(p);
            return RedirectToAction("Index");
        }
        public ActionResult YetenekSil(int id)
        {
            var yetenek = repo.Find(x => x.ID == id);
            repo.TDelete(yetenek);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult YetenekDuzenle(int id)
        {
            var yetenekbul = repo.Find(x => x.ID == id);
            return View(yetenekbul);
        }
        [HttpPost]
        public ActionResult YetenekDuzenle(Yeteneklerim p)
        {
            Yeteneklerim t = repo.Find(x => x.ID == p.ID);
            t.Yetenek = p.Yetenek;
            t.Oran = p.Oran;
            repo.TUpdate(t);
            return RedirectToAction("Index");
        }
    }
}