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
    public class AutoresRecursosController : Controller
    {
        private Biblioteca_MetropolisEntities db = new Biblioteca_MetropolisEntities();

        // GET: AutoresRecursos
        public async Task<ActionResult> Index()
        {
            var autoresRecursos = db.AutoresRecursos.Include(a => a.Autor).Include(a => a.Recurso);
            return View(await autoresRecursos.ToListAsync());
        }

        // GET: AutoresRecursos/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AutoresRecursos autoresRecursos = await db.AutoresRecursos.FindAsync(id);
            if (autoresRecursos == null)
            {
                return HttpNotFound();
            }
            return View(autoresRecursos);
        }

        // GET: AutoresRecursos/Create
        public ActionResult Create()
        {
            ViewBag.IdAutor = new SelectList(db.Autor, "IdAutor", "Nombre");
            ViewBag.IdRec = new SelectList(db.Recurso, "IdRec", "Titulo");
            return View();
        }

        // POST: AutoresRecursos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "IdRecAutor,IdRec,IdAutor,EsPrincipal")] AutoresRecursos autoresRecursos)
        {
            if (ModelState.IsValid)
            {
                db.AutoresRecursos.Add(autoresRecursos);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.IdAutor = new SelectList(db.Autor, "IdAutor", "Nombre", autoresRecursos.IdAutor);
            ViewBag.IdRec = new SelectList(db.Recurso, "IdRec", "Titulo", autoresRecursos.IdRec);
            return View(autoresRecursos);
        }

        // GET: AutoresRecursos/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AutoresRecursos autoresRecursos = await db.AutoresRecursos.FindAsync(id);
            if (autoresRecursos == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdAutor = new SelectList(db.Autor, "IdAutor", "Nombre", autoresRecursos.IdAutor);
            ViewBag.IdRec = new SelectList(db.Recurso, "IdRec", "Titulo", autoresRecursos.IdRec);
            return View(autoresRecursos);
        }

        // POST: AutoresRecursos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "IdRecAutor,IdRec,IdAutor,EsPrincipal")] AutoresRecursos autoresRecursos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(autoresRecursos).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.IdAutor = new SelectList(db.Autor, "IdAutor", "Nombre", autoresRecursos.IdAutor);
            ViewBag.IdRec = new SelectList(db.Recurso, "IdRec", "Titulo", autoresRecursos.IdRec);
            return View(autoresRecursos);
        }

        // GET: AutoresRecursos/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AutoresRecursos autoresRecursos = await db.AutoresRecursos.FindAsync(id);
            if (autoresRecursos == null)
            {
                return HttpNotFound();
            }
            return View(autoresRecursos);
        }

        // POST: AutoresRecursos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            AutoresRecursos autoresRecursos = await db.AutoresRecursos.FindAsync(id);
            db.AutoresRecursos.Remove(autoresRecursos);
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
