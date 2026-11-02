using product_manager_api.ProductManagerApi.Business.DTOs;
using product_manager_api.ProductManagerApi.DataAccess.Models;
using product_manager_api.ProductManagerApi.DataAccess.Repositories;

namespace product_manager_api.ProductManagerApi.Business.Services;

public class ProductService : IProductService
{
    private readonly IProductRepository _repository;

    public ProductService(IProductRepository repository)
    {
        _repository = repository;
    }

    public List<ProductDto> ObtenerTodos()
    {
        return _repository.ObtenerTodos().Select(ToDto).ToList();
    }

    public ProductDto? ObtenerPorId(int id)
    {
        var product = _repository.ObtenerPorId(id);
        return product is null ? null : ToDto(product);
    }

    public ProductDto Agregar(CreateProductDto product)
    {
        var created = _repository.Agregar(new Product
        {
            Nombre = product.Nombre,
            Precio = product.Precio,
            Categoria = product.Categoria,
            Activo = true
        });

        return ToDto(created);
    }

    public ProductDto? Actualizar(int id, CreateProductDto product)
    {
        var existing = _repository.ObtenerPorId(id);
        if (existing is null)
        {
            return null;
        }

        var updated = _repository.Actualizar(new Product
        {
            Id = id,
            Nombre = product.Nombre,
            Precio = product.Precio,
            Categoria = product.Categoria,
            Activo = existing.Activo
        });

        return updated is null ? null : ToDto(updated);
    }

    public bool Eliminar(int id)
    {
        return _repository.Eliminar(id);
    }

    private static ProductDto ToDto(Product product)
    {
        return new ProductDto
        {
            Id = product.Id,
            Nombre = product.Nombre,
            Precio = product.Precio,
            Categoria = product.Categoria,
            Activo = product.Activo
        };
    }
}
