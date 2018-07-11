using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebShop_Mobile.Models
{
    public class IndexUserViewModel
    {
            public IndexViewModel indexViewModel;
            public UserViewModel userViewModel;

            public IndexUserViewModel(IndexViewModel indexViewModel, UserViewModel userViewModel)
            {
                this.indexViewModel = indexViewModel;
                this.userViewModel = userViewModel;
            }
    }
}