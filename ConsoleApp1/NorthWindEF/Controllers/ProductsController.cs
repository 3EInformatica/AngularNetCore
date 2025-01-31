using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using NorthWindEF.DTO;
using NorthWindEF.Models;
using System.Linq;

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
        [HttpGet]
        [Route("Search")]
        public IActionResult GetByNameOrder(string? nomeProdotto,
                int? supplierId,
                int? categoryId,
                string? orderBy,
                string? orderDirection,
                int pagina = 1,
                int record = 10)
        {
            IQueryable<Product> products = context.Products
                .Include(s => s.Supplier).Include(s => s.Category);
            //if (nomeProdotto!=null && nomeProdotto != "")
            if (!String.IsNullOrEmpty(nomeProdotto))
            {
                products = products.Where(s => s.ProductName.Contains(nomeProdotto));
            }
            if (supplierId != null && supplierId != 0)
            {
                products = products.Where(s => s.SupplierId == supplierId);
            }
            if (categoryId != null && categoryId != 0)
            {
                products = products.Where(s => s.CategoryId == categoryId);
            }
            if (orderBy == "ProductName")
            {
                if (orderDirection == "DESC")
                    products = products.OrderByDescending(s => s.ProductName);
                else
                    products = products.OrderBy(s => s.ProductName);
            }
            else if (orderBy == "SupplierID")
            {
                if (orderDirection == "DESC")
                    products = products.OrderByDescending(s => s.SupplierId);
                else
                    products = products.OrderBy(s => s.SupplierId);
            }
            else if (orderBy == "CategoryID")
            {
                if (orderDirection == "DESC")
                    products = products.OrderByDescending(s => s.CategoryId);
                else
                    products = products.OrderBy(s => s.CategoryId);
            }
            products = products.Skip((pagina - 1) * record).Take(record);

            var risultato = products.Select(s => new ProdutcDTO()
            {
                ProductId = s.ProductId,
                ProductName = s.ProductName,
                CategoryName = s.Category.CategoryName,
                SupplyerName = s.Supplier.CompanyName
            }
            ).ToList();

            return Ok(risultato);
        }
    }
}
