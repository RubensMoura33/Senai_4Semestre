using Exercicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestExercicios
{
    public class EmailUnitTest
    {
        [Theory]
        [InlineData("rubens@email.com")]
        [InlineData("rubensemail.com")] 
        [InlineData("rubensemail")]
        
        public void TestarSeOEmailEValido(string email) 
        {
            var resultadoEsperado = true;

            var resultado = Email.VerficarEmail(email);

            Assert.Equal(resultadoEsperado, resultado);
        }

    }
}
