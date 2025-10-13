class ClearOutboxRecordConverter :
    WriteOnlyJsonConverter<ClearOutboxRecord>
{
    public override void Write(VerifyJsonWriter writer, ClearOutboxRecord record)
    {
        writer.WriteStartObject();
        writer.WriteMember(record, record.AmountToClear, "AmountToClear");
        writer.WriteMember(record, record.MinimumAge, "MinimumAge");
        writer.WriteMember(record, record.UseBulk, "UseBulk");
        writer.WriteMember(record, record.Args, "Args");
        writer.WriteMember(record, record.Posts, "Posts");
        writer.WriteMember(record, record.Context, "Context");
        writer.WriteEndObject();
    }
}