//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SWPappPro.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class OPINIA
    {
        public int OPINIA_ID { get; set; }
        public Nullable<int> NUMER_OPINII { get; set; }
        public string TRESC { get; set; }
        public Nullable<int> OCENA { get; set; }
        public Nullable<int> LEKARZ_ID { get; set; }
        public Nullable<int> PACJENT_ID { get; set; }
    
        public virtual LEKARZ LEKARZ { get; set; }
        public virtual PACJENT PACJENT { get; set; }
    }
}
