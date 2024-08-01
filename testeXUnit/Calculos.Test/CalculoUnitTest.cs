using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculos.Test
{
    public class CalculoUnitTest
    {

        //AAA : Act, Arrange, Assert
        //AAA : Afir, Organizar e Assertir

        [Fact]
        public void TestarMetodoSomar() 
        {
            //Arrange : Organizar
            var x1 = 4.1;
            var x2 = 5.9;
            var valorEsperado = 10;

            //Act : Agir

            var soma = Calculo.Somar(x1, x2);

            //Assert : Provar

            Assert.Equal(valorEsperado, soma);
        }
        [Fact]
        public void TestarMetodoDividir()
        {
            //Arrange : Organizar
            var x1 = 10;
            var x2 = 2;
            var valorEsperado = 5;

            //Act : Agir

            var divisao = Calculo.Dividir(x1, x2);

            //Assert : Provar

            Assert.Equal(valorEsperado, divisao);
        }
        [Fact]
        public void TestarMetodoMultiplicar()
        {
            //Arrange : Organizar
            var x1 = 5;
            var x2 = 3;
            var valorEsperado = 15;

            //Act : Agir

            var multiplicar = Calculo.Multiplicar(x1, x2);

            //Assert : Provar

            Assert.Equal(valorEsperado, multiplicar);
        }
        [Fact]
        public void TestarMetodoSubtrair()
        {
            //Arrange : Organizar
            var x1 = 10;
            var x2 = 5;
            var valorEsperado = 5;

            //Act : Agir

            var subtrair = Calculo.Subtrair(x1, x2);

            //Assert : Provar

            Assert.Equal(valorEsperado, subtrair);
        }
    }
}
