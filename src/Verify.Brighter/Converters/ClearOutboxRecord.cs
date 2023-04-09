namespace VerifyTests.Brighter;

public record ClearOutboxRecord()
{
    public int? AmountToClear { get; }
    public int? MinimumAge { get; }
    public bool? UseBulk { get; }
    public Dictionary<string,object>? Args { get; }
    public IReadOnlyCollection<Guid>? Posts { get; }

    public ClearOutboxRecord(IEnumerable<Guid> posts) : this() =>
        Posts = posts.ToArray();

    public ClearOutboxRecord(int amountToClear, int minimumAge, bool useBulk, Dictionary<string,object>? args) : this()
    {
        AmountToClear = amountToClear;
        MinimumAge = minimumAge;
        UseBulk = useBulk;
        Args = args;
    }
}