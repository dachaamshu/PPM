using PPM.Domain;
using PPM.Model;
namespace PPM.Ui.Consoles
{
    public class RoleConsoles 
    {
        RoleRepo roleRepo = new RoleRepo();
        public void AddRoleMethod()
        {
            int size;

            Console.WriteLine("Enter the size: ");
            size = int.Parse(Console.ReadLine() ?? string.Empty);
            for (int i = 0; i < size; i++)
            {

                Role role = new Role();
                while (true)
                {

                    Console.WriteLine("Enter RoleId : ");
                    int roleId = int.Parse(Console.ReadLine() ?? string.Empty);

                    while (roleId <= 0)
                    {

                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                        Console.WriteLine("ROLEID SHOULD NOT BE 0 AND NEGATIVE.");
                        Console.ResetColor();
                        Console.WriteLine("Please,Enter a valid RoleId : ");
                        roleId = int.Parse(Console.ReadLine() ?? string.Empty);

                    }

                    bool roleExists = RoleRepo.roleList.Exists(item => item.RoleId == roleId);

                    if (roleExists)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                        Console.WriteLine("---------------------------------ROLE ID ALREADY EXISTS---------------------------------");
                        Console.ResetColor();
                    }
                    else
                    {

                        role.RoleId = roleId;
                        break;
                    }
                }
                Console.WriteLine("Enter RoleName : ");
                role.RoleName = Console.ReadLine() ?? string.Empty;
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("----------------------------ROLE ADDED SUCCESSFULLY------------------------------------");
                Console.ResetColor();

                roleRepo.AddEntity(role);
            }
        }

        public List<Role> ViewRoles()
        {
            RoleRepo roleRepo = new RoleRepo();

            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("VIEW ROLES: ");
            Console.ResetColor();
            Console.WriteLine();

            if (roleRepo.ListAll().Count() <= 0)
            {
                Console.WriteLine("THE LIST IS EMPTY.");
            }
            else
            {

                foreach (Role item in roleRepo.ListAll())
                {
                    Console.WriteLine("RoleId : {0} , RoleName : {1}", item.RoleId, item.RoleName);
                }
            }

            return RoleRepo.roleList;
        }

        public void ViewRoleById()
        {
            ViewRoles();

            while (true)
            {

                Console.WriteLine("Enter RoleId : ");
                int id = int.Parse(Console.ReadLine() ?? string.Empty);

                if (RoleRepo.roleList.Exists(item => item.RoleId == id))
                {

                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.WriteLine("VIEW ROLE DETAILS: ");
                    Console.ResetColor();
                    foreach (Role item in RoleRepo.roleList)
                    {

                        if (item.RoleId == id)
                        {
                            Console.WriteLine("RoleId : {0} , RoleName : {1}", item.RoleId, item.RoleName);
                            
                        }
                    }
                    break;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.WriteLine("ROLEID DOESN'T EXIST.");
                    Console.ResetColor();
                }
            }
        }

        public void DeleteRoleById()
        {
            ViewRoles();

            if (RoleRepo.roleList.Count() > 0)
            {
                while (true)
                {
                    Console.WriteLine("Enter RoleId : ");
                    int validRoleId = int.Parse(Console.ReadLine() ?? string.Empty);

                    if (RoleRepo.roleList.Exists(item => item.RoleId == validRoleId))
                    {

                        if (EmployeeRepo.employeeList.Exists(item => item.RoleId == validRoleId))
                        {
                            Console.ForegroundColor = ConsoleColor.DarkCyan;
                            Console.WriteLine("Role is assigned to Employee.");
                            Console.ResetColor();
                            break;
                        }
                        else
                        {

                            roleRepo.Delete(validRoleId);
                            Console.ForegroundColor = ConsoleColor.DarkCyan;
                            Console.WriteLine("------------------------------ROLE REMOVED SUCCESSFULLY--------------------------------");
                            Console.ResetColor();
                            break;

                        }

                    }

                    else
                    {
                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                        Console.WriteLine("ROLEID DOESN'T EXIST.");
                        Console.ResetColor();

                    }
                }

            }

            else
            {
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("The Role List is Empty.");
                Console.ResetColor();
            }
        }

    }


}

