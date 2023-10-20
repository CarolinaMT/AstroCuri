using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstroCuri.Shared.Entities
{
    public class User
    {
       
        [Required(ErrorMessage = "El Id del usuario es requerido")]
        public int UserId { get; set;} 

        [Required(ErrorMessage = "El Nombre es requerido")]
        public string FirstName { get; set; } = null;

        [Required(ErrorMessage = "El Apellido es requerido")]
        public string LastName { get; set; } = null;

        [Required(ErrorMessage = "El Correo es requerido")]
        public string Address { get; set; } = null;
        public string FullName => $"{FirstName} " +
            $"{LastName}";






    }
}
