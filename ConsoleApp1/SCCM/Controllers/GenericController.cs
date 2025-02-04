using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SCCM.Models;

namespace SCCM.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenericController<T> : ControllerBase where T : BaseEntity
    {
       


        [HttpGet]
        [Route("GetAll")]
        public IActionResult GetAll()
        {

            var geoitalias = _dbSet.Where(s=>s.Abilitato).ToList();
            return Ok(geoitalias);
        }

        [HttpGet]
        [Route("GetById/{id}")]
        public IActionResult GetById(int id)
        {
            var geoitalias = _dbSet.FirstOrDefault(s=>s.Id==id && s.Abilitato);
            return Ok(geoitalias);
        }

        [HttpPost]
        [Route("Insert")]
        public IActionResult Insert([FromBody] T element)
        {
            element.DataCreazione = DateTime.Now;
            var geoitalias = _dbSet.Add(element);
            _context.SaveChanges();
            return Ok(true);
        }


        [HttpDelete]
        [Route("Delete/{id}")]
        public IActionResult Delete(int id)
        {
            var geoitalias = _dbSet.FirstOrDefault(s => s.Id == id && s.Abilitato);
            geoitalias.Abilitato = false;
            geoitalias.DataCancellazione = DateTime.Now;
            _context.SaveChanges();

            return Ok(true);
        }

        [HttpPut]
        [Route("Update")]
        public IActionResult Update(T element)
        {
            element.DataAggiornamento = DateTime.Now;
            _context.Entry(element).State = EntityState.Modified;
            _context.SaveChanges();

            return Ok(true);
        }

        [HttpDelete]
        [Route("HardDelete/{id}")]
        public IActionResult HardDelete(int id)
        {
            var geoitalias = _dbSet.FirstOrDefault(s => s.Id == id && s.Abilitato);
            
            if(geoitalias!=null)
            {
                _dbSet.Remove(geoitalias);
            }

            _context.SaveChanges();

            return Ok(true);
        }

    }
}