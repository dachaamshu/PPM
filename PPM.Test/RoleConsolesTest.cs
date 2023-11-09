using NUnit.Framework;
using PPM.Domain;
using PPM.Model;
using PPM.Ui.Consoles;

namespace PPM.Test
{
    [TestFixture]
    public class RoleConsolesTest
    {
        RoleConsoles roleConsoles = new RoleConsoles();

        [Test]
        public void AddRoleMethodValidInput()
        {

            var input = new StringReader("1\n2\nDeveloper\n");
            Console.SetIn(input);
            roleConsoles.AddRoleMethod();

        }

        [Test]
        public void AddRoleMethodNegativeRoleId()
        {

            var input = new StringReader("1\n-1\n3\nHR");
            Console.SetIn(input);
            roleConsoles.AddRoleMethod();

        }

        [Test]
        public void AddRoleMethodDupicateRoleId()
        {

            var input = new StringReader("2\n4\ntester\n4\n5\nMarketing\n");
            Console.SetIn(input);
            roleConsoles.AddRoleMethod();

        }

        [Test]
        public void ViewRoleTest()
        {
            Role role = new Role()
            {
                RoleId = 1,
                RoleName = "MANAGER"
            };

            RoleRepo.roleList.Add(role);

            List<Role> roleList = roleConsoles.ViewRoles();

            Assert.IsTrue(RoleRepo.roleList.Contains(role));

        }

        [Test]
        public void ViewRoleByRoleIdTest()
        {

            var input = new StringReader("-1\n2");
            Console.SetIn(input);
            roleConsoles.ViewRoleById();

        }

        [Test]
        public void DeleteRoleByRoleIdTest()
        {

            var input = new StringReader("-1\n3");
            Console.SetIn(input);
            roleConsoles.DeleteRoleById();

        }

    }

}