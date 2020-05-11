using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Moto : Vehiculo
    {
        /// <summary>
        /// Constructor que llama al constructor base y setea los campos de moto
        /// </summary>
        /// <param name="marca">Se agna a marca</param>
        /// <param name="chasis">Se asigna a chasis</param>
        /// <param name="color">Se asigna a color</param>
        public Moto(EMarca marca, string chasis, ConsoleColor color):base(chasis,marca,color)
        {
        }

        /// <summary>
        /// Las motos son chicas
        /// </summary>
        public override ETamanio Tamanio
        {
            get
            {
                return ETamanio.Chico;
            }
        }

        /// <summary>
        /// Metodo redefinido que retorna los datos de la moto
        /// </summary>
        /// <returns>Retorna un string con los datos de la moto</returns>
        public override string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("MOTO");
            sb.AppendLine(base.Mostrar());
            sb.AppendLine("TAMAÑO : "+ this.Tamanio);
            sb.AppendLine("---------------------");

            return sb.ToString();
        }
    }
}
