using Paramore.Brighter;
using VerifyTests.Brighter;
// ReSharper disable ArrangeObjectCreationWhenTypeNotEvident

[UsesVerify]
public class Tests
{
    #region HandlerTest

    [Fact]
    public async Task HandlerTest()
    {
        var context = new RecordingCommandProcessor();
        var handler = new Handler(context);
        await handler.Handle(new Message("value"));
        await Verify(context);
    }

    #endregion

    [Fact]
    public async Task AllTest()
    {
        var context = new RecordingCommandProcessor();
        var handler = new AllHandler(context);
        await handler.Handle(new Message("value"));
        await Verify(context);
    }
}

#region Handler

public class Handler: RequestHandlerAsync<Message>
{
    IAmACommandProcessor commandProcessor;

    public Handler(IAmACommandProcessor commandProcessor) =>
        this.commandProcessor = commandProcessor;

    public async Task<Message> Handle(Message message)
    {
        await commandProcessor.SendAsync(new Response("Property Value"));

        return await base.HandleAsync(message);
    }
}

#endregion

public class AllHandler : RequestHandlerAsync<Message>
{
    RecordingCommandProcessor commandProcessor;

    public AllHandler(RecordingCommandProcessor commandProcessor) =>
        this.commandProcessor = commandProcessor;

    public async Task<Message> Handle(Message message)
    {
        await commandProcessor.SendAsync(new Response("Property Value"));
        return await base.HandleAsync(message);
    }
}