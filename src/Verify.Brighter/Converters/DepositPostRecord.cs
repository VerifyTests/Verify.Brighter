namespace VerifyTests.Brighter;

public record DepositPostRecord(
    IReadOnlyList<IRequest> Requests,
    RequestContext? Context,
    Dictionary<string, object>? Args,
    bool? ContinueOnCapturedContext = null,
    string? BatchId = null);