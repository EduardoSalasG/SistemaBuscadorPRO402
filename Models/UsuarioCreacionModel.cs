using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaBuscador.Models
{
    public class UsuarioCreacionModel
    {
        [Required(ErrorMessage ="El campo {0} es requerido")]
        [Display(Name ="Nombre de Usuario")]
        public string NombreUsuario { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string Nombres { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string Apellidos { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "Rol")]
        public int? RolId { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "Contraseña")]
        [MinLength(8,ErrorMessage ="El campo {0} debe tener como mínimo {1} caracteres")]
        [RegularExpression("^(?=\\w*\\d)(?=\\w*[A-Z])(?=\\w*[a-z])\\S{8,16}$",ErrorMessage ="La contraseña debe tener al menos una mayúscula, minúsculas, dígitos y al menos 8 caracteres")]
        public string Password { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "Repetir Contraseña")]
        [MinLength(8, ErrorMessage = "El campo {0} debe tener como mínimo {1} caracteres")]
        [RegularExpression("^(?=\\w*\\d)(?=\\w*[A-Z])(?=\\w*[a-z])\\S{8,16}$", ErrorMessage = "La contraseña debe tener al menos una mayúscula, minúsculas, dígitos y al menos 8 caracteres")]
        [Compare("Password",ErrorMessage ="Las contraseñas no son iguales")]
        public string RePassword { get; set; }

        public SelectList Roles { get; set; }


    }
}
