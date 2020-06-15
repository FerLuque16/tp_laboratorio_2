using Excepciones;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Archivos
{
    public class Xml<T> : IArchivo<T>
    {
       
        /// <summary>
        /// Metodo que guarda en un archivo .xml los datos de un objeto
        /// </summary>
        /// <param name="archivo">Ruta y nombre del archivo que se creara</param>
        /// <param name="datos">Objeto de onde se obtendran los datos a guardar</param>
        /// <returns>Retorna true si pudo guardar el archivo o retorna false si ni pudo</returns>
        public bool Guardar(string archivo, T datos)
        {
            bool retorno = false;

            if (!(String.IsNullOrEmpty(archivo)) || object.ReferenceEquals(datos, null))
            {
                using (XmlTextWriter xwr = new XmlTextWriter(archivo, Encoding.UTF8))
                {
                    XmlSerializer xsr = new XmlSerializer(typeof(T));
                    xsr.Serialize(xwr, datos);
                    retorno = true;

                }
            }
            else
            {
                throw new ArchivosException(new Exception("No se pudo guardar el archivo"));
                
            }

            return retorno;
        }

        /// <summary>
        /// Metodo que lee un archivo.xml y guarda los datos del archivo en un objeto
        /// </summary>
        /// <param name="archivo">Ruta donde se encuentra el archivo</param>
        /// <param name="datos">Objeto donde se cargaran los datos leidos</param>
        /// <returns>Retorna true si pudo leer el archivo o retorna false si no pudo leerlo</returns>
        public bool Leer(string archivo, out T datos)
        {
            bool retorno = false;
            XmlTextReader xrd = new XmlTextReader(archivo);
            if(!(xrd is null))
            {
                XmlSerializer xsr = new XmlSerializer(typeof(T));
                datos = (T)xsr.Deserialize(xrd);
                retorno = true;

            }
            else
            {
                 throw new ArchivosException(new Exception("No se pudo leer el archivo"));
               
            }

          

            return retorno;
        }

    }
}
