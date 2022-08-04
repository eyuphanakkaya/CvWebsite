using CvWebsite.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CvWebsite.Models.Entity;

namespace CvWebsite.Controllers
{
    [Authorize] 
    public class HakkimdaController : Controller
    {
        // GET: Hakkimda
        HakkimdaRepository hakkimdaRepository = new HakkimdaRepository();
        public ActionResult Index()
        {
           var Hak=hakkimdaRepository.List();
            return View(Hak);
        }
        [HttpGet]
        public ActionResult HakkimdaDuzenle()
        {
            var Deger = hakkimdaRepository.Find(x => x.Id == 1);
            return View(Deger);
        }
        [HttpPost]
        public ActionResult HakkimdaDuzenle(TbAbout tbAbout)
        {
            var Deger = hakkimdaRepository.Find(x => x.Id == 1);
            Deger.Name=tbAbout.Name;
            Deger.LastName=tbAbout.LastName;
            Deger.Adress=tbAbout.Adress;
            Deger.Phone=tbAbout.Phone;
            Deger.Mail=tbAbout.Mail;
            Deger.Explanation=tbAbout.Explanation;
            hakkimdaRepository.TUpdate(Deger);
            return RedirectToAction("Index");
        }
    }
}