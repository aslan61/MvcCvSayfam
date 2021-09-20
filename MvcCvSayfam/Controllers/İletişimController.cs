using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCvSayfam.Models.Entity;
using MvcCvSayfam.Repositories;
namespace MvcCvSayfam.Controllers
{
    public class İletişimController : Controller
    {
        // GET: İletişim
        GenericRepository<İletişim> repo = new GenericRepository<İletişim>();
        public ActionResult Index()
        {
            var mesajlar = repo.List();
            return View(mesajlar);
        }
    }
}