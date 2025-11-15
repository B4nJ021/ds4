using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laboratorio123
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

        private void btnSemi_Click(object sender, EventArgs e)
        {
            try
            {
                double a = double.Parse(txtA.Text);
                double b = double.Parse(txtB.Text);
                double c = double.Parse(txtC.Text);

                if (!TrianguloHelper.EsTrianguloValido(a, b, c))
                {
                    MessageBox.Show("Los valores no forman un triángulo válido.");
                    return;
                }

                double s = TrianguloHelper.CalcularSemiperimetro(a, b, c);
                txtResulSemi.Text = $"Semiperímetro: {s:F2}";
            }
            catch
            {
                MessageBox.Show("Ingrese valores numéricos válidos.");
            }
        }

        private void btnArea_Click(object sender, EventArgs e)
        {
            try
            {
                double a = double.Parse(txtA.Text);
                double b = double.Parse(txtB.Text);
                double c = double.Parse(txtC.Text);

                if (!TrianguloHelper.EsTrianguloValido(a, b, c))
                {
                    MessageBox.Show("Los valores no forman un triángulo válido.");
                    return;
                }

                double area = TrianguloHelper.CalcularArea(a, b, c);
                txtResulArea.Text = $"Área: {area:F2}";
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
