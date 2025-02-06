using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SCCM.Models;
using SCCM.Services;

namespace SCCM.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnagraficaGestoriController : GenericController<AnagraficheGestori>
    {
        private GenericService<AnagraficheClienti> _anagraficaCLientiService;
        private GenericService<Appuntamento> _Appuntamentoservice;
        public AnagraficaGestoriController()
        {
            _anagraficaCLientiService = new GenericService<AnagraficheClienti>();
            _Appuntamentoservice = new GenericService<Appuntamento>();
        }

        [HttpGet]
        public IActionResult GetAll()
        {

            var clienti = _anagraficaCLientiService.GetAll();
            var appuntamenti = _Appuntamentoservice.GetAll();

            var query =
   from c in clienti
   join a in appuntamenti on c.Id equals a.IdCliente
   where c.Id == 1
   orderby c.Id
   select new { Clienti = c, Appuntamenti = a };



            return Ok(query);
        }
    }
}
