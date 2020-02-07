using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Estapar.Data;
using TesteEstapar.Models;

namespace Estapar.Controllers
{
    public class CarroController : Controller
    {
        private EstaparContext db = new EstaparContext();

        // GET: Carro
        public ActionResult Index()
        {
            return View(db.CarroEntities.ToList());
        }

        // GET: Carro/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CarroEntity carroEntity = db.CarroEntities.Find(id);
            if (carroEntity == null)
            {
                return HttpNotFound();
            }
            return View(carroEntity);
        }

        // GET: Carro/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Carro/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nome,Placa")] CarroEntity carroEntity)
        {
            if (ModelState.IsValid)
            {
                db.CarroEntities.Add(carroEntity);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(carroEntity);
        }

        // GET: Carro/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CarroEntity carroEntity = db.CarroEntities.Find(id);
            if (carroEntity == null)
            {
                return HttpNotFound();
            }
            return View(carroEntity);
        }

        // POST: Carro/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome,Placa")] CarroEntity carroEntity)
        {
            if (ModelState.IsValid)
            {
                db.Entry(carroEntity).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(carroEntity);
        }

        // GET: Carro/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CarroEntity carroEntity = db.CarroEntities.Find(id);
            if (carroEntity == null)
            {
                return HttpNotFound();
            }
            return View(carroEntity);
        }

        // POST: Carro/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CarroEntity carroEntity = db.CarroEntities.Find(id);
            db.CarroEntities.Remove(carroEntity);
            db.SaveChanges();
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
