using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class GuardaString
    {
        /// <summary>
        ///  Escribe un archivo en la ruta indicada, si el archivo ya existe, agregara los datos que reciba
        /// </summary>
        /// <param name="texto">Datos que se guardaran en el archivo</param>
        /// <param name="archivo">Ruta donde se guardara el archivo</param>
        /// <returns>Retorna true si pudo guardar el archivo</returns>
        public static bool Guardar(this string texto, string archivo)
        {
            bool retorno = false;
            if (!(String.IsNullOrEmpty(archivo)) || !(String.IsNullOrEmpty(texto)))
            {
                {
                    using (StreamWriter data = new StreamWriter(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\" + archivo, true))//= new StreamWriter(archivo))
                    {
                        data.Write(texto);
                        retorno = true;

                    }
                }

            }
            else
            {
                throw new Exception("No se pudo guardar el archivo");
            }
            return retorno;



           
        }


    }
}
