using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SWPappPro.Models
{
    public class KartaBadanieModel
    {
        public IEnumerable<KARTA_PACJENTA> Karta_pacjenta { get; set; }
        public IEnumerable<BADANIE> Badanie { get; set; }
    }
}