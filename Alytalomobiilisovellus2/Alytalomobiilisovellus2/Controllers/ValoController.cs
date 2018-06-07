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
    public class ValoController : Controller
    {
        private AlyTaloEntities db = new AlyTaloEntities();

        // GET: Valo
        public ActionResult Index()
        {
            List<ValoViewModel> model = new List<ValoViewModel>();
            AlyTaloEntities entities = new AlyTaloEntities();
            try
            {
                List<Valot> valo = entities.Valot.OrderByDescending(Valot => Valot.ValoID).ToList();
                foreach (Valot val in valo)
                {
                    ValoViewModel va = new ValoViewModel();
                    va.ValoID = val.ValoID;
                    va.Valot0 = val.Valot0;
                    va.Valot33 = val.Valot33;
                    va.Valot66 = val.Valot66;
                    va.Valot100 = val.Valot100;
                    va.ValoHuone = val.ValoHuone;
                    va.ValoTime0 = val.ValoTime0;
                    va.ValoTime33 = val.ValoTime33;
                    va.ValoTime66 = val.ValoTime66;
                    va.ValoTime100 = val.ValoTime100;
                    model.Add(va);
                }
            }
            finally
            {
                entities.Dispose();
            }
            return View(model);
        }

        // GET: Valo/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Valot valot = db.Valot.Find(id);
            if (valot == null)
            {
                return HttpNotFound();
            }
            return View(valot);
        }

        // GET: Valo/Create
        public ActionResult Create()
        {
            AlyTaloEntities db = new AlyTaloEntities();
            ValoViewModel model = new ValoViewModel();


            return View(model);
        }

        // POST: Valo/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ValoViewModel model)
        {
            Valot va = new Valot();
            va.ValoID = model.ValoID;
            va.ValoHuone = model.ValoHuone;
            db.Valot.Add(va);
            try
            {
                db.SaveChanges();
            }
            catch(Exception ex)
            {

            }

            return RedirectToAction("Index");
        }

        // GET: Valo/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Valot val = db.Valot.Find(id);
            if (val == null)
            {
                return HttpNotFound();
            }
            ValoViewModel va = new ValoViewModel();
            va.ValoID = val.ValoID;
            //va.Valot0 = val.Valot0;
            //va.Valot33 = val.Valot33;
            //va.Valot66 = val.Valot66;
            //va.Valot100 = val.Valot100;
            va.ValoHuone = val.ValoHuone;
            //va.ValoTime0 = val.ValoTime0;
            //va.ValoTime33 = val.ValoTime33;
            //va.ValoTime66 = val.ValoTime66;
            //va.ValoTime100 = val.ValoTime100;


            return View(va);
        }

        // POST: Valo/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ValoViewModel model)
        {
            Valot va = db.Valot.Find(model.ValoID);
            va.ValoHuone = model.ValoHuone;
            db.SaveChanges();
            return RedirectToAction("Index");
            
        }

        // GET: Valo/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Valot valot = db.Valot.Find(id);
            if (valot == null)
            {
                return HttpNotFound();
            }
            return View(valot);
        }

        // POST: Valo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Valot valot = db.Valot.Find(id);
            db.Valot.Remove(valot);
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
        //GET
        public ActionResult Valo33(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Valot val = db.Valot.Find(id);
            if (val == null)
            {
                return HttpNotFound();
            }
            ValoViewModel va = new ValoViewModel();
            va.ValoID = val.ValoID;
            va.Valot0 = false;
            va.Valot33 = true;
            va.Valot66 = false;
            va.Valot100 = false;
            va.ValoHuone = val.ValoHuone;
            //va.ValoTime0 = val.ValoTime0;
            va.ValoTime33 = val.ValoTime33;
            //va.ValoTime66 = val.ValoTime66;
            //va.ValoTime100 = val.ValoTime100;
            return View(va);
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Valo33(ValoViewModel model)
        {
            Valot va = db.Valot.Find(model.ValoID);

            va.Valot0 = false;
            va.Valot33 = true;
            va.Valot66 = false;
            va.Valot100 = false;
            va.ValoHuone = model.ValoHuone;
            //va.ValoTime0 = val.ValoTime0;
            va.ValoTime33 = DateTime.Now;
            //va.ValoTime66 = DateTime.Now;
            //va.ValoTime100 = DateTime.Now;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
