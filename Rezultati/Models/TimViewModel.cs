using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Rezultati.Models
{
    public class TimViewModel
    {
        public int TimId { get; set; }
        public string Naziv { get; set; }
        public string Trener { get; set; }
        public string Grad { get; set; }
        public string Stadion { get; set; }
        public int KonferencijaId { get; set; }
        public int? DomacePobjede { get; set; }
        public int? GostujucePobjede { get; set; }
        public int? Pobjede { get; set; }
        public int? DomaciPorazi { get; set; }
        public int? GostujuciPorazi { get; set; }
        public int? Porazi { get; set; }
        public int? PostignutiKosevi { get; set; }
        public int? PostignutiKoseviDomaci { get; set; }
        public int? PostignutiKoseviGostujuci { get; set; }
        public int? PrimljeniKosevi { get; set; }
        public int? PrimljeniKoseviDomaci { get; set; }
        public int? PrimljeniKoseviGostujuci { get; set; }
        public double? ProcentPobijeda { get; set; }
    }
}