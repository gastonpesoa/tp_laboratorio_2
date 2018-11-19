using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class ArchivosException : Exception
    {
        #region "Constructor"
        /// <summary>
        /// Constructor de instancias
        /// </summary>
        /// <param name="innerException">Excepción que se asignará dentro de la excepción</param>
        public ArchivosException(Exception innerException)
            : base("Archivo Inválido", innerException) { }
        #endregion
    }
}
