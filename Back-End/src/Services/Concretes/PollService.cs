
public class PollService : IPollService
{
    private readonly IPollRepository _pollRepository;
    private readonly IOptionsRepository _optionsRepository;

    public PollService(IPollRepository pollRepository, IOptionsRepository optionsRepository)
    {
        _pollRepository = pollRepository;
        _optionsRepository = optionsRepository;
    }

    public async Task<Poll> CreatePoll(RequestPollDTO pollDTO)
    {
        var newPoll = new Poll{
            Name = pollDTO.Name,
            Options = pollDTO.Options
        };

        var result = await _pollRepository.Create(newPoll);
        Console.WriteLine(result.Name);
        pollDTO.Options.Select(async option => await _optionsRepository.Create(option));

        return result;
    }

    public async Task<bool> DeletePoll(int id)
    {
        return await _pollRepository.Delete(id);
    }

    public async Task<List<Poll>> GetAllPolls()
    {
        return await _pollRepository.GetAll();
    }

    public async Task<Poll?> GetPollById(int id)
    {
        var existingPoll = await _pollRepository.GetById(id);

        return existingPoll;
    }

    public Task<Poll> UpdatePoll(int id, RequestPollDTO pollDTO)
    {
        throw new NotImplementedException();
    }
}
