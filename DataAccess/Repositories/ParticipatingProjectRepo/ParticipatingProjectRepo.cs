using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.ParticipatingProjectRepo
{
    public class ParticipatingProjectRepo : IParticipatingProjectRepo
    {
        public void Delete(int employeeId, int companyProjectId) => ParticipatingProjectDAO.Instance.Delete(employeeId, companyProjectId);

        public ParticipatingProject GetParticipatingProject(int employeeId, int companyProjectId) => ParticipatingProjectDAO.Instance.GetParticipatingProject(employeeId, companyProjectId);
    }
}
