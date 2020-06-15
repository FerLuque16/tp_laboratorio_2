using EntidadesAbstractas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases_Instanciables
{
   
    public sealed class Alumno : Universitario
    {

        public enum EEstadoCuenta
        {
            AlDia,
            Deudor,
            Becado
        }

        private Universidad.EClases claseQueToma;
        private EEstadoCuenta estadoCuenta;

        #region Constructores
        /// <summary>
        /// Constructor por defecto de Alumno
        /// </summary>
        public Alumno()
        {

        }

        /// <summary>
        /// Constructor de Alumno que hereda del constructor Universitario y setea la clase que toma el alumno
        /// </summary>
        /// <param name="id">Id a setear</param>
        /// <param name="nombre">Nombre a setear</param>
        /// <param name="apellido">Apellido a setear</param>
        /// <param name="dni">Dni a setear</param>
        /// <param name="nacionalidad">Nacionalidad a setear</param>
        /// <param name="claseQueToma">Clase a setear</param>

        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma ):base(id,nombre,apellido,dni,nacionalidad)
        {
          
            this.claseQueToma = claseQueToma;
        }

        /// <summary>
        /// Constructor de alumno que utiliza una sobrecarga de constructor y sete el estado de cuenta del alumno
        /// </summary>
        /// <param name="id">Id a setear</param>
        /// <param name="nombre">Nombre a setear</param>
        /// <param name="apellido">Apellido a setear</param>
        /// <param name="dni">Dni a setear</param>
        /// <param name="nacionalidad">Nacionalidad a setear</param>
        /// <param name="claseQueToma">Clase a setear</param>
        /// <param name="estadoCuenta">Estado de cuenta a setear</param>

        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma, EEstadoCuenta estadoCuenta):this(id,nombre,apellido,dni,nacionalidad,claseQueToma)
        {
            this.estadoCuenta = estadoCuenta;
        }

        #endregion

        #region Metodos
        /// <summary>
        /// Muestra todos los datos del alumno
        /// </summary>
        /// <returns></returns>

        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("");
            sb.AppendFormat(base.MostrarDatos());
            sb.AppendLine("");
            //sb.AppendLine($"LEGAJO NÚMERO: {this.le}")

            if (this.estadoCuenta == EEstadoCuenta.AlDia)
                sb.AppendLine("ESTADO DE CUENTA: Al dia");
            else
                sb.AppendLine($"ESTADO DE CUENTA: {this.estadoCuenta.ToString()}");

            sb.AppendLine(this.ParticiparEnClase());

            return sb.ToString();

           
        }

        /// <summary>
        /// Verigica si un alumno toma la clase recibida
        /// </summary>
        /// <param name="a">Alumno a verificar</param>
        /// <param name="clase">Clase a verificar</param>
        /// <returns>Retorna true si el alumno toma esa clas o retorna flase si no la toma</returns>
        public static bool operator==(Alumno a, Universidad.EClases clase)
        {
            bool retorno = false;

            if(a.claseQueToma == clase && a.estadoCuenta != EEstadoCuenta.Deudor)          
                retorno = true;
            
            return retorno;
        }

        /// <summary>
        /// Verifica si el alumno no toma la clase que se indica
        /// </summary>
        /// <param name="a">Alumno a verificar</param>
        /// <param name="clase">Clase a verificar</param>
        /// <returns>Retorna true el alumno no toma esa clase o retorna false si es que la toma</returns>

        public static bool operator !=(Alumno a, Universidad.EClases clase)
        {

            bool retorno = false;

            if (a.claseQueToma != clase)
                retorno = true;

            return retorno;

        }

        /// <summary>
        /// Muestra que clase toma el alumno
        /// </summary>
        /// <returns>Retorna un string mostrando que clase toma el alumno</returns>

        public override string ParticiparEnClase()
        {
            return "TOMA CLASE DE " +this.claseQueToma;
        }

        /// <summary>
        /// Hace publicp todos los datos del alumno
        /// </summary>
        /// <returns>Retornaun string con todos los datos del alumno</returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }

        #endregion
    }
}
