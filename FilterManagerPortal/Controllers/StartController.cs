using DemoSalesApp.Data;
using FilterManagerPortal.Areas.Identity.Data;
using FilterManagerPortal.Models;
using FilterManagerPortal.Models.Viewmodels;
using FilterManagerPortal.Repository;
using FimaService.FimaEmailService;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using System.Diagnostics;

namespace FilterManagerPortal.Controllers
{
    public class StartController : Controller
    {
        private readonly UserManager<FimaUser> _userManager;
        private readonly IFimaRepo _fimaRepo;
        private readonly IScanLogic _scanLogic;

        public StartController(UserManager<FimaUser> userManager, IFimaRepo repo, IScanLogic scanLogic)
        {
            _userManager = userManager;
            _fimaRepo = repo;
            _scanLogic = scanLogic;
        }

        public IActionResult Start()
        {
            return View();
        }

        public async Task<IActionResult> FilterList() 
        {
            var user = await _userManager.GetUserAsync(User);

            if (user == null)
            {
                // If the user is not logged in, redirect to the login page
                return RedirectToAction("Login", "Account");
            }

            var filters = _fimaRepo.GetFilters(user);

            return View(filters);
        }

        public async Task<IActionResult> EmailSettingsList()
        {
            var user = await _userManager.GetUserAsync(User);

            EmailSettingsViewModel vm = new EmailSettingsViewModel();
            vm.SendEmail = user.SendNotificationEmailToUser;
            vm.SendEmailToSeller = user.SendEmailToSeller;
            vm.EmailText = user.EmailText;

            return View(vm);
        }

        public async Task<IActionResult> AdminPage(string selectedUserId)
        {
            var user = await _userManager.GetUserAsync(User);

            if (user.IsUserAdmin)
            {
                var vm = _scanLogic.SetupAdminVmData(selectedUserId);
                return View(vm);
            }
            else
            {
                ViewBag.ErrorMessage = "You are not authorized to access this section.";
                return RedirectToAction("Start", "Start");
            }
        }
    }
}
