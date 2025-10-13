namespace VerifyTests.Brighter;

public record PostRecord(
    IRequest Request,
    RequestContext? Context,
    Dictionary<string, object>? Args,
    bool? ContinueOnCapturedContext = null,
    DateTimeOffset? At = null,
    TimeSpan? Delay = null);