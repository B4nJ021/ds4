using System;

public class Calculator
{
    private decimal currentValue;
    private decimal previousValue;
    private string operation;
    private bool isNewOperation;

    public Calculator()
    {
        Clear();
    }

    public decimal CurrentValue => currentValue;

    public void SetNumber(decimal number)
    {
        if (isNewOperation)
        {
            currentValue = number;
            isNewOperation = false;
        }
        else
        {
            currentValue = number;
        }
    }

    public void SetOperation(string op)
    {
        if (!isNewOperation && operation != null)
        {
            Calculate();
        }

        previousValue = currentValue;
        operation = op;
        isNewOperation = true;
    }

    public decimal Calculate()
    {
        if (operation == null) return currentValue;

        decimal result = 0;

        switch (operation)
        {
            case "+":
                result = previousValue + currentValue;
                break;
            case "-":
                result = previousValue - currentValue;
                break;
            case "*":
                result = previousValue * currentValue;
                break;
            case "/":
                if (currentValue == 0)
                    throw new DivideByZeroException("No se puede dividir por cero");
                result = previousValue / currentValue;
                break;
        }

        currentValue = result;
        operation = null;
        isNewOperation = true;
        return result;
    }

    public decimal Square()
    {
        currentValue = currentValue * currentValue;
        isNewOperation = true;
        return currentValue;
    }

    public decimal SquareRoot()
    {
        if (currentValue < 0)
            throw new InvalidOperationException("No se puede calcular la raíz cuadrada de un número negativo");

        currentValue = (decimal)Math.Sqrt((double)currentValue);
        isNewOperation = true;
        return currentValue;
    }

    public void Negate()
    {
        currentValue = -currentValue;
    }

    public void Clear()
    {
        currentValue = 0;
        previousValue = 0;
        operation = null;
        isNewOperation = true;
    }

    public void ClearEntry()
    {
        currentValue = 0;
        isNewOperation = true;
    }

    public string GetOperationString(decimal num1, string op, decimal num2, decimal result)
    {
        return $"{num1} {op} {num2} = {result}";
    }

    public string GetUnaryOperationString(string op, decimal num, decimal result)
    {
        if (op == "x²")
            return $"{num}² = {result}";
        else if (op == "√")
            return $"√{num} = {result}";
        return "";
    }
}
