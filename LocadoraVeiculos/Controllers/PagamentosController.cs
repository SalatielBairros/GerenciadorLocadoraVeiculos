using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LocadoraVeiculos.Infra;
using LocadoraVeiculos.Models;

namespace LocadoraVeiculos.Controllers
{
    public class PagamentosController : Controller
    {
        private Context db = new Context();

        // GET: Pagamentos
        public ActionResult Index()
        {
            var pagamentos = db.Pagamentos.Include(p => p.Aluguel).Include(p => p.Funcionario);
            return View(pagamentos.ToList());
        }

        // GET: Pagamentos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pagamentos pagamentos = db.Pagamentos.Find(id);
            if (pagamentos == null)
            {
                return HttpNotFound();
            }
            return View(pagamentos);
        }

        // GET: Pagamentos/Create
        public ActionResult Create()
        {
            ViewBag.AluguelId = new SelectList(db.Alugueis, "Id", "Id");
            ViewBag.FuncionarioId = new SelectList(db.Funcionarios, "Id", "Nome");
            return View();
        }

        // POST: Pagamentos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Data,Valor,FuncionarioId,AluguelId")] Pagamentos pagamentos)
        {
            if (ModelState.IsValid)
            {
                db.Pagamentos.Add(pagamentos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AluguelId = new SelectList(db.Alugueis, "Id", "Id", pagamentos.AluguelId);
            ViewBag.FuncionarioId = new SelectList(db.Funcionarios, "Id", "Nome", pagamentos.FuncionarioId);
            return View(pagamentos);
        }

        // GET: Pagamentos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pagamentos pagamentos = db.Pagamentos.Find(id);
            if (pagamentos == null)
            {
                return HttpNotFound();
            }
            ViewBag.AluguelId = new SelectList(db.Alugueis, "Id", "Id", pagamentos.AluguelId);
            ViewBag.FuncionarioId = new SelectList(db.Funcionarios, "Id", "Nome", pagamentos.FuncionarioId);
            return View(pagamentos);
        }

        // POST: Pagamentos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Data,Valor,FuncionarioId,AluguelId")] Pagamentos pagamentos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pagamentos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AluguelId = new SelectList(db.Alugueis, "Id", "Id", pagamentos.AluguelId);
            ViewBag.FuncionarioId = new SelectList(db.Funcionarios, "Id", "Nome", pagamentos.FuncionarioId);
            return View(pagamentos);
        }

        // GET: Pagamentos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pagamentos pagamentos = db.Pagamentos.Find(id);
            if (pagamentos == null)
            {
                return HttpNotFound();
            }
            return View(pagamentos);
        }

        // POST: Pagamentos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Pagamentos pagamentos = db.Pagamentos.Find(id);
            db.Pagamentos.Remove(pagamentos);
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
