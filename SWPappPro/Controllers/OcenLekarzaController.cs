using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SWPappPro.Controllers
{
    public class OcenLekarzaController : Controller
    {
        /// <summary>
        /// Metoda zwracają stronę z listą ocen dla lekarza pobraną z bazy danych.
        /// Wewnatrz metody zostanie wywołana funkcja realizujaca dostęp do bazy danych na podstawie identyfikatora lekarza.
        /// Identyfikator lekarza zostanie pobrany ze zmiennych sesji.
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }
    }
}