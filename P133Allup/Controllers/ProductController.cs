using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using P133Allup.DataAccessLayer;

namespace P133Allup.Controllers
{
    public class ProductController : Controller
    {
        private readonly AppDbContext _context;
        public ProductController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        } 
        public async Task<IActionResult> Detail(int id)
        {
            var product = await _context.Products.SingleOrDefaultAsync(x => x.Id == id);
            return View(product);
        }
    }
}
