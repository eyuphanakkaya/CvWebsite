using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CvWebsite.Models.Entity;
using CvWebsite.Repository;

namespace CvWebsite.Controllers
{
    public class SosyalMedyaController : Controller
    {
        // GET: SosyalMedya
        SosyalRepository sosyalRepository=new SosyalRepository();
        public ActionResult Index()
        {
           
            var Sos = sosyalRepository.List();
            return View(Sos);
        }
        [HttpGet]
        public ActionResult Ekle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Ekle(TbSocial tbSocial)
        {
            sosyalRepository.TAdd(tbSocial);
            tbSocial.Durum =true;
            sosyalRepository.TUpdate(tbSocial);

            return RedirectToAction("Index");
        }
        public ActionResult SayfaDuzenle(int id)
        {
            var Deger = sosyalRepository.Find(x => x.Id == id);
            return View(Deger);
        }
        [HttpPost]
        public ActionResult SayfaDuzenle(TbSocial tbSocial)
        {
            var Deger = sosyalRepository.Find(x => x.Id == tbSocial.Id);
            Deger.Name = tbSocial.Name;
            Deger.Icon = tbSocial.Icon;
            Deger.Link = tbSocial.Link;
            sosyalRepository.TUpdate(Deger);
            return RedirectToAction("Index");
        }
        public ActionResult SayfaDurum(int id)
        {
            var Durum = sosyalRepository.Find(x => x.Id == id);
            Durum.Durum = false;
            sosyalRepository.TUpdate(Durum);
            return RedirectToAction("Index");

        }
    }
}