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
    
    public partial class KARTA_PACJENTA
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public KARTA_PACJENTA()
        {
            this.BADANIE = new HashSet<BADANIE>();
        }
    
        public int KARTA_PACJENTA_ID { get; set; }
        public string NUMER_KARTY { get; set; }
        public Nullable<System.DateTime> DATA_ZALOZENIA { get; set; }
        public int WLASCICIEL { get; set; }
        public Nullable<int> PROWADZACY { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BADANIE> BADANIE { get; set; }
        public virtual LEKARZ LEKARZ { get; set; }
        public virtual PACJENT PACJENT { get; set; }
    }
}
