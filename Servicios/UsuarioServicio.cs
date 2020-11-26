using DAL;
using Servicios.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios
{
   public class UsuarioServicio
    {
        UsuarioRepositorio usuarioRepositorio;

        public UsuarioServicio(ConsorcioCtx contexto)
        {
            usuarioRepositorio = new UsuarioRepositorio(contexto);
        }

        public Boolean registrarUsuario(Usuario usuario, string pass2)
        {
            Usuario usuarioObtenido = usuarioRepositorio.buscarUsuarioPorEmail(usuario.Email);

            if (usuarioObtenido == null && usuario.Password == pass2)
            {
                usuario.FechaRegistracion = System.DateTime.Now;
                usuarioRepositorio.crearUsuario(usuario);
                return true;
            }
            else
            {
                return false;
            }

        }

        public Boolean loguearUsuario(Usuario usuario)
        {
            Usuario usuarioObtenido = usuarioRepositorio.buscarUsuarioPorEmail(usuario.Email);

            if (usuarioObtenido.Password == usuario.Password)
            {
                SessionHelper.AgregarUsuarioSession(usuarioObtenido.IdUsuario);
                usuarioObtenido.FechaUltLogin = System.DateTime.Now;
                usuarioRepositorio.modificarUsuario(usuarioObtenido);
                return true;
            }
            else
            {
                return false;
            }

        }

        public void desloguearUsuario()
        {
            SessionHelper.DestruirSession();
        }

        
    }
}
