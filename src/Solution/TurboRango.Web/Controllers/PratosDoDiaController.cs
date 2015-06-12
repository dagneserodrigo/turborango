using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TurboRango.Dominio;
using TurboRango.Web.Models;

namespace TurboRango.Web.Controllers
{
    public class PratosDoDiaController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: PratosDoDia
        public ActionResult Index()
        {
            return View(db.Pratoes.ToList());
        }

        [AllowAnonymous]
        public JsonResult PratoDoDia(int? id)
        {
            var pratoDoDia = db.Pratoes.Where(p => p.Id == id).FirstOrDefault();
            return Json(new
            {
                prato = pratoDoDia
            }, JsonRequestBehavior.AllowGet);
        }

        // GET: PratosDoDia/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PratoDoDia pratoDoDia = db.Pratoes.Find(id);
            if (pratoDoDia == null)
            {
                return HttpNotFound();
            }
            ViewBag.Restaurante = db.Restaurantes.Where(r => r.PratoDoDia.Id == id).First();
            return View(pratoDoDia);
        }

        // GET: PratosDoDia/Create
        public ActionResult Create()
        {
            ViewBag.Restaurantes = db.Restaurantes.Select(r => new { Id = r.Id.ToString(), Nome = r.Nome }).ToList();
            return View();
        }

        // POST: PratosDoDia/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nome,Ingredientes,Valor,DataAtualizacao,Descricao,Restaurante")] PratoDoDiaViewModel pratoDoDia)
        {
            if (ModelState.IsValid)
            {
                var restaurante = db.Restaurantes.Find(pratoDoDia.Restaurante);
                if (restaurante == null)
                {
                    return HttpNotFound();
                }

                var pratoDoDiaDb = new PratoDoDia
                {
                    Nome = pratoDoDia.Nome,
                    Ingredientes = pratoDoDia.Ingredientes,
                    Valor = pratoDoDia.Valor,
                    DataAtualizacao = pratoDoDia.DataAtualizacao,
                    Descricao = pratoDoDia.Descricao
                };

                restaurante.PratoDoDia = pratoDoDiaDb;
                db.Entry(restaurante).State = EntityState.Modified;

                db.Pratoes.Add(pratoDoDiaDb);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pratoDoDia);
        }

        // GET: PratosDoDia/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PratoDoDia pratoDoDia = db.Pratoes.Find(id);
            if (pratoDoDia == null)
            {
                return HttpNotFound();
            }
            ViewBag.Restaurante = db.Restaurantes.Where(r => r.PratoDoDia.Id == id ).First();
            return View(pratoDoDia);
        }

        // POST: PratosDoDia/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome,Ingredientes,Valor,DataAtualizacao,Descricao")] PratoDoDia pratoDoDia)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pratoDoDia).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pratoDoDia);
        }

        // GET: PratosDoDia/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PratoDoDia pratoDoDia = db.Pratoes.Find(id);
            if (pratoDoDia == null)
            {
                return HttpNotFound();
            }
            ViewBag.Restaurante = db.Restaurantes.Where(r => r.PratoDoDia.Id == id).First();
            return View(pratoDoDia);
        }

        // POST: PratosDoDia/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var restaurante = db.Restaurantes.Where(r => r.PratoDoDia.Id == id).First();
            if (restaurante != null)
            {
                restaurante.PratoDoDia = null;
                db.Entry(restaurante).State = EntityState.Modified;
            }
            
            PratoDoDia pratoDoDia = db.Pratoes.Find(id);
            db.Pratoes.Remove(pratoDoDia);
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
