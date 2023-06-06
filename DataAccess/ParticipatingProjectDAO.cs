using BusinessObject.Context;
using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class ParticipatingProjectDAO
    {
        public ParticipatingProjectDAO() { }

        public IEnumerable<ParticipatingProject> GetParticipatingProjectsByCompanyProjectID(int id)
        {
            using (var context = new ProjectParticipatingDbContext())
            {
                return context.ParticipatingProjects.Where(p => p.CompanyProjectID == id).ToList();
            }
        }

        public void Delete(int employeeId, int companyProjectId)
        {
            using (var context = new ProjectParticipatingDbContext())
            {
                var participatingProject = context.ParticipatingProjects.FirstOrDefault(p => p.EmployeeID == employeeId && p.CompanyProjectID == companyProjectId);
                context.ParticipatingProjects.Remove(participatingProject);
                context.SaveChanges();
            }
        }
    }
}
