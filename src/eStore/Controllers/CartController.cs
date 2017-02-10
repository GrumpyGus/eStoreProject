using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Http;
using eStore.Utils;
using eStore.Models;
using System.Collections.Generic;
using System;

namespace eStore.Controllers
{
    public class CartController : Controller
    {
        AppDbContext _db;
        public CartController(AppDbContext context)
        {
            _db = context;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }
        public ActionResult ClearCart()
        {
            HttpContext.Session.Remove(SessionVars.Cart); // clear out current tray
            HttpContext.Session.SetString(SessionVars.Message, "Cart Cleared"); // clear out current cart once order has been placed
            return Redirect("/Home");
        }

        // Add the cart, pass the session variable info to the db
        public ActionResult AddCart()
        {
            // they can't add a Tray if they're not logged on
            if (HttpContext.Session.GetString(SessionVars.User) == null)
            {
                return Redirect("/Login");
            }
            CartModel model = new CartModel(_db);
            int retVal = -1;
            string retMessage = "";
            try
            {
                Dictionary<string, object> cartItems = HttpContext.Session.GetObject<Dictionary<string, object>>(SessionVars.Cart);
                retVal = model.AddOrder(cartItems, HttpContext.Session.GetString(SessionVars.User));
                if (retVal > 0) // cart Added
                {
                    retMessage = "Order " + retVal + " Created!";
                }
                else // problem
                {
                    retMessage = "Order not added, try again later";
                }
            }
            catch (Exception ex) // big problem
            {
                retMessage = "Order was not created, try again later! - " + ex.Message;
            }
            HttpContext.Session.Remove(SessionVars.Cart); // clear out current tray once persisted
            HttpContext.Session.SetString(SessionVars.Message, retMessage);
            return Redirect("/Home");
        }

        public IActionResult List()
        {
            if (HttpContext.Session.GetString(SessionVars.User) == null)
            {
                return Redirect("/Login");
            }
            return View("List");
        }

        [Route("[action]")]
        public IActionResult GetCarts()
        {
            CartModel model = new CartModel(_db);
            return Ok(model.GetOrders(HttpContext.Session.GetString(SessionVars.User)));
        }

        [Route("[action]/{tid:int}")]
        public IActionResult GetOrderDetails(int tid)
        {
            CartModel model = new CartModel(_db);
            return Ok(model.GetOrderDetails(tid, HttpContext.Session.GetString(SessionVars.User)));
        }

    }

}
