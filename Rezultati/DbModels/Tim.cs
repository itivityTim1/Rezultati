//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Rezultati.DbModels
{
    using System;
    using System.Collections.Generic;
    
    public partial class Tim
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tim()
        {
            this.Igrac = new HashSet<Igrac>();
            this.Utakmica = new HashSet<Utakmica>();
            this.Utakmica1 = new HashSet<Utakmica>();
        }
    
        public int TimId { get; set; }
        public string Naziv { get; set; }
        public string Trener { get; set; }
        public string Grad { get; set; }
        public string Stadion { get; set; }
        public int KonferencijaId { get; set; }
        public byte[] Logo { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Igrac> Igrac { get; set; }
        public virtual Konferencija Konferencija { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Utakmica> Utakmica { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Utakmica> Utakmica1 { get; set; }
    }
}
