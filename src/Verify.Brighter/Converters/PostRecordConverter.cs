class PostRecordConverter :
    WriteOnlyJsonConverter<PostRecord>
{
    public override void Write(VerifyJsonWriter writer, PostRecord record)
    {
        writer.WriteStartObject();
        writer.WriteMember(record, record.Request, "Request");
        writer.WriteMember(record, record.Context, "Context");
        writer.WriteMember(record, record.Args, "Args");
        writer.WriteMember(record, record.Delay, "Delay");
        writer.WriteMember(record, record.At, "At");
        writer.WriteMember(record, record.ContinueOnCapturedContext, "ContinueOnCapturedContext");
        writer.WriteEndObject();
    }
}