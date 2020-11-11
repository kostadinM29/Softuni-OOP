using VehiclesExtension.Interfaces;

namespace VehiclesExtension.Models
{
    public interface IVehicle : IDriveable, IRefuelable
    {
        double FuelQuantity { get; }

        double FuelConsumption { get; }
    }
}