using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clases_Abstractas;
using System.Threading;

namespace Clases_Instanciables
{
    public sealed class Profesor : Universitario
    {
        #region "Campos"
        private Queue<Universidad.EClases> clasesDelDia;
        static Random random;
        #endregion

        #region "Constructores"
        /// <summary>
        /// Constructar de clase, inicializa al campo estático Random 
        /// </summary>
        static Profesor()
        {
            Profesor.random = new Random();
        }
        /// <summary>
        /// Constructor por defecto.
        /// </summary>
        public Profesor()
        {

        }
        /// <summary>
        /// Constructor de instancia, inicializa el campo clasesDelDia.
        /// Asignará dos clases al azar al Profesor mediante el método randomClases().
        /// Las dos clases pueden o no ser la misma
        /// </summary>
        /// <param name="id">Id que se asignará a la instancia</param>
        /// <param name="nombre">Nombre que se asignará a la instancia</param>
        /// <param name="apellido">Apellido que se asignará a la instancia</param>
        /// <param name="dni">DNI que se asignará a la instancia</param>
        /// <param name="nacionalidad">Nacionalidad que se asignará a la instancia</param>
        public Profesor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            :base(id, nombre, apellido, dni, nacionalidad)
        {
            this.clasesDelDia = new Queue<Universidad.EClases>();
            this._randomClases();
        }
        #endregion

        #region "Operadores"
        /// <summary>
        /// Un Profesor será igual a un EClase si da esa clase
        /// </summary>
        /// <param name="i">Profesor que se verificará coincidencia con clase</param>
        /// <param name="clase">Clase que se comparará</param>
        /// <returns>(true) Si da la clase - (false) Caso contrario</returns>
        public static bool operator ==(Profesor i, Universidad.EClases clase)
        {
            bool contiene = false;
            foreach (Universidad.EClases claseEnCola in i.clasesDelDia)
            {
                if (claseEnCola == clase)
                {
                    contiene = true;
                    break;
                }
            }
            return contiene;
        }
        /// <summary>
        /// Un Profesor será distinta a un EClase si no da esa clase
        /// </summary>
        /// <param name="i">Profesor que se verificará coincidencia con clase</param>
        /// <param name="clase">Clase que se comparará</param>
        /// <returns>(true) Si da la clase - (false) Caso contrario</returns>
        public static bool operator !=(Profesor i, Universidad.EClases clase)
        {
            return !(i == clase);
        }
        #endregion

        #region "Métodos"
        /// <summary>
        /// Asigna dos clases al azar al Profesor
        /// </summary>
        private void _randomClases()
        {
            this.clasesDelDia.Enqueue((Universidad.EClases)Profesor.random.Next(0, 3));
            Thread.Sleep(2000);
            this.clasesDelDia.Enqueue((Universidad.EClases)Profesor.random.Next(0, 3));
        }
        /// <summary>
        ///  Retorna la cadena "CLASES DEL DÍA" junto al nombre de las clases que da.
        /// </summary>
        /// <returns>(string) Cadena "CLASES DEL DÍA" junto al nombre de las clases que da.</returns>
        protected override string ParticiparEnClase()
        {
            StringBuilder s = new StringBuilder();
            s.AppendLine("CLASES DEL DÍA:");
            foreach (Universidad.EClases clase in this.clasesDelDia)
            {
                s.AppendFormat("{0}\n", clase);
            }
            return s.ToString();
        }
        /// <summary>
        /// Sobrescritura del método MostrarDatos()
        /// </summary>
        /// <returns>(string) Datos del Profesor.</returns>
        protected override string MostrarDatos()
        {
            StringBuilder s = new StringBuilder();
            s.AppendLine(base.MostrarDatos());
            s.AppendFormat("{0}\n", this.ParticiparEnClase());
            return s.ToString();
        }
        /// <summary>
        /// Sobrescritura del método ToString(), reutiliza método MostrarDatos().
        /// </summary>
        /// <returns>(string) Expone datos del Profesor</returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }
        #endregion
    }
}
