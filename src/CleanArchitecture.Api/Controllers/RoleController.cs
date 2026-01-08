using CleanArchitecture.Application.Abstractions.Dispatchers;
using CleanArchitecture.Application.Dtos.Roles;
using CleanArchitecture.Application.Organizations.Update;
using CleanArchitecture.Application.Roles.Create;
using CleanArchitecture.Application.Roles.Delete;
using CleanArchitecture.Application.Roles.Get;
using CleanArchitecture.Application.Roles.GetById;
using CleanArchitecture.Infrastructure.Authorization;
using Microsoft.AspNetCore.Mvc;
using Action = CleanArchitecture.Infrastructure.Authorization.Action;

namespace CleanArchitecture.Api.Controllers;

public class RoleController : VersionedApiController
{
    private readonly IQueryDispatcher _queryDispatcher;
    private readonly ICommandDispatcher _commandDispatcher;

    public RoleController(IQueryDispatcher queryDispatcher, ICommandDispatcher commandDispatcher)
    {
        _queryDispatcher = queryDispatcher;
        _commandDispatcher = commandDispatcher;
    }

    [HttpGet]
    [MustHavePermission(Action.View, Resource.Roles)]
    public async Task<IEnumerable<RoleDto>> GetListAsync(CancellationToken cancellationToken)
    {
        return await _queryDispatcher.Dispatch<GetRolesQuery, IEnumerable<RoleDto>>(new GetRolesQuery(), cancellationToken);
    }

    [HttpGet("{id:guid}")]
    [MustHavePermission(Action.View, Resource.Roles)]
    public async Task<RoleDto> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var query = new GetRoleByIdQuery(id);

        return await _queryDispatcher.Dispatch<GetRoleByIdQuery, RoleDto>(query, cancellationToken);
    }

    [HttpPost]
    [MustHavePermission(Action.Create, Resource.Roles)]
    public async Task<Guid> CreateAsync([FromBody] CreateRoleCommand command, CancellationToken cancellationToken)
    {
        return await _commandDispatcher.Dispatch<CreateRoleCommand, Guid>(command, cancellationToken);
    }

    [HttpPut]
    [MustHavePermission(Action.Update, Resource.Roles)]
    public async Task<Guid> UpdateAsync([FromBody] UpdateRoleCommand command, CancellationToken cancellationToken)
    {
        return await _commandDispatcher.Dispatch<UpdateRoleCommand, Guid>(command, cancellationToken);
    }

    [HttpDelete("{id:guid}")]
    [MustHavePermission(Action.Delete, Resource.Roles)]
    public async Task DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        await _commandDispatcher.Dispatch(new DeleteRoleCommand(id), cancellationToken);
    }
}
