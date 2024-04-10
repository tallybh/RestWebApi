using RestWebApi.Models;

namespace RestWebApi.Contracts;

public interface IProductRepository
{
    Task<List<Product>> GetAllProducts();
    Task<Product> GetProductById(int id);
    Task<Product> AddNewProduct(Product p);

    Task<bool> Delete(int id);

    Task<bool> Update(Product p);

}
