using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Excepciones;
using Clases_Instanciables;

namespace UnitTestTP_03
{
    [TestClass]
    public class UnitTest1
    {
        #region "Excepcions Unit Tests"
        /// <summary>
        /// Test unitario valida excepcion de tipo NacionalidadInvalidaException
        /// al intentar instanciar un nuevo alumno con ENacionalidad Extranjero 
        /// y DNI de tipo Argentino
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(NacionalidadInvalidaException))]
        public void TestMethod01_NacionalidadInvalidaException()
        {
            //arrange 
            Alumno a2 = new Alumno(2, "Juana", "Martinez", "12234458",
            Clases_Abstractas.Persona.ENacionalidad.Extranjero, Universidad.EClases.Laboratorio,
            Alumno.EEstadoCuenta.Deudor);
            //act es manejado en el constructor de Alumno
            //asert es manejado en el ExpectedException
        }
        /// <summary>
        /// Test unitario que valida excepcion de tipo AlumnoRepetidoException
        /// al intentar agregar un alumno repetido a una Universidad
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(AlumnoRepetidoException))]
        public void TestMethod02_AlumnoRepetidoException()
        {
            //arrange
            Universidad gim = new Universidad();

            Alumno a1 = new Alumno(1, "Juan", "Lopez", "12234456",
            Clases_Abstractas.Persona.ENacionalidad.Argentino, Universidad.EClases.Programacion,
            Alumno.EEstadoCuenta.Becado);

            Alumno a2 = new Alumno(1, "Juan", "Lopez", "12234456",
            Clases_Abstractas.Persona.ENacionalidad.Argentino, Universidad.EClases.Programacion,
            Alumno.EEstadoCuenta.Becado);

            Profesor p = new Profesor(1, "Juan", "Lopez", "12234456",
            Clases_Abstractas.Persona.ENacionalidad.Argentino);

            //act
            gim += a1;
            gim += a2;
            //asert es manejado en el ExpectedException
        }
        #endregion

        #region "Numeric Unit Test"
        /// <summary>
        /// Test unitario valida que el Dni pasado como string al instanciar un nuevo alumno
        /// sea luego de ser validado en la propiedad, cargado como int
        /// </summary>
        [TestMethod]
        public void TestMethod03_ValidDniNumber()
        {
            //arrange
            //act
            Alumno a1 = new Alumno(1, "Juan", "Lopez", "12234456",
            Clases_Abstractas.Persona.ENacionalidad.Argentino, Universidad.EClases.Programacion,
            Alumno.EEstadoCuenta.Becado);
            //assert
            Assert.AreEqual(12234456, a1.DNI);
        }
        #endregion

        #region "Not Null Values Tests"
        /// <summary>
        /// Test unitario valida que no haya valores nulos 
        /// en algún atributo de la clase Alumno.
        /// </summary>
        [TestMethod]
        public void TestMethod04_NotNullValueInAlumnoField()
        {
            //arrange
            //act
            Alumno a1 = new Alumno(1, "Juan", "Lopez", "12234456",
            Clases_Abstractas.Persona.ENacionalidad.Argentino, Universidad.EClases.Programacion,
            Alumno.EEstadoCuenta.Becado);
            //assert
            try { Assert.IsNotNull(a1.Nombre, "Nombre nulo"); }
            catch (Exception ex) { throw ex; }

            try { Assert.IsNotNull(a1.Apellido, "Apellido nulo"); }
            catch (Exception ex) { throw ex; }

            try { Assert.IsNotNull(a1.DNI, "Dni nulo"); }
            catch (Exception ex) { throw ex; }

            try { Assert.IsNotNull(a1.Nacionalidad, "Nacionalidad nula"); }
            catch (Exception ex) { throw ex; }
        }
        /// <summary>
        /// Test unitario valida que no haya valores null
        /// en las listas de una instancia de tipo Universidad
        /// </summary>
        [TestMethod]
        public void TestMethod05_NotNullValueInUniversidadField()
        {
            //arrange 
            //act
            Universidad universidad = new Universidad();
            //assert
            try { Assert.IsNotNull(universidad.Alumnos,"Lista de alumnos nula"); }
            catch (Exception ex) { throw ex; }

            try { Assert.IsNotNull(universidad.Instructores, "Lista de instructores nula"); }
            catch (Exception ex) { throw ex; }

            try { Assert.IsNotNull(universidad.Jornadas, "Lista de jornadas nula"); }
            catch (Exception ex) { throw ex; }
        }
        #endregion
    }
}
