using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace DemoSalesApp.Models
{
    public class SubCategoryTag
    {
        [Key]
        public int SubCategoryTagId { get; set; }

        public string SubCategoryTagName { get; set; }

        [Display(Name = "CategoryTag")]
        public int CategoryTagId { get; set; }

        [ForeignKey("CategoryTagId")]
        public virtual CategoryTag? CategoryTag { get; set; }
    }
}
