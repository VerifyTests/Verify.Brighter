public record Message(string Property) :
    IRequest
{
    public Id? CorrelationId { get; set; }
    public Id Id { get; set; } = Id.Random();
    public Activity? Span { get; set; }
}