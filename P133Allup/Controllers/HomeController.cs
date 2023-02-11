using Microsoft.AspNetCore.Mvc;
using P133Allup.DataAccessLayer;

namespace P133Allup.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;
        public HomeController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        } 
        public IActionResult Search(string searchedProduct)
        {
            if (string.IsNullOrEmpty(searchedProduct.Trim()))
            {
                return NoContent();
            }
            var product=_context.Products.Where(x=>x.Title.Contains(searchedProduct)).ToList();
            return PartialView("_SharedPartialView", product);
        }
    }
}
