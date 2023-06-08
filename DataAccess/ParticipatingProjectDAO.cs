using BusinessObject.Context;
using BusinessObject.Models;
using Microsoft.EntityFrameworkCore;
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

        public ParticipatingProject GetParticipatingProject(int employeeId, int companyProjectId)
        {
            using (var context = new ProjectParticipatingDbContext())
            {
                return context.ParticipatingProjects.Where(p => p.EmployeeID == employeeId && p.CompanyProjectID == companyProjectId).Include(p => p.Employee).FirstOrDefault();
            }
        }

        public IEnumerable<ParticipatingProject> GetParticipatingProjectsByEmployeeID(int id)
        {
            using (var context = new ProjectParticipatingDbContext())
            {
                return context.ParticipatingProjects.Where(p => p.EmployeeID == id).ToList();
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
