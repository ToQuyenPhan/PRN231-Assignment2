using BusinessObject.Models;
using DataAccess.Repositories.GenericRepo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using System.Collections.Generic;

namespace ProjectParticipantManagementSystemAPI.Controllers
{
    public class DepartmentsController : ODataController
    {
        private static IGenericRepo<Department> GenericRepo;

        public DepartmentsController(IGenericRepo<Department> genericRepo) {
            GenericRepo = genericRepo;
        }

        [EnableQuery]
        public ActionResult<IEnumerable<Department>> Get()
        {
            var list = GenericRepo.GetAll(null);
            return Ok(list);
        }

        [EnableQuery]
        public ActionResult<Department> Get([FromRoute]int key)
        {
            var department = GenericRepo.GetById(key, null, null);
            if(department == null)
            {
                return NotFound();
            }
            return Ok(department);
        }
    }
}
