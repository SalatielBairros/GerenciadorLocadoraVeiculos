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
        [DisplayName("Situação")]
        public StatusCarro Situacao { get; set; } = StatusCarro.Disponivel;
        public Status Status { get; set; } = Status.Ativo;
    }
}