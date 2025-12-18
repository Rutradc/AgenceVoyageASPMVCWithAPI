namespace AppAgency.API.Dto
{
    public record ActivityCreateDto
    (
        string Title,
        string Description,
        decimal Price,
        int DestinationId
    );
}
