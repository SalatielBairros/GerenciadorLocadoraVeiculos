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
        /// Construtor padrão da classe.
        /// </summary>
        public Context() : base("RemoteConnection")
        {

        }

        /// <summary>
        /// Definição de clientes como tabela do banco de dados.
        /// </summary>
        public DbSet<CustomerModel> Clientes { get; set; }
        /// <summary>
        /// Definição de Endereços como tabela do banco de dados.
        /// </summary>
        public DbSet<Enderecos> Enderecos { get; set; }
    }
}