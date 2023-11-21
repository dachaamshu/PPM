using PPM.Model;
using PPM.DAL;
namespace PPM.Domain
{
    public class EmployeeRepo : IEntityOperation<Employee>
    {

        public static List<Employee> employeeList = new List<Employee>();
        public void AddEntity(Employee employeeDetails)
        {
            //employeeList.Add(employeeDetails);
            EmployeeDal employeeDal = new EmployeeDal();
            employeeDal.AddEmployee(employeeDetails);
            
        }

        public List<Employee> ListAll()
        {
            //return employeeList;
            EmployeeDal employeeDal = new EmployeeDal();
            var employeelist = employeeDal.ViewEmployee();
            return employeelist;
        }
        public List<Employee> ListById(int id)

        {
            //return employeeList.Find(item => item.EmployeeId == id)!;
            EmployeeDal employeeDal = new EmployeeDal();
            var employeelist = employeeDal.ViewEmployeeByIdDal(id);
            return employeelist;
        }

        public void Delete(int id)
        {
            // var t = employeeList.SingleOrDefault(item => item.EmployeeId == id);
            // if (t != null)
            // {
            //     employeeList.Remove(t);
            // }
            EmployeeDal employeeDal = new EmployeeDal();
            employeeDal.DeleteEmployeeByIdDal(id);

        }
    }
}





