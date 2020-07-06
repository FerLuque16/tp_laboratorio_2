using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades;
using MainCorreo;

namespace TestUnitarioTP4
{
    [TestClass]
    public class Testeos
    {
        /// <summary>
        /// Verifica que la lista de paquetes este instanciada
        /// </summary>
        [TestMethod]
        public void ListaInstanciada()
        {
            Correo correo = new Correo();

            Assert.IsNotNull(correo.Paquetes);
        }

        /// <summary>
        /// Verifica que no hayan paquetes repetidos en el mismo correo
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(TrackingRepetidoException))]
        public void IDRepetidoTest()
        {
            Correo correo = new Correo();

            Paquete p1 = new Paquete("9 de Julio", "000-100-0005");
            Paquete p2 = new Paquete("Avenida de Mayo", "000-100-0005");

            correo += p1;
            correo += p2;

        }
    }
}
