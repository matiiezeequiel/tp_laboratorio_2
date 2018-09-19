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
    public partial class LaCalculadora : Form
    {
        public LaCalculadora()
        {
            InitializeComponent();
        }

        private void btnOperar_Click(object sender, EventArgs e)
        {
            this.lblResultado.Text = LaCalculadora.Operar(this.txtNumero1.Text, this.txtNumero2.Text, this.cmbOperador.Text).ToString();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            Entidades.Numero numero = new Entidades.Numero();
            this.lblResultado.Text = numero.DecimalBinario(this.lblResultado.Text);
        }

        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            Entidades.Numero numero = new Entidades.Numero();
            this.lblResultado.Text = numero.BinarioDecimal(this.lblResultado.Text);
        }

        private void Limpiar()
        {
            this.txtNumero1.Clear();
            this.txtNumero2.Clear();
            this.lblResultado.Text = string.Empty;
            this.cmbOperador.Text = string.Empty;
        }

        private static double Operar(string numero1, string numero2, string operador)
        {
            Entidades.Numero num1 = new Entidades.Numero(numero1);
            Entidades.Numero num2 = new Entidades.Numero(numero2);
            return Calculadora.Operar(num1, num2, operador);
        }
    }
}
