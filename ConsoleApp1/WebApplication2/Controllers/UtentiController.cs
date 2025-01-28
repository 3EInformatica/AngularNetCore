using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.Mappings;
using WebApplication2.Models;
using WebApplication2.Models.DTO;
using WebApplication2.Services;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UtentiController : ControllerBase
    {
        [HttpPost]
        [Route("Login")]
        public Response<LoginUtenteDTO> Login([FromBody] Models.Requests.LoginRequest request)
        {
            Response<LoginUtenteDTO> r = new Response<LoginUtenteDTO>();

            var utente = UtentiService.Login(request.Username, request.Password);
            if (utente == null)
            {
                r.Success = false;
                r.Message = "Credenziali non valide";
                r.Result = null;
            }
            else
            {
                r.Success = true;
                r.Message = "Operazione completata";
                r.Result = UtentiMapping.MapUtentiLogin(utente);
            }

            return r;
        }
    }
}
