using System.ComponentModel.DataAnnotations;

namespace book_mvc.Models
{
    public class CategoryModel
    {
        [Key]
        public int Id { get; set; }
        [Required, MinLength(4, ErrorMessage = "Name can not be empty")]
        public string Name { get; set; }
        [Required, MinLength(4, ErrorMessage = "Description can not be empty")]
        public string Description { get; set; }
        [Required]
        public string Slug { get; set; }
        public int Status { get; set; }
    }
}
