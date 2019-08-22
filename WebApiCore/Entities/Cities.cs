using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiCore.Entities
{
    public class Cities
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(64)]
        public string Cit_Name { get; set; }
        
    }
}
