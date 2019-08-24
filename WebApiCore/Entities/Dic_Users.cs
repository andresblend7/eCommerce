using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiCore.Entities
{
    public class Dic_Users
    {
        public int Id { get; set; }

        [Required]
        [ForeignKey("Rol")]
        public int Use_RolIdFk { get; set; }

        /// <summary>
        /// Dinero ficticio que tendrá cada usuario
        /// </summary>
        public int Use_Money { get; set; }

        [Required]
        [MaxLength(64)]
        public string Use_FirstName { get; set; }

        [MaxLength(64)]
        public string Use_LastName { get; set; }

        /// <summary>
        /// Email es la lalve de acceso a la aplicación.
        /// </summary>
        [Required]
        [EmailAddress]
        [MaxLength(32)]
        public string Use_Email { get; set; }

        [MaxLength(128)]
        public string Use_Address { get; set; }

        [MaxLength(16)]
        public string Use_Phone { get; set; }

        [Required]
        [MaxLength(256)]
        public string Use_HashPassword { get; set; }

        public DateTime Use_CreationDate { get; set; }

        public bool Use_Status { get; set; }

        [ForeignKey("Use_RolIdFk")]
        public Dic_Rol Rol { get; set; }
    }
}
