using FluentValidation;
using MediatR;
using Trucks.DataAccess.Repositories;
using Trucks.Utilities;
using Trucks.Utilities.Exceptions;

namespace Trucks.DataAccess.Commands.CreateTruck
{
    public class CreateTruckCommandHandler : IRequestHandler<CreateTruckCommand, Guid>
    {
        private readonly ITruckRepository _truckRepository;
        private readonly IValidator<CreateTruckCommand> _validator;

        public CreateTruckCommandHandler(ITruckRepository truckRepository, IValidator<CreateTruckCommand> validator)
        {
            _truckRepository = truckRepository;
            _validator = validator;
        }

        public async Task<Guid> Handle(CreateTruckCommand request, CancellationToken ct)
        {
            var validationResult = await _validator.ValidateAsync(request, ct);
            if (!validationResult.IsValid)
            {
                throw new BusinessConflictException(ValidationHelper.GetFailedValidationMessage(validationResult));
            }
            
            return await _truckRepository.Create(request.Model, ct);
        }
    }
}
