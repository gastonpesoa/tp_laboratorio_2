using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades_2018
{
    public class Dulce : Producto
    {
        #region "Constructores"
        /// <summary>
        /// Constructor para objetos de TIPO Dulce
        /// </summary>
        /// <param name="marca">Marca con la que se iniciará la instancia</param>
        /// <param name="patente">Código de barras con el que se iniciará la instancia</param>
        /// <param name="color">Color con el que se iniciará la instancia</param>
        public Dulce(EMarca marca, string patente, ConsoleColor color)
            : base(patente, marca, color)
        {
        }
        #endregion

        #region "Propiedades"
        /// <summary>
        /// Los dulces tienen 80 calorías
        /// </summary>
        protected override short CantidadCalorias
        {
            get
            {
                return 80;
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

            sb.AppendLine("DULCE");
            sb.AppendLine(base.Mostrar());
            sb.AppendFormat("CALORIAS : {0}\n", this.CantidadCalorias);
            sb.AppendLine("---------------------");

            return sb.ToString();
        }
        #endregion
    }
}
