
public class PollRepositoryMemory : IPollRepository
{
    private readonly List<Poll> _polls;

    public PollRepositoryMemory()
    {
        _polls = new List<Poll>();
    }

    public Task<Poll?> Create(Poll item)
    {
        _polls.Add(item);
        Console.WriteLine(item.Options[0].Name + "asdas");
        return Task.FromResult(item);
    }

    public Task<bool> Delete(int id)
    {
        var pollToDelete = _polls.FirstOrDefault(poll => poll.Id.Equals(id));
        if (pollToDelete != null)
        {
            _polls.Remove(pollToDelete);
            return Task.FromResult(true);
        }
        return Task.FromResult(false);
    }

    public Task<List<Poll>> GetAll()
    {
        return Task.FromResult(_polls);
    }

    public Task<Poll?> GetById(int id)
    {
        var existingPoll = _polls.FirstOrDefault(poll => poll.Id.Equals(id));
        return Task.FromResult(existingPoll);
    }

    public Task<Poll?> Update(int id, Poll item)
    {
        var pollToUpdate = _polls.FirstOrDefault(poll => poll.Id.Equals(id));
        if (pollToUpdate == null)
        {
            return Task.FromResult(pollToUpdate);
        }
        pollToUpdate.Name = item.Name;
        pollToUpdate.Options = item.Options;

        return Task.FromResult(pollToUpdate);
    }
}
