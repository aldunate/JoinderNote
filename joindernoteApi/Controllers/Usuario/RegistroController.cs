using System.Collections.Generic;
using System.Web.Http;
using joindernoteData;
using joindernoteService.Services;
using System.Web.Http.Cors;

namespace joindernoteApi.Controllers
{
    [EnableCors("*","*","*")]
    public class RegistroController : ApiController
    {
        // Curso
        private IUsuarioService usuarioService = new UsuarioService();

        public Usuario Get(string nombre)
        {
            return usuarioService.GetUsuario(nombre);
        }

        public IHttpActionResult Post(Usuario usuario)
        {
            return Ok(usuarioService.SaveUsuario(usuario));
        }


    }
}