using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CvWebsite.Repository;

namespace CvWebsite.Controllers
{
    public class IletisimController : Controller
    {
        // GET: Iletisim
        IletsimRepository iletisimRepository = new IletsimRepository();
        public ActionResult Index()
        {
            var Deger=iletisimRepository.List();
            return View(Deger);
        }
    }
}