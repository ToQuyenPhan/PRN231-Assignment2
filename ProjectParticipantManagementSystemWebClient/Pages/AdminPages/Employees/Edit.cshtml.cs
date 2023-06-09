using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BusinessObject.Models;
using System.Net.Http;
using BusinessObject;
using System.Net.Http.Headers;
using System.Text.Json.Serialization;
using System.Text.Json;
using ProjectParticipantManagementSystemWebClient.ViewModels;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using ProjectParticipantManagementSystemWebClient.Utils;

namespace ProjectParticipantManagementSystemWebClient.Pages.AdminPages.Employees
{
    [Authorize(Roles = nameof(Role.Admin))]
    public class EditModel : PageModel
    {
        private HttpClient client = null;
        private string EmployeeApiUrl = "";
        private string DepartmentApiUrl = "";

        public EditModel()
        {
        }

        [BindProperty]
        public EmployeeViewModel Employee { get; set; }
        public IList<Department> Departments { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            client = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);
            EmployeeApiUrl = "https://localhost:44351/odata/Employees("+ id 
                + ")?$expand=Department&$format=application/json;odata.metadata=none";
            HttpResponseMessage response = await client.GetAsync(EmployeeApiUrl);
            string strData = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            options.Converters.Add(new JsonStringEnumConverter());
            var employee = JsonSerializer.Deserialize<Employee>(strData, options);
            var employeeViewModel = new EmployeeViewModel
            {
                EmployeeID = employee.EmployeeID,
                EmailAddress = employee.EmailAddress,
                Password = employee.Password,
                FullName = employee.FullName,
                Skills = employee.Skills,
                Telephone = employee.Telephone,
                Address = employee.Address,
                Status = employee.Status,
                DepartmentID = employee.DepartmentID
            };
            Employee = employeeViewModel;
            if (Employee == null)
            {
                return NotFound();
            }
            DepartmentApiUrl = "https://localhost:44351/odata/Departments?$format=application/json;odata.metadata=none";
            response = await client.GetAsync(DepartmentApiUrl);
            strData = await response.Content.ReadAsStringAsync();
            var list = JsonSerializer.Deserialize<Odata<Department>>(strData, options);
            Departments = list.Value;
            var statuses = from Status s in Enum.GetValues(typeof(Status)) select new { ID = s, Name = s.ToString() };
            ViewData["Status"] = new SelectList(statuses, "ID", "Name");
            ViewData["DepartmentID"] = new SelectList(Departments, "DepartmentID", "DepartmentName");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            try
            {
                client = new HttpClient();
                var contentType = new MediaTypeWithQualityHeaderValue("application/json");
                client.DefaultRequestHeaders.Accept.Add(contentType);
                EmployeeApiUrl = "https://localhost:44351/odata/Employees(" + Employee.EmployeeID + ")";
                var employee = new Employee
                {
                    EmployeeID = Employee.EmployeeID,
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
                HttpResponseMessage response = await client.PutAsync(EmployeeApiUrl, content);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    return RedirectToPage("./Index");
                }
                else
                {
                    return Page();
                }
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
