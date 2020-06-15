using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Excepciones;
using Archivos;

namespace Clases_Instanciables
{

   
    public class Universidad
    {

        public enum EClases
        {

            Programacion,
            Laboratorio,
            Legislacion,
            SPD
        }

        private List<Alumno> alumnos;
        private List<Jornada> jornada;
        private List<Profesor> profesores;


        #region Propiedades

        /// <summary>
        /// Setea o retorna la lista de alumnos
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
        /// Setea o retorna la lista de instructores
        /// </summary>
        public List<Profesor> Instructores
        {
            get 
            {
                return this.profesores; 
            }
            set
            { 
                this.profesores = value; 
            }
        }

        /// <summary>
        /// Setea o retorna la lista de jornadas
        /// </summary>
        public List<Jornada> Jornadas
        {
            get 
            { 
                return this.jornada; 
            }
            set 
            { 
                this.jornada = value; 
            }
        }
        #endregion

        #region Constructores

        /// <summary>
        /// Propiedad que setea o retorna una jornada especiafica a traves del indexador
        /// </summary>
        /// <param name="i">Indice de la jornada a buscar</param>
        /// <returns>Retorna la jornada especifica</returns>
        public Jornada this[int i]
        {
            get
            {
                if (i < 0 && i > this.jornada.Count)
                    return null;

                return this.jornada[i];
            }
            set
            {
                if (i > 0 && i < this.jornada.Count)
                    this.jornada[i] = value;
            }
        }

        #endregion

        #region Constructores
        /// <summary>
        /// Constructor de Universidad que instancia todas las listas
        /// </summary>

        public Universidad()
        {
            this.alumnos = new List<Alumno>();
            this.profesores = new List<Profesor>();
            this.jornada = new List<Jornada>();
        }

        #endregion

        #region Metodos
        /// <summary>
        /// Metodo estatico que guarda todos los datos de la universidad en un archivo .xml
        /// </summary>
        /// <param name="uni">Universidad que tiene los datos a ser guardados</param>
        /// <returns>Retorna true si pudo guardar el archivo</returns>

        public static bool Guardar(Universidad uni)
        {
            bool aux;
            Xml<Universidad> xml = new Xml<Universidad>();

            aux = xml.Guardar("Universidad.xml", uni);

            if (!aux)
                throw new ArchivosException(new Exception("No se pudo guardar el archivo"));

            return aux;
        }

        /// <summary>
        /// Metodo estatico que lee un archivo .xml que contiene los datos de universidad
        /// </summary>
        /// <returns>Retorna un objeto de tipo Universidad con los datos cargados y leidos desde el archivo .xml</returns>
        public static Universidad Leer()
        {
            Universidad aux=new Universidad();
            Xml<Universidad> xml = new Xml<Universidad>();

            if(!(xml.Leer("Universidad.xml", out aux)))
            {
                throw new ArchivosException(new Exception("No se pudo leer el archivo"));
            }

            return aux;

        }

        /// <summary>
        /// Muestra todos los datos de la universidad
        /// </summary>
        /// <param name="uni">Universidad de donde se sacan los datos a mostrar</param>
        /// <returns>Retorna el string con todos los datos</returns>
        private string MostrarDatos(Universidad uni)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("JORNADA: ");
            foreach (Jornada item in uni.jornada)
            {
                sb.AppendFormat(item.ToString());
            }

            return sb.ToString();

        }

        /// <summary>
        /// Sobrecarga del operador != que reutliza el operador ==
        /// </summary>
        /// <param name="g">Universidad donde se buscara al alumno</param>
        /// <param name="a">Alumno a ser buscado</param>
        /// <returns>Retorna true si el alumno no se encuentra en la universidad o retorna false si el alumno si se encuentra en la universidad</returns>

        public static bool operator !=(Universidad g, Alumno a)
        {
            return !(g == a);
        }

        /// <summary>
        /// Sobrecarga del operador != que reutiliza el operador ==
        /// </summary>
        /// <param name="g">Universidad donde se buscara al profesor</param>
        /// <param name="i">Profeosr a ser buscado</param>
        /// <returns>Retorna true si el profesor no se encuentra en la universidad</returns>
        public static bool operator !=(Universidad g, Profesor i)
        {
            return !(g == i);
        }

        /// <summary>
        /// Sobrecarga del operador != que buscar al primer profesor que no es capaz de dar la clase deseada
        /// </summary>
        /// <param name="u">Universidad donde se buscara al profesor</param>
        /// <param name="clase">Clase del cual se buscara profesor</param>
        /// <returns>Retorna al primer profesor que no sea capaz de dar cicha clase</returns>

        public static Profesor operator !=(Universidad u, EClases clase)
        {
            Profesor aux=null;

            foreach (Profesor profe in u.profesores)
            {
                if (profe != clase)
                {
                    aux = profe;
                    break;
                }
            }

            return aux;
        }

        /// <summary>
        /// Sobrecarga del operador + que agrega una clase a una universidad creando una nueva jornada
        /// </summary>
        /// <param name="u">Universidad donde se agregara la clase</param>
        /// <param name="clase">Clase que se agregara </param>
        /// <returns>Retorna la universidad con la jornada agregada</returns>
        public static Universidad operator +(Universidad u, EClases clase)
        {
            Jornada jornada=null;
            Profesor profe=null;
          
            profe = u == clase;

            if(!(profe is null))
            {
                jornada = new Jornada(clase, profe);
              

                for (int i = 0; i < u.alumnos.Count; i++)
                {
                    if (u.alumnos[i] == clase)
                        jornada.Alumnos.Add(u.alumnos[i]);
                }

                u.jornada.Add(jornada);
            }
            else
            {
                throw new SinProfesorException("No hay profesor para la clase");
            }

            return u;


        }

        /// <summary>
        /// Sobrecarga del operador + que agrega un profesor a la universidad si este no esta cargado aún
        /// </summary>
        /// <param name="u"></param>
        /// <param name="i"></param>
        /// <returns>Retorna la universidad con eel profesor cargado</returns>

        public static Universidad operator +(Universidad u, Profesor i)
        {

            foreach  (Profesor item in u.profesores)
            {
                if(item == i)
                {
                    return u;                 
                }
            }

            u.profesores.Add(i);

            return u;
 
        }

        /// <summary>
        /// Sobrecarga del operador + que agrega un alumno a la universidad si este no esta cargado aún
        /// </summary>
        /// <param name="u"></param>
        /// <param name="a"></param>
        /// <returns>Retorna la universidad con el alumno cargado</returns>
        public static Universidad operator +(Universidad u, Alumno a)
        {
         
          
                if(u == a)
                {
                    throw new AlumnoRepetidoException("Alumno repetido");
                }
            

            u.alumnos.Add(a);

            return u;


        }

        /// <summary>
        /// Sobrecarga del operador == que verifica si un profesor ya se encuentra en la universidad
        /// </summary>
        /// <param name="u">Universidad donde se busca al profesor</param>
        /// <param name="i">Profesor a buscar</param>
        /// <returns>Retorna true si el profesor se encuentra en la universidad o retorna false si no se encuentra</returns>

        public static bool operator ==(Universidad u, Profesor i)
        {
            bool retorno = false; ;
            foreach (Profesor item in u.profesores)
            {
                if(item == i)
                {
                    retorno = true;
                    break;
                }
            }

            return retorno;
        }

        /// <summary>
        /// Sobrecarga del operador == que verifica si un alumno ya se encuentra en la universidad
        /// </summary>
        /// <param name="u">Universidad donde se buscara al alumno</param>
        /// <param name="a">Alumno a buscar</param>
        /// <returns>Retorna true si el alumno se encuentra en la universidad o retorna false si no se encuentra</returns>
        public static bool operator ==(Universidad u, Alumno a)
        {
            bool retorno=false;
            foreach (Alumno item  in u.alumnos)
            {
                if (item == a)
                {
                    retorno = true;
                    break;
                }
                    
            }

            return retorno;
        }

        /// <summary>
        /// Sobrecarga del operador == que busca al profesor capaz de dar la clase
        /// </summary>
        /// <param name="u">Universidad donde se buscara al profesor</param>
        /// <param name="clase">Clase que se buscara profesor para darla</param>
        /// <returns>Retorna al profesor capaz de dar la clase deseada</returns>
        public static Profesor operator ==(Universidad u, EClases clase)
        {
            Profesor aux;

            foreach (Profesor profe in u.profesores)
            {
                if(profe==clase)
                {
                    aux = profe;
                    return aux;
                }
            }

            throw new SinProfesorException("No hay profesor para la clase");
        }

        /// <summary>
        /// Hace publico todos los datos de la universidad
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {

            return MostrarDatos(this);
        }


        #endregion



    }
}
