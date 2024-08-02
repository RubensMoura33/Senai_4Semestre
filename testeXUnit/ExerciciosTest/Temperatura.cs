using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercicios
{
    public class Temperatura
    {
        public static double ConverterCelsiusParaFahrenheit(double temperatura)
        {
            var fahrenheit = 1.8 * temperatura + 32;

            return fahrenheit;
        }
    }
}
