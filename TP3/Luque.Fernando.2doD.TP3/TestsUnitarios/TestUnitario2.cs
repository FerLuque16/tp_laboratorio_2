using System;
using Clases_Instanciables;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestsUnitarios
{
    [TestClass]
    public class TestUnitario2
    {
        [TestMethod]
        public void JornadaConAlumnos()
        {
            Profesor p1 = new Profesor(1, "Nombre", "Apellido", "12345645", EntidadesAbstractas.Persona.ENacionalidad.Argentino);
            Jornada j1 = new Jornada(Universidad.EClases.Laboratorio, p1);

            Assert.IsNotNull(j1.Alumnos);
     
        }

        [TestMethod]
        public void UniversidadConProfesores()
        {
            Universidad universidad = new Universidad();

            Assert.IsNotNull(universidad.Instructores);
     
        }
    }
}
