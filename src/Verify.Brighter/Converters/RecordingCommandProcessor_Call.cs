namespace VerifyTests.Brighter;

public partial class RecordingCommandProcessor
{
    public TResponse Call<T, TResponse>(T request, int timeOutInMilliseconds)
        where T : class, ICall
        where TResponse : class, IResponse
    {
        queue.Enqueue(new(CommandType.Call, new CallRecord(request, typeof(TResponse), timeOutInMilliseconds)));
        return default!;
    }

    public IEnumerable<CallRecord> Calls =>
        queue.Where(_ => _.type is CommandType.Call)
            .Select(_ => _.record)
            .Cast<CallRecord>();
}