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
    
    public partial class KONSULTACJA_ONLINE
    {
        public Nullable<System.DateTime> DATA { get; set; }
        public string OPIS { get; set; }
        public int KONSULTACJA_ONLINE_ID { get; set; }
        public Nullable<int> PACJENT_ID { get; set; }
        public Nullable<int> KONSULTANT_ID { get; set; }
    
        public virtual KONSULTANT KONSULTANT { get; set; }
        public virtual PACJENT PACJENT { get; set; }
    }
}
