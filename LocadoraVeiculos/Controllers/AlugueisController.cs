using System;
using LocadoraVeiculos.Infra;
using LocadoraVeiculos.Models;
using LocadoraVeiculos.Security;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace LocadoraVeiculos.Controllers
{
    public class AlugueisController : Controller
    {
        private Context db = new Context();

        // GET: Alugueis
        public ActionResult Index()
        {
            var alugueis = db.Alugueis.Include(a => a.Carro).Include(a => a.Cliente);
            return View(alugueis.ToList());
        }

        // GET: Alugueis/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Aluguel aluguel = db.Alugueis.Find(id);
            if (aluguel == null)
            {
                return HttpNotFound();
            }
            return View(aluguel);
        }

        // GET: Alugueis/Create
        [SessionAuthorize]
        public ActionResult Create()
        {
            ViewBag.CarroId = new SelectList(db.Carros, "Id", "Modelo");
            ViewBag.ClienteId = new SelectList(db.Clientes, "Id", "Nome");
            return View();
        }

        // POST: Alugueis/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [SessionAuthorize]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Data,CarroId,ClienteId,Status")] Aluguel aluguel)
        {
            if (ModelState.IsValid)
            {
                var carro = db.Carros.Find(aluguel.CarroId);
                if (carro == null) throw new ArgumentException("Carro não encontrado.");
                carro.Status =
                    (aluguel.Status == StatusAluguel.Finalizado ? StatusCarro.Disponivel : StatusCarro.Reservado);

                db.Alugueis.Add(aluguel);
                db.SaveChanges();
                db.Entry(carro).State = EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            ViewBag.CarroId = new SelectList(db.Carros, "Id", "Modelo", aluguel.CarroId);
            ViewBag.ClienteId = new SelectList(db.Clientes, "Id", "Nome", aluguel.ClienteId);
            return View(aluguel);
        }

        // GET: Alugueis/Edit/5
        [SessionAuthorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Aluguel aluguel = db.Alugueis.Find(id);
            if (aluguel == null)
            {
                return HttpNotFound();
            }
            ViewBag.CarroId = new SelectList(db.Carros, "Id", "Modelo", aluguel.CarroId);
            ViewBag.ClienteId = new SelectList(db.Clientes, "Id", "Nome", aluguel.ClienteId);
            return View(aluguel);
        }

        // POST: Alugueis/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [SessionAuthorize]
        public ActionResult Edit([Bind(Include = "Id,Data,CarroId,ClienteId,Status")] Aluguel aluguel)
        {
            if (ModelState.IsValid)
            {
                var carro = db.Carros.Find(aluguel.CarroId);
                if (carro == null) throw new ArgumentException("Carro não encontrado.");
                carro.Status = aluguel.Status == StatusAluguel.Finalizado ? StatusCarro.Disponivel : StatusCarro.Reservado;

                db.Entry(aluguel).State = EntityState.Modified;
                db.Entry(carro).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CarroId = new SelectList(db.Carros, "Id", "Modelo", aluguel.CarroId);
            ViewBag.ClienteId = new SelectList(db.Clientes, "Id", "Nome", aluguel.ClienteId);
            return View(aluguel);
        }

        // GET: Alugueis/Delete/5
        [SessionAuthorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Aluguel aluguel = db.Alugueis.Find(id);
            if (aluguel == null)
            {
                return HttpNotFound();
            }
            return View(aluguel);
        }

        // POST: Alugueis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [SessionAuthorize]
        public ActionResult DeleteConfirmed(int id)
        {
            Aluguel aluguel = db.Alugueis.Find(id);
            db.Alugueis.Remove(aluguel);
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
