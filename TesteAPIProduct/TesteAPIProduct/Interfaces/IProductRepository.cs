using TesteAPIProduct.Domains;

namespace TesteAPIProduct.Interface
{
    public interface IProductRepository
    {
        List<Products> GetProducts();
        void Post(Products product);
        Products GetById(Guid id);
        void Delete(Guid id);
        void Update(Guid id, Products product);


    }
}
