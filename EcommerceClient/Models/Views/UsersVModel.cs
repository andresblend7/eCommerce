using EcommerceClient.Models.Structure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EcommerceClient.Models.Views
{
    public class UsersVModel
    {
        public UsersVModel()
        {
            this.Users = new List<User>();
        }
        public List<User> Users { get; set; }
    }
}