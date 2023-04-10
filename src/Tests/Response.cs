using Paramore.Brighter;

public record Response(string Property) : IResponse
{
    public Guid Id { get; set; }
    public Activity? Span { get; set; }
    public Guid CorrelationId { get; set; }
}
public record MyCommand(string Property) : IResponse
{
    public Guid Id { get; set; }
    public Activity? Span { get; set; }
    public Guid CorrelationId { get; set; }
}
public record MyEvent(string Property) : IEvent
{
    public Guid Id { get; set; }
    public Activity? Span { get; set; }
}