using CleanArchitecture.Application.Dtos.Tokens;

namespace CleanArchitecture.Application.Abstractions.Token;

public interface ITokenProvider
{
    Task<string> Create(CreateTokenRequest request);
}