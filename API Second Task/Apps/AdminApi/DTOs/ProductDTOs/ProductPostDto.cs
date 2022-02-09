using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Second_Task.Apps.AdminApi.DTOs.ProductDTOs
{
    public class ProductPostDto
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public double Cost { get; set; }
        public bool IsDeleted { get; set; }
        public int CategoryId { get; set; }
    }

    public class ProductPostDtoValidator : AbstractValidator<ProductPostDto>
    {
        public ProductPostDtoValidator()
        {
            RuleFor(x => x.Name)
                .MaximumLength(50).WithMessage("Name must be less than 50 chars")
                .NotEmpty().WithMessage("Name is required");

            RuleFor(x => x.Price)
                .GreaterThanOrEqualTo(0).WithMessage("Price cant be lower than 0")
                .NotNull().WithMessage("Price is required");

            RuleFor(x => x.Cost)
                .GreaterThanOrEqualTo(0).WithMessage("Cost cant be lower than 0")
                .NotNull().WithMessage("Cost is required");

            RuleFor(x => x.CategoryId).NotNull().WithMessage("Categoryid cant be null!");

            RuleFor(x => x).Custom((x, context) =>
            {
                if (x.Cost > x.Price)
                    context.AddFailure("Cost", "Cost cant be higher than price!");
            });
        }
    }
}
