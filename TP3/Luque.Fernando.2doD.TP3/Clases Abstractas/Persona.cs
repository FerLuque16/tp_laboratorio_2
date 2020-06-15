using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;

namespace EntidadesAbstractas
{

    
    public abstract class Persona
    {

        public enum ENacionalidad
        {
            Argentino,
            Extranjero
        }

        private string apellido;
        private int dni;
        private ENacionalidad nacionalidad;
        private string nombre;

        #region Propiedades
        /// <summary>
        /// Propiedad para setear o recibir el apellido
        /// </summary>
        public string Apellido
        {
            get 
            { 
                return this.apellido; 
            }
            set
            {
                if(!String.IsNullOrEmpty(ValidarNombreApeliido(value)))
                    this.apellido = value; 
            }

        }

        /// <summary>
        /// Propiedad para setear o recibir el sni
        /// </summary>

        public int Dni
        {
            get 
            {
                return this.dni; 
            }
            set
            { 
               
                this.dni = ValidarDni(this.nacionalidad,value);
            }
        }

        /// <summary>
        /// Propiedad para setear dni 
        /// </summary>
        public string StringToDni
        {
           
            set 
            {
                this.dni = ValidarDni(this.nacionalidad, value); 
            }
        }

        /// <summary>
        /// Propiedad para setear o recibir la nacionalidad
        /// </summary>
        public ENacionalidad Nacionalidad
        {
            get 
            { 
                return this.nacionalidad; 
            }
            set 
            {
                this.nacionalidad = value; 
            }
        }

        /// <summary>
        /// Propiedad para setear o recibir el nombre
        /// </summary>
        public string Nombre
        {
            get 
            { 
                return this.nombre; 
            }
            set
            {
                if (!String.IsNullOrEmpty(ValidarNombreApeliido(value)))
                    this.nombre = value;
            }
        }
        #endregion


        #region Constructores
        /// <summary>
        /// Constructor por defecto de Persona
        /// </summary>

        public Persona()
        {
                
        }

        /// <summary>
        /// Constructor de Persona que setea nombre, apellido y nacionalidad
        /// </summary>
        /// <param name="nombre">Nombre a setear</param>
        /// <param name="apellido">Apellido a setear</param>
        /// <param name="nacionalidad">Nacionalidad a setear</param>

        public Persona(string nombre, string apellido, ENacionalidad nacionalidad)
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.nacionalidad = nacionalidad;

        }

        /// <summary>
        /// Constructor de Persona que reciba una sobrecarga y setea los recibido mas el dni
        /// </summary>
        /// <param name="nombre">Nombre a setear</param>
        /// <param name="apellido">Apellido a setear</param>
        /// <param name="dni">Dni a setear</param>
        /// <param name="nacionalidad">Nacionalidad a setear</param>

        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad):this(nombre,apellido,nacionalidad)
        {
            this.Dni = dni;
        }

        /// <summary>
        /// Constructor de Persona que reciba una sobrecarga y setea los recibido mas el dni de tipo string
        /// </summary>
        /// <param name="nombre">Nombre a setear</param>
        /// <param name="apellido">Apellido a setear</param>
        /// <param name="dni">Dni a setear</param>
        /// <param name="nacionalidad">Nacionalidad a setear</param>

        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad):this(nombre, apellido, nacionalidad)
        {
            this.StringToDni = dni;
        }

        #endregion

        #region Metodos
        /// <summary>
        /// Retorna todos los datos de la persona
        /// </summary>
        /// <returns>Retorna los datos de la persona</returns>
        public override string ToString()
        {

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"NOMBRE COMPLETO {this.apellido} {this.nombre}");          
            sb.AppendLine($"NACIONALIDAD: {this.nacionalidad}");
            
            return sb.ToString();
        }

        /// <summary>
        /// Valida que el dni y la nacionalidad coincidan
        /// </summary>
        /// <param name="nacionalidad">Nacionalidad de la persona</param>
        /// <param name="dni">Dni de la persona</param>
        /// <returns></returns>

        private int ValidarDni(ENacionalidad nacionalidad, int dni)
        {
            if (nacionalidad == ENacionalidad.Argentino && dni >= 1 && dni <= 89999999)
                return dni;

            else if (nacionalidad == ENacionalidad.Extranjero && dni >= 90000000 && dni <= 99999999)
                return dni;

           

            throw new NacionalidadInvalidaException("La nacionalidad no condice con el dni");

 
            
        }

        /// <summary>
        /// Valida que el dni tenga un formato y longitud valido 
        /// </summary>
        /// <param name="nacionalidad">Nacionalidad de la persona</param>
        /// <param name="dni">Dni de la persona</param>
        /// <returns>Retorna el resultado de ValidarDni o una exception si el dni no es valido</returns>

        private int ValidarDni (ENacionalidad nacionalidad, string dni)
        {
            int aux;

            if(int.TryParse(dni, out aux) && dni.Length<=8)
            {
            

               return ValidarDni(nacionalidad, aux);
            }
           
            throw new DniInvalidoException("Dni invalido");
            
        }

        /// <summary>
        /// Valida que el nombre o apellido sean de formato valido
        /// </summary>
        /// <param name="dato">Dato a validar </param>
        /// <returns>Retorna el dato si fue valido, o un string vacio si fue invalido</returns>
        private string ValidarNombreApeliido (string dato)
        {

            for (int i = 0; i < dato.Length; i++)
            {
                if (!(char.IsLetter(dato[i])))
                    return String.Empty;     
            }
            return dato;
        }

        #endregion

    }
}
