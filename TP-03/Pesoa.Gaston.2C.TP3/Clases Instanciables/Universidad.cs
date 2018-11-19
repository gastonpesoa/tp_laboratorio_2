using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;
using Archivos;

namespace Clases_Instanciables
{
    public class Universidad
    {
        #region "Enumerado"
        public enum EClases
        {
            Programacion,
            Laboratorio, 
            Legislacion,
            SPD
        }
        #endregion

        #region "Campos"
        private List<Alumno> alumnos;
        private List<Jornada> jornada;
        private List<Profesor> profesores;
        #endregion

        #region "Propiedades"
        /// <summary>
        /// Obtiene y asigna una lista de Alumnos a la Universidad
        /// </summary>
        public List<Alumno> Alumnos
        {
            get { return this.alumnos; }
            set { this.alumnos = value; }
        }
        /// <summary>
        /// Obtiene y asigna una lista de Profesores a la Universidad
        /// </summary>
        public List<Profesor> Instructores
        {
            get { return this.profesores; }
            set { this.profesores = value; }
        }
        /// <summary>
        /// Obtiene y asigna una lista de Jornadas a la Universidad
        /// </summary>
        public List<Jornada> Jornadas
        {
            get { return this.jornada; }
            set { this.jornada = value; }
        }
        /// <summary>
        /// Indexador, accede a una Jornada específica.
        /// </summary>
        /// <param name="i">Índice con el que se accederá a una Jornada específica.</param>
        /// <returns>(Jornada) Jornada con el índice especificado.</returns>
        public Jornada this[int i]
        {
            get
            {
                if (i >= 0 && i < this.Jornadas.Count)
                {
                    return this.Jornadas[i];
                }
                else
                {
                    return null;
                }
            }
            set
            {
                if (i >= 0 && i < this.Jornadas.Count)
                {
                    this.Jornadas[i] = value;
                }
            }
        }
        #endregion

        #region "Constructor"
        /// <summary>
        /// Constructor por defecto.
        /// </summary>
        public Universidad()
        {
            this.Alumnos = new List<Alumno>();
            this.Jornadas = new List<Jornada>();
            this.Instructores = new List<Profesor>();
        }
        #endregion

        #region "Operadores"
        /// <summary>
        /// Un Universidad será igual a un Alumno si el mismo está inscripto en ella.
        /// </summary>
        /// <param name="g">Universidad donde se buscará al Alumno</param>
        /// <param name="a">Alumno que se buscará dentro de la lista de Alumnos de la Universidad</param>
        /// <returns>(true) En caso de encontrar coincidencia - (AlumnoRepetidoException) En caso contrario.</returns>
        public static bool operator ==(Universidad g, Alumno a)
        {
            bool contiene = false;
            foreach (Alumno alumno in g.Alumnos)
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
        /// Un Universidad será distinta a un Alumno si el mismo no está inscripto en ella.
        /// </summary>
        /// <param name="g">Universidad donde se buscará al Alumno</param>
        /// <param name="a">Alumno que se buscará dentro de la lista de Alumnos de la Universidad</param>
        /// <returns>(true) En caso de no encontrar coincidencia - (false) En caso contrario.</returns>
        public static bool operator !=(Universidad g, Alumno a)
        {
            return !(g == a);
        }
        /// <summary>
        /// Un Universidad será igual a un Profesor si el mismo está dando clases en ella.
        /// </summary>
        /// <param name="g">Universidad donde se buscará al Profesor</param>
        /// <param name="i">Profesor que se buscará dentro de la lista de Profesores de la Universidad</param>
        /// <returns>(true) En caso de encontrar coincidencia - (false) En caso contrario.</returns>
        public static bool operator ==(Universidad g, Profesor i)
        {
            bool contiene = false;
            foreach (Profesor profesor in g.Instructores)
            {
                if (profesor == i)
                {
                    contiene = true;
                }
            }
            return contiene;
        }
        /// <summary>
        /// Un Universidad será distinta a un Profesor si el mismo no está dando clases en ella.
        /// </summary>
        /// <param name="g">Universidad donde se buscará al Profesor</param>
        /// <param name="i">Profesor que se buscará dentro de la lista de Profesores de la Universidad</param>
        /// <returns>(true) En caso de no encontrar coincidencia - (false) En caso contrario.</returns>
        public static bool operator !=(Universidad g, Profesor i)
        {
            return !(g == i);
        }
        /// <summary>
        /// Agrega Alumnos a la lista de Alumnos de la Universidad, validando que no estén previamente cargados.
        /// </summary>
        /// <param name="u">Universidad donde se intentará agregar al Alumno</param>
        /// <param name="a">Alumno que se intentará agregar a la lista de Alumnos de la Universidad.</param>
        /// <returns>
        /// (Universidad) u mas el Alumno agregado a la lista de Alumnos en caso de que no halla estado cargado previamente.
        /// (Universidad) u sin modificaciones en caso contrario.
        /// </returns>
        public static Universidad operator +(Universidad u, Alumno a)
        {
            if (u != a)
            {
                u.Alumnos.Add(a);
            }
            return u;
        }
        /// <summary>
        /// Agrega Profesores a la lista de Profesores de la Universidad, validando que no estén previamente cargados.
        /// </summary>
        /// <param name="u">Universidad donde se intentará agregar al Profesor</param>
        /// <param name="i">Profesor que se intentará agregar a la lista de Profesores de la Universidad.</param>
        /// <returns>
        /// (Universidad) u mas el Profesor agregado a la lista de Profesores en caso de que no halla estado cargado previamente.
        /// (Universidad) u sin modificaciones en caso contrario.
        /// </returns>
        public static Universidad operator +(Universidad u, Profesor i)
        {
            if (u != i)
            {
                u.Instructores.Add(i);
            }
            return u;
        }
        /// <summary>
        /// La igualación entre un Universidad y una Clase retornará el primer Profesor capaz de dar esa clase. 
        /// Sino, lanzará la Excepción SinProfesorException.
        /// </summary>
        /// <param name="u">Universidad donde se buscará a un Profesor capaz de dar la clase.</param>
        /// <param name="clase">Clase que donde se buecará a un Profesor que pueda dar ese Tipo de clase</param>
        /// <returns>
        /// (Profesor) Si se encuentra a un profesor capaz de dar la clase. 
        /// (SinProfesorException) Caso contrario.
        /// </returns>
        public static Profesor operator ==(Universidad u, EClases clase)
        {
            Profesor profesorAsignado = null;
            
            foreach (Profesor profesor in u.Instructores)
            {
                if (profesor == clase)
                {
                    profesorAsignado = profesor;
                    break;
                }
            }
            if (profesorAsignado is null)
            {
                throw new SinProfesorException();
            }        
            return profesorAsignado;
        }
        /// <summary>
        /// Retorna el primer Profesor que no pueda dar la clase.
        /// </summary>
        /// <param name="u">Universidad donde se buscará a un Profesor no capaz de dar la clase.</param>
        /// <param name="clase">Clase que donde se buecará a un Profesor que no pueda dar ese Tipo de clase</param>
        /// <returns>
        /// (Profesor) Profesor capaz de no dar la clase. 
        /// (SinProfesorException) Caso contrario.
        /// </returns>
        public static Profesor operator !=(Universidad u, EClases clase)
        {
            Profesor profesorAsignado = null;

            foreach (Profesor profesor in u.Instructores)
            {
                if (profesor != clase)
                {
                    profesorAsignado = profesor;
                    break;
                }
            }
            if (profesorAsignado is null)
            {
                throw new SinProfesorException();
            }
            return profesorAsignado;
        }
        /// <summary>
        /// Al agregar una clase a un Universidad se deberá generar y agregar una nueva Jornada indicando la clase, 
        /// un Profesor que pueda darla(según su atributo ClasesDelDia) 
        /// y la lista de alumnos que la toman(todos los que coincidan en su campo ClaseQueToma).
        /// </summary>
        /// <param name="g">Universidad a la que se le asignará la nueva Jornada en caso que se cumplan los requisitos.</param>
        /// <param name="clase">Clase con la que se intentará generar la Jornada correspondiente.</param>
        /// <returns>
        /// (Universidad) g mas la Jornada correspondiente agregada a la su lista de Jornadas.
        /// (SinProfesorException) Si no se encuentra un profesor capaz de dar esa clase.
        /// </returns>
        public static Universidad operator +(Universidad g, EClases clase)
        {
            Jornada jornada = null;
            Profesor profesorAsignado = null;
            try
            {
                profesorAsignado = g == clase;
            }
            catch (SinProfesorException ex)
            {
                throw ex;
            }
            if (!(profesorAsignado is null))
            {
                jornada = new Jornada(clase, profesorAsignado);
                foreach (Alumno alumno in g.Alumnos)
                {
                    if (alumno == clase)
                    {
                        jornada.Alumnos.Add(alumno);
                    }
                }
                g.Jornadas.Add(jornada);
            }
            return g;
        }
        #endregion

        #region "Métodos"
        /// <summary>
        /// Método privado y de clase retorna una cadena de caracteres con los datos de la Universidad.
        /// </summary>
        /// <param name="uni">Universidad de la que se retornaran los datos</param>
        /// <returns>(string) Datos de la Universidad</returns>
        private static string MostrarDatos(Universidad uni)
        {
            StringBuilder s = new StringBuilder();
            s.AppendLine("JORNADA:");
            for (int i = 0; i < uni.Jornadas.Count; i++)
            {
                s.Append(uni.Jornadas[i].ToString());
                s.AppendLine("<------------------------------------------------------------->\n");
            }
            return s.ToString();
        }
        /// <summary>
        /// Sobrescritura del método ToString(), publica datos de la Universidad mediante el método MostrarDatos().
        /// </summary>
        /// <returns>(string) Datos de la Universidad.</returns>
        public override string ToString()
        {
            return Universidad.MostrarDatos(this);
        }
        /// <summary>
        /// De clase serializará los datos del Universidad en un XML, 
        /// incluyendo todos los datos de sus Profesores, Alumnos y Jornadas.
        /// </summary>
        /// <param name="uni">Universidad a ser serializado</param>
        /// <returns>(true) Si se pudo serializar - (false) Caso contrario</returns>
        public static bool Guardar(Universidad uni)
        {
            bool serializado = false;
            Xml<Universidad> xml = new Xml<Universidad>();
            try
            {
                serializado = xml.Guardar(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/Universidad.xml", uni);
            }
            catch (ArchivosException ex)
            {
                throw ex;
            }
            return serializado;
        }
        /// <summary>
        /// De clase, retorna una Universidad con todos los datos previamente serializados.
        /// </summary>
        /// <returns>(Universidad) Datos deserializados</returns>
        public static Universidad Leer()
        {
            bool deserializado = false;
            Universidad universidad = null, returnAux = null;
            Xml<Universidad> xml = new Xml<Universidad>();
            try
            {
                deserializado = xml.Leer(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/Universidad.xml", out universidad);
            }
            catch (ArchivosException ex)
            {
                throw ex;
            }
            if (deserializado)
            {
                returnAux = universidad;
            }
            return returnAux;
        }
        #endregion
    }
}
