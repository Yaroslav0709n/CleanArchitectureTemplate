using CleanArchitecture.Application.Abstractions.Messaging;
using CleanArchitecture.Application.Users.Dto;

namespace CleanArchitecture.Application.Users.GetByEmail;

public sealed record GetUserByEmailQuery(string Email) : IQuery<UserResponse>;
