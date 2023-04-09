namespace VerifyTests.Brighter;

public partial class RecordingCommandProcessor
{
    public void Post<T>(T request)
        where T : class, IRequest =>
        queue.Enqueue(new(CommandType.Post, request));

    public Task PostAsync<T>(T request, bool continueOnCapturedContext = false, CancellationToken cancellation = default)
        where T : class, IRequest
    {
        queue.Enqueue(new(CommandType.Post, request));
        return Task.CompletedTask;
    }

    public IEnumerable<IRequest> Posts =>
        queue.Where(_ => _.type is CommandType.Post)
            .Select(_ => _.record)
            .Cast<IRequest>();
}