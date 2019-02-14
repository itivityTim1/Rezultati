using Rezultati.DbModels;
using Rezultati.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Rezultati.Controllers
{
    public class IgracController : Controller
    {
        // GET: Igrac
        public ActionResult List()
        {
            return View();
        }

        public ActionResult GetPlayers()
        {
            using (var context = new RezultatiEntities())
            {
                var sviIgraci = context.Igrac.Select(i => new IgracViewModel
                {
                    IgracId = i.IgracId,
                    Ime = i.Ime,
                    Prezime = i.Prezime,
                    DatumRodjenja = i.DatumRodjenja,
                    MjestoRodjenja = i.MjestoRodjenja,
                    BrojDresa = i.BrojDresa,
                    Pozicija = i.Pozicija,
                    TimId = i.TimId,
                    Tim = i.Tim.Naziv
                }).ToList();

                return PartialView("_TabelaIgraci", sviIgraci);
            }
        }

        public ActionResult AddPlayer(string Ime, string Prezime, string DatumRodjenja, string MjestoRodjenja, short BrojDresa, int Tim, string Pozicija)
        {
            DateTime datumRodjenja = Convert.ToDateTime(DatumRodjenja);
            using (var context = new RezultatiEntities())
            {
                var dodajIgraca = context.Igrac.Add(new Igrac
                {
                    Ime = Ime,
                    Prezime = Prezime,
                    DatumRodjenja = datumRodjenja,
                    MjestoRodjenja = MjestoRodjenja,
                    BrojDresa = BrojDresa,
                    TimId = Tim,
                    Pozicija = Pozicija,
                    Slika = new byte[0]
                });
                context.SaveChanges();

                var sviIgraci = context.Igrac.Select(i => new IgracViewModel
                {
                    IgracId = i.IgracId,
                    Ime = i.Ime,
                    Prezime = i.Prezime,
                    DatumRodjenja = i.DatumRodjenja,
                    MjestoRodjenja = i.MjestoRodjenja,
                    BrojDresa = i.BrojDresa,
                    Pozicija = i.Pozicija,
                    TimId = i.TimId,
                    Tim = i.Tim.Naziv
                }).ToList();

                return PartialView("_TabelaIgraci", sviIgraci);
            }
        }

        public ActionResult EditPlayer(int id)
        {
            using (var context = new RezultatiEntities())
            {
                var igracZaIzmjenu = context.Igrac.Where(t => t.IgracId == id).ToList();

                IgracViewModel igrac = new IgracViewModel
                {
                    IgracId = igracZaIzmjenu[0].IgracId,
                    Ime = igracZaIzmjenu[0].Ime,
                    Prezime = igracZaIzmjenu[0].Prezime,
                    DatumRodjenja = igracZaIzmjenu[0].DatumRodjenja,
                    MjestoRodjenja = igracZaIzmjenu[0].MjestoRodjenja,
                    BrojDresa = igracZaIzmjenu[0].BrojDresa,
                    Pozicija = igracZaIzmjenu[0].Pozicija,
                    TimId = igracZaIzmjenu[0].TimId,
                };

                return new JsonResult() { Data = igrac, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
        }

    }
}