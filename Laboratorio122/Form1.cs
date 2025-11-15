using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laboratorio122
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnPromedio_Click(object sender, EventArgs e)
        {
            try
            {
                double n1 = double.Parse(txtNota1.Text);
                double n2 = double.Parse(txtNota2.Text);
                double n3 = double.Parse(txtNota3.Text);

                double prom = PromedioHelper.CalcularPromedio(n1, n2, n3);

                txtResultado.Text = $"Promedio: {prom:F2}";
            }
            catch
            {
                MessageBox.Show("Ingrese valores numéricos válidos.");
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
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

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
