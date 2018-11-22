using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebServiceClientes.Models
{
    /// <summary>
    /// Endereços Cliente
    /// </summary>
    public class Enderecos
    {
        /// <summary>
        /// Identificador do endereço. Gerado automaticamente
        /// </summary>
        [Key]
        public int Id { get; set; }
        /// <summary>
        /// Logradouro do endereço do cliente
        /// </summary>
        [Required]
        [StringLength(maximumLength: 255, ErrorMessage = "O campo logradouro não deve ultrapassar 255 caracteres")]
        public string Logradouro { get; set; }
        /// <summary>
        /// Número do cliente
        /// </summary>
        [StringLength(maximumLength: 5, ErrorMessage = "O campo número não deve ultrapassar 5 caracteres")]
        [DisplayName("Número")]
        public string Numero { get; set; }
        /// <summary>
        /// Bairro do endereço do cliente
        /// </summary>
        [StringLength(maximumLength: 255, ErrorMessage = "O campo bairro não deve ultrapassar 255 caracteres")]
        public string Bairro { get; set; }
        /// <summary>
        /// Cidade onde o endereço é localizado.
        /// </summary>
        [Required]
        [StringLength(maximumLength: 255, ErrorMessage = "O campo cidade não deve ultrapassar 255 caracteres")]
        public string Cidade { get; set; }
        /// <summary>
        /// Complemento, como apartamento, bloco, referência, entre outros.
        /// </summary>
        [StringLength(maximumLength: 255, ErrorMessage = "O campo complemento não deve ultrapassar 255 caracteres")]
        public string Complemento { get; set; }
        /// <summary>
        /// Referência do cliente.
        /// </summary>
        [Required]
        public int ClienteId { get; set; }
        /// <summary>
        /// Cliente que possui o endereço.
        /// </summary>
        public virtual CustomerModel Cliente { get; set; }
    }
}