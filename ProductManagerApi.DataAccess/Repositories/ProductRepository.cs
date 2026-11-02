using product_manager_api.ProductManagerApi.DataAccess.Models;

namespace product_manager_api.ProductManagerApi.DataAccess.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private static readonly List<Product> _products = new()
        {
            new Product { Id = 1, Nombre = "Teclado", Precio = 25000m, Categoria = "Electrónica", Activo = true },
            new Product { Id = 2, Nombre = "Mouse", Precio = 15000m, Categoria = "Electrónica", Activo = true },
            new Product { Id = 3, Nombre = "Lámpara", Precio = 30000m, Categoria = "Hogar", Activo = true },
            new Product { Id = 4, Nombre = "Cuaderno", Precio = 5000m, Categoria = "Librería", Activo = true }
        };

        public ICollection<Product> ObtenerTodos()
        {
            return _products.ToList();
        }

        public Product? ObtenerPorId(int id)
        {
            return _products.FirstOrDefault(p => p.Id == id);
        }

        public Product Agregar(Product product)
        {
            product.Id = _products.Count > 0 ? _products.Max(p => p.Id) + 1 : 1;
            _products.Add(product);
            return product;
        }

        public Product? Actualizar(Product product)
        {
            var existingProduct = _products.FirstOrDefault(p => p.Id == product.Id);
            if (existingProduct != null)
            {
                existingProduct.Nombre = product.Nombre;
                existingProduct.Precio = product.Precio;
                existingProduct.Categoria = product.Categoria;
                existingProduct.Activo = product.Activo;
            }
            return existingProduct;
        }

        public bool Eliminar(int id)
        {
            var productToRemove = _products.FirstOrDefault(p => p.Id == id);
            if (productToRemove != null)
            {
                _products.Remove(productToRemove);
                return true;
            }
            return false;
        }
    }
}
