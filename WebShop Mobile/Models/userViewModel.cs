using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebShop_Mobile.Models
{
    public class userViewModel
    {
        public string UserName { get; set; }

        public string Email { get; set; }
        public bool EmailConfirmed { get; set; }

        public string PhoneNumber { get; set; }
        public bool PhoneNumberConfirmed { get; set; }

        public string Firstname { get; set; }
        public string Lastname { get; set; }

        public string BillingAdress { get; set; }
        public string BillingZip { get; set; }
        public string BillingCity { get; set; }

        public string DeliveryAdress { get; set; }
        public string DeliveryZip { get; set; }
        public string DeliveryCity { get; set; }

        public List<Order> Orders { get; set; }
        public bool LockoutEnabled { get; set; }



        public userViewModel(ApplicationUser user, Customer customer)
        {
            UserName = user.UserName;

            Email = user.Email;
            EmailConfirmed = user.EmailConfirmed;

            PhoneNumber = user.PhoneNumber;
            PhoneNumberConfirmed = user.PhoneNumberConfirmed;

            LockoutEnabled = user.LockoutEnabled;

            if (customer != null)
            {
                Firstname = customer.Firstname;
                Lastname = customer.Lastname;

                BillingAdress = customer.BillingAdress;
                BillingCity = customer.BillingCity;
                BillingZip = customer.BillingZip;

                DeliveryAdress = customer.DeliveryAdress;
                DeliveryCity = customer.DeliveryCity;
                DeliveryZip = customer.DeliveryZip;

                PhoneNumber = customer.PhoneNumber;

                Orders = new List<Order>();

                foreach (var item in customer.Orders)
                {
                    Orders.Add(item);
                }
            }
        }
    }
}