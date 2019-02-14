using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Rezultati.Models
{
    public class IgracViewModel
    {
        public int? IgracId { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public DateTime? DatumRodjenja { get; set; }
        public string MjestoRodjenja { get; set; }
        public short? BrojDresa { get; set; }
        public int? TimId { get; set; }
        public string Tim { get; set; }
        public string Pozicija { get; set; }
    }
}