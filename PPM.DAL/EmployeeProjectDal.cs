using System.Data.SqlClient;
using PPM.Model;
namespace PPM.DAL
{
   public class EmployeeProjectDal
   {
      string connect = "Server = RHJ-9F-D070\\SQLEXPRESS ; Database = PROLIFICSPROJECTMANAGER ; Integrated Security=true";

      public void AddEmployeeToProjectDal(EmployeeProject employeeProject)
      {
         using (SqlConnection connection = new SqlConnection(connect))
         {
            connection.Open();

            using (SqlCommand command = new SqlCommand("Insert into EmployeeProject(ProjectId,ProjectName,EmployeeId,FirstName,LastName,RoleId) values(@projectId,@projectName,@employeeId,@firstName,@lastName,@roleId)", connection))
            {
               command.Parameters.AddWithValue("@projectId", employeeProject.ProjectId);
               command.Parameters.AddWithValue("@projectName",employeeProject.ProjectName);
               command.Parameters.AddWithValue("@employeeId", employeeProject.EmployeeId);
               command.Parameters.AddWithValue("@firstName",employeeProject.FirstName);
               command.Parameters.AddWithValue("@lastName",employeeProject.LastName);
               command.Parameters.AddWithValue("@roleId", employeeProject.RoleId);
               command.ExecuteNonQuery();
            }
         }
      }

      public bool IsEmployeeProjectExists(int projectId, int employeeId)
      {
         using (SqlConnection connection = new SqlConnection(connect))
         {
            connection.Open();
            string query = "Select count(*) from EmployeeProject where ProjectId = @projectId AND EmployeeId = @employeeId";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
               command.Parameters.AddWithValue("@projectId", projectId);
               command.Parameters.AddWithValue("@employeeId", employeeId);

               int employeeProjectCount = (int)command.ExecuteScalar();

               return employeeProjectCount > 0;
            }
         }
      }

      public bool IsEmployeeExist(int employeeId)
      {
         using (SqlConnection connection = new SqlConnection(connect))
         {
            connection.Open();
            string query = "Select count(*) from EmployeeProject where EmployeeId = @employeeId";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
               command.Parameters.AddWithValue("@employeeId", employeeId);

               int employeeCount = (int)command.ExecuteScalar();

               return employeeCount > 0;
            }
         }
      }

      public bool IsProjectExist(int projectId)
      {
         using (SqlConnection connection = new SqlConnection(connect))
         {
            connection.Open();
            string query = "Select count(*) from EmployeeProject where ProjectId = @projectId";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
               command.Parameters.AddWithValue("@projectId", projectId);

               int projectCount = (int)command.ExecuteScalar();

               return projectCount > 0;
            }
         }
      }

      public List<EmployeeProject> ViewEmployeeInProject()
      {
         List<EmployeeProject> employeeProjectList = new List<EmployeeProject>();
         using (SqlConnection connection = new SqlConnection(connect))
         {
            connection.Open();

            using (SqlCommand command = new SqlCommand("Select * from EmployeeProject", connection))
            {
               SqlDataReader reader = command.ExecuteReader();

               while (reader.Read())
               {
                  EmployeeProject employeeProject = new EmployeeProject();
                  employeeProject.ProjectId = Convert.ToInt32(reader["ProjectId"]);
                  employeeProject.ProjectName = reader["ProjectName"].ToString();
                  employeeProject.EmployeeId = Convert.ToInt32(reader["EmployeeId"]);
                  employeeProject.FirstName = reader["FirstName"].ToString();
                  employeeProject.LastName = reader["LastName"].ToString();
                  employeeProject.RoleId = Convert.ToInt32(reader["RoleId"]);
                  employeeProjectList.Add(employeeProject);

               }

            }

         }
         return employeeProjectList;
      }

      public void RemoveEmployeefromProjectDal(int projectId,int employeeId)
      {
         using (SqlConnection connection = new SqlConnection(connect))
         {
            connection.Open();

            using (SqlCommand cmd = new SqlCommand("DELETE FROM EmployeeProject WHERE ProjectId = @projectId AND EmployeeId = @employeeId", connection))
            {
               cmd.Parameters.AddWithValue("@projectId",projectId);
               cmd.Parameters.AddWithValue("@employeeId", employeeId);
               cmd.ExecuteNonQuery();

            }

         }
      }
   }
}