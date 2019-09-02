using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EcommerceClient.Models.Structure
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        public int Rol { get; set; }

        /// <summary>
        /// Dinero ficticio que tendrá cada usuario
        /// </summary>
        public int Money { get; set; }

        [Required]
        [MaxLength(64)]
        public string FirstName { get; set; }

        [MaxLength(64)]
        public string LastName { get; set; }

        /// <summary>
        /// Email es la llave de acceso a la aplicación.
        /// </summary>
        [Required]
        [EmailAddress]
        [MaxLength(32)]
        public string Email { get; set; }

        [MaxLength(128)]
        public string Address { get; set; }

        [MaxLength(16)]
        public string Phone { get; set; }

        [Required]
        [MaxLength(256)]
        public string HashPassword { get; set; }

        public DateTime CreationDate { get; set; }

        public bool Status { get; set; }

     
    }
}