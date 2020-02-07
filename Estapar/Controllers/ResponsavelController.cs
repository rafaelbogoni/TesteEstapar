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
    public class ResponsavelController : Controller
    {
        private EstaparContext db = new EstaparContext();

        // GET: Responsavel
        public ActionResult Index()
        {
            return View(db.ResponsavelEntities.ToList());
        }


        // GET: Responsavel/Create
        public ActionResult Create()
        {
            var lista = db.MotoristaEntities.Where(x => x.Nome != string.Empty).ToList();
       
            var itensSelecionaveis = new List<SelectListItem>();

            foreach (var item in lista)
            {
                itensSelecionaveis.Add(new SelectListItem
                {
                    Value = item.Id.ToString(),
                    Text = item.Nome
                });
            }

            ViewBag.ListaMotorista = itensSelecionaveis;

            return View();
        }

        // POST: Responsavel/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Responsavel,Carro,IdMotorista")] ResponsavelEntity responsavelEntity)
        {
            int id = int.Parse(responsavelEntity.Responsavel);
            if (ModelState.IsValid)
            {
                responsavelEntity.IdMotorista = db.MotoristaEntities.Find(id).Id;
                responsavelEntity.Responsavel = db.MotoristaEntities.Find(id).Nome;
                db.ResponsavelEntities.Add(responsavelEntity);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(responsavelEntity);
        }

        // GET: Responsavel/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ResponsavelEntity responsavelEntity = db.ResponsavelEntities.Find(id);
            if (responsavelEntity == null)
            {
                return HttpNotFound();
            }
            return View(responsavelEntity);
        }

        // POST: Responsavel/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Responsavel,Carro,IdMotorista")] ResponsavelEntity responsavelEntity)
        {
            if (ModelState.IsValid)
            {
                db.Entry(responsavelEntity).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(responsavelEntity);
        }

        // GET: Responsavel/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ResponsavelEntity responsavelEntity = db.ResponsavelEntities.Find(id);
            if (responsavelEntity == null)
            {
                return HttpNotFound();
            }
            return View(responsavelEntity);
        }

        // POST: Responsavel/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ResponsavelEntity responsavelEntity = db.ResponsavelEntities.Find(id);
            db.ResponsavelEntities.Remove(responsavelEntity);
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
