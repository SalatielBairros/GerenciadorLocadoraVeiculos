using LocadoraVeiculos.Infra;
using LocadoraVeiculos.Models;
using LocadoraVeiculos.Security;
using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace LocadoraVeiculos.Controllers
{
    public class ClientesController : Controller
    {
        private Context db = new Context();

        // GET: Clientes
        public ActionResult Index()
        {
            return View(db.Clientes.Where(x => x.Status == Status.Ativo).ToList());
        }

        // GET: Clientes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cliente cliente = db.Clientes.Find(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        // GET: Clientes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Clientes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nome,CPF,RG,Telefone,Endereco,Contato,Tipo")] Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                cliente.StatusCadastro = HttpContext.Session["LOCADORAUSER"] != null ? StatusCadastro.Confirmado : StatusCadastro.Solicitado;
                db.Clientes.Add(cliente);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cliente);
        }

        // GET: Clientes/Edit/5
        [SessionAuthorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cliente cliente = db.Clientes.Find(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        // POST: Clientes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [SessionAuthorize]
        public ActionResult Edit([Bind(Include = "Id,Nome,CPF,RG,Telefone,Endereco,Contato,Tipo")] Cliente cliente)
        {
            if (!ModelState.IsValid) return View(cliente);

            cliente.StatusCadastro = HttpContext.Session["LOCADORAUSER"] != null ? StatusCadastro.Confirmado : StatusCadastro.Solicitado;

            db.Entry(cliente).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [SessionAuthorize]
        // GET: Clientes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cliente cliente = db.Clientes.Find(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        // POST: Clientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [SessionAuthorize]
        public ActionResult DeleteConfirmed(int id)
        {
            Cliente cliente = db.Clientes.Find(id);
            if (cliente == null) throw new Exception("Cliente não cadastrado.");
            cliente.Status = Status.Inativo;
            db.Entry(cliente).State = EntityState.Modified;
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

        [SessionAuthorize]
        public ActionResult Confirmar(int id)
        {
            Cliente cliente = db.Clientes.Find(id);
            if (cliente == null)
                throw new ArgumentException("Cliente não encontrado");

            cliente.StatusCadastro = StatusCadastro.Confirmado;

            db.Entry(cliente).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
