using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace DemoSalesApp.Models
{
    public class SpecTag
    {
        [Key]
        public int SpecTagId { get; set; }

        public string SpecTagName { get; set; }

        [Display(Name = "SubCategoryTag")]
        public int SubCategoryTagId { get; set; }

        [ForeignKey("SubCategoryTagId")]
        public virtual SubCategoryTag? SubCategoryTag { get; set; }
    }
}
