﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Alytalomobiilisovellus2.Models;
using Alytalomobiilisovellus2.ViewModels;

namespace Alytalomobiilisovellus2.Controllers
{
    public class LampotilaController : Controller
    {
        private AlyTaloEntities db = new AlyTaloEntities();

        // GET: Lampotila LampotilaViewModel objektien palauttaminen näkymään
        public ActionResult Index()
        {
            //luodaan uusi model-objekti, joka palautetaan lopuksi näkymään
            List<LampotilaViewModel> model = new List<LampotilaViewModel>();
            //avataan tietokantayhteys
            AlyTaloEntities entities = new AlyTaloEntities();

            //haetaan vastaavat objektit tietokannasta, jotka halutaan mukaan model-objektin listaukseen
            try
            {
                List<Lampotila> lampotila = entities.Lampotila.ToList();
                foreach (Lampotila lam in lampotila)
                {
                    //uusi LampotilaViewModel-objekti, johon tietokantatiedot haetaan
                    LampotilaViewModel la = new LampotilaViewModel();
                    la.LampotilaID = lam.LampotilaID;
                    la.TaloNykyLampotila = lam.TaloNykyLampotila;
                    la.TavoiteLampotila = lam.TavoiteLampotila;
                    la.LämmitysON = lam.LämmitysON;
                    la.LämmitysOFF = lam.LämmitysOFF;
                    //tietokannasta haettuja la-objektien lisääminen model-objektiin
                    model.Add(la);
                }
            }
            finally
            {
                entities.Dispose();
            }
            //model-objektin palautus näkymään
            return View(model);
        }

        //// GET: Lampotila/Details/5
        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Lampotila lampotila = db.Lampotila.Find(id);
        //    if (lampotila == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(lampotila);
        //}

        // GET: Lampotila/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Lampotila/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "LampotilaID,TavoiteLampotila,TaloNykyLampotila,LämmitysON,LämmitysOFF")] Lampotila lampotila)
        {
            if (ModelState.IsValid)
            {
                db.Lampotila.Add(lampotila);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(lampotila);
        }

        // GET: Lampotila/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lampotila lampotila = db.Lampotila.Find(id);
            if (lampotila == null)
            {
                return HttpNotFound();
            }
            return View(lampotila);
        }

        // POST: Lampotila/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "LampotilaID,TavoiteLampotila,TaloNykyLampotila,LämmitysON,LämmitysOFF")] Lampotila lampotila)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lampotila).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(lampotila);
        }

        // GET: Lampotila/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lampotila lampotila = db.Lampotila.Find(id);
            if (lampotila == null)
            {
                return HttpNotFound();
            }
            return View(lampotila);
        }

        // POST: Lampotila/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Lampotila lampotila = db.Lampotila.Find(id);
            db.Lampotila.Remove(lampotila);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
