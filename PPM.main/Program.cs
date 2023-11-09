

using System;
using System.Numerics;
using System.Runtime.Loader;
using Microsoft.VisualBasic;
using System.Collections.Generic;
using PPM.Domain;
using PPM.Ui.Consoles;
using System.Reflection.Emit;
namespace PPM.main
{
  public class Program

  {
    public static void Main(string[] args)

    {

      int choice = 0;
      do
      {
        choice = MainConsoles.MainMethod();

        switch (choice)
        {

          case 1:

            int selectOption = 0;

            ProjectConsoles projectConsoles = new ProjectConsoles();
            EmployeeProjectConsoles employeeProjectConsoles = new EmployeeProjectConsoles();
            
            do
            {

            selectOption = MainConsoles.ProjectMain();
            

              switch (selectOption)
              {

                case 1:
                          projectConsoles.AddProjectMethod();
                  break;

                case 2:
                          projectConsoles.ViewProjects();
                  break;

                case 3:
                          projectConsoles.ViewProjectById();
                  break;

                case 4:
                          projectConsoles.DeleteProjectById();
                  break;

                case 5 :
                          employeeProjectConsoles.AddEmployeeToProjectMethod();
                  break;

                case 6:
                          employeeProjectConsoles.RemoveEmployeefromProjectMethod();
                  break;

                case 7 :
                           employeeProjectConsoles.ViewAddEmployeetoProject();
                  break;

                case 8 :

                   break;

                default :
                           MainConsoles.DefaultMethod();
                  break;

              }

            } while (selectOption != 8);

            break;


          case 2:

             int option = 0;

            EmployeeConsoles employeeConsoles = new EmployeeConsoles();

            do
            {
               option = MainConsoles.EmployeeMain();
              
              switch (option)
              {

                case 1:
                          employeeConsoles.AddEmployeeMethod();
                  break;

                case 2:
                           employeeConsoles.ViewEmployees();
                  break;

                case 3:
                           employeeConsoles.ViewEmployeeById();
                 break;

                case 4:
                            employeeConsoles.DeleteEmployeeById();
                  break;

                case 5:

                  break;
                
                 default :
                           MainConsoles.DefaultMethod();
                  break;

              }

            } while (option != 5);

            break;

          case 3:

             int selectChoice = 0;

            RoleConsoles roleConsoles = new RoleConsoles();

            do
            {

              selectChoice= MainConsoles.RoleMain();
        
              switch (selectChoice)
              {
                case 1:
                         roleConsoles.AddRoleMethod();
                  break;

                case 2:
                          roleConsoles.ViewRoles();
                  break;

                case 3:
                        roleConsoles.ViewRoleById();
                  break;

                case 4:
                         roleConsoles.DeleteRoleById();
                  break;

                case 5:

                  break;

                 default :
                           MainConsoles.DefaultMethod();
                  break;

              }

            } while (selectChoice != 5);

            break;

          case 4 : 
                   SaveRepo saveRepo = new SaveRepo();
                   MainConsoles.save();
                   saveRepo.SaveData();

            break;

          case 5:
                   MainConsoles.ExitMethod();
            break;

          default :
                    MainConsoles.DefaultMethod();
             break;

        }

      } while (choice != 5);

    }

  }
}


