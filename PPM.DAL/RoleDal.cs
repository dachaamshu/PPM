using System.Data.SqlClient;
using System.Net.Sockets;
using PPM.Model;


namespace PPM.DAL
{
    public class RoleDal
    {
        public static List<Role> roleList = new List<Role>();
        string connect = "Server = RHJ-9F-D070\\SQLEXPRESS ; Database = PROLIFICSPROJECTMANAGER ; Integrated Security=true";
        public void AddRole(Role role)
        {
            using (SqlConnection connection = new SqlConnection(connect))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("Insert into Role(RoleId,RoleName) VALUES(@roleId,@roleName)", connection))
                {
                    command.Parameters.AddWithValue("@roleId", role.RoleId);
                    command.Parameters.AddWithValue("@roleName", role.RoleName);

                    command.ExecuteNonQuery();
                }

            }
        }

        public bool IsRoleExists(int roleId)
        {
            using (SqlConnection connection = new SqlConnection(connect))
            {
                connection.Open();

                string query = "SELECT COUNT(*) FROM Role WHERE RoleId = @roleId";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@roleId", roleId);

                    int roleCount = (int)command.ExecuteScalar();
                    
                    return roleCount > 0;
    
                }
            }
        }

        public List<Role> ViewRole()
        {
            List<Role> roleList = new List<Role>();
            using(SqlConnection connection = new SqlConnection(connect))
            {
                connection.Open();
                
                using(SqlCommand command = new SqlCommand("Select RoleId,RoleName from Role",connection))
                {
                    SqlDataReader reader = command.ExecuteReader();

                    while(reader.Read())
                    {
                        Role role = new Role();
                        role.RoleId = Convert.ToInt32(reader["RoleId"]);
                        role.RoleName = reader["RoleName"].ToString();
                        roleList.Add(role);
                    }
                }
            }
            return roleList;
        }

        public List<Role> ViewRoleIdByDal(int roleId)
        {
            List<Role> roleList = new List<Role>();

            using(SqlConnection connection = new SqlConnection(connect))
            {
                connection.Open();
                
                using(SqlCommand command = new SqlCommand("Select RoleId,RoleName from Role where RoleId = @RoleId",connection))
                {
                    command.Parameters.AddWithValue("@RoleId",roleId);
                    SqlDataReader reader = command.ExecuteReader();

                    while(reader.Read())
                    {
                        Role role = new Role();
                        role.RoleId = Convert.ToInt32(reader["RoleId"]);
                        role.RoleName = reader["RoleName"].ToString();
                        roleList.Add(role);
                    }
                }
            }
            return roleList;
        }

        public void DeleteRoleByIdDal(int roleId)
        {

            using (SqlConnection connection = new SqlConnection(connect))
            {
                connection.Open();

                using (SqlCommand cmd = new SqlCommand("DELETE FROM Role where RoleId = @roleId", connection))
                {

                    cmd.Parameters.AddWithValue("@roleId", roleId);

                    cmd.ExecuteNonQuery();

                }

            }

        
        }
    }
}
