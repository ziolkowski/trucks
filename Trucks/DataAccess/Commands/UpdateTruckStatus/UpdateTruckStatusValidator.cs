using FluentValidation;
using Trucks.DataAccess.Commands.SetTruckStatus;

namespace Trucks.DataAccess.Commands.UpdateTruckStatus
{
    public class UpdateTruckStatusValidator : AbstractValidator<UpdateTruckStatusCommand>
    {
        public UpdateTruckStatusValidator() 
        {
            RuleFor(x => x.Model).ChildRules(x => x.RuleFor(z => z.Status).IsInEnum());
        }
    }
}
