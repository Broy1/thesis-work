using DemoSalesApp.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FilterManagerPortal.Models.Viewmodels
{
    public class FiltersViewModel
    {
        public Filter Filter { get; set; }

        public List<CategoryTag>? Tags { get; set; }
        public List<SubCategoryTag>? SubTags { get; set; }
        public List<SpecTag>? SpecTags { get; set; }

        public int SelectedTagId { get; set; }
        public int SelectedSubTagId { get; set; }
        public int SelectedSpecTagId { get; set; }
    }
}
