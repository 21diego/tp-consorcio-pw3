using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DAL
{
    public class ExpensasDTO
    {
        public int IdExpensas { get; set; }
        public int AnioExpensa { get; set; }
        public int MesExpensa { get; set; }
        public int Unidades { get; set; }
        public decimal GastoTotal { get; set; }
        public decimal MontoExpensa { get; set; }
    }
}