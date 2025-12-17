using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto1
{
    public partial class Form1 : Form
    {
        private Calculator calculator;
        private DatabaseManager dbManager;
        private bool isDecimalEntered;
        private string currentOperation;
        private decimal valueBeforeOperation;
        public Form1()
        {
            InitializeComponent();
            calculator = new Calculator();
            dbManager = new DatabaseManager("localhost", "CalculadoraDB");

            isDecimalEntered = false;
            currentOperation = null;
        }
        // Método para manejar los botones numéricos
        private void NumberButton_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            string number = btn.Text;

            if (txtDisplay.Text == "0" || txtDisplay.Text == "Error")
            {
                txtDisplay.Text = number;
            }
            else
            {
                txtDisplay.Text += number;
            }
        }
        // Método para el botón decimal
        private void ButtonDecimal_Click(object sender, EventArgs e)
        {
            if (!isDecimalEntered && !txtDisplay.Text.Contains("."))
            {
                txtDisplay.Text += ".";
                isDecimalEntered = true;
            }
        }

        // Método para botones de operación (+, -, *, /)
        private void OperationButton_Click(object sender, EventArgs e)
        {
            try
            {
                Button btn = (Button)sender;
                string operation = btn.Text;

                decimal currentNumber = decimal.Parse(txtDisplay.Text);
                calculator.SetNumber(currentNumber);
                calculator.SetOperation(operation);

                valueBeforeOperation = currentNumber;
                currentOperation = operation;

                txtDisplay.Text = "0";
                isDecimalEntered = false;
            }
            catch (Exception ex)
            {
                txtDisplay.Text = "Error";
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Método para el botón igual (=)
        private void ButtonEquals_Click(object sender, EventArgs e)
        {
            try
            {
                decimal currentNumber = decimal.Parse(txtDisplay.Text);
                calculator.SetNumber(currentNumber);

                decimal result = calculator.Calculate();

                // Guardar en base de datos
                if (currentOperation != null)
                {
                    string operationString = calculator.GetOperationString(
                        valueBeforeOperation, currentOperation, currentNumber, result);
                    dbManager.SaveCalculation(operationString, result);
                }

                txtDisplay.Text = result.ToString();
                isDecimalEntered = false;
                currentOperation = null;
            }
            catch (Exception ex)
            {
                txtDisplay.Text = "Error";
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Método para el botón Clear (C)
        private void ButtonClear_Click(object sender, EventArgs e)
        {
            calculator.Clear();
            txtDisplay.Text = "0";
            isDecimalEntered = false;
            currentOperation = null;
        }

        // Método para el botón Clear Entry (CE)
        private void ButtonClearEntry_Click(object sender, EventArgs e)
        {
            calculator.ClearEntry();
            txtDisplay.Text = "0";
            isDecimalEntered = false;
        }

        // Método para el botón de cuadrado (x²)
        private void ButtonSquare_Click(object sender, EventArgs e)
        {
            try
            {
                decimal currentNumber = decimal.Parse(txtDisplay.Text);
                calculator.SetNumber(currentNumber);

                decimal result = calculator.Square();

                // Guardar en base de datos
                string operationString = calculator.GetUnaryOperationString("x²", currentNumber, result);
                dbManager.SaveCalculation(operationString, result);

                txtDisplay.Text = result.ToString();
                isDecimalEntered = false;
            }
            catch (Exception ex)
            {
                txtDisplay.Text = "Error";
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Método para el botón de raíz cuadrada (√)
        private void ButtonSquareRoot_Click(object sender, EventArgs e)
        {
            try
            {
                decimal currentNumber = decimal.Parse(txtDisplay.Text);
                calculator.SetNumber(currentNumber);

                decimal result = calculator.SquareRoot();

                // Guardar en base de datos
                string operationString = calculator.GetUnaryOperationString("√", currentNumber, result);
                dbManager.SaveCalculation(operationString, result);

                txtDisplay.Text = result.ToString();
                isDecimalEntered = false;
            }
            catch (Exception ex)
            {
                txtDisplay.Text = "Error";
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Método para el botón de negativo (+/-)
        private void ButtonNegate_Click(object sender, EventArgs e)
        {
            try
            {
                decimal currentNumber = decimal.Parse(txtDisplay.Text);
                calculator.SetNumber(currentNumber);
                calculator.Negate();

                txtDisplay.Text = calculator.CurrentValue.ToString();
            }
            catch (Exception ex)
            {
                txtDisplay.Text = "Error";
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void btnTestConnection_Click(object sender, EventArgs e)
        {
            if (dbManager.TestConnection())
            {
                MessageBox.Show("Conexión exitosa a la base de datos", "Éxito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("No se pudo conectar a la base de datos", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
