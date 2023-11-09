namespace PPM.Model;

using System;

public class EmployeeProject
{
    public int ProjectId { get; set; }

    public string? ProjectName {get; set;}
    public int EmployeeId { get; set; }

    public string? FirstName {get; set;}

    public string? LastName{get; set;}

    public int RoleId{get; set;}

 // public DateTime CreatedOn{get; set;}

 // public DateTime ModifiedOn{get; set;}
 

    public override string ToString()
    {
        return string.Format("ProjectId : {0}, ProjectName : {1} , EmployeeId : {2} , FirstName : {3} , LastName : {4} RoleId : {5} ", ProjectId, ProjectName , EmployeeId , FirstName , LastName , RoleId);
    }
}