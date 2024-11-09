public interface IOptionsService
{
    Task<Options> CreateOptions(RequestOptionsDTO optionsDTO);
    Task<List<Options>> GetAllOptions();
    Task<Options?> GetOptionsById(int id);
    Task<Options> UpdateOptions(int id, UpdateOptionsDTO optionsDTO);
    Task<bool> DeleteOptions(int id);
}