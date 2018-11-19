using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades_2018
{
    public class Snacks : Producto
    {
        #region "Constructores"
        /// <summary>
        /// Constructor para objetos de TIPO Snacks
        /// </summary>
        /// <param name="marca">Marca con la que se iniciará la instancia</param>
        /// <param name="patente">Código de barras con la que se iniciará la instancia</param>
        /// <param name="color">Color con la que se iniciará la instancia</param>
        public Snacks(EMarca marca, string patente, ConsoleColor color)
            : base(patente, marca, color)
        {
        }
        #endregion

        #region "Propiedades"
        /// <summary>
        /// Los snacks tienen 104 calorías
        /// </summary>
        protected override short CantidadCalorias
        {
            get
            {
                return 104;
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

            sb.AppendLine("SNACKS");
            sb.AppendLine(base.Mostrar());
            sb.AppendFormat("CALORIAS : {0}\n", this.CantidadCalorias);
            sb.AppendLine("---------------------");

            return sb.ToString();
        }
        #endregion
    }
}
