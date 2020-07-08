using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{

    
    

    /// <summary>
    /// La clase Vehiculo no deberá permitir que se instancien elementos de este tipo.
    /// </summary>
    public abstract class Vehiculo
    {
        /// <summary>
        /// Enumerado que contiene la marca de los vehiculos
        /// </summary>
        public enum EMarca
        {
            Chevrolet, Ford, Renault, Toyota, BMW, Honda
        }
        /// <summary>
        /// Enumerado que contiene el tamaño de los vehiculos
        /// </summary>

        public enum ETamanio
        {
            Chico, Mediano, Grande
        }

        EMarca marca;
        string chasis;
        ConsoleColor color;

        /// <summary>
        /// ReadOnly: Retornará el tamaño
        /// </summary>
        public abstract ETamanio Tamanio { get; }

        /// <summary>
        /// Constructor que setea todos los campos
        /// </summary>
        /// <param name="chasis">Se asigna al atributo chasis</param>
        /// <param name="marca">Se asigan al atriibuto marca</param>
        /// <param name="color">Se asigna al atributo color</param>
        public Vehiculo(string chasis, EMarca marca, ConsoleColor color)
        {
            this.chasis = chasis;
            this.marca = marca;
            this.color = color;
        }


        /// <summary>
        /// Publica todos los datos del Vehiculo.
        /// </summary>
        /// <returns></returns>
        public virtual string Mostrar()
        {
            StringBuilder sb = new StringBuilder();
            // sb.AppendLine((string)this);
            sb.AppendLine("CHASIS: " + this.chasis);
            sb.AppendLine("MARCA : " + this.marca);
            sb.AppendLine("COLOR : " + this.color);

            return sb.ToString();
        }

        /// <summary>
        /// Retorna los datos del vehiculo
        /// </summary>
        /// <param name="p">Vehiculod de donde tomara los datos</param>
        /// <returns>Retorna un string con los datos del vehiculo</returns>
        public static explicit operator string(Vehiculo p)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(p.Mostrar());

           

            return sb.ToString();
        }

        /// <summary>
        /// Dos vehiculos son iguales si comparten el mismo chasis
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        public static bool operator ==(Vehiculo v1, Vehiculo v2)
        {
            return v1.chasis == v2.chasis;
        }
        /// <summary>
        /// Dos vehiculos son distintos si su chasis es distinto
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        public static bool operator !=(Vehiculo v1, Vehiculo v2)
        {
            return !(v1 == v2);
        }
    }
}
