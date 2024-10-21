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
using System.Web.UI.WebControls;

//Creadores del Poryecto
//Jeremy Edenilson Flores Portillo - FP240479
//Daniel Ernesto Alvarado Roque - AR220441
//Edgar Josué Gómez Meléndez - GM240279
//Lucía Milena Hernández Bonilla - HB221258


namespace BibliotecaMetrópolis.Controllers
{
    public class AutoresRecursosController : Controller
    {
        private Biblioteca_Metropolis_newEntities db = new Biblioteca_Metropolis_newEntities();

        // GET: AutoresRecursos
        public async Task<ActionResult> Index()
        {
            var autoresRecursos = db.AutoresRecursos.Include(a => a.Autor);
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
            return View();
        }

        // POST: AutoresRecursos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "IdRecAutor,IdRecurso,TipoRecurso,IdAutor,EsPrincipal")] AutoresRecursos autoresRecursos)
        {
            if (ModelState.IsValid)
            {
                db.AutoresRecursos.Add(autoresRecursos);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.IdAutor = new SelectList(db.Autor, "IdAutor", "Nombre", autoresRecursos.IdAutor);
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
            return View(autoresRecursos);
        }

        // POST: AutoresRecursos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "IdRecAutor,IdRecurso,TipoRecurso,IdAutor,EsPrincipal")] AutoresRecursos autoresRecursos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(autoresRecursos).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.IdAutor = new SelectList(db.Autor, "IdAutor", "Nombre", autoresRecursos.IdAutor);
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
