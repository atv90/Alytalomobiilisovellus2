using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;
using Alytalomobiilisovellus2.Models;
using Alytalomobiilisovellus2.ViewModels;


//ADD CONTROLLER: mvc5 with views using EF, model class:Sauna
//kaikki kolme kohtaa raksittuna
//lisää SaunaViewModel ViewsModel-kansioon (kopioi models kansion Sauna.cs-luokan tiedot)

namespace Alytalomobiilisovellus2.Controllers
{
    public class SaunaController : Controller
    {
        private AlyTaloEntities db = new AlyTaloEntities();

        // GET: Sauna
        public ActionResult Index()
        {
            //muodostetaan lista SaunaViewModel-luokan objekteista modeliin, joka palautetaan näkymään
            List<SaunaViewModel> model = new List<SaunaViewModel>();
            //tietokantayhteyden avaaminen
            AlyTaloEntities entities = new AlyTaloEntities();

            //objektien lisäys tietokannasta modeliin try/finally käsittelyllä
            try
            {
                //EF-mallin Sauna-luokan objektien listaus tietokannasta ja 
                //vastaavien SaunaViewModel objektien yhdistäminen
                List<Sauna> sauna = entities.Sauna.ToList();
                foreach (Sauna sau in sauna)
                {
                    SaunaViewModel sa = new SaunaViewModel();
                    sa.SaunaID = sau.SaunaID;
                    sa.SaunaNro = sau.SaunaNro;
                    sa.SaunaNykyLampötila = sau.SaunaNykyLampötila;
                    sa.SaunaTavoiteLampötila = sau.SaunaTavoiteLampötila;
                    sa.SaunaPäällä = sau.SaunaPäällä;
                    sa.SaunaOFF = sau.SaunaOFF;
                    //lisätään sa-objektit modeliin
                    model.Add(sa);
                }
            }
            finally
            {
                entities.Dispose();//tietokantayhteyden sulkeminen
            }
            //näytetään luotu model näkymässä
            return View(model);
        }

        //// GET: Sauna/Details/5
        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Sauna sauna = db.Sauna.Find(id);
        //    if (sauna == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(sauna);
        //}

        // GET: Sauna/Create
        public ActionResult Create()
        {
            //tietokantayhteys ja objektin luominen SaunaViewModelista
            AlyTaloEntities db = new AlyTaloEntities();
            SaunaViewModel model = new SaunaViewModel();
            return View(model);
        }

        // POST: Sauna/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SaunaViewModel sauna)
        //valitaan uuteen riviin luontihetkellä lisättävät tiedot
        {
            //haetaan SaunaViewModelista luotavia sa-objekteja
            //vastaavat tiedot
            Sauna sa = new Sauna();
            sa.SaunaID = sauna.SaunaID;
            sa.SaunaNro = sauna.SaunaNro;
            //lisätään tietokantaan(viitatun db-objektin-luominen sivun ylälaidassa)
            db.Sauna.Add(sa);
            //poikkeuskäsittely
            try
            {
                db.SaveChanges();
            }
            catch (Exception ex)
            {

            }
            //palataan takaisin saunalistaukseen
            return RedirectToAction("Index");
        }

        // GET: Sauna/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //haetaan tietokannasta id:tä vastaavan objektin tiedot
            Sauna sau = db.Sauna.Find(id);
            if (sau == null)
            {
                return HttpNotFound();
            }
            //haetaan SaunaViewModelista tarvittavat(=mitä muokataan ja ID yksilöintiin
            //objektit ja palautetaan ne näkymään
            SaunaViewModel sa = new SaunaViewModel();
            sa.SaunaID = sau.SaunaID;
            sa.SaunaNro = sau.SaunaNro;
            return View(sa);
        }

        // POST: Sauna/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]

        //tietokantaan tallennettavat tiedot
        public ActionResult Edit(SaunaViewModel model)
        {
            Sauna sa = db.Sauna.Find(model.SaunaID);
            sa.SaunaNro = model.SaunaNro;
        
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: Sauna/Delete/5
        public ActionResult Delete(int? id)
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
            return View(sauna);
        }

        // POST: Sauna/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Sauna sauna = db.Sauna.Find(id);
            db.Sauna.Remove(sauna);
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

        //GET: Sauna/SaunaON
        public ActionResult SaunaOn(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sauna sau = db.Sauna.Find(id);
            if(sau == null)
            {
                return HttpNotFound();
            }
            //haetaan halutut tiedot tietokannasta
            SaunaViewModel sa = new SaunaViewModel();
            sa.SaunaID = sau.SaunaID;
            sa.SaunaNro = sau.SaunaNro;
            sa.SaunaNykyLampötila = sau.SaunaNykyLampötila;
            sa.SaunaTavoiteLampötila = sau.SaunaTavoiteLampötila;
            sa.SaunaPäällä = true;
            sa.SaunaOFF = false;

            return View(sa);
        }
        //mitä tallennetaan tietokantaan
        //POST: Sauna/ON
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SaunaON(SaunaViewModel model)
        {
            Sauna sa = db.Sauna.Find(model.SaunaID);
            sa.SaunaID = model.SaunaID;
            sa.SaunaNro = model.SaunaNro;
            sa.SaunaNykyLampötila = model.SaunaNykyLampötila;
            sa.SaunaTavoiteLampötila = model.SaunaTavoiteLampötila;
            sa.SaunaPäällä = true;
            sa.SaunaOFF = false;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
