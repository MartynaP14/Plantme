using Microsoft.AspNetCore.Mvc;
using Plantme.Data;
using Plantme.Models;

namespace Plantme.Controllers
{
    public class BasketController : Controller
    {


        private readonly ApplicationDbContext _context;

        public BasketController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()

        {
            List<BasketItem> basket = HttpContext.Session.GetJson<List<BasketItem>>("Basket") ?? new List<BasketItem>();

            ShoppingBasket BasketV = new()
            {
                BasketItems = basket,
                TotalAmount = (decimal)basket.Sum(x =>x.ProductQuantity * x.ProductPrice)
            };

            return View(BasketV);
        }

        public async Task<IActionResult> Add(int id)

        {
            Product product = await _context.Products.FindAsync(id);

            List<BasketItem> basket = HttpContext.Session.GetJson<List<BasketItem>>("Basket") ?? new List<BasketItem>();

            BasketItem basketitem = basket.Where(c => c.ProductId == id).FirstOrDefault();

            if (basketitem == null)
            {
                basket.Add(new BasketItem(product));
            }
            else
            {
                basketitem.ProductQuantity += 1;
            }

            HttpContext.Session.SetJson("Basket", basket);

            TempData["Success"] = "Product was added to your basket";

            return Redirect(Request.Headers["Referer"].ToString());
        }

    }
}
