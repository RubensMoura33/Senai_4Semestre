using Exercicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestExercicios
{
    public class LivroUnitTest
    {
        [Fact]
        public void TestarMetodoAdicionarLivro () 
        {   
            string livro = "guarani";

            var numeroDeLivros = Livro.ListarNumeroDeLivros();

            var numeroDeLivrosEsperados = numeroDeLivros + 1;

            var numeroDeLivrosAposAdicionar = Livro.AdicionarLivro(livro);

            Assert.Equal(numeroDeLivrosEsperados, numeroDeLivrosAposAdicionar);
        }
    }
}
