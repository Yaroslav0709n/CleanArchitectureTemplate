using CleanArchitecture.Application.Abstractions.Messaging;
using CleanArchitecture.Application.Users.Dto;

namespace Application.Users.GetById;

public sealed record GetUserByIdQuery(Guid UserId) : IQuery<UserResponse>;
