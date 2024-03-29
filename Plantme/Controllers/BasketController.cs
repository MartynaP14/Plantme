﻿using Microsoft.AspNetCore.Mvc;
using Plantme.Data;
using Plantme.Models;
using Stripe;

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
            Models.Product product = await _context.Products.FindAsync(id);

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

        [HttpPost]
        public async Task<IActionResult> Create(string stripeToken )
        {
            //var product = _context.GetByID();
            List<long> item_ids = new List<long>();

            List<BasketItem> basket = HttpContext.Session.GetJson<List<BasketItem>>("Basket");

            foreach (BasketItem item in basket)
            {
                item_ids.Add(item.ProductId);
            }

            


            foreach (long id in item_ids)

            {

                var item = await _context.Products.FindAsync((int)id);
                var chargeStripe = new ChargeCreateOptions()
                {
                    Amount = (long) (item.ProductPrice * 100),
                    Currency = "eur",
                    Source = stripeToken,
                    Metadata = new Dictionary<string, string>()
                {
                    {"ProductId", item.ProductId.ToString()},
                    {"ProductName", item.ProductName },

                }

                };
              
                var service = new ChargeService();
                Charge charge = service.Create(chargeStripe);
            }


            //if(charge.Status == "succeeded")
            //{
            //    return View("Pass");
            //}

            return View("Pass");

        }


        public async Task<IActionResult> Decrease(int id)
        {
            List<BasketItem> basket = HttpContext.Session.GetJson<List<BasketItem>>("Basket");

            BasketItem basketitem = basket.Where(c => c.ProductId == id).FirstOrDefault();

            if (basketitem.ProductQuantity > 1)
            {
                --basketitem.ProductQuantity;
            }
            else
            {
                basket.RemoveAll(p => p.ProductId == id);
            }

            if (basket.Count == 0)
            {
                HttpContext.Session.Remove("Basket");
            }
            else
            {
                HttpContext.Session.SetJson("Basket", basket);
            }

            TempData["Success"] = "The product has been removed from your shopping basket";

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Remove(int id)
        {
            List<BasketItem> basket = HttpContext.Session.GetJson<List<BasketItem>>("Basket");

            basket.RemoveAll(p => p.ProductId == id);

            if (basket.Count == 0)
            {
                HttpContext.Session.Remove("Basket");
            }
            else
            {
                HttpContext.Session.SetJson("Basket", basket);
            }

            TempData["Success"] = "The product has been removed from your shopping basket";

            return RedirectToAction("Index");
        }

        public IActionResult Clear()
        {
            HttpContext.Session.Remove("Basket");

            return RedirectToAction("Index");
        }



    }
}
