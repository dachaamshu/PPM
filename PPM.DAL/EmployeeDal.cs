using System.Data.SqlClient;
using PPM.Model;

namespace PPM.DAL
{
    public class EmployeeDal
    {
        // public static List<Employee> employeeList = new List<Employee>();

        string connect = "Server = RHJ-9F-D070\\SQLEXPRESS ; Database = PROLIFICSPROJECTMANAGER ; Integrated Security=true";
        public void AddEmployee(Employee employee)
        {
            using (SqlConnection connection = new SqlConnection(connect))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("Insert into Employee(EmployeeId, FirstName, LastName, EmailId, MobileNumber, Address, RoleId) Values(@employeeId, @firstName, @lastName, @emailId, @mobileNumber, @address, @roleId)", connection))
                {
                    command.Parameters.AddWithValue("@employeeId", employee.EmployeeId);
                    command.Parameters.AddWithValue("@firstName", employee.FirstName);
                    command.Parameters.AddWithValue("@lastName", employee.LastName);
                    command.Parameters.AddWithValue("@emailId", employee.EmailId);
                    command.Parameters.AddWithValue("@mobileNumber", (long)employee.MobileNumber);
                    command.Parameters.AddWithValue("@address", employee.Address);
                    command.Parameters.AddWithValue("@roleId", employee.RoleId);

                    command.ExecuteNonQuery();
                }
            }
        }

        public bool IsEmployeeExists(int employeeId)
        {
            using (SqlConnection connection = new SqlConnection(connect))
            {
                connection.Open();

                string query = "SELECT COUNT(*) FROM Employee WHERE EmployeeId = @employeeId";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@employeeId", employeeId);

                    int employeeCount = (int)command.ExecuteScalar();

                    return employeeCount > 0;
                }
            }
        }

        public bool IsRoleExist(int roleId)
        {
            using (SqlConnection connection = new SqlConnection(connect))
            {
                connection.Open();

                string query = "SELECT COUNT(*) FROM Employee WHERE RoleId = @roleId";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@roleId", roleId);

                    int roleCount = (int)command.ExecuteScalar();

                    return roleCount > 0;
                }
            }
        }

        public List<Employee> ViewEmployee()
        {
            List<Employee> employeeList = new List<Employee>();
            using (SqlConnection connection = new SqlConnection(connect))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("Select * from Employee", connection))
                {
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        Employee employee = new Employee();
                        employee.EmployeeId = Convert.ToInt32(reader["EmployeeId"]);
                        employee.FirstName = reader["FirstName"].ToString();
                        employee.LastName = reader["LastName"].ToString();
                        employee.EmailId = reader["EmailId"].ToString();
                        employee.MobileNumber = Convert.ToInt64(reader["MobileNumber"]);
                        employee.Address = reader["Address"].ToString();
                        employee.RoleId = Convert.ToInt32(reader["RoleId"]);
                        employeeList.Add(employee);
                    }
                }
            }
            return employeeList;
        }


        public List<Employee> ViewEmployeeByIdDal(int employeeId)
        {
            List<Employee> employeeList = new List<Employee>();
            using (SqlConnection connection = new SqlConnection(connect))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("Select EmployeeId, FirstName, LastName, EmailId, MobileNumber, Address, RoleId from Employee where EmployeeId = @employeeId", connection))
                {
                    command.Parameters.AddWithValue("@EmployeeId",employeeId);
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        Employee employee = new Employee();
                        employee.EmployeeId = Convert.ToInt32(reader["EmployeeId"]);
                        employee.FirstName = reader["FirstName"].ToString();
                        employee.LastName = reader["LastName"].ToString();
                        employee.EmailId = reader["EmailId"].ToString();
                        employee.MobileNumber = Convert.ToInt64(reader["MobileNumber"]);
                        employee.Address = reader["Address"].ToString();
                        employee.RoleId = Convert.ToInt32(reader["RoleId"]);
                        employeeList.Add(employee);
                    }
                }
            }
            return employeeList;
        }

        public void DeleteEmployeeByIdDal(int employeeId)
        {

            using (SqlConnection connection = new SqlConnection(connect))
            {
                connection.Open();

                using (SqlCommand cmd = new SqlCommand("DELETE FROM Employee WHERE EmployeeId = @employeeId", connection))
                {

                    cmd.Parameters.AddWithValue("@employeeId", employeeId);
                    cmd.ExecuteNonQuery();

                }

            }
        }
    }
}


