namespace PPM.Model
{
    public interface IEmployeeProject
    {
        public  void AddEmployeeToProject(int projectId, string? projectName, int employeeId, string? firstName, string? lastName, int roleId);

        public void RemoveEmployeefromProject(int projectId, int employeeId);
    }
}