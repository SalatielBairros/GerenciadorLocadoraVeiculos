using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Web;
using WebServiceClientes.Models;

namespace WebServiceClientes.Helpers
{
    /// <summary>
    /// Métodos auxiliares de extensão para se trabalhar com enumeradores.
    /// </summary>
    public static class EnumHelper
    {
        /// <summary>
        /// Busca descrição do Enum (atributo description)
        /// </summary>
        /// <param name="this">Enum a ter sua descrição buscada.</param>
        /// <returns>Descrição do enumerador</returns>
        public static string GetDescription(this Enum @this)
        {
            FieldInfo fi = @this.GetType().GetField(@this.ToString());

            var attributes = (DescriptionAttribute[])fi.GetCustomAttributes(
                typeof(DescriptionAttribute), false);

            return attributes.Length > 0 ? attributes[0].Description : @this.ToString();
        }
    }
}