using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Rezultati.Models
{
    public class UtakmicaViewModel
    {
        public int UtakmicaId { get; set; }
        public System.DateTime DatumOdigravanja { get; set; }
        public int Kolo { get; set; }
        public int DomaciTimId { get; set; }
        public string DomaciTim { get; set; }
        public int GostujuciTimId { get; set; }
        public string GostujuciTim { get; set; }
        public int PrvaCetvrtinaDomaci { get; set; }
        public int PrvaCetvrtinaGost { get; set; }
        public int DrugaCetvrtinaDomaci { get; set; }
        public int DrugaCetvrtinaGost { get; set; }
        public int TrecaCetvrtinaDomaci { get; set; }
        public int TrecaCetvrtinaGost { get; set; }
        public int CetvrtaCetvrtinaDomaci { get; set; }
        public int CetvrtaCetvrtinaGost { get; set; }
        public int PoeniDomaci { get; set; }
        public int PoeniGost { get; set; }
    }
}