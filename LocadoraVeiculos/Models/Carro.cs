using System.ComponentModel.DataAnnotations;

namespace LocadoraVeiculos.Models
{
    public class Carro
    {
        [Key]
        public int Id { get; set; }
        public string Modelo { get; set; }
        public string Marca { get; set; }
        public TipoCarro Tipo { get; set; }
        public string ValorDiaria { get; set; }
        public string Placa { get; set; }
        public string Cor { get; set; }
        public int Ano { get; set; }
        public string Chassi { get; set; }
        public float Quilomeatragem { get; set; }
    }
}