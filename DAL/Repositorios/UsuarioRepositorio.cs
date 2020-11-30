using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class UsuarioRepositorio
    {
        ConsorcioCtx context;

        public UsuarioRepositorio(ConsorcioCtx contexto)
        {
            context = contexto;

        }

        public void crearUsuario(Usuario usuario)
        {
            context.Usuarios.Add(usuario);
            context.SaveChanges();
        }

        public Usuario buscarUsuarioPorId(int idUsuario)
        {
            return context.Usuarios.Find(idUsuario);
        }

        public void eliminarUsuario(Usuario usuario)
        {
            context.Usuarios.Remove(usuario);
            context.SaveChanges();
        }

        public void modificarUsuario(Usuario usuario)
        {
           Usuario usuarioObtenido = context.Usuarios.Find(usuario.IdUsuario);
            usuarioObtenido.Email = usuario.Email;
            usuarioObtenido.Password = usuario.Password;
            usuarioObtenido.FechaUltLogin = usuario.FechaUltLogin;

            context.SaveChanges();
        }

        public Usuario buscarUsuarioPorEmail(string email)
        {
            return context.Usuarios.FirstOrDefault(u => u.Email == email);
        }
    }
}
