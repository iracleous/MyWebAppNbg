namespace NbgApi.Security;

using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using DomainProject.Data;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

public class ApiKeyAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
{
    private const string ApiKeyName = "ApiKey";
    private readonly ILogger<ApiKeyAuthenticationHandler> _logger;
    private readonly string _apiKey;
    private readonly string _secret;
    private readonly string _token;
    private readonly string _tokenSecret;
    private readonly EshopDbContext _dbContext;

    public ApiKeyAuthenticationHandler(IOptionsMonitor<AuthenticationSchemeOptions> options,
                                        ILoggerFactory logger,
                                        UrlEncoder encoder)
        : base(options, logger, encoder)
    {
    }

    protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
    {
        
        if (!Request.Headers.TryGetValue("Authorization", out _))
            return AuthenticateResult.Fail("No authorization header");

        try
        {
            var vv = Request.Headers;
            
            var authHeader = AuthenticationHeaderValue.Parse(vv.Authorization);
            var credentialBytes = Convert.FromBase64String(authHeader.Parameter);
            var credentials = Encoding.UTF8.GetString(credentialBytes).Split([ ':' ], 2);
            var username = credentials[0];
            var password = credentials[1];

            if (await YourMethodToValidateUserNameAndPasswordAsync(username, password))
            {
                var claims = new[] { new Claim(ClaimTypes.Name, username) };
                var identity = new ClaimsIdentity(claims, Scheme.Name);
                var principal = new ClaimsPrincipal(identity);
                var ticket = new AuthenticationTicket(principal, Scheme.Name);
            }
      }   
        catch { }

        return AuthenticateResult.Fail("Unauthorized user");
    }

    private async Task<bool> YourMethodToValidateUserNameAndPasswordAsync(string username, string password)
    {
        var user = await _dbContext.Users
            .FirstOrDefaultAsync(u => u.Username == username && u.Password == password);

        return user != null;
    }

    private static bool IsValidApiKey(string apiKey)
    {
        // TODO: Implement your API key validation logic here
        // Example: Check against a list of valid keys or validate from a database
        return apiKey == "YourSecretApiKey";
    }
}
