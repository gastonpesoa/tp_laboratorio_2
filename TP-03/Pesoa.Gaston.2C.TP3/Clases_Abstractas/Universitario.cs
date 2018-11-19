using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases_Abstractas
{
    public abstract class Universitario : Persona
    {
        #region "Campos"
        private int legajo;
        #endregion

        #region "Constructores"
        /// <summary>
        /// Constructor por defecto.
        /// </summary>
        public Universitario()
        {

        }
        /// <summary>
        /// Constructor de instancias.
        /// </summary>
        /// <param name="legajo">Legajo que se asignará a la instancia</param>
        /// <param name="nombre">Nombre que se asignará a la instancia</param>
        /// <param name="apellido">Apellido que se asignará a la instancia</param>
        /// <param name="dni">DNI que se asignará a la instancia</param>
        /// <param name="nacionalidad">Nacionalidad que se asignará a la instancia</param>
        public Universitario(int legajo, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : base(nombre, apellido, dni, nacionalidad)
        {
            this.legajo = legajo;
        }
        #endregion

        #region "Operadores"
        /// <summary>
        /// Dos Universitario serán iguales si y sólo si son del mismo Tipo y su Legajo o DNI son iguales.
        /// </summary>
        /// <param name="pg1">Universitario 1 a comparar</param>
        /// <param name="pg2">Universitario 2 a comparar</param>
        /// <returns></returns>
        public static bool operator ==(Universitario pg1, Universitario pg2)
        {
            return pg1.Nacionalidad == pg2.Nacionalidad && (pg1.DNI == pg2.DNI || pg1.legajo == pg2.legajo); 
        }
        /// <summary>
        /// Dos Universitario serán distintos si y sólo si son de distinto Tipo y su Legajo o DNI son diferentes.
        /// </summary>
        /// <param name="pg1">Universitario 1 a comparar</param>
        /// <param name="pg2">Universitario 2 a comparar</param>
        /// <returns></returns>
        public static bool operator !=(Universitario pg1, Universitario pg2)
        {
            return !(pg1 == pg2);
        }
        #endregion

        #region "Métodos"
        /// <summary>
        /// Sobrescritura del método Equals(object). Verifica que el objeto passado como parámetro sea del Tipo Universitario.
        /// </summary>
        /// <param name="obj">Objeto que se verificará</param>
        /// <returns>(true) en caso de ser de Tipo Universitario - (false) en caso contrario</returns>
        public override bool Equals(object obj)
        {
            return obj is Universitario;
        }
        /// <summary>
        ///  Método protegido y virtual. 
        ///  Expone todos los datos del Universitario.
        /// </summary>
        /// <returns>(string) Datos del Universitario</returns>
        protected virtual string MostrarDatos()
        {
            StringBuilder s = new StringBuilder();
            s.AppendLine(base.ToString());
            s.AppendFormat("\nLEGAJO NÚMERO: {0}", this.legajo);
            return s.ToString();
        }
        /// <summary>
        /// Método protegido y abstracto.
        /// </summary>
        /// <returns>(string)</returns>
        protected abstract string ParticiparEnClase();
        #endregion
    }
}
