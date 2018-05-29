﻿using Alytalomobiilisovellus2.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Alytalomobiilisovellus2.Controllers
{
    public class SaunaController : Controller
    {
        private AlyTaloEntities db = new AlyTaloEntities();
        // GET: Sauna
        public ActionResult Sauna()
        {
            return View();
        }
        public JsonResult SaunanTila()
        {
            //tietokantahaku
            AlyTaloEntities entities = new AlyTaloEntities();

            //JavaScript-objektin luominen tietokannasta
            var stila = (from s in entities.Sauna
                         select new
                         {
                             SaunanTila = s.SaunaTila,
                             SaunanLampotila = s.SaunaNykyLampotila

                         }).ToList();

            //stila-objekti JSON-muotoon
            string stilajson = JsonConvert.SerializeObject(stila);

            entities.Dispose(); //muistin vapautus

            //välimuistin hallinta
            Response.Expires = -1;
            Response.CacheControl = "no-cache";

            //tulosten palautus
            return Json(stilajson, JsonRequestBehavior.AllowGet);
        }
        //GET: tietojen muokkaus
        public ActionResult MuokkaaSauna(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sauna sauna = db.Sauna.Find(id);
            if (sauna == null)
            {
                return HttpNotFound();
            }
            SaunaData s = new SaunaData();
            s.SaunaTila = sauna.SaunaTila;
            s.SaunaNykyLampotila = sauna.SaunaNykyLampotila;

            return View(s);
        }
        //POST: tietojen muokkaus
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult MuokkaaSauna(SaunaData model)
        {
            Sauna s = db.Sauna.Find(model.SaunaTila);
            s.SaunaTila = model.SaunaTila;
            s.SaunaNykyLampotila = model.SaunaNykyLampotila;

            db.SaveChanges();

            return RedirectToAction("Sauna");
        } 
    }
}