using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using User.API.DTO;
using User.UseCases.Requests.Activities;
using User.UseCases.Responses;
using User.UseCases.Services.Interfaces;

namespace User.API.Controllers;

[ApiController]
[Route("api/activity")]
public class UserController : ControllerBase
{
    private readonly ILogger<UserController> _logger;
    private readonly IUserService _service;
    private readonly IMapper _mapper;

    public UserController(IUserService service, ILogger<UserController> logger, IMapper mapper)
    {
        _service = service;
        _logger = logger;
        _mapper = mapper;
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<UserDTO>> GetUserById([FromRoute] Guid id)
    {
        var activity = await _service.GetUserById(id);
        if (activity == null)
        {
            return NotFound();
        }

        return Ok(_mapper.Map<UserDTO>(activity));
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<UserDTO>>> GetUsers([FromRoute] GetActivitiesRequest request)
    {
        return Ok(_mapper.Map<UserDTO[]>(await _service.GetUsers(request.SearchValue, request.Page, request.PageSize)));
    }

    [HttpPost]
    public async Task<ActionResult<AddUserResponse>> AddUser([FromBody] AddUserRequest request)
    {
        AddUserResponse response = await _service.AddUser(request);
        if (response.FailureReason == null)
        {
            return Ok();
        }

        if (response.FailureType == FailureType.User)
        {
            return BadRequest(response);
        }

        return StatusCode(500, response);
    }

    [HttpDelete]
    public async Task<ActionResult> DeleteUser(Guid id)
    {
        if (await _service.DeleteUser(id))
            return Ok();
        return NotFound();
    }
}