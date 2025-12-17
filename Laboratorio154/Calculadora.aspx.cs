using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Laboratorio154
{
    public partial class Calculadora : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSumar_Click(object sender, EventArgs e)
        {
            try
            {
                // Leer los valores de los TextBox
                double numero1 = Convert.ToDouble(txtNumero1.Text);
                double numero2 = Convert.ToDouble(txtNumero2.Text);

                // Realizar la suma
                double resultado = numero1 + numero2;

                // Mostrar el resultado en el Label
                lblResultado.Text = $"Resultado: {numero1} + {numero2} = {resultado}";
                lblResultado.Visible = true;
            }
            catch (Exception)
            {
                // Manejo de errores si los valores no son válidos
                lblResultado.Text = "Error: Por favor ingrese números válidos";
                lblResultado.Visible = true;
            }
        }
    }
}