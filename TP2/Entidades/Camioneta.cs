using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Camioneta : Vehiculo
    {
        /// <summary>
        /// Constructor que llama al constructor base y setea los campos de camioneta
        /// </summary>
        /// <param name="marca">Se asigna a marca</param>
        /// <param name="chasis">Se asigna a chasis</param>
        /// <param name="color">se asigna a color</param>
        public Camioneta(EMarca marca, string chasis, ConsoleColor color)
            : base(chasis, marca, color)
        {
        }
        /// <summary>
        /// Las camionetas son grandes
        /// </summary>
        public override ETamanio Tamanio
        {
            get
            {
                return ETamanio.Grande;
            }
        }

        /// <summary>
        ///  Metodo redefinido que retorna los datos de la moto
        /// </summary>
        /// <returns>Retorna un string con los datos de la camioneta</returns>
        public override string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("CAMIONETA");
            sb.AppendLine(base.Mostrar());
            sb.AppendLine("TAMAÑO : "+ this.Tamanio);
            sb.AppendLine("---------------------");

            return sb.ToString();
        }
    }
}
