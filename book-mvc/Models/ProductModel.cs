using System.ComponentModel.DataAnnotations;

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
        [Required, MinLength(4, ErrorMessage = "Price can not be empty")]
        public decimal Price { get; set; }
        public string Image { get; set; }
        public int CategoryId { get; set; }
        public CategoryModel Category { get; set; }
    }
}
