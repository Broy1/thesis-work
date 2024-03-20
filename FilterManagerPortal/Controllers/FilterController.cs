using DemoSalesApp.Data;
using DemoSalesApp.Models;
using FilterManagerPortal.Areas.Identity.Data;
using FilterManagerPortal.Data;
using FilterManagerPortal.Models;
using FilterManagerPortal.Models.Viewmodels;
using FilterManagerPortal.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace FilterManagerPortal.Controllers
{
    public class FilterController : Controller
    {
        private UserManager<FimaUser> _userManager;
        private readonly IFimaRepo _fimaRepo;
        private readonly IScanLogic _scanLogic;

        public FilterController(UserManager<FimaUser> userManager, IFimaRepo repo, IScanLogic scanLogic)
        {
            _userManager = userManager;
            _fimaRepo = repo;
            _scanLogic = scanLogic;
        }

        // GET
        public IActionResult CreateFilter()
        {
            var model = _scanLogic.SetupCreateFilterVm();

            var jsonModel = JsonSerializer.Serialize(model);
            ViewBag.MyModel = jsonModel;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateFilter(FiltersViewModel obj)
        {
            var selectedTag = obj.SelectedTagId;
            var selectedSubTag = obj.SelectedSubTagId;
            var selectedSpecTag = obj.SelectedSpecTagId;
            string tagCode = $"{selectedTag};{selectedSubTag};{selectedSpecTag}";
            var user = await _userManager.GetUserAsync(User);

            Filter f = new Filter()
            {
                FilterName = obj.Filter.FilterName,
                FilterPrice = obj.Filter.FilterPrice,
                Tags = tagCode,
                FimaUser = user
            };

            // after creating a filter check the shopdb right away
            _scanLogic.ScanShopDbForEmailSend(user,tagCode,obj.Filter.FilterPrice);
            _fimaRepo.CreateFilter(f);
            _fimaRepo.SaveFimaDbChanges();

            return RedirectToAction("FilterList","Start");
        }

        // GET
        public IActionResult EditFilter(int id)
        {
            var f = _fimaRepo.GetFilterById(id);

            return View(f);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditFilter(Filter filter)
        {
            var user = await _userManager.GetUserAsync(User);
            filter.FimaUser = user;

            _fimaRepo.UpdateFilter(filter);
            _fimaRepo.SaveFimaDbChanges();

            return RedirectToAction("FilterList", "Start");
        }

        // GET
        public IActionResult DeleteFilter(int id)
        {
            var f = _fimaRepo.GetFilterById(id);

            return View(f);
        }

        [HttpPost,ActionName("DeleteFilter")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteFilterPost(int id)
        {
            var obj = _fimaRepo.GetFilterById(id);
            if (obj == null)
            {
                NotFound();
            }

            _fimaRepo.DeleteFilter(obj);
            _fimaRepo.SaveFimaDbChanges();

            return RedirectToAction("FilterList", "Start");
        }

        // GET
        public IActionResult DeleteFilterAdmin(int id)
        {
            var f = _fimaRepo.GetFilterById(id);

            return View(f);
        }

        [HttpPost, ActionName("DeleteFilterAdmin")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteFilterPostAdmin(int id)
        {
            var obj = _fimaRepo.GetFilterById(id);
            if (obj == null)
            {
                NotFound();
            }
            _fimaRepo.DeleteFilter(obj);
            _fimaRepo.SaveFimaDbChanges();

            return RedirectToAction("AdminPage", "Start");
        }

        [HttpPost]
        // used for changing e-mail settings
        public async Task<IActionResult> UpdateUser(EmailSettingsViewModel model)
        {
            var user = await _userManager.GetUserAsync(User);
            var userb = _fimaRepo.GetUserById(user.Id);

            if (userb == null)
            {
                return NotFound();
            }

            userb.SendNotificationEmailToUser = model.SendEmail;
            userb.SendEmailToSeller = model.SendEmailToSeller;
            userb.EmailText= model.EmailText;

            _fimaRepo.SaveFimaDbChanges();

            return RedirectToAction("FilterList", "Start");
        }
    }
}
