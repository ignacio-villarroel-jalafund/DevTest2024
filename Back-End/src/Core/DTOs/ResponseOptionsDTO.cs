public record ResponseOptionsDTO
(
    string Name
)
{
    public static ResponseOptionsDTO FromDomain(Options options)
    {
        return new ResponseOptionsDTO(
            options.Name
        );
    }
}