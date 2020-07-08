using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;

namespace Entidades
{
    public class Automovil : Vehiculo
    {
        /// <summary>
        /// Enumerado que contiene el tipo deauto
        /// </summary>
        public enum ETipo { Monovolumen, Sedan }
        ETipo tipo;

        /// <summary>
        /// Por defecto, TIPO será Monovolumen
        /// </summary>
        /// <param name="marca">Se asigna a marca</param>
        /// <param name="chasis">Se asigna a marca</param>
        /// <param name="color">se asigna a marca</param>
        public Automovil(EMarca marca, string chasis, ConsoleColor color)
            : base(chasis, marca, color)
        {
            this.tipo = ETipo.Monovolumen;
        }
        /// <summary>
        /// Constructo que llama al constructor base y setea los campos de automovil
        /// </summary>
        /// <param name="marca">Se asigna a marca</param>
        /// <param name="chasis">Se asigna a chasis</param>
        /// <param name="color">Se asigna a color</param>
        /// <param name="tipo">Se asigna a tipo</param>
        public Automovil(EMarca marca, string chasis, ConsoleColor color,ETipo tipo):this(marca,chasis,color)
        {
            this.tipo = tipo;
        }

        /// <summary>
        /// Los automoviles son medianos
        /// </summary>
        public override ETamanio Tamanio
        {
            get
            {
                return ETamanio.Mediano;
            }
        }

        /// <summary>
        /// Metodo redefinido que retorna los datos del automovil
        /// </summary>
        /// <returns>Retorna un string con los datos del automovil</returns>
        public override sealed string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("AUTOMOVIL");
            sb.AppendLine(base.Mostrar());
            sb.AppendLine("TAMAÑO : "+ this.Tamanio);
            sb.AppendLine("TIPO : " + this.tipo);
            sb.AppendLine("---------------------");

            return sb.ToString();
        }
    }
}
