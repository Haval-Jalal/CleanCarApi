using Microsoft.VisualBasic.FileIO;
using CleanCarApi.Domain.Enums;

namespace CleanCarApi.Domain.Entities
{
    public class Car
    {
        public int Id { get; set; }
        public string Model { get; set; } = string.Empty;
        public int Year { get; set; }
        public decimal Price { get; set; }
        public FuelType Fuelype { get; set; }

        public int BrandId { get; set; }
        public Brand Brand { get; set; } = null!;
    }
}
