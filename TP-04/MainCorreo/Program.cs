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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MainCorreo
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FrmPpal());
        }
    }
}
