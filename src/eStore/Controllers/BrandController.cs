using Microsoft.AspNet.Mvc;
using eStore.Models;
using eStore.ViewModels;
using Microsoft.AspNet.Http;
using System.Collections.Generic;
using System;
using eStore.Utils;

namespace ASPNetExercises.Controllers
{
    public class BrandController : Controller
    {
        AppDbContext _db;
        public BrandController(AppDbContext context)
        {
            _db = context;
        }
        public IActionResult Index()
        {
            BrandViewModel vm = new BrandViewModel();
            // only build the catalogue once
            if (HttpContext.Session.GetObject<List<Brand>>(SessionVars.Brands) == null)
            {
                try
                {
                    BrandModel brandModel = new BrandModel(_db);
                    // now load the brands
                    List<Brand> brands = brandModel.GetAll();
                    HttpContext.Session.SetObject(SessionVars.Brands, brands);
                    vm.SetBrands(HttpContext.Session.GetObject<List<Brand>>(SessionVars.Brands));
                }
                catch (Exception ex)
                {
                    ViewBag.Message = "Catalogue Problem - " + ex.Message;
                }
            }
            else
            {
                vm.SetBrands(HttpContext.Session.GetObject<List<Brand>>(SessionVars.Brands));
            }
            return SelectBrand (vm);
        }

        public IActionResult SelectBrand(BrandViewModel vm)
        {
            BrandModel brandModel = new BrandModel(_db);
            ProductModel prodModel = new ProductModel(_db);
            List<Product> products = prodModel.GetAllByBrand(vm.BrandId);
            List<ProductViewModel> vms = new List<ProductViewModel>();

            if (products.Count == 0)
            {
                products = prodModel.GetAll();
            }

            if (products.Count > 0)
            {
                foreach (Product prod in products)
                {
                    ProductViewModel mvm = new ProductViewModel();
                    mvm.Qty = 0; //Not sure if this was used to store number in cart
                    mvm.BrandId = prod.BrandId;
                    mvm.BrandName = brandModel.GetName(prod.BrandId);
                    mvm.Description = prod.Description;
                    mvm.Id = prod.Id;
                    mvm.CostPrice = prod.CostPrice;
                    mvm.MSRP = prod.MSRP;
                    mvm.ProductName = prod.ProductName;
                    mvm.GraphicName = prod.GraphicName;
                    mvm.QtyOnHand = prod.QtyOnHand;
                    mvm.QtyOnBackOrder = prod.QtyOnBackOrder;
                    vms.Add(mvm);
                }
                ProductViewModel[] myCat = vms.ToArray();
                HttpContext.Session.SetObject(SessionVars.Catalogue, myCat);
            }

            vm.SetBrands(HttpContext.Session.GetObject<List<Brand>>(SessionVars.Brands));
            return View("Index", vm);
        }

        [HttpPost]
        public ActionResult SelectItem(BrandViewModel vm)
        {
            Dictionary<string, object> cart;
            if (HttpContext.Session.GetObject<Dictionary<String, Object>>(SessionVars.Cart) == null)
            {
                cart = new Dictionary<string, object>();
            }
            else
            {
                cart = HttpContext.Session.GetObject<Dictionary<string, object>>(SessionVars.Cart);
            }
            ProductViewModel[] cat = HttpContext.Session.GetObject<ProductViewModel[]>(SessionVars.Catalogue);
            String retMsg = "";
            foreach (ProductViewModel prod in cat)
            {
                if (prod.Id == vm.Id)
                {
                    if (vm.Qty > 0) // update only selected item
                    {
                        prod.Qty = vm.Qty;
                        retMsg = vm.Qty + " - item(s) Added!";
                        cart[prod.Id] = prod;
                    }
                    else
                    {
                        prod.Qty = 0;
                        cart.Remove(prod.Id);
                        retMsg = "item(s) Removed!";
                    }

                    if (vm.BrandId != 0) vm.BrandId = prod.BrandId;

                    break;
                }
            }
            ViewBag.AddMessage = retMsg;
            HttpContext.Session.SetObject(SessionVars.Cart, cart);
            vm.SetBrands(HttpContext.Session.GetObject<List<Brand>>(SessionVars.Brands));
            return View("Index", vm);
        }
    }
}
