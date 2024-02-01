using Trucks.Dto;
using Trucks.Enums;

namespace Trucks.Services
{
    public interface ITruckStatusService
    {
        SetTruckStatusResult CheckTruckStatusOrder(TruckStatus oldStatus, TruckStatus newStatus);
    }
}