namespace VerifyTests.Brighter;

public partial class RecordingCommandProcessor
{
    public void Send<T>(T command)
        where T : class, IRequest =>
        queue.Enqueue(new(CommandType.Send,command));

    public Task SendAsync<T>(T command, bool continueOnCapturedContext = false, Cancel cancel = default)
        where T : class, IRequest
    {
        queue.Enqueue(new(CommandType.Send, command));
        return Task.CompletedTask;
    }

    public IEnumerable<IRequest> Sends =>
        queue.Where(_ => _.type is CommandType.Send)
            .Select(_ => _.record)
            .Cast<IRequest>();
}