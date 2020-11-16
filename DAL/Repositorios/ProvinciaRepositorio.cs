using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ProvinciaRepositorio
    {
        ConsorcioCtx context;

        public ProvinciaRepositorio(ConsorcioCtx contexto)
        {
            context = contexto;

        }

        public List<Provincia> listarProvincias()
        {
            return context.Provincias.ToList();
        }
    }
}
