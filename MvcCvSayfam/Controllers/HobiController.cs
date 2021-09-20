using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCvSayfam.Models.Entity;
using MvcCvSayfam.Repositories;

namespace MvcCvSayfam.Controllers
{
    public class HobiController : Controller
    {
        // GET: Hobi
        GenericRepository<Hobilerim> repo =new GenericRepository<Hobilerim>();
        [HttpGet]
        public ActionResult Index()
        {
            var hobiler = repo.List();
            return View(hobiler);
        }
        [HttpPost]
        public ActionResult Index(Hobilerim h)
        {
            var b = repo.Find(x => x.ID == 1);
            b.Aciklama1 = h.Aciklama1;
            b.Aciklama2 = h.Aciklama2;
            repo.TUpdate(b);
            return RedirectToAction("Index");
        }

    }
}