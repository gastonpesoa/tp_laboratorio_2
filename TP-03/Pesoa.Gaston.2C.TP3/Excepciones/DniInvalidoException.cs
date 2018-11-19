using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class DniInvalidoException : Exception
    {
        #region "Campos"
        private string mensajeBase;
        #endregion

        #region "Constructores"
        /// <summary>
        /// Constructor por defecto.
        /// </summary>
        public DniInvalidoException()
            :this("Dni Inválido") { }
        /// <summary>
        /// Constructor de instancias.
        /// </summary>
        /// <param name="message">Mensaje que se asignará a la excepción</param>
        public DniInvalidoException(string message)
            :base(message)
        {
            this.mensajeBase = message;
        }
        /// <summary>
        /// Constructor de instancias.
        /// </summary>
        /// <param name="e">Excepción que se asignará al InnerException de la excepción</param>
        public DniInvalidoException(Exception e)
            : this("Dni Inválido",e) { }
        /// <summary>
        /// Constructor de instancias
        /// </summary>
        /// <param name="message">Mensaje que se asignará a la excepción</param>
        /// <param name="e">Excepción que se asignará al InnerException de la excepción</param>
        public DniInvalidoException(string message, Exception e)
            :base(message, e)
        {
            this.mensajeBase = message;
        }
        #endregion
    }
}
