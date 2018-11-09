using System;
using System.ComponentModel.DataAnnotations;

namespace LocadoraVeiculos.Models
{
    public class Aluguel
    {
        [Key]
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public int CarroId { get; set; }
        public virtual Carro Carro { get; set; }
        public int ClienteId { get; set; }
        public virtual Cliente Cliente { get; set; }
        public StatusAluguel Status { get; set; }

    }
}