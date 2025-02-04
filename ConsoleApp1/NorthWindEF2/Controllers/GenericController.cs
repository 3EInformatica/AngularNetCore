using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using NorthWindEF2.Models;

namespace NorthWindEF2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenericController<T> : ControllerBase where T : BaseEntity
    {
        private CorsoNetGennaioContext _context;
        private readonly DbSet<T> _dbset;

        public GenericController()
        {
            var isDebugMode = true;
            var options = new Microsoft.EntityFrameworkCore.DbContextOptionsBuilder<CorsoNetGennaioContext>()
                .UseSqlServer("Server=54.38.44.7;Database=CorsoNetGennaio;User Id=corsoNetCore;Password=3EInformatica!;Encrypt=False;TrustServerCertificate=False;")

           .LogTo(s => System.Diagnostics.Debug.WriteLine(s))
                          .EnableDetailedErrors(isDebugMode)
                          .EnableDetailedErrors(isDebugMode)
                          .EnableSensitiveDataLogging(isDebugMode).Options;
            _context = new CorsoNetGennaioContext(options);


            _dbset = _context.Set<T>();
        }



        [HttpGet]
        [Route("HelloWorld")]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [HttpGet]
        [Route("GetAll")]
        public List<T> GetAll()
        {
            return _dbset.ToList();
        }
        [HttpGet]
        [Route("GetById/{id}")]
        public T GetById(int id)
        {
            return  _dbset.FirstOrDefault(s=>s.id==id);
        }


    }
}
