﻿public record Message(string Property) :
    IRequest
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Activity? Span { get; set; }
}