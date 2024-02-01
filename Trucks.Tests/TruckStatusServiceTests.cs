using FluentAssertions;
using Microsoft.OpenApi.Extensions;
using Trucks.Dto;
using Trucks.Enums;
using Trucks.Services;

namespace Trucks.Tests
{
    public class TruckStatusServiceTests
    {
        [Theory]
        [InlineData(TruckStatus.Loading, TruckStatus.ToJob)]
        [InlineData(TruckStatus.ToJob, TruckStatus.AtJob)]
        [InlineData(TruckStatus.AtJob, TruckStatus.Returning)]
        [InlineData(TruckStatus.Returning, TruckStatus.Loading)]
        [InlineData(TruckStatus.Loading, TruckStatus.OutOfService)]
        [InlineData(TruckStatus.ToJob, TruckStatus.OutOfService)]
        [InlineData(TruckStatus.AtJob, TruckStatus.OutOfService)]
        [InlineData(TruckStatus.Returning, TruckStatus.OutOfService)]
        [InlineData(TruckStatus.OutOfService, TruckStatus.Loading)]
        [InlineData(TruckStatus.OutOfService, TruckStatus.ToJob)]
        [InlineData(TruckStatus.OutOfService, TruckStatus.AtJob)]
        [InlineData(TruckStatus.OutOfService, TruckStatus.Returning)]
        public void CheckTruckStatusOrder_PassValidStatus_ReturnSuccessObject(TruckStatus oldStatus, TruckStatus newStatus)
        {
            var expected = new SetTruckStatusResult(true);
            var truckStatusService = new TruckStatusService();

            var result = truckStatusService.CheckTruckStatusOrder(oldStatus, newStatus);

            result.Should().Be(expected);
            result.Should().BeOfType(typeof(SetTruckStatusResult));
        }

        [Theory]
        [InlineData(TruckStatus.Loading, TruckStatus.AtJob)]
        [InlineData(TruckStatus.Loading, TruckStatus.Returning)]
        [InlineData(TruckStatus.ToJob, TruckStatus.Loading)]
        [InlineData(TruckStatus.ToJob, TruckStatus.Returning)]
        [InlineData(TruckStatus.AtJob, TruckStatus.Loading)]
        [InlineData(TruckStatus.AtJob, TruckStatus.ToJob)]
        [InlineData(TruckStatus.Returning, TruckStatus.ToJob)]
        [InlineData(TruckStatus.Returning, TruckStatus.AtJob)]
        public void CheckTruckStatusOrder_PassInvalidStatus_ReturnFailObject(TruckStatus oldStatus, TruckStatus newStatus)
        {
            var expected = new SetTruckStatusResult(false, $"Cannot set {newStatus.GetDisplayName()} status from {oldStatus.GetDisplayName()}. " +
                $"Statuses can only be changed in the following order: Loading -> To Job -> At Job -> Returning.");
            var truckStatusService = new TruckStatusService();

            var result = truckStatusService.CheckTruckStatusOrder(oldStatus, newStatus);

            result.Should().Be(expected);
            result.Should().BeOfType(typeof(SetTruckStatusResult));
        }
    }
}