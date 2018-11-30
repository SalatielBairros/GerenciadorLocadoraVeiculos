using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LocadoraVeiculos.Models
{
    public class Aluguel
    {
        [Key]
        public int Id { get; set; }
        [DataType(DataType.Date)]
        [Required]
        [DisplayName("Data Inicial")]
        public DateTime DataInicial { get; set; } = DateTime.Now;
        [DisplayName("Data Final")]
        public DateTime? DataFinal { get; set; } = null;
        [Required]
        [DisplayName("Carro")]
        public int CarroId { get; set; }
        public virtual Carro Carro { get; set; }
        [Required]
        [DisplayName("Cliente")]
        public int ClienteId { get; set; }
        public virtual Cliente Cliente { get; set; }
        [DisplayName("Situação")]
        public StatusAluguel Situacao { get; set; }
        public Status Status { get; set; } = Status.Ativo;
    }
}