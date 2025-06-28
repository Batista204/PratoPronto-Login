using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using PratoPronto.Models;

namespace PratoPronto.Controllers
{
    public class PratosController : Controller
    {
        private PratoContext db = new PratoContext();

        public ActionResult Index()
        {
            return View(db.Pratos.ToList());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            Prato prato = db.Pratos.Find(id);
            if (prato == null)
                return HttpNotFound();

            return View(prato);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nome,Descricao,Preco,Foto,Categoria")] Prato prato)
        {
            if (ModelState.IsValid)
            {
                db.Pratos.Add(prato);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(prato);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            Prato prato = db.Pratos.Find(id);
            if (prato == null)
                return HttpNotFound();

            return View(prato);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome,Descricao,Preco,Foto,Categoria")] Prato prato)
        {
            if (ModelState.IsValid)
            {
                db.Entry(prato).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(prato);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            Prato prato = db.Pratos.Find(id);
            if (prato == null)
                return HttpNotFound();

            return View(prato);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Prato prato = db.Pratos.Find(id);
            db.Pratos.Remove(prato);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
                db.Dispose();

            base.Dispose(disposing);
        }
    }
}
