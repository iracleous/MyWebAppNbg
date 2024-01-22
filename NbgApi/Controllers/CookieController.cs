
using Microsoft.AspNetCore.Mvc;
using NbgApi.Services;
using System.Net;

namespace DemoJwt.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CookieController : ControllerBase
{
    private readonly ICookieServices _cookieServices;
    public CookieController(ICookieServices services)
    {
         _cookieServices = services;
    }



    [HttpGet]
    [Route("set")]
    public string SetCookie()
    {
        return _cookieServices.AddCookie(Response, "myCookie", "value");
    }

    [HttpGet]
    [Route("get")]
    public string GetCookie()
    {
       return _cookieServices.ReadCookie(Request, "myCookie" );
  }
    [HttpGet]
    [Route("reset")]
    public string DeletetCookie()
    {
        return _cookieServices.DeleteCookie(Request, Response, "myCookie");
    }
    [HttpGet]
    [Route("seto")]
    public string SetCookieWithOptions()
    {
        return _cookieServices.AddCookieWithParameters(Response, "myCookieWithOptions", "cookie-value-with-options");
    }


}