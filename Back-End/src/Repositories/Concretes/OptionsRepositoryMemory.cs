
public class OptionsRepositoryMemory : IOptionsRepository
{
    private readonly List<Options> _options;

    public OptionsRepositoryMemory()
    {
        _options = new List<Options>();
    }

    public Task<Options?> Create(Options item)
    {
        _options.Add(item);
        Console.WriteLine(item.Name);
        return Task.FromResult(item);
    }

    public Task<bool> Delete(int id)
    {
        var optionToDelete = _options.FirstOrDefault(option => option.Id.Equals(id));
        if (optionToDelete != null)
        {
            _options.Remove(optionToDelete);
            return Task.FromResult(true);
        }
        return Task.FromResult(false);
    }

    public Task<List<Options>> GetAll()
    {
        return Task.FromResult(_options);
    }

    public Task<Options?> GetById(int id)
    {
        var existingPoll = _options.FirstOrDefault(options => options.Id.Equals(id));
        return Task.FromResult(existingPoll);
    }

    public Task<Options?> Update(int id, Options item)
    {
        var optionToUpdate = _options.FirstOrDefault(option => option.Id.Equals(id));
        if (optionToUpdate == null)
        {
            return Task.FromResult(optionToUpdate);
        }

        optionToUpdate.Name = item.Name;

        return Task.FromResult(optionToUpdate);
    }
}
