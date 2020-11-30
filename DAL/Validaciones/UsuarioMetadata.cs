using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    internal class UsuarioMetadata
    {
        [Required(ErrorMessage = "Ingrese un valor al campo email")]
        [EmailAddress(ErrorMessage = "Ingrese un correo electrónico valido")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Ingrese un valor al campo contraseña")]
        public string Password { get; set; }
    }
}
