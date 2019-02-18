using Rezultati.DbModels;
using Rezultati.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Rezultati.Controllers
{
    public class UcinakController : Controller
    {
        // GET: Ucinak
        //public ActionResult TeamDetails()
        //{
        //    return View();
        //}
        
        public ActionResult TeamDetails(int TimId)
        {
            using(var context = new RezultatiEntities())
            {
                var tim = context.Tim.Where(t => t.TimId == TimId).Select(t => new TimViewModel
                {
                    TimId = t.TimId,
                    Naziv = t.Naziv,
                    Grad = t.Grad,
                    Trener = t.Trener,
                    Stadion = t.Stadion,
                    KonferencijaId = t.KonferencijaId,
                    DomacePobjede = t.Utakmica.Where(u => (u.PrvaCetvrtinaDomaci + u.DrugaCetvrtinaDomaci + u.TrecaCetvrtinaDomaci + u.CetvrtaCetvrtinaDomaci) >
                        (u.PrvaCetvrtinaGost + u.DrugaCetvrtinaGost + u.TrecaCetvrtinaGost + u.CetvrtaCetvrtinaGost)).Count(),
                    GostujucePobjede = t.Utakmica1.Where(u => (u.PrvaCetvrtinaDomaci + u.DrugaCetvrtinaDomaci + u.TrecaCetvrtinaDomaci + u.CetvrtaCetvrtinaDomaci) <
                        (u.PrvaCetvrtinaGost + u.DrugaCetvrtinaGost + u.TrecaCetvrtinaGost + u.CetvrtaCetvrtinaGost)).Count(),
                    DomaciPorazi = t.Utakmica.Where(u => (u.PrvaCetvrtinaDomaci + u.DrugaCetvrtinaDomaci + u.TrecaCetvrtinaDomaci + u.CetvrtaCetvrtinaDomaci) <
                        (u.PrvaCetvrtinaGost + u.DrugaCetvrtinaGost + u.TrecaCetvrtinaGost + u.CetvrtaCetvrtinaGost)).Count(),
                    GostujuciPorazi = t.Utakmica1.Where(u => (u.PrvaCetvrtinaDomaci + u.DrugaCetvrtinaDomaci + u.TrecaCetvrtinaDomaci + u.CetvrtaCetvrtinaDomaci) >
                        (u.PrvaCetvrtinaGost + u.DrugaCetvrtinaGost + u.TrecaCetvrtinaGost + u.CetvrtaCetvrtinaGost)).Count(),
                    PostignutiKoseviDomaci = t.Utakmica.Select(u => u.PrvaCetvrtinaDomaci + u.DrugaCetvrtinaDomaci + u.TrecaCetvrtinaDomaci + u.CetvrtaCetvrtinaDomaci).Sum(),
                    PostignutiKoseviGostujuci = t.Utakmica1.Select(u => u.PrvaCetvrtinaGost + u.DrugaCetvrtinaGost + u.TrecaCetvrtinaGost + u.CetvrtaCetvrtinaGost).Sum(),
                    PrimljeniKoseviDomaci = t.Utakmica1.Select(u => u.PrvaCetvrtinaDomaci + u.DrugaCetvrtinaDomaci + u.TrecaCetvrtinaDomaci + u.CetvrtaCetvrtinaDomaci).Sum(),
                    PrimljeniKoseviGostujuci = t.Utakmica.Select(u => u.PrvaCetvrtinaGost + u.DrugaCetvrtinaGost + u.TrecaCetvrtinaGost + u.CetvrtaCetvrtinaGost).Sum(),
                    Igraci = t.Igrac.Select(i => new IgracViewModel()
                    {
                        IgracId = i.IgracId,
                        Ime = i.Ime,
                        Prezime = i.Prezime,
                        BrojDresa = i.BrojDresa ,
                        DatumRodjenja = i.DatumRodjenja,
                        MjestoRodjenja = i.MjestoRodjenja,
                        Pozicija = i.Pozicija,
                        TimId = i.TimId,
                        Tim = t.Naziv
                    }).ToList()
                }).ToList();

                var timKonacna = tim.Select(t => new TimViewModel
                {
                    TimId = t.TimId,
                    Naziv = t.Naziv,
                    Grad = t.Grad,
                    Trener = t.Trener,
                    Stadion = t.Stadion,
                    KonferencijaId = t.KonferencijaId,
                    DomacePobjede = t.DomacePobjede,
                    GostujucePobjede = t.GostujucePobjede,
                    Pobjede = t.DomacePobjede + t.GostujucePobjede,
                    GostujuciPorazi = t.GostujuciPorazi,
                    DomaciPorazi = t.DomaciPorazi,
                    Porazi = t.GostujuciPorazi + t.DomaciPorazi,
                    PostignutiKoseviDomaci = t.PostignutiKoseviDomaci,
                    PostignutiKoseviGostujuci = t.PostignutiKoseviGostujuci,
                    PostignutiKosevi = Convert.ToInt32(t.PostignutiKoseviDomaci) + Convert.ToInt32(t.PostignutiKoseviGostujuci),
                    PrimljeniKoseviDomaci = t.PrimljeniKoseviDomaci,
                    PrimljeniKoseviGostujuci = t.PrimljeniKoseviGostujuci,
                    PrimljeniKosevi = Convert.ToInt32(t.PrimljeniKoseviDomaci) + Convert.ToInt32(t.PrimljeniKoseviGostujuci),
                    ProcentPobijeda = Convert.ToDouble(t.DomacePobjede + t.GostujucePobjede) / (t.DomacePobjede + t.GostujucePobjede + t.GostujuciPorazi + t.DomaciPorazi),
                    Igraci = t.Igraci
                    
                }).ToList();

                TimViewModel timStat = timKonacna[0];

                return View(timStat);
            }
        }
    }
}