using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Entidades
{
    public class Paquete : IMostrar<Paquete>
    {
        #region "Delegado"
        public delegate void DelegadoEstado(object paquete, EventArgs e);
        public delegate void DelegadoException(object paquete, Exception ex);
        #endregion

        #region "Eventos"
        public event DelegadoEstado InformaEstado;
        public event DelegadoException InformaExcepcion;
        #endregion

        #region "Enumerado"
        public enum EEstado { Ingresado, EnViaje, Entregado }
        #endregion

        #region "Campos"
        private string direccionEntrega;
        private EEstado estado;
        private string trackingID;
        #endregion

        #region "Propiedades"
        public string DireccionEntrega
        {
            get { return this.direccionEntrega; }
            set { this.direccionEntrega = value; }
        }

        public EEstado Estado
        {
            get { return this.estado; }
            set { this.estado = value; }
        }

        public string TrackingID
        {
            get { return this.trackingID; }
            set { this.trackingID = value; }
        }
        #endregion

        #region "Constructor"
        /// <summary>
        ///     Constructor de instancias de la clase Paquete.
        /// </summary>
        /// <param name="direccionEntrega">
        ///     Dirección de entrega que se le asignará al paquete.
        /// </param>
        /// <param name="trackingID">
        ///     ID de seguimiento que se le asignará al paquete.
        /// </param>
        public Paquete(string direccionEntrega, string trackingID)
        {
            this.DireccionEntrega = direccionEntrega;
            this.TrackingID = trackingID;
        }
        #endregion

        #region "Operadores"
        /// <summary>
        ///     Dos paquetes serán iguales siempre y cuando su Tracking ID sea el mismo.
        /// </summary>
        /// <param name="p1">
        ///     Paquete 1 a ser comparado.
        /// </param>
        /// <param name="p2">
        ///     Paquete 2 a ser comparado.
        /// </param>
        /// <returns>
        ///     (true) En caso de ser iguales.
        ///     (flase) De ser diferentes.
        /// </returns>
        public static bool operator ==(Paquete p1, Paquete p2)
        {
            return p1.TrackingID == p2.TrackingID;
        }

        /// <summary>
        ///     Dos paquetes serán distintos siempre y cuando su Tracking ID sea diferente.
        /// </summary>
        /// <param name="p1">
        ///     Paquete 1 a ser comparado.
        /// </param>
        /// <param name="p2">
        ///     Paquete 2 a ser comparado.
        /// </param>
        /// <returns>
        ///     (true) En caso de ser distintos.
        ///     (false) De ser iguales.
        /// </returns>
        public static bool operator !=(Paquete p1, Paquete p2)
        {
            return !(p1 == p2);
        }
        #endregion

        #region "Métodos"
        /// <summary>
        ///     Cambia el estado del paquete  de la siguiente forma:
        ///         a.Coloca una demora de 4 segundos.
        ///         b.Pasa al siguiente estado.
        ///         c.Informa el estado a través del evento InformarEstado. 
        ///         d.Repite las acciones desde el punto A hasta que el estado sea Entregado.
        ///         e.Finalmente guardar los datos del paquete en la base de datos
        ///         f.En caso de producirse un error se informa mediante el evento InformaExcepcion.
        /// </summary>
        public void MockCicloDeVida()
        {
            try
            {
                // Se iterará hasta que el estado del paquete sea Entregado.
                while ((int)this.Estado <= 2)
                {
                    // En caso de que halla algún manejador agregado al evento se lanza InformaEstado.
                    if (InformaEstado != null)
                    {
                        InformaEstado(this, null);
                    }
                    // Pausa de 4 segundos.
                    Thread.Sleep(4000);
                    // Si el estado no es Entregado se cambia al estado próximo.
                    if ((int)this.Estado < 2)
                    {
                        int i = (int)this.Estado + 1;
                        this.Estado = (EEstado)i;
                    }
                    else
                    {
                        break;
                    }
                }
                //Se inserta el paquete en la base de datos una vez que el paquete llega el estado Entregado.
                PaqueteDAO.Insertar(this); 
            }
            catch (Exception ex)
            {
                // En caso de error se dispara otro evento que puede manejar una excepción.
                InformaExcepcion(this, ex);
            }
        }

        /// <summary>
        ///     Expone la informción del paquete.
        /// </summary>
        /// <param name="elemento">
        ///     (IMostrar<Paquete>) Elemento a ser mostrado.
        /// </param>
        /// <returns>
        ///     (string) Datos del paquete.
        /// </returns>
        public string MostrarDatos(IMostrar<Paquete> elemento)
        {
            StringBuilder s = new StringBuilder();
            s.AppendFormat("{0} para {1}",((Paquete)elemento).TrackingID, ((Paquete)elemento).DireccionEntrega);
            return s.ToString();
        }

        /// <summary>
        ///     Sobrecarga del método ToString().
        ///     Reutiliza el método MostrarDatos(IMostrar<Paquete> elemento) 
        ///     para retorna la información del paquete.
        /// </summary>
        /// <returns>
        ///     (string) Datos del paquete.
        /// </returns>
        public override string ToString()
        {
            return this.MostrarDatos(this); 
        }
        #endregion

    }
}
