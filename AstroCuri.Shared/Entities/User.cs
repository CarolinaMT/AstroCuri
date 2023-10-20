﻿using AstroCuri.Shared.Entities.Enums;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstroCuri.Shared.Entities
{   
    //se agrega el identity para extender la funcionalidad del usuario (sofía)
    public class User : IdentityUser
    {

        [Required(ErrorMessage = "El Id del usuario es requerido")]
        public int UserId { get; set; }

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
