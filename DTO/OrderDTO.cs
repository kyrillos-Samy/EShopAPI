using System.ComponentModel.DataAnnotations;

namespace DTO
{
    public class OrderDTO : BaseDTO
    {
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public double TotalAmount { get; set; }
        public List<OrderProductDTO> Items { get; set; }
    }
}
