using FilterManagerPortal.Areas.Identity.Data;

namespace FilterManagerPortal.Models.Viewmodels
{
    public class AdminViewModel
    {
        public ICollection<FimaUser> fimaUsers { get; set; }

        public Dictionary<string, List<Filter>> userFilters { get; set; }

        public string selectedUserId { get; set; }

    }
}
