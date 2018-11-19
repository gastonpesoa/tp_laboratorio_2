using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public interface IMostrar<T>
    {
        #region "Métodos"
        /// <summary>
        ///     Descripción del método que las clases que implementen la interfaz deberán sobrescribir.
        /// </summary>
        /// <param name="elemento">
        ///     (IMostrar<T>) Interfaz genérica. 
        ///     El tipo del elemento deberá ser especificado en el momento de su declaración.
        /// </param>
        /// <returns>
        ///     (string)
        /// </returns>
        string MostrarDatos(IMostrar<T> elemento);
        #endregion
    }
}
