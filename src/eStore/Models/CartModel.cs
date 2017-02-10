using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Data.Entity;
using eStore.ViewModels;
using eStore.Models;

namespace eStore.Models
{
    public class CartModel
    {
        private AppDbContext _db;
        public CartModel(AppDbContext ctx)
        {
            _db = ctx;
        }
        public int AddOrder(Dictionary<string, object> items, string user)
        {
            int orderId = -1;
            using (_db)
            {
                // we need a transaction as multiple entities involved
                using (var _trans = _db.Database.BeginTransaction())
                {
                    try
                    {
                        Orders order = new Orders();
                        order.UserId = user;
                        order.DateCreated = System.DateTime.Now;
                        order.OrderAmount = 0;
                        // calculate the totals and then add the tray row to the table
                        foreach (var key in items.Keys)
                        {
                            ProductViewModel item = JsonConvert.DeserializeObject<ProductViewModel>(Convert.ToString(items[key]));
                            if (item.Qty > 0)
                            {
                                order.OrderAmount += item.MSRP * item.Qty;
                            }
                        }
                        _db.Orders.Add(order);
                        _db.SaveChanges();
                        // then add each item to the trayitems table
                        foreach (var key in items.Keys)
                        {
                            ProductViewModel item = JsonConvert.DeserializeObject<ProductViewModel>(Convert.ToString(items[key]));
                            if (item.Qty > 0)
                            {
                                OrderLineItems line = new OrderLineItems();

                                //Load the updated data into a product item
                                Product prod = _db.Products.Where(p => p.Id == item.Id).FirstOrDefault();

                                if (item.QtyOnHand > item.Qty) // enough stock
                                {
                                    //Quantities
                                    prod.QtyOnHand = item.QtyOnHand - item.Qty;
                                    line.QtyOrdered = item.Qty;
                                    line.QtySold = item.Qty;
                                }
                                else // not enough stock
                                {
                                    //Quantities
                                    line.QtyBackOrdered = item.Qty - item.QtyOnHand;
                                    line.QtyOrdered = item.Qty;
                                    line.QtySold = line.QtyOrdered - line.QtyBackOrdered;

                                    prod.QtyOnBackOrder = item.QtyOnBackOrder + (item.Qty - item.QtyOnHand);
                                    prod.QtyOnHand = 0;
                                }

                                //Others
                                line.SellingPrice = item.MSRP;
                                line.OrderId = order.Id;
                                line.ProductId = item.Id;

                                _db.OrderLineItems.Add(line);
                                _db.Products.Update(prod);
                                _db.SaveChanges();
                            }
                        }
                        // test trans by uncommenting out these 3 lines
                        //int x = 1;
                        //int y = 0;
                        //x = x / y;
                        _trans.Commit();
                        orderId = order.Id;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        _trans.Rollback();
                    }
                }
            }
            return orderId;
        }

        public List<Orders> GetOrders(string uid)
        {
            try
            {
                return _db.Orders.Where(t => t.UserId == uid).ToList();
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                return null;
            }
        }

        public List<OrderViewModel> GetOrderDetails(int oid, string uid)
        {
            List<OrderViewModel> allDetails = new List<OrderViewModel>();
            // LINQ way of doing INNER JOINS
            var results = from order in _db.Set<Orders>()
                          join orderItem in _db.Set<OrderLineItems>() on order.Id equals orderItem.OrderId
                          join product in _db.Set<Product>() on orderItem.ProductId equals product.Id
                          where (order.UserId == uid && order.Id == oid)
                          select new OrderViewModel
                          {
                              ProductId = product.Id,
                              ProductName = product.ProductName,
                              OrderId = order.Id,
                              UserId = uid,
                              SoldPrice = product.MSRP,
                              QtyBackOrdered = orderItem.QtyBackOrdered,
                              QtySold = orderItem.QtySold,
                              QtyOrdered = orderItem.QtyOrdered,
                              DateCreated = order.DateCreated.ToString("yyyy/MM/dd - hh:mm tt")
                          };
            allDetails = results.ToList<OrderViewModel>();
            return allDetails;
        }
    }
}