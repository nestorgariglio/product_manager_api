using product_manager_api.ProductManagerApi.DataAccess.Models;

namespace product_manager_api.ProductManagerApi.DataAccess.Repositories
{
    public interface IProductRepository
    {
        ICollection<Product> ObtenerTodos();
        Product? ObtenerPorId(int id);
        Product Agregar(Product product);
        Product? Actualizar(Product product);
        bool Eliminar(int id);
    }
}
