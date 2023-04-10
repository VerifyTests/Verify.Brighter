using Paramore.Brighter;
using VerifyTests.Brighter;
// ReSharper disable ArrangeObjectCreationWhenTypeNotEvident
// ReSharper disable MethodSupportsCancellation

[UsesVerify]
public class Tests
{
    #region HandlerTest

    [Fact]
    public async Task HandlerTest()
    {
        var context = new RecordingCommandProcessor();
        var handler = new Handler(context);
        await handler.HandleAsync(new Message("value"));
        await Verify(context);
    }

    #endregion

    [Fact]
    public async Task AllTest()
    {
        var context = new RecordingCommandProcessor();
        var handler = new AllHandler(context);
        await handler.HandleAsync(new Message("value"));
        await Verify(context);
    }
}

#region Handler

public class Handler: RequestHandlerAsync<Message>
{
    IAmACommandProcessor processor;

    public Handler(IAmACommandProcessor processor) =>
        this.processor = processor;

    public override async Task<Message> HandleAsync(
        Message message,
        CancellationToken cancellation = default)
    {
        await processor.SendAsync(new MyCommand("Some data"));
        await processor.PublishAsync(new MyEvent("Some other data"));

        return await base.HandleAsync(message);
    }
}

#endregion

public class AllHandler : RequestHandlerAsync<Message>
{
    RecordingCommandProcessor processor;

    public AllHandler(RecordingCommandProcessor processor) =>
        this.processor = processor;

    public override async Task<Message> HandleAsync(Message message, CancellationToken cancellationToken = default)
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