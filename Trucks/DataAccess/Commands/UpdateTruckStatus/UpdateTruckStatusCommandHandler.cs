using FluentValidation;
using MediatR;
using Trucks.DataAccess.Repositories;
using Trucks.Services;
using Trucks.Utilities;
using Trucks.Utilities.Exceptions;

namespace Trucks.DataAccess.Commands.SetTruckStatus
{
    public class UpdateTruckStatusCommandHandler : IRequestHandler<UpdateTruckStatusCommand>
    {
        private readonly ITruckRepository _truckRepository;
        private readonly IValidator<UpdateTruckStatusCommand> _validator;
        private readonly ITruckStatusService _statusService;

        public UpdateTruckStatusCommandHandler(ITruckRepository truckRepository, IValidator<UpdateTruckStatusCommand> validator, 
            ITruckStatusService statusService)
        {
            _truckRepository = truckRepository;
            _validator = validator;
            _statusService = statusService;
        }

        public async Task Handle(UpdateTruckStatusCommand request, CancellationToken ct)
        {
            var validationResult = await _validator.ValidateAsync(request, ct);
            if (!validationResult.IsValid)
            {
                throw new BusinessConflictException(ValidationHelper.GetFailedValidationMessage(validationResult));
            }

            var targetTruck = await _truckRepository.GetOne(request.Model.Id, ct);
            var result = _statusService.CheckTruckStatusOrder(targetTruck.Status, request.Model.Status);
            if (!result.IsValid)
            {
                throw new BusinessConflictException(result.ErrorMessage);
            }

            await _truckRepository.UpdateStatus(request.Model, ct);
        }
    }
}
