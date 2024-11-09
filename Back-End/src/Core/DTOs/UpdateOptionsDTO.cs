public record UpdateOptionsDTO
(
    string Name,
    int Votes
)
{
    public static Options ToDomain(UpdateOptionsDTO optionsDTO)
    {
        return new Options{
            Name = optionsDTO.Name,
            Votes = optionsDTO.Votes
        };
    }
}