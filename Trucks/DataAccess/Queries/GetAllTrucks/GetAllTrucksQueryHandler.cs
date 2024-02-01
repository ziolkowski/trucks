using MediatR;
using FluentValidation;
using Trucks.DataAccess.Repositories;
using Trucks.Dto;
using Trucks.Utilities.Exceptions;
using Trucks.Utilities;

namespace Trucks.DataAccess.Queries.GetAllTrucks
{
    public class GetAllTrucksQueryHandler : IRequestHandler<GetAllTrucksQuery, IEnumerable<TruckDto>>
    {
        private readonly ITruckRepository _truckRepository;
        private readonly IValidator<GetAllTrucksQuery> _validator;

        public GetAllTrucksQueryHandler(ITruckRepository truckRepository, IValidator<GetAllTrucksQuery> validator)
        {
            _truckRepository = truckRepository;
            _validator = validator;
        }

        public async Task<IEnumerable<TruckDto>> Handle(GetAllTrucksQuery request, CancellationToken ct)
        {
            var validationResult = await _validator.ValidateAsync(request, ct);
            if (!validationResult.IsValid)
            {
                throw new BusinessConflictException(ValidationHelper.GetFailedValidationMessage(validationResult));
            }
                        
            return await _truckRepository.GetAll(request.QueryParameters, ct);
        }
    }
}
