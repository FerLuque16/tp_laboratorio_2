using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades

{
    public class TrackingRepetidoException : Exception
    {
        /// <summary>
        /// Excepcion que se usara cuando 2 paquetes sean iguales
        /// </summary>
        /// <param name="mensaje">Mensaje que contendra la exception</param>
        public TrackingRepetidoException(string mensaje) : base(mensaje)
        {

        }
        /// <summary>
        /// Excepcion que se usara cuando 2 paquetes sean iguales
        /// </summary>
        /// <param name="mensaje">Mensaje que contendra la excepcion</param>
        /// <param name="inner">Excepcion que recibira de la excepcion padre</param>
        public TrackingRepetidoException(string mensaje, Exception inner) : base(mensaje, inner)
        {

        }
    }
}
