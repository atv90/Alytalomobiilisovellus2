//using Alytalomobiilisovellus2.Models;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using System.Web.Mvc;

//namespace Alytalomobiilisovellus2.Controllers
//{
//    public class OlohuoneValotController : Controller
//    {
//        // GET: OlohuoneValot
//        public ActionResult Index(int id)
//        {
//            int valoid = id;
//            AlyTaloEntities entities = new AlyTaloEntities();

//            var olohuonevalot = (from ov in entities.Valot
//                                 where ov.ValoID == valoid
//                                 select new
//                                 {
//                                     ValotPaalla = ov.ValotPaalla,
//                                     Valot0 = ov.Valot0,
//                                     Valot33 = ov.Valot33,
//                                     Valot66 = ov.Valot66,
//                                     Valot100 = ov.Valot100
//                                 }).FirstOrDefault();

//            ViewBag.ValotPaalla = olohuonevalot.ValotPaalla;
//            ViewBag.Valot0 = olohuonevalot.Valot0;
//            ViewBag.Valot33 = olohuonevalot.Valot33;
//            ViewBag.Valot66 = olohuonevalot.Valot66;
//            ViewBag.Valot100 = olohuonevalot.Valot100;
            

//            entities.Dispose();
//            return View(olohuonevalot);
//        }
//    }
//}