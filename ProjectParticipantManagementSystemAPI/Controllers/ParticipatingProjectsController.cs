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
        public ActionResult<IEnumerable<ParticipatingProject>> Get([FromQuery] int companyProjectId)
        {
            var list = GenericRepo.GetAll("Employee");
            return Ok(list);
        }

        [EnableQuery]
        public ActionResult<IEnumerable<ParticipatingProject>> Get([FromQuery]int employeeId, [FromQuery]int companyProjectId)
        {
            var participatingProjects = ParticipatingProjectRepo.GetParticipatingProjectsByCompanyProjectID(companyProjectId);
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

        [EnableQuery]
        public IActionResult Delete([FromQuery]int employeeId, [FromQuery]int companyProjectId)
        {
            ParticipatingProjectRepo.Delete(employeeId, companyProjectId);
            return Ok();
        }
        //Search Query: https://localhost:44351/odata/ParticipatingProjects?$filter=contains(FullName, 'A')
    }
}
