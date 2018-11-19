using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clases_Abstractas;

namespace Clases_Instanciables
{
    public sealed class Alumno : Universitario
    {
        #region "Enumerado"
        public enum EEstadoCuenta
        {
            AlDia,
            Deudor,
            Becado
        }
        #endregion

        #region "Campos"
        private Universidad.EClases claseQueToma;
        private EEstadoCuenta estadoCuenta;
        #endregion

        #region "Constructores"
        /// <summary>
        /// Constructor por defecto.
        /// </summary>
        public Alumno()
        {

        }
        /// <summary>
        /// Constructor de instancias.
        /// </summary>
        /// <param name="id">Id que se asignará a la instancia</param>
        /// <param name="nombre">Nombre que se asignará a la instancia</param>
        /// <param name="apellido">Apellido que se asignará a la instancia</param>
        /// <param name="dni">DNI que se asignará a la instancia</param>
        /// <param name="nacionalidad">Nacionalidad que se asignará a la instancia</param>
        /// <param name="claseQueToma">Clase que toma que se asignará a la instancia</param>
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma)
            : base(id, nombre, apellido, dni, nacionalidad)
        {
            this.claseQueToma = claseQueToma;
        }
        /// <summary>
        /// Constructor de instancias.
        /// </summary>
        /// <param name="id">Id que se asignará a la instancia</param>
        /// <param name="nombre">Nombre que se asignará a la instancia</param>
        /// <param name="apellido">Apellido que se asignará a la instancia</param>
        /// <param name="dni">DNI que se asignará a la instancia</param>
        /// <param name="nacionalidad">Nacionalidad que se asignará a la instancia</param>
        /// <param name="claseQueToma">Clase que toma que se asignará a la instancia</param>
        /// <param name="estadoCuenta">Estado de cuenta que se asignará a la instancia</param>
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma, EEstadoCuenta estadoCuenta)
            : base(id, nombre, apellido, dni, nacionalidad)
        {
            this.claseQueToma = claseQueToma;
            this.estadoCuenta = estadoCuenta;
        }
        #endregion

        #region "Operadores"
        /// <summary>
        /// Un Alumno será igual a un EClase si toma esa clase y su estado de cuenta no es Deudor
        /// </summary>
        /// <param name="a">Alumno a verificar si toma la clase</param>
        /// <param name="clase">Clase que debe tomar el Alumno</param>
        /// <returns></returns>
        public static bool operator ==(Alumno a, Universidad.EClases clase)
        {
            return a.claseQueToma == clase && a.estadoCuenta != EEstadoCuenta.Deudor;
        }
        /// <summary>
        /// Un Alumno será distinto a un EClase sólo si no toma esa clase
        /// </summary>
        /// <param name="a">Alumno a verificar si no toma la clase</param>
        /// <param name="clase">Clase que no debe tomar el Alumno</param>
        /// <returns></returns>
        public static bool operator !=(Alumno a, Universidad.EClases clase)
        {
            return a.claseQueToma != clase;
        }
        #endregion

        #region "Métodos"
        /// <summary>
        /// Sobreescribirá el método MostrarDatos con todos los datos del alumno.
        /// </summary>
        /// <returns>(string) Datos del alumno</returns>
        protected override string MostrarDatos()
        {
            StringBuilder s = new StringBuilder();
            s.AppendLine(base.MostrarDatos());
            s.Append("\nESTADO DE LA CUENTA: ");
            switch (this.estadoCuenta)
            {
                case EEstadoCuenta.AlDia:
                    s.AppendLine("Cuota al día");
                    break;
                case EEstadoCuenta.Deudor:
                    s.AppendLine("Deudor");
                    break;
                case EEstadoCuenta.Becado:
                    s.AppendLine("Becado");
                    break;
                default:
                    break;
            }
            s.Append(this.ParticiparEnClase());
            return s.ToString();
        }
        /// <summary>
        /// Retornará la cadena "TOMA CLASE DE " junto al nombre de la clase que toma
        /// </summary>
        /// <returns>(string) "TOMA CLASE DE " junto al nombre de la clase que toma</returns>
        protected override string ParticiparEnClase()
        {
            StringBuilder s = new StringBuilder();
            s.AppendFormat("TOMA CLASES DE {0}", this.claseQueToma);
            return s.ToString();
        }
        /// <summary>
        ///  Publica los datos del Alumno a través del método MostrarDatos()
        /// </summary>
        /// <returns>(string) Datos del alumno</returns>
        public override string ToString()
        {
            return this.MostrarDatos(); 
        }
        #endregion
    }
}
