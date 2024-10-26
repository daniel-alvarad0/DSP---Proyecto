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


    public class Tesis1Controller : Controller
    {
        private Biblioteca_Metropolis_newEntities db = new Biblioteca_Metropolis_newEntities();

        public async Task<ActionResult> Index()
        {
            var tesis = db.Tesis.Include(t => t.Pais);
            return View(await tesis.ToListAsync());
        }

      
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tesis tesis = await db.Tesis.FindAsync(id);
            if (tesis == null)
            {
                return HttpNotFound();
            }
            return View(tesis);
        }

     
        public ActionResult Create()
        {
            ViewBag.IdPais = new SelectList(db.Pais, "IdPais", "Nombre");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "IdTesis,Titulo,AnnoPublic,InstitucionEducativa,IdPais,PalabraBusqueda")] Tesis tesis)
        {
            if (ModelState.IsValid)
            {
                db.Tesis.Add(tesis);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.IdPais = new SelectList(db.Pais, "IdPais", "Nombre", tesis.IdPais);
            return View(tesis);
        }

  
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tesis tesis = await db.Tesis.FindAsync(id);
            if (tesis == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdPais = new SelectList(db.Pais, "IdPais", "Nombre", tesis.IdPais);
            return View(tesis);
        }

 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "IdTesis,Titulo,AnnoPublic,InstitucionEducativa,IdPais,PalabraBusqueda")] Tesis tesis)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tesis).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.IdPais = new SelectList(db.Pais, "IdPais", "Nombre", tesis.IdPais);
            return View(tesis);
        }

        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tesis tesis = await db.Tesis.FindAsync(id);
            if (tesis == null)
            {
                return HttpNotFound();
            }
            return View(tesis);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Tesis tesis = await db.Tesis.FindAsync(id);
            db.Tesis.Remove(tesis);
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
