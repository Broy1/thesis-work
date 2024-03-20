using DemoSalesApp.Models;
using FilterManagerPortal.Areas.Identity.Data;
using FilterManagerPortal.Models.Viewmodels;

namespace FilterManagerPortal.Repository
{
    public interface IScanLogic
    {
        public void ScanShopDbForEmailSend(FimaUser user, string tags, int price);

        public void ScanDbForAllFilters();

        public void NotifySeller(FimaUser user, Product p);

        public FiltersViewModel SetupCreateFilterVm();

        public AdminViewModel SetupAdminVmData(string selectedUserId);
    }
}