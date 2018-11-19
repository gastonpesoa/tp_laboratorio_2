using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Archivos;
using Excepciones;

namespace Clases_Instanciables
{
    public class Jornada
    {
        #region "Campos"
        private List<Alumno> alumnos;
        private Universidad.EClases clase;
        private Profesor instructor;
        #endregion

        #region "Propiedades"
        /// <summary>
        /// Obtiene y asigna la lista de alumnos a la Jornada
        /// </summary>
        public List<Alumno> Alumnos
        {
            get { return this.alumnos; }
            set { this.alumnos = value; }
        }
        /// <summary>
        /// Obtiene y asigna una clase a la Jornada
        /// </summary>
        public Universidad.EClases Clase
        {
            get { return this.clase; }
            set { this.clase = value; }
        }
        /// <summary>
        /// Obtiene y asigna un Profesor a la Jornada
        /// </summary>
        public Profesor Instructor
        {
            get { return this.instructor; }
            set { this.instructor = value; }
        }
        #endregion

        #region "Constructores"
        /// <summary>
        /// Constructor por defecto, inicializa la lista de alumnos. 
        /// </summary>
        private Jornada()
        {
            this.Alumnos = new List<Alumno>();
        }
        /// <summary>
        /// Constructor de instancias.
        /// </summary>
        /// <param name="clase">Clase que se asignará a la instancia</param>
        /// <param name="instructor">Profesor que se asignará a la instancia</param>
        public Jornada(Universidad.EClases clase, Profesor instructor)
            : this()
        {
            this.Clase = clase;
            this.Instructor = instructor;
        }
        #endregion

        #region "Operadores"
        /// <summary>
        /// Una Jornada será igual a un Alumno si el mismo participa de la clase.
        /// </summary>
        /// <param name="j">Jornada donde se buecará coincidencia con el Alumno</param>
        /// <param name="a">Alumno que se buecara en la lista de alumnos de Jornada</param>
        /// <returns>(true) Si el Alumno participa de la clase - (false) Caso contrario</returns>
        public static bool operator ==(Jornada j, Alumno a)
        {
            bool contiene = false;
            foreach (Alumno alumno in j.Alumnos)
            {
                if (alumno == a)
                {
                    contiene = true;
                    throw new AlumnoRepetidoException();
                }
            }
            return contiene;
        }
        /// <summary>
        /// Una Jornada será distinta a un Alumno si el mismo no participa de la clase.
        /// </summary>
        /// <param name="j">Jornada donde se buecará coincidencia con el Alumno</param>
        /// <param name="a">Alumno que se buecará en la lista de alumnos de Jornada</param>
        /// <returns>(true) Si el Alumno no participa de la clase - (false) Caso contrario</returns>
        public static bool operator !=(Jornada j, Alumno a)
        {
            return !(j == a);
        }
        /// <summary>
        /// Agrega Alumnos a la clase previa validación que no esté previamente cargado.
        /// </summary>
        /// <param name="j">Jornada donde se agregará al Alumno</param>
        /// <param name="a">Alumno que se agregará a la lista de Alumnos de la Jornada</param>
        /// <returns>
        /// (Jornada) j más el Alumno agregado a la lista en caso de que no se encuentre previamente cargado.
        /// (Jornada) j sin modificaciones en caso contrario
        /// </returns>
        public static Jornada operator +(Jornada j, Alumno a)
        {
            bool contiene = false;
            try
            {
                contiene = j != a;
            }
            catch (AlumnoRepetidoException ex)
            {
                throw ex;
            }
            if (contiene)
            {
                j.Alumnos.Add(a);
            }
            return j;
        }
        #endregion

        #region "Métodos"
        /// <summary>
        /// Expone todos los datos de la Jornada
        /// </summary>
        /// <returns>(string) Datos de la Jornada</returns>
        public override string ToString()
        {
            StringBuilder s = new StringBuilder();
            s.AppendFormat("CLASE DE {0} POR {1}ALUMNOS:\n", this.Clase, this.Instructor.ToString());
            foreach (Alumno alumno in this.Alumnos)
            {
                s.AppendLine(alumno.ToString());
            }
            return s.ToString();
        }
        /// <summary>
        /// De clase, guarda los datos de la Jornada en un archivo de texto.
        /// </summary>
        /// <param name="jornada">Jornada que se guardará</param>
        /// <returns>(true) En caso de que se guarden los datos - (flase) En caso contrario</returns>
        public static bool Guardar(Jornada jornada)
        {
            bool guardado = false;
            Texto texto = new Texto();
            try
            {
                guardado = texto.Guardar(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/Jornada.txt" , jornada.ToString());
            }
            catch (ArchivosException ex)
            {
                throw ex;
            }
            return guardado;
        }
        /// <summary>
        /// De clase, retorna los datos de la Jornada como texto.
        /// </summary>
        /// <returns>(string) Datos de la Jornada</returns>
        public static string Leer()
        {
            bool leido = false;
            string datos = null, returnAux = null;
            Texto texto = new Texto();
            try
            {
                leido = texto.Leer(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/Jornada.txt", out datos);
            }
            catch (ArchivosException ex)
            {
                throw ex;
            }
            if (leido)
            {
                returnAux = datos;
            }
            return returnAux;
        }
        #endregion
    }
}
