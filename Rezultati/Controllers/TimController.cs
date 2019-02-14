using Rezultati.DbModels;
using Rezultati.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Rezultati.Controllers
{
    public class TimController : Controller
    {
        // GET: Tim
        public ActionResult Index()
        {
            using(var context = new RezultatiEntities())
            {
                var sviTimovi = context.Tim.Select(t => new TimViewModel
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
                    PrimljeniKoseviGostujuci = t.Utakmica.Select(u => u.PrvaCetvrtinaGost + u.DrugaCetvrtinaGost + u.TrecaCetvrtinaGost + u.CetvrtaCetvrtinaGost).Sum()
                }).ToList();

                var timoviKonacna = sviTimovi.Select(t => new TimViewModel
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
                    ProcentPobijeda = Convert.ToDouble(t.DomacePobjede + t.GostujucePobjede) / (t.DomacePobjede + t.GostujucePobjede + t.GostujuciPorazi + t.DomaciPorazi)
                }).ToList();

                return View(timoviKonacna);
            }
        }

        public ActionResult List()
        {
            return View();
        }

        public ActionResult GetTeams()
        {
            using (var context = new RezultatiEntities())
            {
                var sviTimovi = context.Tim.Select(t => new TimViewModel
                {
                    TimId = t.TimId,
                    Naziv = t.Naziv,
                    Grad = t.Grad,
                    Trener = t.Trener,
                    Stadion = t.Stadion
                }).ToList();

                return PartialView("_TabelaTimovi", sviTimovi);
            }
        }
        
        public ActionResult AddTeam(string Naziv, string Grad, string Trener, string Stadion, string Konferencija)
        {
            int konferencijaID = Convert.ToInt32(Konferencija);
            using (var context = new RezultatiEntities())
            {
                var dodajTim = context.Tim.Add(new Tim
                {
                    Naziv = Naziv,
                    Grad = Grad,
                    Trener = Trener,
                    Stadion = Stadion,
                    KonferencijaId = konferencijaID,
                    Logo = new byte[0]
                });
                context.SaveChanges();

                var sviTimovi = context.Tim.Select(t => new TimViewModel
                {
                    TimId = t.TimId,
                    Naziv = t.Naziv,
                    Grad = t.Grad,
                    Trener = t.Trener,
                    Stadion = t.Stadion
                }).ToList();

                return PartialView("_TabelaTimovi", sviTimovi);
            }
        }

        public JsonResult EditTeam(int id)
        {
            using (var context = new RezultatiEntities())
            {
                var timZaIzmjenu = context.Tim.Where(t => t.TimId == id).ToList();

                TimViewModel tim = new TimViewModel
                {
                    TimId = timZaIzmjenu[0].TimId,
                    Grad = timZaIzmjenu[0].Grad,
                    Naziv = timZaIzmjenu[0].Naziv,
                    Trener = timZaIzmjenu[0].Trener,
                    Stadion = timZaIzmjenu[0].Stadion,
                    KonferencijaId = timZaIzmjenu[0].KonferencijaId
                };

                return new JsonResult() { Data = tim, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
        }

        [HttpPost]
        public ActionResult EditTeam(string Id,string Naziv, string Grad, string Trener, string Stadion, string Konferencija)
        {
            int konferencijaID = Convert.ToInt32(Konferencija);
            int timID = Convert.ToInt32(Id);
            using (var context = new RezultatiEntities())
            {
                Tim izmijenjenTim = context.Tim.Find(timID);
                    
                izmijenjenTim.Naziv = Naziv;
                izmijenjenTim.Grad = Grad;
                izmijenjenTim.Trener = Trener;
                izmijenjenTim.Stadion = Stadion;
                izmijenjenTim.KonferencijaId = konferencijaID;
                izmijenjenTim.Logo = new byte[0];
                
                context.SaveChanges();

                var sviTimovi = context.Tim.Select(t => new TimViewModel
                {
                    TimId = t.TimId,
                    Naziv = t.Naziv,
                    Grad = t.Grad,
                    Trener = t.Trener,
                    Stadion = t.Stadion
                }).ToList();

                return PartialView("_TabelaTimovi", sviTimovi);
            }
        }

        public ActionResult DeleteTeam(int id)
        {
            using(var context = new RezultatiEntities())
            {
                var timZaBrisanje = context.Tim.Find(id);
                var brisanjeTime = context.Tim.Remove(timZaBrisanje);
                context.SaveChanges();

                var sviTimovi = context.Tim.Select(t => new TimViewModel
                {
                    TimId = t.TimId,
                    Naziv = t.Naziv,
                    Grad = t.Grad,
                    Trener = t.Trener,
                    Stadion = t.Stadion
                }).ToList();

                return PartialView("_TabelaTimovi", sviTimovi);
            }
        }
        
    }
}