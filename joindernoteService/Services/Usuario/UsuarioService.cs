using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using joindernoteData;


namespace joindernoteService.Services
{
    public class UsuarioService : IUsuarioService
    {
        private JoinderNoteDb db = new JoinderNoteDb();
        private ITokenService tokenService = new TokenService();

        public Usuario GetUsuario(int id)
        {
            return db.Usuario.Where(x => x.Id == id).FirstOrDefault();
        }
        public Usuario GetUsuario(string nombre)
        {
            return db.Usuario.Where(x => x.Nombre == nombre).FirstOrDefault();
        }

        public List<Usuario> GetUsuarios()
        {
            return db.Usuario.ToList();
        }

        public Usuario SaveUsuario(Usuario usuario)
        {
            try
            {
                usuario = db.Usuario.Add(usuario);
                Usuario found = db.Usuario.Where(x => x.Nombre == usuario.Nombre).FirstOrDefault();
                if(found != null) return null;
                db.SaveChanges();
                Token token = tokenService.CreateToken(usuario);
                if (tokenService.SaveToken(token)) return usuario;
                return null;
            }catch(Exception e)
            {
                return null;
            }
        }

        public Token LoginUsuario(Usuario usuario)
        {
            usuario = db.Usuario.Where(x => x.Nombre == usuario.Nombre && x.Password == usuario.Password).FirstOrDefault();
            if (usuario != null) return tokenService.CreateToken(usuario);
            return null;
        }
    }
}




















































































































































































































