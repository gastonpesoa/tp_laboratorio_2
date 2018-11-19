using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archivos
{
    public interface IArchivo<T>
    {
        #region "Métodos"
        /// <summary>
        /// Método para guardar archivos a ser implementado en clases que implementen la interfaz.
        /// </summary>
        /// <param name="archivos">Path donde se almacenarán T datos</param>
        /// <param name="datos">T datos que se guardarán</param>
        /// <returns>(true) Si se pudieron guardar los datos - (false) Caso contrario.</returns>
        bool Guardar(string archivos, T datos);
        /// <summary>
        /// Método para leer archivos a ser implementado en clases que implementen la interfaz.
        /// </summary>
        /// <param name="archivos">Path de donde se leeran los datos</param>
        /// <param name="datos">Datos leídos</param>
        /// <returns>(true) Si se pudieron leer los datos - (false) Caso contrario.</returns>
        bool Leer(string archivos, out T datos);
        #endregion
    }
}
