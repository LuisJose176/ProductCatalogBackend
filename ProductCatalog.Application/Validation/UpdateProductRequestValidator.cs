using FluentValidation;
using ProductCatalog.Application.DTOs;

namespace ProductCatalog.Application.Validation
{
    public class UpdateProductRequestValidator : AbstractValidator<UpdateProductRequest>
    {
        public UpdateProductRequestValidator()
        {
            RuleFor(x => x.Name).NotEmpty().MaximumLength(100);
            RuleFor(x => x.Price).GreaterThan(0);
            RuleFor(x => x.Description).MaximumLength(255).When(x => x.Description != null);
        }
    }
}
