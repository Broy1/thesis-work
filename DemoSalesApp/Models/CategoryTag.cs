using System.ComponentModel.DataAnnotations;

namespace DemoSalesApp.Models
{
    public class CategoryTag
    {
        [Key]
        public int CategoryTagId { get; set; }

        public string CategoryName { get; set; }
    }
}
