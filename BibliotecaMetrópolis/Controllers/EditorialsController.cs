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

//Creadores del Poryecto
//Jeremy Edenilson Flores Portillo - FP240479
//Daniel Ernesto Alvarado Roque - AR220441
//Edgar Josué Gómez Meléndez - GM240279
//Lucía Milena Hernández Bonilla - HB221258


{
    public class EditorialsController : Controller
    {
        private Biblioteca_Metropolis_newEntities db = new Biblioteca_Metropolis_newEntities();

        public async Task<ActionResult> Index()
        {
            return View(await db.Editorial.ToListAsync());
        }

        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Editorial editorial = await db.Editorial.FindAsync(id);
            if (editorial == null)
            {
                return HttpNotFound();
            }
            return View(editorial);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "IdEdit,Nombre")] Editorial editorial)
        {
            if (ModelState.IsValid)
            {
                db.Editorial.Add(editorial);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(editorial);
        }


        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Editorial editorial = await db.Editorial.FindAsync(id);
            if (editorial == null)
            {
                return HttpNotFound();
            }
            return View(editorial);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "IdEdit,Nombre")] Editorial editorial)
        {
            if (ModelState.IsValid)
            {
                db.Entry(editorial).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(editorial);
        }

        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Editorial editorial = await db.Editorial.FindAsync(id);
            if (editorial == null)
            {
                return HttpNotFound();
            }
            return View(editorial);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Editorial editorial = await db.Editorial.FindAsync(id);
            db.Editorial.Remove(editorial);
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
