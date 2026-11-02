using System.ComponentModel.DataAnnotations;

namespace product_manager_api.ProductManagerApi.Business.DTOs;

public class CreateProductDto
{
    [Required]
    [StringLength(100, MinimumLength = 3)]
    public string Nombre { get; set; } = string.Empty;

    [Required]
    [Range(typeof(decimal), "0", "79228162514264337593543950335", MinimumIsExclusive = true)]
    public decimal Precio { get; set; }

    [Required]
    public string Categoria { get; set; } = string.Empty;
}
