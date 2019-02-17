using Rezultati.DbModels;
using Rezultati.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace Rezultati.Controllers
{
    public class UtakmicaController : Controller
    {
        // GET: Utakmica
        public ActionResult Pregled()
        {
            return View();
        }

        public ActionResult GetGames()
        {
            using(var context = new RezultatiEntities())
            {
                DateTime datum = DateTime.Now.Date;
                var utakmice = context.Utakmica.Where(u => u.DatumOdigravanja == datum).Select(u => new UtakmicaViewModel
                {
                    UtakmicaId = u.UtakmicaId,
                    DatumOdigravanja = u.DatumOdigravanja,
                    Kolo = u.Kolo,
                    GostujuciTimId = u.GostujuciTimId,
                    GostujuciTim = u.Tim1.Grad + " " + u.Tim1.Naziv,
                    DomaciTimId = u.DomaciTimId,
                    DomaciTim = u.Tim.Grad + " " + u.Tim.Naziv,
                    PrvaCetvrtinaDomaci = u.PrvaCetvrtinaDomaci,
                    DrugaCetvrtinaDomaci = u.DrugaCetvrtinaDomaci,
                    TrecaCetvrtinaDomaci = u.TrecaCetvrtinaDomaci,
                    CetvrtaCetvrtinaDomaci = u.CetvrtaCetvrtinaDomaci,
                    PoeniDomaci = u.PrvaCetvrtinaDomaci + u.DrugaCetvrtinaDomaci + u.TrecaCetvrtinaDomaci + u.CetvrtaCetvrtinaDomaci,
                    PrvaCetvrtinaGost = u.PrvaCetvrtinaGost,
                    DrugaCetvrtinaGost = u.DrugaCetvrtinaGost,
                    TrecaCetvrtinaGost = u.TrecaCetvrtinaGost,
                    CetvrtaCetvrtinaGost = u.CetvrtaCetvrtinaGost,
                    PoeniGost = u.PrvaCetvrtinaGost + u.DrugaCetvrtinaGost + u.TrecaCetvrtinaGost + u.CetvrtaCetvrtinaGost
                }).ToList();
                return PartialView("_Utakmice", utakmice);
            }

        }

        public JsonResult ListaTimova()
        {
            using (var context = new RezultatiEntities())
            {
                var timovi = context.Tim.Select(u => new
                {
                    Id = u.TimId,
                    Naziv = u.Grad + " " + u.Naziv
                }).ToList();

                return new JsonResult() { Data = timovi, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
        }

        public ActionResult AddGame(string datum, int kolo, int domaciId, int gostId)
        {
            using (var context = new RezultatiEntities())
            {
                DateTime datumUtakmice = Convert.ToDateTime(datum);
                var dodajUtakmicu = context.Utakmica.Add(new Utakmica
                {
                    DatumOdigravanja = datumUtakmice,
                    Kolo = kolo,
                    DomaciTimId = domaciId,
                    GostujuciTimId = gostId,
                    CetvrtaCetvrtinaDomaci = 0,
                    CetvrtaCetvrtinaGost = 0,
                    DrugaCetvrtinaDomaci = 0,
                    DrugaCetvrtinaGost = 0,
                    PrvaCetvrtinaDomaci = 0,
                    PrvaCetvrtinaGost = 0,
                    TrecaCetvrtinaDomaci = 0,
                    TrecaCetvrtinaGost = 0
                });
                context.SaveChanges();
                var utakmice = context.Utakmica.Where(u => u.DatumOdigravanja == datumUtakmice).Select(u => new UtakmicaViewModel
                {
                    UtakmicaId = u.UtakmicaId,
                    DatumOdigravanja = u.DatumOdigravanja,
                    Kolo = u.Kolo,
                    GostujuciTimId = u.GostujuciTimId,
                    GostujuciTim = u.Tim1.Grad + " " + u.Tim1.Naziv,
                    DomaciTimId = u.DomaciTimId,
                    DomaciTim = u.Tim.Grad + " " + u.Tim.Naziv,
                    PrvaCetvrtinaDomaci = u.PrvaCetvrtinaDomaci,
                    DrugaCetvrtinaDomaci = u.DrugaCetvrtinaDomaci,
                    TrecaCetvrtinaDomaci = u.TrecaCetvrtinaDomaci,
                    CetvrtaCetvrtinaDomaci = u.CetvrtaCetvrtinaDomaci,
                    PoeniDomaci = u.PrvaCetvrtinaDomaci + u.DrugaCetvrtinaDomaci + u.TrecaCetvrtinaDomaci + u.CetvrtaCetvrtinaDomaci,
                    PrvaCetvrtinaGost = u.PrvaCetvrtinaGost,
                    DrugaCetvrtinaGost = u.DrugaCetvrtinaGost,
                    TrecaCetvrtinaGost = u.TrecaCetvrtinaGost,
                    CetvrtaCetvrtinaGost = u.CetvrtaCetvrtinaGost,
                    PoeniGost = u.PrvaCetvrtinaGost + u.DrugaCetvrtinaGost + u.TrecaCetvrtinaGost + u.CetvrtaCetvrtinaGost
                }).ToList();
                return PartialView("_Utakmice", utakmice);

            }
        }

        public JsonResult Result(int id)
        {
            using (var context = new RezultatiEntities())
            {
                var sveUtakmice = context.Utakmica.Where(u => u.UtakmicaId == id).Select(u => new UtakmicaViewModel
                {
                    UtakmicaId = u.UtakmicaId,
                    DatumOdigravanja = u.DatumOdigravanja,
                    Kolo = u.Kolo,
                    GostujuciTimId = u.GostujuciTimId,
                    GostujuciTim = u.Tim1.Grad + " " + u.Tim1.Naziv,
                    DomaciTimId = u.DomaciTimId,
                    DomaciTim = u.Tim.Grad + " " + u.Tim.Naziv,
                    PrvaCetvrtinaDomaci = u.PrvaCetvrtinaDomaci,
                    DrugaCetvrtinaDomaci = u.DrugaCetvrtinaDomaci,
                    TrecaCetvrtinaDomaci = u.TrecaCetvrtinaDomaci,
                    CetvrtaCetvrtinaDomaci = u.CetvrtaCetvrtinaDomaci,
                    PoeniDomaci = u.PrvaCetvrtinaDomaci + u.DrugaCetvrtinaDomaci + u.TrecaCetvrtinaDomaci + u.CetvrtaCetvrtinaDomaci,
                    PrvaCetvrtinaGost = u.PrvaCetvrtinaGost,
                    DrugaCetvrtinaGost = u.DrugaCetvrtinaGost,
                    TrecaCetvrtinaGost = u.TrecaCetvrtinaGost,
                    CetvrtaCetvrtinaGost = u.CetvrtaCetvrtinaGost,
                    PoeniGost = u.PrvaCetvrtinaGost + u.DrugaCetvrtinaGost + u.TrecaCetvrtinaGost + u.CetvrtaCetvrtinaGost
                }).ToList();

                UtakmicaViewModel utakmica = sveUtakmice[0];

                return new JsonResult() { Data = utakmica, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }

        }

        [HttpPost]
        public ActionResult Result(int Id, int PrvaDomaci, int DrugaDomaci, int TrecaDomaci, int CetvrtaDomaci, int PrvaGost, int DrugaGost, int TrecaGost, int CetvrtaGost)
        {
            using (var context = new RezultatiEntities())
            {
                var rezultat = context.Utakmica.Find(Id);
                rezultat.CetvrtaCetvrtinaDomaci = CetvrtaDomaci;
                rezultat.CetvrtaCetvrtinaGost = CetvrtaGost;
                rezultat.DrugaCetvrtinaDomaci = DrugaDomaci;
                rezultat.DrugaCetvrtinaGost = DrugaGost;
                rezultat.PrvaCetvrtinaDomaci = PrvaDomaci;
                rezultat.PrvaCetvrtinaGost = PrvaGost;
                rezultat.TrecaCetvrtinaDomaci = TrecaDomaci;
                rezultat.TrecaCetvrtinaGost = TrecaGost;
                context.SaveChanges();

                DateTime datumUtakmice = rezultat.DatumOdigravanja;
                var utakmice = context.Utakmica.Where(u => u.DatumOdigravanja == datumUtakmice).Select(u => new UtakmicaViewModel
                {
                    UtakmicaId = u.UtakmicaId,
                    DatumOdigravanja = u.DatumOdigravanja,
                    Kolo = u.Kolo,
                    GostujuciTimId = u.GostujuciTimId,
                    GostujuciTim = u.Tim1.Grad + " " + u.Tim1.Naziv,
                    DomaciTimId = u.DomaciTimId,
                    DomaciTim = u.Tim.Grad + " " + u.Tim.Naziv,
                    PrvaCetvrtinaDomaci = u.PrvaCetvrtinaDomaci,
                    DrugaCetvrtinaDomaci = u.DrugaCetvrtinaDomaci,
                    TrecaCetvrtinaDomaci = u.TrecaCetvrtinaDomaci,
                    CetvrtaCetvrtinaDomaci = u.CetvrtaCetvrtinaDomaci,
                    PoeniDomaci = u.PrvaCetvrtinaDomaci + u.DrugaCetvrtinaDomaci + u.TrecaCetvrtinaDomaci + u.CetvrtaCetvrtinaDomaci,
                    PrvaCetvrtinaGost = u.PrvaCetvrtinaGost,
                    DrugaCetvrtinaGost = u.DrugaCetvrtinaGost,
                    TrecaCetvrtinaGost = u.TrecaCetvrtinaGost,
                    CetvrtaCetvrtinaGost = u.CetvrtaCetvrtinaGost,
                    PoeniGost = u.PrvaCetvrtinaGost + u.DrugaCetvrtinaGost + u.TrecaCetvrtinaGost + u.CetvrtaCetvrtinaGost
                }).ToList();
                return PartialView("_Utakmice", utakmice);

            }
        }

        public ActionResult ChangeDate(string datum)
        {
            using (var context = new RezultatiEntities())
            {
                DateTime dtm = Convert.ToDateTime(datum).Date;
                var utakmice = context.Utakmica.Where(u => u.DatumOdigravanja == dtm).Select(u => new UtakmicaViewModel
                {
                    UtakmicaId = u.UtakmicaId,
                    DatumOdigravanja = u.DatumOdigravanja,
                    Kolo = u.Kolo,
                    GostujuciTimId = u.GostujuciTimId,
                    GostujuciTim = u.Tim1.Grad + " " + u.Tim1.Naziv,
                    DomaciTimId = u.DomaciTimId,
                    DomaciTim = u.Tim.Grad + " " + u.Tim.Naziv,
                    PrvaCetvrtinaDomaci = u.PrvaCetvrtinaDomaci,
                    DrugaCetvrtinaDomaci = u.DrugaCetvrtinaDomaci,
                    TrecaCetvrtinaDomaci = u.TrecaCetvrtinaDomaci,
                    CetvrtaCetvrtinaDomaci = u.CetvrtaCetvrtinaDomaci,
                    PoeniDomaci = u.PrvaCetvrtinaDomaci + u.DrugaCetvrtinaDomaci + u.TrecaCetvrtinaDomaci + u.CetvrtaCetvrtinaDomaci,
                    PrvaCetvrtinaGost = u.PrvaCetvrtinaGost,
                    DrugaCetvrtinaGost = u.DrugaCetvrtinaGost,
                    TrecaCetvrtinaGost = u.TrecaCetvrtinaGost,
                    CetvrtaCetvrtinaGost = u.CetvrtaCetvrtinaGost,
                    PoeniGost = u.PrvaCetvrtinaGost + u.DrugaCetvrtinaGost + u.TrecaCetvrtinaGost + u.CetvrtaCetvrtinaGost
                }).ToList();
                return PartialView("_Utakmice", utakmice);
            }
        }


    }
}