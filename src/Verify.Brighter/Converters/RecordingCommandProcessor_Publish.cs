namespace VerifyTests.Brighter;

public partial class RecordingCommandProcessor
{
    public void Publish<T>(T @event)
        where T : class, IRequest =>
        queue.Enqueue(new(CommandType.Publish, @event));

    public Task PublishAsync<T>(T @event, bool continueOnCapturedContext = false, Cancel cancel = default)
        where T : class, IRequest
    {
        queue.Enqueue(new(CommandType.Publish, @event));
        return Task.CompletedTask;
    }

    public IEnumerable<IRequest> Publishes =>
        queue.Where(_ => _.type is CommandType.Publish)
            .Select(_ => _.record)
            .Cast<IRequest>();
}