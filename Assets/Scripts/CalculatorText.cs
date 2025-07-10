using UnityEngine;
using TMPro;
public class CalculatorText : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public TMP_Text CalcText;

    private string currentNumber = "";
    private string lastSymbol = "";
    private float lastNumber = 0;   private string expression = "";

    void Start()
    {
        CalcText.text = "";
    }

    public void OnButtonPress(string value)
    {
        Debug.Log("Button Pressed: " + value);

        if (value == "C")
        {
            Clear();
        }
        else if (value == "." && currentNumber.Contains("."))
        {
            return;
        }
        else if (value == "+" || value == "-" || value == "*" || value == "/")
        {
            if (currentNumber != "")
            {
                lastNumber = float.Parse(currentNumber);
                currentNumber = "";
            }

            lastSymbol = value;
            expression += " " + value + " ";
            CalcText.text = expression;
        }
        else if (value == "=")
        {
            if (currentNumber != "" && lastSymbol != "")
            {
                float secondNumber = float.Parse(currentNumber);
                float result = 0;

                switch (lastSymbol)
                {
                    case "+": result = lastNumber + secondNumber; break;
                    case "-": result = lastNumber - secondNumber; break;
                    case "*": result = lastNumber * secondNumber; break;
                    case "/": result = secondNumber != 0 ? lastNumber / secondNumber : 0; break;
                }

                expression += " = " + result.ToString();
                CalcText.text = expression;

                currentNumber = result.ToString();
                lastSymbol = "";
                expression = currentNumber;
            }
        }
        else
        {
            currentNumber += value;
            expression += value;
            CalcText.text = expression;
        }
    }

    public void Clear()
    {
        currentNumber = "";
        lastSymbol = "";
        lastNumber = 0;
        expression = "";
        CalcText.text = "";
    }
}