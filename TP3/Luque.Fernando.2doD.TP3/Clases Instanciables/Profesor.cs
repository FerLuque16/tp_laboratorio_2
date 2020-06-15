using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;

namespace Clases_Instanciables
{
    public sealed class Profesor : Universitario
    {
        private Queue<Universidad.EClases> clasesDelDia;
        private static Random random;

        #region Constructores
        /// <summary>
        ///  Constructor por defecto de Profesor
        /// </summary>
        public Profesor()
        {

        }

        /// <summary>
        /// Instacia el atributo random de Profesor
        /// </summary>
        static  Profesor()
        {
            random = new Random();
        }

        /// <summary>
        /// Constructor de Profesor que hereda del constructor Universitarioy setea las clases del dia del profesor
        /// </summary>
        /// <param name="id">Id a setear</param>
        /// <param name="nombre">Nombre a setear</param>
        /// <param name="apellido">Apellido a setear</param>
        /// <param name="dni">Dni a setear</param>
        /// <param name="nacionalidad">Nacionalidad a setear</param>
        public Profesor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad):base(id,nombre,apellido,dni,nacionalidad)
        {

            this.clasesDelDia = new Queue<Universidad.EClases>();

            for (int i = 0; i < 2; i++)
            {
                this._randomClases();
            }


        }

        #endregion


        #region Metodos
        /// <summary>
        ///  Sobrecarga el operador != reutilizando el operador ==
        /// </summary>
        /// <param name="i">Profesor a comparar</param>
        /// <param name="clase">Clase a comparar</param>
        /// <returns></returns>
        public static bool operator !=(Profesor i, Universidad.EClases clase)
        {
            return !(i == clase);
        }

        /// <summary>
        /// Sobrecarga el operador == que compara profesor y clase
        /// </summary>
        /// <param name="i"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static bool operator ==(Profesor i, Universidad.EClases clase)
        {
            bool retorno = false;
            foreach ( Universidad.EClases item in i.clasesDelDia)
            {
                if(item == clase)
                {
                    retorno = true;
                    break;
                }
            }
            return retorno;
        }

        /// <summary>
        /// Retorna todos los datos del profesor
        /// </summary>
        /// <returns>Retorna uns tring con los datos del profesor</returns>

        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat(base.MostrarDatos());
            sb.AppendLine("");
            sb.AppendFormat(this.ParticiparEnClase());

            return sb.ToString();

        }

       
        /// <summary>
        /// Asigna 2 clases de manera aleatoria al profesor
        /// </summary>
        public void _randomClases()
        {
            int clase;

            clase = random.Next(0, Enum.GetNames(typeof(Universidad.EClases)).Length - 1);
            this.clasesDelDia.Enqueue((Universidad.EClases)clase);

        }

        /// <summary>
        /// Hace publico los datos del profesor
        /// </summary>
        /// <returns>Retorna un string con todos los datos</returns>
        public override string ToString()
        {           
            return this.MostrarDatos();
        }
        /// <summary>
        /// Muestra las clases que dicta el profesor
        /// </summary>
        /// <returns>Retorna el string con las clases</returns>
        public override string ParticiparEnClase()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("CLASES DEL DIA");
            sb.AppendLine("");
            foreach (Universidad.EClases item in this.clasesDelDia)
            {
                sb.AppendLine(item.ToString());
            }

            return sb.ToString();
        }

        #endregion
    }
}
