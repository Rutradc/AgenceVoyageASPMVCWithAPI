using AppAgency.API.Dto;
using AppAgency.Domain.Model;

namespace AppAgency.API.Handlers
{
    public static class Mapper
    {
        public static Destination ToEntity(this DestinationCreateDto dto)
        {
            if (dto is null) throw new ArgumentNullException(nameof(dto));
            return new Destination() 
            {
                Country = dto.Country,
                City = dto.City,
                Description = dto.Description,
            };
        }

        public static Activity ToEntity(this ActivityCreateDto dto)
        {
            if (dto is null) throw new ArgumentNullException(nameof(dto));
            return new Activity()
            {
                Title = dto.Title,
                Description = dto.Description,
                Price = dto.Price,
                DestinationId = dto.DestinationId,
            };
        }

        public static Booking ToEntity(this BookingCreateDto dto)
        {
            if (dto is null) throw new ArgumentNullException(nameof(dto));
            return new Booking()
            {
                BookingDate = dto.BookingDate,
                ClientName = dto.ClientName
            };
        }
    }
}
