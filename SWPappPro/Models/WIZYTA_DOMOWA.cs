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
    
    public partial class WIZYTA_DOMOWA
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public WIZYTA_DOMOWA()
        {
            this.TERMINARZ = new HashSet<TERMINARZ>();
        }
    
        public int WIZYTA_DOMOWA_ID { get; set; }
        public Nullable<int> PACJENT_ID { get; set; }
        public Nullable<int> LEKARZ_ID { get; set; }
        public string ULICA { get; set; }
        public string KOD_POCZTOWY { get; set; }
        public string NR_DOMU { get; set; }
        public string MIEJSCOWOSC { get; set; }
    
        public virtual LEKARZ LEKARZ { get; set; }
        public virtual PACJENT PACJENT { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TERMINARZ> TERMINARZ { get; set; }
    }
}