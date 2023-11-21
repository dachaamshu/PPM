using PPM.Model;
using PPM.Domain;
using PPM.DAL;
using Microsoft.Win32.SafeHandles;
using System.Reflection.Emit;
using PPM.Dal;

namespace PPM.Ui.Consoles
{
    public class ProjectConsoles
    {
        ProjectRepo projectRepo = new ProjectRepo();
        EmployeeProjectRepo employeeProjectRepo = new EmployeeProjectRepo();

        public void AddProjectMethod()
        {

            Console.WriteLine("enter the count : ");
            int count = int.Parse(Console.ReadLine() ?? string.Empty);

            for (int i = 0; i < count; i++)
            {
                Project project = new Project();
                int projectId;
                while (true)
                {
                    while (true)
                    {

                        Console.WriteLine("Enter ProjectId : ");
                        projectId = int.Parse(Console.ReadLine() ?? string.Empty);

                        if (projectId <= 0)
                        {

                            Console.ForegroundColor = ConsoleColor.DarkCyan;
                            Console.WriteLine("PROJECTID SHOULD NOT BE 0 AND NEGATIVE.");
                            Console.ResetColor();

                        }
                        else
                        {

                            break;
                        }
                    }

                    ProjectDal projectDal = new ProjectDal();
                    if (projectDal.IsProjectExists(projectId))
                    {
                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                        Console.WriteLine("---------------------------PROJECT DETAILS ALREADY EXISTS------------------------------");
                        Console.ResetColor();
                    }
                    else
                    {

                        project.ProjectId = projectId;
                        break;
                    }
                }

                Console.WriteLine("Enter projectName: ");
                project.ProjectName = Console.ReadLine() ?? string.Empty;

                Console.WriteLine("Enter StartDate: ");
                project.StartDate = DateTime.Parse(Console.ReadLine() ?? string.Empty);

                Console.WriteLine("Enter EndDate: ");
                project.EndDate = DateTime.Parse(Console.ReadLine() ?? string.Empty);

                while (project.StartDate >= project.EndDate)
                {

                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.WriteLine("INVALID PROJECT DETAILS : END DATE MUST BE AFTER START DATE.");
                    Console.ResetColor();
                    Console.WriteLine("Please Enter Valid EndDate: ");
                    project.EndDate = DateTime.Parse(Console.ReadLine() ?? string.Empty);

                }

                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("------------------------PROJECT DETAILS ADDED SUCCESSFULLY-----------------------------");
                Console.ResetColor();
                projectRepo.AddEntity(project);


                Console.WriteLine("Do you want add employee to project ? (yes/no)");
                string y = Console.ReadLine() ?? string.Empty;


                if (y == "yes" || y == "Yes")
                {
                    EmployeeRepo employeeRepo = new EmployeeRepo();
                    List<Employee> employeeList = employeeRepo.ListAll();

                    if (employeeList.Count() == 0)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                        Console.WriteLine("There are no Employees in Employee list.");
                        Console.ResetColor();

                    }
                    else
                    {

                        EmployeeProject obj = new EmployeeProject();
                        int employeeId;
                        obj.ProjectId = project.ProjectId;
                        obj.ProjectName = project.ProjectName;

                        Console.WriteLine("Enter the number of employees you want to add : ");
                        int size = int.Parse(Console.ReadLine() ?? string.Empty);
                        for (int j = 0; j < size; j++)
                        {

                            while (true)
                            {
                                while (true)
                                {
                                    Console.WriteLine("Enter EmployeeId : ");
                                    employeeId = int.Parse(Console.ReadLine() ?? string.Empty);

                                    if (employeeId == 0)
                                    {
                                        return;
                                    }
                                    
                                    EmployeeDal employeeDal = new EmployeeDal();
                                    //var employeeExist = EmployeeRepo.employeeList.Exists(item => item.EmployeeId == employeeId);

                                    if (employeeDal.IsEmployeeExists(employeeId))
                                    {
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Employee Doesn't Exist.");
                                        break;
                                    }
                                }
                                
                                EmployeeProjectDal employeeProjectDal = new EmployeeProjectDal();
                                //var employeeProjectExist = EmployeeProjectRepo.employeeProjectList.Exists(item => item.ProjectId == projectId && item.EmployeeId == employeeId);

                                if (employeeProjectDal.IsEmployeeProjectExists(projectId,employeeId))
                                {
                                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                                    Console.WriteLine("Employee already exist in the project.");
                                    Console.ResetColor();
                                    break;
                                }
                                else
                                {
                                    //EmployeeRepo employeeRepo = new EmployeeRepo();
                                    var query2 = employeeRepo.ListById(employeeId);
                                    // from item in EmployeeRepo.employeeList
                                    //              where item.EmployeeId == employeeId
                                    //              select new { item.EmployeeId, item.FirstName, item.LastName, item.RoleId };

                                    foreach (var item in query2)
                                    {
                                        obj.EmployeeId = item.EmployeeId;
                                        obj.FirstName = item.FirstName;
                                        obj.LastName = item.LastName;
                                        obj.RoleId = item.RoleId;

                                    }
                                    //break;

                                }

                                //EmployeeProjectRepo.employeeProjectList.Add(obj);

                                // foreach (EmployeeProject item in EmployeeProjectRepo.employeeProjectList)
                                // {
                                //     System.Console.WriteLine("PROJECT DETAILS : ");

                                //     System.Console.WriteLine("EmployeeId: {0} , Roleid : {1} , Project Id :{2}", item.EmployeeId, item.RoleId, item.ProjectId);
                                // }

                                employeeProjectRepo.AddEmployeeToProject(obj.ProjectId,obj.ProjectName,employeeId,obj.FirstName,obj.LastName, obj.RoleId);

                                Console.ForegroundColor = ConsoleColor.DarkCyan;
                                Console.WriteLine("-----------EMPLOYEE  ADDED TO PROJECT SUCCESSFULLY-------------------");
                                Console.ResetColor();
                                break;
                            }

                            // EmployeeProjectRepo.AddEmployeeToProject(obj.ProjectId, obj.ProjectName, employeeId, obj.FirstName, obj.LastName, obj.RoleId);

                            // Console.ForegroundColor = ConsoleColor.DarkCyan;
                            // Console.WriteLine("-----------EMPLOYEE  ADDED TO PROJECT SUCCESSFULLY-------------------");
                            // Console.ResetColor();
                        }


                    }

                }



                else
                {
                    Console.WriteLine("not interested.");
                }

            }

        }

        public List<Project> ViewProjects()
        {
            ProjectRepo projectRepo = new();

            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("VIEW PROJECTS : ");
            Console.ResetColor();
            Console.WriteLine();
            if (projectRepo.ListAll().Count() <= 0)
            {
                Console.WriteLine("THE LIST IS EMPTY.");

            }

            else
            {
                foreach (Project item in projectRepo.ListAll())
                {

                    Console.WriteLine("ProjectId : {0} , ProjectName : {1} , StartDate : {2} , EndDate : {3}", item.ProjectId, item.ProjectName, item.StartDate, item.EndDate);

                }
            }
            return ProjectRepo.projectList;

        }

        public void ViewProjectById()
        {
            ViewProjects();

            ProjectRepo projectRepo = new ProjectRepo();
            List<Project> projectList = projectRepo.ListAll();

            if (projectList.Count() > 0)
            {
                while (true)
                {

                    Console.WriteLine("Enter ProjectId : ");
                    int ProjectId = int.Parse(Console.ReadLine() ?? string.Empty);


                    List<Project> projectlist = projectRepo.ListById(ProjectId);

                    if (projectlist.Count > 0)
                    {

                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                        Console.WriteLine("VIEW PROJECT DETAILS : ");
                        Console.ResetColor();

                        foreach (Project item in projectlist)
                        {
                            if (item.ProjectId == ProjectId)
                            {

                                Console.WriteLine("ProjectId : {0} , ProjectName : {1} , StartDate : {2} , EndDate : {3}", item.ProjectId, item.ProjectName, item.StartDate, item.EndDate);

                            }

                        }

                        break;
                    }

                    else
                    {

                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                        Console.WriteLine("PROJECTID DOESN'T EXIST.");
                        Console.ResetColor();

                    }
                }

            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("The Project List is Empty.");
                Console.ResetColor();
            }
        }

        public void DeleteProjectById()
        {
            ViewProjects();
            ProjectRepo projectRepo = new ProjectRepo();
            List<Project> projectList = projectRepo.ListAll();

            if (projectList.Count() > 0)
            {

                while (true)
                {
                    Console.WriteLine("Enter ProjectId : ");
                    int validProjectId = int.Parse(Console.ReadLine() ?? string.Empty);
                    ProjectDal projectDal = new ProjectDal();
                    EmployeeProjectDal employeeProjectDal = new EmployeeProjectDal();
                    if (projectDal.IsProjectExists(validProjectId))
                    {

                        if (employeeProjectDal.IsProjectExist(validProjectId))
                        {

                            Console.ForegroundColor = ConsoleColor.DarkCyan;
                            System.Console.WriteLine("Project is ongoing so you can't delete it.");
                            Console.ResetColor();
                            break;

                        }

                        else
                        {

                            projectRepo.Delete(validProjectId);
                            Console.ForegroundColor = ConsoleColor.DarkCyan;
                            Console.WriteLine("------------------------PROJECT REMOVED SUCCESSFULLY-----------------------------------");
                            Console.ResetColor();
                            break;

                        }
                    }

                    else
                    {
                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                        Console.WriteLine("PROJECTID DOESN'T EXIST.");
                        Console.ResetColor();
                    }
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("Project List is Empty.");
                Console.ResetColor();
            }

        }

    }

}




