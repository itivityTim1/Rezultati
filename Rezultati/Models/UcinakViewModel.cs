using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Rezultati.Models
{
    public class UcinakViewModel
    {
        public int UcinakId { get; set; }
        public int UtakmicaId { get; set; }
        public int IgracId { get; set; }
        public string ImeIgraca { get; set; }
        public string Tim { get; set; }
        public short BrojMinuta { get; set; }
        public short BrojPoena { get; set; }
        public short BrojAsistencija { get; set; }
        public short BrojSkokova { get; set; }
        public short PokusajiIzIgre { get; set; }
        public short PogodjeniSutevi { get; set; }
        public short SlobodnaBacanja { get; set; }
        public short PogodjenaBacanja { get; set; }
        public short LicneGreske { get; set; }
        public short SuteviZaTri { get; set; }
        public short PogodjeniZaTri { get; set; }
        public short UkradeneLopte { get; set; }
        public short Blokovi { get; set; }
        public short IzgubljeneLopte { get; set; }
    }
}