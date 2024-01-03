using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using User.API.DTO;
using User.UseCases.Entities;
using User.UseCases.Requests.User;
using User.UseCases.Responses;
using User.UseCases.Services.Interfaces;

namespace User.API.Controllers;

[ApiController]
[Route("api/user")]
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

    [HttpGet]
    [Authorize]
    public async Task<ActionResult<UserDTO>> GetUser()
    {
        var user = await _service.GetUser();
        if (user == null)
        {
            return NotFound();
        }
    
        return Ok(_mapper.Map<UserDTO>(_mapper.Map<UserEntity>(user)));
    }

    [HttpGet("search")]
    public async Task<ActionResult<IEnumerable<UserDTO>>> GetUsers([FromRoute] GetUsersRequest request)
    {
        var response = await _service.GetUsers(request.SearchValue, request.Page, request.PageSize);
        return Ok(_mapper.Map<UserDTO[]>(response.Users));
    }

    [HttpPost]
    public async Task<ActionResult<UpdateUserResponse>> UpdateUser([FromBody] UpdateUserRequest request)
    {
        UpdateUserResponse response = await _service.UpdateUser(request);
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
    public async Task<ActionResult> DeleteUser(string id)
    {
        if (await _service.DeleteUser(id))
            return Ok();
        return NotFound();
    }
}