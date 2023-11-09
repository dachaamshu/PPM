using NUnit.Framework;
using PPM.Ui.Consoles;
using PPM.Model;
using PPM.Domain;

namespace PPM.Test
{
    [TestFixture]
    public class EmployeeConsolesTest
    {
        EmployeeConsoles employeeConsoles = new EmployeeConsoles();

        [Test]
        public void AddEmployeeMethodValidInput()
        {

            var input = new StringReader("1\n4\nVaish\nPeddaboina\nvaish@gmail.com\n9133797959\nnzb\n1\n");

            Console.SetIn(input);

            employeeConsoles.AddEmployeeMethod();

        }


        [Test]
        public void AddEmployeeNegativeEmployeeId()

        {

            var input = new StringReader("1\n-1\n5\nshivani\nceela\nshivani@gmail.com\n9133797958\nnzb\n1\n");

            Console.SetIn(input);

            employeeConsoles.AddEmployeeMethod();

        }


        [Test]
        public void AddEmployeeDuplicateId()

        {

            var input = new StringReader("2\n10\nAkhila\nKommu\nakhila@gmail.com\n9848908030\nhyd\n1\n10\n2\nameena\nrathod\nameena@gmail.com\n9010425313\nhyd\n1\n");
            Console.SetIn(input);
            employeeConsoles.AddEmployeeMethod();
        }


        [Test]
        public void AddEmployeeInvalidEmailId()

        {

            var input = new StringReader("1\n6\nsrujana\neegala\ndgh.com\nsrujana@gmail.com\n9912005177\nwarangal\n1\n");

            Console.SetIn(input);

            employeeConsoles.AddEmployeeMethod();


        }


        [Test]
        public void AddEmployeeInvalidMobileNumber()

        {

            var input = new StringReader("1\n7\nsurya\ndacha\ndgh@gmail.com\n913379797\n91337979598\n9133797959\nkmr\n1\n");

            Console.SetIn(input);

            employeeConsoles.AddEmployeeMethod();

        }

        [Test]
        public void ViewEmployeeTest()
        {
            Employee employee = new Employee()
            {
                EmployeeId = 3,
                FirstName = "DACHA",
                LastName = "AMSHU",
                EmailId = "dacha@gmail.com",
                MobileNumber = 9133797959,
                RoleId = 2
            };

            EmployeeRepo.employeeList.Add(employee);

            List<Employee> employeeList = employeeConsoles.ViewEmployees();

            Assert.IsTrue(EmployeeRepo.employeeList.Contains(employee));

        }

        [Test]
        public void ViewEmployeeByEmployeeIdTest()
        {

            var input = new StringReader("-1\n4");
            Console.SetIn(input);
            employeeConsoles.ViewEmployeeById();

        }

        [Test]
        public void DeleteEmployeeByEmployeeIdTest()
        {

            var input = new StringReader("-1\n5");
            Console.SetIn(input);
            employeeConsoles.DeleteEmployeeById();

        }

    }

}
