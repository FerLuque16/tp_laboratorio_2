using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;

namespace Archivos
{
    public class Texto : IArchivo<string>

    {

        /// <summary>
        /// Metodo que guarda los datos de un objeto en un archivo .txt
        /// </summary>
        /// <param name="archivo">Ruta y nombre del archivo a ser guardado</param>
        /// <param name="datos">Datos que se guardaran en el archivo</param>
        /// <returns>Retorna true si pudo guardar el archivo o retorna false si no pudo</returns>
        public bool Guardar(string archivo, string datos)
        {

            bool retorno=false;
            if (!(String.IsNullOrEmpty(archivo)) || !(String.IsNullOrEmpty(datos)))
            {
                {
                    using (StreamWriter data = new StreamWriter(archivo))
                    {
                        data.Write(datos);
                        retorno = true;

                    }
                }               

            }
            else
            {
                throw new ArchivosException(new Exception("No se pudo guardar el archivo"));
            }
            return retorno;
        }


        /// <summary>
        /// Metodo que lee un archivo .txt  y guarda los datos en un string
        /// </summary>
        /// <param name="archivo">Ruta y nombre del archivo que se leera</param>
        /// <param name="datos">Atributo donde se guardaran los datos del archivo</param>
        /// <returns>Retorna true si pudo leerlo o retorna false si no lo leyó</returns>
        public bool Leer(string archivo, out string datos)
        {
            bool retorno = false;
                       
           if(!(String.IsNullOrEmpty(archivo)))
           {
                using (StreamReader rd = new StreamReader(archivo))
                {
                    //StringBuilder data = new StringBuilder();
                    /*while ((datos = rd.ReadLine()) != null)
                    {
                        data.AppendLine(datos);                      
                    }*/

                    datos = rd.ReadToEnd();

                    retorno = true;
                }

           }
           else
           {
                throw new ArchivosException(new Exception("No se pudo leer el archivo"));
           }

            return retorno;
                         
        }
    }
}
