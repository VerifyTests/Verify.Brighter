using Paramore.Brighter;

public record Request(string Property) : IRequest
{
    public Guid Id { get; set; }
    public Activity Span { get; set; } = null!;
}