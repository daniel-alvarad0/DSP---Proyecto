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


    public class EnciclopediasController : Controller
    {
        private Biblioteca_Metropolis_newEntities db = new Biblioteca_Metropolis_newEntities();

        // GET: Enciclopedias
        public async Task<ActionResult> Index()
        {
            var enciclopedia = db.Enciclopedia.Include(e => e.Editorial).Include(e => e.Pais);
            return View(await enciclopedia.ToListAsync());
        }

        // GET: Enciclopedias/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Enciclopedia enciclopedia = await db.Enciclopedia.FindAsync(id);
            if (enciclopedia == null)
            {
                return HttpNotFound();
            }
            return View(enciclopedia);
        }

        // GET: Enciclopedias/Create
        public ActionResult Create()
        {
            ViewBag.IdEdit = new SelectList(db.Editorial, "IdEdit", "Nombre");
            ViewBag.IdPais = new SelectList(db.Pais, "IdPais", "Nombre");
            return View();
        }

        // POST: Enciclopedias/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "IdEnciclopedia,Titulo,AnnoPublic,IdEdit,Edicion,IdPais,PalabraBusqueda")] Enciclopedia enciclopedia)
        {
            if (ModelState.IsValid)
            {
                db.Enciclopedia.Add(enciclopedia);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.IdEdit = new SelectList(db.Editorial, "IdEdit", "Nombre", enciclopedia.IdEdit);
            ViewBag.IdPais = new SelectList(db.Pais, "IdPais", "Nombre", enciclopedia.IdPais);
            return View(enciclopedia);
        }

        // GET: Enciclopedias/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Enciclopedia enciclopedia = await db.Enciclopedia.FindAsync(id);
            if (enciclopedia == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdEdit = new SelectList(db.Editorial, "IdEdit", "Nombre", enciclopedia.IdEdit);
            ViewBag.IdPais = new SelectList(db.Pais, "IdPais", "Nombre", enciclopedia.IdPais);
            return View(enciclopedia);
        }

        // POST: Enciclopedias/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "IdEnciclopedia,Titulo,AnnoPublic,IdEdit,Edicion,IdPais,PalabraBusqueda")] Enciclopedia enciclopedia)
        {
            if (ModelState.IsValid)
            {
                db.Entry(enciclopedia).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.IdEdit = new SelectList(db.Editorial, "IdEdit", "Nombre", enciclopedia.IdEdit);
            ViewBag.IdPais = new SelectList(db.Pais, "IdPais", "Nombre", enciclopedia.IdPais);
            return View(enciclopedia);
        }

        // GET: Enciclopedias/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Enciclopedia enciclopedia = await db.Enciclopedia.FindAsync(id);
            if (enciclopedia == null)
            {
                return HttpNotFound();
            }
            return View(enciclopedia);
        }

        // POST: Enciclopedias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Enciclopedia enciclopedia = await db.Enciclopedia.FindAsync(id);
            db.Enciclopedia.Remove(enciclopedia);
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
