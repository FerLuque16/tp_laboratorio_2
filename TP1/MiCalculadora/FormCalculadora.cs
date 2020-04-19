using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace MiCalculadora
{
    public partial class FormCalculadora : Form
    {
        

        public FormCalculadora()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Llama al metodo Operar para realizar la operacion deseada
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOperar_Click(object sender, EventArgs e)
        {
            string strNum1;
            string strNum2;
            string operador;
            double resultado;

            strNum1 = txtNumero1.Text;
            strNum2 = txtNumero2.Text;
            operador = cmbOperador.Text;

            resultado=Operar(strNum1, strNum2, operador);

            lblResultado.Text = resultado.ToString();
        }

        /// <summary>
        /// Limpia el formulario con el metodo Limpiar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        /// <summary>
        /// Cierra el formulario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Convierte el resultado de una operacion a un numero binario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCovertirABinario_Click(object sender, EventArgs e)
        {
            string strBinario;
            

            strBinario=Numero.DecimalBinario(lblResultado.Text);

            lblResultado.Text = strBinario;

            
        }

        /// <summary>
        /// Convierte un numero binario a decimal
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {

            string strDecimal;

            strDecimal = Numero.BinarioDecimal(lblResultado.Text);

            lblResultado.Text = strDecimal;
           

            

        }

        /// <summary>
        /// Utiliza la funcion Operar para realizar las operaciones requeridas con los numero recibidos respecto al operador 
        /// </summary>
        /// <param name="numero1">Numero de tipo string que se le asignara al atributo de Numero1</param>
        /// <param name="numero2">Numero de tipo string que se le asignara al atributo de Numero2</param>
        /// <param name="operador">Operador que dira que tipo de operacion debe realizar el metodo Operar</param>
        /// <returns></returns>
        private static double Operar(string numero1, string numero2, string operador)
        {
            Numero num1 = new Numero(numero1);
            Numero num2 = new Numero(numero2);


            return Calculadora.Operar(num1, num2, operador);
            
        }

        /// <summary>
        /// Limpian el formulario asignando null a los textos
        /// </summary>
        private void Limpiar()
        {
            txtNumero1.Text = null;
            txtNumero2.Text = null;
            lblResultado.Text = null;
         
        }

       
       
        
    }
}
