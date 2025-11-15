using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laboratorio12
{
    public partial class CalculadoraVTD : Form
    {
        public CalculadoraVTD()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                double v = double.Parse(txtVelocidad.Text);
                double t = double.Parse(txtTiempo.Text);
                double d = Calculator.CalcularDistancia(v, t);
                txtResultado.Text = $"Distancia: {d:F2}";
            }
            catch
            {
                MessageBox.Show("Ingrese valores numéricos válidos.");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            foreach (Control c in this.Controls)
            {
                if (c is TextBox)
                    ((TextBox)c).Clear();

                if (c is Label && c.Name.StartsWith("lblResultado"))
                    ((Label)c).Text = "";   // limpia solo labels de resultado

                if (c is ComboBox)
                    ((ComboBox)c).SelectedIndex = -1;

                if (c is CheckBox)
                    ((CheckBox)c).Checked = false;

                if (c is RadioButton)
                    ((RadioButton)c).Checked = false;
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
