class CallRecordConverter :
    WriteOnlyJsonConverter<CallRecord>
{
    public override void Write(VerifyJsonWriter writer, CallRecord record)
    {
        writer.WriteStartObject();
        writer.WriteMember(record, record.Request, "Request");
        writer.WriteMember(record, record.Context, "Context");
        writer.WriteMember(record, record.ResponseType, "ResponseType");
        writer.WriteMember(record, record.TimeOut, "TimeOut");
        writer.WriteEndObject();
    }
}