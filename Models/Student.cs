using System.ComponentModel.DataAnnotations;

namespace Product.Models
{
    public class Student
    {
        public int id { get; set; }
        [Required]
        public string name { get; set; }
        public int age { get; set; }
        [EmailAddress]
        public string email { get; set; }
    }
}
