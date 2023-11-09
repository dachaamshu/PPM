using System;
using System.Runtime.CompilerServices;
using System.Xml.Serialization;
namespace PPM.Model
{
public class Project
{

   public int ProjectId { get; set; }
   public string? ProjectName { get; set; }
   [XmlIgnore]
   public DateOnly StartDate { get; set; }
   [XmlIgnore]
   public DateOnly EndDate { get; set; }

   [XmlElement("StartDate")]
        public string StartdateString
        {
            get { return StartDate.ToString(); }
            set { StartDate = DateOnly.Parse(value); }
        }
 
        [XmlElement("EndDate")]
        public string EnddateString
        {
            get { return EndDate.ToString(); }
            set { EndDate = DateOnly.Parse(value); }
        }

     // public DateTime CreatedOn{get; set;}

     // public DateTime ModifiedOn{get; set;}
 

   public override string ToString()
   {
      return string.Format("{0},{1},{2},{3}", ProjectId, ProjectName, StartDate, EndDate);
   }

}
}