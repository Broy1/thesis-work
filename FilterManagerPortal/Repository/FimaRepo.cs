using DemoSalesApp.Data;
using DemoSalesApp.Models;
using FilterManagerPortal.Areas.Identity.Data;
using FilterManagerPortal.Data;
using FilterManagerPortal.Models;
using FilterManagerPortal.Models.Viewmodels;
using FimaService.FimaEmailService;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.IdentityModel.Logging;

namespace FilterManagerPortal.Repository
{
    public class FimaRepo : IFimaRepo
    {

        private readonly FimaDbContext _fimaDbContext;
        private readonly SalesAppDbContext _salesAppDbContext;
        private readonly TagsDbContext _tagDbContext;

        public FimaRepo(FimaDbContext DbContext, SalesAppDbContext salesAppDbContext, TagsDbContext tagdbContext, IFimaEmailService emailService)
        {
            _fimaDbContext = DbContext;
            _salesAppDbContext = salesAppDbContext;
            _tagDbContext = tagdbContext;
        }

        public List<Product> GetProducts()
        {
            return _salesAppDbContext.Products.ToList();
        }

        public IQueryable<Filter> GetFiltersFromFimaDb()
        {
            return _fimaDbContext.Filters;
        }

        public FimaUser GetUserById(string id)
        {
            var user = _fimaDbContext.Users.First(u => u.Id == id);
            return user;
        }

        public List<int> GetFilterIdsFromShop(string tags)
        {
            List<int> ids = new List<int>();

            // check the shop db items for tags
            foreach (var product in _salesAppDbContext.Products)
            {
                if (product.ProductTags == tags)
                {
                    ids.Add(product.ProductId);
                }
            }

            return ids;
        }

        public IQueryable<Filter> GetFilters(FimaUser fimaUser)
        {
            return _fimaDbContext.Filters.Where(u => u.FimaUser.Id == fimaUser.Id);
        }

        public IQueryable<FimaUser> GetById(string id)
        {
            return _fimaDbContext.Users.Where(u => u.Id == id);
        }

        public ICollection<FimaUser> GetAllUsers()
        {
            ICollection<FimaUser> users= new List<FimaUser>();

            foreach (var user in _fimaDbContext.Users)
            {
                users.Add(user);
            }
            return users;
        }

        public Filter GetFilterById(int id)
        {
            var f = _fimaDbContext.Filters.FirstOrDefault(f => f.FilterId == id);
            return f;
        }

        public void DeleteFilter(Filter? obj)
        {
            _fimaDbContext.Filters.Remove(obj);
        }

        public void SaveFimaDbChanges()
        {
            _fimaDbContext.SaveChanges();
        }

        public void UpdateFilter(Filter filter)
        {
            _fimaDbContext.Update(filter);
        }

        public void CreateFilter(Filter f)
        {
            _fimaDbContext.Add(f);
        }

        public List<CategoryTag> GetCategoryList()
        {
            return _tagDbContext.CategoryTags.ToList();
        }

        public List<SubCategoryTag> GetSubCategoryList()
        {
            return _tagDbContext.SubCategoryTags.ToList();
        }

        public List<SpecTag> GetSpecList()
        {
            return _tagDbContext.SpecTags.ToList();
        }
    }
}
