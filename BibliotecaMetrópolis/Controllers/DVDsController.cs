﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BibliotecaMetrópolis;

namespace BibliotecaMetrópolis.Controllers
{
    public class DVDsController : Controller
    {
        private Biblioteca_Metropolis_newEntities db = new Biblioteca_Metropolis_newEntities();

        // GET: DVDs
        public async Task<ActionResult> Index()
        {
            var dVD = db.DVD.Include(d => d.Editorial).Include(d => d.Pais);
            return View(await dVD.ToListAsync());
        }

        // GET: DVDs/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DVD dVD = await db.DVD.FindAsync(id);
            if (dVD == null)
            {
                return HttpNotFound();
            }
            return View(dVD);
        }

        // GET: DVDs/Create
        public ActionResult Create()
        {
            ViewBag.IdEdit = new SelectList(db.Editorial, "IdEdit", "Nombre");
            ViewBag.IdPais = new SelectList(db.Pais, "IdPais", "Nombre");
            return View();
        }

        // POST: DVDs/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "IdDVD,Titulo,AnnoPublic,IdEdit,IdPais,PalabraBusqueda")] DVD dVD)
        {
            if (ModelState.IsValid)
            {
                db.DVD.Add(dVD);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.IdEdit = new SelectList(db.Editorial, "IdEdit", "Nombre", dVD.IdEdit);
            ViewBag.IdPais = new SelectList(db.Pais, "IdPais", "Nombre", dVD.IdPais);
            return View(dVD);
        }

        // GET: DVDs/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DVD dVD = await db.DVD.FindAsync(id);
            if (dVD == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdEdit = new SelectList(db.Editorial, "IdEdit", "Nombre", dVD.IdEdit);
            ViewBag.IdPais = new SelectList(db.Pais, "IdPais", "Nombre", dVD.IdPais);
            return View(dVD);
        }

        // POST: DVDs/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "IdDVD,Titulo,AnnoPublic,IdEdit,IdPais,PalabraBusqueda")] DVD dVD)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dVD).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.IdEdit = new SelectList(db.Editorial, "IdEdit", "Nombre", dVD.IdEdit);
            ViewBag.IdPais = new SelectList(db.Pais, "IdPais", "Nombre", dVD.IdPais);
            return View(dVD);
        }

        // GET: DVDs/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DVD dVD = await db.DVD.FindAsync(id);
            if (dVD == null)
            {
                return HttpNotFound();
            }
            return View(dVD);
        }

        // POST: DVDs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            DVD dVD = await db.DVD.FindAsync(id);
            db.DVD.Remove(dVD);
            await db.SaveChangesAsync();
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
    }
}
