using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiCore.Entities
{
    public class Rol
    {
        public int Id { get; set; }
        [MaxLength(16)]
        public string Rol_Name { get; set; }
        [MaxLength(128)]
        public string Rol_Description { get; set; }
        public bool Rol_status { get; set; }

    }
}
