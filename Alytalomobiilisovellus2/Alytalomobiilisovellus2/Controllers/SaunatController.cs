//using Alytalomobiilisovellus2.Models;
//using Newtonsoft.Json;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Net;
//using System.Web;
//using System.Web.Mvc;
////EI KÄYTÖSSÄ!!!!
//namespace Alytalomobiilisovellus2.Controllers
//{
//    public class SaunatController : Controller
//    {
//        private AlyTaloEntities db = new AlyTaloEntities();
//        // GET: Sauna
//        public ActionResult Saunat()
//        {
//            return View();
//        }
//        public JsonResult SaunanTila()
//        {
//            //tietokantahaku
//            AlyTaloEntities entities = new AlyTaloEntities();

//            //JavaScript-objektin luominen tietokannasta
//            var stila = (from s in entities.Sauna
//                         select new
//                         {
//                             SaunaID = s.SaunaID,
//                             SaunanTila = s.SaunaNro,
//                             SaunanLampotila = s.SaunaNykyLampötila

//                         }).ToList();

//            //stila-objekti JSON-muotoon
//            string stilajson = JsonConvert.SerializeObject(stila);

//            entities.Dispose(); //muistin vapautus

//            //välimuistin hallinta
//            Response.Expires = -1;
//            Response.CacheControl = "no-cache";

//            //tulosten palautus
//            return Json(stilajson, JsonRequestBehavior.AllowGet);
//        }

//        //saunan tietojen haku tietokannasta ID:n perusteella
//        public JsonResult HaeSauna(int id)
//        {
//            AlyTaloEntities entities = new AlyTaloEntities();
//            var sauna = (from s in entities.Sauna
//                         where s.SaunaID == id
//                         select new
//                         {
//                             SaunaID = s.SaunaID,
//                             SaunanTila = s.SaunaNro,
//                             SaunanLampotila = s.SaunaNykyLampötila
//                         }).FirstOrDefault();
//            string saunajson = JsonConvert.SerializeObject(sauna);
//            entities.Dispose();
//            return Json(saunajson, JsonRequestBehavior.AllowGet);
//        }

//        //GET: tietojen muokkaus, tietokannasta selaimeen
//        public ActionResult MuokkaaSauna(int? id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            Sauna sauna = db.Sauna.Find(id);
//            if (sauna == null)
//            {
//                return HttpNotFound();
//            }
//            SaunaData s = new SaunaData();
//            s.SaunaTila = sauna.SaunaNro;
//            s.SaunaNykyLampotila = sauna.SaunaNykyLampötila;

//            return View(s);
//        }
//        //POST: tietojen muokkaus, selaimelta tietokantaan
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult MuokkaaSauna(SaunaData model)
//        {
//            Sauna s = db.Sauna.Find(model.SaunaTila);
//            s.SaunaNro = model.SaunaTila;
//            s.SaunaNykyLampötila = model.SaunaNykyLampotila;

//            db.SaveChanges();

//            return RedirectToAction("Sauna");
//        }
//        public ActionResult Update(Sauna sauna)
//        {
//            AlyTaloEntities entities = new AlyTaloEntities();

//            int id = sauna.SaunaID;
//            bool OK = false;

//            Sauna dbItem = (from s in entities.Sauna
//                            where s.SaunaID == id
//                            select s).FirstOrDefault();
//            //kopioidaan selaimelta saadut tiedot tietokantaan, jos kentän arvo ei ole nolla
//            if (dbItem != null)
//            {
//                dbItem.SaunaID = sauna.SaunaID;
//                dbItem.SaunaNro = sauna.SaunaNro;
//                dbItem.SaunaNykyLampötila = sauna.SaunaNykyLampötila;

//                entities.SaveChanges();
//                OK = true;
//            }
//            entities.Dispose();
//            return Json(OK, JsonRequestBehavior.AllowGet);
//        }
//    }
//}