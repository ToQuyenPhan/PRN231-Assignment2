using BusinessObject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using ProjectParticipantManagementSystemWebClient.ViewModels;
using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Threading.Tasks;
using BusinessObject;
using Microsoft.AspNetCore.Http;
using ProjectParticipantManagementSystemWebClient.Utils;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;

namespace ProjectParticipantManagementSystemWebClient.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        [BindProperty]
        public LoginViewModel LoginModel { get; set; }

        [ViewData]
        public string Message { get; set; }

        public IActionResult OnGet()
        {
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                var role = HttpContext.User.FindFirst(ClaimType.Role.ToString());
                return RedirectToPage(role.Value == Role.Admin.ToString() ? "/AdminPages/Employees/Index" : "/CustomerPages/Profile");
            }
            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            var email = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("DefaultAccount:Email").Value;
            var password = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("DefaultAccount:Password").Value;
            if(email.Equals(LoginModel.Email) && password.Equals(LoginModel.Password))
            {
                var adminIdentity = new ClaimsIdentity(new List<Claim>
                {
                    new(ClaimType.Role, Role.Admin.ToString()),
                }, CookieAuthenticationDefaults.AuthenticationScheme);
                var adminPrinciple = new ClaimsPrincipal(adminIdentity);
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, adminPrinciple);
                return RedirectToPage("/AdminPages/Employees/Index");
            }
            else
            {
                try
                {
                    HttpClient client = new HttpClient();
                    var contentType = new MediaTypeWithQualityHeaderValue("application/json");
                    client.DefaultRequestHeaders.Accept.Add(contentType);
                    string EmployeeApiUrl = "https://localhost:44351/odata/Employees?$filter=EmailAddress eq '" + LoginModel.Email + "' And Password eq '"
                        + LoginModel.Password + "'&$format=application/json;odata.metadata=none";
                    HttpResponseMessage response = await client.GetAsync(EmployeeApiUrl);
                    string strData = await response.Content.ReadAsStringAsync();
                    var options = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    };
                    options.Converters.Add(new JsonStringEnumConverter());
                    var result = JsonSerializer.Deserialize<Odata<Employee>>(strData, options);
                    var employee = result.Value;
                    if (employee != null && employee.Count > 0)
                    {
                        int id = 0;
                        foreach (var item in employee)
                        {
                            id = item.EmployeeID;
                        }
                        HttpContext.Session.SetInt32("id", id);
                            var claims = new List<Claim>
                        {
                            new(ClaimType.Role, Role.Customer.ToString())
                        };
                        var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                        var principal = new ClaimsPrincipal(identity);
                        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
                        return RedirectToPage("/CustomerPages/Profile", new { Id = id });
                    }
                    else
                    {
                        Message = "Incorrect email or password!";
                        return Page();
                    }
                }catch(Exception ex)
                {
                    Message = "Something went wrong, please try again!";
                    return Page();
                }
            }
        }
    }
}
