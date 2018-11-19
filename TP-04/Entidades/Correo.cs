using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Entidades
{
    public class Correo : IMostrar<List<Paquete>>
    {
        #region "Campos"
        private List<Thread> mockPaquetes;
        private List<Paquete> paquetes;
        #endregion

        #region "Propiedades"
        public List<Paquete> Paquetes 
        {
            get { return this.paquetes; }
            set { this.paquetes = value; }
        }
        #endregion

        #region "Constructor"
        /// <summary>
        /// Constructor por defecto, inicializa las listas mockPaquetes y paquetes.
        /// </summary>
        public Correo()
        {
            this.mockPaquetes = new List<Thread>();
            this.paquetes = new List<Paquete>();
        }
        #endregion

        #region "Operadores"
        /// <summary>
        ///     Sobrecarga del operador +:
        ///         a.Controla si el paquete ya está en la lista. En el caso de que esté, 
        ///             se lanzará la excepción TrackingIdRepetidoException.
        ///         b.De no estar repetido, agrega el paquete a la lista de paquetes.
        ///         c.Crea un hilo para el método MockCicloDeVida del paquete, y agregar dicho hilo a mockPaquetes.
        ///         d.Ejecuta el hilo.
        /// </summary>
        /// <param name="c">
        ///     (Correo) Correo en el que se agregará el paquete.
        /// </param>
        /// <param name="p">
        ///     (Paquete) Paquete que se agregará al correo.
        /// </param>
        /// <returns>
        ///     (Correo) Correo más el paquete agregado, 
        ///         en caso de que no se halla encontrado previamente cargado.
        ///     (TrackingIdRepetidoException) En caso de que se halla encontrado previamente cargado.
        /// </returns>
        public static Correo operator +(Correo c, Paquete p)
        {
            // Control de si el paquete ya está en la lista.
            foreach (Paquete paquete in c.Paquetes)
            {
                if (paquete == p)
                {
                    throw new TrackingIdRepetidoException("El Traking ID " + p.TrackingID + " ya figura en la lista de envios.");
                }
            }
            // En caso de no estar el paquete previamente cargado en la lista:
            // Agrega el paquete a la lista
            c.Paquetes.Add(p);
            // Instancia de un nuevo hilo para el método MockCicloDeVida del paquete.
            Thread t = new Thread(p.MockCicloDeVida);
            // Se agrega el hilo a la lista de mockPaquetes.
            c.mockPaquetes.Add(t);
            // Se incia el hilo.
            t.Start();
            // Retorno del correo mas el nuevo paquete y su ciclo de vida agregado a sus listas.
            return c;
        }
        #endregion

        #region "Métodos"
        /// <summary>
        ///     Retorna los datos de todos los paquetes de la lista del correo.
        /// </summary>
        /// <param name="elementos">
        ///     (IMostrar<List<Paquete>>) Lista de paquetes a ser mostrada.
        /// </param>
        /// <returns>
        ///     (string) Datos de la lista de paquetes del correo.
        /// </returns>
        public string MostrarDatos(IMostrar<List<Paquete>> elementos) 
        {
            StringBuilder s = new StringBuilder();

            foreach (Paquete paquete in ((Correo)elementos).Paquetes)
            {
                s.AppendFormat("{0} ({1})\n", paquete.ToString(), paquete.Estado);
            }
            return s.ToString();
        }

        /// <summary>
        ///     Cierra todos los hilos activos de la lista mockPaquetes.
        /// </summary>
        public void FinEntregas()
        {
            foreach (Thread t in this.mockPaquetes)
            {
                // Si el hilo no es null y esta activo se cierra.
                if (t.IsAlive && t != null)
                {
                    t.Abort();
                }
            }
        }
        #endregion
    }
}
