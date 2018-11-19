using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using Excepciones;

namespace Archivos
{
    public class Xml<T> : IArchivo<T>
    {
        #region "Métodos"
        /// <summary>
        /// Implementación del metodo Guardar() de la interfaz implementada.
        /// Serializa el dato especificado y escribe en un documento Xml.
        /// </summary>
        /// <param name="archivo">Path donde se serializarán los datos</param>
        /// <param name="datos">Datos que se serializarán</param>
        /// <returns>(true) Si se pudieron serializar los datos - (false) Caso contrario.</returns>
        public bool Guardar(string archivo, T datos)
        {
            bool returnAux = false;
            XmlTextWriter writer = null;
            XmlSerializer ser = new XmlSerializer(typeof(T));
            try
            {
                writer = new XmlTextWriter(archivo,Encoding.UTF8);
                ser.Serialize(writer, datos);
            }
            catch(Exception ex)
            {
                throw new ArchivosException(ex);
            }
            finally
            {
                if (!(writer is null))
                {
                    writer.Close();
                    returnAux = true;
                }
            }
            return returnAux;
        }
        /// <summary>
        /// Implementación del metodo Leer() de la interfaz implementada.
        /// Deserializa el documento Xml contenido por el path especificado.
        /// </summary>
        /// <param name="archivo">Path de donde se deserializarán los datos</param>
        /// <param name="datos">Datos deserializados</param>
        /// <returns>(true) Si se pudieron deserializar los datos - (false) Caso contrario</returns>
        public bool Leer(string archivo, out T datos)
        {
            bool returnAux = false;
            XmlTextReader reader = null;
            XmlSerializer ser = new XmlSerializer(typeof(T));
            try
            {
                reader = new XmlTextReader(archivo);
                datos = (T)ser.Deserialize(reader);
            }
            catch(Exception ex)
            {
                throw new ArchivosException(ex);
            }
            finally
            {
                if (!(reader is null))
                {
                    reader.Close();
                    returnAux = true;
                }
            }
            return returnAux;
        }
        #endregion
    }
}
