namespace VerifyTests.Brighter;

public record CallRecord(ICall Request, RequestContext? Context, Type ResponseType, TimeSpan? TimeOut);