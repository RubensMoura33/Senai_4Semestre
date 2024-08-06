using Moq;
using TesteAPIProduct.Domains;
using TesteAPIProduct.Interface;

namespace testApi
{
    public class ProductsTest
    {
        //Indica que o metodo e de teste de unidade
        [Fact]
        public void Get()
        {
            //Arranger : Organizar

            var products = new List<Products>
            {
                new Products {IdProduct = Guid.NewGuid() , Name = "Produto 1", Price= 10},
                new Products {IdProduct = Guid.NewGuid() , Name = "Produto 2", Price= 15},
                new Products {IdProduct = Guid.NewGuid() , Name = "Produto 3", Price= 20},
                new Products {IdProduct = Guid.NewGuid() , Name = "Produto 3", Price= 20},
            };

            //Cria um obj de simulacao do tipo IProductRepository
            var mockRepository = new Mock<IProductRepository>();

            //Configura o metodo Get para retornar a lista de produtos "mock"
            mockRepository.Setup(x => x.GetProducts()).Returns(products);

            //Act : Agir

            //Ele chama o metodo Get() e armazena o resultado em result
            var result = mockRepository.Object.GetProducts();

            //Assert : Provar

            //Prova se o resultado esperado e igual ao resultado obtido atraves da busca
            Assert.Equal(4, result.Count);
        }

        [Fact]
        public void Post ()
        {

            // Arrange: Organize o cenário do teste

            // Cria uma lista inicial de produtos
            var products = new List<Products>
            {
                new Products { IdProduct = Guid.NewGuid(), Name = "Produto 1", Price = 10 },
                new Products { IdProduct = Guid.NewGuid(), Name = "Produto 2", Price = 15 },
                new Products { IdProduct = Guid.NewGuid(), Name = "Produto 3", Price = 20 },
                new Products { IdProduct = Guid.NewGuid(), Name = "Produto 3", Price = 20 },
            };

            // Cria um novo produto que será adicionado à lista
            var newProduct = new Products { IdProduct = Guid.NewGuid(), Name = "Produto Novo", Price = 25 };

            // Cria um mock (simulação) do repositório de produtos
            var mockRepository = new Mock<IProductRepository>();

            // Configura o método GetProducts do mock para retornar a lista inicial de produtos
            mockRepository.Setup(x => x.GetProducts()).Returns(products);

            // Configura o método Post do mock para adicionar o produto à lista de produtos
            mockRepository.Setup(x => x.Post(It.IsAny<Products>())).Callback<Products>(p => products.Add(p));

            // Act: Ação do teste

            // Adiciona o novo produto usando o método Post do mock
            mockRepository.Object.Post(newProduct);

            // Obtém a lista atualizada de produtos
            var result = mockRepository.Object.GetProducts();

            // Assert: Verificação dos resultados

            // Verifica se a lista de produtos contém o novo produto adicionado
            Assert.Contains(result, p => p.IdProduct == newProduct.IdProduct && p.Name == newProduct.Name && p.Price == newProduct.Price);

            // Verifica se a contagem total de produtos é 5 (inicialmente 4 mais 1 novo produto)
            Assert.Equal(5, result.Count);
        }

        [Fact]
        public void DeleteProduct_RemovesProductFromList()
        {
            var productIdToDelete = Guid.NewGuid();
            var products = new List<Products>
    {
        new Products {IdProduct = Guid.NewGuid(), Name = "Produto 1", Price = 10},
        new Products {IdProduct = Guid.NewGuid(), Name = "Produto 2", Price = 20},
        new Products {IdProduct = productIdToDelete, Name = "Produto 3", Price = 30},
        new Products {IdProduct = Guid.NewGuid(), Name = "Produto 4", Price = 40},
    };

            var mockRepository = new Mock<IProductRepository>();
            mockRepository.Setup(x => x.GetProducts()).Returns(products);
            mockRepository.Setup(x => x.Delete(It.IsAny<Guid>())).Callback<Guid>(id =>
            {
                var product = products.FirstOrDefault(p => p.IdProduct == id);
                if (product != null)
                {
                    products.Remove(product);
                }
            });

            mockRepository.Object.Delete(productIdToDelete);

            var result = mockRepository.Object.GetProducts();
            Assert.Equal(3, result.Count);
            Assert.DoesNotContain(result, p => p.IdProduct == productIdToDelete);
        }
    }
    
}