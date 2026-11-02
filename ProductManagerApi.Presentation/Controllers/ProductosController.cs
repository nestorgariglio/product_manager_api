using Microsoft.AspNetCore.Mvc;
using product_manager_api.ProductManagerApi.Business.DTOs;
using product_manager_api.ProductManagerApi.Business.Services;

namespace ProductManagerApi.Controllers;

[ApiController]
[Route("api/productos")]
public class ProductosController : ControllerBase
{
    private readonly IProductService _service;

    public ProductosController(IProductService service)
    {
        _service = service;
    }

    [HttpGet]
    public IActionResult ObtenerTodos()
    {
        return Ok(_service.ObtenerTodos());
    }

    [HttpGet("{id:int}")]
    public IActionResult ObtenerPorId(int id)
    {
        var product = _service.ObtenerPorId(id);
        return product is null ? NotFound() : Ok(product);
    }

    [HttpPost]
    public IActionResult Agregar([FromBody] CreateProductDto product)
    {
        var created = _service.Agregar(product);
        return CreatedAtAction(nameof(ObtenerPorId), new { id = created.Id }, created);
    }

    [HttpPut("{id:int}")]
    public IActionResult Actualizar(int id, [FromBody] CreateProductDto product)
    {
        var updated = _service.Actualizar(id, product);
        return updated is null ? NotFound() : Ok(updated);
    }

    [HttpDelete("{id:int}")]
    public IActionResult Eliminar(int id)
    {
        return _service.Eliminar(id) ? NoContent() : NotFound();
    }
}
