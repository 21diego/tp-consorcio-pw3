using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace Servicios
{
    public class ProvinciaServicio
    {
        ProvinciaRepositorio repo;

        public ProvinciaServicio(ConsorcioCtx contexto)
        {
            ConsorcioCtx ctx = contexto;
            repo = new DAL.ProvinciaRepositorio(ctx);
        }

        public List<Provincia> listarProvincias()
        {
            return repo.listarProvincias();
        }

    }
}
