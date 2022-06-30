using System.ComponentModel.DataAnnotations;

namespace DTO
{
    public class CategoryDTO : BaseDTO
    {
        [Required]
        public string Name { get; set; }
    }
}
