using Paramore.Brighter;

public record Response(string Property) : IResponse
{
    public Guid Id { get; set; }
    public Activity? Span { get; set; }
    public Guid CorrelationId { get; set; }
}