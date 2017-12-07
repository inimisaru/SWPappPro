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
    /// <summary>
    /// Klasa modelu danych odpowiadająca za mapujaca na encje tablicy LEKARZ
    /// </summary>
    public partial class LEKARZ
    {
        /// <summary>
        /// Konstruktor klasy LEKARZ
        /// </summary>
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
        /// <summary>
        /// Pararametr LEKARZ_ID
        /// </summary>
        public int LEKARZ_ID { get; set; }
        /// <summary>
        /// Pararametr IMIE
        /// </summary>
        public string IMIE { get; set; }
        /// <summary>
        /// Pararametr NAZWISKO
        /// </summary>
        public string NAZWISKO { get; set; }
        /// <summary>
        /// Pararametr SPECJALIZACJA
        /// </summary>
        public string SPECJALIZACJA { get; set; }
        /// <summary>
        /// Pararametr PESEL
        /// </summary>
        public string PESEL { get; set; }
        /// <summary>
        /// Pararametr DATA_URODZENIA
        /// </summary>
        public Nullable<System.DateTime> DATA_URODZENIA { get; set; }
        /// <summary>
        /// Pararametr NR_LICENCJI
        /// </summary>
        public string NR_LICENCJI { get; set; }
        /// <summary>
        /// Pararametr HASLO
        /// </summary>
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

        /// <summary>
        /// Metoda odpowiadająca za walidacje logowania do systemu jako lekarz
        /// </summary>
        /// <param name="entity"></param> Obiekt z wprowadzonymi przez uzytkownika danymi podlegającymi sprawdzeniu
        /// <param name="current"></param>Obiekt przechowujący odwołonie do sesji użytkownika
        /// <returns></returns>
        public bool ZalogujLekarz(LEKARZ entity, HttpContextBase current)
        {

            var db = new SWPappDBEntities();
            //pobranie z bazy danych rekordu o nazwie uzytkownika takiej jak podanej w entity(czyli danych z formularza)
            var pass = db.LEKARZ.Where(s => s.PESEL == entity.PESEL.Trim()).FirstOrDefault();
            //jesli rekord istnieje
            if (pass != null)
            {
                //porównanie haseł
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
