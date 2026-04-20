namespace CleanCarApi.Infrastructure.Settings;

// Representerar JWT-sektionen i appsettings.json
// Används med Options-pattern istället för IConfiguration direkt
public class JwtSettings
{
    public string Key { get; set; } = string.Empty;
    public string Issuer { get; set; } = string.Empty;
    public string Audience { get; set; } = string.Empty;
}
