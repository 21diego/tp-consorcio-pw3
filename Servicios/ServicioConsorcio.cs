using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace Servicios
{
    public class ServicioConsorcio
    {
        private static ServicioConsorcio instance;

        private ServicioConsorcio() { }

        public static ServicioConsorcio getInstance() {
            if (instance == null) {
                instance = new ServicioConsorcio();
            }
            return instance;
        }

        private static List<Consorcio> consorcios = new List<Consorcio>();
        private static int id = 1;




        public List<Consorcio> listarConsorcios()
        {
            consorcios.Add(new Consorcio()
            {
                ConsorcioId = id++,
                Nombre = "La fastina",
                Ciudad = "gotica",
                DiaVencimientoExpensas = 5

            }) ;
            return consorcios;
        }

        public Consorcio getConsorcioById(int id)
        {
            Consorcio consorcio = new Consorcio()
            {
                ConsorcioId = id,
                Nombre = "La fastina",
                Ciudad = "gotica",
                DiaVencimientoExpensas = 5
            };
            return consorcio;
        }
    }
}
