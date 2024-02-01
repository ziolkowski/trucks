using FluentValidation;
using MediatR;
using Trucks.DataAccess.Repositories;
using Trucks.Utilities.Exceptions;
using Trucks.Utilities;

namespace Trucks.DataAccess.Commands.UpdateTruck
{
    public class UpdateTruckCommandHandler : IRequestHandler<UpdateTruckCommand>
    {
        private readonly ITruckRepository _truckRepository;
        private readonly IValidator<UpdateTruckCommand> _validator;

        public UpdateTruckCommandHandler(ITruckRepository truckRepository, IValidator<UpdateTruckCommand> validator)
        {
            _truckRepository = truckRepository;
            _validator = validator;
        }

        public async Task Handle(UpdateTruckCommand request, CancellationToken ct)
        {
            var validationResult = await _validator.ValidateAsync(request, ct);
            if (!validationResult.IsValid)
            {
                throw new BusinessConflictException(ValidationHelper.GetFailedValidationMessage(validationResult));
            }

            await _truckRepository.Update(request.Model, ct);
        }
    }
}