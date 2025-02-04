using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SCCM.Models;

namespace SCCM.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GeoItaliaController : ControllerBase
    {
        private seiciochemangiContext context;
        public GeoItaliaController()
        {
            var isDebugMode = true;
            var options = new Microsoft.EntityFrameworkCore.DbContextOptionsBuilder<seiciochemangiContext>()
                .UseSqlServer("Server=54.38.44.7;Database=seiciochemangi;User Id=corsoNetCore;Password=3EInformatica!;Encrypt=False;TrustServerCertificate=False;")

           .LogTo(s => System.Diagnostics.Debug.WriteLine(s))
                          .EnableDetailedErrors(isDebugMode)
                          .EnableSensitiveDataLogging(isDebugMode).Options;
            context = new seiciochemangiContext(options);

        }

        [HttpGet]
        [Route("GetAll")]
        public IActionResult GetAll()
        {
            var geoitalias = context.Geoitalia.Take(10).ToList();
            return Ok(geoitalias);
        }

        //[HttpGet]
        //[Route("Search")]
        //public IActionResult Search(string nomecomune, )
        //{

        //    var geoitalias = context.Geoitalia
        //        .Where(s => s.DenominazioneItalianaEStraniera.Contains(nomecomune))
        //        .OrderBy(s => s.CodiceRegione)
        //        .ThenBy(s => s.CodiceProvinciaStorico1)
        //        .Take(10);


        //    var risultato = geoitalias.ToList();
        //    return Ok(risultato);
        //}

    }
}
