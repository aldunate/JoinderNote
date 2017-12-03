using System.Collections.Generic;
using System.Web.Http;
using joindernoteData;
using joindernoteService.Services;
using System.Web.Http.Cors;

namespace joindernoteApi.Controllers
{
    [EnableCors("*","*","*")]
    public class UsuarioController : ApiController
    {
        // Curso
        private IUsuarioService usuarioService = new UsuarioService();

        public IEnumerable<Usuario> Get()
        {
            return usuarioService.GetUsuarios();
        }

        public Usuario Get(int id)
        {
            return usuarioService.GetUsuario(id);
        }

        public IHttpActionResult Post(Usuario usuario)
        {
            return Ok(usuarioService.SaveUsuario(usuario));
        }


    }
}