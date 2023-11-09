namespace PPM.Ui.Consoles
{
    public class MainConsoles
    {
        public static int MainMethod()
        {
            int choice = 0;

            Console.WriteLine("---------------------------------------------------------------------------------------");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("                        PROLIFICSPROJECTMANAGER                                        ");
            Console.ResetColor();
            Console.WriteLine("---------------------------------------------------------------------------------------");
            Console.WriteLine("1.PROJECT MODULE.");
            Console.WriteLine("2.EMPLOYEE MODULE.");
            Console.WriteLine("3.ROLE MODULE.");
            Console.WriteLine("4.SAVE APP DATA.");
            Console.WriteLine("5.EXIT.");
            Console.WriteLine("---------------------------------------------------------------------------------------");

            Console.WriteLine("Enter selected option :");

            choice = int.Parse(Console.ReadLine() ?? string.Empty);

            return choice;
        }

        public static int ProjectMain()
        {
            int selectOption = 0;

            Console.WriteLine("---------------------------------------------------------------------------------------");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("                        PROJECT MODULE                                                 ");
            Console.ResetColor();
            Console.WriteLine("---------------------------------------------------------------------------------------");
            Console.WriteLine("1. Add Project.");
            Console.WriteLine("2. View Projects. ");
            Console.WriteLine("3. List By Id. ");
            Console.WriteLine("4. Delete the Project.");
            Console.WriteLine("5. Add Employee to the Project.");
            Console.WriteLine("6. Remove Employee from the Project.");
            Console.WriteLine("7. View Employees in the Project.");
            Console.WriteLine("8. Return to Main Menu. ");
            Console.WriteLine("---------------------------------------------------------------------------------------");

              Console.WriteLine("Enter selected option :");

             selectOption = int.Parse(Console.ReadLine() ?? string.Empty);

             return selectOption;

        }

        public static int EmployeeMain()
        {
            int option = 0;

            Console.WriteLine("---------------------------------------------------------------------------------------");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("                        EMPLOYEE MODULE                                                 ");
            Console.ResetColor();
            Console.WriteLine("----------------------------------------------------------------------------------------");
            Console.WriteLine("1. Add Employee.");
            Console.WriteLine("2. View Employees. ");
            Console.WriteLine("3. List By Id. ");
            Console.WriteLine("4. Delete the Employee.");
            Console.WriteLine("5. Return to Main Menu. ");
            Console.WriteLine("----------------------------------------------------------------------------------------");

            Console.WriteLine("Enter the choice : ");
            option = int.Parse(Console.ReadLine() ?? string.Empty);

            return option;
        }

        public static int RoleMain()
        {
            int selectChoice = 0;
            
            Console.WriteLine("---------------------------------------------------------------------------------------");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("                          ROLE MODULE                                                   ");
            Console.ResetColor();
            Console.WriteLine("----------------------------------------------------------------------------------------");
            Console.WriteLine("1. Add Role.");
            Console.WriteLine("2. View Roles. ");
            Console.WriteLine("3. List By Id. ");
            Console.WriteLine("4. Delete the Role.");
            Console.WriteLine("5. Return to Main Menu. ");
            Console.WriteLine("----------------------------------------------------------------------------------------");

            Console.WriteLine("Enter the choice : ");
            selectChoice = int.Parse(Console.ReadLine() ?? string.Empty);

            return selectChoice;
        }

        public static void ExitMethod()
        {
            Console.WriteLine("Exit.");
        }

        public static void DefaultMethod()
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("Invalid selected option.");
            Console.ResetColor();
        }

        public static void save()
        {
            Console.WriteLine("Data Stored.");
        }
    }
}