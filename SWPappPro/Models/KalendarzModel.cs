using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SWPappPro.Models
{
    public class KalendarzModel
    {
        public IEnumerable<TERMINARZ> Terminarz { get; set; }
        public IEnumerable<WIZYTA_DOMOWA> Wizyta_domowa { get; set; }
        public IEnumerable<WIZYTA_KONSULTACYJNA> Wizyta_konsultacyjna { get; set; }
        public IEnumerable<WIZYTA_DOMOWA> Wizyta_domowaStala { get; set; }
        public IEnumerable<WIZYTA_KONSULTACYJNA> Wizyta_konsultacyjnaStala { get; set; }

    }
}