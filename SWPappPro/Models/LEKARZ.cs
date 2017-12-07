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
    using System.Web;
    using System.Linq;

    public partial class LEKARZ
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LEKARZ()
        {
            this.BADANIE = new HashSet<BADANIE>();
            this.GABINET = new HashSet<GABINET>();
            this.KARTA_PACJENTA = new HashSet<KARTA_PACJENTA>();
            this.OPINIA = new HashSet<OPINIA>();
            this.POWIADOMIENIE = new HashSet<POWIADOMIENIE>();
            this.TERMINARZ = new HashSet<TERMINARZ>();
            this.WIZYTA_DOMOWA = new HashSet<WIZYTA_DOMOWA>();
            this.WIZYTA_KONSULTACYJNA = new HashSet<WIZYTA_KONSULTACYJNA>();
        }
    
        public int LEKARZ_ID { get; set; }
        public string IMIE { get; set; }
        public string NAZWISKO { get; set; }
        public string SPECJALIZACJA { get; set; }
        public string PESEL { get; set; }
        public Nullable<System.DateTime> DATA_URODZENIA { get; set; }
        public string NR_LICENCJI { get; set; }
        public string HASLO { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BADANIE> BADANIE { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GABINET> GABINET { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KARTA_PACJENTA> KARTA_PACJENTA { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OPINIA> OPINIA { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<POWIADOMIENIE> POWIADOMIENIE { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TERMINARZ> TERMINARZ { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WIZYTA_DOMOWA> WIZYTA_DOMOWA { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WIZYTA_KONSULTACYJNA> WIZYTA_KONSULTACYJNA { get; set; }

        public bool ZalogujLekarz(LEKARZ entity, HttpContextBase current)
        {

            var db = new SWPappDBEntities();
            //pobranie z bazy danych rekordu o nazwie uzytkownika takiej jak podanej w entity(czyli danych z formularza)
            var pass = db.LEKARZ.Where(s => s.PESEL == entity.PESEL.Trim()).FirstOrDefault();
            //jesli rekord istnieje
            if (pass != null)
            {
                //por�wnanie hase�
                if (entity.HASLO.Equals(pass.HASLO.Trim()))
                {
                        current.Session["typ"] = "lekarz";
                        current.Session["login"] = pass.PESEL;
                        current.Session["id"] = pass.LEKARZ_ID;
                    return true;

                }
                return false;
            }
            else
            {
                return false;
            }
            
        }


    }

}
