using BusinessObject.Models;
using DataAccess.Repositories.GenericRepo;
using DataAccess.Repositories.ParticipatingProjectRepo;
using Microsoft.AspNet.OData.Routing;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Formatter;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using System.Collections.Generic;

namespace ProjectParticipantManagementSystemAPI.Controllers
{
    public class ParticipatingProjectsController : ODataController
    {
        private static IGenericRepo<ParticipatingProject> GenericRepo;
        private static IParticipatingProjectRepo ParticipatingProjectRepo;

        public ParticipatingProjectsController(IGenericRepo<ParticipatingProject> genericRepo, IParticipatingProjectRepo participatingProjectRepo)
        {
            GenericRepo = genericRepo;
            ParticipatingProjectRepo = participatingProjectRepo;
        }

        [EnableQuery]
        public ActionResult<IEnumerable<ParticipatingProject>> Get()
        {
            var list = GenericRepo.GetAll(null);
            return Ok(list);
        }

        //[EnableQuery]
        //[ODataRoute("ParticipatingProject({employeeId},{companyProjectId}")]
        //public ActionResult<IEnumerable<ParticipatingProject>> Get([FromODataUri] int employeeId, [FromODataUri] int companyProjectId)
        //{
        //    var participatingProjects = ParticipatingProjectRepo.GetParticipatingProjectsByCompanyProjectID(companyProjectId);
        //    if (participatingProjects == null)
        //    {
        //        return NotFound();
        //    }
        //    return Ok(participatingProjects);
        //}

        [EnableQuery]
        public IActionResult Post([FromBody] ParticipatingProject participatingProject)
        {
            GenericRepo.Insert(participatingProject);
            return Created(participatingProject);
        }

        [EnableQuery]
        public IActionResult Patch([FromBody] ParticipatingProject participatingProject)
        {
            //if (key != participatingProject.EmployeeID)
            //{
            //    return BadRequest();
            //}
            GenericRepo.Update(participatingProject);
            return Ok(participatingProject);
        }

        [EnableQuery]
        [ODataRoute("DeleteParticipatingProject(key1={key1}, key2={key2})")]
        public IActionResult Delete([FromODataUri] int key1, [FromODataUri] int key2)
        {
            ParticipatingProjectRepo.Delete(key1, key2);
            return Ok();
        }
        //Search Query: https://localhost:44351/odata/ParticipatingProjects?$filter=contains(FullName, 'A')
    }
}
