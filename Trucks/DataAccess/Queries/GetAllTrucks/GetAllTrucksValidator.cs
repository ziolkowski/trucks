using FluentValidation;

namespace Trucks.DataAccess.Queries.GetAllTrucks
{
    public class GetAllTrucksValidator : AbstractValidator<GetAllTrucksQuery>
    {
        public GetAllTrucksValidator()
        {
            RuleFor(x => x.QueryParameters).ChildRules(x => x.RuleForEach(z => z.Statuses).IsInEnum());
        }
    }
}
