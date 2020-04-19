using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class Calculadora
    {
        /// <summary>
        ///  Realiza la operacion que corresponda de acuerdo al operador recibido. Las operaciones son sobrecargas de operadores
        /// </summary>
        /// <param name="num1">Objeto de la clase Numero que contiene el atributo para la operacion</param>
        /// <param name="num2">Objeto de la clase Numero que contiene el atributo para la operacion</param>
        /// <param name="operador">Operador que se validara, y respecto al tipo de operador, realizara la operacion que corresponda</param>
        /// <returns>Retorna el resultado obtenido de dicha operacion</returns>
        public static double Operar(Numero num1, Numero num2, string operador)
        {
            double resultado=0;

            if (ValidarOperador(operador) == "ok")
            {

                switch (operador)
                {
                    case "+":
                        resultado = num1 + num2;
                        break;

    
                    case "-":
                        resultado = num1 - num2;
                        break;


                    case "*":
                        resultado = num1 * num2;
                        break;

                    case "/":
                        resultado = num1 / num2;
                        break;
                }

            }


            return resultado;
        }

        /// <summary>
        /// Valida que el operador sea valido.
        /// </summary>
        /// <param name="operador">Es el operador a validar </param>
        /// <returns>Retorna "+" si el operador no es valido. Retorna "ok" si el operador es valido</returns>
        private static string ValidarOperador (string operador)
        {
            if (operador != "/" && operador != "*" && operador != "-" && operador != "+" )
            {
                return "+";
            }

            return "ok";
        }
       
    }
}
