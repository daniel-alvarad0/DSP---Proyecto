using System;
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

    //Creadores del Poryecto
    //Jeremy Edenilson Flores Portillo - FP240479
    //Daniel Ernesto Alvarado Roque - AR220441
    //Edgar Josué Gómez Meléndez - GM240279
    //Lucía Milena Hernández Bonilla - HB221258


    public class PaisController : Controller
    {
        private Biblioteca_Metropolis_newEntities db = new Biblioteca_Metropolis_newEntities();

        public async Task<ActionResult> Index()
        {
            return View(await db.Pais.ToListAsync());
        }

        public async Task<ActionResult> Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pais pais = await db.Pais.FindAsync(id);
            if (pais == null)
            {
                return HttpNotFound();
            }
            return View(pais);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "IdPais,Nombre")] Pais pais)
        {
            if (ModelState.IsValid)
            {
                db.Pais.Add(pais);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(pais);
        }

        public async Task<ActionResult> Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pais pais = await db.Pais.FindAsync(id);
            if (pais == null)
            {
                return HttpNotFound();
            }
            return View(pais);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "IdPais,Nombre")] Pais pais)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pais).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(pais);
        }

        public async Task<ActionResult> Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pais pais = await db.Pais.FindAsync(id);
            if (pais == null)
            {
                return HttpNotFound();
            }
            return View(pais);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            Pais pais = await db.Pais.FindAsync(id);
            db.Pais.Remove(pais);
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
