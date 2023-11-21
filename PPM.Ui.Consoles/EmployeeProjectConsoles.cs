
using PPM.Model;
using PPM.Domain;
using System.Text.RegularExpressions;
using System.Numerics;
using System.Linq;
using System.ComponentModel.Design;
using System.Runtime.CompilerServices;
using System.Collections;
using System.Transactions;
using System.Reflection.Emit;
using System.Linq.Expressions;
using PPM.Dal;
using PPM.DAL;

namespace PPM.Ui.Consoles
{
   public class EmployeeProjectConsoles
   {
      ProjectRepo projectRepo = new ProjectRepo();
      EmployeeRepo employeeRepo = new EmployeeRepo();
      RoleRepo roleRepo = new RoleRepo();
      EmployeeProjectRepo employeeProjectRepo = new EmployeeProjectRepo();

      int projectId;
      string? projectName;
      int employeeId;
      string? firstName;
      string? lastName;

      int roleId;


      EmployeeProject employeeProject = new EmployeeProject();
      ProjectConsoles projectConsoles = new ProjectConsoles();

      EmployeeConsoles employeeConsoles = new EmployeeConsoles();
      public void AddEmployeeToProjectMethod()
      {

         projectConsoles.ViewProjects();

         int projectId;

         ProjectRepo projectRepo = new ProjectRepo();
         List<Project> projectList = projectRepo.ListAll();

         if (projectList.Count() > 0)
         {

            while (true)

            {

               System.Console.WriteLine("Enter the projectId : ");

               projectId = int.Parse(System.Console.ReadLine() ?? string.Empty);

               if (projectId == 0)
               {
                  return;

               }

               ProjectDal projectDal = new ProjectDal();

               //bool projectExist = ProjectRepo.projectList.Any(p => p.ProjectId == projectId);

               if (projectDal.IsProjectExists(projectId))
               {
                  break;
               }

               else

               {
                  System.Console.WriteLine();
                  System.Console.WriteLine("Please Enter Correct projectId.");

               }

            }

            //ProjectRepo projectRepo = new ProjectRepo();
            var query1 = projectRepo.ListById(projectId);
            // from item in ProjectRepo.projectList
            //              where item.ProjectId == projectId
            //              select new { item.ProjectId, item.ProjectName };

            foreach (var item in query1)
            {

               projectId = item.ProjectId;
               projectName = item.ProjectName;

            }

            employeeConsoles.ViewEmployees();

            int employeeId;

            EmployeeRepo employeeRepo = new EmployeeRepo();
            List<Employee> employeeList = employeeRepo.ListAll();

            if (employeeList.Count() > 0)
            {

               while (true)
               {
                  while (true)
                  {

                     System.Console.WriteLine("Enter the EmployeeId : ");
                     employeeId = int.Parse(System.Console.ReadLine() ?? string.Empty);

                     if (employeeId == 0)
                     {
                        return;

                     }

                     EmployeeDal employeeDal = new EmployeeDal();

                     //bool employeeExist = EmployeeRepo.employeeList.Any(p => p.EmployeeId == employeeId);

                     if (employeeDal.IsEmployeeExists(employeeId))
                     {

                        break;

                     }

                     else
                     {

                        System.Console.WriteLine("Please Enter Correct EmployeeId.");

                     }

                  }

                  EmployeeProjectDal employeeProjectDal = new EmployeeProjectDal();
                  //bool employeeProjectExist = EmployeeProjectRepo.employeeProjectList.Any(p => p.ProjectId == projectId && p.EmployeeId == employeeId);

                  if (employeeProjectDal.IsEmployeeProjectExists(projectId, employeeId))
                  {
                     System.Console.WriteLine("Employee already added to the project.");

                  }

                  else
                  {
                     // EmployeeRepo employeeRepo = new EmployeeRepo();
                     var query2 = employeeRepo.ListById(employeeId);
                     // from items in EmployeeRepo.employeeList
                     //              where items.EmployeeId == employeeId
                     //              select new { items.EmployeeId, items.FirstName, items.LastName, items.RoleId };

                     foreach (var item in query2)
                     {

                        employeeId = item.EmployeeId;
                        firstName = item.FirstName;
                        lastName = item.LastName;
                        roleId = item.RoleId;

                     }

                     break;

                  }

               }

               employeeProjectRepo.AddEmployeeToProject(projectId, projectName, employeeId, firstName, lastName, roleId);

               Console.ForegroundColor = ConsoleColor.DarkCyan;
               Console.WriteLine("-----------EMPLOYEE  ADDED TO PROJECT SUCCESSFULLY-------------------");
               Console.ResetColor();
            }
            else
            {
               Console.ForegroundColor = ConsoleColor.DarkCyan;
               Console.WriteLine("The Employee List is Empty.");
               Console.ResetColor();
            }

         }
         else
         {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("The Project List is Empty.");
            Console.ResetColor();
         }
      }

      public void RemoveEmployeefromProjectMethod()
      {

         var flag = true;

         while (flag)
         {
            // ProjectConsoles projectConsoles = new ProjectConsoles();
            // projectConsoles.ViewProjects();
            ViewAddEmployeetoProject();

            // ProjectRepo projectRepo = new ProjectRepo();
            // List<Project> projectList = projectRepo.ListAll();
            EmployeeProjectRepo employeeProjectRepo = new EmployeeProjectRepo();
            List<EmployeeProject> employeeProjectList = employeeProjectRepo.ViewEmployeeProject();

            if (employeeProjectList.Count() > 0)
            {

               while (true)
               {
                  Console.WriteLine("Enter the ProjectId : ");
                  projectId = int.Parse(Console.ReadLine() ?? string.Empty);

                  ProjectDal projectDal = new ProjectDal();

                  //var projectExist = ProjectRepo.projectList.Exists(item => item.ProjectId == projectId);

                  if (projectDal.IsProjectExists(projectId))
                  {

                     break;
                  }
                  else
                  {
                     Console.WriteLine("Please, Enter a valid ProjectId.");
                  }
               }

               //ViewEmployees();
               // ViewAddEmployeetoProject();


               Console.WriteLine("Enter the EmployeeId: ");
               employeeId = int.Parse(Console.ReadLine() ?? string.Empty);

               EmployeeDal employeeDal = new EmployeeDal();

               //var employeeExist = EmployeeRepo.employeeList.Exists(item => item.EmployeeId == employeeId);

               if (employeeDal.IsEmployeeExists(employeeId))
               {

                  EmployeeProjectDal employeeProjectDal = new EmployeeProjectDal();
                  //bool employeeInProject = EmployeeProjectRepo.employeeProjectList.Exists(item => item.ProjectId == projectId && item.EmployeeId == employeeId);

                  if (employeeProjectDal.IsEmployeeProjectExists(projectId, employeeId))
                  {

                     Console.WriteLine();
                     employeeProjectRepo.RemoveEmployeefromProject(projectId, employeeId);
                     Console.ForegroundColor = ConsoleColor.DarkCyan;
                     Console.WriteLine("-----------EMPLOYEE REMOVED FROM THE PROJECT -------------------");
                     Console.ResetColor();


                  }

                  else
                  {
                     Console.WriteLine("Employee not associated with the project.");

                  }

               }


               else
               {

                  Console.WriteLine("Please, Enter a valid EmployeeId.");
                  employeeId = int.Parse(Console.ReadLine() ?? string.Empty);

               }

               System.Console.WriteLine("Do you want to remove another employee from the project? ");

               string choice = System.Console.ReadLine() ?? string.Empty;


               if (choice != "yes")

               {

                  flag = false;

               }
            }
            else
            {
               Console.ForegroundColor = ConsoleColor.DarkCyan;
               Console.WriteLine("The List is Empty.");
               Console.ResetColor();
               break;
            }

         }

      }

      public List<EmployeeProject> ViewAddEmployeetoProject()
      {
         EmployeeProjectRepo employeeProjectRepo = new EmployeeProjectRepo();
         Console.ForegroundColor = ConsoleColor.DarkCyan;
         Console.WriteLine("VIEW EMPLOYEES IN PROJECT: ");
         Console.ResetColor();
         Console.WriteLine();

         if (employeeProjectRepo.ViewEmployeeProject().Count == 0)
         {
            Console.WriteLine("The list is Empty.");
         }
         else
         {

            foreach (EmployeeProject item in employeeProjectRepo.ViewEmployeeProject())
            {
               Console.WriteLine("ProjectId : {0},ProjectName : {1} , EmployeeId : {2} ,FirstName : {3},LastName : {4} , RoleId : {5} ", item.ProjectId, item.ProjectName, item.EmployeeId, item.FirstName, item.LastName, item.RoleId);
            }
         }

         return EmployeeProjectRepo.employeeProjectList;
      }

   }

}





