using Alytalomobiilisovellus2.Models;
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
                             SaunaID = s.SaunaID,
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
        //GET: tietojen muokkaus, tietokannasta selaimeen
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
        //POST: tietojen muokkaus, selaimelta tietokantaan
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
        public ActionResult Update(Sauna sauna)
        {
            AlyTaloEntities entities = new AlyTaloEntities();

            int id = sauna.SaunaID;
            bool OK = false;

            Sauna dbItem = (from s in entities.Sauna
                            where s.SaunaID == id
                            select s).FirstOrDefault();
            //kopioidaan selaimelta saadut tiedot tietokantaan, jos kentän arvo ei ole nolla
            if (dbItem != null)
            {
                dbItem.SaunaID = sauna.SaunaID;
                dbItem.SaunaTila = sauna.SaunaTila;
                dbItem.SaunaNykyLampotila = sauna.SaunaNykyLampotila;

                entities.SaveChanges();
                OK = true;
            }
            entities.Dispose();
            return Json(OK, JsonRequestBehavior.AllowGet);
        }
    }
}