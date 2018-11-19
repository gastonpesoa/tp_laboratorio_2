using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades_2018
{
    /// <summary>
    /// La clase Producto no deberá permitir que se instancien elementos de este tipo.
    /// </summary>
    public abstract class Producto
    {
        #region "Enumerado"
        public enum EMarca
        {
            Serenisima, Campagnola, Arcor, Ilolay, Sancor, Pepsico
        }
        #endregion

        #region "Atributos"
        private EMarca marca;
        private string codigoDeBarras;
        private ConsoleColor colorPrimarioEmpaque;
        #endregion

        #region "Constructores"
        /// <summary>
        /// Constructor para objetos de TIPO Producto
        /// </summary>
        /// <param name="patente">Código de barras con el que se iniciará la instancia</param>
        /// <param name="marca">Marca con la que se iniciará la instancia</param>
        /// <param name="color">Color con el que se iniciará la instancia</param>
        public Producto(string patente, EMarca marca, ConsoleColor color)
        {
            this.codigoDeBarras = patente;
            this.marca = marca;
            this.colorPrimarioEmpaque = color;
        }
        #endregion

        #region "Propiedades"
        /// <summary>
        /// ReadOnly: Retornará la cantidad de calorias del producto
        /// </summary>
        protected abstract short CantidadCalorias { get; }
        #endregion

        #region "Métodos"
        /// <summary>
        /// Publica todos los datos del Producto.
        /// </summary>
        /// <returns>string con datos del producto</returns>
        public virtual string Mostrar()
        {
            return (string)this;
        }
        #endregion

        #region "Sobrecargas"
        /// <summary>
        /// Sobrecarga de conversión explícita del tipo Producto a tipo string
        /// Retorna string con detalle del producto
        /// </summary>
        /// <param name="p">Producto a ser detallado</param>
        public static explicit operator string(Producto p)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("CODIGO DE BARRAS: {0}\r\n", p.codigoDeBarras);
            sb.AppendFormat("MARCA          : {0}\r\n", p.marca.ToString());
            sb.AppendFormat("COLOR EMPAQUE  : {0}\r\n", p.colorPrimarioEmpaque.ToString());
            sb.AppendLine("---------------------");

            return sb.ToString();
        }
        #endregion

        #region "Operadores"
        /// <summary>
        /// Dos productos son iguales si comparten el mismo código de barras
        /// </summary>
        /// <param name="p1">Producto uno a comparar</param>
        /// <param name="p2">Producto dos a comparar</param>
        /// <returns>
        /// (true) en caso de ser iguales
        /// (false) en caso de ser disitintos
        /// </returns>
        public static bool operator ==(Producto p1, Producto p2)
        {
            return (p1.codigoDeBarras == p2.codigoDeBarras);
        }
        /// <summary>
        /// Dos productos son distintos si su código de barras es distinto
        /// </summary>
        /// <param name="p1">Producto uno a comparar</param>
        /// <param name="p2">Producto dos a comparar</param>
        /// <returns>
        /// (true) En caso de ser disitintos 
        /// (false) En caso de ser iguales
        /// </returns>
        public static bool operator !=(Producto p1, Producto p2)
        {
            return !(p1.codigoDeBarras == p2.codigoDeBarras);
        }
        #endregion
    }
}
