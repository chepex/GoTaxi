using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GoTaxiV2.Models;

namespace GoTaxiV2.Controllers
{
    public class CotizacionController : Controller
    {
        private SIGTPPEntities db = new SIGTPPEntities();

        
        // GET: /Cotizacion/





        public ActionResult Index()
        {
            var cotizacion = db.cotizacion.Include(c => c.transporte).Include(c => c.usuario);
            return View(cotizacion.ToList());
        }

        
        // GET: /Cotizacion/Details/5

        public ActionResult Details(int id = 0)
        {
            cotizacion cotizacion = db.cotizacion.Find(id);
            if (cotizacion == null)
            {
                return HttpNotFound();
            }
            return View(cotizacion);
        }

        
        // GET: /Cotizacion/Create

        public ActionResult Create()
        {
            ViewBag.idTipoTransporte = new SelectList(db.transporte, "idTransporte", "nombre");
            ViewBag.idUusario = new SelectList(db.usuario, "idUsuario", "nombre");
            return View();
        }

        
        // POST: /Cotizacion/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(cotizacion cotizacion)
        {
            if (ModelState.IsValid)
            {
                db.cotizacion.Add(cotizacion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idTipoTransporte = new SelectList(db.transporte, "idTransporte", "nombre", cotizacion.idTipoTransporte);
            ViewBag.idUusario = new SelectList(db.usuario, "idUsuario", "nombre", cotizacion.idUusario);
            return View(cotizacion);
        }

        //
        // GET: /Cotizacion/Edit/5

        public ActionResult Edit(int id = 0)
        {
            cotizacion cotizacion = db.cotizacion.Find(id);
            if (cotizacion == null)
            {
                return HttpNotFound();
            }
            ViewBag.idTipoTransporte = new SelectList(db.transporte, "idTransporte", "nombre", cotizacion.idTipoTransporte);
            ViewBag.idUusario = new SelectList(db.usuario, "idUsuario", "nombre", cotizacion.idUusario);
            return View(cotizacion);
        }

        //
        // POST: /Cotizacion/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(cotizacion cotizacion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cotizacion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idTipoTransporte = new SelectList(db.transporte, "idTransporte", "nombre", cotizacion.idTipoTransporte);
            ViewBag.idUusario = new SelectList(db.usuario, "idUsuario", "nombre", cotizacion.idUusario);
            return View(cotizacion);
        }

        //
        // GET: /Cotizacion/Delete/5

        public ActionResult Delete(int id = 0)
        {
            cotizacion cotizacion = db.cotizacion.Find(id);
            if (cotizacion == null)
            {
                return HttpNotFound();
            }
            return View(cotizacion);
        }

        //
        // POST: /Cotizacion/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            cotizacion cotizacion = db.cotizacion.Find(id);
            db.cotizacion.Remove(cotizacion);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}