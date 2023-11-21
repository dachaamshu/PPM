using System.Data.SqlClient;
using PPM.Model;

namespace PPM.Dal
{
    public class ProjectDal
    {
        //public static List<Project> projectList = new List<Project>();
        string connect = "Server = RHJ-9F-D070\\SQLEXPRESS ; Database = PROLIFICSPROJECTMANAGER ; Integrated Security=true";

        public void AddProject(Project project)
        {
            using (SqlConnection connection = new SqlConnection(connect))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("INSERT INTO Project (ProjectId, ProjectName, StartDate, EndDate) VALUES (@projectId, @ProjectName, @StartDate, @EndDate)", connection))
                {
                    DateTime startDateTime = new DateTime(project.StartDate.Year, project.StartDate.Month, project.StartDate.Day, 0, 0, 0);
                    DateTime endDateTime = new DateTime(project.EndDate.Year, project.EndDate.Month, project.EndDate.Day, 0, 0, 0);

                    command.Parameters.AddWithValue("@projectId", project.ProjectId);
                    command.Parameters.AddWithValue("@projectName", project.ProjectName);
                    command.Parameters.AddWithValue("@startDate", startDateTime);
                    command.Parameters.AddWithValue("@endDate", endDateTime);


                    command.ExecuteNonQuery();
                }
            }
        }


        public bool IsProjectExists(int projectId)
        {
            using (SqlConnection connection = new SqlConnection(connect))
            {
                connection.Open();

                string query = "SELECT COUNT(*) FROM Project WHERE ProjectId = @ProjectId";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ProjectId", projectId);

                    int projectCount = (int)command.ExecuteScalar();

                    return projectCount > 0;
                }
            }
        }

        public List<Project> ViewProject()
        {
            List<Project> projectList = new List<Project>();
            using (SqlConnection connection = new SqlConnection(connect))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("Select * from Project", connection))
                {
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        Project project = new Project();
                        project.ProjectId = Convert.ToInt32(reader["ProjectId"]);
                        project.ProjectName = reader["ProjectName"].ToString();
                        project.StartDate = Convert.ToDateTime(reader["StartDate"]);
                        project.EndDate = Convert.ToDateTime(reader["EndDate"]);
                        projectList.Add(project);
                    }
                }
            }
            return projectList;
        }

        public List<Project> ViewProjectByIdDal(int projectId)
        {
            List<Project> projectList = new List<Project>();

            using (SqlConnection connection = new SqlConnection(connect))
            {
                connection.Open();

                using (SqlCommand cmd = new SqlCommand("SELECT ProjectId, ProjectName, StartDate, EndDate FROM Project WHERE ProjectId = @projectId", connection))
                {
                    cmd.Parameters.AddWithValue("@projectId", projectId);
                    SqlDataReader reader = cmd.ExecuteReader();

                        while (reader.Read())
                        {
                            Project project = new Project();
                            project.ProjectId = Convert.ToInt32(reader["ProjectId"]);
                            project.ProjectName = Convert.ToString(reader["ProjectName"]);
                            project.StartDate = Convert.ToDateTime(reader["StartDate"]);
                            project.EndDate = Convert.ToDateTime(reader["EndDate"]);

                            projectList.Add(project);
                        }
                    
                }
            }

            return projectList;
        }

        public void DeleteProjectByIdDal(int projectId)
        {

            using (SqlConnection connection = new SqlConnection(connect))
            {
                connection.Open();

                using (SqlCommand cmd = new SqlCommand("DELETE FROM Project where ProjectId = @projectId", connection))
                {

                    cmd.Parameters.AddWithValue("@ProjectId", projectId);
                    cmd.ExecuteNonQuery();
                }

            }
        }
    }
}