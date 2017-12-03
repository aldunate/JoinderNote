using System.Collections.Generic;
using System.Web.Http;
using joindernoteData;
using joindernoteService.Services;
using System.Web.Http.Cors;

namespace joindernoteApi.Controllers
{
    [EnableCors("*","*","*")]
    public class LoginController : ApiController
    {
        // Curso
        private IUsuarioService usuarioService = new UsuarioService();

        

        public IHttpActionResult Post(Usuario usuario)
        {
            return Ok(usuarioService.LoginUsuario(usuario));
        }


    }
}