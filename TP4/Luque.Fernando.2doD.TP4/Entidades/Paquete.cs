using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Entidades
{
    
    public class Paquete : IMostrar<Paquete>
    {
        public enum EEstado
        {
            Ingresado,
            EnViaje,
            Entregado
        }

        public delegate void DelegadoEstado(object sender, EventArgs e);

        private string direccionEntrega;
        private EEstado estado;
        private string trackingID;

        public event DelegadoEstado InformaEstado;

        /// <summary>
        /// Retorna o setea la direccion de entrega del paquete
        /// </summary>

        public string DireccionEntrega
        {
            get
            {
                return this.direccionEntrega;
            }
            set
            {
                this.direccionEntrega = value;
            }
        }

        /// <summary>
        /// Retorna o setea el estado del paquete
        /// </summary>
        public EEstado Estado
        {
            get
            {
                return this.estado;
            }

            set
            {
                this.estado = value;
            }
        }

        /// <summary>
        /// Retorna o setea el id de rastreo del paquete
        /// </summary>
        public string TrackingID
        {
            get
            {
                return this.trackingID;
            }
            set
            {
                this.trackingID = value;
            }
        }

        /// <summary>
        /// Constructor del paquete
        /// </summary>
        /// <param name="direccionEntrega">Direccion de entrega a setear</param>
        /// <param name="trackingID">Id de traqueo a setear</param>

        public Paquete(string direccionEntrega, string trackingID)
        {
            this.DireccionEntrega = direccionEntrega;
            this.TrackingID = trackingID;
            this.Estado = EEstado.Ingresado;
        }

        /// <summary>
        /// Realiza el ciclo de cambio de estado del paquete cada 4 segundos
        /// </summary>

        public void MockCicloDeVida()
        {
            while(this.Estado != EEstado.Entregado)
            {
                Thread.Sleep(4000);

                switch (this.Estado)
                {
                    case EEstado.Ingresado:
                        this.Estado = EEstado.EnViaje;
                        break;
                    case EEstado.EnViaje:
                        this.Estado=EEstado.Entregado;
                        break;                   
                    default:
                        break;
                }
                InformaEstado(this, new EventArgs());

                
            }

            
                PaqueteDAO.Insertar(this);
            
            
        }

        /// <summary>
        /// Retorna los datos del elemento usando la interfaz IMostrar
        /// </summary>
        /// <param name="elemento">Elemento de donde se sacaran los datos</param>
        /// <returns></returns>
        public string MostrarDatos(IMostrar<Paquete> elemento)
        {
            return string.Format("{0} para {1} ",((Paquete)elemento).TrackingID, ((Paquete)elemento).DireccionEntrega); 
    
        }

        /// <summary>
        /// Verifica si la igualdad entre 2 paquetes
        /// </summary>
        /// <param name="p1">Primer paquete</param>
        /// <param name="p2">Segundo paquete</param>
        /// <returns></returns>
        public static bool operator ==(Paquete p1, Paquete p2)
        {

            return p1.trackingID==p2.trackingID;
        }

        /// <summary>
        /// Verifica la desigualdad entre 2 paquetes
        /// </summary>
        /// <param name="p1">Primer paquete</param>
        /// <param name="p2">Segundo paquete</param>
        /// <returns>Retorna true si los paquetes son distintos</returns>
        public static bool operator !=(Paquete p1, Paquete p2)
        {
            return !(p1 == p2);
        }

        /// <summary>
        /// Hara publico los datos del paquete
        /// </summary>
        /// <returns>Retorna uns string con los datos del paquete</returns>
        public override string ToString()
        {
            return this.MostrarDatos(this);
        }


    }
}
