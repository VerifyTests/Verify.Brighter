namespace VerifyTests.Brighter;

public partial class RecordingCommandProcessor :
    IAmACommandProcessor
{
    internal enum CommandType
    {
        Send,
        Publish,
        Post,
        Deposit,
        Clear,
        Call
    }

    internal ConcurrentQueue<(CommandType type, object record)> queue = [];
}