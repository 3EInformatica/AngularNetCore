using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UtentiController : ControllerBase
    {
        [HttpGet]
        [Route("Saluto")]
        public Response<string> Saluto(string nome)
        {
            Response<string> r = new Response<string>();
            r.Success = true;
            r.Message = "Operazione completata";
            r.Result = "Ciao " + nome;

            return r;
        }

    }
}
