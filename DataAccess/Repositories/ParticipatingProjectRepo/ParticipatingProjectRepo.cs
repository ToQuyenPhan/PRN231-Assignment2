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
        private ParticipatingProjectDAO dao = new ParticipatingProjectDAO();

        public void Delete(int employeeId, int companyProjectId) => dao.Delete(employeeId, companyProjectId);

        public IEnumerable<ParticipatingProject> GetParticipatingProjectsByCompanyProjectID(int id) => dao.GetParticipatingProjectsByCompanyProjectID(id);
    }
}
