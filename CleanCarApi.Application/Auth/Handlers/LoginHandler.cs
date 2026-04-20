using CleanCarApi.Application.Auth;
using CleanCarApi.Application.Interfaces;
using MediatR;

namespace CleanCarApi.Application.Auth.Handlers;

// Hanterar inloggning — delegerar autentisering och token-generering till IAuthService
public class LoginHandler : IRequestHandler<LoginCommand, string>
{
    private readonly IAuthService _authService;

    public LoginHandler(IAuthService authService)
    {
        _authService = authService;
    }

    public async Task<string> Handle(
        LoginCommand request,
        CancellationToken cancellationToken)
    {
        return await _authService.LoginAsync(request.Dto.Username, request.Dto.Password);
    }
}