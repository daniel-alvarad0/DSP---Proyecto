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


    public class LibroesController : Controller
    {
        private Biblioteca_Metropolis_newEntities db = new Biblioteca_Metropolis_newEntities();

        public async Task<ActionResult> Index(String Buscar)
        {
            var libro = db.Libro.Include(l => l.Editorial).Include(l => l.Pais);
            
            return View(await libro.ToListAsync());
        }

        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Libro libro = await db.Libro.FindAsync(id);
            if (libro == null)
            {
                return HttpNotFound();
            }
            return View(libro);
        }
        public ActionResult Create()
        {
            ViewBag.IdEdit = new SelectList(db.Editorial, "IdEdit", "Nombre");
            ViewBag.IdPais = new SelectList(db.Pais, "IdPais", "Nombre");
            return View();
        }

    
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "IdLibro,Titulo,AnnoPublic,IdEdit,Edicion,IdPais,PalabraBusqueda")] Libro libro)
        {
            if (ModelState.IsValid)
            {
                db.Libro.Add(libro);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.IdEdit = new SelectList(db.Editorial, "IdEdit", "Nombre", libro.IdEdit);
            ViewBag.IdPais = new SelectList(db.Pais, "IdPais", "Nombre", libro.IdPais);
            return View(libro);
        }


        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Libro libro = await db.Libro.FindAsync(id);
            if (libro == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdEdit = new SelectList(db.Editorial, "IdEdit", "Nombre", libro.IdEdit);
            ViewBag.IdPais = new SelectList(db.Pais, "IdPais", "Nombre", libro.IdPais);
            return View(libro);
        }

     
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "IdLibro,Titulo,AnnoPublic,IdEdit,Edicion,IdPais,PalabraBusqueda")] Libro libro)
        {
            if (ModelState.IsValid)
            {
                db.Entry(libro).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.IdEdit = new SelectList(db.Editorial, "IdEdit", "Nombre", libro.IdEdit);
            ViewBag.IdPais = new SelectList(db.Pais, "IdPais", "Nombre", libro.IdPais);
            return View(libro);
        }

     
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Libro libro = await db.Libro.FindAsync(id);
            if (libro == null)
            {
                return HttpNotFound();
            }
            return View(libro);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Libro libro = await db.Libro.FindAsync(id);
            db.Libro.Remove(libro);
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
