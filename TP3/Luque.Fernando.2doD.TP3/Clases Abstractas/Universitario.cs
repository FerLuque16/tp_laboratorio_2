using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesAbstractas
{
    public abstract  class Universitario : Persona
    {
        private int legajo;

        #region Constructores

        /// <summary>
        /// Constructor por defecto de Universitario
        /// </summary>
        public Universitario()
        {

        }

        /// <summary>
        /// Constructor de universitario que hereda el constructor Persona y ademas setea legajo
        /// </summary>
        /// <param name="legajo">Legajo a setear</param>
        /// <param name="nombre">Nombre a setear</param>
        /// <param name="apellido">Apellido a setear</param>
        /// <param name="dni">Dni a setear</param>
        /// <param name="nacionalidad">Nacionalidad a setear</param>
        public Universitario(int legajo, string nombre, string apellido, string dni, ENacionalidad nacionalidad):base(nombre,apellido,dni,nacionalidad)
        {
          
            this.legajo = legajo;
           
        }
        #endregion

        #region Metodos
        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>

        public override bool Equals(object obj)
        {
            return obj.GetType() == this.GetType() && (((Universitario)obj).Dni == this.Dni || ((Universitario)obj).legajo == this.legajo);
        }

        /// <summary>
        /// Retorna todos los datos del universitario
        /// </summary>
        /// <returns></returns>

        protected virtual string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine($"LEGAJO NÚMERO: {this.legajo}");
            return sb.ToString();
        }

        /// <summary>
        /// Verifica si 2 universitarios son iguales utilizando Equals
        /// </summary>
        /// <param name="pg1">Universitario a comparar</param>
        /// <param name="pg2">Universitario a comparar</param>
        /// <returns>Retorna true si son iguales o retorna false si no lo son</returns>
        public static bool operator ==(Universitario pg1, Universitario pg2)
        {           
            return pg1.Equals(pg2);
        }

        /// <summary>
        /// Verifica si 2 universitarios son distintos
        /// </summary>
        /// <param name="pg1">Universitario a comparar</param>
        /// <param name="pg2">Universitario a comparar</param>
        /// <returns>Retorna true si no lo son y retorna false, si los son</returns>
        public static bool operator != (Universitario pg1, Universitario pg2)
        {
            return !(pg1==pg2);
        }

        
        /// <summary>
        /// Metodo abstracto 
        /// </summary>
        /// <returns></returns>
        public abstract string ParticiparEnClase();


        #endregion


    }
}
