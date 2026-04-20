using CleanCarApi.Application.Auth;
using CleanCarApi.Application.Interfaces;
using MediatR;

namespace CleanCarApi.Application.Auth.Handlers;

// Hanterar registrering — delegerar till IAuthService som vet hur Identity fungerar
public class RegisterHandler : IRequestHandler<RegisterCommand, string>
{
    private readonly IAuthService _authService;

    public RegisterHandler(IAuthService authService)
    {
        _authService = authService;
    }

    public async Task<string> Handle(
        RegisterCommand request,
        CancellationToken cancellationToken)
    {
        return await _authService.RegisterAsync(
            request.Dto.Username,
            request.Dto.Password,
            request.Dto.Role);
    }
}