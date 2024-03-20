using DemoSalesApp.Data;
using DemoSalesApp.Models;
using FilterManagerPortal.Areas.Identity.Data;
using FilterManagerPortal.Models.Viewmodels;
using FilterManagerPortal.Models;
using Microsoft.EntityFrameworkCore;

namespace FilterManagerPortal.Repository
{
    public interface IFimaRepo
    {
        public Filter GetFilterById(int id);

        public FimaUser GetUserById(string id);

        public ICollection<FimaUser> GetAllUsers();

        public IQueryable<Filter> GetFilters(FimaUser fimaUser);

        public IQueryable<Filter> GetFiltersFromFimaDb();

        public IQueryable<FimaUser> GetById(string id);

        public List<CategoryTag> GetCategoryList();

        public List<int> GetFilterIdsFromShop(string tags);

        public List<SpecTag> GetSpecList();

        public List<SubCategoryTag> GetSubCategoryList();

        public void CreateFilter(Filter f);

        public void DeleteFilter(Filter? obj);

        public void SaveFimaDbChanges();

        public void UpdateFilter(Filter filter);

        public List<Product> GetProducts();
    }
}
