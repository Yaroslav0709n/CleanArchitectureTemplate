using CleanArchitecture.Application.Abstractions.Dispatchers;
using CleanArchitecture.Application.Dtos.Addresses;
using CleanArchitecture.Application.Organizations.Create;
using CleanArchitecture.Application.Organizations.Delete;
using CleanArchitecture.Application.Organizations.Get;
using CleanArchitecture.Application.Organizations.GetById;
using CleanArchitecture.Application.Organizations.Update;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.Api.Controllers;

public class OrganizationController : VersionedApiController
{
    private readonly IQueryDispatcher _queryDispatcher;
    private readonly ICommandDispatcher _commandDispatcher;

    public OrganizationController(IQueryDispatcher queryDispatcher, ICommandDispatcher commandDispatcher)
    {
        _queryDispatcher = queryDispatcher;
        _commandDispatcher = commandDispatcher;
    }

    [HttpGet]
    public async Task<IEnumerable<OrganizationResponse>> GetListAsync(CancellationToken cancellationToken)
    {
        return await _queryDispatcher.Dispatch<GetOrganizationsQuery, IEnumerable<OrganizationResponse>>(new GetOrganizationsQuery(), cancellationToken);
    }

    [HttpGet("{id:guid}")]
    public async Task<OrganizationResponse> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var query = new GetOrganizationByIdQuery(id);

        return await _queryDispatcher.Dispatch<GetOrganizationByIdQuery, OrganizationResponse>(query, cancellationToken);
    }

    [HttpPost]
    public async Task<Guid> CreateAsync([FromBody] CreateOrganizationCommand command, CancellationToken cancellationToken)
    {
        return await _commandDispatcher.Dispatch<CreateOrganizationCommand, Guid>(command, cancellationToken);
    }

    [HttpPut]
    public async Task<Guid> UpdateAsync([FromBody] UpdateOrganizationCommand command, CancellationToken cancellationToken)
    {
        return await _commandDispatcher.Dispatch<UpdateOrganizationCommand, Guid>(command, cancellationToken);
    }

    [HttpDelete("{id:guid}")]
    public async Task DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        await _commandDispatcher.Dispatch(new DeleteOrganizationCommand(id), cancellationToken);
    }
}
