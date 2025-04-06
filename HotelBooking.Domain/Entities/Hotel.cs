

namespace HotelBooking.Domain.Entities
{
    public class Hotel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public double Price { get; set; }
        public string? HotelCode { get; set; }
        public int Stars {
            get; set;
        }

    }
}
