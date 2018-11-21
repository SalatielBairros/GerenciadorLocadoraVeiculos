using System.Data.Entity;
using WebServiceClientes.Models;

namespace WebServiceClientes.Infra
{
    /// <summary>
    /// Contexto do banco de dados.
    /// </summary>
    public class Context : DbContext
    {
        /// <summary>
        /// Definição de clientes como tabela do banco de dados.
        /// </summary>
        public DbSet<CustomerModel> Clientes { get; set; }
    }
}