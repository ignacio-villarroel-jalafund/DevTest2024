public record RequestPollDTO
(
    string Name,
    List<Options> Options
)
{
    public static Poll ToDomain(RequestPollDTO pollDTO)
    {
        return new Poll
        {
            Name = pollDTO.Name,
            Options = pollDTO.Options
        };
    }
}