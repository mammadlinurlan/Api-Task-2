using FluentValidation;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Second_Task.Apps.AdminApi.DTOs.CategoryDTOs
{
    public class CategoryPostDto
    {
        public string Name { get; set; }

        public IFormFile ImageFile { get; set; }
    }

    public class CategoryPostDtoValidator : AbstractValidator<CategoryPostDto> {



        public CategoryPostDtoValidator()
        {
            RuleFor(x => x.Name).MaximumLength(50).WithMessage("Category name must be less than 50chars");
            RuleFor(x => x.ImageFile).NotNull().WithMessage("Image cannot be null!");
            //RuleFor(x => x).Custom((x, context) =>
            //{
            //    if (x.ImageFile.Length / 1024 / 1024 > 2)
            //    {
            //        context.AddFailure("Image must be less than 2mb");
            //    }
            //});
            //RuleFor(x => x).Custom((x, context) =>
            //{
            //    if (!x.ImageFile.ContentType.Contains("image/"))
            //    {
            //        context.AddFailure("Select an image file!");
            //    }
            //});

        }
        }


    }

