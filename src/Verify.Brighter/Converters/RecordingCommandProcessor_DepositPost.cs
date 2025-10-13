namespace VerifyTests.Brighter;

public partial class RecordingCommandProcessor
{
    public IEnumerable<DepositPostRecord> Deposits =>
        queue.Where(_ => _.type is CommandType.Deposit)
            .Select(_ => _.record)
            .Cast<DepositPostRecord>();

    public Id DepositPost<TRequest>(TRequest request, RequestContext? requestContext = null, Dictionary<string, object>? args = null)
        where TRequest : class, IRequest
    {
        queue.Enqueue(new(CommandType.Deposit, new DepositPostRecord([request], requestContext, args)));
        return Id.Create($"DepositPost: {request.Id}");
    }

    public Id DepositPost<TRequest, TTransaction>(TRequest request, IAmABoxTransactionProvider<TTransaction> transactionProvider, RequestContext? requestContext = null, Dictionary<string, object>? args = null, string? batchId = null)
        where TRequest : class, IRequest
    {
        queue.Enqueue(new(CommandType.Deposit, new DepositPostRecord([request], requestContext, args)));
        return Id.Create($"DepositPost: {request.Id}");
    }

    public Id[] DepositPost<TRequest>(IEnumerable<TRequest> requests, RequestContext? requestContext, Dictionary<string, object>? args = null)
        where TRequest : class, IRequest
    {
        var array = requests.ToArray();
        queue.Enqueue(new(CommandType.Deposit, new DepositPostRecord(array, requestContext, args)));
        return array.Select(_ => Id.Create($"DepositPost: {_.Id}")).ToArray();
    }

    public Id[] DepositPost<TRequest, TTransaction>(IEnumerable<TRequest> requests, IAmABoxTransactionProvider<TTransaction> transactionProvider, RequestContext? requestContext = null, Dictionary<string, object>? args = null)
        where TRequest : class, IRequest
    {
        var array = requests.ToArray();
        queue.Enqueue(new(CommandType.Deposit, new DepositPostRecord(array, requestContext, args)));
        return array.Select(_ => Id.Create($"DepositPost: {_.Id}")).ToArray();
    }

    public Task<Id> DepositPostAsync<TRequest>(TRequest request, RequestContext? requestContext = null, Dictionary<string, object>? args = null, bool continueOnCapturedContext = true, Cancel cancel = default)
        where TRequest : class, IRequest
    {
        queue.Enqueue(new(CommandType.Deposit, new DepositPostRecord([request], requestContext, args, continueOnCapturedContext)));
        return Task.FromResult(Id.Create($"DepositPost: {request.Id}"));
    }

    public Task<Id> DepositPostAsync<T, TTransaction>(T request, IAmABoxTransactionProvider<TTransaction> transactionProvider, RequestContext? requestContext = null, Dictionary<string, object>? args = null, bool continueOnCapturedContext = true, Cancel cancel = default, string? batchId = null)
        where T : class, IRequest
    {
        queue.Enqueue(new(CommandType.Deposit, new DepositPostRecord([request], requestContext, args, continueOnCapturedContext)));
        return Task.FromResult(Id.Create($"DepositPost: {request.Id}"));
    }

    public Task<Id[]> DepositPostAsync<TRequest>(IEnumerable<TRequest> requests, RequestContext? requestContext = null, Dictionary<string, object>? args = null, bool continueOnCapturedContext = true, Cancel cancel = default)
        where TRequest : class, IRequest
    {
        var array = requests.ToArray();
        queue.Enqueue(new(CommandType.Deposit, new DepositPostRecord(array, requestContext, args, continueOnCapturedContext)));
        return Task.FromResult(array.Select(_ => Id.Create($"DepositPost: {_.Id}")).ToArray());
    }

    public Task<Id[]> DepositPostAsync<T, TTransaction>(IEnumerable<T> requests, IAmABoxTransactionProvider<TTransaction> transactionProvider, RequestContext? requestContext = null, Dictionary<string, object>? args = null, bool continueOnCapturedContext = true, Cancel cancel = default)
        where T : class, IRequest
    {
        var array = requests.ToArray();
        queue.Enqueue(new(CommandType.Deposit, new DepositPostRecord(array, requestContext, args, continueOnCapturedContext)));
        return Task.FromResult(array.Select(_ => Id.Create($"DepositPost: {_.Id}")).ToArray());
    }
}