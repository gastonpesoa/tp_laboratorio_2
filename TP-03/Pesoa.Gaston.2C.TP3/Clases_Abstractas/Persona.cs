using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;

namespace Clases_Abstractas
{
    public abstract class Persona
    {
        #region "Enumerado"
        public enum ENacionalidad
        {
            Argentino, 
            Extranjero
        }
        #endregion

        #region "Campos"
        private int dni;
        private string nombre;
        private string apellido;
        private ENacionalidad nacionalidad;
        #endregion

        #region "Propiedades"
        /// <summary>
        /// Asigna el valor al campo dni a través de la propiedad DNI 
        /// previa validación por medio del método ValidarDni(ENacionalidad, string).
        /// </summary>
        public string StringToDni
        {
            set
            {
                int dniValidado = 0;
                try
                {
                    dniValidado = this.ValidarDni(this.nacionalidad, value);
                }
                catch (NacionalidadInvalidaException ex)
                {
                    throw ex;
                }
                catch (DniInvalidoException ex)
                {
                    throw ex;
                }
                this.DNI = dniValidado;
            }
        }
        /// <summary>
        /// Obtiene y asigna el valor de dni previa validación por medio del método ValidarDni(ENacionalidad, int).
        /// </summary>
        public int DNI
        {
            get { return this.dni; }
            set
            {
                int dniValidado = 0;
                try
                {
                    dniValidado = this.ValidarDni(this.nacionalidad, value);
                }
                catch (NacionalidadInvalidaException ex)
                {
                    throw ex;
                }
                this.dni = dniValidado;
            }
        }
        /// <summary>
        /// Obtiene y asigna el valor de nombre previa validación por medio de ValidarNombreApellido(string).
        /// Caso de valor incorrecto, no se cargará.
        /// </summary>
        public string Nombre
        {
            get { return this.nombre; }
            set
            {
                if (!(this.ValidarNombreApellido(value) is null))
                {
                    this.nombre = value;
                }
            }
        }
        /// <summary>
        /// Obtiene y asigna el valor de apellido previa validación por medio de ValidarNombreApellido(string).
        /// Caso de valor incorrecto, no se cargará.
        /// </summary>
        public string Apellido
        {
            get { return this.apellido; }
            set
            {
                if (!(this.ValidarNombreApellido(value) is null))
                {
                    this.apellido = value;
                }
            }
        }
        /// <summary>
        /// Obtiene y asigna el valor de nacionalidad.
        /// </summary>
        public ENacionalidad Nacionalidad
        {
            get { return this.nacionalidad; }
            set { this.nacionalidad = value; }
        }
        #endregion

        #region "Constructores"
        /// <summary>
        /// Constructor por defecto.
        /// </summary>
        public Persona()
        {

        }
        /// <summary>
        /// Constructor de instancias.
        /// </summary>
        /// <param name="nombre">Nombre a ser asignado</param>
        /// <param name="apellido">Apellido a ser asignado</param>
        /// <param name="nacionalidad">Nacionalidad a ser asignada</param>
        public Persona(string nombre, string apellido, ENacionalidad nacionalidad)
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Nacionalidad = nacionalidad;
        }
        /// <summary>
        /// Constructor de instancias.
        /// </summary>
        /// <param name="nombre">Nombre a ser asignado</param>
        /// <param name="apellido">Apellido a ser asignado</param>
        /// <param name="dni">DNI a ser asignado</param>
        /// <param name="nacionalidad">Nacionalidad a ser asignada</param>
        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad)
            : this(nombre, apellido, nacionalidad)
        {
            this.DNI = dni;
        }
        /// <summary>
        /// Constructor de instancias.
        /// </summary>
        /// <param name="nombre">Nombre a ser asignado</param>
        /// <param name="apellido">Apellido a ser asignado</param>
        /// <param name="dni">DNI a ser asignado</param>
        /// <param name="nacionalidad">Nacionalidad a ser asignada</param>
        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : this(nombre, apellido, nacionalidad)
        {
            this.StringToDni = dni;
        }
        #endregion

        #region "Métodos"
        /// <summary>
        /// Validará que el DNI sea correcto, teniendo en cuenta su nacionalidad. 
        /// Argentino entre 1 y 89999999 y Extranjero entre 90000000 y 99999999. 
        /// Caso contrario, se lanzará la excepción NacionalidadInvalidaException.
        /// </summary>
        /// <param name="nacionalidad">Nacionalidad que se tendrá en cuenta para realizar la validación</param>
        /// <param name="dato">Dni que se validará</param>
        /// <returns>(int) Dni en caso de que sea correcto</returns>
        private int ValidarDni(ENacionalidad nacionalidad, int dato)
        {
            int returnAux = 0;
            switch (nacionalidad)
            {
                case ENacionalidad.Argentino:
                    if (dato < 1 || dato > 89999999)
                    {
                        throw new NacionalidadInvalidaException();
                    }
                    returnAux = dato;
                    break;
                case ENacionalidad.Extranjero:
                    if (dato < 90000000 || dato > 99999999)
                    {
                        throw new NacionalidadInvalidaException();
                    }
                    returnAux = dato;
                    break;
                default:
                    break;
            }
            return returnAux;
        }
        /// <summary>
        /// Si el DNI presenta un error de formato (más caracteres de los permitidos, letras, etc.) 
        /// se lanzará DniInvalidoException.
        /// </summary>
        /// <param name="nacionalidad">Nacionalidad que se tendrá en cuenta para realizar la validación</param>
        /// <param name="dato">Dni que se validará</param>
        /// <returns>(int) Dni en caso de que sea correcto</returns>
        private int ValidarDni(ENacionalidad nacionalidad, string dato)
        {
            int dni = 0;
            if (!int.TryParse(dato, out int result))
            {
                throw new DniInvalidoException();
            }
            else
            {
                try
                {
                    dni = this.ValidarDni(nacionalidad, result);
                }
                catch (NacionalidadInvalidaException ex)
                {
                    throw ex;
                }
            }
            return dni;
        }
        /// <summary>
        /// Validará que los nombres sean cadenas con caracteres válidos para nombres.
        /// </summary>
        /// <param name="dato">Cadena de caracteres a validar</param>
        /// <returns>(string) Dato validado en caso de ser correcto - (null) Caso contrario</returns>
        private string ValidarNombreApellido(string dato)
        {
            string returnAux = null;
            bool esLetra;
            int i = 0;

            do
            {
                esLetra = char.IsLetter(dato[i]);
                i++;
            } while (esLetra && i < dato.Length);

            if (esLetra)
            {
                returnAux = dato;
            }
            return returnAux;
        }
        /// <summary>
        /// Sobrescritura del método ToString() expone datos de la Persona.
        /// </summary>
        /// <returns>(string) Datos de la Persona.</returns>
        public override string ToString()
        {
            StringBuilder s = new StringBuilder();
            s.AppendFormat("NOMBRE COMPLETO: {0}, {1}\nNACIONALIDAD: {2}", this.Apellido, this.Nombre, this.Nacionalidad);
            return s.ToString();
        }
        #endregion
    }
}
