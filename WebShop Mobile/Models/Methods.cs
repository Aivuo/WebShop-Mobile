using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebShop_Mobile.Models
{
    public static class Methods
    {
        public static List<CellPhone> SearchProducts(string ReleaseYear, params string[] Developers)
        {

            WebShopMobileDb Db = new WebShopMobileDb();

            List<CellPhone> model = new List<CellPhone>();

            if (ReleaseYear != null)
            {
                model = Db.CellPhones.Where(x => x.Discontinued != true && x.ReleaseYear == ReleaseYear)
                                   .OrderBy(x => x.ReleaseYear)
                                   .ThenBy(x => x.Developer)
                                   .ThenBy(x => x.Name)
                                   .ToList();

            } else if (Developers != null)
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
            else
            {
                model = Db.CellPhones.Where(x => x.Discontinued != true)
                                     .OrderBy(x => x.Developer)
                                     .ThenBy(x => x.Name).ToList();
            }

            return model;
        }

    }
}