using System.Collections.Generic;
using System.Web.Http;
using joindernoteData;
using joindernoteService.Services;
using System.Web.Http.Cors;
using System.Security.Claims;

namespace joindernoteApi.Controllers
{
    [EnableCors("*", "*", "*")]
    public class AuthController : ApiController
    {
        ITokenService tokenService = new TokenService();
        IUsuarioService usuarioService = new UsuarioService();

        // Verifica token
        public string Get(string token)
        {
            return tokenService.DecodingToken(token);
        }

        // Autentificacion devuelve token
        public string Post(Usuario usuario)
        {
            usuario = usuarioService.GetUsuario(usuario.Id);
            if(usuario != null) return tokenService.CreateToken(usuario).Nombre;
            return "El usuario no existe";
        }

    }
}