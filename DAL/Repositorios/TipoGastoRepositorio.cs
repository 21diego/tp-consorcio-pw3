using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace DAL.Repositorios
{
    public class TipoGastoRepositorio
    {
        ConsorcioCtx context;

        public TipoGastoRepositorio(ConsorcioCtx contexto)
        {
            context = contexto;
        }
        public List<TipoGasto> ObtenerTiposGastos()
        {
            return context.TipoGastoes.ToList();
        }
    }
}
