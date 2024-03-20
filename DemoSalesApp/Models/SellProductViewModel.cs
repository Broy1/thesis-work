using Microsoft.AspNetCore.Mvc.Rendering;

namespace DemoSalesApp.Models
{
    public class SellProductViewModel
    {
        public Product Product { get; set; }

        public List<CategoryTag> Tags { get; set; }
        public List<SubCategoryTag> SubTags { get; set; }
        public List<SpecTag> SpecTags { get; set; }

        public int SelectedTagId { get; set; }
        public int SelectedSubTagId { get; set; }
        public int SelectedSpecTagId { get; set; }

    }
}
