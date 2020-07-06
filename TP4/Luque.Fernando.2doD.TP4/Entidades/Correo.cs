using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Entidades
{
    public class Correo : IMostrar<List<Paquete>>
    {
        private List<Thread> mockPaquetes;
        private List<Paquete> paquetes;

        /// <summary>
        /// Retorna o setea la lista de paquetes
        /// </summary>
        public List<Paquete> Paquetes

        {
            get
            {
                return this.paquetes;
            }
            set
            {
                this.paquetes = value;
            }
        }

        /// <summary>
        /// Constructor que instancia la lista de hilos y la lista de paquetes
        /// </summary>
        public Correo()
        {
            this.mockPaquetes = new List<Thread>();
            this.paquetes = new List<Paquete>();

        }

        /// <summary>
        /// Aborta todos los hilos que estan en funcionamiento
        /// </summary>
        public void FinEntregas()
        {
            foreach (Thread hilo in mockPaquetes)
            {
                if(hilo.IsAlive)
                    hilo.Abort();
            }
        }
        /// <summary>
        /// Muesta el cada paquete y el estado en que se encuentra del correo
        /// </summary>
        /// <param name="elementos"></param>
        /// <returns></returns>
        public string MostrarDatos(IMostrar<List<Paquete>> elementos)
        {
            StringBuilder sb = new StringBuilder();

            foreach (Paquete p in ((Correo)elementos).Paquetes)
            {                
                sb.AppendLine(string.Format(p.ToString() + "({0})", p.Estado));
            }

            return sb.ToString();
             
        }

        /// <summary>
        /// Agrega un paquete al correo
        /// </summary>
        /// <param name="c"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        public static Correo operator +(Correo c, Paquete p)
        {
            Thread hiloP;
            foreach (Paquete paquete in c.Paquetes)
            {
                if (paquete == p)
                    throw new TrackingRepetidoException("El paquete ya se encuentra en el correo");
            }

                c.Paquetes.Add(p);

                hiloP = new Thread(p.MockCicloDeVida);
                hiloP.Start();
                c.mockPaquetes.Add(hiloP);
                
            
            return c;
        }

    }
}
