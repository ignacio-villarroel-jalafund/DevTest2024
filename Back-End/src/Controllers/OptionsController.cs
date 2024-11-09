using Microsoft.AspNetCore.Mvc;

public class OptionsController : BaseController
{
    private readonly IOptionsService _optionsService;

    public OptionsController(IOptionsService optionsService)
    {
        _optionsService = optionsService;
    }


    [HttpGet]
    [ProducesResponseType(typeof(ResponseOptionsDTO), statusCode: StatusCodes.Status200OK)]
    public async Task<ActionResult> GetPolls()
    {
        var response = await _optionsService.GetAllOptions();
        return Ok(response);
    }
}