using System.ComponentModel.DataAnnotations;

namespace DTO
{
    public class ProductDTO : BaseDTO
    {
        public int CategoryId { get; set; }
        public CategoryDTO Category { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public double Price { get; set; }
        public string Discription { get; set; }
    }
}
