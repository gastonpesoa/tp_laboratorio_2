using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class NacionalidadInvalidaException : Exception
    {
        #region "Constructores"
        /// <summary>
        /// Constructor por defecto
        /// </summary>
        public NacionalidadInvalidaException()
            : this("La nacionalidad no se coincide con el número de DNI") { }
        /// <summary>
        /// Constructor de instancia
        /// </summary>
        /// <param name="message">Mensaje que se asignará a la excepción</param>
        public NacionalidadInvalidaException(string message)
            : base(message) { }
        #endregion
    }
}
