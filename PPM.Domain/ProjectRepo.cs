using System.IO.Compression;
using System.Security.Cryptography.X509Certificates;
using PPM.Model;

namespace PPM.Domain
{
   public class ProjectRepo : IEntityOperation<Project>
   {
      public static List<Project> projectList = new List<Project>();
      public  void AddEntity(Project projectObj)
      {
         projectList.Add(projectObj);

      }


 public List<Project> ListAll()
 {
   return projectList;
 }
    public Project ListById(int id)

    {
      return projectList.Find(item => item.ProjectId == id)!;
    }
      public void Delete(int id)
      {

         var t = projectList.SingleOrDefault(item => item.ProjectId == id);
         if (t != null)
         {
            projectList.Remove(t);
         }

      }

   }
}

