using FluentValidation;
using PetEcommerce.Core.Feature.Pet.Command.Models;

namespace PetEcommerce.Core.Feature.Pet.Command.Validator
{
    public class CreatePetCommandValidator : AbstractValidator<CreatePetCommand>
    {
        public CreatePetCommandValidator()
        {
            RuleFor(x => x.Name)
                    .NotEmpty().NotNull().WithMessage("Name should not be empty or null")
                    .MaximumLength(100).WithMessage("Product name must not exceed 100 characters.");

            RuleFor(x => x.Description)
                    .NotEmpty().WithMessage("Product description is required.")
                    .MaximumLength(500).WithMessage("Product description must not exceed 500 characters.");

            RuleFor(x => x.Price)
                .GreaterThan(0).WithMessage("Product price must be greater than zero.");

            RuleFor(x => x.SpeciesId)
                .NotNull().NotEmpty().WithMessage("Specie should not be empty or null");

            RuleFor(x => x.BreedId)
                .NotNull().NotEmpty().WithMessage("Breed should not be empty or null");
        }
    }
}
