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
    public class MotoristaController : Controller
    {
        private EstaparContext db = new EstaparContext();

        // GET: Motorista
        public ActionResult Index()
        {
            return View(db.MotoristaEntities.ToList());
        }


        // GET: Motorista/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Motorista/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nome,Cpf,Dt_Nascminento")] MotoristaEntity motoristaEntity)
        {
            if (ModelState.IsValid)
            {
                db.MotoristaEntities.Add(motoristaEntity);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(motoristaEntity);
        }

        // GET: Motorista/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MotoristaEntity motoristaEntity = db.MotoristaEntities.Find(id);
            if (motoristaEntity == null)
            {
                return HttpNotFound();
            }
            return View(motoristaEntity);
        }

        // POST: Motorista/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome,Cpf,Dt_Nascminento")] MotoristaEntity motoristaEntity)
        {
            if (ModelState.IsValid)
            {
                db.Entry(motoristaEntity).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(motoristaEntity);
        }

        // GET: Motorista/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MotoristaEntity motoristaEntity = db.MotoristaEntities.Find(id);
            if (motoristaEntity == null)
            {
                return HttpNotFound();
            }
            return View(motoristaEntity);
        }

        // POST: Motorista/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MotoristaEntity motoristaEntity = db.MotoristaEntities.Find(id);
            db.MotoristaEntities.Remove(motoristaEntity);
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
