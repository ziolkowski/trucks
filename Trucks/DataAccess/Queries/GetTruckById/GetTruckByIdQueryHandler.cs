using FluentValidation;
using MediatR;
using Trucks.DataAccess.Repositories;
using Trucks.Dto;
using Trucks.Utilities.Exceptions;
using Trucks.Utilities;

namespace Trucks.DataAccess.Queries.GetTruckById
{
    public class GetTruckByIdQueryHandler : IRequestHandler<GetTruckByIdQuery, TruckDto>
    {
        private readonly ITruckRepository _truckRepository;
        private readonly IValidator<GetTruckByIdQuery> _validator;

        public GetTruckByIdQueryHandler(ITruckRepository truckRepository, IValidator<GetTruckByIdQuery> validator)
        {
            _truckRepository = truckRepository;
            _validator = validator;
        }

        public async Task<TruckDto> Handle(GetTruckByIdQuery request, CancellationToken ct)
        {
            var validationResult = await _validator.ValidateAsync(request, ct);
            if (!validationResult.IsValid)
            {
                throw new BusinessConflictException(ValidationHelper.GetFailedValidationMessage(validationResult));
            }

            return await _truckRepository.GetOne(request.Id, ct);
        }
    }
}
