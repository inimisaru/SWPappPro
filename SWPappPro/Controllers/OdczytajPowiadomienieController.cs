﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SWPappPro.Controllers
{
    public class OdczytajPowiadomienieController : Controller
    {
        public ActionResult OdczytajPowiadomienie()
        {
            return View();
        }
        [HttpPost]
        public ActionResult OdczytajPowiadomienieZatwierdz()
        {
            return View("OdczytajPowiadomienieWynik");
        }
    }
}