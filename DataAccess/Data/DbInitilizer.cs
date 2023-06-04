using BusinessObject.Context;
using BusinessObject.Models;
using System;
using System.Linq;

namespace ProjectParticipantManagementSystemAPI.Data
{
    public class DbInitializer
    {
        public static void Initialize(ProjectParticipatingDbContext context)
        {
            if (context.ParticipatingProjects.Any())
            {
                return;
            }
            var departments = new Department[]
            {
                new Department{DepartmentName = "Software Engineering", 
                    DepartmentDescription = "Focus on engineering, advanced math, and computer programming."},
                new Department{DepartmentName = "Communication and Media",
                    DepartmentDescription = "Crafting messages, understanding audiences, working with new technologies and learning key communication theories."},
                new Department{DepartmentName = "Digital Design",
                    DepartmentDescription = "Educated and trained to compete in the rapidly emerging art and creative design fields."}
            };
            context.Departments.AddRange(departments);
            context.SaveChanges();
            var employees = new Employee[]
            {
                new Employee{Password = "1", FullName = "Phan Thi To Quyen", Address = "HCM City", Status = Status.Active, 
                Skills = "Coding", Telephone = "0123456789", DepartmentID = 1, EmailAddress = "quyen@gmail.com"},
                new Employee{Password = "1", FullName = "Phan Thi To Quyen 2", Address = "HCM City", Status = Status.Active,
                Skills = "Coding", Telephone = "0123456789", DepartmentID = 2, EmailAddress = "quyen2@gmail.com"},
                new Employee{Password = "1", FullName = "Phan Thi To Quyen 3", Address = "HCM City", Status = Status.Active,
                Skills = "Coding", Telephone = "0123456789", DepartmentID = 3, EmailAddress = "quyen3@gmail.com"}
            };
            context.Employees.AddRange(employees);
            context.SaveChanges();
            var companyProjects = new CompanyProject[]
            {
                new CompanyProject{ProjectName = "TroTot", ProjectDescription = "Help people look for a suitable home.", 
                EstimatedStartDate = DateTime.Now, ExpectedEndDate = DateTime.Today.AddDays(3)},
                new CompanyProject{ProjectName = "CoRe", ProjectDescription = "A cooking recipe website.",
                EstimatedStartDate = DateTime.Now, ExpectedEndDate = DateTime.Today.AddDays(2)},
                new CompanyProject{ProjectName = "ABlog", ProjectDescription = "A website for students to share experience.",
                EstimatedStartDate = DateTime.Now, ExpectedEndDate = DateTime.Today.AddDays(4)}
            };
            context.CompanyProjects.AddRange(companyProjects);
            context.SaveChanges();
            var participatingProjects = new ParticipatingProject[]
            {
                new ParticipatingProject{CompanyProjectID = 1, EmployeeID = 1, StartDate = System.DateTime.Now, 
                    EndDate = DateTime.Today.AddDays(2), ProjectRole = 1},
                new ParticipatingProject{CompanyProjectID = 2, EmployeeID = 3, StartDate = System.DateTime.Now, 
                    EndDate = DateTime.Today.AddDays(1), ProjectRole = 2},
                new ParticipatingProject{CompanyProjectID = 3, EmployeeID = 2, StartDate = System.DateTime.Now, 
                    EndDate = DateTime.Today.AddDays(3), ProjectRole = 1}
            };
            context.ParticipatingProjects.AddRange(participatingProjects);
            context.SaveChanges();
        }
    }
}
