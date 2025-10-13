namespace VerifyTests.Brighter;

public partial class RecordingCommandProcessor
{
    public void Send<TRequest>(TRequest command, RequestContext? requestContext = null)
        where TRequest : class, IRequest =>
        queue.Enqueue(new(CommandType.Send, new SendRecord(command, requestContext)));

    public string Send<TRequest>(DateTimeOffset at, TRequest command, RequestContext? requestContext = null)
        where TRequest : class, IRequest
    {
        queue.Enqueue(new(CommandType.Send, new SendRecord(command, requestContext)));
        return $"Send: {command.Id}";
    }

    public string Send<TRequest>(TimeSpan delay, TRequest command, RequestContext? requestContext = null)
        where TRequest : class, IRequest
    {
        queue.Enqueue(new(CommandType.Send, new SendRecord(command, requestContext)));
        return $"Send: {command.Id}";
    }

    public Task SendAsync<TRequest>(TRequest command, RequestContext? requestContext = null, bool continueOnCapturedContext = true, Cancel cancel = default)
        where TRequest : class, IRequest
    {
        queue.Enqueue(new(CommandType.Send, new SendRecord(command, requestContext, continueOnCapturedContext)));
        return Task.FromResult($"Send: {command.Id}");
    }

    public Task<string> SendAsync<TRequest>(DateTimeOffset at, TRequest command, RequestContext? requestContext = null, bool continueOnCapturedContext = true, Cancel cancel = default)
        where TRequest : class, IRequest
    {
        queue.Enqueue(new(CommandType.Send, new SendRecord(command, requestContext, continueOnCapturedContext, At: at)));
        return Task.FromResult($"Send: {command.Id}");
    }

    public Task<string> SendAsync<TRequest>(TimeSpan delay, TRequest command, RequestContext? requestContext = null, bool continueOnCapturedContext = true, Cancel cancel = default)
        where TRequest : class, IRequest
    {
        queue.Enqueue(new(CommandType.Send, new SendRecord(command, requestContext, continueOnCapturedContext, Delay: delay)));
        return Task.FromResult($"Send: {command.Id}");
    }

    public IEnumerable<SendRecord> Sends =>
        queue.Where(_ => _.type is CommandType.Send)
            .Select(_ => _.record)
            .Cast<SendRecord>();
}