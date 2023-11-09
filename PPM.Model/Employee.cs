namespace PPM.Model;

using System;
using System.Numerics;
using System.Xml.Serialization;

public class Employee
{
   public int EmployeeId { get; set; }
   public string? FirstName { get; set; }
   public string? LastName { get; set; }
   public string? EmailId { get; set; }
   [XmlIgnore]
   public BigInteger MobileNumber { get; set; }
   public string? Address { get; set; }
   public int RoleId { get; set; }

// public DateTime CreatedOn{get; set;}

 // public DateTime ModifiedOn{get; set;}
 

   [XmlElement("MobileNumber")]
        public string StartdateString
        {
            get { return MobileNumber.ToString(); }
            set { MobileNumber = BigInteger.Parse(value); }
        }

   public override string ToString()
   {
      return string.Format("{0},{1},{2},{3},{4},{5},{6}", EmployeeId, FirstName, LastName, EmailId, MobileNumber, Address, RoleId);
   }


}
