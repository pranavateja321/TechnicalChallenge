using WebAPI.Models;

namespace WebAPI.Services
{
    public class MockProductService : IProductService
    {
        private static List<Product> _products = new List<Product>
        {
            new Product { Id = 1, Name = "Product 1", CustomerId = 1 },
            new Product { Id = 2, Name = "Product 2", CustomerId = 1 },
            new Product { Id = 3, Name = "Product 3", CustomerId = 2 },
            new Product { Id = 4, Name = "Product 4", CustomerId = 2 },
            // Add more mock products as needed
        };

        public IEnumerable<Product> GetProducts()
        {
            return _products;
        }

        public Product GetProduct(int id)
        {
            return _products.FirstOrDefault(p => p.Id == id);
        }

        public void AddProduct(Product product)
        {
            product.Id = _products.Count + 1;
            _products.Add(product);
        }

        public void UpdateProduct(int id, Product product)
        {
            var existingProduct = _products.FirstOrDefault(p => p.Id == id);
            if (existingProduct != null)
            {
                existingProduct.Name = product.Name;
                existingProduct.CustomerId = product.CustomerId;
            }
        }

        public void DeleteProduct(int id)
        {
            var productToDelete = _products.FirstOrDefault(p => p.Id == id);
            if (productToDelete != null)
            {
                _products.Remove(productToDelete);
            }
        }

        public IEnumerable<Product> GetProductsByCustomerId(int customerId)
        {
            return _products.Where(p => p.CustomerId == customerId);
        }
    }
}
