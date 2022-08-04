using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using CvWebsite.Models.Entity;

namespace CvWebsite.Controllers
{
    [AllowAnonymous]
    public class AdminController : Controller
    {
        // GET: Admin
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(TbAdmin tbAdmin)
        {
            DbCVEntities dbCVEntities = new DbCVEntities();
            var Admn=dbCVEntities.TbAdmin.FirstOrDefault(x=>x.UserName==tbAdmin.UserName && x.Password==tbAdmin.Password);
            if (Admn!=null)
            {
                FormsAuthentication.SetAuthCookie(Admn.UserName, false);
                Session["UserName"] = Admn.UserName.ToString();
                return RedirectToAction("Index","Hakkimda");
                    
            }
            else
            {
                return RedirectToAction("Index", "Admin");
            }
        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index", "Admin");
        }

    }
}