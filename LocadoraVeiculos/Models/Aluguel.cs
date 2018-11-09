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
        public DateTime Data { get; set; } = DateTime.Now;
        [Required]
        [DisplayName("Carro")]
        public int CarroId { get; set; }
        public virtual Carro Carro { get; set; }
        [Required]
        [DisplayName("Cliente")]
        public int ClienteId { get; set; }
        public virtual Cliente Cliente { get; set; }
        public StatusAluguel Status { get; set; }
    }
}