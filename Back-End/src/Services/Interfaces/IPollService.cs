public interface IPollService 
{
    Task<Poll> CreatePoll(RequestPollDTO pollDTO);
    Task<List<Poll>> GetAllPolls();
    Task<Poll?> GetPollById(int id);
    Task<Poll> UpdatePoll(int id, RequestPollDTO pollDTO);
    Task<bool> DeletePoll(int id);
}