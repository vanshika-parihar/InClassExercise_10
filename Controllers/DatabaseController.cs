using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InClass_10.Controllers
{
    public class DatabaseController : Controller
    {
        using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using InClass.DataAccess;
using InClass.Models;

namespace InClass.Controllers
    {
        public class DatabaseExampleController : Controller
        {
            public ApplicationDbContext dbContext;

            public DatabaseExampleController(ApplicationDbContext context)
            {
                dbContext = context;
            }

            public IActionResult Index()
            {
                return View();
            }

            public async Task<ViewResult> DatabaseOperations()
            {
                // CREATE operation
                Products MyProduct1 = new Products();
                MyProduct1.ProductId = 1;
                MyProduct1.name = "A";
                MyProduct1.price = 10;

                Products MyProduct2 = new Products();
                MyProduct2.ProductId = 2;
                MyProduct2.name = "B";
                MyProduct2.price = 18;

                Orders MyOrder1 = new Orders();
                MyOrder1.OrderId = 1;
                MyOrder1.billamount = 46.13;

                Orders MyOrder2 = new Orders();
                MyOrder2.OrderId = 2;
                MyOrder2.billamount = 40;

                Orders MyOrder3 = new Orders();
                MyOrder3.OrderId = 3;
                MyOrder3.billamount = 12;


                dbContext.Products.Add(MyProduct1);
                dbContext.Products.Add(MyProduct2);

                dbContext.Orders.Add(MyOrder1);
                dbContext.Orders.Add(MyOrder2);
                dbContext.Orders.Add(MyOrder3);

                dbContext.SaveChanges();

                return View();
            }

            public IActionResult Query1()
            {
                var result1 = from o in dbContext.Ordered_Products
                              where o.ProductsOrdered != null
                              select new
                              {
                                  Order_id = o.OrdersPlaced
                              };
                return View(result1);
            }
            public IActionResult Query2(string givenproduct)
            {
                var result2 = from p in Products
                              join o in Ordered_Products on p.ProductId equals o.ProductsOrdered into match1
                              where p.name == givenproduct
                              group o by o.count
                              select new
                          {
                              productid = match1.ProductId
                              ordername = match1.ordername

                          };
                return View(result2);
            }

        }
    }

}
}
