using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LocadoraVeiculos.Models
{
    public class Cliente
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(maximumLength: 255, ErrorMessage = "O nome do cliente não deve ultrapassar 255 caracteres")]
        public string Nome { get; set; }
        [Required]
        public string CPF { get; set; }
        public string RG { get; set; }
        public string Telefone { get; set; }
        [DisplayName("Endereço")]
        public string Endereco { get; set; }
        public string Contato { get; set; }
        public TipoCliente Tipo { get; set; }
        public Status Status { get; set; } = Status.Ativo;

        [DisplayName("Situação Cadastro")]
        public StatusCadastro StatusCadastro { get; set; } = StatusCadastro.Solicitado;
    }
}