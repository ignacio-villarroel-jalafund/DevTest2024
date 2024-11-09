public class Poll
{
    public int Id { get; set; }
    public required string Name { get; set; }

    public required List<Options> Options { get; set; }
}