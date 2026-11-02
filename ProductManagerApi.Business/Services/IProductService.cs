using product_manager_api.ProductManagerApi.Business.DTOs;

namespace product_manager_api.ProductManagerApi.Business.Services;

public interface IProductService
{
    List<ProductDto> ObtenerTodos();
    ProductDto? ObtenerPorId(int id);
    ProductDto Agregar(CreateProductDto product);
    ProductDto? Actualizar(int id, CreateProductDto product);
    bool Eliminar(int id);
}
