using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using System.ComponentModel;

namespace DemoSalesApp.Models
{
    public class Product
    {

        [Key]
        public int ProductId { get; set; }

        //[Required]
        public string? ProductPicUrl { get; set; }

        [Required]
        [DisplayName("Product name")]
        public string ProductName { get; set; }

        [Required]
        [DisplayName("Product Price")]
        public double ProductPrice { get; set; }

        [DisplayName("Product Description")]
        public string? ProductDescription { get; set; }

        [DisplayName("Product Condition")]
        public string? ProductCondition { get; set; }

        //[Required]
        public string? ProductTags { get; set; }
        
        [DisplayName("Upload time")]
        public DateTime ProductUploadTime { get; set; } = DateTime.Now;

        public string ProductSellerEmail { get; set; }
    }
}
