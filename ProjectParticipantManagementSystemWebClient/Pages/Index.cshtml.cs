using BusinessObject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using ProjectParticipantManagementSystemWebClient.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Threading.Tasks;
using BusinessObject;

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

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            var email = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("DefaultAccount:Email").Value;
            var password = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("DefaultAccount:Password").Value;
            if(email.Equals(LoginModel.Email) && password.Equals(LoginModel.Password))
            {
                return RedirectToPage("/AdminPages/Employees/Index");
            }
            else
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
                if(employee != null)
                {
                    Message = "Hello Customer";
                    return Page();
                }
                else
                {
                    return Page();
                }
            }
        }
    }
}
