using System.IO.Compression;
using System.Security.Cryptography.X509Certificates;
using PPM.Model;
using PPM.DAL;
using PPM.Dal;

namespace PPM.Domain
{
   public class ProjectRepo : IEntityOperation<Project>
   {
      public static List<Project> projectList = new List<Project>();
      public void AddEntity(Project projectObj)
      {
         //projectList.Add(projectObj);
         ProjectDal projectDal = new ProjectDal();
         projectDal.AddProject(projectObj);

      }


      public List<Project> ListAll()
      {

         ProjectDal projectDal = new ProjectDal();
         var projectlist = projectDal.ViewProject();
         return projectlist;

      }
      public List<Project> ListById(int id)

      {
         //return projectList.Find(item => item.ProjectId == id)!;
         ProjectDal projectDal = new ProjectDal();
         var projectlist = projectDal.ViewProjectByIdDal(id);
         return projectlist;
      }
      public void Delete(int id)
      {

         // var t = projectList.SingleOrDefault(item => item.ProjectId == id);
         // if (t != null)
         // {
         //    projectList.Remove(t);
         // }
         ProjectDal projectDal = new ProjectDal();
         projectDal.DeleteProjectByIdDal(id);

      }

   }
}

