using DemoSalesApp.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using FilterManagerPortal.Areas.Identity.Data;

namespace FilterManagerPortal.Models
{
    public class Filter
    {
        [Key]
        public int FilterId { get; set; }

        [Required]
        [DisplayName("Filter name")]
        public string? FilterName { get; set; }

        [Required]
        [DisplayName("Price")]
        public int FilterPrice { get; set; }

        [DisplayName("Tags")]
        public string? Tags { get; set; }

        [ForeignKey("UserId")]
        public virtual FimaUser? FimaUser { get; set; }
    }
}
