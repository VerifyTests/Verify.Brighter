class DepositPostRecordConverter :
    WriteOnlyJsonConverter<DepositPostRecord>
{
    public override void Write(VerifyJsonWriter writer, DepositPostRecord record)
    {
        writer.WriteStartObject();
        writer.WriteMember(record, record.Requests, "Requests");
        writer.WriteMember(record, record.Context, "Context");
        writer.WriteMember(record, record.Args, "Args");
        writer.WriteMember(record, record.ContinueOnCapturedContext, "ContinueOnCapturedContext");
        writer.WriteEndObject();
    }
}