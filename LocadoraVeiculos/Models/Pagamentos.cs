using System;
using System.ComponentModel.DataAnnotations;

namespace LocadoraVeiculos.Models
{
    public class Pagamentos
    {
        [Key]
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public decimal Valor { get; set; }

        public int FuncionarioId { get; set; }
        public virtual Funcionario Funcionario { get; set; }
        public int AluguelId { get; set; }
        public virtual Aluguel Aluguel { get; set; }
    }
}