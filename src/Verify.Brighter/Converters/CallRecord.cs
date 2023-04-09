namespace VerifyTests.Brighter;

public record CallRecord(ICall Request, Type ResponseType, int TimeOutInMilliseconds);