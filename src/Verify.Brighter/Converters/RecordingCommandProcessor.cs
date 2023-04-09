using Paramore.Brighter;

namespace VerifyTests.Brighter;

public class RecordingCommandProcessor :
    IAmACommandProcessor
{
    
    public void Send<T>(T command)
        where T : class, IRequest =>
        throw new NotImplementedException();

    public Task SendAsync<T>(T command, bool continueOnCapturedContext = false, CancellationToken cancellation = default)
        where T : class, IRequest =>
        throw new NotImplementedException();

    public void Publish<T>(T @event)
        where T : class, IRequest =>
        throw new NotImplementedException();

    public Task PublishAsync<T>(T @event, bool continueOnCapturedContext = false, CancellationToken cancellation = default)
        where T : class, IRequest =>
        throw new NotImplementedException();

    public void Post<T>(T request)
        where T : class, IRequest =>
        throw new NotImplementedException();

    public Task PostAsync<T>(T request, bool continueOnCapturedContext = false, CancellationToken cancellation = default)
        where T : class, IRequest =>
        throw new NotImplementedException();

    public Guid DepositPost<T>(T request)
        where T : class, IRequest =>
        throw new NotImplementedException();

    public Guid[] DepositPost<T>(IEnumerable<T> requests)
        where T : class, IRequest =>
        throw new NotImplementedException();

    public Task<Guid> DepositPostAsync<T>(T request, bool continueOnCapturedContext = false, CancellationToken cancellation = default)
        where T : class, IRequest =>
        throw new NotImplementedException();

    public Task<Guid[]> DepositPostAsync<T>(IEnumerable<T> requests, bool continueOnCapturedContext = false, CancellationToken cancellation = default)
        where T : class, IRequest =>
        throw new NotImplementedException();

    public void ClearOutbox(params Guid[] posts) =>
        throw new NotImplementedException();

    public void ClearOutbox(int amountToClear = 100, int minimumAge = 5000, Dictionary<string, object>? args = null) =>
        throw new NotImplementedException();

    public Task ClearOutboxAsync(IEnumerable<Guid> posts, bool continueOnCapturedContext = false, CancellationToken cancellation = default) =>
        throw new NotImplementedException();

    public void ClearAsyncOutbox(int amountToClear = 100, int minimumAge = 5000, bool useBulk = false, Dictionary<string, object>? args = null) =>
        throw new NotImplementedException();

    public TResponse Call<T, TResponse>(T request, int timeOutInMilliseconds)
        where T : class, ICall where TResponse : class, IResponse =>
        throw new NotImplementedException();
}
