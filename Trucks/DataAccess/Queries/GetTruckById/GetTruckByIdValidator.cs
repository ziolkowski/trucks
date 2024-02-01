using FluentValidation;

namespace Trucks.DataAccess.Queries.GetTruckById
{
    public class GetTruckByIdValidator : AbstractValidator<GetTruckByIdQuery>
    {
        public GetTruckByIdValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
        }
    }
}
