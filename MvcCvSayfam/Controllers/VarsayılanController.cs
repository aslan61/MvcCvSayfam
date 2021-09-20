using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCvSayfam.Models.Entity;
namespace MvcCvSayfam.Controllers
{  
    [AllowAnonymous]
    public class VarsayılanController : Controller
    {
        // GET: Varsayılan
        DbCvEntities2 db = new DbCvEntities2();
        public ActionResult Index()
        {
            var degerler = db.Hakkımda.ToList();
            return View(degerler);
        }
        public PartialViewResult SosyalMedya()
        {
            var sosyalmedya = db.TblSosyalMedya.Where(x=>x.Durum==true).ToList();
            return PartialView(sosyalmedya);
        }
        public PartialViewResult Deneyim()
        {
            var degerler = db.Deneyimlerim.ToList();
            return PartialView(degerler);
        }
        public PartialViewResult Eğitimlerim()
        {
            var eğitimler = db.Eğitimlerim.ToList();
            return PartialView(eğitimler);
        }
        public PartialViewResult Yeteneklerim()
        {
            var yetenekler = db.Yeteneklerim.ToList();
            return PartialView(yetenekler);
        }
        public PartialViewResult Hobilerim()
        {
            var hobiler = db.Hobilerim.ToList();
            return PartialView(hobiler);
        }
        public PartialViewResult Sertifikalar()
        {
            var sertifikalar = db.Sertifikalarım.ToList();
            return PartialView(sertifikalar);
        }
        [HttpGet]
        public PartialViewResult İletişim()
        {
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult İletişim(İletişim t)
        {
            t.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
            db.İletişim.Add(t);
            db.SaveChanges();
            return PartialView();
        }
    }
}