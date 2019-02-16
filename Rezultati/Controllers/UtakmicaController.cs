﻿using Rezultati.DbModels;
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

    }
}