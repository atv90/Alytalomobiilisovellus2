using System;
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

        //// GET: Lampotila/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: Lampotila/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "LampotilaID,TavoiteLampotila,TaloNykyLampotila,LämmitysON,LämmitysOFF")] Lampotila lampotila)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Lampotila.Add(lampotila);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    return View(lampotila);
        //}

        // GET: Lampotila/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //haetaan tietokannasta id:tä vastaavan objektin tiedot
            Lampotila lam = db.Lampotila.Find(id);
            if (lam == null)
            {
                return HttpNotFound();
            }
            //LampotilaViewModelista halutut tiedot
            LampotilaViewModel la = new LampotilaViewModel();
            la.LampotilaID = lam.LampotilaID;
            la.TaloNykyLampotila = lam.TaloNykyLampotila;
            la.TavoiteLampotila = lam.TavoiteLampotila;
            //palautetaan la-objektit näkymään
            return View(la);
        }

        // POST: Lampotila/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(LampotilaViewModel model)//mallista tietokantaan tallennettavat tiedot
        {
            Lampotila la = db.Lampotila.Find(model.LampotilaID);
            la.TaloNykyLampotila = model.TaloNykyLampotila;
            la.TavoiteLampotila = model.TavoiteLampotila;
            la.LämmitysON = true;

            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //// GET: Lampotila/Delete/5
        //public ActionResult Delete(int? id)
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

        //// POST: Lampotila/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    Lampotila lampotila = db.Lampotila.Find(id);
        //    db.Lampotila.Remove(lampotila);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}

        //GET: Lampotila/LammitysON
        public ActionResult LammitysON(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //haku tieokannasta id:n perusteella
            Lampotila lam = db.Lampotila.Find(id);
            if (lam == null)
            {
                return HttpNotFound();
            }
            //tietokantatietojen ja LammitysViewModelin la-objektien yhdistäminen
            LampotilaViewModel la = new LampotilaViewModel();
            la.LampotilaID = lam.LampotilaID;
            la.LämmitysON = true;
            la.LämmitysOFF = false;

            return View(la);
        }
        //mitä tallennetaan tietokantaan
        //POST: Lampotila/LammitysON
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LammitysON(LampotilaViewModel model)
        {
            Lampotila la = db.Lampotila.Find(model.LampotilaID);
            la.LampotilaID = model.LampotilaID;
            la.LämmitysON = true;
            la.LämmitysOFF = false;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
