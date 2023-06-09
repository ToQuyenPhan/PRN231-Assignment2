using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BusinessObject.Models;
using ProjectParticipantManagementSystemWebClient.ViewModels;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text.Json.Serialization;
using System.Text.Json;
using BusinessObject;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using ProjectParticipantManagementSystemWebClient.Utils;

namespace ProjectParticipantManagementSystemWebClient.Pages.AdminPages.Employees
{
    [Authorize(Roles = nameof(Role.Admin))]
    public class CreateModel : PageModel
    {
        private HttpClient client = null;
        private string EmployeeApiUrl = "";

        public CreateModel()
        {
        }

        public async Task<IActionResult> OnGet()
        {
            var statuses = from Status s in Enum.GetValues(typeof(Status)) select new { ID = s, Name = s.ToString() };
            ViewData["Status"] = new SelectList(statuses, "ID", "Name");
            ViewData["DepartmentID"] = new SelectList(GetDepartments().Result, "DepartmentID", "DepartmentName");
            return Page();
        }

        [BindProperty]
        public EmployeeViewModel Employee { get; set; }
        public IList<Department> Departments { get; set; }

        [ViewData]
        public string Message { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            if(EmailExist(Employee.EmailAddress).Result)
            {
                var statuses = from Status s in Enum.GetValues(typeof(Status)) select new { ID = s, Name = s.ToString() };
                ViewData["Status"] = new SelectList(statuses, "ID", "Name");
                ViewData["DepartmentID"] = new SelectList(GetDepartments().Result, "DepartmentID", "DepartmentName");
                Message = "This email is already exist!";
                return Page();
            }
            try
            {
                client = new HttpClient();
                var contentType = new MediaTypeWithQualityHeaderValue("application/json");
                client.DefaultRequestHeaders.Accept.Add(contentType);
                EmployeeApiUrl = "https://localhost:44351/odata/Employees";
                var employee = new Employee
                {
                    EmailAddress = Employee.EmailAddress,
                    Password = Employee.Password,
                    FullName = Employee.FullName,
                    Skills = Employee.Skills,
                    Telephone = Employee.Telephone,
                    Address = Employee.Address,
                    Status = Employee.Status,
                    DepartmentID = Employee.DepartmentID
                };
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };
                options.Converters.Add(new JsonStringEnumConverter());
                var jsonObject = JsonSerializer.Serialize(employee, options);
                HttpContent content = new StringContent(jsonObject, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync(EmployeeApiUrl, content);
                if (response.StatusCode == System.Net.HttpStatusCode.Created)
                {
                    return RedirectToPage("./Index");
                }
                else
                {
                    return Page();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private async Task<bool> EmailExist(string email)
        {
            bool check = false;
            client = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);
            EmployeeApiUrl = "https://localhost:44351/odata/Employees?$filter=EmailAddress eq '" + email + "'";
            HttpResponseMessage response = await client.GetAsync(EmployeeApiUrl);
            string strData = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            options.Converters.Add(new JsonStringEnumConverter());
            var employee = JsonSerializer.Deserialize<Employee>(strData, options);
            if(employee != null)
            {
                check = true;
            }
            return check;
        }

        private async Task<IList<Department>> GetDepartments()
        {
            client = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);
            string DepartmentApiUrl = "https://localhost:44351/odata/Departments?$format=application/json;odata.metadata=none";
            HttpResponseMessage response = await client.GetAsync(DepartmentApiUrl);
            string strData = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            options.Converters.Add(new JsonStringEnumConverter());
            var list = JsonSerializer.Deserialize<Odata<Department>>(strData, options);
            return list.Value;
        }
    }
}
