using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Entidades
{
    public static class PaqueteDAO
    {

        static SqlCommand comando;
        static SqlConnection conexion;

        /// <summary>
        /// Crea la conexion a la base de datos
        /// </summary>
        static PaqueteDAO()
        {
            try
            {
                conexion = new SqlConnection(@"Data Source = .\sqlexpress; Initial Catalog = correo-sp-2017; Integrated Security = True");                
                comando = new SqlCommand();

                comando.Connection = conexion;
            }
            catch (Exception ex)
            {

                throw new Exception("No se pudo conectar a la base de datos", ex.InnerException);
            }                                      
        }

        /// <summary>
        /// Inserta un paquete en la base de datos
        /// </summary>
        /// <param name="p">Paquete a insertar en la base de datos</param>
        /// <returns>Retorna true si pudo insertar, o retorna false si no pudo</returns>

        public static bool Insertar(Paquete p)
        {
            int retorno = -1;

            bool resultado = false;
            try
            {
                comando.Parameters.Clear();
                conexion.Open();

                comando.CommandText = "Insert into Paquetes (direccionEntrega, trackingID, alumno) values (@direccionEntrega, @trackingID, @alumno)";

                comando.Parameters.Add(new SqlParameter("direccionEntrega", p.DireccionEntrega));
                comando.Parameters.Add(new SqlParameter("trackingID",p.TrackingID));
                comando.Parameters.Add(new SqlParameter("alumno", "Fernando Luque"));

                retorno = comando.ExecuteNonQuery();


                if (retorno != -1)
                    resultado = true;


            }
            catch (Exception ex)
            {

                throw new Exception("No se pudo insertar el paquete el paquete",ex.InnerException);
            }
            finally
            {
                conexion.Close();
            }

            return resultado;
        }

    }
}
