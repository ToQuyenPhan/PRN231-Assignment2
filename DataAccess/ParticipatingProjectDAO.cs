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
        private static ParticipatingProjectDAO instance = null;
        private static readonly object instanceLock = new object();
        public ParticipatingProjectDAO() { }

        public static ParticipatingProjectDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null) instance = new ParticipatingProjectDAO();
                    return instance;
                }
            }
        }

        public ParticipatingProject GetParticipatingProject(int employeeId, int companyProjectId)
        {
            using (var context = new ProjectParticipatingDbContext())
            {
                return context.ParticipatingProjects.Where(p => p.EmployeeID == employeeId && p.CompanyProjectID == companyProjectId).Include(p => p.Employee).FirstOrDefault();
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
