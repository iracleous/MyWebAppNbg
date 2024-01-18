using Azure.Identity;
using DemoJwt.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using NbgApi.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace DemoJwt.Controllers;

[ApiController]
[Route("api/[controller]")]
public class WtForSecController : ControllerBase
{
    private readonly ILogger<WtForSecController> _logger;

    public WtForSecController(ILogger<WtForSecController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    [Route("c1")]
    public IEnumerable<WeatherForecast> GetAnonymous()
    {
        _logger.Log(LogLevel.Information, "Get starts/ends");
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = WeatherForecast.Summaries[Random.Shared.Next(WeatherForecast.Summaries.Length)]
        })
        .ToArray();
    }


    [HttpGet]
    [Route("c")]
    public string GetToken([FromQuery(Name ="username")]string username, [FromQuery(Name = "password")] string password)
    {
        _logger.Log(LogLevel.Information, "GetToken starts/ends");
        return GenerateJwtToken(username, password);
    }

    /**
     * 
      
    When using from postman
    the authorization
    and the BearerToken 
    using Token as calculated before


    curl -X GET -H "Authorization: Bearer ***" https://localhost:7223/api/weatherforecast/c2


     * 
     */





    [HttpGet]
    [Route("c2")]
    [Authorize]
    public string GetAuthorize()
    {
        _logger.Log(LogLevel.Information, "GetAuthorize starts/ends");

        //analysis of a claim

        var userIdClaim = User.Claims.FirstOrDefault(
            c => c.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier");

        var userClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name);

        string userId = "";

        if (userClaim != null)
        {
            // Extract the user ID from the claim
              userId = userClaim.Value;
 
        }
 
        return userId;
    }

    private static string GenerateJwtToken(string username, string password)
    {

        // Replace "your-secret-key" with your actual secret key

        // Convert the secret key to a byte array
        byte[] keyBytes = Encoding.UTF8.GetBytes(SecurityInfo.SecretKey);

        // Create a SymmetricSecurityKey using the byte array
        var key = new SymmetricSecurityKey(keyBytes);

        //HS256
        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: "your-issuer",
            audience: "your-audience",
            claims: new[] { new Claim(ClaimTypes.Name, username) , new Claim(ClaimTypes.Country,"Greece")},
            expires: DateTime.UtcNow.AddMinutes(15),
            signingCredentials: credentials
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }


}
