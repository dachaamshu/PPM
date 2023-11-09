using PPM.Model;

namespace PPM.Domain
{
    public class EmployeeRepo : IEntityOperation<Employee>
    {

        public static List<Employee> employeeList = new List<Employee>();
        public void AddEntity(Employee employeeDetails)
        {
            employeeList.Add(employeeDetails);

        }

        public List<Employee> ListAll()
        {
            return employeeList;
        }
        public Employee ListById(int id)

        {
            return employeeList.Find(item => item.EmployeeId == id)!;
        }

        public void Delete(int id)
        {
            var t = employeeList.SingleOrDefault(item => item.EmployeeId == id);
            if (t != null)
            {
                employeeList.Remove(t);
            }
        }
    }
}





