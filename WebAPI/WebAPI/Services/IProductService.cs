using WebAPI.Models;

namespace WebAPI.Services
{
    public interface IProductService
    {
        IEnumerable<Product> GetProducts();
        Product GetProduct(int id);
        void AddProduct(Product product);
        void UpdateProduct(int id, Product product);
        void DeleteProduct(int id);
        IEnumerable<Product> GetProductsByCustomerId(int customerId);
    }
}
