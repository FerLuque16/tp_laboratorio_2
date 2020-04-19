using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Numero
    {
        private double numero;

        /// <summary>
        /// Constructor asigna 0 al atributo numero
        /// </summary>
        public Numero()
        {
            this.numero = 0;
        }

        /// <summary>
        /// Constructor que asigna el valor recibido de tipo double al atributo numero
        /// </summary>
        /// <param name="numero"></param>
        public Numero(double numero)
        {
            this.numero = numero;
        }

        /// <summary>
        /// Constructor que asigna el valor recibido de tipo string mediante la propiedad SetNumero
        /// </summary>
        /// <param name="strNumero"></param>
        public Numero(string strNumero)
        {
            this.SetNumero = strNumero;
        }


        /// <summary>
        /// Recibe un valor binario de tipo string ylo convierte en un valor decimal
        /// </summary>
        /// <param name="binario">Numero binario de tipo string a ser convertido en decimal</param>
        /// <returnsRetorna un string, que sera el numero convertido en decimal si es que se puedo validar, de lo contrario retorna el mensaje "Valor invalido"></returns>
        public static string BinarioDecimal(string binario)
        {
            string res;
            int numeroDecimal=0;

            if (binario is null || binario =="")
            {
                res = "Valor invalido";
            }

            else
            {
                for (int i = 1; i < binario.Length; i++)
                {
                    numeroDecimal += (int)Math.Pow(2, binario.Length - i) * int.Parse(binario[i - 1].ToString());
                }

                res = numeroDecimal.ToString();


            }

            return res;
            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="numero"></param>
        /// <returns></returns>
        public static string DecimalBinario(double numero)
        {

            string strNumero;

            strNumero = numero.ToString();
            
            return DecimalBinario(strNumero);
        }

        /// <summary>
        /// Metodo que convierte el numero decimal recibido en binario
        /// </summary>
        /// <param name="strNumero">Numero de tipo string que se validara y de ser asi se convertira en binario</param>
        /// <returns>Retorna un string, que sera el numero binario si es que se puedo validar, de lo contrario retorna el mensaje "Valor invalido" </returns>
        public static string DecimalBinario(string strNumero)
        {

            int numero;
            string binario = "";

            if(strNumero is null || !int.TryParse(strNumero,out numero))
            {
                binario = "Valor invalido";
            }
            else
            {
                while(numero > 0)
                {
                    binario = (numero % 2).ToString() + binario;
                    numero = numero / 2;

                }
            }



            return binario;
        }

        /// <summary>
        /// Realiza la sobrecarga del operador + con la suma de los objetos de la Clase Numero 
        /// </summary>
        /// <param name="num1">Objeto de la clase Numero que se usara para la sobrecarga</param>
        /// <param name="num2">Objeto de la clase Numero que se usara para la sobrecarga</param>
        /// <returns>Retorna el resultado de la suma de los 2 atributos</returns>
        public static double operator +(Numero num1, Numero num2)
        {
            return num1.numero + num2.numero;
        }

        /// <summary>
        /// Realiza la sobrecarga del operador - con la suma de los objetos de la Clase Numero 
        /// </summary>
        /// <param name="num1">Objeto de la clase Numero que se usara para la sobrecarga</param>
        /// <param name="num2">Objeto de la clase Numero que se usara para la sobrecarga</param>
        /// <returns>Retorna el resultado de la resta de los 2 atributos</returns>
        public static double operator -(Numero num1, Numero num2)
        {
            return num1.numero - num2.numero;
        }


        /// <summary>
        /// Realiza la sobrecarga del operador * con la suma de los objetos de la Clase Numero 
        /// </summary>
        /// <param name="num1"></param>
        /// <param name="num2"></param>
        /// <returns>Retorna el resultado del producto entre los 2 atributos</returns>
        public static double operator *(Numero num1, Numero num2)
        {
            return num1.numero * num2.numero;
        }

        /// <summary>
        /// Realiza la sobrecarga del operador * con la suma de los objetos de la Clase Numero 
        /// </summary>
        /// <param name="num1">Objeto de la clase Numero que se usara para la sobrecarga</param>
        /// <param name="num2">Objeto de la clase Numero que se usara para la sobrecarga</param>
        /// <returns>Retorna el resultado de la division entre los 2 atributos. Si el el atributo del segundo paramettro es 0, se retornara el minino valor que pueda tener un double</returns>
        public static double operator /(Numero num1, Numero num2)
        {
            if (num2.numero == 0)
                return double.MinValue;

            return num1.numero / num2.numero;
        }


        /// <summary>
        /// Valida que el valor recibido sea numerico
        /// </summary>
        /// <param name="strNumero">Es el valor a validar</param>
        /// <returns>Retorna el valor en formato double. Retorna 0 si el valor no es nuemrico</returns>
        private double ValidarNumero(string strNumero)
        {
            double aux;

            if (double.TryParse(strNumero, out aux))    
                return aux;
            
            else
                return 0;
            
        }

        /// <summary>
        /// Valida y asigna el valor al atributo del objeto de la Clase Numero
        /// </summary>
        private string SetNumero
        {
           

            set 
            {
                double aux = ValidarNumero(value);

                if (aux !=0)
                {
                    this.numero = aux;
                }



            }
        }
    }
}
