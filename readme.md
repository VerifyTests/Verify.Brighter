# <img src="/src/icon.png" height="30px"> Verify.Wolverine

[![Discussions](https://img.shields.io/badge/Verify-Discussions-yellow?svg=true&label=)](https://github.com/orgs/VerifyTests/discussions)
[![Build status](https://ci.appveyor.com/api/projects/status/ddi2145ncdpw0wx0?svg=true)](https://ci.appveyor.com/project/SimonCropp/Verify-Brighter)
[![NuGet Status](https://img.shields.io/nuget/v/Verify.Brighter.svg)](https://www.nuget.org/packages/Verify.Brighter/)

Adds [Verify](https://github.com/VerifyTests/Verify) support for verifying [Brighter](https://www.goparamore.io/) via a custom test context.


## NuGet package

https://nuget.org/packages/Verify.Brighter/


## Usage

<!-- snippet: Enable -->
<a id='snippet-enable'></a>
```cs
[ModuleInitializer]
public static void Init() =>
    VerifyBrighter.Initialize();
```
<sup><a href='/src/Tests/ModuleInitializer.cs#L3-L9' title='Snippet source file'>snippet source</a> | <a href='#snippet-enable' title='Start of snippet'>anchor</a></sup>
<!-- endSnippet -->


## Handler

Given the handler:

<!-- snippet: Handler -->
<a id='snippet-handler'></a>
```cs
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
```
<sup><a href='/src/Tests/Tests.cs#L31-L48' title='Snippet source file'>snippet source</a> | <a href='#snippet-handler' title='Start of snippet'>anchor</a></sup>
<!-- endSnippet -->


## Test

Pass in instance of `RecordingMessageContext` in to the `Handle` method and then `Verify` that instance.

<!-- snippet: HandlerTest -->
<a id='snippet-handlertest'></a>
```cs
[Fact]
public async Task HandlerTest()
{
    var context = new RecordingCommandProcessor();
    var handler = new Handler(context);
    await handler.Handle(new Message("value"));
    await Verify(context);
}
```
<sup><a href='/src/Tests/Tests.cs#L8-L19' title='Snippet source file'>snippet source</a> | <a href='#snippet-handlertest' title='Start of snippet'>anchor</a></sup>
<!-- endSnippet -->

Will result in:

<!-- snippet: Tests.HandlerTest.verified.txt -->
<a id='snippet-Tests.HandlerTest.verified.txt'></a>
```txt
{
  Calls: [],
  Deposits: [],
  Posts: [],
  Publishes: [],
  Sends: [
    {
      Property: Property Value
    }
  ]
}
```
<sup><a href='/src/Tests/Tests.HandlerTest.verified.txt#L1-L11' title='Snippet source file'>snippet source</a> | <a href='#snippet-Tests.HandlerTest.verified.txt' title='Start of snippet'>anchor</a></sup>
<!-- endSnippet -->


## Icon

[Wolverine](https://thenounproject.com/term/wolverine/3386573/) designed by [Phạm Thanh Lộc](https://thenounproject.com/thanhloc1009/) from [The Noun Project](https://thenounproject.com/).
