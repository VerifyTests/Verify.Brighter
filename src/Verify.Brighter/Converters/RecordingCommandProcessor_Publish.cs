namespace VerifyTests.Brighter;

public partial class RecordingCommandProcessor
{
    public IEnumerable<PublishRecord> Publishes =>
        queue.Where(_ => _.type is CommandType.Publish)
            .Select(_ => _.record)
            .Cast<PublishRecord>();

    public void Publish<TRequest>(TRequest @event, RequestContext? requestContext = null)
        where TRequest : class, IRequest =>
        queue.Enqueue(new(CommandType.Publish, new PublishRecord(@event, requestContext)));

    public string Publish<TRequest>(DateTimeOffset at, TRequest @event, RequestContext? requestContext = null)
        where TRequest : class, IRequest
    {
        queue.Enqueue(new(CommandType.Publish, new PublishRecord(@event, requestContext, At: at)));
        return $"Publish: {@event.Id}";
    }

    public string Publish<TRequest>(TimeSpan delay, TRequest @event, RequestContext? requestContext = null)
        where TRequest : class, IRequest
    {
        queue.Enqueue(new(CommandType.Publish, new PublishRecord(@event, requestContext, Delay: delay)));
        return $"Publish: {@event.Id}";
    }

    public Task PublishAsync<TRequest>(TRequest @event, RequestContext? requestContext = null, bool continueOnCapturedContext = true, Cancel cancel = default)
        where TRequest : class, IRequest
    {
        queue.Enqueue(new(CommandType.Publish, new PublishRecord(@event, requestContext, continueOnCapturedContext)));
        return Task.CompletedTask;
    }

    public Task<string> PublishAsync<TRequest>(DateTimeOffset at, TRequest @event, RequestContext? requestContext = null, bool continueOnCapturedContext = true, Cancel cancel = default)
        where TRequest : class, IRequest
    {
        queue.Enqueue(new(CommandType.Publish, new PublishRecord(@event, requestContext, continueOnCapturedContext, At: at)));
        return Task.FromResult($"Publish: {@event.Id}");
    }

    public Task<string> PublishAsync<TRequest>(TimeSpan delay, TRequest @event, RequestContext? requestContext = null, bool continueOnCapturedContext = true, Cancel cancel = default)
        where TRequest : class, IRequest
    {
        queue.Enqueue(new(CommandType.Publish, new PublishRecord(@event, requestContext, continueOnCapturedContext, Delay: delay)));
        return Task.FromResult($"Publish: {@event.Id}");
    }
}