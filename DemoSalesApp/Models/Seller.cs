using System.ComponentModel.DataAnnotations;

namespace DemoSalesApp.Models
{
    public class Seller
    {
        [Key]
        public int SellerId { get; set; }

        public string? SellerUsername { get; set; }

        public string? SellerPassword { get; set; }

        [Required]
        public string SellerEmail { get; set; }
    }
}
