using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using LocadoraVeiculos.Models;

namespace LocadoraVeiculos.Infra
{
    public class Context : DbContext
    {
        public Context() : base("RemoteConnection")
        {
            this.Configuration.LazyLoadingEnabled = true;
        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Carro> Carros{ get; set; }
        public DbSet<Aluguel> Alugueis { get; set; }
        public DbSet<Pagamentos> Pagamentos { get; set; }
        public DbSet<Funcionario> Funcionarios { get; set; }
    }
}