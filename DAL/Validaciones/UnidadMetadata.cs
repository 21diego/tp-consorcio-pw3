using System;
using System.ComponentModel.DataAnnotations;

namespace DAL
{
    internal class UnidadMetadata
    {
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string NombrePropietario { get; set; }
        [Required]
        public string ApellidoPropietario { get; set; }
        [Required]
        [EmailAddress(ErrorMessage = "Ingrese un correo electrónico valido")]
        public string EmailPropietario { get; set; }
        [RegularExpression("^[0-9]+$", ErrorMessage = "Ingrese un número entero")]
        public Nullable<int> Superficie { get; set; }
    }
}