using DemoSalesApp.Models;
using FilterManagerPortal.Areas.Identity.Data;
using FilterManagerPortal.Models;
using FilterManagerPortal.Models.Viewmodels;
using FimaService.FimaEmailService;

namespace FilterManagerPortal.Repository
{
    public class ScanLogic : IScanLogic
    {
        private IFimaEmailService _emailService;
        private IFimaRepo _fimarepo;
        private string _productLink;

        public ScanLogic(IFimaRepo fimarepo, IFimaEmailService emailService)
        {
            _productLink = "https://localhost:7042/Product/ViewItem/";
            _fimarepo = fimarepo;
            _emailService= emailService;
        }

        // this db scan only runs, when a new filter is created
        public void ScanShopDbForEmailSend(FimaUser user, string tags, int price)
        {
            if (user.SendNotificationEmailToUser)
            {
                List<int> productids = _fimarepo.GetFilterIdsFromShop(tags);
                List<Product> products = _fimarepo.GetProducts();
                // send email with each of the available items
                foreach (var item in productids)
                {
                    Product p = products.First(p => p.ProductId == item);
                    if (p.ProductPrice < price)
                    {
                        _productLink += p.ProductId;
                        _emailService.SendEmailToUser(user.Email, p.ProductName, _productLink);
                        NotifySeller(user, p);
                    }
                }
            }
        }

        public void ScanDbForAllFilters()
        {
            var filters = _fimarepo.GetFiltersFromFimaDb();
            var products = _fimarepo.GetProducts();
            var users = _fimarepo.GetAllUsers();

            foreach (var filter in filters)
            {
                foreach (var product in products)
                {
                    if (product.ProductTags == filter.Tags && product.ProductPrice < filter.FilterPrice)
                    {
                        var user = _fimarepo.GetUserById(filter.FimaUser.Id);
                        if (user.SendNotificationEmailToUser) 
                        {
                            _productLink += product.ProductId;
                            _emailService.SendEmailToUser(user.Email, product.ProductName, _productLink);
                            NotifySeller(user, product);
                        }
                    }
                }
            }
        }

        public void NotifySeller(FimaUser user, Product p)
        {
            if (user.SendEmailToSeller && string.IsNullOrEmpty(user.EmailText))
            {
                _emailService.SendEmailToSeller(user.EmailText, p.ProductSellerEmail, p.ProductName);
            }
            else if (string.IsNullOrEmpty(user.EmailText))
            {
                throw new ArgumentNullException("EmailText");
            }
        }

        public FiltersViewModel SetupCreateFilterVm()
        {
            var categoryTags = _fimarepo.GetCategoryList();
            var subCategoryTags = _fimarepo.GetSubCategoryList();
            var specTags = _fimarepo.GetSpecList();

            var model = new FiltersViewModel();

            model.Tags = new List<CategoryTag>();
            model.SubTags = new List<SubCategoryTag>();
            model.SpecTags = new List<SpecTag>();

            foreach (var tag in _fimarepo.GetCategoryList())
            {
                model.Tags.Add(tag);
            }

            foreach (var subtag in subCategoryTags)
            {
                model.SubTags.Add(subtag);
            }

            foreach (var spectag in specTags)
            {
                model.SpecTags.Add(spectag);
            }

            return model;
        }

        public AdminViewModel SetupAdminVmData(string selectedUserId)
        {
            var users = _fimarepo.GetAllUsers();
            var userFilters = new Dictionary<string, List<Filter>>();

            foreach (var item in users)
            {
                var filters = _fimarepo.GetFilters(item);
                List<Filter> filterList = new List<Filter>();
                foreach (var fil in filters)
                {
                    filterList.Add(fil);
                }
                userFilters.Add(item.Id, filterList);
            }

            var vm = new AdminViewModel
            {
                fimaUsers = users,
                userFilters = userFilters,
                selectedUserId = selectedUserId
            };

            return vm;
        }
    }
}
