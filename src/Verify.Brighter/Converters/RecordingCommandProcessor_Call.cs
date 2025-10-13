namespace VerifyTests.Brighter;

public partial class RecordingCommandProcessor
{
    public TResponse? Call<T, TResponse>(T request, RequestContext? requestContext = null, TimeSpan? timeOut = null)
        where T : class, ICall
        where TResponse : class, IResponse
    {
        queue.Enqueue(new(CommandType.Call, new CallRecord(request, requestContext, typeof(TResponse), timeOut)));
        return null;
    }

    public IEnumerable<CallRecord> Calls =>
        queue.Where(_ => _.type is CommandType.Call)
            .Select(_ => _.record)
            .Cast<CallRecord>();
}