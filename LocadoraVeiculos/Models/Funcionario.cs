using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LocadoraVeiculos.Models
{
    public class Funcionario
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        [DisplayName("E-mail")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [StringLength(maximumLength: 10, MinimumLength = 4, ErrorMessage = "A senha deve conter entre 4 e 10 caracteres")]
        public string Senha { get; set; }
        [DisplayName("Tipo Acesso")]
        public TipoAcessoFuncionario TipoAcesso { get; set; } = TipoAcessoFuncionario.Normal;
    }
}