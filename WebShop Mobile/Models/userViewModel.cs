using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebShop_Mobile.Models
{
    public class UserViewModel
    {

        [Display(Name = "Username")]
        public string UserName { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Display(Name = "Email confirmed")]
        public bool EmailConfirmed { get; set; }

        [Display(Name = "User roles")]
        public List<string> UserRoles { get; set; }

        [Display(Name = "Phonenumber")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Phonenumber confirmed")]
        public bool PhoneNumberConfirmed { get; set; }

        [StringLength(50)]
        [Display(Name = "Firstname")]
        public string Firstname { get; set; }

        [StringLength(50)]
        [Display(Name = "Lastname")]
        public string Lastname { get; set; }

        [Display(Name = "Billing adress")]
        public string BillingAdress { get; set; }
        [Display(Name = "Billing zip")]
        public string BillingZip { get; set; }
        [Display(Name = "Billing city")]
        public string BillingCity { get; set; }

        [Display(Name = "Delivery adress")]
        public string DeliveryAdress { get; set; }
        [Display(Name = "Delivery zip")]
        public string DeliveryZip { get; set; }
        [Display(Name = "Delivery city")]
        public string DeliveryCity { get; set; }

        [Display(Name = "Orders")]
        public List<Order> Orders { get; set; }
        [Display(Name = "Lockout enabled")]
        public bool LockoutEnabled { get; set; }

        public UserViewModel()
        {

        }

        public UserViewModel(ApplicationUser user, Customer customer)
        {
            UserName = user.UserName;

            Email = user.Email;
            EmailConfirmed = user.EmailConfirmed;

            PhoneNumber = user.PhoneNumber;
            PhoneNumberConfirmed = user.PhoneNumberConfirmed;

            LockoutEnabled = user.LockoutEnabled;

            if (user.Roles.Count > 0)
            {
                ApplicationDbContext appDb = new ApplicationDbContext();
                var existingRoles = appDb.Roles.ToList();
                UserRoles = new List<string>();

                    foreach (var item in existingRoles)
                    {
                        foreach (var item2 in user.Roles)
                        {
                            if (item.Id == item2.RoleId)
                            {
                                UserRoles.Add(item.Name);
                            }
                        }
                    } 
            }

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