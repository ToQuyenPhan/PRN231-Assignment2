using BusinessObject.Models;
using DataAccess.Repositories.GenericRepo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Formatter;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectParticipantManagementSystemAPI.Controllers
{
    
    public class EmployeesController : ODataController
    {
        private readonly IGenericRepo<Employee> _repository;

        public EmployeesController(IGenericRepo<Employee> repository)
        {
            _repository = repository;
        }

        [EnableQuery]
        public IActionResult Get()
        {
            var employees = _repository.GetAll();
            return Ok(employees);
        }
        [EnableQuery]
        public IActionResult Get([FromODataUri] int key)
        {
            var employee = _repository.GetById(key);
            if (employee == null)
                return NotFound();

            return Ok(employee);
        }

        [EnableQuery]
        public IActionResult Post([FromBody] Employee employee)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _repository.Insert(employee);
            return Created(employee);
        }

        [EnableQuery]
        public IActionResult Put([FromODataUri] int key, [FromBody] Employee employee)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var existingEmployee = _repository.GetById(key);
            if (existingEmployee == null)
                return NotFound();

            _repository.Update(employee);
            return Updated(employee);
        }

        [EnableQuery]
        public IActionResult Delete([FromODataUri] int key)
        {
            var existingEmployee = _repository.GetById(key);
            if (existingEmployee == null)
                return NotFound();

            _repository.Delete(existingEmployee);
            return NoContent();
        }
    }
}