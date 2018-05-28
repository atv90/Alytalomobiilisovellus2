using Alytalomobiilisovellus2.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MobiiliAlytalo.Views
{
    public class SaunaController : Controller
    {
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
    }
}