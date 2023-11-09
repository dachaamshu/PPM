using NUnit.Framework;
using PPM.Model;
using PPM.Domain;
using PPM.Ui.Consoles;
namespace PPM.Test
{
    [TestFixture]
    public class DomainTest
    {
        ProjectRepo projectRepo = new ProjectRepo();
        EmployeeRepo employeeRepo = new EmployeeRepo();
        RoleRepo roleRepo = new RoleRepo();
        EmployeeProjectRepo employeeProjectRepo = new EmployeeProjectRepo();
        EmployeeProjectConsoles employeeProjectConsoles = new EmployeeProjectConsoles();

        [Test]
        public void AddProjectTest()
        {

            Project project = new Project()
            {
                ProjectId = 1,
                ProjectName = "JAVA",
                StartDate = new DateOnly(2023, 12, 12),
                EndDate = new DateOnly(2024, 12, 12)
            };

            projectRepo.AddEntity(project);

            // Assert.That(Project.projectList.Count, Is.EqualTo(1));

            // Assert.That(Project.projectList[0].ProjectName, Is.EqualTo("JAVA"));

            Assert.That(ProjectRepo.projectList.Contains(project));

            // Console.WriteLine("Project Test Case Passed.");

        }

        [Test]
        public void AddEmployeeTest()
        {
            Employee employee = new Employee()
            {
                EmployeeId = 1,
                FirstName = "SURYA",
                LastName = "AMSHU",
                EmailId = "dacha@gmail.com.com",
                MobileNumber = 9133797959,
                RoleId = 1
            };

            employeeRepo.AddEntity(employee);

            Assert.That(EmployeeRepo.employeeList.Contains(employee));

            //  CollectionAssert.Contains(Employee.employeeList, employeeDetails);

            // Console.WriteLine("Employee Test Case Passed.");

        }

        [Test]
        public void AddRoleTest()
        {
            Role role = new Role()
            {
                RoleId = 1,
                RoleName = "DEVELOPER"
            };

            roleRepo.AddEntity(role);

            Assert.That(RoleRepo.roleList.Contains(role));

            // Console.WriteLine("Role Test Case Passed.");

        }

        [Test]
        public void AddEmployeeToProjectTest()

        {

            EmployeeProject employeeProject = new EmployeeProject()
            {

                ProjectId = 1,
                ProjectName = "JAVA",
                EmployeeId = 1,
                FirstName = "SURYA",
                LastName = "AMSHU",
                RoleId = 1
                
            };
           
            employeeProjectRepo.AddEmployeeToProject(employeeProject.ProjectId,employeeProject.ProjectName,employeeProject.EmployeeId,employeeProject.FirstName,employeeProject.LastName,employeeProject.RoleId);


            bool containsItem = EmployeeProjectRepo.employeeProjectList.Any(item =>
            item.ProjectId == employeeProject.ProjectId &&
            item.EmployeeId == employeeProject.EmployeeId &&
            item.FirstName == employeeProject.FirstName &&
            item.LastName == employeeProject.LastName &&
            item.RoleId == employeeProject.RoleId);


            Assert.IsTrue(containsItem);
        }
    

        
        [Test]
        public void RemoveEmployeeToProjectTest()

        {

            EmployeeProject employeeProject = new EmployeeProject()
            {

                ProjectId = 1,
                EmployeeId = 1

            };

            employeeProjectRepo.RemoveEmployeefromProject(employeeProject.ProjectId,employeeProject.EmployeeId);

            bool containsItem = EmployeeProjectRepo.employeeProjectList.Any(item =>
            item.ProjectId == employeeProject.ProjectId &&
            item.EmployeeId == employeeProject.EmployeeId );


            Assert.IsFalse(containsItem);
        }

        
        [Test]
        public void ViewAddEmployeetoProjectTest()
        {
            EmployeeProject employeeProject = new EmployeeProject()
            {

                ProjectId = 1,
                ProjectName = "DATABASE",
                EmployeeId = 1,
                FirstName = "SURYA",
                LastName = "AMSHU",
                RoleId = 1

            };
            EmployeeProjectRepo.employeeProjectList.Add(employeeProject);

            List<EmployeeProject> employeeProjectList = employeeProjectConsoles.ViewAddEmployeetoProject();

            Assert.IsTrue(EmployeeProjectRepo.employeeProjectList.Contains(employeeProject));

        }


    }
}
