class CallRecordConverter :
    WriteOnlyJsonConverter<CallRecord>
{
    public override void Write(VerifyJsonWriter writer, CallRecord record)
    {
        writer.WriteStartObject();
        writer.WriteMember(record, record.Request, "Request");
        writer.WriteMember(record, record.ResponseType, "ResponseType");
        writer.WriteMember(record, $"{record.TimeOutInMilliseconds} ms", "TimeOut");
        writer.WriteEndObject();
    }
}