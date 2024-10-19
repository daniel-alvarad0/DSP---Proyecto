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
    public class RecursoesController : Controller
    {
        private Biblioteca_MetropolisEntities db = new Biblioteca_MetropolisEntities();

        // GET: Recursoes
        public async Task<ActionResult> Index()
        {
            var recurso = db.Recurso.Include(r => r.Editorial).Include(r => r.Pais);
            return View(await recurso.ToListAsync());
        }

        // GET: Recursoes/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Recurso recurso = await db.Recurso.FindAsync(id);
            if (recurso == null)
            {
                return HttpNotFound();
            }
            return View(recurso);
        }

        // GET: Recursoes/Create
        public ActionResult Create()
        {
            ViewBag.IdEdit = new SelectList(db.Editorial, "IdEdit", "Nombre");
            ViewBag.IdPais = new SelectList(db.Pais, "IdPais", "Nombre");
            return View();
        }

        // POST: Recursoes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "IdRec,Titulo,AnnoPublic,IdEdit,Edicion,IdPais,PalabraBusqueda")] Recurso recurso)
        {
            if (ModelState.IsValid)
            {
                db.Recurso.Add(recurso);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.IdEdit = new SelectList(db.Editorial, "IdEdit", "Nombre", recurso.IdEdit);
            ViewBag.IdPais = new SelectList(db.Pais, "IdPais", "Nombre", recurso.IdPais);
            return View(recurso);
        }

        // GET: Recursoes/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Recurso recurso = await db.Recurso.FindAsync(id);
            if (recurso == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdEdit = new SelectList(db.Editorial, "IdEdit", "Nombre", recurso.IdEdit);
            ViewBag.IdPais = new SelectList(db.Pais, "IdPais", "Nombre", recurso.IdPais);
            return View(recurso);
        }

        // POST: Recursoes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "IdRec,Titulo,AnnoPublic,IdEdit,Edicion,IdPais,PalabraBusqueda")] Recurso recurso)
        {
            if (ModelState.IsValid)
            {
                db.Entry(recurso).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.IdEdit = new SelectList(db.Editorial, "IdEdit", "Nombre", recurso.IdEdit);
            ViewBag.IdPais = new SelectList(db.Pais, "IdPais", "Nombre", recurso.IdPais);
            return View(recurso);
        }

        // GET: Recursoes/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Recurso recurso = await db.Recurso.FindAsync(id);
            if (recurso == null)
            {
                return HttpNotFound();
            }
            return View(recurso);
        }

        // POST: Recursoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Recurso recurso = await db.Recurso.FindAsync(id);
            db.Recurso.Remove(recurso);
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
