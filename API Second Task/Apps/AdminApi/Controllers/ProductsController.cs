using API_Second_Task.Apps.AdminApi.DTOs;
using API_Second_Task.Apps.AdminApi.DTOs.ProductDTOs;
using API_Second_Task.Data.DAL;
using API_Second_Task.Data.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Second_Task.Apps.AdminApi.Controllers
{
    [Route("admin/api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProductsController(AppDbContext context)
        {
            _context = context;
        }





       
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Product product = _context.Products.FirstOrDefault(x => x.Id == id && !x.IsDeleted);

            if (product == null) return NotFound();

            ProductGetDto productDto = new ProductGetDto
            {
                Id = product.Id,
               Cost  = product.Cost,
                Price = product.Price,
                Name = product.Name,
                CreatedTime = product.CreatedTime,
                ModifiedTime = product.ModifiedTime,
                CategoryId = product.CategoryId
            };


            return Ok(productDto);
        }

        [HttpGet("")]
        public IActionResult GetAll(int page = 1, string search = null)
        {
            var query = _context.Products.Where(x => !x.IsDeleted);

            if (!string.IsNullOrWhiteSpace(search))
                query = query.Where(x => x.Name.Contains(search));

            ListDto<ProductListItemDto> listDto = new ListDto<ProductListItemDto>
            {
                Items = query.Skip((page - 1) * 8).Take(8).Select(x =>
                    new ProductListItemDto
                    {
                        Id = x.Id,
                        Name = x.Name,
                        Price = x.Price,
                        Cost = x.Cost,
                        CategoryId = x.CategoryId
                    }).ToList(),
                TotalCount = query.Count()
            };

            return Ok(listDto);
        }

        [HttpPost("")]

        public IActionResult Create(ProductPostDto productDto)
        {
            Product product = new Product
            {
                Name = productDto.Name,
                Cost = productDto.Cost,
                Price = productDto.Price,
                CategoryId = productDto.CategoryId
            };

            _context.Products.Add(product);
            _context.SaveChanges();

            return StatusCode(201, product);
        }


        [HttpPut("{id}")]
        public IActionResult Update(int id, ProductPostDto productDto)
        {
            Product existProduct = _context.Products.FirstOrDefault(x => x.Id == id);

            if (existProduct == null)
                return NotFound();

            existProduct.Name = productDto.Name;
            existProduct.Price = productDto.Price;
            existProduct.Cost = productDto.Cost;
            existProduct.CategoryId = productDto.CategoryId;

            _context.SaveChanges();

            return NoContent();
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Product product = _context.Products.FirstOrDefault(x => x.Id == id);

            if (product == null)
                return NotFound();

            product.IsDeleted = true;

            _context.SaveChanges();


            return NoContent();
        }

    }
}
