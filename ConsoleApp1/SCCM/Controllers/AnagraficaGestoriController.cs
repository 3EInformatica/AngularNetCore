using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SCCM.Models;

namespace SCCM.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnagraficaGestoriController : GenericController<AnagraficheGestori>    
    {
    }
}
