

using RestWebApi.Contracts;

namespace RestWebApi.Services;

public class MockForCourseProductRepository: IProductRepository
{
    List<Product> products = new List<Product>
    {
        new Product { Id = 1, Name = "Apple" , Price =10 },
        new Product { Id = 2, Name = "Book", Price =25 },
        new Product { Id = 3, Name = "Milk" , Price=20 }
    };

    public Task<Product> AddNewProduct(Product p)
    {
        int Id = products.Max(p => p.Id) + 1;
        Product newProduct = p with { Id = Id };
        products.Add(newProduct);
        return Task.FromResult(newProduct);
    }

    public Task<bool> Delete(int id)
    {
        bool deleted = false;
        var p = products.Where(p=>p.Id == id).FirstOrDefault();
        if (p != null)
        {
            deleted = true;
            products.Remove(p);
        }

        return Task.FromResult(deleted);
        
    }

    public Task<List<Product>> GetAllProducts()
    {
        return Task.FromResult(products);
    }

    public Task<Product> GetProductById(int id)
    {
        Product p = products.Where(p=>p.Id == id).FirstOrDefault();
        return Task.FromResult(p);
    }

    public Task<bool> Update(Product p)
    {
        bool updated = false;
        Product product = products.Where(i=> i.Id == p.Id).FirstOrDefault();
        if(product != null)
        {
            updated = true;
            int index = products.IndexOf(product);
            products[index] = p;
        }

        return Task.FromResult(updated);
    }
}
