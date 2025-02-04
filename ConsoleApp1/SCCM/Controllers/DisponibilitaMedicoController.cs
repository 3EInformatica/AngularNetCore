using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SCCM.Models;

namespace SCCM.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DisponibilitaMedicoController : ControllerBase
    {
        private seiciochemangiContext context;

        public DisponibilitaMedicoController()
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
        [Route("CheckAvalilability")]
        public IActionResult CheckAvalilability(int idMedico, DateTime Datappuntamento)
        {
            //var geoitalias = context.DisponibilitaMedicos.Where(s =>
            //s.IdMedico == idMedico
            //&& Datappuntamento >= s.Inizio
            //&& Datappuntamento <= s.Fine
            //).Count();
            //return Ok(geoitalias > 0);

            //var geoitalias = context.DisponibilitaMedicos.Where(s =>
            //s.IdMedico == idMedico
            //&& Datappuntamento >= s.Inizio
            //&& Datappuntamento <= s.Fine
            //).Any();
            //return Ok(geoitalias );

            var geoitalias = context.DisponibilitaMedicos.Any(s =>
         s.IdMedico == idMedico
         && Datappuntamento >= s.Inizio
         && Datappuntamento <= s.Fine
         );
            return Ok(geoitalias);


        }


        [HttpGet]
        [Route("ViewAvailability")]

        public IActionResult ViewAvailability(int idMedico, DateTime giornoAppuntamento)
        {


            var geoitalias = context.DisponibilitaMedicos.FirstOrDefault(s =>
         s.IdMedico == idMedico
         && giornoAppuntamento >= s.Inizio
         && giornoAppuntamento <= s.Fine
         );
            List<string> result = new List<string>();
            int durataAppuntamento = 10;

            if (geoitalias != null)
            {
                
                var dataCorrente = geoitalias.Inizio;

                while (dataCorrente < geoitalias.Fine)   // 10:00 - 11:00
                {

                    //controlla se c'è già un appuntamento
                    var appuntamento = context.Appuntamentos.Any(s =>
                    s.IdDisponibilitaMedico == geoitalias.Id && s.Inizio == dataCorrente 
                    );

                    if (!appuntamento)
                        result.Add(dataCorrente.ToString("HH:mm") + " - " + dataCorrente.AddMinutes(durataAppuntamento).ToString("HH:mm"));

                    dataCorrente = dataCorrente.AddMinutes(durataAppuntamento);
                }
            }

            return Ok(result);


        }



    }
}
