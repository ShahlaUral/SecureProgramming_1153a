using System.ComponentModel.DataAnnotations;

namespace CampusDocs.Api.Models
{
    public class Student
    { 
        public string FirstName { get; set; } 
        public string LastName { get; set; } 
        public string StudentCode { get; set; } 
        public string UserName { get; set; }
         
        public string Email { get; set; } 
        public int Age { get; set; }
        public string Status { get; set; }
    }
}
