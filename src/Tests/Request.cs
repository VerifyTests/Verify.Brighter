public record Request(string Property) :
    IRequest
{
    public Id Id { get; set; } = Id.Random();
    public Activity Span { get; set; } = null!;
    public Id? CorrelationId { get; set; }
}