using CleanArchitecture.Application.Abstractions.Dispatchers;
using CleanArchitecture.Application.Dtos.Users;
using CleanArchitecture.Application.Users.GetByEmail;
using CleanArchitecture.Application.Users.GetById;
using CleanArchitecture.Application.Users.Login;
using CleanArchitecture.Application.Users.Register;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.Api.Controllers;

public class UserController : VersionedApiController
{
    private readonly IQueryDispatcher _queryDispatcher;
    private readonly ICommandDispatcher _commandDispatcher;

    public UserController(IQueryDispatcher queryDispatcher, ICommandDispatcher commandDispatcher)
    {
        _queryDispatcher = queryDispatcher;
        _commandDispatcher = commandDispatcher;
    }

    [HttpGet]
    public async Task<UserResponse> GetByEmailAsync(string email, CancellationToken cancellationToken)
    {
        var query = new GetUserByEmailQuery(email);

        return await _queryDispatcher.Dispatch<GetUserByEmailQuery, UserResponse>(query, cancellationToken);
    }

    [HttpGet("{id:guid}")]
    public async Task<UserResponse> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var query = new GetUserByIdQuery(id);

        return await _queryDispatcher.Dispatch<GetUserByIdQuery, UserResponse>(query, cancellationToken);
    }

    [HttpPost("login")]
    public async Task<string> LoginAsync([FromBody] LoginUserCommand command, CancellationToken cancellationToken)
    {
        return await _commandDispatcher.Dispatch<LoginUserCommand, string>(command, cancellationToken);
    }

    [HttpPost("register")]
    public async Task RegisterAsync([FromBody] RegisterUserCommand command, CancellationToken cancellationToken)
    {
        await _commandDispatcher.Dispatch(command, cancellationToken);
    }
}
