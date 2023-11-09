using PPM.Domain;
using PPM.Ui.Consoles;
using PPM.Model;
using NUnit.Framework;
using System.Data;

namespace PPM.Test
{

    [TestFixture]
    public class ProjectConsolesTest
    {
        ProjectConsoles projectConsoles = new ProjectConsoles();
        EmployeeConsoles employeeConsoles = new EmployeeConsoles();

        [Test]
        public void AddProjectMethodValidInput()
        {
      
            var input = new StringReader("1\n2\nC#\n2023-10-25\n2023-10-31\nyes\n2\n2\n2");

            Console.SetIn(input);

            projectConsoles.AddProjectMethod();

        }

        [Test]
        public void AddProjectMethodNegativeProjectId()
        {

            var input = new StringReader("1\n-1\n3\nPYTHON\n2023-10-25\n2023-10-31\n");

            Console.SetIn(input);

            projectConsoles.AddProjectMethod();


        }

        [Test]
        public void AddProjectMethodDuplicateProjectId()
        {
    
            var input = new StringReader("2\n4\nREACT\n2023-10-25\n2023-10-31\n4\n5\nProjectB\n2023-10-20\n2023-10-30\n");
            Console.SetIn(input);

            projectConsoles.AddProjectMethod();

         
        }

        [Test]
        public void AddProjectMethodEndDateBeforeStartDate()

        {
        
            var input = new StringReader("1\n6\nANGULAR\n2023-10-31\n2023-10-25\n2023-10-31\n2024-10-31");

            Console.SetIn(input);

            projectConsoles.AddProjectMethod();

    
        }

        [Test]
        public void ViewProjectTest()
        {

            Project project = new Project()

            {

                ProjectId = 1,

                ProjectName = "DOTNET",

                StartDate = new DateOnly(2023, 10, 11),

                EndDate = new DateOnly(2023, 11, 11)
            };

            ProjectRepo.projectList.Add(project);

            List<Project> projectList = projectConsoles.ViewProjects();

            Assert.IsTrue(ProjectRepo.projectList.Contains(project));

        }

        [Test]
        public void ViewProjectByProjectIdTest()
        {

            var input = new StringReader("-1\n2");
            Console.SetIn(input);
            projectConsoles.ViewProjectById();

        }

        [Test]
        public void DeleteProjectByProjectIdTest()
        {

            var input = new StringReader("-1\n3");
            Console.SetIn(input);
            projectConsoles.DeleteProjectById();

        }

        EmployeeProjectConsoles employeeProjectConsoles = new EmployeeProjectConsoles();
        [Test]
        public void AddEmpToProjTest()
        {
            var input = new StringReader("1\n10");
            Console.SetIn(input);
            employeeProjectConsoles.AddEmployeeToProjectMethod();
        }
    }
}








