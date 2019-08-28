using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Calculator
{

    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        int currentState = 1;
        string mathOperator;
        double firstNumber, secondNumber, result;

        public MainPage()
        {
            InitializeComponent();
            OnClear(this, null);
        }
        void OnClear(object sender, EventArgs e)
        {
            firstNumber = 0.0;
            secondNumber = 0.0;
            currentState = 1;
            result = 0;
            this.resultText.Text = "0";
        }
        void OnClearInput(object sender, EventArgs e)
        {

            if (currentState == 1)
            {
                result = 0;
                firstNumber = 0;
                secondNumber = 0;
                this.resultText.Text = "0";
            }
            else if (currentState == 2)
            {
                currentState = -2;
                firstNumber = result;
                secondNumber = 0;
                result = 0;
                this.resultText.Text = "0";
            }
            else if(currentState == -1)
            {
                firstNumber = result;
                secondNumber = 0;
                this.resultText.Text = Convert.ToString(firstNumber);
            }

        }

        void OnBackSelected(object sender, EventArgs e)
        {   if(!this.resultText.Text.Equals( ""))
            {
                this.resultText.Text = resultText.Text.Remove(resultText.Text.Length - 1, 1);
            }  
        }

        // Positive Negative

        void OnPositiveNegative(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            string pressed = button.Text;

            if (this.resultText.Text == "0")
            {

            }
            else if (!this.resultText.Text.Contains("-"))
            {
                if (currentState == 1 || currentState == -1)
                {
                    firstNumber *= -1; this.resultText.Text = this.resultText.Text.Insert(0, "-");
                }
                else if (currentState == 2)
                {
                    secondNumber *= -1; this.resultText.Text = this.resultText.Text.Insert(0, "-");
                }
                else
                {
                    this.result *= -1; this.resultText.Text = this.resultText.Text.Insert(0, "-");
                }
            }
            else if (this.resultText.Text.Contains("-"))
            {
                if (currentState == 1 || currentState == -1)
                {
                    firstNumber *= -1; this.resultText.Text = this.resultText.Text.Remove(0, 1);
                }
                else if (currentState == 2 && secondNumber < 0)
                {
                    secondNumber *= -1; this.resultText.Text = this.resultText.Text.Remove(0, 1);
                }
                else
                {
                    result *= -1; this.resultText.Text = this.resultText.Text.Remove(0, 1);
                }

            }
        }

        // Decimal Select
        void OnDecimal(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            string pressed = button.Text;

            if (!this.resultText.Text.Contains("."))
            {
                this.resultText.Text += ".";

            }
            else if (this.resultText.Text.Contains("."))
            {
                this.resultText.Text += "";

            }


            //this.resultText.Text = resultText.Text;
            //this.resultText.Text += pressed;
        }

        void OnSelectNumber(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            string pressed = button.Text;

            if (this.resultText.Text == "0" || currentState < 0)
            {
                this.resultText.Text = "";
                if (currentState < 0)
                    currentState *= -1;
            }
          
            {
                this.resultText.Text += pressed;

            }

            //for decimal ending

            double number;
            if (double.TryParse(this.resultText.Text, out number))
            {
                this.resultText.Text = number.ToString("N0");
                if (currentState == 1)
                {
                    firstNumber = number;
                }
                else
                {
                    secondNumber = number;
                    // currentState = 2;
                }

            }
        }


        void OnSelectOperator(object sender, EventArgs e)
        {

            Button button = (Button)sender;
            string pressed = button.Text;


            if (((currentState == -2 || currentState == -1 || currentState == 1) && pressed == "%")
                || pressed == "√" || pressed == "x²" || pressed == "1/x")
            {
                result = SimpleCalculator.Calculate(firstNumber, 1, pressed);

                this.resultText.Text = result.ToString();
                firstNumber = result;
                currentState = -1;
            }
            else if (currentState == 2)
            {
                result = SimpleCalculator.Calculate(firstNumber, secondNumber, mathOperator);

                this.resultText.Text = result.ToString();
                firstNumber = result;
                currentState = -1;
            }
            mathOperator = pressed;
            currentState = -2;
        }


        void OnCalculate(object sender, EventArgs e)
        {
            if (currentState == 2)
            {
                result = SimpleCalculator.Calculate(firstNumber, secondNumber, mathOperator);

                this.resultText.Text = result.ToString();
                firstNumber = result;
                currentState = -1;
            }
        }


    }
}
