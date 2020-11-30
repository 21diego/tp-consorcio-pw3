using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    class GastoMetadata
    {
        [Required(ErrorMessage = "Debe ingresar un valor correspondiente al nombre")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "Debe seleccionar un tipo de gasto")]
        public int IdTipoGasto { get; set; }
        [Required(ErrorMessage = "Debe ingresar una fecha de gasto")]
        public System.DateTime FechaGasto { get; set; }
        [Required(ErrorMessage = "Debe ingresar un valor correspondiente al año de Expensa")]
        public int AnioExpensa { get; set; }
        [Required(ErrorMessage = "Debe ingresar un valor correspondiente al mes de Expensa")]
        public int MesExpensa { get; set; }
        [Required(ErrorMessage = "Debe cargar un comprobante")]
        public string ArchivoComprobante { get; set; }
        [Required(ErrorMessage = "Debe ingresar un valor correspondiente al monto")]
        public decimal Monto { get; set; }
    }
}
