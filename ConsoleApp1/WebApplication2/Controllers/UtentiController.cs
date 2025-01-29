using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.Mappings;
using WebApplication2.Models;
using WebApplication2.Models.DTO;
using WebApplication2.Models.Entities;
using WebApplication2.Models.Requests;
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

        [HttpGet]
        [Route("GetAll")]
        public Response<List<UtenteDTO>> GetAll()
        {
            Response<List<UtenteDTO>> r = new Response<List<UtenteDTO>>();
            List<Utenti> utenti = UtentiService.GetAll();// vado a recuperar eil servizio
            if (utenti == null)
            {
                r.Success = false;
                r.Message = "Nessun utente trovato";
                r.Result = null;
            }
            else
            {
                r.Success = true;
                r.Message = "Operazione completata";
                r.Result = UtentiMapping.MapUtente(utenti); //qui mappo i risultati
            }
            return r;
        }


        [HttpGet]
        [Route("GetByGuid")]
        public Response<UtenteDTO> GetByGuid( Guid guidUtente )
        {
            Response<UtenteDTO> r =new  Response<UtenteDTO>();
            //Utenti utenti = UtentiService.GetAll().FirstOrDefault(s=>s.Guid==guidUtente);// vado a recuperar eil servizio
            Utenti utenti = UtentiService.GetByGuid(guidUtente);// vado a recuperar eil servizio
            if (utenti == null)
            {
                r.Success = false;
                r.Message = "Nessun utente trovato";
                r.Result = null;
            }
            else
            {
                r.Success = true;
                r.Message = "Operazione completata";
                r.Result = UtentiMapping.MapUtente(utenti); //qui mappo i risultati
            }
            return r;
        }



        [HttpGet]
        [Route("GetByGuid2/{guidUtente}")]
        public Response<UtenteDTO> GetByGuid2(Guid guidUtente)
        {
            Response<UtenteDTO> r = new Response<UtenteDTO>();
            //Utenti utenti = UtentiService.GetAll().FirstOrDefault(s=>s.Guid==guidUtente);// vado a recuperar eil servizio
            Utenti utenti = UtentiService.GetByGuid(guidUtente);// vado a recuperar eil servizio
            if (utenti == null)
            {
                r.Success = false;
                r.Message = "Nessun utente trovato";
                r.Result = null;
            }
            else
            {
                r.Success = true;
                r.Message = "Operazione completata";
                r.Result = UtentiMapping.MapUtente(utenti); //qui mappo i risultati
            }
            return r;
        }
        [HttpPost]
        [Route("Insert")]
        public Response<bool> Insert([FromBody] UtenteNewRequest utente)
        {
            Response<bool> result = new Response<bool>();

            result.Success = true;
            result.Message = "Operazione completata";
            result.Result = UtentiService.Insert(utente);


            return result;
        }

        [HttpDelete]
        [Route("Delete/{guidUtente}")]
        public Response<bool> Delete(Guid guidUtente)
        {
            Response<bool> result = new Response<bool>();

            result.Success = true;
            result.Message = "Operazione completata";
            result.Result = UtentiService.Delete(guidUtente);


            return result;
        }

        [HttpPut]
        [Route("Update")]
        public Response<bool> Update([FromBody] UtenteEditRequest request)
        {
            Response<bool> result = new Response<bool>();

            result.Success = true;
            result.Message = "Operazione completata";
            result.Result = UtentiService.Update(request);


            return result;
        }

    }
}
