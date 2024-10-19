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
    public class EditorialsController : Controller
    {
        private Biblioteca_MetropolisEntities db = new Biblioteca_MetropolisEntities();

        // GET: Editorials
        public async Task<ActionResult> Index()
        {
            return View(await db.Editorial.ToListAsync());
        }

        // GET: Editorials/Details/5
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

        // GET: Editorials/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Editorials/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
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

        // GET: Editorials/Edit/5
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

        // POST: Editorials/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
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

        // GET: Editorials/Delete/5
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

        // POST: Editorials/Delete/5
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
