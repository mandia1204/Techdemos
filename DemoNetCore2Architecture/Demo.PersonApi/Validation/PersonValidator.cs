using Demo.PersonApi.Models;
using Demo.PersonApi.Repositories.Interfaces;
using FluentValidation;

namespace Demo.PersonApi.Validation
{
    public class PersonValidator: AbstractValidator<Person>
    {
        public PersonValidator(IPersonRepository personRepository)
        {
            RuleSet("Edit", () => {
                RuleFor(p=> p.PersonId).NotEmpty().WithMessage("Person id is required");
            });
            RuleSet("New", () => {
                RuleFor(p =>p.Name).NotEmpty().WithMessage("Name is required.");
                RuleFor(p =>p.Courses).NotEmpty().WithMessage("Select at least one course.");
            });
        }
    }
}