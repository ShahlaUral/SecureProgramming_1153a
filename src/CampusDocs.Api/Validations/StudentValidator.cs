using CampusDocs.Api.Models;
using FluentValidation;

namespace CampusDocs.Api.Validations
{
    public class StudentValidator : AbstractValidator<Student>
    {
        public readonly List<string> StatusAllowList = new List<string> { "Active", "Inactive", "Suspended" };

        public StudentValidator()
        {
            RuleFor(x => x.FirstName)
                .NotEmpty()
                .MaximumLength(20)
                .MinimumLength(3);

            RuleFor(x => x.LastName)
                .NotEmpty()
                .MaximumLength(30)
                .MinimumLength(3);
            RuleFor(x => x.Age)
                .NotEmpty()
                .InclusiveBetween(16, 100)
                .WithMessage("");
            RuleFor(x => x.Email)
                .NotEmpty()
                .EmailAddress();

            RuleFor(x => x.Status)
                .NotEmpty()
                .Must(status => StatusAllowList.Contains(status, StringComparer.OrdinalIgnoreCase));


            RuleFor(x => x.Status)
                .Must(status =>
                status == "Active" || status == "Inactive" || status == "Suspended");
                
        }
    }
}
