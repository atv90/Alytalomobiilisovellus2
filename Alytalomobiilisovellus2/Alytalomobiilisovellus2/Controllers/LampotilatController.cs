//using Alytalomobiilisovellus2.Models;
//using Newtonsoft.Json;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using System.Web.Mvc;
////EI KÄYTÖSSÄ!!!!
//namespace Alytalomobiilisovellus2.Controllers
//{
//    public class LampotilatController : Controller
//    {
//        // GET: Lampotila
//        public ActionResult Lampotilat()
//        {
//            return View();
//        }
//        public JsonResult LampotilaTila()
//        {
//            AlyTaloEntities entities = new AlyTaloEntities();
//            var vtila = (from l in entities.Lampotila
//                         select new
//                         {
//                             TavoiteLampotila = l.TavoiteLampotila,
//                             NykyLampotila = l.TaloNykyLampotila
//                         }).ToList();

//            string ltilajson = JsonConvert.SerializeObject(vtila);

//            entities.Dispose();

//            Response.Expires = -1;
//            Response.CacheControl = "no-cache";

//            return Json(ltilajson, JsonRequestBehavior.AllowGet);
//        }
//    }
//}