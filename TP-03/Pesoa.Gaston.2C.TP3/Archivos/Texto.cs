using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Excepciones;

namespace Archivos
{
    public class Texto : IArchivo<string>
    {
        #region "Métodos"
        /// <summary>
        /// Implementación del metodo Guardar() de la interfaz implementada.
        /// Guarda datos de formato texto en el path especificado en archivo.
        /// </summary>
        /// <param name="archivo">Path donde se guardarán datos</param>
        /// <param name="datos">Datos que se guardarán</param>
        /// <returns>(true) Si se pudieron guardar los datos - (false) Caso contrario.</returns>
        public bool Guardar(string archivo, string datos)
        {
            bool returnAux = false;
            StreamWriter sW = null;
            try
            {
                sW = new StreamWriter(archivo);
                sW.Write(datos);
            }
            catch (Exception ex)
            {
                throw new ArchivosException(ex);
            }
            finally
            {
                if (!(sW is null))
                {
                    sW.Close();
                    returnAux = true;
                }
            }
            return returnAux;
        }
        /// <summary>
        /// Implementación del metodo Leer() de la interfaz implementada.
        /// Lee datos de formato texo del path especificado.
        /// </summary>
        /// <param name="archivo">Path de donde se leeran los datos</param>
        /// <param name="datos">Datos leídos</param>
        /// <returns>(true) Si se pudieron leer los datos - (false) Caso contrario</returns>
        public bool Leer(string archivo, out string datos)
        {
            bool returnAux = false;
            StreamReader sR = null;
            try
            {
                sR = new StreamReader(archivo);
                datos = sR.ReadToEnd();
            }
            catch (Exception ex)
            {
                throw new ArchivosException(ex);
            }
            finally
            {
                if (!(sR is null))
                {
                    sR.Close();
                    returnAux = true;
                }
            }
            return returnAux;
        }
        #endregion
    }
}
