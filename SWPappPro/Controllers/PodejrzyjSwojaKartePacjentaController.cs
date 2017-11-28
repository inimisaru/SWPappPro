using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SWPappPro.Controllers
{
    public class PodejrzyjSwojaKartePacjentaController : Controller
    {
        // GET: PodejrzyjSwojaKartePacjentaForm
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult PodejrzyjSwojaKartePacjenta()
        {
            return View();
        }
    }
}