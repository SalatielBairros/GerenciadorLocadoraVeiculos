using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WebServiceClientes.Infra;
using WebServiceClientes.Models;

namespace WebServiceClientes.Controllers
{
    /// <summary>
    /// Serviços relacionados aos clientes.
    /// Caso ocorra algum erro, os códigos de erro e mensagens serão referente às padrões do HTTP.
    /// </summary>
    public class CustomerModelsController : ApiController
    {
        private Context db = new Context();

        // GET: api/CustomerModels
        /// <summary>
        /// Listar todos os clientes
        /// </summary>
        /// <returns>Lista dos clientes disponíveis no sistema</returns>
        public IQueryable<CustomerModel> GetClientes()
        {
            return db.Clientes;
        }

        // GET: api/CustomerModels/5
        /// <summary>
        /// Buscar cliente específico
        /// </summary>
        /// <param name="id">Id do cliente a ser buscado</param>
        /// <returns>Cliente</returns>
        [ResponseType(typeof(CustomerModel))]
        public IHttpActionResult GetCustomerModel(int id)
        {
            CustomerModel customerModel = db.Clientes.Find(id);
            if (customerModel == null)
            {
                return NotFound();
            }

            return Ok(customerModel);
        }

        // PUT: api/CustomerModels/5
        /// <summary>
        /// Inserir/Anterar um cliente
        /// </summary>
        /// <param name="id">Id do cliente a ser alterado</param>
        /// <param name="customerModel">Dados do cliente</param>
        /// <returns></returns>
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCustomerModel(int id, CustomerModel customerModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != customerModel.Id)
            {
                return BadRequest();
            }

            db.Entry(customerModel).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerModelExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/CustomerModels
        /// <summary>
        /// Insere um cliente novo no sistema
        /// </summary>
        /// <param name="customerModel"></param>
        /// <returns></returns>
        [ResponseType(typeof(CustomerModel))]
        public IHttpActionResult PostCustomerModel(CustomerModel customerModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Clientes.Add(customerModel);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = customerModel.Id }, customerModel);
        }

        // DELETE: api/CustomerModels/5
        /// <summary>
        /// Remove um cliente do sistema
        /// </summary>
        /// <param name="id">Cliente a ser removido</param>
        /// <returns></returns>
        [ResponseType(typeof(CustomerModel))]
        public IHttpActionResult DeleteCustomerModel(int id)
        {
            CustomerModel customerModel = db.Clientes.Find(id);
            if (customerModel == null)
            {
                return NotFound();
            }

            db.Clientes.Remove(customerModel);
            db.SaveChanges();

            return Ok(customerModel);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CustomerModelExists(int id)
        {
            return db.Clientes.Count(e => e.Id == id) > 0;
        }
    }
}