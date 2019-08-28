using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator
{
    class SimpleCalculator
    {
        public static double Calculate(double value1, double value2, string mathOperator)

        {

            double result = 0;



            switch (mathOperator)

            {

                case "÷":

                    result = value1 / value2;

                    break;

                case "×":

                    result = value1 * value2;

                    break;

                case "+":

                    result = value1 + value2;

                    break;

                case "-":

                    result = value1 - value2;

                    break;

                case "%":

                    result =  (value1/100) * value2;


                    break;

                case "√":

                    result =  Math.Sqrt(value1);

                    break;

                case "x²":

                    result = Math.Pow(value1,2);

                    break;

                case "1/x":

                    result =  1/value1;

                    break;

            }



            return result;

        }
    }
}
