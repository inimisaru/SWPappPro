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
    
    public partial class KONSULTANT
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public KONSULTANT()
        {
            this.KONSULTACJA_ONLINE = new HashSet<KONSULTACJA_ONLINE>();
        }
    
        public string GODZINY_KONSULTACJI { get; set; }
        public string IMIE { get; set; }
        public string NAZWISKO { get; set; }
        public string SPECJALIZACJA { get; set; }
        public string NR_LICENCJI { get; set; }
        public Nullable<System.DateTime> DATA_URODZENIA { get; set; }
        public int KONSULTANT_ID { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KONSULTACJA_ONLINE> KONSULTACJA_ONLINE { get; set; }
    }
}
