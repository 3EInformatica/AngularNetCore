using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SCCM.Models;

namespace SCCM.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnagraficaClientiController : GenericController<AnagraficheClienti>
    {
        //private seiciochemangiContext context;

        //public AnagraficaClientiController()
        //{
        //    var isDebugMode = true;
        //    var options = new Microsoft.EntityFrameworkCore.DbContextOptionsBuilder<seiciochemangiContext>()
        //        .UseSqlServer("Server=54.38.44.7;Database=seiciochemangi;User Id=corsoNetCore;Password=3EInformatica!;Encrypt=False;TrustServerCertificate=False;")

        //   .LogTo(s => System.Diagnostics.Debug.WriteLine(s))
        //                  .EnableDetailedErrors(isDebugMode)
        //                  .EnableSensitiveDataLogging(isDebugMode).Options;
        //    context = new seiciochemangiContext(options);

        //}

        //[HttpGet]
        //[Route("GetAll")]
        //public IActionResult GetAll()
        //{

        //    var geoitalias = context.AnagraficheClientis.ToList();
        //    return Ok(geoitalias);
        //}

    }
}
