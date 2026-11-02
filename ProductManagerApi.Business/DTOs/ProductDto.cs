namespace product_manager_api.ProductManagerApi.Business.DTOs;

public class ProductDto
{
    public int Id { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public decimal Precio { get; set; }
    public string Categoria { get; set; } = string.Empty;
    public bool Activo { get; set; }
}
