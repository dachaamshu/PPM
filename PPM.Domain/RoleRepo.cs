using System.Security.Cryptography.X509Certificates;
using PPM.Model;

namespace PPM.Domain
{
  public class RoleRepo : IEntityOperation<Role>
  {
    public static List<Role> roleList = new List<Role>();
    public void AddEntity(Role roleObj)
    {

      roleList.Add(roleObj);

    }

    public List<Role> ListAll()
    {
      return roleList;
    }
    public Role ListById(int id)

    {
      return roleList.Find(item => item.RoleId == id)!;
    }

    public void Delete(int id)
    {
      var t = roleList.SingleOrDefault(item => item.RoleId == id);
      if (t != null)
      {
        roleList.Remove(t);
      }
    }
  }
}