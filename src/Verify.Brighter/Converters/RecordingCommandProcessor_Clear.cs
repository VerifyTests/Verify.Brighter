namespace VerifyTests.Brighter;

public partial class RecordingCommandProcessor
{
    public void ClearOutbox(Id[] ids, RequestContext? requestContext = null, Dictionary<string, object>? args = null) =>
        queue.Enqueue(new(CommandType.Clear, new ClearOutboxRecord(ids, requestContext)));

    public Task ClearOutboxAsync(IEnumerable<Id> posts, RequestContext? requestContext = null, Dictionary<string, object>? args = null, bool continueOnCapturedContext = true, Cancel cancel = default)
    {
        queue.Enqueue(new(CommandType.Clear, new ClearOutboxRecord(posts, requestContext)));
        return Task.CompletedTask;
    }
}