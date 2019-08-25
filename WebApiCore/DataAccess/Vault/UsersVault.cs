using EcommerceClient.Models.Structure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiCore.Entities;

namespace WebApiCore.DataAccess.Vault
{
    public static class UsersVault
    {

        public static List<Dic_Users> GetBasicUsers() {
            List<Dic_Users> users = new List<Dic_Users>();


            users.Add(new Dic_Users() {
                   Use_Address = "Calle Wallaby 32 Sidney",
                   Use_CreationDate = DateTime.Now,
                   Use_Email = "email@email.com",
                   Use_FirstName = "Andres",
                   Use_LastName = "Mendoza",
                   Use_HashPassword ="123",
                   Use_Money = 5300000,
                   Use_Phone = "3126549874",
                   Use_RolIdFk = 1,
                   Use_Status = true
            });

            return users;
        }
    }
}
