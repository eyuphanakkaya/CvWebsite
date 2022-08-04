using CvWebsite.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CvWebsite.Models.Entity;

namespace CvWebsite.Controllers
{
    public class YeteneklerimController : Controller
    {
        // GET: Yeteneklerim
        YetenekRepository yetenekRepository = new YetenekRepository();
        public ActionResult Index()
        {
            var Deger=yetenekRepository.List();
            return View(Deger);
        }
        [HttpGet]
        public ActionResult YetenekEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YetenekEkle(TbTalents tbTalents)
        {
            yetenekRepository.TAdd(tbTalents);
            return RedirectToAction("Index");
        }
        public ActionResult YetenekSil(int id)
        {
            var DegerBul = yetenekRepository.Find(x => x.Id == id);
            yetenekRepository.TDelete(DegerBul);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult YetenekDuzenle(int id)
        {
            var DegerBul = yetenekRepository.Find(x=>x.Id==id);
            return View(DegerBul);
        }
        [HttpPost]
        public ActionResult YetenekDuzenle(TbTalents tbTalents)
        {
            var DegerBul = yetenekRepository.Find(x => x.Id == tbTalents.Id);
            DegerBul.Talent = tbTalents.Talent;
            DegerBul.Ratio = tbTalents.Ratio;
            yetenekRepository.TUpdate(tbTalents);
            return RedirectToAction("Index");
        }
    }
}