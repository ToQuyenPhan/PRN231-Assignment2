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
        ParticipatingProject GetParticipatingProject(int employeeId, int companyProjectId);
        void Delete(int employeeId, int companyProjectId);
    }
}
