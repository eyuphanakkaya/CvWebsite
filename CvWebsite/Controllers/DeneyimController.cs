using CvWebsite.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CvWebsite.Models.Entity;


namespace CvWebsite.Controllers
{
    public class DeneyimController : Controller
    {
        // GET: Deneyim
        DeneyimRepository Deneyim = new DeneyimRepository();
        public ActionResult Index()
        {
            var Den = Deneyim.List();
            return View(Den);
        }
        [HttpGet]
        public ActionResult DeneyimEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DeneyimEkle(TbExperiences P)
        {
            Deneyim.TAdd(P);
            return RedirectToAction("Index");
        }
        public ActionResult DeneyimSil(int Id)
        {
            TbExperiences T=Deneyim.Find(x=>x.Id==Id);
            Deneyim.TDelete(T);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult DeneyimDuzenle(int Id)
        {
            var DegerGetir=Deneyim.Find(x=>x.Id==Id);
            return View(DegerGetir);
        }
        [HttpPost]
        public  ActionResult DeneyimDuzenle(TbExperiences P)
        {
            var Degergetir = Deneyim.Find(x => x.Id == P.Id);
            Degergetir.Title = P.Title;
            Degergetir.Subtitle = P.Subtitle;
            Degergetir.Date = P.Date;
            Degergetir.Explanation=P.Explanation;
            Deneyim.TUpdate(Degergetir);
            return RedirectToAction("Index");
            
        }

    }
}