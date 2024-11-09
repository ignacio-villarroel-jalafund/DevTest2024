public record RequestOptionsDTO
(
    string Name
)
{
    public static Options ToDomain(RequestOptionsDTO optionsDTO)
    {
        return new Options{
            Name = optionsDTO.Name
        };
    }
}