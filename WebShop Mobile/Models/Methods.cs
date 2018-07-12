using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebShop_Mobile.Models
{
    public static class Methods
    {

        public static List<CellPhone> SearchProducts(string ReleaseYear, string searchString, params string[] Developers)
        {
            WebShopMobileDb Db = new WebShopMobileDb();
            List<CellPhone> model = new List<CellPhone>();

            if (ReleaseYear != null && ReleaseYear != "")
            {
                model = Db.CellPhones.Where(x => x.Discontinued != true && x.ReleaseYear == ReleaseYear)
                                   .OrderBy(x => x.ReleaseYear)
                                   .ThenBy(x => x.Developer)
                                   .ThenBy(x => x.Name)
                                   .ToList();
            }
            else if (Developers != null)
            {
                var cellPhones = Db.CellPhones.Where(x => x.Discontinued != true).ToList();
                foreach (var item in Developers)
                {
                    var temp = cellPhones.Where(x => x.Developer == item).ToList();
                    foreach (var item2 in temp)
                    {
                        model.Add(item2);
                    }
                }

                model.OrderBy(x => x.Developer)
                     .ThenBy(x => x.Name);
            }
            else if (searchString != null)
            {
                var cellList = Db.CellPhones.Where(x => x.Discontinued != true).ToList();

                model = cellList.Where(x => x.Name.StartsWith(searchString, StringComparison.OrdinalIgnoreCase) || x.Developer.StartsWith(searchString, StringComparison.OrdinalIgnoreCase))
                                .OrderBy(x => x.Name).ToList();
            }
            else
            {
                model = Db.CellPhones.Where(x => x.Discontinued != true)
                                     .OrderBy(x => x.Developer)
                                     .ThenBy(x => x.Name).ToList();
            }

            return model;
        }

        public static List<string> CategoriesResult(string Category)
        {
            WebShopMobileDb Db = new WebShopMobileDb();

            var model = new List<string>();

            if (Category == "Developers")
            {
                var developers = Db.CellPhones.Select(x => x.Developer)
                                              .Distinct().ToList();
                foreach (var item in developers)
                {
                    model.Add(item);
                }
                model.Sort();
            }
            else
            {
                var releaseYears = Db.CellPhones.Select(x => x.ReleaseYear)
                                                .Distinct().ToList();
                foreach (var item in releaseYears)
                {
                    model.Add(item);
                }
                model.Sort();
            }
            model.Add(Category);

            return model;
        }

        public static void AddtoCart(int cellId, string userName)
        {
            WebShopMobileDb Db = new WebShopMobileDb();
            ApplicationDbContext AppDb = new ApplicationDbContext();

            var cellPhone = Db.CellPhones.FirstOrDefault(x => x.Id == cellId);
            var user = AppDb.Users.FirstOrDefault(x => x.Email == userName);
            var customer = Db.Customers.Include("Orders")
                                       .FirstOrDefault(x => x.EmailAdress == user.Email);

            var order = new Order();

            if (customer.Orders == null || customer.Orders.FirstOrDefault(x => x.Processed == false) == null)
            {
                order = new Order
                {
                    CustomerId = customer.Id,
                    Customer = customer,
                    OrderDate = DateTime.Now.ToShortDateString(),
                    Processed = false
                };
                customer.Orders.Add(order);
            }
            else
            {
                //order = customer.Orders.FirstOrDefault(x => x.Processed == false);
                order = Db.Orders.Include("OrderRows").FirstOrDefault(x => x.CustomerId == customer.Id && x.Processed == false);
            }

            var orderRow = new OrderRow
            {
                CellPhoneId = cellPhone.Id,
                CellPhone = cellPhone,
                Price = cellPhone.Price,
                Date = order.OrderDate,
                OrderId = order.Id,
                Order = order
            };

            order.OrderRows.Add(orderRow);

            Db.SaveChanges();
        }

    }
}