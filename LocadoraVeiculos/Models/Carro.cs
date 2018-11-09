using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LocadoraVeiculos.Models
{
    public class Carro
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Modelo { get; set; }
        [Required]
        public string Marca { get; set; }
        [Required]
        public TipoCarro Tipo { get; set; }
        [DisplayName("Valor Diária")]
        public decimal ValorDiaria { get; set; }
        [Required]
        public string Placa { get; set; }
        public string Cor { get; set; }
        public int Ano { get; set; }
        public string Chassi { get; set; }
        [DisplayName("KM")]
        public float Quilomeatragem { get; set; }
    }

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