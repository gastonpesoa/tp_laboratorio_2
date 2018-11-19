using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Entidades
{
    public static class GuardaString
    {
        #region "Método de extención"
        /// <summary>
        ///     Método de extensión para la clase String.
        ///     Guarda en un archivo de texto en el escritorio de la máquina.
        ///     Si el archivo existe, agregará información en él.    
        /// </summary>
        /// <param name="texto">
        ///     (string) Especifica en que tipo funciona el método.
        /// </param>
        /// <param name="archivo">
        ///     Nombre del archivo
        /// </param>
        /// <returns>
        ///     (true) Si se escribió el archivo con éxito     
        ///     (Exception) En caso de producirse un error al intentar abrir o escribir el archivo
        /// </returns>
        public static bool Guardar(this string texto, string archivo)
        {
            bool returnAux = false;
            StreamWriter sW = null;
            try
            {
                sW = new StreamWriter(archivo, true);
                sW.WriteLine(texto);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al abrir/escribir el archivo de texto\n" + ex.Message, ex);
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
        #endregion
    }
}
