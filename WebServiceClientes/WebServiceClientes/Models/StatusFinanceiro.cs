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
        SemPendencias = 0,
        /// <summary>
        /// Cliente com pendências financeiras.
        /// </summary>
        ComPendencias = 1,
        /// <summary>
        /// Cliente inadimplente, ou seja, com débitos vencidos.
        /// </summary>
        Inadimplente = 2
    }
}