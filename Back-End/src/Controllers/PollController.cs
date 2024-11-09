using Microsoft.AspNetCore.Mvc;

public class PollController : BaseController
{
    private readonly IPollService _pollService;

    public PollController(IPollService pollService)
    {
        _pollService = pollService;
    }

    [HttpPost]
    [ProducesResponseType(typeof(ResponsePollDTO), statusCode: StatusCodes.Status201Created)]
    [ProducesResponseType(statusCode: StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> AddPoll([FromBody] RequestPollDTO requestPollDTO)
    {
        var newPoll = await _pollService.CreatePoll(requestPollDTO);
        var response = ResponsePollDTO.FromDomain(newPoll);
        return Ok(response);
    }



    [HttpGet]
    [ProducesResponseType(typeof(ResponsePollDTO), statusCode: StatusCodes.Status200OK)]
    public async Task<ActionResult> GetPolls()
    {
        var result = await _pollService.GetAllPolls();
        result.Select(poll => Console.WriteLine(poll.Options));
        var response = result.Select(poll => ResponsePollDTO.FromDomain(poll));
        return Ok(response);
    }

}