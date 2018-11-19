///<universidad> 
///     Universidad Tecnológica Nacional Facultad Regional Avellaneda
///</universidad>
///<carrera>
///     Técnico Superior en Programación
///</carrera>
///<materia>
///     Laboratorio de Programación II
///</materia>
///<trabajo>
///     Trabajo Práctico Nº4
///</trabajo>
///<docente>
///     Federico Dávila
///</docente>
///<alumno>
///     Gastón Pesoa
///</alumno>
///<descripción>
///     Aplicación para un sistema de correo, simula los pasajes desde su ingreso hasta su entrega:
///         A. En la parte superior vemos los paquetes Ingresados y como cambian su estado a En Viaje y 
///         luego Finalizados. Al alcanzar ese último estado, guarda la información del paquete 
///         en una base de datos provista para tal fin.
///         B. Al seleccionar un elemento de la lista de "Entregado" y hacer click con el botón derecho del mouse, 
///         vemos un menú Mostrar. Al hacer click en este, muestra la información del paquete 
///         en el cuadro de texto situado en la parte inferior izquierda.
///         C. En la parte inferior derecha se ingresan paquetes al sistema al cargar los datos 
///         y hacer click en el botón Agregar.
///         D. Al hacer click en el botón Mostrar Todos, se muestra la información en el cuadro de texto 
///         situado en la parte inferior izquierda y se guarda esa información en un archivo de texto 
///         en el escritorio de la máquina.
///</descripción>

using Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MainCorreo
{
    public partial class FrmPpal : Form
    {
        #region "Campos"
        private Paquete paquete;
        private Correo correo;
        #endregion

        /// <summary>
        ///     Constructor por defecto.
        /// </summary>
        public FrmPpal()
        {
            InitializeComponent();
        }

        /// <summary>
        ///     Manejador de evento asociado al evento Load:
        ///         Crea una nueva instancia de la clase Correo.
        /// </summary>
        /// <param name="sender">
        ///     (object) Emisor del evento.
        /// </param>
        /// <param name="e">
        ///     (EventArgs) Proporciona data para almacenar información del evento.
        /// </param>
        private void FrmPpal_Load(object sender, EventArgs e)
        {
            this.correo = new Correo();
        }

        /// <summary>
        ///     Manejador del evento Click del botón btnAgregar:
        ///         a.Crea un nuevo paquete y asocia al evento InformaEstado el método paq_InformaEstado.
        ///             y al evento InformaExcepcion el método paq_InformaExcepcion.
        ///         b.Agrega el paquete al correo, controlando las excepciones que puedan derivar de dicha acción.
        ///         c.Llama al método ActualizarEstados.
        /// </summary>
        /// <param name="sender">
        ///     (object) Emisor del evento Click del botón btnAgregar.
        /// </param>
        /// <param name="e">
        ///     (EventArgs) Proporciona data para almacenar información del evento.
        /// </param>
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            // Instancia de un nuevo paquete con los datos cargados en el formulario.
            this.paquete = new Paquete(txtDireccion.Text, mtxtTrackingID.Text);
            // Se asocia al evento InformaEstado el manejador paq_InformaEstado.
            paquete.InformaEstado += paq_InformaEstado;
            // Se asocia al evento InformaExcepcion el manejador paq_InformaExcepcion.
            paquete.InformaExcepcion += paq_InformaExcepcion;

            try
            {
                // Se agrega al paquete al correo
                // Se inicia un nuevo hilo y desencadenan los eventos. 
                correo += paquete;
            }
            catch (Exception ex)
            {
                // Se informa en caso de que el paquete ya se encuentre en la lista previemante.
                MessageBox.Show(ex.Message, "Paquete repetido", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
        }

        /// <summary>
        ///     Manejador de evento asociado al evento InformaEstado:
        ///         a.Verifica que el hilo, que invoca al manejador, 
        ///             sea el mismo que el hilo donde se creó el formuluario.
        ///         b.En caso de no ser el mismo hilo, crea un nuevo delegado Paquete.DelegadoEstado,
        ///             que se llama a si mismo asincrónicamente usando el método Invoke().
        ///         c.De ser el hilo, que llama al manejador del evento, el mismo que el hilo donde se creó el 
        ///             formulario, se llama al método ActualizarEstados() directamente.
        /// </summary>
        /// <param name="paquete">
        ///     (Paquete) Paquete emisor del evento InformaExcepcion. 
        /// </param>
        /// <param name="e">
        ///     (EventArgs) Proporciona data para almacenar información del evento.
        /// </param>
        private void paq_InformaEstado(object paquete, EventArgs e)
        {
            if (this.InvokeRequired)
            {
                Paquete.DelegadoEstado d = new Paquete.DelegadoEstado(paq_InformaEstado);
                this.Invoke(d, new object[] { paquete, e });
            }
            else
            {
                this.ActualizarEstados();
            }
        }

        /// <summary>
        ///     Manejador de evento asociado al evento InformaExcepcion:
        ///         Informa en caso de error al intentar conexión con la base de datos de SQL Server.
        /// </summary>
        /// <param name="paquete">
        ///     (object) Paquete emisor del evento, que se intentá agregar a la base de datos.
        /// </param>
        /// <param name="ex">
        ///     (Exception) Excepcion capturada al intentar agregar el paquete a la base de datos.
        /// </param>
        private void paq_InformaExcepcion(object paquete, Exception ex)
        {
            MessageBox.Show("Error al intentar insertar el paquete con el El Traking ID " + 
                ((Paquete)paquete).TrackingID + " en la base de datos de SQL Server\n" +
                ex.Message, "Error de Conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /// <summary>
        ///     Limpia los 3 ListBox, luego recorre la lista de paquetes agregando cada uno de ellos, 
        ///     en el listado que corresponda.
        /// </summary>
        private void ActualizarEstados()
        {
            lstEstadoIngresado.Items.Clear();
            lstEstadoEnViaje.Items.Clear();
            lstEstadoEntregado.Items.Clear();

            foreach (Paquete paquete in correo.Paquetes)
            {
                switch (paquete.Estado)
                {
                    case Paquete.EEstado.Ingresado:
                        lstEstadoIngresado.Items.Add(paquete);
                        break;
                    case Paquete.EEstado.EnViaje:
                        lstEstadoEnViaje.Items.Add(paquete);
                        break;
                    case Paquete.EEstado.Entregado:
                        lstEstadoEntregado.Items.Add(paquete);
                        break;
                    default:
                        break;
                }
            }
        }

        /// <summary>
        ///     Llama al método genérico MostrarInformacion, especificando el parámetro a el tipo <List<Paquete>>.
        /// </summary>
        /// <param name="sender">
        ///     (object) Emisor del evento.
        /// </param>
        /// <param name="e">
        ///     (EventArgs) Proporciona data para almacenar información del evento.
        /// </param>
        private void btnMostrarTodos_Click(object sender, EventArgs e)
        {
            this.MostrarInformacion<List<Paquete>>((IMostrar<List<Paquete>>)this.correo);
        }

        /// <summary>
        ///     Evalua que el atributo elemento no sea nulo y:
        ///         a.Muestra los datos de elemento en el rtbMostrar.
        ///         b.Utiliza el método de extensión para guardar los datos en un archivo llamado salida.txt.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="elemento"></param>
        private void MostrarInformacion<T>(IMostrar<T> elemento)
        {
            if (!(elemento is null))
            {
                try
                {
                    rtbMostrar.Text = elemento.MostrarDatos(elemento);
                    rtbMostrar.Text.Guardar(Environment.GetFolderPath
                        (Environment.SpecialFolder.Desktop) + "\\salida.txt");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "No se ha creado el archivo de texto", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        ///     Manejador de evento asociado al evento FormClosing:
        ///         Llama al método FinEntregas a fin de cerrar todos los hilos abiertos.
        /// </summary>
        /// <param name="sender">
        ///     (object) Emisor del evento.
        /// </param>
        /// <param name="e">
        ///     (FormClosingEventArgs) Proporciona data para almacenar información del evento.
        /// </param>
        private void FrmPpal_FormClosing(object sender, FormClosingEventArgs e)
        {
            correo.FinEntregas();
        }

        /// <summary>
        ///     Manejador de evento asociado al evento Click del control mostrarToolStripMenuItem.
        ///         Muestra la información del paquete en el cuadro de texto del rtbMostrar.
        /// </summary>
        /// <param name="sender">
        ///     (object) Emisor del evento.
        /// </param>
        /// <param name="e">
        ///     (EventArgs) Proporciona data para almacenar información del evento.
        /// </param>
        private void mostrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rtbMostrar.Clear();
            if (lstEstadoEntregado.SelectedIndex >= 0)
            {
                rtbMostrar.Text =
                    lstEstadoEntregado.Items[lstEstadoEntregado.SelectedIndex].ToString();
            }
        }
    }
}
