using PPM.Model;
using System.IO;
using System.Runtime.CompilerServices;
using System.Xml.Serialization;

namespace PPM.Domain
{
   public class SaveRepo
   {
      public void SaveData()
      {
         XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Project>));

         using (FileStream projectStream = new FileStream(@"C:\Users\SDacha\Documents\New folder\PROLIFICS PROJECT MANAGER\PPM.Data\ProjectData.xml", FileMode.Create, FileAccess.Write))
         {
            xmlSerializer.Serialize(projectStream, ProjectRepo.projectList);
         }

         xmlSerializer = new XmlSerializer(typeof(List<Employee>));

         using (FileStream employeeStream = new FileStream(@"C:\Users\SDacha\Documents\New folder\PROLIFICS PROJECT MANAGER\PPM.Data\EmployeeData.xml", FileMode.Create, FileAccess.Write))
         {
            xmlSerializer.Serialize(employeeStream, EmployeeRepo.employeeList);
         }

         xmlSerializer = new XmlSerializer(typeof(List<Role>));

         using (FileStream roleStream = new FileStream(@"C:\Users\SDacha\Documents\New folder\PROLIFICS PROJECT MANAGER\PPM.Data\RoleData.xml", FileMode.Create, FileAccess.Write))
         {
            xmlSerializer.Serialize(roleStream, RoleRepo.roleList);
         }

         xmlSerializer = new XmlSerializer(typeof(List<EmployeeProject>));

         using (FileStream employeeProjectStream = new FileStream(@"C:\Users\SDacha\Documents\New folder\PROLIFICS PROJECT MANAGER\PPM.Data\EmployeeProjectData.xml", FileMode.Create, FileAccess.Write))
         {
            xmlSerializer.Serialize(employeeProjectStream, EmployeeProjectRepo.employeeProjectList);
         }

      }
   }
}