using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Archivos;
using EntidadesAbstractas;
using Clases_Instanciables;
using Excepciones;

namespace TestsUnitarios
{
    [TestClass]
    public class TestUnitario1
    {
        [TestMethod]
        [ExpectedException(typeof(DniInvalidoException))]
        public void DniInvalido()
        {

            Alumno a1;
           
            a1 = new Alumno(50, "Nombre", "Apeliido", "dniNoValido", Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio);

        }

        [TestMethod]
        [ExpectedException(typeof(NacionalidadInvalidaException))]
        public void NacionalidadInvalida()
        {
            Alumno a1;

            a1 = new Alumno(50, "Nombre", "Apeliido", "12345655", Persona.ENacionalidad.Extranjero, Universidad.EClases.Laboratorio);

        }

       

        

    }
}
