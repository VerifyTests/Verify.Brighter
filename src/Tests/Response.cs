using Paramore.Brighter;

public record Response(string Property) : IRequest
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Activity? Span { get; set; }
}