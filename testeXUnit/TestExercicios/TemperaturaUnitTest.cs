using Exercicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestExercicios
{
    public class TemperaturaUnitTest
    {
        [Fact]
        public void VerificarMetodoConversao()
        {
            var temperatura = 25;

            var fahrenheitEsperado = 77;

            var fahrenheit = Temperatura.ConverterCelsiusParaFahrenheit(temperatura);

            Assert.Equal(fahrenheitEsperado, fahrenheit);
        }
    }
}
