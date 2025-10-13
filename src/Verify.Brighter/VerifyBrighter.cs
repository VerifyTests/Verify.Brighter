using Argon;

namespace VerifyTests;

public static class VerifyBrighter
{
    public static bool Initialized { get; private set; }

    public static void Initialize()
    {
        if (Initialized)
        {
            throw new("Already Initialized");
        }

        Initialized = true;
        VerifierSettings.AddExtraSettings(_ => _.Converters.AddRange(converters));
    }

    static List<JsonConverter> converters =
    [
        new RecordingCommandProcessorConverter(),
        new ClearOutboxRecordConverter(),
        new CallRecordConverter(),
        new SendRecordConverter(),
        new PublishRecordConverter(),
        new PostRecordConverter(),
        new DepositPostRecordConverter()
    ];
}