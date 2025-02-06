using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SCCM.Models;
using SCCM.Services;

namespace SCCM.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenericController<T> : ControllerBase where T : BaseEntity
    {
        private GenericService<T> _genericService;
        public GenericController()
        {
            _genericService = new GenericService<T>();
        }


        [HttpGet]
        [Route("GetAll")]
        public IActionResult GetAll()
        {

            var geoitalias = _genericService.GetAll();
            return Ok(geoitalias);
        }

        [HttpGet]
        [Route("GetById/{id}")]
        public IActionResult GetById(int id)
        {
            var geoitalias = _genericService.GetById(id);
            return Ok(geoitalias);
        }

        [HttpPost]
        [Route("Insert")]
        public IActionResult Insert([FromBody] T element)
        {
            _genericService.New(element);
            return Ok(true);
        }


        [HttpDelete]
        [Route("Delete/{id}")]
        public IActionResult Delete(int id)
        {


            T? entity = _genericService.GetById(id);
            if (entity == null)
            {
                return NotFound();
            }
            return Ok(_genericService.Delete(entity));

      
        }

        [HttpPut]
        [Route("Update")]
        public IActionResult Update(T element)
        {
            return Ok(_genericService.Edit(element));
        }

        [HttpDelete]
        [Route("HardDelete/{id}")]
        public IActionResult HardDelete(int id)
        {
            var geoitalias = _dbSet.FirstOrDefault(s => s.Id == id && s.Abilitato);

            if (geoitalias != null)
            {
                _dbSet.Remove(geoitalias);
            }

            _context.SaveChanges();

            return Ok(true);
        }

    }
}