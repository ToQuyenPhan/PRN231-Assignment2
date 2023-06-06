using BusinessObject.Models;
using DataAccess.Repositories.GenericRepo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Formatter;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using System.Collections.Generic;

namespace ProjectParticipantManagementSystemAPI.Controllers
{
    public class CompanyProjectsController : ODataController
    {
        private static IGenericRepo<CompanyProject> GenericRepo;

        public CompanyProjectsController(IGenericRepo<CompanyProject> genericRepo)
        {
            GenericRepo = genericRepo;
        }

        [EnableQuery]
        public ActionResult<IEnumerable<CompanyProject>> Get()
        {
            var list = GenericRepo.GetAll(null);
            return Ok(list);
        }

        [EnableQuery]
        public IActionResult Get([FromODataUri] int key)
        {
            var companyProject = GenericRepo.GetById(key, null, null);
            if (companyProject == null)
            {
                return NotFound();
            }
            return Ok(companyProject);
        }

        [EnableQuery]
        public IActionResult Post([FromBody]CompanyProject companyProject)
        {
            GenericRepo.Insert(companyProject);
            return Created(companyProject);
        }

        [EnableQuery]
        public IActionResult Put([FromODataUri] int key, [FromBody]CompanyProject companyProject)
        {
            if(key != companyProject.CompanyProjectID)
            {
                return BadRequest();
            }
            GenericRepo.Update(companyProject);
            return Ok(companyProject);
        }

        [EnableQuery]
        public IActionResult Delete([FromODataUri] int key)
        {
            GenericRepo.Delete(key);
            return Ok();
        }
        //Search Query: https://localhost:44351/odata/CompanyProjects?$filter=contains(ProjectName, 'A') 
    }
}
