
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

            while (true)

            {

               System.Console.WriteLine("Enter the projectId : ");

               projectId = int.Parse(System.Console.ReadLine() ?? string.Empty);

               if (projectId == 0)
               {
                  return;

               }

               bool projectExist = ProjectRepo.projectList.Any(p => p.ProjectId == projectId);

               if (projectExist)
               {
                  break;
               }

               else

               {
                  System.Console.WriteLine();
                  System.Console.WriteLine("Please Enter Correct projectId.");

               }

            }

            var query1 = from item in ProjectRepo.projectList
                         where item.ProjectId == projectId
                         select new { item.ProjectId, item.ProjectName };

            foreach (var item in query1)
            {

               projectId = item.ProjectId;
               projectName = item.ProjectName;

            }

            employeeConsoles.ViewEmployees();

            int employeeId;

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

                  bool employeeExist = EmployeeRepo.employeeList.Any(p => p.EmployeeId == employeeId);

                  if (employeeExist)
                  {

                     break;

                  }

                  else
                  {

                     System.Console.WriteLine("Please Enter Correct EmployeeId.");

                  }

               }

               bool employeeProjectExist = EmployeeProjectRepo.employeeProjectList.Any(p => p.ProjectId == projectId && p.EmployeeId == employeeId);

               if (employeeProjectExist)
               {
                  System.Console.WriteLine("Employee already added to the project.");

               }

               else
               {

                  var query2 = from items in EmployeeRepo.employeeList
                               where items.EmployeeId == employeeId
                               select new { items.EmployeeId, items.FirstName, items.LastName, items.RoleId };

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

            employeeProjectRepo.AddEmployeeToProject(projectId,projectName,employeeId,firstName, lastName ,roleId);

            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("-----------EMPLOYEE  ADDED TO PROJECT SUCCESSFULLY-------------------");
            Console.ResetColor();


         }

         public void RemoveEmployeefromProjectMethod()
         {

            var flag = true;

            while (flag)

            {

             //  ViewProjects();
               ViewAddEmployeetoProject();

               while (true)
               {
                  Console.WriteLine("Enter the ProjectId : ");
                  projectId = int.Parse(Console.ReadLine() ?? string.Empty);

                  var projectExist = ProjectRepo.projectList.Exists(item => item.ProjectId == projectId);

                  if (projectExist)
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

               var employeeExist = EmployeeRepo.employeeList.Exists(item => item.EmployeeId == employeeId);

               if (employeeExist)
               {


                  bool employeeInProject = EmployeeProjectRepo.employeeProjectList.Exists(item => item.ProjectId == projectId && item.EmployeeId == employeeId);

                  if (employeeInProject)
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

         }

         public List<EmployeeProject> ViewAddEmployeetoProject()
         {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("VIEW EMPLOYEES IN PROJECT: ");
            Console.ResetColor();
            Console.WriteLine();

            if (EmployeeProjectRepo.employeeProjectList.Count <= 0)
            {
               Console.WriteLine("The list is Empty.");
            }
            else
            {

               foreach (EmployeeProject item in EmployeeProjectRepo.employeeProjectList)
               {
                  Console.WriteLine("ProjectId : {0}, ProjectName : {1} , EmployeeId : {2} , FirstName : {3} , LastName : {4} , RoleId : {5} ", item.ProjectId, item.ProjectName, item.EmployeeId, item.FirstName, item.LastName, item.RoleId);
               }
            }

            return EmployeeProjectRepo.employeeProjectList;
         }

      }

   }




   
