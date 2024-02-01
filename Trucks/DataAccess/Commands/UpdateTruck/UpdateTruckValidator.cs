using FluentValidation;
using Trucks.Utilities;

namespace Trucks.DataAccess.Commands.UpdateTruck
{
    public class UpdateTruckValidator : AbstractValidator<UpdateTruckCommand>
    {
        public UpdateTruckValidator() 
        {
            RuleFor(x => x.Model).ChildRules(x => x.RuleFor(z => z.Id).NotEmpty());
            RuleFor(x => x.Model).ChildRules(x => x.RuleFor(z => z.Code).Matches(Constants.AlphanumericRegex));
        }
    }
}