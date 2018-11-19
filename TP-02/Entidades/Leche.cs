using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;

namespace Entidades_2018
{
    public class Leche : Producto
    {
        #region "Enumerado"
        public enum ETipo { Entera, Descremada }
        #endregion

        #region "Atributos"
        private ETipo tipo;
        #endregion

        #region "Constructores"
        /// <summary>
        /// Por defecto, TIPO será ENTERA
        /// </summary>
        /// <param name="marca">Marca con la que se iniciará la instancia</param>
        /// <param name="patente">Código de barras con la que se iniciará la instancia</param>
        /// <param name="color">Color con la que se iniciará la instancia</param>
        public Leche(EMarca marca, string patente, ConsoleColor color)
            : base(patente, marca, color)
        {
            this.tipo = ETipo.Entera;
        }
        /// <summary>
        /// Constructor para objetos de TIPO Leche
        /// </summary>
        /// <param name="marca">Marca con la que se iniciará la instancia</param>
        /// <param name="patente">Código de barras con la que se iniciará la instancia</param>
        /// <param name="color">Color con la que se iniciará la instancia</param>
        /// <param name="tipo">Tipo con el que se iniciará la instancia</param>
        public Leche(EMarca marca, string patente, ConsoleColor color, ETipo tipo)
            :base(patente, marca, color)
        {
            this.tipo = tipo;
        }
        #endregion

        #region "Propiedades"
        /// <summary>
        /// Las leches tienen 20 calorías
        /// </summary>
        protected override short CantidadCalorias
        {
            get
            {
                return 20;
            }
        }
        #endregion

        #region "Métodos"
        /// <summary>
        /// Expone los datos del elemento (incluida su herencia) 
        /// </summary>
        /// <returns>(string) Detalle del objeto</returns>
        public sealed override string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("LECHE");
            sb.AppendLine(base.Mostrar());
            sb.AppendFormat("CALORIAS : {0}\nTIPO: {1}\n", this.CantidadCalorias,this.tipo);
            sb.AppendLine("---------------------");

            return sb.ToString();
        }
        #endregion
    }
}
