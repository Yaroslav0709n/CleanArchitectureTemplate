using System.Net;

namespace CleanArchitecture.Application.Exceptions;

public class UnauthorizedException : CustomException
{
    public UnauthorizedException(string message) : base(message, null, HttpStatusCode.Unauthorized)
    {
    }
}