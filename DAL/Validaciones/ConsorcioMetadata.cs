using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    class ConsorcioMetadata
    {
        [Required(ErrorMessage = "Debe ingresar un valor correspondiente al nombre")]
        [DataType(DataType.Text)]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "Debe seleccionar una provincia")]
        public int IdProvincia { get; set; }
        [Required(ErrorMessage = "Debe ingresar un valor correspondiente a la ciudad")]
        [DataType(DataType.Text)]
        public string Ciudad { get; set; }
        [Required(ErrorMessage = "Debe ingresar un valor correspondiente a la calle")]
        [DataType(DataType.Text)]
        public string Calle { get; set; }
        [Required(ErrorMessage = "Debe ingresar un valor correspondiente a la altura")]
        public int Altura { get; set; }
        [Required(ErrorMessage = "Debe ingresar un valor correspondiente a el dia de Vencimiento de expensas")]
        [Range(1, 28, ErrorMessage = "El dia de Vencimiento de expensas debe ser un numero entre 1 - 28")]
        public int DiaVencimientoExpensas { get; set; }
    }
}
