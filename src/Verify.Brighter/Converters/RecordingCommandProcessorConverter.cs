using SimpleInfoName;

class RecordingCommandProcessorConverter :
    WriteOnlyJsonConverter<RecordingCommandProcessor>
{
    public override void Write(VerifyJsonWriter writer, RecordingCommandProcessor processor)
    {
        writer.WriteStartObject();
        foreach (var (type, record) in processor.queue)
        {
            switch (type)
            {
                case RecordingCommandProcessor.CommandType.Send:
                case RecordingCommandProcessor.CommandType.Publish:
                case RecordingCommandProcessor.CommandType.Post:
                case RecordingCommandProcessor.CommandType.Deposit:
                    writer.WriteMember(processor, record, $"{type.ToString()}: {record.GetType().SimpleName()}");
                    break;
                case RecordingCommandProcessor.CommandType.Clear:
                    var clearOutboxRecord = (ClearOutboxRecord) record;
                    writer.WriteMember(processor, clearOutboxRecord, "Clear");
                    break;
                case RecordingCommandProcessor.CommandType.Call:
                    var callRecord = (CallRecord) record;
                    writer.WriteMember(processor, callRecord, "Call");
                    break;
            }
        }
        writer.WriteEndObject();
    }
}