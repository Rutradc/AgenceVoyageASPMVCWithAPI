namespace AppAgency.API.Dto
{
    public record BookingCreateDto
    (
        DateTime BookingDate,
        string ClientName,
        IEnumerable<int> ActivitiesIds
    );
}
