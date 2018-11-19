using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class SinProfesorException : Exception
    {
        #region "Constructor"
        /// <summary>
        /// Constructor de instancias.
        /// </summary>
        public SinProfesorException()
            : base("No hay profesor para la clase.") { }
        #endregion
    }
}
