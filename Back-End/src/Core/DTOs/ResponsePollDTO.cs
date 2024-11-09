public record ResponsePollDTO
(
    int Id,
    string Name,
    List<Options> Options
)
{
    public static ResponsePollDTO FromDomain(Poll poll)
    {
        return new ResponsePollDTO
        (
            poll.Id,
            poll.Name,
            poll.Options
        );
    }
}