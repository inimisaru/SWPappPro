﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.Entity;
using System.Net;
using SWPappPro.Models;



namespace SWPappPro.Controllers
{
    /// <summary>
    /// Autor: Dawid Stefański
    /// Kontroler do sterowania pomiędzy stronami oraz komunikujący się z klasami danych (Models)
    /// </summary>
    public class PodejrzyjSwojaKartePacjentaController : Controller
    {
        private SWPappDBEntities4 db = new SWPappDBEntities4();
        /// <summary>
        /// Metoda służąca do zwracania widoku domyślnej strony.
        /// </summary>
        /// <returns>widok strony PodejrzyjSwojaKartePacjenta</returns>
        public ActionResult PodejrzyjSwojaKartePacjenta()
        {
            int id = (int)Session["id"];

            var viewModel = new KartaBadanieModel();

            viewModel.Karta_pacjenta = db.KARTA_PACJENTA.Where(k => k.KARTA_PACJENTA_ID == id);

            viewModel.Badanie = db.BADANIE.Where(b => b.KARTA_PACJENTA_ID == id);

            return View(viewModel);
        }
    }
}