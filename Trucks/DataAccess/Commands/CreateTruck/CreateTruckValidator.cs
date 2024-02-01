using FluentValidation;
using Trucks.Utilities;

namespace Trucks.DataAccess.Commands.CreateTruck
{
    public class CreateTruckValidator : AbstractValidator<CreateTruckCommand>
    {
        public CreateTruckValidator() 
        {
            RuleFor(x => x.Model).ChildRules(x => x.RuleFor(z => z.Code).NotEmpty().Matches(Constants.AlphanumericRegex));
            RuleFor(x => x.Model).ChildRules(x => x.RuleFor(z => z.Name).NotEmpty());
        }
    }
}
