using SWPappPro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SWPappPro.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult LoginLekarz()
        {
            return View();
        }
        [HttpPost]
        public ActionResult LoginLekarz(LEKARZ entity)
        {
            if (entity.ZalogujLekarz(entity, this.HttpContext))
            {
                return RedirectToAction("Index", "Lekarz");
            }

            else return View("Fail");
        }
        public ActionResult LoginPacjent()
        {
            return View();
        }
        [HttpPost]
        public ActionResult LoginPacjent(PACJENT entity)
        {
            if (entity.ZalogujPacjent(entity, this.HttpContext))
            {
                return RedirectToAction("Index", "Pacjent");
            }

            else return View("Fail");
        }
        public ActionResult Logout()
        {
            Session["login"] = null;
            return View("Index");
        }

    }
}