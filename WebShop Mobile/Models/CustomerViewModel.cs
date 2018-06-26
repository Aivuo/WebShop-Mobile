using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebShop_Mobile.Models
{
    public class CustomerViewModel
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public string UserConnectionId { get; set; }
        public string Email { get; set; }

        public CustomerViewModel(TestPerson testPerson, ApplicationUser applicationUser)
        {
            Name = testPerson.Name;
            Id = testPerson.Id;
            UserConnectionId = testPerson.UserConnectionId;
            Email = applicationUser.Email;

        }
    }
}