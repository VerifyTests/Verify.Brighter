namespace VerifyTests.Brighter;

public partial class RecordingCommandProcessor
{
    public Guid DepositPost<T>(T request)
        where T : class, IRequest
    {
        queue.Enqueue(new(CommandType.Deposit, request));
        return Guid.Empty;
    }

    public Guid[] DepositPost<T>(IEnumerable<T> requests)
        where T : class, IRequest =>
        requests.Select(DepositPost).ToArray();

    public Task<Guid> DepositPostAsync<T>(T request, bool continueOnCapturedContext = false, Cancel cancel = default)
        where T : class, IRequest =>
        Task.FromResult(DepositPost(request));

    public Task<Guid[]> DepositPostAsync<T>(IEnumerable<T> requests, bool continueOnCapturedContext = false, Cancel cancel = default)
        where T : class, IRequest =>
        Task.FromResult(DepositPost(requests));

    public IEnumerable<IRequest> Deposits =>
        queue.Where(_ => _.type is CommandType.Deposit)
            .Select(_ => _.record)
            .Cast<IRequest>();
}