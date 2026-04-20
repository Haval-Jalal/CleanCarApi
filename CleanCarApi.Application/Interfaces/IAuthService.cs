namespace CleanCarApi.Application.Interfaces;

// Abstraktion för autentisering — Application-lagret vet inte hur det implementeras
public interface IAuthService
{
    Task<string> LoginAsync(string username, string password);
    Task<string> RegisterAsync(string username, string password, string role);
}
