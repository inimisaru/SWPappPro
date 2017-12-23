using SWPappPro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SWPappPro.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    public class HomeController : Controller
    {
        /// <summary>
        /// Metoda zwracająca widok Index
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// Metoda zwracająca widok LoginLekarz
        /// </summary>
        /// <returns></returns>
        public ActionResult LoginLekarz()
        {
            return View();
        }
        /// <summary>
        /// Metoda wywoływana przy użyciu metody POST po zatwierdzeniu wprowadzonych danych
        /// </summary>
        /// <param name="entity">obiekt LEKARZ z wprowadzonymi PESELEM oraz HASŁEM</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult LoginLekarz(LEKARZ entity)
        {
            //Sprawdz czy dane są poprawne, jeśli tak to przekieruj na stronę główną lekarza
            if (entity.ZalogujLekarz(entity, this.HttpContext))
            {
                return RedirectToAction("Index", "Lekarz");
            }

            else return View("Fail");
        }
        /// <summary>
        /// Metoda zwracająca widok LoginLekarz
        /// </summary>
        /// <returns></returns>
        public ActionResult LoginPacjent()
        {
            return View();
        }
        /// <summary>
        /// Metoda wywoływana przy użyciu metody POST po zatwierdzeniu wprowadzonych danych
        /// </summary>
        /// <param name="entity">obiekt PACJENT z wprowadzonymi PESELEM oraz HASŁEM</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult LoginPacjent(PACJENT entity)
        {
            if (entity.ZalogujPacjent(entity, this.HttpContext))
            {
                return RedirectToAction("Index", "Pacjent");
            }

            else return View("Fail");
        }
        /// <summary>
        /// Metoda wylogowująca użytkownika, resetuje zmienna sesji i zwraca widok ze stroną główną.
        /// </summary>
        /// <returns></returns>
        public ActionResult Logout()
        {
            Session["login"] = null;
            return View("Index");
        }

    }
}