using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CvWebsite.Repository;
using CvWebsite.Models.Entity;

namespace CvWebsite.Controllers
{
    public class SertifikalarımController : Controller
    {
        // GET: Sertifikalarım
        SertifikalarRepository sertifikaRepository = new SertifikalarRepository();
        public ActionResult Index()
        {
            var Deger = sertifikaRepository.List();
            return View(Deger);
        }
        public ActionResult SertifkSil(int id)
        {
            var DegerBul=sertifikaRepository.Find(x=>x.Id == id);
            sertifikaRepository.TDelete(DegerBul);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult SertifkEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SertifkEkle(TbDocuments tbDocuments)
        {
            sertifikaRepository.TAdd(tbDocuments);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult SertifkDuzenle(int id)
        {
            var DegerBul = sertifikaRepository.Find(x => x.Id == id);
            return View(DegerBul);
        }
        [HttpPost]
        public ActionResult SertifkDuzenle(TbDocuments tbDocuments)
        {
            var DegerGetir = sertifikaRepository.Find(x => x.Id == tbDocuments.Id);
            DegerGetir.Explanation=tbDocuments.Explanation;
            DegerGetir.Date=tbDocuments.Date;
            sertifikaRepository.TUpdate(DegerGetir);
            return RedirectToAction("Index");
        }

    }
}