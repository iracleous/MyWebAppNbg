
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace DemoJwt.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CookieController : ControllerBase
{
    [HttpGet]
    [Route("set")]
    public string SetCookie()
    {
        // Create a new cookie
        var cookie = new Cookie("myCookie", "cookie-value");

        // Set the cookie in the response
        Response.Cookies.Append(cookie.Name, cookie.Value);

        return  "Cookie set successfully" ;
    }

    [HttpGet]
    [Route("get")]
    public string GetCookie()
    {
        // Retrieve the value of the "myCookie" cookie
        var cookieValue = Request.Cookies["myCookie"];

        if (cookieValue != null)
        {
            return  $"Cookie value: {cookieValue}" ;
        }
        else
        {
            return  "Cookie not found" ;
        }

    }
    [HttpGet]
    [Route("seto")]
    public string SetCookieWithOptions()
    {
        // Create a cookie with options
        var cookieOptions = new CookieOptions
        {
            Expires = DateTime.Now.AddMinutes(30),
            HttpOnly = true,
            Secure = true,
            SameSite = SameSiteMode.Strict
        };

        Response.Cookies.Append("myCookieWithOptions", "cookie-value-with-options", cookieOptions);

        return  "Cookie with options set successfully";
    }


}