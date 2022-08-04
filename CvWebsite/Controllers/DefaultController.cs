using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CvWebsite.Models.Entity;

namespace CvWebsite.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        DbCVEntities Db = new DbCVEntities();
        public ActionResult Index()
        {
            var Deger = Db.TbAbout.ToList();
            return View(Deger);
        }

        public PartialViewResult Experiences()
        {
            var Deneyim = Db.TbExperiences.ToList();
            return PartialView(Deneyim);
        }
        public PartialViewResult Trainings()
        {
            var Egitim = Db.TbTrainings.ToList();
            return PartialView(Egitim);
        }
        public PartialViewResult Talents()
        {
            var Yetenek = Db.TbTalents.ToList();
            return PartialView(Yetenek);
        }

        public PartialViewResult Hobbies()
        {
            var Hobi = Db.TbHobbies.ToList();
            return PartialView(Hobi);
        }
        public PartialViewResult Document()
        {
            var Sertifika=Db.TbDocuments.ToList();
            return PartialView(Sertifika);
        }
        [HttpGet]
        public PartialViewResult Contact()
        {
         
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult Contact(TbContact P1)
        {
            P1.Date = DateTime.Now.ToShortDateString();
            Db.TbContact.Add(P1);
            Db.SaveChanges();
            return PartialView();

        }
        public PartialViewResult Social()
        {
            var Deger = Db.TbSocial.ToList()/*.Where(x=>x.Durum==true)*/;
            return PartialView(Deger);

        }

    }
}