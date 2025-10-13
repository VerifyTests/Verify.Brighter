namespace VerifyTests.Brighter;

public partial class RecordingCommandProcessor
{
    public IEnumerable<PostRecord> Posts =>
        queue.Where(_ => _.type is CommandType.Post)
            .Select(_ => _.record)
            .Cast<PostRecord>();

    public void Post<TRequest>(TRequest request, RequestContext? requestContext = null, Dictionary<string, object>? args = null)
        where TRequest : class, IRequest =>
        queue.Enqueue(new(CommandType.Publish, new PostRecord(request, requestContext, args)));

    public string Post<TRequest>(DateTimeOffset at, TRequest request, RequestContext? requestContext = null, Dictionary<string, object>? args = null)
        where TRequest : class, IRequest
    {
        queue.Enqueue(new(CommandType.Publish, new PostRecord(request, requestContext, args, At: at)));
        return $"Post: {request.Id}";
    }

    public string Post<TRequest>(TimeSpan delay, TRequest request, RequestContext? requestContext = null, Dictionary<string, object>? args = null)
        where TRequest : class, IRequest
    {
        queue.Enqueue(new(CommandType.Publish, new PostRecord(request, requestContext, args, Delay: delay)));
        return $"Post: {request.Id}";
    }

    public Task PostAsync<TRequest>(TRequest request, RequestContext? requestContext = null, Dictionary<string, object>? args = null, bool continueOnCapturedContext = true, Cancel cancel = default)
        where TRequest : class, IRequest
    {
        queue.Enqueue(new(CommandType.Publish, new PostRecord(request, requestContext, args, continueOnCapturedContext)));
        return Task.CompletedTask;
    }

    public Task<string> PostAsync<TRequest>(DateTimeOffset at, TRequest request, RequestContext? requestContext = null, Dictionary<string, object>? args = null, bool continueOnCapturedContext = true, Cancel cancel = default)
        where TRequest : class, IRequest
    {
        queue.Enqueue(new(CommandType.Publish, new PostRecord(request, requestContext, args, continueOnCapturedContext, At: at)));
        return Task.FromResult($"Post: {request.Id}");
    }

    public Task<string> PostAsync<TRequest>(TimeSpan delay, TRequest request, RequestContext? requestContext = null, Dictionary<string, object>? args = null, bool continueOnCapturedContext = true, Cancel cancel = default)
        where TRequest : class, IRequest
    {
        queue.Enqueue(new(CommandType.Publish, new PostRecord(request, requestContext, args, continueOnCapturedContext, Delay: delay)));
        return Task.FromResult($"Post: {request.Id}");
    }
}