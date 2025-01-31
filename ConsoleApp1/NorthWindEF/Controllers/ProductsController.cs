using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using NorthWindEF.Models;

namespace NorthWindEF.Controllers
{



    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private CorsoNetGennaioContext context;
        public ProductsController()
        {
            var isDebugMode = true;
            var options = new Microsoft.EntityFrameworkCore.DbContextOptionsBuilder<CorsoNetGennaioContext>()
                .UseSqlServer("Server=54.38.44.7;Database=CorsoNetGennaio;User Id=corsoNetCore;Password=3EInformatica!;Encrypt=False;TrustServerCertificate=False;")

           .LogTo(s => System.Diagnostics.Debug.WriteLine(s))
                          .EnableDetailedErrors(isDebugMode)
                          .EnableSensitiveDataLogging(isDebugMode).Options;
            context = new CorsoNetGennaioContext(options);

        }

        [HttpGet]
        [Route("GetAll")]
        public IActionResult GetAll()
        {

            var products = context.Products.ToList();

            return Ok(products);
        }

        [HttpGet]
        [Route("GetById")]
        public IActionResult GetById(int idProdotto)
        {

            //IQueryable<Product> pp = context.Products.Where(s => s.ProductId == idProdotto);

            //IEnumerable<Product> pp2 = pp.ToList();


            var products = context.Products.Where(s => s.ProductId == idProdotto).First();

            return Ok(products);
        }

        [HttpPost]
        [Route("Insert")]
        public IActionResult Insert([FromBody] Product prodotto)
        {

            context.Products.Add(prodotto);
            context.SaveChanges();
            return Ok(true);
        }

        [HttpPut]
        [Route("Update")]
        public IActionResult Update([FromBody] Product prodotto)
        {

            context.Products.Update(prodotto);
            context.SaveChanges();
            return Ok(true);
        }


        [HttpDelete]
        [Route("Delete/{idProdtto}")]
        public IActionResult Delete(int idProdtto)
        {

            var prodotto = context.Products.Where(s => s.ProductId == idProdtto).FirstOrDefault();
            if (prodotto != null)
            {
                context.Products.Remove(prodotto);
                context.SaveChanges();
                return Ok(true);
            }
            else
            {
                return Ok(false);
            }
        }

        [HttpGet]
        [Route("GetByName")]
        public IActionResult GetByName(string nomeProdotto = "")
        {
            //  where ProductName like '%nomeProdotto%' 
            var products = context.Products.Where(s => s.ProductName.Contains(nomeProdotto)).ToList();

            //  where ProductName like 'nomeProdotto%' 
            var productsStart = context.Products.Where(s => s.ProductName.StartsWith(nomeProdotto)).ToList();

            //  where ProductName like '%nomeProdotto' 
            var productsEnd = context.Products.Where(s => s.ProductName.EndsWith(nomeProdotto)).ToList();


            return Ok(products);
        }

        [HttpGet]
        [Route("GetByNameOrder")]
        public IActionResult GetByNameOrder(string? nomeProdotto, string? operatoreConfronto, decimal? UnitPrice)
        {
            //  where ProductName like '%nomeProdotto%' 
            var products = context.Products.
                Where(s => s.ProductName.Contains(nomeProdotto ?? ""));

            if (operatoreConfronto == ">")
            {
                products = products.Where(s => s.UnitPrice > (UnitPrice ?? 0));
            }
            else if (operatoreConfronto == "<")
            {
                products = products.Where(s => s.UnitPrice < (UnitPrice ?? 0));
            }
            else if (operatoreConfronto == "=")
            {
                products = products.Where(s => s.UnitPrice == (UnitPrice ?? 0));
            }


            var pp = products.ToList();

            return Ok(pp);
        }


    }
}
