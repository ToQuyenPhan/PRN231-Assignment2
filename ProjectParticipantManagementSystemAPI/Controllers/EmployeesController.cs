using BusinessObject.Models;
using DataAccess.Repositories.GenericRepo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Formatter;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using System.Collections.Generic;

namespace ProjectParticipantManagementSystemAPI.Controllers
{
    public class EmployeesController : ODataController
    {
        private static IGenericRepo<Employee> GenericRepo;

        public EmployeesController(IGenericRepo<Employee> genericRepo)
        {
            GenericRepo = genericRepo;
        }

        [EnableQuery]
        public ActionResult<IEnumerable<Employee>> Get()
        {
            var list = GenericRepo.GetAll("Department");
            return Ok(list);
        }

        [EnableQuery]
        public IActionResult Get([FromODataUri] int key)
        {
            var employee = GenericRepo.GetById(key);
            if (employee == null)
            {
                return NotFound();
            }
            return Ok(employee);
        }

        [EnableQuery]
        public IActionResult Post([FromBody] Employee employee)
        {
            GenericRepo.Insert(employee);
            return Created(employee);
        }

        [EnableQuery]
        public IActionResult Put([FromODataUri] int key, [FromBody] Employee employee)
        {
            if (key != employee.EmployeeID)
            {
                return BadRequest();
            }
            GenericRepo.Update(employee);
            return Ok(employee);
        }

        [EnableQuery]
        public IActionResult Delete([FromODataUri] int key)
        {
            GenericRepo.Delete(key);
            return Ok();
        }
        //Search Query: https://localhost:44351/odata/Employees?$filter=contains(FullName, 'A')
    }
}
