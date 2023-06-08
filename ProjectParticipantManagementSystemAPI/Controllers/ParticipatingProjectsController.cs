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
        public IActionResult Get([FromQuery] int employeeId, [FromQuery] int companyProjectId)
        {
            var participatingProjects = ParticipatingProjectRepo.GetParticipatingProject(employeeId,companyProjectId);
            if (participatingProjects == null)
            {
                return NotFound();
            }
            return Ok(participatingProjects);
        }

        [EnableQuery]
        public IActionResult Post([FromBody] ParticipatingProject participatingProject)
        {
            GenericRepo.Insert(participatingProject);
            return Created(participatingProject);
        }

        [EnableQuery]
        public IActionResult Patch([FromBody] ParticipatingProject participatingProject)
        {
            GenericRepo.Update(participatingProject);
            return Ok(participatingProject);
        }

        [HttpDelete("odata/ParticipatingProjects/DeleteParticipatingProject")]
        [EnableQuery]
        public IActionResult Delete([FromQuery] int employeeId, [FromQuery] int companyProjectId)
        {
            ParticipatingProjectRepo.Delete(employeeId, companyProjectId);
            return Ok();
        }
    }
}
