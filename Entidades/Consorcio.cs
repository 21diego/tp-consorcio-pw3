using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Consorcio
    {
        public int ConsorcioId { get; set; }
        public string Nombre { get; set; }
        public string Ciudad { get; set; }
        public string Calle { get; set; }
        public int Altura { get; set; }
        public DateTime FechaCreacion { get; set; }
        public int DiaVencimientoExpensas { get; set; }
        public int IdProvincia { get; set; }
        public int IdUsuarioCreador { get; set; }
    }
}
