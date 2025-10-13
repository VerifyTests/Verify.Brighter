public record Response(string Property) :
    IResponse
{
    public Id Id { get; set; } = Id.Random();
    public Activity? Span { get; set; }
    public Id? CorrelationId { get; set; }
}

public record MyCommand(string Property) :
    IResponse
{
    public Id Id { get; set; } = Id.Random();
    public Activity? Span { get; set; }
    public Id? CorrelationId { get; set; }
}

public record MyEvent(string Property) :
    IEvent
{
    public Id Id { get; set; } = Id.Random();
    public Activity? Span { get; set; }
    public Id? CorrelationId { get; set; }
}