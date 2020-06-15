using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Archivos;
using Excepciones;

namespace Clases_Instanciables
{
    public class Jornada
    {
        private List<Alumno> alumnos;
        private Universidad.EClases clase;
        private Profesor instructor;

        #region Propiedades

        /// <summary>
        /// Propiedad que setea o retorna la lista de alumnos
        /// </summary>

        public List<Alumno> Alumnos
        {
            get 
            { 
                return this.alumnos; 
            }
            set 
            { 
                this.alumnos = value; 
            }
        }

        /// <summary>
        /// Propiedad que setea o retorna la clase
        /// </summary>
        public Universidad.EClases Clase
        {
            get 
            { 
                return this.clase; 
            }
            set 
            { 
                this.clase = value; 
            }
        }

        /// <summary>
        /// Propiedad que setea o retorna al instructor
        /// </summary>
        public Profesor Instructor
        {
            get 
            { 
                return this.instructor; 
            }
            set 
            { 
                this.instructor = value; 
            }
        }

        #endregion

        #region Constructores

        /// <summary>
        /// Constructor que instancia la lista de alumnos
        /// </summary>
        private Jornada()
        {
            this.alumnos = new List<Alumno>();
        }

        /// <summary>
        /// Constructor que setea la clase y el profesor de la jornada y llama al constructor privado
        /// </summary>
        /// <param name="clase">Clase a setear</param>
        /// <param name="instructor">Profesor a setear</param>
        public Jornada(Universidad.EClases clase, Profesor instructor):this()
        {
            this.Clase = clase;
            this.Instructor = instructor;

        }

        #endregion

        #region Metodos

        /// <summary>
        /// Metodo estatico que lee un archivo de texto con los datos de jornada
        /// </summary>
        /// <returns>Retorna los datos contiene el archivo</returns>
        public static string Leer()
        {
            Texto archivo = new Texto();

            string aux = "";

            if (!(archivo.Leer("Jornada.txt", out aux)))
                throw new ArchivosException(new Exception("No se pudo leer el archivo"));
            

            return aux;
        }

        /// <summary>
        /// Metodo estatico que guarda los datos de la jornada en un archivo de texto
        /// </summary>
        /// <param name="jornada">Jornada de la cula se guardaran los datos</param>
        /// <returns>Retorna true si fue posible guardar el archivo</returns>
        public static bool Guardar(Jornada jornada)
        {
            bool aux;
            Texto archivo=new Texto();

            aux= archivo.Guardar("Jornada.txt",jornada.ToString());

            if (!aux)
                throw new ArchivosException(new Exception("No se pudo guardar el archivo"));

            return aux;

            
        }

        /// <summary>
        /// Sobrecarga el operador != reutilizando el operador ==
        /// </summary>
        /// <param name="j">Jornada a comparar</param>
        /// <param name="a">Alumno a comparar</param>
        /// <returns></returns>
        public static bool operator !=(Jornada j, Alumno a)
        {
            return !(j == a);
        }

        /// <summary>
        /// Sobrecarga del operador + que agrega al alumno si este no esta cargado en la lista alumnos de jornada
        /// </summary>
        /// <param name="j">Jornada donde se cargara al alumno</param>
        /// <param name="a">Alumno a cargar</param>
        /// <returns>Retorna la jornada</returns>
        public static Jornada operator +(Jornada j, Alumno a)
        {

            if (j != a)
                j.alumnos.Add(a);

            return j;
        }

        /// <summary>
        /// Sobrecarga del operador == que verifica si el alumno ya esta en la lista alumnos de jornada
        /// </summary>
        /// <param name="j">Jornada donce esta la lista</param>
        /// <param name="a">Alumno a buscar</param>
        /// <returns>Retorna true el el alumno esta contenido en la lista alumnos y retorna false si no esta contenido</returns>
        public static bool operator ==(Jornada j, Alumno a)
        {
            bool retorno = false;

            foreach (Alumno item in j.alumnos)
            {
                if (item == a)
                    retorno = true;
            }

            return retorno;
        }

        /// <summary>
        /// Hace publico todos los datos de la jornada
        /// </summary>
        /// <returns>Retorna un string con todos los datos</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"CLASE DE {this.clase.ToString()} POR {this.instructor.ToString()}");
           // sb.AppendLine("");
            //sb.AppendFormat(this.instructor.ToString());
            sb.AppendLine("");
            sb.AppendLine("ALUMNOS: ");
            foreach (Alumno item in this.alumnos)
            {
                sb.AppendLine(item.ToString());
            }

            sb.AppendLine("<------------------------------------------------------------->");

            return sb.ToString();
        }

        #endregion

    }
}
