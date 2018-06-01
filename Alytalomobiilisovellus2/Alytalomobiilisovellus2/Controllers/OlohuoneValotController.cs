using Alytalomobiilisovellus2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Alytalomobiilisovellus2.Controllers
{
    public class OlohuoneValotController : Controller
    {
        // GET: OlohuoneValot
        public ActionResult Index()
        {
            AlyTaloEntities entities = new AlyTaloEntities();
            List<OlohuoneValot> olohuonevalot = entities.OlohuoneValot.ToList();
            entities.Dispose();
            return View(olohuonevalot);
        }
    }
}