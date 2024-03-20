using DemoSalesApp.Data;
using DemoSalesApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Text.Json;

namespace DemoSalesApp.Controllers
{
    public class ProductController : Controller
    {
        private SalesAppDbContext _db;
        private TagDbContext _tagdb;

        public ProductController(SalesAppDbContext db, TagDbContext tagdb)
        {
            this._db = db;
            _tagdb = tagdb;
        }

        public IActionResult Index()
        {
            IEnumerable<Product> objProductList = _db.Products.ToList();
            return View(objProductList);
        }

        public IActionResult ViewItem(int id)
        {
            var p = _db.Products.FirstOrDefault(p => p.ProductId == id);
            
            return View(p);
        }

        // GET
        public IActionResult SellProduct()
        {
            var categoryTags = _tagdb.CategoryTags.ToList();
            var subCategoryTags = _tagdb.SubCategoryTags.ToList();
            var specTags = _tagdb.SpecTags.ToList();
            var model = new SellProductViewModel();

            model.Tags = new List<CategoryTag>();
            model.SubTags = new List<SubCategoryTag>();
            model.SpecTags = new List<SpecTag>();

            foreach (var tag in categoryTags) 
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

            var jsonModel = JsonSerializer.Serialize(model);
            ViewBag.MyModel = jsonModel;

            return View();
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SellProduct(SellProductViewModel obj)
        {
            var selectedTag = obj.SelectedTagId;
            var selectedSubTag = obj.SelectedSubTagId;
            var selectedSpecTag = obj.SelectedSpecTagId;
            string tagCode = $"{selectedTag};{selectedSubTag};{selectedSpecTag}";

            Product p = new Product()
            {
                ProductName = obj.Product.ProductName,
                ProductPicUrl= obj.Product.ProductPicUrl,
                ProductPrice = obj.Product.ProductPrice,
                ProductCondition = obj.Product.ProductCondition,
                ProductDescription = obj.Product.ProductDescription,
                ProductSellerEmail = obj.Product.ProductSellerEmail,
                ProductTags = tagCode
            };

            _db.Products.Add(p);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
