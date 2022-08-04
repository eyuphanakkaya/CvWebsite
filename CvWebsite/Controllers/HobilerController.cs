using CvWebsite.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CvWebsite.Models.Entity;

namespace CvWebsite.Controllers
{
    public class HobilerController : Controller
    {
        // GET: Hobiler
        HobiRepository hobiRepository = new HobiRepository();
        [HttpGet]
        public ActionResult Index()
        {
            var Deger = hobiRepository.List();
            return View(Deger);
        }
        [HttpPost]
        public ActionResult Index(TbHobbies tbHobbies)
        {
            var Hobi = hobiRepository.Find(x => x.Id == 1);
            Hobi.Explanation1=tbHobbies.Explanation1;
            Hobi.Explanation2=tbHobbies.Explanation2;
            hobiRepository.TUpdate(tbHobbies);
            return RedirectToAction("Index");
        }
    }
}