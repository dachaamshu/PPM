using PPM.Domain;
using PPM.Model;
using System.Text.RegularExpressions;
using System.Linq.Expressions;
using System.Numerics;
namespace PPM.Ui.Consoles
{
    public class EmployeeConsoles 
    {
        EmployeeRepo employeeRepo = new EmployeeRepo();
        RoleConsoles roleConsoles = new RoleConsoles();

        public void AddEmployeeMethod()
        {
            int length;
            Console.WriteLine("Enter the Length: ");
            length = int.Parse(Console.ReadLine() ?? string.Empty);
            for (int j = 0; j < length; j++)
            {
                Employee employee = new Employee();
                while (true)
                {

                    Console.WriteLine("Enter the EmployeeId : ");
                    int employeeId = int.Parse(Console.ReadLine() ?? string.Empty);

                    while (employeeId <= 0)
                    {

                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                        Console.WriteLine("EMPLOYEEID SHOULD NOT BE 0 AND NEGATIVE.");
                        Console.ResetColor();
                        Console.WriteLine("Please,Enter a valid EmployeeId : ");
                        employeeId = int.Parse(Console.ReadLine() ?? string.Empty);

                    }

                    if (EmployeeRepo.employeeList.Exists(item => item.EmployeeId == employeeId))
                    {
                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                        Console.WriteLine("-------------------------------EMPLOYEE DETAILS ALREADY EXISTS--------------------------");
                        Console.ResetColor();
                    }

                    else
                    {
                        employee.EmployeeId = employeeId;
                        break;
                    }
                }

                Console.WriteLine("Enter the FirstName : ");
                employee.FirstName = Console.ReadLine() ?? string.Empty;

                Console.WriteLine("Enter the LastName : ");
                employee.LastName = Console.ReadLine() ?? string.Empty;

                Console.WriteLine("Enter the EmailId : ");
                employee.EmailId = Console.ReadLine() ?? string.Empty;

                if (!Regex.IsMatch(employee.EmailId, @"^[^@\s]+@[^@\s]+\.(com|net|org|gov|in|co.in)$"))
                {
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.WriteLine("INCORRECT EMAIL FORMAT.PLEASE,TRY AGAIN!");
                    Console.ResetColor();
                    Console.WriteLine("Please Enter the Valid EmailId : ");
                    employee.EmailId = Console.ReadLine() ?? string.Empty;

                }

                Console.WriteLine("Enter the MobileNumber : ");
                employee.MobileNumber = BigInteger.Parse(Console.ReadLine() ?? string.Empty);

                while (employee.MobileNumber.ToString().Length > 10 || employee.MobileNumber.ToString().Length < 10 || employee.MobileNumber.ToString().Length < 0)
                {
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.WriteLine("INVALID MOBILE NUMBER.");
                    Console.ResetColor();
                    Console.WriteLine("Please Enter Valid MobileNumber : ");
                    employee.MobileNumber = BigInteger.Parse(Console.ReadLine() ?? string.Empty);
                }

                Console.WriteLine("Enter the Address : ");
                employee.Address = Console.ReadLine() ?? string.Empty;

                roleConsoles.ViewRoles();

                if (RoleRepo.roleList.Count == 0)
                {

                    employee.RoleId = 0;

                }

                else
                {

                    while (true)
                    {

                        Console.WriteLine("Enter the RoleId : ");
                        int RoleId = int.Parse(Console.ReadLine() ?? string.Empty);

                        var roleExists = RoleRepo.roleList.Exists(item => item.RoleId == RoleId);

                        if (roleExists)
                        {
                            employee.RoleId = RoleId;
                            break;
                        }
                        else
                        {

                            Console.WriteLine("Please Enter a valid RoleId.");

                        }
                    }
                }

                var query1 = from item in RoleRepo.roleList
                             where item.RoleId == employee.RoleId
                             select new { item.RoleId };

                foreach (var item in query1)
                {
                    employee.RoleId = item.RoleId;
                }

                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("----------------------------EMPLOYEE DETAILS ADDED SUCCESSFULLY------------------------");
                Console.ResetColor();

                employeeRepo.AddEntity(employee);
            }
        }



        public List<Employee> ViewEmployees()
        {
            EmployeeRepo employeeRepo = new EmployeeRepo();

            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("VIEW EMPLOYEES :  ");
            Console.ResetColor();
            Console.WriteLine();

            if (employeeRepo.ListAll().Count() == 0)
            {

                Console.WriteLine("THE LIST IS EMPTY.");

            }

            else

            {
                foreach (Employee item in employeeRepo.ListAll())
                {

                    Console.WriteLine("EmployeeId : {0} , FirstName : {1} , LastName : {2} , EmailId : {3} , MobileNumber : {4} , Address : {5} , RoleId : {6}", item.EmployeeId, item.FirstName, item.LastName, item.EmailId, item.MobileNumber, item.Address, item.RoleId);

                }
            }
            return EmployeeRepo.employeeList;
        }

        public void ViewEmployeeById()
        {
            ViewEmployees();

            while (true)
            {

                Console.WriteLine("Enter EmployeeId : ");
                int id = int.Parse(Console.ReadLine() ?? string.Empty);

                if (EmployeeRepo.employeeList.Exists(item => item.EmployeeId == id))
                {

                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.WriteLine("VIEW EMPLOYEE DETAILS :  ");
                    Console.ResetColor();

                    foreach (Employee item in EmployeeRepo.employeeList)
                    {

                        if (item.EmployeeId == id)
                        {
                            Console.WriteLine("EmployeeId : {0} , FirstName : {1} , LastName : {2} , EmailId : {3} , MobileNumber : {4} , Address : {5} , RoleId : {6}", item.EmployeeId, item.FirstName, item.LastName, item.EmailId, item.MobileNumber, item.Address, item.RoleId);

                        }
                        
                    }
                    break;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.WriteLine("EMPLOYEEID DOESN'T EXIST.");
                    Console.ResetColor();
                }
            }

        }


        public void DeleteEmployeeById()
        {

            ViewEmployees();

            if (EmployeeRepo.employeeList.Count() > 0)
            {

                while (true)
                {

                    Console.WriteLine("Enter EmployeeId : ");
                    int validEmployeeId = int.Parse(Console.ReadLine() ?? string.Empty);
                    if (EmployeeRepo.employeeList.Exists(item => item.EmployeeId == validEmployeeId))
                    {
                        if (EmployeeProjectRepo.employeeProjectList.Exists(item => item.EmployeeId == validEmployeeId))
                        {
                            Console.ForegroundColor = ConsoleColor.DarkCyan;
                            System.Console.WriteLine("Employee is assigned to Project.");
                            Console.ResetColor();
                            break;
                        }

                        else
                        {
                            employeeRepo.Delete(validEmployeeId);
                            Console.ForegroundColor = ConsoleColor.DarkCyan;
                            Console.WriteLine("------------------------EMPLOYEE REMOVED SUCCESSFULLY----------------------------------");
                            Console.ResetColor();
                            break;
                        }
                    }

                    else
                    {
                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                        Console.WriteLine("EMPLOYEEID DOESN'T EXIST.");
                        Console.ResetColor();
                    }
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("The Employee List is Empty.");
                Console.ResetColor();
            }

        }


    }
}


