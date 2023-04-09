using Paramore.Brighter;

namespace VerifyTests.Brighter;

public class RecordingCommandProcessor :
    IAmACommandProcessor
{
    enum CommandType
    {
        Send,
        Publish,
        Post,
        Deposit,
        Clear,
        Call
    }

    ConcurrentQueue<(CommandType, object)> queue = new();
    public void Send<T>(T command)
        where T : class, IRequest =>
        queue.Enqueue(new(CommandType.Send,command));

    public Task SendAsync<T>(T command, bool continueOnCapturedContext = false, CancellationToken cancellation = default)
        where T : class, IRequest
    {
        queue.Enqueue(new(CommandType.Send, command));
        return Task.CompletedTask;
    }

    public void Publish<T>(T @event)
        where T : class, IRequest =>
        queue.Enqueue(new(CommandType.Publish, @event));

    public Task PublishAsync<T>(T @event, bool continueOnCapturedContext = false, CancellationToken cancellation = default)
        where T : class, IRequest
    {
        queue.Enqueue(new(CommandType.Publish, @event));
        return Task.CompletedTask;
    }

    public void Post<T>(T request)
        where T : class, IRequest =>
        queue.Enqueue(new(CommandType.Post, request));

    public Task PostAsync<T>(T request, bool continueOnCapturedContext = false, CancellationToken cancellation = default)
        where T : class, IRequest
    {
        queue.Enqueue(new(CommandType.Post, request));
        return Task.CompletedTask;
    }

    public Guid DepositPost<T>(T request)
        where T : class, IRequest
    {
        queue.Enqueue(new(CommandType.Deposit, request));
        return Guid.Empty;
    }

    public Guid[] DepositPost<T>(IEnumerable<T> requests)
        where T : class, IRequest =>
        requests.Select(DepositPost).ToArray();

    public Task<Guid> DepositPostAsync<T>(T request, bool continueOnCapturedContext = false, CancellationToken cancellation = default)
        where T : class, IRequest =>
        Task.FromResult(DepositPost(request));

    public Task<Guid[]> DepositPostAsync<T>(IEnumerable<T> requests, bool continueOnCapturedContext = false, CancellationToken cancellation = default)
        where T : class, IRequest =>
        Task.FromResult(DepositPost(requests));

    record ClearOutboxGroup(int AmountToClear, int MinimumAge, bool UseBulk, Dictionary<string,object>? Args);

    public void ClearOutbox(int amountToClear = 100, int minimumAge = 5000, Dictionary<string, object>? args = null) =>
        queue.Enqueue(new(CommandType.Clear, new ClearOutboxGroup(amountToClear, minimumAge, false, args)));

    public void ClearAsyncOutbox(int amountToClear = 100, int minimumAge = 5000, bool useBulk = false, Dictionary<string, object>? args = null) =>
        queue.Enqueue(new(CommandType.Clear, new ClearOutboxGroup(amountToClear, minimumAge, false, args)));

    record ClearOutboxGuids(IEnumerable<Guid> Posts);

    public void ClearOutbox(params Guid[] posts) =>
        queue.Enqueue(new(CommandType.Clear, new ClearOutboxGuids(posts)));

    public Task ClearOutboxAsync(IEnumerable<Guid> posts, bool continueOnCapturedContext = false, CancellationToken cancellation = default)
    {
        queue.Enqueue(new(CommandType.Clear, new ClearOutboxGuids(posts)));
        return Task.CompletedTask;
    }

    public TResponse Call<T, TResponse>(T request, int timeOutInMilliseconds)
        where T : class, ICall where TResponse : class, IResponse =>
        throw new NotImplementedException();
}

