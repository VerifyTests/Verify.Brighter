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

    static List<JsonConverter> converters = new()
    {
        new RecordingCommandProcessorConverter(),
        new ClearOutboxRecordConverter(),
        new CallRecordConverter()
    };
}