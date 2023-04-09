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
    RecordingCommandProcessor processor;

    public AllHandler(RecordingCommandProcessor processor) =>
        this.processor = processor;

    public async Task<Message> Handle(Message message)
    {
        processor.Send(new Response("Send Value"));
        processor.Post(new Response("Post Value"));
        processor.Publish(new Response("Publish Value"));
        processor.DepositPost(new Response("Publish Value"));
        processor.ClearOutbox();
        processor.Call<Call, Response>(new Call(), 10);
        return await base.HandleAsync(message);
    }
}

public class Call : ICall
{
    public Guid Id { get; set; }
    public Activity Span { get; set; } = null!;
    public ReplyAddress ReplyAddress { get; } = null!;
}