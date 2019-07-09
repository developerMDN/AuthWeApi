using AuthWeApi.Controllers.Token;
using AuthWeApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Web.Http;

namespace AuthWeApi.Controllers
{
    /// <summary>
    /// login controller para autenticar usuarios
    /// </summary>
    [AllowAnonymous]
    [RoutePrefix("api/login")]
    public class LoginController : ApiController
    {
        [HttpGet]
        [Route("echoping")]
        public IHttpActionResult EchoPing()
        {
            return Ok(true);
        }

        [HttpGet]
        [Route("echouser")]
        public IHttpActionResult EchoUser()
        {
            var identity = Thread.CurrentPrincipal.Identity;
            return Ok($" IPrincipal-user: {identity.Name} - IsAuthenticated: {identity.IsAuthenticated}");
        }

        [HttpPost]
        [Route("authenticate")]
        public IHttpActionResult Authenticate(UsuarioLoginRequest login)
        {
            if (login == null)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            //TODO: Validar credenciales, solo demo !!
            bool isCredentialValid = (login.ClaveUsuario == "123456");
            if (isCredentialValid)
            {
                var token = TokenGenerator.GenerateTokenJwt(login.NombreUsuario);
                return Ok(token);
            }
            else
            {
                return Unauthorized();
            }
        }
    }
}
