namespace VerifyTests.Brighter;

public record ClearOutboxRecord()
{
    public RequestContext? Context { get; }
    public int? AmountToClear { get; }
    public int? MinimumAge { get; }
    public bool? UseBulk { get; }
    public Dictionary<string,object>? Args { get; }
    public IReadOnlyCollection<Id>? Posts { get; }

    public ClearOutboxRecord(IEnumerable<Id> posts, RequestContext? context) : this()
    {
        Context = context;
        Posts = posts.ToArray();
    }

    public ClearOutboxRecord(int amountToClear, int minimumAge, bool useBulk, Dictionary<string,object>? args) :
        this()
    {
        AmountToClear = amountToClear;
        MinimumAge = minimumAge;
        UseBulk = useBulk;
        Args = args;
    }
}