using API_Second_Task.Apps.AdminApi.DTOs;
using API_Second_Task.Apps.AdminApi.DTOs.CategoryDTOs;
using API_Second_Task.Data.DAL;
using API_Second_Task.Data.Entities;
using API_Second_Task.Extensions;
using Microsoft.AspNetCore.Hosting;
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
    public class CategoriesController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public CategoriesController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }


        [HttpPost("")]
        public IActionResult Create([FromForm]CategoryPostDto postDto)
        {
            if (_context.Categories.Any(x=>x.Name.ToLower().Trim() == postDto.Name.ToLower().Trim()))
            {
                return StatusCode(409);
            }
            if (postDto.ImageFile==null)
            {
                return BadRequest();
            }



            Category category = new Category
            {
                Name = postDto.Name,
                Image = postDto.ImageFile.SaveImg(_env.WebRootPath, "assets/img")

            };

            _context.Categories.Add(category);
            _context.SaveChanges();
            return StatusCode(201, category);

        }



        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Category category = _context.Categories.FirstOrDefault(x => x.Id == id && !x.IsDeleted);

            if (category==null)
            {
                return StatusCode(404);
            }

            CategoryGetDTO getDTO = new CategoryGetDTO
            {
                CreatedTime = category.CreatedTime,
                Id = category.Id,
                ModifiedTime = category.ModifiedTime,
                Name = category.Name,
                Image = category.Image

            };

            return Ok(getDTO);
        }


        [HttpGet("")]
        public IActionResult GetAll(int page = 1)
        {
            var query = _context.Categories.Where(x => !x.IsDeleted);

            ListDto<CategoryListItemDto> listDto = new ListDto<CategoryListItemDto>
            {
                TotalCount = query.Count(),
                Items = query.Skip((page - 1) * 8).Take(8).Select(x => new CategoryListItemDto { Id = x.Id, Name = x.Name }).ToList()
            };

            return Ok(listDto);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id,[FromForm]CategoryUpdateDto postDto)
        {

            Category category = _context.Categories.FirstOrDefault(x => x.Id == id && !x.IsDeleted);

            if (category == null)
            {
                return StatusCode(404);
            }

            if (_context.Categories.Any(x=> x.Id!=id && x.Name.ToLower().Trim()==postDto.Name.ToLower().Trim()))
            {
                return StatusCode(409);
            }

           

            if (postDto.ImageFile!=null)
            {
                Helpers.Helper.DeleteImg(_env.WebRootPath, "assets/img", category.Image);
                category.Image = postDto.ImageFile.SaveImg(_env.WebRootPath, "assets/img");
            }
            category.Name = postDto.Name;
            category.ModifiedTime = DateTime.UtcNow;
            _context.SaveChanges();
            return NoContent();

        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Category category = _context.Categories.FirstOrDefault(x => x.Id == id && !x.IsDeleted);

            if (category == null)
            {
                return StatusCode(404);
            }

            category.IsDeleted = true;
            category.ModifiedTime = DateTime.UtcNow;
            _context.SaveChanges();
            return NoContent();

        }
    }
}
