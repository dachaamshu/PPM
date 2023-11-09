using System;

public class Role
{
    public int RoleId { get; set; }
    public string? RoleName { get; set; }

 // public DateTime CreatedOn{get; set;}

 // public DateTime ModifiedOn{get; set;}
 
    public override string ToString()
    {
        return string.Format("{0},{1}", RoleId, RoleName);
    }

}