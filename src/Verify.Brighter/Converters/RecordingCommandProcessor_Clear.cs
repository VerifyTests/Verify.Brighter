﻿namespace VerifyTests.Brighter;

public partial class RecordingCommandProcessor
{
    public void ClearOutbox(int amountToClear = 100, int minimumAge = 5000, Dictionary<string, object>? args = null) =>
        queue.Enqueue(new(CommandType.Clear, new ClearOutboxRecord(amountToClear, minimumAge, false, args)));

    public Task ClearOutboxAsync(int amountToClear = 100, int minimumAge = 5000, Dictionary<string, object>? args = null)
    {
        queue.Enqueue(new(CommandType.Clear, new ClearOutboxRecord(amountToClear, minimumAge, false, args)));
        return Task.CompletedTask;
    }

    public void ClearAsyncOutbox(int amountToClear = 100, int minimumAge = 5000, bool useBulk = false, Dictionary<string, object>? args = null) =>
        queue.Enqueue(new(CommandType.Clear, new ClearOutboxRecord(amountToClear, minimumAge, useBulk, args)));

    public Task ClearAsyncOutboxAsync(int amountToClear = 100, int minimumAge = 5000, bool useBulk = false, Dictionary<string, object>? args = null)
    {
        queue.Enqueue(new(CommandType.Clear, new ClearOutboxRecord(amountToClear, minimumAge, useBulk, args)));
        return Task.CompletedTask;
    }

    public void ClearOutbox(params Guid[] posts) =>
        queue.Enqueue(new(CommandType.Clear, new ClearOutboxRecord(posts)));

    public Task ClearOutboxAsync(IEnumerable<Guid> posts, bool continueOnCapturedContext = false, Cancel cancel = default)
    {
        queue.Enqueue(new(CommandType.Clear, new ClearOutboxRecord(posts)));
        return Task.CompletedTask;
    }
}