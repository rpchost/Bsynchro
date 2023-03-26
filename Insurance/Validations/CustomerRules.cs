using FluentValidation;
using Insurance.Models;

namespace Yodiwo.FEMP.ASP.Service.InfrastructureManagement.Validators
{
    public class CustomerRules : AbstractValidator<Customer>
    {
        public CustomerRules()
        {
            RuleFor(x => x).Must(x => DateTime.Now.Year - 18 > x.DateOfBirth.Year)
                .WithMessage("Customer should be an adult");

            RuleFor(x => x).Must(x => x.InitialCredit >= 0)
              .WithMessage("Customer InitialCredit should be positive number");
        }
    }
}
