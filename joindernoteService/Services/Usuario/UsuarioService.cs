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

        public List<Usuario> GetUsuarios()
        {
            return db.Usuario.ToList();
        }

        public bool SaveUsuario(Usuario usuario)
        {
            try
            {
                db.Usuario.Add(usuario);
                Usuario found = db.Usuario.Where(x => x.Nombre == usuario.Nombre).FirstOrDefault();
                if(found != null) return false;
                db.SaveChanges();
                Token token = tokenService.CreateToken(usuario);
                return tokenService.SaveToken(token);
            }catch(Exception)
            {
                return false;
            }
        }

    }
}