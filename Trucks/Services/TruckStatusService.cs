using Microsoft.OpenApi.Extensions;
using Trucks.Dto;
using Trucks.Enums;

namespace Trucks.Services
{
    public class TruckStatusService : ITruckStatusService
    {
        public SetTruckStatusResult CheckTruckStatusOrder(TruckStatus oldStatus, TruckStatus newStatus)
        {
            if (oldStatus == newStatus || 
                newStatus == TruckStatus.OutOfService || 
                oldStatus == TruckStatus.OutOfService || 
                (oldStatus == TruckStatus.Returning && newStatus == TruckStatus.Loading) ||
                ((int)newStatus - (int)oldStatus) == 1)
            {
                return new SetTruckStatusResult(true);
            }

            var errorMessage = $"Cannot set {newStatus.GetDisplayName()} status from {oldStatus.GetDisplayName()}. " +
                $"Statuses can only be changed in the following order: Loading -> To Job -> At Job -> Returning.";

            return new SetTruckStatusResult(false, errorMessage);
        }
    }
}
