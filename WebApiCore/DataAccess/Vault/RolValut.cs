using EcommerceClient.Models.Structure;
using System.Collections.Generic;
using WebApiCore.Entities;

namespace WebApiCore.DataAccess.Vault
{
    public static class RolValut
    {
        /// <summary>
        /// Obtiene los roles iniciales par la BD
        /// </summary>
        /// <returns></returns>
        public static List<Dic_Rol> GetRoles()
        {

            string[] roles = {
                "Administrator",
                "User"
            };

            List<Dic_Rol> rolesList = new List<Dic_Rol>();
            foreach (var rol in roles)
                rolesList.Add(new Dic_Rol()
                {
                    Rol_Name = rol,
                    Rol_Status = true,
                    Rol_Description = "Default"
                });

            return rolesList;
        }
    }
}
