namespace VerifyTests.Brighter;

public record PublishRecord(
    IRequest Request,
    RequestContext? Context,
    bool? ContinueOnCapturedContext = null,
    DateTimeOffset? At = null,
    TimeSpan? Delay = null);