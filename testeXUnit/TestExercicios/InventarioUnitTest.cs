using Exercicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestExercicios
{
    public class InventarioUnitTest
    {
        [Fact]
        public static void AdicionarProduto_NovoProduto_AdicionaProdutoComQuantidade()
        {

            Inventario.AdicionarProduto("ProdutoA", 10);

            Assert.Equal(10, Inventario.ObterQuantidade("ProdutoA"));
        }

        [Fact]
        public static void AdicionarProduto_ProdutoExistente_IncrementaQuantidade()
        {
            Inventario.AdicionarProduto("ProdutoA", 10);

            Inventario.AdicionarProduto("ProdutoA", 5);

            Assert.Equal(25, Inventario.ObterQuantidade("ProdutoA"));
        }

        [Fact]
        public static void ObterQuantidade_ProdutoNaoExiste_RetornaZero()
        {

            var quantidade = Inventario.ObterQuantidade("ProdutoInexistente");

            Assert.Equal(0, quantidade);
        }
    }
}
