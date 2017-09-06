using joindernoteData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace joindernoteService.Services
{
    public interface IUsuarioService
    {
        List<Usuario> GetUsuarios();
        Usuario GetUsuario(int id);
        bool SaveUsuario(Usuario usuario);
    }
}