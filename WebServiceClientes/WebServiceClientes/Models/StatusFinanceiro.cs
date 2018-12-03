using System.ComponentModel;

namespace WebServiceClientes.Models
{
    /// <summary>
    /// Indica o status financeiro do cliente
    /// </summary>
    public enum StatusFinanceiro
    {
        /// <summary>
        /// Cliente sem pendências financeirias.
        /// </summary>
        [Description("Sem Pendências")]
        SemPendencias = 0,
        /// <summary>
        /// Cliente com pendências financeiras.
        /// </summary>
        [Description("Com Pendências")]
        ComPendencias = 1,
        /// <summary>
        /// Cliente inadimplente, ou seja, com débitos vencidos.
        /// </summary>
        [Description("Inadimplente")]
        Inadimplente = 2
    }
}