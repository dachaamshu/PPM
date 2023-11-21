using PPM.DAL;
using PPM.Model;

namespace PPM.Domain
{
public class EmployeeProjectRepo : IEmployeeProject
{
    public static List<EmployeeProject> employeeProjectList = new List<EmployeeProject>();

     public  void AddEmployeeToProject(int projectId,string? projectName, int employeeId,string? firstName,string? lastName, int roleId)
    {
        EmployeeProject employeeProject = new EmployeeProject()
        {
            ProjectId = projectId,
            ProjectName = projectName,
            EmployeeId = employeeId,
            FirstName = firstName,
            LastName = lastName,
            RoleId = roleId
        };
        EmployeeProjectDal employeeProjectDal = new EmployeeProjectDal();
        employeeProjectDal.AddEmployeeToProjectDal(employeeProject);
    }

    public void RemoveEmployeefromProject(int projectId,int employeeId)
    {

        EmployeeProjectDal employeeProjectDal = new EmployeeProjectDal();
        bool indexToRemove = employeeProjectDal.IsEmployeeProjectExists(projectId,employeeId);
        List<EmployeeProject> employeeProjectList = employeeProjectDal.ViewEmployeeInProject();
        employeeProjectDal.RemoveEmployeefromProjectDal(projectId,employeeId);
        //bool indexToRemove =  employeeProjectList.FindIndex(item => item.ProjectId == projectId && item.EmployeeId == employeeId);

        // if (indexToRemove >= 0)

        // {

        //     employeeProjectList.RemoveAt(indexToRemove);

        //     Console.WriteLine("Employee Removed From the Project.");
        // }

        // else

        // {
        //     System.Console.WriteLine("Employee not found in the project.");

        // }

    }

    public List<EmployeeProject> ViewEmployeeProject()
    {
        EmployeeProjectDal employeeProjectDal = new EmployeeProjectDal();
        var employeeProjectList = employeeProjectDal.ViewEmployeeInProject();
        return employeeProjectList;
    }

}

}