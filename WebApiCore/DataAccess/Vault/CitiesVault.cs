using EcommerceClient.Models.Structure;
using System.Collections.Generic;
using WebApiCore.Entities;

namespace WebApiCore.DataAccess.Vault
{
    public static class CitiesVault
    {
       
        /// <summary>
        /// Obtiene las ciudades Iniciales para la DB
        /// </summary>
        /// <returns></returns>
        public static List<Dic_Cities> GetCities() {

        string[] cities = {
            "Bogotá",
            "Arauca",
            "Armenia",
            "Barranquilla",
            "Cali",
            "Cartagena",
            "Cúcuta",
            "Florencia",
            "Guaviare",
            "Ibagué",
            "Inírida",
            "Leticia",
            "Manizales",
            "Medellín",
            "Mitú",
            "Mocoa",
            "Montería",
            "Neiva",
            "Pasto",
            "Pereira",
            "Popayán",
            "Puerto Carreño",
            "Quibdó",
            "Riohacha",
            "San Andrés",
            "Santa Marta",
            "Sincelejo",
            "Tunja",
            "Valledupar",
            "Villavicencio",
            "Yopal"
        };

            List<Dic_Cities>  citiesList = new List<Dic_Cities>();

            foreach (var ct in cities) 
                citiesList.Add(new Dic_Cities()
                {
                    Cit_Name = ct
                });

            return citiesList;
        }

    }
}
