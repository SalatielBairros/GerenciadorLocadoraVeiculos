using System.ComponentModel.DataAnnotations;

namespace WebServiceClientes.Models
{
    /// <summary>
    /// Informações do cliente.
    /// </summary>
    public class CustomerModel
    {
        /// <summary>
        /// Identificador do cliente. Gerado automaticamente
        /// </summary>
        [Key]
        public int Id { get; set; }
        /// <summary>
        /// Nome do Cliente
        /// </summary>
        [Required]
        [StringLength(maximumLength: 255, ErrorMessage = "O nome do cliente não deve ultrapassar 255 caracteres")]
        public string Nome { get; set; }
        /// <summary>
        /// CPF ou CNPJ do cliente.
        /// </summary>
        [Required]
        [StringLength(maximumLength: 20)]
        public string CPF_CNPJ { get; set; }
        /// <summary>
        /// RG do Cliente
        /// </summary>
        [StringLength(maximumLength: 20)]
        public string RG { get; set; }
        /// <summary>
        /// Status do cliente
        /// </summary>
        [Required]
        public Status Status { get; set; } = Status.Ativo;
        /// <summary>
        /// Status financeiro do cliente
        /// </summary>
        [Required]
        public StatusFinanceiro StatusFinanceiro { get; set; } = StatusFinanceiro.SemPendencias;
    }
}