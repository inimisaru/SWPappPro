﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SWPappPro.Controllers
{
    public class WystawOpinieController : Controller
    {
        public ActionResult WystawOpinie()
        {
            return View();
        }
        [HttpPost]
        public ActionResult WystawOpinieZatwierdz()
        {
            return View("WystawOpinieWynik");
        }
    }
}