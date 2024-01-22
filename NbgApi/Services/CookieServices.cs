
using Azure;
using Azure.Core;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace NbgApi.Services
{
    public interface ICookieServices
    {
        public string AddCookie(HttpResponse response, string name, string value);
        public string AddCookieWithParameters(HttpResponse response, string name, string value);
        public string ReadCookie(HttpRequest request, string name);
        public string DeleteCookie(HttpRequest request, HttpResponse response, string name);

    }



    public class CookieServices : ICookieServices
    {
        public string AddCookie(HttpResponse response, string name, string value)
        {
            // Create a cookie with options
            var cookieOptions = new CookieOptions
            {
                Expires = DateTime.Now.AddMinutes(30),
                HttpOnly = true,
                Secure = true,
                SameSite = SameSiteMode.Strict
            };

            response.Cookies.Append(name, value, cookieOptions);

            return "Cookie with options set successfully";
        }


        public string AddCookieWithParameters(HttpResponse response, string cookieName, string cookieValue)
        {
            // Create a cookie with options
            var cookieOptions = new CookieOptions
            {
                Expires = DateTime.Now.AddMinutes(30),
                HttpOnly = true,
                Secure = true,
                SameSite = SameSiteMode.Strict
            };

            response.Cookies.Append(cookieName, cookieValue, cookieOptions);

            return "Cookie with options set successfully";
        }

        public string DeleteCookie(HttpRequest request, HttpResponse response, string name)
        {
            // Retrieve the value of the "myCookie" cookie
            var cookieValue = request.Cookies[name];
            response.Cookies.Delete(name);

            if (cookieValue != null)
            {
                return $"Cookie value: {cookieValue}";
            }
            else
            {
                return "Cookie not found";
            }

        }

        public string ReadCookie(HttpRequest request, string name)
        {
            // Retrieve the value of the "myCookie" cookie
            var cookieValue = request.Cookies[name];
            if (cookieValue != null)
            {
                return $"Cookie value: {cookieValue}";
            }
            else
            {
                return "Cookie not found";
            }

        }
    }
}
