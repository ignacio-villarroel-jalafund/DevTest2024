
public class OptionsService : IOptionsService
{
    private readonly IOptionsRepository _optionsRepository;

    public OptionsService(IOptionsRepository optionsRepository)
    {
        _optionsRepository = optionsRepository;
    }

    public Task<Options> CreateOptions(RequestOptionsDTO pollDTO)
    {
        var creatOption = new Options
        {
            Name = pollDTO.Name,
            Votes = 0
        };

        var response = _optionsRepository.Create(creatOption);
        return response;
    }

    public Task<bool> DeleteOptions(int id)
    {
        throw new NotImplementedException();
    }

    public Task<List<Options>> GetAllOptions()
    {
        return _optionsRepository.GetAll();
    }

    public Task<Options?> GetOptionsById(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<Options> UpdateOptions(int id, UpdateOptionsDTO optionsDTO)
    {
        var optionToUpdate = await _optionsRepository.GetById(id);
        if (optionToUpdate == null)
        {
            throw new ArgumentException("Option not found");
        }
        optionToUpdate.Name = optionsDTO.Name;
        optionToUpdate.Votes = optionsDTO.Votes;

        await _optionsRepository.Update(id, optionToUpdate);
        return optionToUpdate;
    }
}
