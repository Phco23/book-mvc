using book_mvc.Repository.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace book_mvc.Models
{
    public class ProductModel
    {
        [Key]
        public int Id { get; set; }
        [Required, MinLength(4, ErrorMessage = "Name can not be empty")]
        public string Name { get; set; }
        public string Slug { get; set; }
        [Required, MinLength(4, ErrorMessage = "Description can not be empty")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Price cannot be empty")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Price must be a positive number")]
        [Column(TypeName = "decimal(8,2)")]
        public decimal Price { get; set; }
        public string Image { get; set; }
        public int CategoryId { get; set; }
        public CategoryModel Category { get; set; }
        [NotMapped]
        [FileExtension(ErrorMessage = "Only image files (jpg, jpeg, png) are allowed.")]
        public IFormFile? ImageUpload { get; set; }
    }
}
