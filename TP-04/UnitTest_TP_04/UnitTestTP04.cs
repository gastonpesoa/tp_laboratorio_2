using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades;

namespace UnitTest_TP_04
{
    /// <summary>
    ///     Verifica que la lista de Paquetes del Correo esté instanciada.
    /// </summary>
    [TestClass]
    public class UnitTestTP04
    {
        [TestMethod]
        public void VerificaListaDePaquetesCorreoInstanciada()
        {
            // arrange
            Correo correo;
            // act
            correo = new Correo();
            // assert
            Assert.IsNotNull(correo.Paquetes);
        }

        /// <summary>
        ///     Verifica que no se puedan cargar dos Paquetes con el mismo Tracking ID.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(TrackingIdRepetidoException))]
        public void VerificaQueNoSePuedanCargarDosPaquetesConElMismoTrackingID()
        {
            // arrange
            Correo correo = new Correo();
            Paquete p1 = new Paquete("direccion1", "1");
            Paquete p2 = new Paquete("direccion2", "1");
            // act
            correo += p1;
            correo += p2;
            // assert es manejado en el ExpectedException
        }
    }

    
}
