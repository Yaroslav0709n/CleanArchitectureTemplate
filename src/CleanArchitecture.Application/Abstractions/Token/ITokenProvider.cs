using CleanArchitecture.Application.Dtos.Tokens;

namespace CleanArchitecture.Application.Abstractions.Token;

public interface ITokenProvider
{
    string Create(CreateTokenRequest request);
}