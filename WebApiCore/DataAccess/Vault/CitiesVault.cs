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

            //Inicializamos la lista de ciudades
            List<Dic_Cities>  citiesList = new List<Dic_Cities>();

            //Recoremos el array de strings y los attachamos a la entidad de la base de datos
            foreach (var ct in cities) 
                citiesList.Add(new Dic_Cities()
                {
                    Cit_Name = ct
                });

            return citiesList;
        }

    }
}
