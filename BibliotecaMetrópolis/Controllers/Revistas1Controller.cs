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

    public class Revistas1Controller : Controller
    {
        private Biblioteca_Metropolis_newEntities db = new Biblioteca_Metropolis_newEntities();

        public async Task<ActionResult> Index()
        {
            var revista = db.Revista.Include(r => r.Editorial).Include(r => r.Pais);
            return View(await revista.ToListAsync());
        }

        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Revista revista = await db.Revista.FindAsync(id);
            if (revista == null)
            {
                return HttpNotFound();
            }
            return View(revista);
        }


        public ActionResult Create()
        {
            ViewBag.IdEdit = new SelectList(db.Editorial, "IdEdit", "Nombre");
            ViewBag.IdPais = new SelectList(db.Pais, "IdPais", "Nombre");
            return View();
        }

      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "IdRevista,Titulo,AnnoPublic,IdEdit,Edicion,IdPais,PalabraBusqueda")] Revista revista)
        {
            if (ModelState.IsValid)
            {
                db.Revista.Add(revista);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.IdEdit = new SelectList(db.Editorial, "IdEdit", "Nombre", revista.IdEdit);
            ViewBag.IdPais = new SelectList(db.Pais, "IdPais", "Nombre", revista.IdPais);
            return View(revista);
        }


        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Revista revista = await db.Revista.FindAsync(id);
            if (revista == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdEdit = new SelectList(db.Editorial, "IdEdit", "Nombre", revista.IdEdit);
            ViewBag.IdPais = new SelectList(db.Pais, "IdPais", "Nombre", revista.IdPais);
            return View(revista);
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "IdRevista,Titulo,AnnoPublic,IdEdit,Edicion,IdPais,PalabraBusqueda")] Revista revista)
        {
            if (ModelState.IsValid)
            {
                db.Entry(revista).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.IdEdit = new SelectList(db.Editorial, "IdEdit", "Nombre", revista.IdEdit);
            ViewBag.IdPais = new SelectList(db.Pais, "IdPais", "Nombre", revista.IdPais);
            return View(revista);
        }

        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Revista revista = await db.Revista.FindAsync(id);
            if (revista == null)
            {
                return HttpNotFound();
            }
            return View(revista);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Revista revista = await db.Revista.FindAsync(id);
            db.Revista.Remove(revista);
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
