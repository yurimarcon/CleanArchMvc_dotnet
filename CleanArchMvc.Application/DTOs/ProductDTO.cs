using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CleanArchMvc.Application.DTOs
{
    public class ProductDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "The Name is required")]
        [MinLength(3)]
        [MaxLength(100)]
        [Display(Name = "Name")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "The Description is required")]
        [MinLength(5)]
        [MaxLength(200)]
        [Display(Name = "Description")]
        public string Description { get; set; }

        [Required(ErrorMessage = "The Price is required")]
        [Column(TypeName = "decimal(18,2)")]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        [DataType(DataType.Currency)]
        [Display(Name = "Price")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "The Stock is required")]
        [Range(1, 9999)]
        [Display(Name = "Stock")]
        public decimal Stock { get; set; }

        [Display(Name = "Product Image")]
        public string? Image { get; set; }
        public CategoryDTO? Category { get; set; }

        [Display(Name = "Categories")]
        public int CategoryId { get; set; }
    }
}