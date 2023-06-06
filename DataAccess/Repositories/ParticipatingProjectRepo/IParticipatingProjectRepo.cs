using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.ParticipatingProjectRepo
{
    public interface IParticipatingProjectRepo
    {
        IEnumerable<ParticipatingProject> GetParticipatingProjectsByCompanyProjectID(int id);
        void Delete(int employeeId, int companyProjectId);
    }
}
