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
//    public class ValaistusController : Controller
//    {
//        // GET: Valaistus
//        public ActionResult Valaistus()
//        {
//            return View();
//        }
       
//        public JsonResult ValaistusTila()
//        {
//            AlyTaloEntities entities = new AlyTaloEntities();
//            var vtila = (from v in entities.Valo
//                         select new
//                         {
//                             ValaistusTila = v.ValoTila,
//                             ValaistusMaara = v.ValoMaara
//                         }).ToList();

//            string vtilajson = JsonConvert.SerializeObject(vtila);

//            entities.Dispose();

//            Response.Expires = -1;
//            Response.CacheControl = "no-cache";

//            return Json(vtilajson, JsonRequestBehavior.AllowGet);
//        }
//    }
//}