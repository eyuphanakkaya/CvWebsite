using CvWebsite.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CvWebsite.Models.Entity;

namespace CvWebsite.Controllers
{
    public class EgitimlerController : Controller
    {
        // GET: Egitimler
        EgitimRepository egitimRepository = new EgitimRepository();
        public ActionResult Index()
        {
            var Egitim = egitimRepository.List();
            return View(Egitim);
        }
        [HttpGet]
        public ActionResult EgitimEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult EgitimEkle(TbTrainings tbTrainings)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            egitimRepository.TAdd(tbTrainings);
            return RedirectToAction("Index");
        }
        public ActionResult EgitimSil(int id)
        {
            var DegerBul = egitimRepository.Find(x => x.Id == id);
            egitimRepository.TDelete(DegerBul);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult EgitimDuzenle(int id)
        {
         
            var Deger = egitimRepository.Find(x => x.Id == id);
            return View(Deger);
        }
        [HttpPost]
        public ActionResult EgitimDuzenle(TbTrainings tbTrainings)
        {
            var Deger = egitimRepository.Find(x => x.Id == tbTrainings.Id);
            Deger.Title=tbTrainings.Title;
            Deger.Subtitle1=tbTrainings.Subtitle1;
            Deger.Subtitle2=tbTrainings.Subtitle2;
            Deger.AVG=tbTrainings.AVG;
            Deger.Date=tbTrainings.Date;
            egitimRepository.TUpdate(Deger);
            return RedirectToAction("Index");
        }
    }
}