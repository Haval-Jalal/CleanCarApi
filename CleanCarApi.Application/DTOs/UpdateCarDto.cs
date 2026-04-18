namespace CleanCarApi.Application.DTOs
{
    public class UpdateCarDto
    {
        public string Model { get; set; } = string.Empty;
        public int Year { get; set; }
        public decimal Price { get; set; }
        public int FuelType { get; set; }
        public int BrandId { get; set; }
    }
}
