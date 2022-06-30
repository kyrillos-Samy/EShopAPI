using System.ComponentModel.DataAnnotations;

namespace DTO
{
    public class ProductDiscountDTO : BaseDTO
    {
        public int ProductId { get; set; }
        public ProductDTO Product { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public double Percentage { get; set; }
    }
}
