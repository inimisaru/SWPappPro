using SWPappPro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SWPappPro.Controllers
{
    /// <summary>
    /// Autor: Bartłomiej Balak
    /// Glowny kontroler, do nawigowania po otwarciu aplikacji.
    /// </summary>
    public class HomeController : Controller
    {
        /// <summary>
        /// Metoda w zaleznosci od zmiennej sesji zwraca glowna strone Home lub jesli sesja nie istnieje to do strony Login na której
        /// użytkownik loguje się.
        /// </summary>
        /// <returns>Home</returns>
        /// <returns>Login</returns>
        public ActionResult Index()
        {
            if (Session["login"] == null)
            {
                return View("Login");
            }
            else
            {
                return View("Home");
            }

        }
        public ActionResult Login()
        {
            return View();
        }
        /// <summary>
        /// Metoda, która jest wywoływana po wprowadzeniu danych logowania i wyslaniu ich przy uzyciu POST. Nastepnie sprawdzane sa dane logowania.
        /// W zaleznosci od wyniki uzytkownik przekierowany jest do menu Lekarza lub menu Pacjenta. Jesli wprowadzone zostaly zle dane uzytkownikowi wyswietlana jest strona 
        /// informujaca o blednych danych logowania.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Login(users entity)
        {
            //Wywołanie metody sprawdzajacej dane logowania uzytkownika, metoda zwraca wartosc true/false 
            //w zaleznosci od wyniku operacji walidacji.
            if (entity.ValidateUser(entity, this.HttpContext))
            {
                if (Session["typ"].Equals("lekarz")) return RedirectToAction("Index", "Lekarz");
                else return RedirectToAction("Index", "Pacjent");
            }

            else return View("Fail");
        }
        /// <summary>
        /// Metoda ktora wylogowuje uzytkownika a nastepnie przenosi go do strony logowania
        /// </summary>
        /// <returns></returns>
        public ActionResult Logout()
        {
            Session["login"] = null;
            return View("Login");
        }

    }
}