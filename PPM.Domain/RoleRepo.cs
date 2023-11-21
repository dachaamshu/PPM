using System.Security.Cryptography.X509Certificates;
using PPM.Model;
using PPM.DAL;

namespace PPM.Domain
{
  public class RoleRepo : IEntityOperation<Role>
  {
    public static List<Role> roleList = new List<Role>();
    public void AddEntity(Role roleObj)
    {
      RoleDal roleDal = new RoleDal();
      roleDal.AddRole(roleObj);
      //roleList.Add(roleObj);

    }

    public List<Role> ListAll()
    {
      //return roleList;
      RoleDal roleDal = new RoleDal();
      var rolelist = roleDal.ViewRole();
      return rolelist;

    }
    public List<Role> ListById(int id)
    {
      RoleDal roleDal = new RoleDal();
      var rolelist = roleDal.ViewRoleIdByDal(id);
      return rolelist;
     // return roleList;
    }

    public void Delete(int id)
    {
      // var t = roleList.SingleOrDefault(item => item.RoleId == id);
      // if (t != null)
      // {
      //   roleList.Remove(t);
      // }
      RoleDal roleDal = new RoleDal();
      roleDal.DeleteRoleByIdDal(id);

    }
  }
}