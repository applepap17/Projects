using UnityEngine;
using TMPro;
public class CalculatorText : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public TMP_Text CalcText;

    private string currentNumber = "";
    private string lastSymbol = "";
    private float lastNumber = 0;

    void Start()
    {
        CalcText.text = "";
    }



    // Update is called once per frame
    void Update()
    {

    }
    
        public void OnButtonPress(string value)
    {
        Debug.Log("Button Pressed: " + value);
        
        if (value == "C")
        {
            Clear();
        }
        else if (value == "+" || value == "-" || value == "*" || value == "/")
        {
            if (currentNumber != "")
            {
                lastNumber = float.Parse(currentNumber);
                currentNumber = "";
            }
            lastSymbol = value;
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

                CalcText.text = result.ToString();
                currentNumber = result.ToString();
                lastSymbol = "";
            }
        }
        else
        {
            currentNumber += value;
            CalcText.text = currentNumber;
        }
    }

    public void Clear()
    {
        currentNumber = "";
        lastSymbol = "";
        lastNumber = 0;
        CalcText.text = "";
    }
}
