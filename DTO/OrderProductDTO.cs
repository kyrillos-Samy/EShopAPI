using System.ComponentModel.DataAnnotations;

namespace DTO
{
    public class OrderProductDTO : BaseDTO
    {
        public int OrderId { get; set; }
        public OrderDTO Order { get; set; }
        public int ProductId { get; set; }
        public ProductDTO Product { get; set; }
        [Required]
        public int Quantity { get; set; }
        public double Amount { get; set; }
    }
}
