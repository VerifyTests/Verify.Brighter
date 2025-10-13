namespace VerifyTests.Brighter;

public record SendRecord(
    IRequest Request,
    RequestContext? Context,
    bool? ContinueOnCapturedContext = null,
    DateTimeOffset? At = null,
    TimeSpan? Delay = null);